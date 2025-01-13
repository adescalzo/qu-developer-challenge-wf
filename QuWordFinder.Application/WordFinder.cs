using QuWordFinder.Application.Extensions;
using QuWordFinder.Application.Helpers;
using QuWordFinder.Application.Services;

namespace QuWordFinder.Application;

public class WordFinder
{
    private readonly string _text;
    private readonly SearchService _searchService = new();

    private const int MaxResult = 10;
    private const int MatrixSize = 64;

    public WordFinder(IEnumerable<string> matrix)
    {
        var matrixArray = matrix as string[] ?? matrix.ToArray();

        WordFinderGuards.LengthValidation(matrixArray, MatrixSize);
        WordFinderGuards.IsMatrix(matrixArray);

        var horizontalText = matrixArray.HorizontalsToString();
        var verticalText = matrixArray.VerticalsToString();
        _text = $"{horizontalText}|{verticalText}".ToLower();
    }

    public IEnumerable<string> Find(IEnumerable<string> wordStream)
    {
        var words = wordStream as string[] ?? wordStream.Select(x => x.ToLower()).Distinct().ToArray();
        var wordsFound = _searchService.SearchBySpan(_text, words);

        return wordsFound.SortByMostRepeated().Take(MaxResult);
    }
}