using System;
using System.Collections.Generic;
using System.Text;

namespace StructuralPatterns.CompositeTask
{
    public class LockedState : INodeState
    {
        public void Add(LightElementNode context, LightNode node)
        {
            Console.WriteLine($"[State] Відмовлено: вузол заблоковано. Неможливо додати новий елемент.");
        }
    }
}
