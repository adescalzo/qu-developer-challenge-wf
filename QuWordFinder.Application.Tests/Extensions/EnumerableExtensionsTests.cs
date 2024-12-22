using FluentAssertions;
using QuWordFinder.Application.Extensions;
using QuWordFinder.Application.Tests.TestingSupport;

namespace QuWordFinder.Application.Tests.Extensions;

public class EnumerableExtensionsTests
{
    [Fact]
    public void Should_IsMatrix_Return_False_When_Collection_Is_Empty()
    {
        // Arrange
        IEnumerable<string> values = new List<string>();

        // Act
        var result = values.IsMatrix();

        // Assert
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData(new[] { "123", "456", "789" }, true)] // Valid square matrix
    [InlineData(new[] { "123", "45", "789" }, false)] // Rows of different lengths
    [InlineData(new[] { "123", "456", "789", "012" }, false)] // More rows than columns
    [InlineData(new[] { "12345", "67890" }, false)] // Fewer rows than columns
    public void Should_IsMatrix_Validate_Square_Matrix_Correctly(IEnumerable<string> values, bool expected)
    {
        // Act
        var result = values.IsMatrix();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Should_IsMatrix_Validate_Model1_Matrix_Correctly()
    {
        // Act
        var result = MatrixExamples.Matrix1.IsMatrix();

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Should_IsMatrix_Validate_Model2_Matrix_Correctly()
    {
        // Act
        var result = MatrixExamples.Matrix2.IsMatrix();

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Should_HorizontalsToString_Return_EmptyString_When_Collection_Is_Empty()
    {
        // Arrange
        IEnumerable<string> values = new List<string>();

        // Act
        var result = values.HorizontalsToString();

        // Assert
        result.Should().BeEmpty();
    }

    [Theory]
    [InlineData(new[] { "123", "456", "789" }, "123|456|789")] // Normal case
    [InlineData(new[] { "abc" }, "abc")] // Single string
    [InlineData(new string[0], "")] // Empty collection
    [InlineData(new[] { "", "", "" }, "||")] // Empty strings
    public void Should_HorizontalsToString_Return_Correct_String(IEnumerable<string> values, string expected)
    {
        // Act
        var result = values.HorizontalsToString();

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(new[] { "abc", "def", "ghi" }, "adg|beh|cfi")] // Valid square matrix
    [InlineData(new[] { "abcg", "defj", "ghil", "ghiw" }, "adgg|behh|cfii|gjlw")] // Valid square matrix
    public void Should_VerticalsToString_Return_Correct_String_For_Valid_Matrix(IEnumerable<string> values, string expected)
    {
        // Act
        var result = values.VerticalsToString();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Should_VerticalsToString_Throw_ArgumentException_When_Matrix_Is_Not_Valid()
    {
        // Arrange
        IEnumerable<string> values = new List<string> { "abc", "de", "fgh" };

        // Act
        var act = () => values.VerticalsToString();

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("It has not a matrix structure.");
    }

    [Theory]
    [InlineData(new[] { "apple", "banana", "apple", "orange", "banana", "banana" }, new[] { "banana", "apple", "orange" })] // Normal case
    [InlineData(new[] { "a", "b", "c", "b", "c" }, new[] { "b", "c", "a" })] // No repeats
    [InlineData(new[] { "x", "x", "x", "y", "y", "z" }, new[] { "x", "y", "z" })] // Mixed frequencies
    [InlineData(new string[0], new string[0])] // Empty input
    [InlineData(new[] { "same", "same", "same", "same" }, new[] { "same" })] // All items are the same
    public void Should_SortByMostRepeated_Return_Values_Sorted_By_Frequency(IEnumerable<string> input, IEnumerable<string> expected)
    {
        // Act
        var result = input.SortByMostRepeated();

        // Assert
        result.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }
}