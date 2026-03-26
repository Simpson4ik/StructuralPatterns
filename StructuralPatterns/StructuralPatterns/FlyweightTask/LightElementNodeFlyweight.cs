using System.Collections.Generic;
using System.Text;
using StructuralPatterns.CompositeTask;

namespace StructuralPatterns.FlyweightTask;

public class LightElementNodeFlyweight : LightNode
{
    private readonly TagFormat _format;
    private List<LightNode> _children;

    public LightElementNodeFlyweight(TagFormat format)
    {
        _format = format;
    }

    public void Add(LightNode node)
    {
        if (_children == null)
            _children = new List<LightNode>();

        _children.Add(node);
    }

    public override string InnerHTML
    {
        get
        {
            if (_children == null) return string.Empty;
            var sb = new StringBuilder();
            foreach (var child in _children) sb.Append(child.OuterHTML);
            return sb.ToString();
        }
    }

    public override string OuterHTML
    {
        get
        {
            var sb = new StringBuilder();
            sb.Append($"<{_format.TagName}>");
            sb.Append(InnerHTML);

            if (_format.ClosingType == ClosingType.Paired)
                sb.Append($"</{_format.TagName}>");

            return sb.ToString();
        }
    }
}