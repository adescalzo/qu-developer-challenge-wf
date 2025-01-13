namespace QuWordFinder.Application.Services;

public interface ISearchService
{
    IEnumerable<string> SearchBySpan(string text, IEnumerable<string> words);
}

public class SearchService : ISearchService
{
    /// <summary>
    /// Search values using Span method. Assumes that text and words are all uppercase or all lowercase.
    /// </summary>
    public IEnumerable<string> SearchBySpan(string text, IEnumerable<string> words)
    {
        var textSpan = text.AsSpan(); //Note: It could improve the access to the value in textSpan
        var found = new List<string>();

        foreach (var word in words)
        {
            var wordSpan = word.AsSpan();
            var startIndex = 0;

            //try to search for the word until no more occurrences are found
            while (startIndex < textSpan.Length)
            {
                var index = textSpan[startIndex..].IndexOf(wordSpan, StringComparison.Ordinal);
                if (index < 0)
                {
                    break;
                }

                found.Add(word);
                startIndex += index + wordSpan.Length;
            }
        }

        return found;
    }
}