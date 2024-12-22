using BenchmarkDotNet.Running;
using QuWordFinder.Console;

Console.WriteLine("Hello, Qu");

BenchmarkRunner.Run<BenchmarksSearchers>();

/*
BenchmarkDotNet v0.14.0, Arch Linux
   11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 8 logical and 4 physical cores
   .NET SDK 9.0.100
     [Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
     DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


   | Method                            | Mean      | Error     | StdDev    | Median    | Gen0   | Gen1   | Allocated |
   |---------------------------------- |----------:|----------:|----------:|----------:|-------:|-------:|----------:|
   | EvaluateSearchByAhoCorasick       | 46.902 us | 1.2848 us | 3.6448 us | 46.346 us | 5.6763 | 0.5493 |   35672 B |
   | EvaluateSearchByAhoCorasickTree   | 53.077 us | 0.9327 us | 1.3376 us | 52.746 us | 6.5918 | 0.7324 |   41424 B |
   | EvaluateSearchByContains          | 13.902 us | 0.3776 us | 1.0835 us | 13.740 us | 0.6714 | 0.6561 |    4205 B |
   | EvaluateSearchByContainsTask      | 12.079 us | 0.2414 us | 0.6808 us | 11.913 us | 0.6409 |      - |    4168 B |
   | EvaluateSearchByIndex             | 14.773 us | 0.3813 us | 1.0691 us | 14.809 us | 0.6714 | 0.6409 |    4234 B |
   | EvaluateSearchByRegularExpression | 31.778 us | 0.4866 us | 0.4063 us | 31.638 us | 7.8125 | 0.4883 |   49049 B |
   | EvaluateSearchBySearchByValue     | 35.966 us | 1.0874 us | 3.0493 us | 35.982 us | 7.8125 | 0.4883 |   49054 B |
   | EvaluateSearchBySpan              |  2.660 us | 0.1056 us | 0.2997 us |  2.555 us | 0.0572 |      - |     360 B |
   | EvaluateSearchBySpanParallel      | 14.075 us | 0.4154 us | 1.1985 us | 13.688 us | 0.7019 | 0.6714 |    4412 B |

 */