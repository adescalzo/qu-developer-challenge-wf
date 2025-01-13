# Qu Developer challenge: Word Finder

## Analysis and Evaluation

### Get the text of the matrix

It was the first challenge. Because it is the source of the text, to search each word (horizontally and vertically).

To solve it, I created some extensions to get this data. Then included in the constructor of the class to keep this information for each request to find words.

### Validation

Some validations have been included in the constructor of the class to avoid working with an invalid matrix.

### Search words and performance

Having the text from the matrix, the last challenge was to figure out the best efficient way to search these words in the text.
To achieve it, I developed and researched different performance ways to do it, and evaluated each of them with the Benchmark library.
Finally, having the best evaluated option, and according to the latest C# enhancements. The Span method gave me the best solution 
in this case, therefore, I created a service to give support to the WordFinder class.

- Allocating of tasks in memory affects negatively the performance
- Index and Span with foreach has the better performance, but the Span option was chosen because it could improve the performance
assigning contiguous regions of memory of the text and words.

```text
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
```

### Testing

Unit testing was included for each component that required it.

Projects Application and Console have their coresponding test projects.

### Solution and projects

- QuWordFinder.Console: It has the evaluation of the different options and evaluation to search for words in a text.
- QuWordFinder.Application: It is the main project that has solution in the file WordFinder.cs. Furthermore, it includes the other components required for it.
- QuWordFinder.Application.Tests: The project with all the unit tests for QuWordFinder.Application project.

## Information

- Name: Andrés Descalzo.
- Profile: [LinkedIn andresdescalzo](https://www.linkedin.com/in/andresdescalzo/)
- Date: Dic-21-2024 | First version
- Date: Jan-12-2025 | Include other analysis and fixes

## Notes

- f b 3 -> b 5
- f b 3 -> b 5, k b 3
- e b 5
- b 3 -> b 5
- f b 3 -> 5

:(
