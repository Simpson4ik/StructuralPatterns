using System;
using System.Collections.Generic;
using System.Text;

namespace StructuralPatterns.CompositeTask
{
    public class EditableState : INodeState
    {
        public void Add(LightElementNode context, LightNode node)
        {
            context.InternalAdd(node);
        }
    }
}
