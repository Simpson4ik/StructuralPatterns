using System;
using System.Collections.Generic;
using System.Text;

namespace StructuralPatterns.CompositeTask
{
    public interface IVisitor
    {
        void VisitElementNode(LightElementNode element);
        void VisitTextNode(LightTextNode text);
    }
}
