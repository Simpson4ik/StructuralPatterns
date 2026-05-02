namespace StructuralPatterns.CompositeTask;

public abstract class LightNode
{
    public abstract string OuterHTML { get; }
    public abstract string InnerHTML { get; }

    public abstract void Accept(IVisitor visitor);
}