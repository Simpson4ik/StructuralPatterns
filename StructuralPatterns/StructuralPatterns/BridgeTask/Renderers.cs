using System;

namespace StructuralPatterns.BridgeTask;

public interface IRenderer
{
    void RenderShape(string shapeName);
}

public class VectorRenderer : IRenderer
{
    public void RenderShape(string shapeName)
    {
        Console.WriteLine($"Drawing {shapeName} as lines");
    }
}

public class RasterRenderer : IRenderer
{
    public void RenderShape(string shapeName)
    {
        Console.WriteLine($"Drawing {shapeName} as pixels");
    }
}