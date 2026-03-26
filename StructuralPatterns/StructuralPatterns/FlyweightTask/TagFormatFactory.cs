using System.Collections.Generic;
using StructuralPatterns.CompositeTask;

namespace StructuralPatterns.FlyweightTask;

public class TagFormatFactory
{
    private readonly Dictionary<string, TagFormat> _formats = new();

    public TagFormat GetFormat(string tagName, DisplayType displayType, ClosingType closingType)
    {
        if (!_formats.ContainsKey(tagName))
        {
            _formats[tagName] = new TagFormat(tagName, displayType, closingType);
        }
        return _formats[tagName];
    }
}