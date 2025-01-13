using BenchmarkDotNet.Running;
using QuWordFinder.Console;

Console.WriteLine("Hello, Qu");

BenchmarkRunner.Run<BenchmarksSearchers>();

/*
 * 1 - Contains, Index and Span: In these cases, allocating of tasks in memory affects negatively the performance
 * 2 - Index and Span with foreach has the better performance,
       but the Span option was chosen because it could improve the performance
       assigning contiguous regions of memory of the text and words.
*/

/*
BenchmarkDotNet v0.14.0, Arch Linux
   11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 8 logical and 4 physical cores
   .NET SDK 9.0.100
     [Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
     DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


   | Method                                    | Mean      | Error      | StdDev     | Median    | Gen0    | Gen1   | Allocated |
   |------------------------------------------ |----------:|-----------:|-----------:|----------:|--------:|-------:|----------:|
   | EvaluateSearchByAhoCorasick               | 74.612 us |  6.3512 us | 17.3863 us | 68.996 us |  5.6152 | 0.4883 |   35776 B |
   | EvaluateSearchByAhoCorasickTree           | 75.821 us |  2.4340 us |  6.7447 us | 73.728 us |  6.5918 | 0.7324 |   41464 B |
   | EvaluateSearchByContainsForEach           |  3.984 us |  0.5005 us |  1.3701 us |  3.368 us |  0.0343 |      - |     232 B |
   | EvaluateSearchByContainsParallel          | 21.893 us |  0.4304 us |  0.6701 us | 21.824 us |  0.6714 | 0.6104 |    4371 B |
   | EvaluateSearchByContainsTask              | 19.074 us |  0.3797 us |  0.8254 us | 19.065 us |  0.6409 |      - |    4176 B |
   | EvaluateSearchByIndexForEach              |  3.038 us |  0.0372 us |  0.0545 us |  3.029 us |  0.0343 |      - |     232 B |
   | EvaluateSearchByIndexParallel             | 21.068 us |  0.4089 us |  0.5459 us | 21.107 us |  0.6714 | 0.6409 |    4314 B |
   | EvaluateSearchByIndexTask                 | 19.661 us |  0.4107 us |  1.1584 us | 19.557 us |  0.6409 |      - |    4176 B |
   | EvaluateSearchByRegularExpressionForEach  | 79.072 us |  1.5793 us |  2.9664 us | 77.825 us | 10.8643 | 1.0986 |   68640 B |
   | EvaluateSearchByRegularExpressionParallel | 90.615 us |  6.5644 us | 18.8345 us | 81.939 us |  6.5918 | 6.1035 |   42132 B |
   | EvaluateSearchByRegularExpressionTask     | 99.315 us | 12.0708 us | 35.4016 us | 80.315 us |  5.8594 | 0.4883 |   38573 B |
   | EvaluateSearchBySpanForEach               |  3.064 us |  0.0604 us |  0.1090 us |  3.033 us |  0.0343 |      - |     232 B |
   | EvaluateSearchBySpanParallel              | 21.035 us |  0.3762 us |  0.4182 us | 21.102 us |  0.6714 | 0.6409 |    4244 B |
   | EvaluateSearchBySpanTask                  | 19.854 us |  0.4671 us |  1.3624 us | 19.851 us |  0.6409 |      - |    4176 B |
*/