using System;
using System.Diagnostics;

namespace StructureMapCustomQuartzContext
{
    public class UITraceListener : TraceListener
    {
        private readonly Action<string> uiAction;

        public UITraceListener(Action<string> uiAction)
        {
            this.uiAction = uiAction;
        }

        public override void Write(string message)
        {
            uiAction(message);
        }

        public override void WriteLine(string message)
        {
            uiAction(message + "\r\n");
        }
    }
}