using System;

namespace StructuralPatterns.ProxyTask;

public class SmartTextChecker : ITextReader
{
    private readonly ITextReader _realReader;

    public SmartTextChecker(ITextReader realReader)
    {
        _realReader = realReader;
    }

    public char[][] ReadText(string filePath)
    {
        Console.WriteLine($"Відкриття файлу {filePath}...");

        char[][] result = _realReader.ReadText(filePath);

        Console.WriteLine($"Файл {filePath} успішно прочитано.");

        int totalLines = result.Length;
        int totalChars = 0;
        foreach (var line in result)
        {
            totalChars += line.Length;
        }

        Console.WriteLine($"Рядків: {totalLines}, Символів: {totalChars}");
        Console.WriteLine($"Закриття файлу {filePath}.");

        return result;
    }
}