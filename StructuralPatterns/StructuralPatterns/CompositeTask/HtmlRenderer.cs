using System;
using System.Collections.Generic;
using System.Text;

namespace StructuralPatterns.CompositeTask
{
    public abstract class HtmlRenderer
    {
        public string Render(LightNode node)
        {
            OnBeforeRender(node);
            string html = BuildHtml(node);
            OnAfterRender(node, html);

            return html;
        }

        protected virtual void OnBeforeRender(LightNode node) { }

        private string BuildHtml(LightNode node)
        {
            return node.OuterHTML;
        }
        protected virtual void OnAfterRender(LightNode node, string html) { }
    }
}