using FluentAssertions;
using QuWordFinder.Console.SearchOptions;
using QuWordFinder.Application.Tests.TestingSupport;
using QuWordFinder.Application.Extensions;

namespace QuWordFinder.Console.Tests.SearchOptions;

public class StringSearchServiceSpanTests
{
    private readonly string _text = $"{MatrixExamples.Matrix2.HorizontalsToString()}|{MatrixExamples.Matrix2.VerticalsToString()}";
    private readonly IEnumerable<string> _values = MatrixExamples.Words2;
    private const int CountUniqueFindValues = 14;

    [Fact]
    public void Should_SearchBySpanTask_Search_Values()
    {
        var result = StringSearchAnalyzer.SearchBySpanTask(_text, _values);

        result.Distinct().Count().Should().Be(CountUniqueFindValues);
    }

    [Fact]
    public void Should_SearchBySearchBySpanParallel_Search_Values()
    {
        var result = StringSearchAnalyzer.SearchBySpanParallel(_text, _values);

        result.Distinct().Count().Should().Be(CountUniqueFindValues);
    }
    
    [Fact]
    public void Should_SearchBySpanForEach_Search_Values()
    {
        var result = StringSearchAnalyzer.SearchBySpanForEach(_text, _values);

        result.Distinct().Count().Should().Be(CountUniqueFindValues);
    }
}