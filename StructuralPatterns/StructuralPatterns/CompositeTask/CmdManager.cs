using System;
using System.Collections.Generic;
using System.Text;

namespace StructuralPatterns.CompositeTask
{
    public class CmdManager
    {
        private readonly Stack<ICommand> _history = new Stack<ICommand>();

        public void Compute(ICommand command)
        {
            command.Execute();
            _history.Push(command);
        }

        public void Undo()
        {
            if (_history.Count > 0)
            {
                var command = _history.Pop();
                command.Undo();
            }
        }
    }
}
