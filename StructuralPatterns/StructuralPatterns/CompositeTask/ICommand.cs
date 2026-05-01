using System;
using System.Collections.Generic;
using System.Text;

namespace StructuralPatterns.CompositeTask
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
