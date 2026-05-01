using System;
using System.Collections.Generic;
using System.Text;

namespace StructuralPatterns.CompositeTask
{
    public interface INodeState
    {
        void Add(LightElementNode context, LightNode node);
    }
}
