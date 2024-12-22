namespace QuWordFinder.Console.SearchOptions;

public class AhoCorasickTree
{
    private readonly AhoCorasickTreeNode _root;

    public AhoCorasickTree(IEnumerable<string> keywords)
    {
        _root = new AhoCorasickTreeNode();

        if (keywords is null)
        {
            return;
        }
        
        foreach (var p in keywords)
        {
            AddPatternToTree(p);
        }

        SetFailureNodes();
    }

    public bool Contains(string text)
    {
        return Contains(text, false);
    }

    public bool ContainsThatStart(string text)
    {
        return Contains(text, true);
    }

    private bool Contains(string text, bool onlyStarts)
    {
        var pointer = _root;

        foreach (var c in text)
        {
            var transition = GetTransition(c, ref pointer);

            if (transition != null)
            {
                pointer = transition;
            }
            else if (onlyStarts)
            {
                return false;
            }
            if (pointer?.Results.Any() ?? false)
            {
                return true;
            }
        }

        return false;
    }

    public IEnumerable<string> FindAll(string text)
    {
        var pointer = _root;
        var results = new List<string>();
        foreach (var c in text)
        {
            var transition = GetTransition(c, ref pointer);

            if (transition != null)
            {
                pointer = transition;
            }

            foreach (var result in pointer?.Results ?? [])
            {
                results.Add(result);
            }
        }

        return results;
    }

    private AhoCorasickTreeNode? GetTransition(char c, ref AhoCorasickTreeNode? pointer)
    {
        AhoCorasickTreeNode? transition = null;
        while (transition == null)
        {
            transition = pointer?.GetTransition(c);
            if (pointer == _root)
            {
                break;
            }

            if (transition == null)
            {
                pointer = pointer?.Failure;
            }
        }

        return transition;
    }

    private void SetFailureNodes()
    {
        var nodes = FailToRootNode();
        FailUsingBFS(nodes);
        _root.Failure = _root;
    }

    private void AddPatternToTree(string pattern)
    {
        var node = pattern.Aggregate(_root, (current, c) => current.GetTransition(c) ?? current.AddTransition(c));
        node.AddResult(pattern);
    }

    private List<AhoCorasickTreeNode> FailToRootNode()
    {
        var nodes = new List<AhoCorasickTreeNode>();
        foreach (var node in _root.Transitions)
        {
            node.Failure = _root;
            nodes.AddRange(node.Transitions);
        }

        return nodes;
    }

    private void FailUsingBFS(List<AhoCorasickTreeNode> nodes)
    {
        while (nodes.Count != 0)
        {
            var newNodes = new List<AhoCorasickTreeNode>();
            foreach (var node in nodes)
            {
                var failure = node.ParentFailure;
                var value = node.Value;

                while (failure != null && !failure.ContainsTransition(value))
                {
                    failure = failure.Failure;
                }

                if (failure is null)
                {
                    node.Failure = _root;
                }
                else
                {
                    var f = failure.GetTransition(value);
                    if (f is not null)
                    {
                        node.Failure = f;
                        node.AddResults(node.Failure.Results);
                    }
                }

                newNodes.AddRange(node.Transitions);
            }

            nodes = newNodes;
        }
    }
}