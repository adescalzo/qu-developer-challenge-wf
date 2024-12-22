namespace QuWordFinder.Application.Extensions;

public static class EnumerableExtensions
{
    /// <summary>
    ///  Evaluate if the enumerable is a matrix
    /// </summary>
    public static bool IsMatrix(this IEnumerable<string> values)
    {
        var internalValues = values as string[] ?? values.ToArray();
        var count = internalValues.Length;
        if (count == 0)
        {
            return false;
        }

        var lng = internalValues.First().Length;
        return lng == count && internalValues.All(item => item.Length == lng);
    }

    /// <summary>
    /// Get the horizontal lines in a string
    /// </summary>
    public static string HorizontalsToString(this IEnumerable<string> values)
    {
        var internalValues = values as string[] ?? values.ToArray();
        return internalValues.Length > 0 ? string.Join('|', internalValues) : string.Empty;
    }

    /// <summary>
    /// Get the vertical lines in a string
    /// </summary>
    public static string VerticalsToString(this IEnumerable<string> values)
    {
        var internalValues = values as string[] ?? values.ToArray();
        if (!internalValues.IsMatrix())
        {
            throw new ArgumentException("It has not a matrix structure.");
        }

        var range = Enumerable.Range(0, internalValues.First().Length);
        var verticalLines = new string[internalValues.Length];
        foreach (var index in range)
        {
            verticalLines[index] = string.Join("", internalValues.Select(x => x[index]));
        }

        return verticalLines.HorizontalsToString();
    }

    /// <summary>
    /// Get a list sorted by most repeated
    /// </summary>
    public static IEnumerable<string> SortByMostRepeated(this IEnumerable<string> values)
    {
        var internalValues = values as string[] ?? values.ToArray();
        var wordsCount = internalValues.GroupBy(item => item).ToDictionary(x => x.Key, x => x.Count());
        var wordsOrdered= wordsCount.OrderByDescending(x => x.Value).Select(x => x.Key).ToList();

        return wordsOrdered;
    }
}