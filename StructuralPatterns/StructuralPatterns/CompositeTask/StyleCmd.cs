using System;
using System.Collections.Generic;
using System.Text;

namespace StructuralPatterns.CompositeTask
{
    public class StyleCmd : ICommand
    {
        private readonly LightElementNode _node;
        private readonly string _className;
        private readonly bool _add;

        public StyleCmd(LightElementNode node, string className, bool add = true)
        {
            _node = node;
            _className = className;
            _add = add;
        }

        public void Execute()
        {
            if (_add)
            {
                if (!_node.CssClasses.Contains(_className))
                    _node.CssClasses.Add(_className);
            }
            else
            {
                _node.CssClasses.Remove(_className);
            }
        }

        public void Undo()
        {
            if (_add)
            {
                _node.CssClasses.Remove(_className);
            }
            else
            {
                if (!_node.CssClasses.Contains(_className))
                    _node.CssClasses.Add(_className);
            }
        }
    }
}