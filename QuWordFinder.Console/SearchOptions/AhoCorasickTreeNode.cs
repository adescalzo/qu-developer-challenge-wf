using System.Diagnostics;

namespace QuWordFinder.Console.SearchOptions;

[DebuggerDisplay("Value = {Value}, TransitionCount = {_transitionsDictionary.Count}")]
internal class AhoCorasickTreeNode
{
    private readonly List<string> _results = [];
    private readonly Dictionary<char, AhoCorasickTreeNode> _transitionsDictionary;
    private readonly AhoCorasickTreeNode? _parent;

    private AhoCorasickTreeNode(AhoCorasickTreeNode? parent, char value)
    {
        Value = value;
        _parent = parent;
        _transitionsDictionary = new Dictionary<char, AhoCorasickTreeNode>();
    }

    public AhoCorasickTreeNode() : this(null, ' ')
    {
    }

    public IEnumerable<string> Results => _results;
    public char Value { get; }

    public AhoCorasickTreeNode? Failure { get; set; }

    public AhoCorasickTreeNode? ParentFailure =>  _parent?.Failure;

    public IEnumerable<AhoCorasickTreeNode> Transitions =>   _transitionsDictionary.Values;

    public void AddResult(string result)
    {
        if (!_results.Contains(result))
        {
            _results.Add(result);
        }
    }

    public void AddResults(IEnumerable<string> results)
    {
        foreach (var result in results)
        {
            AddResult(result);
        }
    }

    public AhoCorasickTreeNode AddTransition(char c)
    {
        var node = new AhoCorasickTreeNode(this, c);
        _transitionsDictionary.Add(node.Value, node);

        return node;
    }

    public AhoCorasickTreeNode? GetTransition(char c)
    {
        return _transitionsDictionary.GetValueOrDefault(c);
    }

    public bool ContainsTransition(char c)
    {
        return _transitionsDictionary.ContainsKey(c);
    }
}