using System;

namespace StructuralPatterns.AdapterTask;

public class Logger
{
    public virtual void Log(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"[LOG]: {message}");
        Console.ResetColor();
    }

    public virtual void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[ERROR]: {message}");
        Console.ResetColor();
    }

    public virtual void Warn(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"[WARN]: {message}");
        Console.ResetColor();
    }
}