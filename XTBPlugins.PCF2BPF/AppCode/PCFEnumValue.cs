using Microsoft.Xrm.Sdk;
using System;
using System.Linq;

namespace Carfup.XTBPlugins.AppCode
{
    public class PCFEnumValue
    {
        public PCFEnumValue(string name, string label, string value)
        {
            Name = name;
            Label = label;
            Value = value;
        }

        public string Label { get; private set; }
        public string Name { get; }
        public string Value { get; }

        public override string ToString()
        {
            return Label ?? Name;
        }

        internal void LoadLabel(PCFDetails pcf, IOrganizationService service, int lcid)
        {
            pcf.Resxes.ForEach(r => r.Load(service));

            Label = pcf.Resxes.FirstOrDefault(r => r.Lcid == lcid)?.GetText(Label);
        }
    }
}