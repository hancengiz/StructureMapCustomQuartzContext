using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using Quartz;

namespace StructureMapCustomQuartzContext
{
    public partial class MainForm : Form
    {
        private readonly IScheduler scheduler;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(IScheduler scheduler)
            : this()
        {
            this.scheduler = scheduler;
            SetupTraceListener();
            StartScheduler();
        }

        private void SetupTraceListener()
        {
            Trace.Listeners.Add(new UITraceListener(TraceLog));
        }

        private void TraceLog(string message)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action<string>(TraceLog), message);
            else
                this.textBox1.AppendText(message);
        }

        public void StartScheduler()
        {
            scheduler.Start();
        }

        public void StopScheduler()
        {
            if (scheduler.IsStarted)
                scheduler.Shutdown(false);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            StopScheduler();
            base.OnClosing(e);
        }
    }
}
