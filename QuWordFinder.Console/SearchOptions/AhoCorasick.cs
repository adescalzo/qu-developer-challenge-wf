namespace QuWordFinder.Console.SearchOptions;

internal class Node
{
    public Dictionary<char, Node> Children { get; } = new ();
    public Node? Fail { get; set; }
    public List<string> Output { get; } = [];
}

internal interface IAhoCorasickSearcher
{
    List<(int, List<string>)> Search(string text);
}

internal class AhoCorasickSearcher(Node root) : IAhoCorasickSearcher
{
    public List<(int, List<string>)> Search(string text)
    {
        var current = root;
        var results = new List<(int, List<string>)>();

        for (var i = 0; i < text.Length; i++)
        {
            while (current != null && !current.Children.ContainsKey(text[i]))
            {
                current = current.Fail;
            }
            if (current == null)
            {
                current = root;
                continue;
            }
            current = current.Children[text[i]];
            if (current.Output.Count > 0)
            {
                results.Add((i, [..current.Output]));
            }
        }
        return results;
    }
}

internal class AhoCorasick
{
    public IAhoCorasickSearcher BuildTrie(IEnumerable<string> patterns)
    {
        var root = new Node();
        foreach (var pattern in patterns)
        {
            var current = root;
            foreach (var c in pattern)
            {
                if (!current.Children.TryGetValue(c, out var value))
                {
                    value = new Node();
                    current.Children[c] = value;
                }
                current = value;
            }
            current.Output.Add(pattern);
        }

        BuildFailureLinks(root);

        return new AhoCorasickSearcher(root);
    }

    private void BuildFailureLinks(Node root)
    {
        var queue = new Queue<Node>();
        foreach (var child in root.Children.Values)
        {
            child.Fail = root;
            queue.Enqueue(child);
        }

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            foreach (var (c, child) in current.Children)
            {
                var fail = current.Fail;
                while (fail is not  null && !fail.Children.ContainsKey(c))
                {
                    fail = fail.Fail;
                }
                if (fail is null)
                {
                    child.Fail = root;
                }
                else
                {
                    child.Fail = fail.Children[c];
                    child.Output.AddRange(child.Fail.Output);
                }

                queue.Enqueue(child);
            }
        }
    }
}
