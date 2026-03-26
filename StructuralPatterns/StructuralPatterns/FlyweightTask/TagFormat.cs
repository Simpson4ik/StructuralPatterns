using StructuralPatterns.CompositeTask;

namespace StructuralPatterns.FlyweightTask;

public class TagFormat
{
    public string TagName { get; }
    public DisplayType DisplayType { get; }
    public ClosingType ClosingType { get; }

    public TagFormat(string tagName, DisplayType displayType, ClosingType closingType)
    {
        TagName = tagName;
        DisplayType = displayType;
        ClosingType = closingType;
    }
}