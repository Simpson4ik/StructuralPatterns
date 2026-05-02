using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace StructuralPatterns.CompositeTask
{
    public class TimeTrackerRenderer : HtmlRenderer
    {
        private Stopwatch _stopwatch;

        protected override void OnBeforeRender(LightNode node)
        {
            _stopwatch = Stopwatch.StartNew();
        }

        protected override void OnAfterRender(LightNode node, string html)
        {
            _stopwatch.Stop();
            Console.WriteLine($"[Таймер] Час генерації HTML: {_stopwatch.ElapsedTicks} тіків.");
        }
    }
}
