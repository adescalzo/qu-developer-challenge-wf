using FluentAssertions;
using QuWordFinder.Console.SearchOptions;
using QuWordFinder.Application.Tests.TestingSupport;
using QuWordFinder.Application.Extensions;

namespace QuWordFinder.Console.Tests.SearchOptions;

public class StringSearchServiceContainsTests
{
    private readonly string _text = $"{MatrixExamples.Matrix2.HorizontalsToString()}|{MatrixExamples.Matrix2.VerticalsToString()}";
    private readonly IEnumerable<string> _values = MatrixExamples.Words2;
    private const int CountUniqueFindValues = 14;

    [Fact]
    public void Should_SearchByContainsTask_Search_Values()
    {
        var result = StringSearchAnalyzer.SearchByContainsTask(_text, _values);

        result.Distinct().Count().Should().Be(CountUniqueFindValues);
    }

    [Fact]
    public void Should_SearchBySearchByContainsParallel_Search_Values()
    {
        var result = StringSearchAnalyzer.SearchByContainsParallel(_text, _values);

        result.Distinct().Count().Should().Be(CountUniqueFindValues);
    }

    [Fact]
    public void Should_SearchByContainsForEach_Search_Values()
    {
        var result = StringSearchAnalyzer.SearchByContainsForEach(_text, _values);

        result.Distinct().Count().Should().Be(CountUniqueFindValues);
    }
}