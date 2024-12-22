using BenchmarkDotNet.Attributes;
using QuWordFinder.Application.Tests.TestingSupport;
using QuWordFinder.Application.Extensions;
using QuWordFinder.Console.SearchOptions;

namespace QuWordFinder.Console;

[MemoryDiagnoser]
public class BenchmarksSearchers
{
    private readonly StringSearchAnalyzer _stringSearchAnalyzer = new();
    private readonly string _text = $"{MatrixExamples.Matrix2.HorizontalsToString()}|{MatrixExamples.Matrix2.VerticalsToString()}";
    private readonly IEnumerable<string> _values = MatrixExamples.Words2;

    [Benchmark]
    public int EvaluateSearchByAhoCorasick()
    {
        var result = _stringSearchAnalyzer.SearchByAhoCorasick(_text, _values);
        return result.Count();
    }

    [Benchmark]
    public int EvaluateSearchByAhoCorasickTree()
    {
        var result = _stringSearchAnalyzer.SearchByAhoCorasickTree(_text, _values);
        return result.Count();
    }

    [Benchmark]
    public int EvaluateSearchByContains()
    {
        var result = _stringSearchAnalyzer.SearchByContains(_text, _values);
        return result.Count();
    }

    [Benchmark]
    public int EvaluateSearchByContainsTask()
    {
        var result = _stringSearchAnalyzer.SearchByContainsTask(_text, _values);
        return result.Count();
    }

    [Benchmark]
    public int EvaluateSearchByIndex()
    {
        var result = _stringSearchAnalyzer.SearchByIndex(_text, _values);
        return result.Count();
    }

    [Benchmark]
    public int EvaluateSearchByRegularExpression()
    {
        var result = _stringSearchAnalyzer.SearchByRegularExpression(_text, _values);
        return result.Count();
    }

    [Benchmark]
    public int EvaluateSearchBySearchByValue()
    {
        var result = _stringSearchAnalyzer.SearchByRegularExpression(_text, _values);
        return result.Count();
    }

    [Benchmark]
    public int EvaluateSearchBySpan()
    {
        var result = _stringSearchAnalyzer.SearchBySpan(_text, _values);
        return result.Count();
    }

    [Benchmark]
    public int EvaluateSearchBySpanParallel()
    {
        var result = _stringSearchAnalyzer.SearchBySpanParallel(_text, _values);
        return result.Count();
    }
}