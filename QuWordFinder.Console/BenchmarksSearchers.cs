using BenchmarkDotNet.Attributes;
using QuWordFinder.Application.Tests.TestingSupport;
using QuWordFinder.Application.Extensions;
using QuWordFinder.Console.SearchOptions;

namespace QuWordFinder.Console;

[MemoryDiagnoser]
public class BenchmarksSearchers
{
    private readonly string _text = $"{MatrixExamples.Matrix2.HorizontalsToString()}|{MatrixExamples.Matrix2.VerticalsToString()}";
    private readonly IEnumerable<string> _values = MatrixExamples.Words2;

    [Benchmark]
    public int EvaluateSearchByAhoCorasick()
    {
        var result = StringSearchAnalyzer.SearchByAhoCorasick(_text, _values);
        return result.Count();
    }

    [Benchmark]
    public int EvaluateSearchByAhoCorasickTree()
    {
        var result = StringSearchAnalyzer.SearchByAhoCorasickTree(_text, _values);
        return result.Count();
    }

    [Benchmark]
    public int EvaluateSearchByContainsForEach()
    {
        var result = StringSearchAnalyzer.SearchByContainsForEach(_text, _values);
        return result.Count();
    }

    [Benchmark]
    public int EvaluateSearchByContainsParallel()
    {
        var result = StringSearchAnalyzer.SearchByContainsParallel(_text, _values);
        return result.Count();
    }

    [Benchmark]
    public int EvaluateSearchByContainsTask()
    {
        var result = StringSearchAnalyzer.SearchByContainsTask(_text, _values);
        return result.Count();
    }

    [Benchmark]
    public int EvaluateSearchByIndexForEach()
    {
        var result = StringSearchAnalyzer.SearchByIndexForEach(_text, _values);
        return result.Count();
    }

    [Benchmark]
    public int EvaluateSearchByIndexParallel()
    {
        var result = StringSearchAnalyzer.SearchByIndexParallel(_text, _values);
        return result.Count();
    }

    [Benchmark]
    public int EvaluateSearchByIndexTask()
    {
        var result = StringSearchAnalyzer.SearchByIndexTask(_text, _values);
        return result.Count();
    }

    [Benchmark]
    public int EvaluateSearchByRegularExpressionForEach()
    {
        var result = StringSearchAnalyzer.SearchByRegularExpressionForEach(_text, _values);
        return result.Count();
    }

    [Benchmark]
    public int EvaluateSearchByRegularExpressionParallel()
    {
        var result = StringSearchAnalyzer.SearchByRegularExpressionParallel(_text, _values);
        return result.Count();
    }

    [Benchmark]
    public int EvaluateSearchByRegularExpressionTask()
    {
        var result = StringSearchAnalyzer.SearchByRegularExpressionTask(_text, _values);
        return result.Count();
    }

    [Benchmark]
    public int EvaluateSearchBySpanForEach()
    {
        var result = StringSearchAnalyzer.SearchBySpanForEach(_text, _values);
        return result.Count();
    }

    [Benchmark]
    public int EvaluateSearchBySpanParallel()
    {
        var result = StringSearchAnalyzer.SearchBySpanParallel(_text, _values);
        return result.Count();
    }

    [Benchmark]
    public int EvaluateSearchBySpanTask()
    {
        var result = StringSearchAnalyzer.SearchBySpanTask(_text, _values);
        return result.Count();
    }
}