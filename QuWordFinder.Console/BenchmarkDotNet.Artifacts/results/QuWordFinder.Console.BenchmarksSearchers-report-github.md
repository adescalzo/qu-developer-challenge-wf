```

BenchmarkDotNet v0.14.0, Arch Linux
11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method                            | Mean      | Error     | StdDev    | Median    | Gen0   | Gen1   | Allocated |
|---------------------------------- |----------:|----------:|----------:|----------:|-------:|-------:|----------:|
| EvaluateSearchByAhoCorasick       | 46.902 μs | 1.2848 μs | 3.6448 μs | 46.346 μs | 5.6763 | 0.5493 |   35672 B |
| EvaluateSearchByAhoCorasickTree   | 53.077 μs | 0.9327 μs | 1.3376 μs | 52.746 μs | 6.5918 | 0.7324 |   41424 B |
| EvaluateSearchByContains          | 13.902 μs | 0.3776 μs | 1.0835 μs | 13.740 μs | 0.6714 | 0.6561 |    4205 B |
| EvaluateSearchByContainsTask      | 12.079 μs | 0.2414 μs | 0.6808 μs | 11.913 μs | 0.6409 |      - |    4168 B |
| EvaluateSearchByIndex             | 14.773 μs | 0.3813 μs | 1.0691 μs | 14.809 μs | 0.6714 | 0.6409 |    4234 B |
| EvaluateSearchByRegularExpression | 31.778 μs | 0.4866 μs | 0.4063 μs | 31.638 μs | 7.8125 | 0.4883 |   49049 B |
| EvaluateSearchBySearchByValue     | 35.966 μs | 1.0874 μs | 3.0493 μs | 35.982 μs | 7.8125 | 0.4883 |   49054 B |
| EvaluateSearchBySpan              |  2.660 μs | 0.1056 μs | 0.2997 μs |  2.555 μs | 0.0572 |      - |     360 B |
| EvaluateSearchBySpanParallel      | 14.075 μs | 0.4154 μs | 1.1985 μs | 13.688 μs | 0.7019 | 0.6714 |    4412 B |
