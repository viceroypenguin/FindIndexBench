using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace FindIndexBench;

[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
[MemoryDiagnoser]
public class Benchmarks
{
    [GlobalSetup]
    public void Setup()
    {
        var random = new Random(Count);

        var values = Enumerable.Range(0, Count)
            .Select(_ => Guid.NewGuid().ToString())
            .ToArray();

        _values = values;

        var item = random.Next(Count);
        _predicate = x => x == values[item];
        _predicateFunc = x => x == values[item];
    }

    private Func<string, bool> _predicateFunc = null!;
    private Predicate<string> _predicate = null!;
    private IEnumerable<string> _values = null!;

    [Params(10, 1_000, 100_000)]
    public int Count { get; set; }

    public IEnumerable<string> Values => UseProxy ? IteratorValues() : _values;

    [Params(true, false)]
    public bool UseProxy { get; set; }

    private IEnumerable<string> IteratorValues()
    {
        foreach (var v in _values)
            yield return v;
    }

    [Benchmark(Baseline = true)]
    public int ToListFindIndex()
    {
        return Values.ToList().FindIndex(_predicate);
    }

    public int SelectFirstOrDefaultWithAnonymousType()
    {
        var result = Values
            .Select((value, index) => new { value, index })
            .FirstOrDefault(x => _predicateFunc(x.value));

        return result?.index ?? -1;
    }

    [Benchmark]
    public int OldFindIndex()
    {
        return OldFindIndex(Values, _predicateFunc);
    }

    public static int OldFindIndex<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        return OldFindIndex(source, predicate, 0, int.MaxValue);
    }

    internal static int? TryGetCollectionCount<T>(IEnumerable<T> source)
    {
        ArgumentNullException.ThrowIfNull(source);

        return source.TryGetNonEnumeratedCount(out var count) ? count : default(int?);
    }

    public static int OldFindIndex<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate, Index index, int count)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentOutOfRangeException.ThrowIfNegative(count);

        if (TryGetCollectionCount(source) is int length)
            index = index.GetOffset(length);

        if (!index.IsFromEnd)
        {
            var i = 0;
            var c = 0;
            foreach (var element in source)
            {
                if (i >= index.Value)
                {
                    if (predicate(element))
                        return i;

                    if (++c >= count)
                        return -1;
                }

                i++;
            }

            return -1;
        }
        else
        {
            using var e = source.GetEnumerator();

            var indexFromEnd = index.Value;
            var i = 0;
            if (e.MoveNext())
            {
                Queue<TSource> queue = new();
                queue.Enqueue(e.Current);

                while (e.MoveNext())
                {
                    if (queue.Count == indexFromEnd)
                    {
                        _ = queue.Dequeue();
                        i++;
                    }

                    queue.Enqueue(e.Current);
                }

                var c = 0;
                while (queue.Count != 0)
                {
                    if (predicate(queue.Dequeue()))
                        return i;

                    if (++c >= count)
                        return -1;

                    i++;
                }
            }

            return -1;
        }
    }

    [Benchmark]
    public int NewFindIndex()
    {
        return NewFindIndex(Values, _predicateFunc);
    }

    public static int NewFindIndex<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        return NewFindIndex(source, predicate, 0, int.MaxValue);
    }

    public static int NewFindIndex<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate, int index, int count)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentOutOfRangeException.ThrowIfNegative(index);
        ArgumentOutOfRangeException.ThrowIfNegative(count);

        return FindIndexForward(source, predicate, index, count);
    }

    private static int FindIndexForward<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate, int index, int count)
    {
        return source switch
        {
            TSource[] array => Array.FindIndex(array, index, Math.Min(array.Length - index, count), predicate.Invoke),
            List<TSource> list => list.FindIndex(index, Math.Min(list.Count - index, count), predicate.Invoke),
            _ => DoFindIndexForward(source, predicate, index, count),
        };
    }

    private static int DoFindIndexForward<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate, int index, int count)
    {
        var i = 0;
        var c = 0;
        foreach (var element in source)
        {
            if (i >= index)
            {
                if (predicate(element))
                    return i;

                if (++c >= count)
                    return -1;
            }

            i++;
        }

        return -1;
    }
}
