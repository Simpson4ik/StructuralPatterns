using System;
using System.Collections.Generic;
using System.Text;

namespace StructuralPatterns.CompositeTask
{
    public class DomAnalyzerVisitor : IVisitor
    {
        public int TotalElements { get; private set; }
        public int BlockElements { get; private set; }
        public int InlineElements { get; private set; }
        public int TextNodes { get; private set; }

        public void VisitElementNode(LightElementNode element)
        {
            TotalElements++;
            if (element.DisplayType == DisplayType.Block) BlockElements++;
            else InlineElements++;
        }

        public void VisitTextNode(LightTextNode text)
        {
            TextNodes++;
        }

        public void PrintReport()
        {
            Console.WriteLine("\nЗвіт аналізатора DOM");
            Console.WriteLine($"Усього елементів: {TotalElements}");
            Console.WriteLine($"Блочних (block):  {BlockElements}");
            Console.WriteLine($"Рядкових (inline): {InlineElements}");
            Console.WriteLine($"Текстових вузлів: {TextNodes}");
        }
    }
}
