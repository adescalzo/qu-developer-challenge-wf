using FluentAssertions;
using QuWordFinder.Application.Helpers;

namespace QuWordFinder.Application.Tests.Helpers;

public class WordFinderGuardsTests
{
    [Theory]
    [InlineData(new[] { "123", "456", "789" }, false)] // Valid square matrix (should not throw)
    [InlineData(new[] { "123", "45", "789" }, true)] // Invalid matrix (different row lengths)
    [InlineData(new string[0], true)] // Empty collection
    [InlineData(new[] { "", "", "" }, true)] // Collection with empty strings
    public void Should_IsMatrix_Validate_Matrix_Correctly(IEnumerable<string> matrix, bool shouldThrow)
    {
        // Act
        var act = () => WordFinderGuards.IsMatrix(matrix);

        // Assert
        if (shouldThrow)
        {
            act.Should().Throw<ArgumentException>().WithMessage("It is not a matrix");
            return;
        }

        act.Should().NotThrow();
    }

    [Theory]
    [InlineData(new[] { "123", "456", "789" }, 5, false)] // Valid: first line length <= max
    [InlineData(new[] { "12345", "67890", "ABCDE" }, 5, false)] // Valid: first line length = max
    [InlineData(new[] { "123456", "7890", "ABCD" }, 5, true)] // Invalid: first line length > max
    [InlineData(new string[0], 5, true)] // Invalid: matrix is empty (null first line)
    public void Should_LengthValidation_Validate_First_Line_Length_Correctly(IEnumerable<string> matrix, int max, bool shouldThrow)
    {
        // Act
        var act = () => WordFinderGuards.LengthValidation(matrix, max);

        // Assert
        if (shouldThrow)
        {
            act.Should().Throw<ArgumentException>().WithMessage("*");
            return;
        }

        act.Should().NotThrow();
    }

    [Fact]
    public void Should_LengthValidation_Throw_ArgumentException_With_Specific_Message_When_First_Line_Is_Null()
    {
        // Arrange
        IEnumerable<string> matrix = new List<string>();
        const int max = 5;

        // Act
        var act = () => WordFinderGuards.LengthValidation(matrix, max);

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("First line of the matrix is null");
    }

    [Fact]
    public void Should_LengthValidation_Throw_ArgumentException_With_Specific_Message_When_First_Line_Exceeds_Max_Length()
    {
        // Arrange
        IEnumerable<string> matrix = new List<string> { "123456" };
        const int max = 5;

        // Act
        var act = () => WordFinderGuards.LengthValidation(matrix, max);

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("First line of the matrix is too long. It is more than max length (5)");
    }
}