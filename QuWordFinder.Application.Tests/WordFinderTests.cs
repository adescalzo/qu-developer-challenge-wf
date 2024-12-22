using FluentAssertions;

namespace QuWordFinder.Application.Tests;

public class WordFinderTests
{
    [Theory]
    [InlineData(new[] { "123", "45", "789" }, "It is not a matrix")] // Invalid matrix (rows of unequal lengths)
    [InlineData(new[] { "123456789012345678901234567890123456789012345678901234567890123456", // Over sized rows
            "123456789012345678901234567890123456789012345678901234567890123456" },
        "First line of the matrix is too long. It is more than max length (64)")]
    public void Should_WordFinder_Throw_ArgumentException_With_Expected_Message_When_Matrix_Is_Invalid(string[] matrix, string expectedMessage)
    {
        // Act
        Action act = () => new WordFinder(matrix);

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage(expectedMessage);
    }

    [Theory]
    [InlineData(
        new[] { "abcd", "efgh", "ijkl", "mnop" },
        new[] { "abc", "ghi", "aei", "aei", "xyz" },
        new[] { "aei", "abc", })] // Finds words in horizontal and vertical lines
    [InlineData(
        new[] { "abcd", "efgh", "ijkl", "mnop" },
        new[] { "mnop", "efgh", "abcd" },
        new[] { "mnop", "efgh", "abcd" })] // Finds words in descending order of appearance
    [InlineData(
        new[] { "abcd", "efgh", "ijkl", "mnop" },
        new[] { "xyz", "uvw" },
        new string[0])] // No matches
    [InlineData(
        new[] { "abcd", "efgh", "ijkl", "mnop" },
        new[] { "mnop", "mnop", "mnop" },
        new[] { "mnop" })] // Removes duplicates from the wordStream
    public void Should_Find_Return_Correct_Words_From_Text(string[] matrix, string[] wordStream, string[] expected)
    {
        // Arrange
        var wordFinder = new WordFinder(matrix);

        // Act
        var result = wordFinder.Find(wordStream);

        // Assert
        result.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }

    [Theory]
    [InlineData(
        new[] { "abcd", "efgh", "ijkl", "mnop" },
        new[] { "mnop", "mnop", "mnop", "mnop", "mnop", "abcd", "ijkl", "efgh", "abcd", "mnop", "ijkl", "abcd" },
        new[] { "mnop", "abcd", "ijkl", "efgh" })] // Limits to MaxResult (10 by default)
    public void Should_Find_Limit_Results_To_MaxResult(string[] matrix, string[] wordStream, string[] expected)
    {
        // Arrange
        var wordFinder = new WordFinder(matrix);

        // Act
        var result = wordFinder.Find(wordStream);

        // Assert
        result.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }
}