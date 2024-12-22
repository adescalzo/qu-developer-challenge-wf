using FluentAssertions;
using QuWordFinder.Application.Extensions;
using QuWordFinder.Application.Services;
using QuWordFinder.Application.Tests.TestingSupport;

namespace QuWordFinder.Application.Tests.Services;

public class SearchServiceTests
{
    [Fact]
    public void Should_SearchBySpan_Return_List_Of_Found_Words()
    {
        // Arrange
        var matrix = MatrixExamples.Matrix1;
        var words = MatrixExamples.Words1;
        var text = $"{matrix.HorizontalsToString()}{matrix.VerticalsToString()}";
        var searcher = new SearchService();
        var expected = MatrixExamples.WordsOk1;

        // Act
        var result = searcher.SearchBySpan(text, words);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData("", new[] { "word1", "word2" }, new string[0])] // Empty text, no matches
    [InlineData("This is a test sentence.", new[] { "not", "found" }, new string[0])] // No words match
    [InlineData("This is a test sentence containing some words.", new[] { "test", "words", "missing" },
        new[] { "test", "words" })] // Partial matches
    [InlineData("This is for words sentence containing some words and test", new[] { "test", "words", "missing" },
        new[] { "test", "words", "words" })] // Partial matches
    [InlineData("This is a test with multiple words.", new[] { "This", "test", "words" },
        new[] { "This", "test", "words" })] // All words match
    [InlineData("This is a test sentence.", new[] { "this", "Test", "SENTENCE" },
        new string[0])] // Case-sensitive matching
    public void Should_SearchBySpan_Validate_Text_Against_Words_Correctly(string text, string[] words,
        string[] expected)
    {
        // Arrange
        IEnumerable<string> wordList = words;
        var searcher = new SearchService();

        // Act
        var result = searcher.SearchBySpan(text, wordList);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}