```

BenchmarkDotNet v0.14.0, Arch Linux
11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method                                    | Mean      | Error      | StdDev     | Median    | Gen0    | Gen1   | Allocated |
|------------------------------------------ |----------:|-----------:|-----------:|----------:|--------:|-------:|----------:|
| EvaluateSearchByAhoCorasick               | 74.612 μs |  6.3512 μs | 17.3863 μs | 68.996 μs |  5.6152 | 0.4883 |   35776 B |
| EvaluateSearchByAhoCorasickTree           | 75.821 μs |  2.4340 μs |  6.7447 μs | 73.728 μs |  6.5918 | 0.7324 |   41464 B |
| EvaluateSearchByContainsForEach           |  3.984 μs |  0.5005 μs |  1.3701 μs |  3.368 μs |  0.0343 |      - |     232 B |
| EvaluateSearchByContainsParallel          | 21.893 μs |  0.4304 μs |  0.6701 μs | 21.824 μs |  0.6714 | 0.6104 |    4371 B |
| EvaluateSearchByContainsTask              | 19.074 μs |  0.3797 μs |  0.8254 μs | 19.065 μs |  0.6409 |      - |    4176 B |
| EvaluateSearchByIndexForEach              |  3.038 μs |  0.0372 μs |  0.0545 μs |  3.029 μs |  0.0343 |      - |     232 B |
| EvaluateSearchByIndexParallel             | 21.068 μs |  0.4089 μs |  0.5459 μs | 21.107 μs |  0.6714 | 0.6409 |    4314 B |
| EvaluateSearchByIndexTask                 | 19.661 μs |  0.4107 μs |  1.1584 μs | 19.557 μs |  0.6409 |      - |    4176 B |
| EvaluateSearchByRegularExpressionForEach  | 79.072 μs |  1.5793 μs |  2.9664 μs | 77.825 μs | 10.8643 | 1.0986 |   68640 B |
| EvaluateSearchByRegularExpressionParallel | 90.615 μs |  6.5644 μs | 18.8345 μs | 81.939 μs |  6.5918 | 6.1035 |   42132 B |
| EvaluateSearchByRegularExpressionTask     | 99.315 μs | 12.0708 μs | 35.4016 μs | 80.315 μs |  5.8594 | 0.4883 |   38573 B |
| EvaluateSearchBySpanForEach               |  3.064 μs |  0.0604 μs |  0.1090 μs |  3.033 μs |  0.0343 |      - |     232 B |
| EvaluateSearchBySpanParallel              | 21.035 μs |  0.3762 μs |  0.4182 μs | 21.102 μs |  0.6714 | 0.6409 |    4244 B |
| EvaluateSearchBySpanTask                  | 19.854 μs |  0.4671 μs |  1.3624 μs | 19.851 μs |  0.6409 |      - |    4176 B |
