using System;
using System.Collections;
using System.Collections.Generic;

namespace StructuralPatterns.CompositeTask;

public class NodeIterator : IEnumerator<LightNode>
{
    private readonly Stack<LightNode> _stack = new Stack<LightNode>();
    private readonly Func<LightNode, bool> _predicate;
    private LightNode _current;

    public NodeIterator(LightNode root, Func<LightNode, bool> predicate)
    {
        _stack.Push(root);
        _predicate = predicate;
    }

    public LightNode Current => _current;

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        while (_stack.Count > 0)
        {
            var node = _stack.Pop();

            if (node is LightElementNode elementNode)
            {
                for (int i = elementNode.Children.Count - 1; i >= 0; i--)
                {
                    _stack.Push(elementNode.Children[i]);
                }
            }

            if (_predicate(node))
            {
                _current = node;
                return true;
            }
        }

        return false;
    }

    public void Reset() => throw new NotSupportedException();

    public void Dispose() { }
}