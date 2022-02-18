using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

namespace Carfup.XTBPlugins.AppCode
{
    public class LogUsageManager
    {

        private TelemetryClient telemetry = null;
        private bool forceLog { get; set; } = false;

        private PCF2BPF.PCF2BPF pcf2bpf = null;
        public LogUsageManager(PCF2BPF.PCF2BPF pcf2bpf)
        {
            this.pcf2bpf = pcf2bpf;

            TelemetryConfiguration.Active.InstrumentationKey = CustomParameter.INSIGHTS_INTRUMENTATIONKEY;
            this.telemetry = new TelemetryClient();
            this.telemetry.Context.Component.Version = PCF2BPF.PCF2BPF.CurrentVersion;
            this.telemetry.Context.Device.Id = this.pcf2bpf.GetType().Name;
            this.telemetry.Context.User.Id = Guid.NewGuid().ToString();
        }

        public void UpdateForceLog()
        {
            forceLog = true;
        }

        public void LogData(string type, string action, Exception exception = null)
        {
            if (pcf2bpf.settings.AllowLogUsage == true || forceLog)
            {
                switch (type)
                {
                    case EventType.Event:
                        telemetry.TrackEvent(action, CompleteLog(action));
                        break;
                    case EventType.Dependency:
                        //this.telemetry.TrackDependency(todo);
                        break;
                    case EventType.Exception:
                        telemetry.TrackException(exception, CompleteLog(action));
                        break;
                    case EventType.Trace:
                        telemetry.TrackTrace(action, CompleteLog(action));
                        break;
                }
            }

            if (forceLog)
                forceLog = false;
        }

        public void Flush()
        {
            telemetry.Flush();
        }


        public Dictionary<string, string> CompleteLog(string action = null)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                { "plugin", telemetry.Context.Device.Id },
                { "xtbversion", Assembly.GetEntryAssembly().GetName().Version.ToString() },
                { "pluginversion", PCF2BPF.PCF2BPF.CurrentVersion }
            };

            if (action != null)
                dictionary.Add("action", action);

            return dictionary;
        }

        internal void PromptToLog()
        {
            var msg = "Anonymous statistics will be collected to improve plugin functionalities.\n\n" +
                      "You can just accept or decline and won't be annoyed again about it :)\n\n" +
                      "Thanks!";

            DialogResult result = System.Windows.Forms.MessageBox.Show(msg, "Anonymous statistics collection", MessageBoxButtons.YesNo);
            pcf2bpf.settings.AllowLogUsage = result == DialogResult.Yes;
        }
    }
}
