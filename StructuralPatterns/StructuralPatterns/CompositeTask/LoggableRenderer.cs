using System;
using System.Collections.Generic;
using System.Text;

namespace StructuralPatterns.CompositeTask
{
    public class LoggableRenderer : HtmlRenderer
    {
        protected override void OnBeforeRender(LightNode node)
        {
            Console.WriteLine($"[Лог] Починаємо рендер вузла...");
        }

        protected override void OnAfterRender(LightNode node, string html)
        {
            Console.WriteLine($"[Лог] Рендер завершено. Довжина HTML: {html.Length} символів.");
        }
    }
}
