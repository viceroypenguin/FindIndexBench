```

BenchmarkDotNet v0.15.5, Windows 11 (10.0.26200.6899)
Snapdragon X 12-core X1E80100 3.40 GHz (Max: 3.42GHz), 1 CPU, 12 logical and 12 physical cores
.NET SDK 10.0.100-rc.2.25502.107
  [Host]    : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), Arm64 RyuJIT armv8.0-a
  .NET 10.0 : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), Arm64 RyuJIT armv8.0-a
  .NET 8.0  : .NET 8.0.21 (8.0.21, 8.0.2125.47513), Arm64 RyuJIT armv8.0-a
  .NET 9.0  : .NET 9.0.10 (9.0.10, 9.0.1025.47515), Arm64 RyuJIT armv8.0-a


```
| Method          | Job       | Runtime   | Count  | UseProxy | Mean       | Error     | StdDev    | Ratio | Gen0   | Allocated | Alloc Ratio |
|---------------- |---------- |---------- |------- |--------- |-----------:|----------:|----------:|------:|-------:|----------:|------------:|
| **ToListFindIndex** | **.NET 10.0** | **.NET 10.0** | **10**     | **False**    |  **7.1848 ns** | **0.0784 ns** | **0.0695 ns** |  **1.00** | **0.0076** |      **32 B** |        **1.00** |
| OldFindIndex    | .NET 10.0 | .NET 10.0 | 10     | False    |  5.5263 ns | 0.0038 ns | 0.0032 ns |  0.77 |      - |         - |        0.00 |
| NewFindIndex    | .NET 10.0 | .NET 10.0 | 10     | False    |  0.3852 ns | 0.0015 ns | 0.0013 ns |  0.05 |      - |         - |        0.00 |
|                 |           |           |        |          |            |           |           |       |        |           |             |
| ToListFindIndex | .NET 8.0  | .NET 8.0  | 10     | False    | 15.8470 ns | 0.0730 ns | 0.0683 ns |  1.00 | 0.0076 |      32 B |        1.00 |
| OldFindIndex    | .NET 8.0  | .NET 8.0  | 10     | False    | 11.7037 ns | 0.0043 ns | 0.0036 ns |  0.74 |      - |         - |        0.00 |
| NewFindIndex    | .NET 8.0  | .NET 8.0  | 10     | False    |  4.6912 ns | 0.0257 ns | 0.0215 ns |  0.30 | 0.0153 |      64 B |        2.00 |
|                 |           |           |        |          |            |           |           |       |        |           |             |
| ToListFindIndex | .NET 9.0  | .NET 9.0  | 10     | False    | 12.0828 ns | 0.0961 ns | 0.0899 ns |  1.00 | 0.0076 |      32 B |        1.00 |
| OldFindIndex    | .NET 9.0  | .NET 9.0  | 10     | False    | 23.0577 ns | 0.0080 ns | 0.0074 ns |  1.91 |      - |         - |        0.00 |
| NewFindIndex    | .NET 9.0  | .NET 9.0  | 10     | False    |  4.5824 ns | 0.0169 ns | 0.0141 ns |  0.38 | 0.0153 |      64 B |        2.00 |
|                 |           |           |        |          |            |           |           |       |        |           |             |
| **ToListFindIndex** | **.NET 10.0** | **.NET 10.0** | **10**     | **True**     |  **7.4998 ns** | **0.0489 ns** | **0.0433 ns** |  **1.00** | **0.0076** |      **32 B** |        **1.00** |
| OldFindIndex    | .NET 10.0 | .NET 10.0 | 10     | True     |  9.9156 ns | 0.0614 ns | 0.0545 ns |  1.32 | 0.0115 |      48 B |        1.50 |
| NewFindIndex    | .NET 10.0 | .NET 10.0 | 10     | True     |  7.9498 ns | 0.0555 ns | 0.0492 ns |  1.06 | 0.0115 |      48 B |        1.50 |
|                 |           |           |        |          |            |           |           |       |        |           |             |
| ToListFindIndex | .NET 8.0  | .NET 8.0  | 10     | True     | 15.7530 ns | 0.0354 ns | 0.0296 ns |  1.00 | 0.0076 |      32 B |        1.00 |
| OldFindIndex    | .NET 8.0  | .NET 8.0  | 10     | True     | 21.7153 ns | 0.0842 ns | 0.0746 ns |  1.38 | 0.0115 |      48 B |        1.50 |
| NewFindIndex    | .NET 8.0  | .NET 8.0  | 10     | True     | 17.4880 ns | 0.1166 ns | 0.1090 ns |  1.11 | 0.0115 |      48 B |        1.50 |
|                 |           |           |        |          |            |           |           |       |        |           |             |
| ToListFindIndex | .NET 9.0  | .NET 9.0  | 10     | True     | 12.0661 ns | 0.0359 ns | 0.0318 ns |  1.00 | 0.0076 |      32 B |        1.00 |
| OldFindIndex    | .NET 9.0  | .NET 9.0  | 10     | True     | 18.7082 ns | 0.0625 ns | 0.0554 ns |  1.55 | 0.0115 |      48 B |        1.50 |
| NewFindIndex    | .NET 9.0  | .NET 9.0  | 10     | True     | 17.2729 ns | 0.1137 ns | 0.1063 ns |  1.43 | 0.0115 |      48 B |        1.50 |
|                 |           |           |        |          |            |           |           |       |        |           |             |
| **ToListFindIndex** | **.NET 10.0** | **.NET 10.0** | **1000**   | **False**    |  **7.0642 ns** | **0.0522 ns** | **0.0462 ns** |  **1.00** | **0.0076** |      **32 B** |        **1.00** |
| OldFindIndex    | .NET 10.0 | .NET 10.0 | 1000   | False    |  5.1060 ns | 0.0026 ns | 0.0023 ns |  0.72 |      - |         - |        0.00 |
| NewFindIndex    | .NET 10.0 | .NET 10.0 | 1000   | False    |  0.4454 ns | 0.0010 ns | 0.0009 ns |  0.06 |      - |         - |        0.00 |
|                 |           |           |        |          |            |           |           |       |        |           |             |
| ToListFindIndex | .NET 8.0  | .NET 8.0  | 1000   | False    | 15.7582 ns | 0.0594 ns | 0.0496 ns |  1.00 | 0.0076 |      32 B |        1.00 |
| OldFindIndex    | .NET 8.0  | .NET 8.0  | 1000   | False    | 11.9998 ns | 0.0080 ns | 0.0071 ns |  0.76 |      - |         - |        0.00 |
| NewFindIndex    | .NET 8.0  | .NET 8.0  | 1000   | False    |  4.7047 ns | 0.0332 ns | 0.0278 ns |  0.30 | 0.0153 |      64 B |        2.00 |
|                 |           |           |        |          |            |           |           |       |        |           |             |
| ToListFindIndex | .NET 9.0  | .NET 9.0  | 1000   | False    | 12.1825 ns | 0.0412 ns | 0.0365 ns |  1.00 | 0.0076 |      32 B |        1.00 |
| OldFindIndex    | .NET 9.0  | .NET 9.0  | 1000   | False    | 10.1014 ns | 0.0041 ns | 0.0036 ns |  0.83 |      - |         - |        0.00 |
| NewFindIndex    | .NET 9.0  | .NET 9.0  | 1000   | False    |  4.5783 ns | 0.0185 ns | 0.0155 ns |  0.38 | 0.0153 |      64 B |        2.00 |
|                 |           |           |        |          |            |           |           |       |        |           |             |
| **ToListFindIndex** | **.NET 10.0** | **.NET 10.0** | **1000**   | **True**     |  **7.4780 ns** | **0.0459 ns** | **0.0407 ns** |  **1.00** | **0.0076** |      **32 B** |        **1.00** |
| OldFindIndex    | .NET 10.0 | .NET 10.0 | 1000   | True     |  9.8163 ns | 0.0474 ns | 0.0420 ns |  1.31 | 0.0115 |      48 B |        1.50 |
| NewFindIndex    | .NET 10.0 | .NET 10.0 | 1000   | True     |  7.9300 ns | 0.0477 ns | 0.0423 ns |  1.06 | 0.0115 |      48 B |        1.50 |
|                 |           |           |        |          |            |           |           |       |        |           |             |
| ToListFindIndex | .NET 8.0  | .NET 8.0  | 1000   | True     | 24.9453 ns | 0.0578 ns | 0.0512 ns |  1.00 | 0.0076 |      32 B |        1.00 |
| OldFindIndex    | .NET 8.0  | .NET 8.0  | 1000   | True     | 25.6031 ns | 0.0869 ns | 0.0770 ns |  1.03 | 0.0115 |      48 B |        1.50 |
| NewFindIndex    | .NET 8.0  | .NET 8.0  | 1000   | True     | 18.4052 ns | 0.0609 ns | 0.0569 ns |  0.74 | 0.0115 |      48 B |        1.50 |
|                 |           |           |        |          |            |           |           |       |        |           |             |
| ToListFindIndex | .NET 9.0  | .NET 9.0  | 1000   | True     | 12.6254 ns | 0.0384 ns | 0.0340 ns |  1.00 | 0.0076 |      32 B |        1.00 |
| OldFindIndex    | .NET 9.0  | .NET 9.0  | 1000   | True     | 18.7078 ns | 0.0488 ns | 0.0408 ns |  1.48 | 0.0115 |      48 B |        1.50 |
| NewFindIndex    | .NET 9.0  | .NET 9.0  | 1000   | True     | 17.3300 ns | 0.0898 ns | 0.0840 ns |  1.37 | 0.0115 |      48 B |        1.50 |
|                 |           |           |        |          |            |           |           |       |        |           |             |
| **ToListFindIndex** | **.NET 10.0** | **.NET 10.0** | **100000** | **False**    |  **7.0597 ns** | **0.0334 ns** | **0.0296 ns** |  **1.00** | **0.0076** |      **32 B** |        **1.00** |
| OldFindIndex    | .NET 10.0 | .NET 10.0 | 100000 | False    |  4.9405 ns | 0.0023 ns | 0.0022 ns |  0.70 |      - |         - |        0.00 |
| NewFindIndex    | .NET 10.0 | .NET 10.0 | 100000 | False    |  0.4189 ns | 0.0011 ns | 0.0010 ns |  0.06 |      - |         - |        0.00 |
|                 |           |           |        |          |            |           |           |       |        |           |             |
| ToListFindIndex | .NET 8.0  | .NET 8.0  | 100000 | False    | 15.9139 ns | 0.0455 ns | 0.0403 ns |  1.00 | 0.0076 |      32 B |        1.00 |
| OldFindIndex    | .NET 8.0  | .NET 8.0  | 100000 | False    | 33.8305 ns | 0.0188 ns | 0.0167 ns |  2.13 |      - |         - |        0.00 |
| NewFindIndex    | .NET 8.0  | .NET 8.0  | 100000 | False    |  4.6808 ns | 0.0311 ns | 0.0276 ns |  0.29 | 0.0153 |      64 B |        2.00 |
|                 |           |           |        |          |            |           |           |       |        |           |             |
| ToListFindIndex | .NET 9.0  | .NET 9.0  | 100000 | False    | 12.0684 ns | 0.0451 ns | 0.0400 ns |  1.00 | 0.0076 |      32 B |        1.00 |
| OldFindIndex    | .NET 9.0  | .NET 9.0  | 100000 | False    |  9.7301 ns | 0.0062 ns | 0.0055 ns |  0.81 |      - |         - |        0.00 |
| NewFindIndex    | .NET 9.0  | .NET 9.0  | 100000 | False    |  4.5450 ns | 0.0097 ns | 0.0081 ns |  0.38 | 0.0153 |      64 B |        2.00 |
|                 |           |           |        |          |            |           |           |       |        |           |             |
| **ToListFindIndex** | **.NET 10.0** | **.NET 10.0** | **100000** | **True**     |  **7.0601 ns** | **0.0542 ns** | **0.0480 ns** |  **1.00** | **0.0076** |      **32 B** |        **1.00** |
| OldFindIndex    | .NET 10.0 | .NET 10.0 | 100000 | True     |  9.8142 ns | 0.0232 ns | 0.0205 ns |  1.39 | 0.0115 |      48 B |        1.50 |
| NewFindIndex    | .NET 10.0 | .NET 10.0 | 100000 | True     |  8.0083 ns | 0.0750 ns | 0.0665 ns |  1.13 | 0.0115 |      48 B |        1.50 |
|                 |           |           |        |          |            |           |           |       |        |           |             |
| ToListFindIndex | .NET 8.0  | .NET 8.0  | 100000 | True     | 15.8505 ns | 0.0594 ns | 0.0496 ns |  1.00 | 0.0076 |      32 B |        1.00 |
| OldFindIndex    | .NET 8.0  | .NET 8.0  | 100000 | True     | 42.9407 ns | 0.0849 ns | 0.0752 ns |  2.71 | 0.0114 |      48 B |        1.50 |
| NewFindIndex    | .NET 8.0  | .NET 8.0  | 100000 | True     | 18.3197 ns | 0.0700 ns | 0.0655 ns |  1.16 | 0.0115 |      48 B |        1.50 |
|                 |           |           |        |          |            |           |           |       |        |           |             |
| ToListFindIndex | .NET 9.0  | .NET 9.0  | 100000 | True     | 12.0510 ns | 0.0496 ns | 0.0440 ns |  1.00 | 0.0076 |      32 B |        1.00 |
| OldFindIndex    | .NET 9.0  | .NET 9.0  | 100000 | True     | 18.7322 ns | 0.0712 ns | 0.0631 ns |  1.55 | 0.0115 |      48 B |        1.50 |
| NewFindIndex    | .NET 9.0  | .NET 9.0  | 100000 | True     | 17.2780 ns | 0.0615 ns | 0.0545 ns |  1.43 | 0.0115 |      48 B |        1.50 |
