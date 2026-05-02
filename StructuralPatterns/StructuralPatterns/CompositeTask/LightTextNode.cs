namespace StructuralPatterns.CompositeTask;

public class LightTextNode : LightNode
{
    private readonly string _text;
    public override void Accept(IVisitor visitor) => visitor.VisitTextNode(this);

    public LightTextNode(string text)
    {
        _text = text;
    }

    public override string OuterHTML => _text;
    public override string InnerHTML => _text;
}