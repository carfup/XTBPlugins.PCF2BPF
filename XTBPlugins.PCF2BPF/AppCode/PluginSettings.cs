using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carfup.XTBPlugins.AppCode
{
    public class PluginSettings
    {
        public bool? AllowLogUsage { get; set; }
        public string CurrentVersion { get; set; } = PCF2BPF.PCF2BPF.CurrentVersion;
    }

    // EventType to qualify which type of telemetry we send
    static class EventType
    {
        public const string Event = "event";
        public const string Trace = "trace";
        public const string Dependency = "dependency";
        public const string Exception = "exception";
    }

    public static class CustomParameter
    {
        public static string INSIGHTS_INTRUMENTATIONKEY = "INSIGHTS_INTRUMENTATIONKEY_TOREPLACE";
    }

    // EventType to qualify which action was performed by the plugin
    static class LogAction
    {
        public const string PluginClosed = "PluginClosed";
        public const string StatsAccepted = "StatsAccepted";
        public const string StatsDenied = "StatsDenied";
        public const string SettingsSaved = "SettingsSaved";
        public const string SettingsSavedWhenClosing = "SettingsSavedWhenClosing";
        public const string SettingLoaded = "SettingLoaded";
        public const string EnvironmentOnPremise = "EnvironmentOnPremise";
        public const string UsersLoaded = "UsersLoaded";
        public const string BpfEntitiesLoaded = "BpfEntitiesLoaded";
        public const string PossiblePcfLoaded = "PossiblePcfLoaded";
        public const string LoadingBpfFormDetails = "LoadingBpfFormDetails";
        public const string BpfNotSupportedYet = "BpfNotSupportedYet";
        public const string UpdateAndPublish = "UpdateAndPublish";
        public const string ControlModified = "ControlModified";
        public const string ControlAdded = "ControlAdded";
        public const string AddingControl = "AddingControl";
        public const string ControlRemoved = "ControlRemoved";
        public const string ModifyingControl = "ModifyingControl";
        public const string PossiblePcfSet = "PossiblePcfSet";
        public const string ExistingPcfDetailsLoaded = "ExistingPcfDetailsLoaded";
        public const string FieldTypeNotSupported = "FieldTypeNotSupported";
        public const string FormFactorCopied = "FormFactorCopied";
        public const string ConnectionUpdated = "ConnectionUpdated";
        public const string LoadAPCF = "LoadAPCF";
    }
}
