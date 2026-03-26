using System;
using System.Text.RegularExpressions;

namespace StructuralPatterns.ProxyTask;

public class SmartTextReaderLocker : ITextReader
{
    private readonly ITextReader _realReader;
    private readonly Regex _regex;

    public SmartTextReaderLocker(ITextReader realReader, string pattern)
    {
        _realReader = realReader;
        _regex = new Regex(pattern);
    }

    public char[][] ReadText(string filePath)
    {
        if (_regex.IsMatch(filePath))
        {
            Console.WriteLine("Access denied!");
            return Array.Empty<char[]>();
        }

        return _realReader.ReadText(filePath);
    }
}