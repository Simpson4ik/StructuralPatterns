namespace StructuralPatterns.AdapterTask;

public class FileLoggerAdapter : Logger
{
    private readonly FileWriter _fileWriter;

    public FileLoggerAdapter(FileWriter fileWriter)
    {
        _fileWriter = fileWriter;
    }

    public override void Log(string message)
    {
        _fileWriter.WriteLine($"[LOG]: {message}");
    }

    public override void Error(string message)
    {
        _fileWriter.WriteLine($"[ERROR]: {message}");
    }

    public override void Warn(string message)
    {
        _fileWriter.WriteLine($"[WARN]: {message}");
    }
}