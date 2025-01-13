using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace QuWordFinder.Console.SearchOptions;

public static class StringSearchAnalyzer
{
    public static IEnumerable<string> SearchByAhoCorasick(string text, IEnumerable<string> words)
    {
        var acSearch = new AhoCorasick().BuildTrie(words);
        var result = acSearch.Search(text);
        var searched = result.SelectMany(x => x.Item2).Distinct();
        return searched;
    }

    public static IEnumerable<string> SearchByAhoCorasickTree(string text, IEnumerable<string> words)
    {
        var acSearch = new AhoCorasickTree(words);
        var result = acSearch.FindAll(text);
        return result;
    }

    public static IEnumerable<string> SearchByContainsForEach(string text, IEnumerable<string> words)
    {
        var wordList = words as string[] ?? words.ToArray();
        var found = new string[wordList.Count()];
        var index = 0;

        for (var i = 0; i < wordList.Count(); i++)
        {
            if (!text.Contains(wordList[i], StringComparison.Ordinal))
            {
                continue;
            }

            found[index++] = wordList[i];
        }

        return found.Where(x => !string.IsNullOrEmpty(x));
    }

    public static IEnumerable<string> SearchByContainsParallel(string text, IEnumerable<string> words)
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

    public static IEnumerable<string> SearchByContainsTask(string text, IEnumerable<string> words)
    {
        var tl = words
            .Select(word => Task.Run(() => text.Contains(word, StringComparison.Ordinal) ? word : string.Empty))
            .ToArray();
        Task.WaitAll(tl);

        var found = tl.Where(x => !string.IsNullOrEmpty(x.Result)).Select(x => x.Result).ToArray();

        return found;
    }

    public static IEnumerable<string> SearchByIndexForEach(string text, IEnumerable<string> words)
    {
        var wordList = words as string[] ?? words.ToArray();
        var found = new string[wordList.Count()];
        var index = 0;

        for (var i = 0; i < wordList.Count(); i++)
        {
            if (text.IndexOf(wordList[i], StringComparison.Ordinal) == -1)
            {
                continue;
            }

            found[index++] = wordList[i];
        }

        return found.Where(x => !string.IsNullOrEmpty(x));
    }

    public static IEnumerable<string> SearchByIndexParallel(string text, IEnumerable<string> words)
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

    public static IEnumerable<string> SearchByIndexTask(string text, IEnumerable<string> words)
    {
        var tl = words
            .Select(word => Task.Run(() => text.IndexOf(word, StringComparison.Ordinal) == -1 ? string.Empty : word))
            .ToArray();

        Task.WaitAll(tl);

        var found = tl.Where(x => !string.IsNullOrEmpty(x.Result)).Select(x => x.Result).ToArray();

        return found;
    }

    public static IEnumerable<string> SearchByRegularExpressionForEach(string text, IEnumerable<string> words)
    {
        var wordList = words as string[] ?? words.ToArray();
        var found = new string[wordList.Count()];
        var index = 0;

        for(var i = 0; i < wordList.Count(); i++)
        {
            if (!Regex.IsMatch(text, wordList[i], RegexOptions.IgnoreCase))
            {
                continue;
            };

            found[index++] = wordList[i];
        }

        return found.Where(x => !string.IsNullOrEmpty(x));
    }


    public static IEnumerable<string> SearchByRegularExpressionParallel(string text, IEnumerable<string> words)
    {
        var found = new ConcurrentBag<string>();
        Parallel.ForEach(words, word =>
        {
            if (!Regex.IsMatch(text, word, RegexOptions.IgnoreCase))
            {
                return;
            };

            found.Add(word);
        });

        return found;
    }

    public static IEnumerable<string> SearchByRegularExpressionTask(string text, IEnumerable<string> words)
    {
        var tl = words
            .Select(word => Task.Run(() =>
                Regex.IsMatch(text, word, RegexOptions.IgnoreCase) ? word : string.Empty
            ))
            .ToArray();

        Task.WaitAll(tl);

        return tl.Where(x => !string.IsNullOrEmpty(x.Result)).Select(x => x.Result).ToArray();
    }

    public static IEnumerable<string> SearchBySpanForEach(string text, IEnumerable<string> words)
    {
        var textSpan = text.AsSpan();
        var wordList = words as string[] ?? words.ToArray();
        var found = new string[wordList.Count()];
        var index = 0;

        for(var i = 0; i < wordList.Count(); i++)
        {
            var wordSpan = wordList[i].AsSpan();
            var indexPosition = textSpan.IndexOf(wordSpan, StringComparison.Ordinal);
            if (indexPosition < 0)
            {
                continue;
            }

            found[index++] = wordList[i];
        }

        return found.Where(x => !string.IsNullOrEmpty(x));
    }

    public static IEnumerable<string> SearchBySpanTask(string text, IEnumerable<string> words)
    {
        var tl = words
            .Select(word => Task.Run(() =>
            {
                var textSpan = text.AsSpan();
                var wordSpan = word.AsSpan();
                var index = textSpan.IndexOf(wordSpan, StringComparison.Ordinal);

                return index == -1 ? string.Empty : word;
            }))
            .ToArray();

        Task.WaitAll(tl);

        var found = tl.Where(x => !string.IsNullOrEmpty(x.Result)).Select(x => x.Result).ToArray();

        return found;
    }

    public static IEnumerable<string> SearchBySpanParallel(string text, IEnumerable<string> words)
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
