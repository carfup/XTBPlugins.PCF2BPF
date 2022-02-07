using Carfup.XTBPlugins.Controls;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Carfup.XTBPlugins.AppCode
{
    public class FormTab
    {
        private readonly int _index;
        private readonly XmlNode _tabNode;

        public FormTab(XmlNode tabNode, int index)
        {
            _tabNode = tabNode;
            _index = index;

            Initialize();
        }

        public List<FormAttribute> Attributes { get; private set; } = new List<FormAttribute>();
        public BpfStageControl Control { get; set; }

        public override string ToString()
        {
            var label = _tabNode.SelectSingleNode("labels/label")?.Attributes["description"]?.Value;
            if (string.IsNullOrEmpty(label))
            {
                label = $"Stage {_index}";
            }

            return label;
        }

        private void Initialize()
        {
            foreach (XmlNode controlNode in _tabNode.SelectNodes(".//control"))
            {
                Attributes.Add(new FormAttribute(controlNode));
            }
        }
    }
}