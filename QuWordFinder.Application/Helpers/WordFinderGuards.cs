using QuWordFinder.Application.Extensions;

namespace QuWordFinder.Application.Helpers;

public static class WordFinderGuards
{
    public static void IsMatrix(IEnumerable<string> matrix)
    {
        if (!matrix.IsMatrix())
        {
            throw new ArgumentException("It is not a matrix");
        }
    }

    public static void LengthValidation(IEnumerable<string> matrix, int max)
    {
        var firstLine = matrix.FirstOrDefault();
        if (firstLine is null)
        {
            throw new ArgumentException("First line of the matrix is null");
        }

        if (firstLine.Length > max)
        {
            throw new ArgumentException($"First line of the matrix is too long. It is more than max length ({max})");
        }
    }
}