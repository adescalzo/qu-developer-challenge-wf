using System.Collections.Concurrent;
using System.Text.RegularExpressions;
using QuWordFinder.Application.Helpers;

namespace QuWordFinder.Console.SearchOptions;

public class StringSearchAnalyzer
{
    public IEnumerable<string> SearchByAhoCorasick(string text, IEnumerable<string> words)
    {
        var acSearch = new AhoCorasick().BuildTrie(words);
        var result = acSearch.Search(text);
        var searched = result.SelectMany(x => x.Item2).Distinct();
        return searched;
    }

    public IEnumerable<string> SearchByAhoCorasickTree(string text, IEnumerable<string> words)
    {
        var acSearch = new AhoCorasickTree(words);
        var result = acSearch.FindAll(text);
        return result;
    }

    public IEnumerable<string> SearchByContains(string text, IEnumerable<string> words)
    {
        var found = new ConcurrentBag<string>();
        Parallel.ForEach(words, word =>
        {
            if (!text.Contains(word, StringComparison.Ordinal))
            {
                return;
            }

            found.Add(word);
        });

        return found;
    }

    public IEnumerable<string> SearchByContainsTask(string text, IEnumerable<string> words)
    {
        var tl = words
            .Select(word => Task.Run(() => text.Contains(word, StringComparison.Ordinal) ? word : string.Empty))
            .ToArray();
        Task.WaitAll(tl);

        var found = tl.Where(x => !string.IsNullOrEmpty(x.Result)).Select(x => x.Result).ToArray();

        return found;
    }

    public IEnumerable<string> SearchByIndex(string text, IEnumerable<string> words)
    {
        var found = new ConcurrentBag<string>();
        Parallel.ForEach(words, word =>
        {
            if (text.IndexOf(word, StringComparison.Ordinal) < 0)
            {
                return;
            }

            found.Add(word);
        });

        return found;
    }

    public IEnumerable<string> SearchByRegularExpression(string text, IEnumerable<string> words)
    {
        var found = new ConcurrentBag<string>();
        Parallel.ForEach(words, word =>
        {
            var rgx = new Regex($@"\b{word}\b");
            var match = rgx.Match(text);
            if (!match.Success)
            {
                return;
            };

            found.Add(word);
        });

        return found;
    }

    public IEnumerable<string> SearchBySpan(string text, IEnumerable<string> words)
    {
        var textSpan = text.AsSpan();
        var found = new List<string>();
        foreach (var word in words)
        {
            var wordSpan = word.AsSpan();
            var index = textSpan.IndexOf(wordSpan, StringComparison.Ordinal);
            if (index < 0)
            {
                continue;
            }

            found.Add(word);
        }

        return found;
    }

    public IEnumerable<string> SearchBySpanParallel(string text, IEnumerable<string> words)
    {
        var found = new ConcurrentBag<string>();
        Parallel.ForEach(words, word =>
        {
            var textSpan = text.AsSpan();
            var wordSpan = word.AsSpan();
            var index = textSpan.IndexOf(wordSpan, StringComparison.Ordinal);
            if (index < 0)
            {
                return;
            }

            found.Add(word);
        });

        return found;
    }
}