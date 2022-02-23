using Carfup.XTBPlugins.Controls;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Carfup.XTBPlugins.AppCode
{
    public class FormAttribute
    {
        private readonly XmlNode _controlNode;
        private XmlNode _controlDescriptionNode;
        private string _displayName;
        private string _entityDisplayName;
        private string _entityLogicalName;
        private PCFDetails _pcfConfiguration;
        private Guid _uniqueId;

        public FormAttribute(XmlNode controlNode)
        {
            _controlNode = controlNode;
        }

        public AttributeMetadata Amd { get; private set; }
        public BpfFieldControl Control { get; set; }
        public string CustomControlName => _controlDescriptionNode?.SelectSingleNode("customControl[@name]")?.Attributes["name"]?.Value;
        public XmlNode CustomControlNode => _controlDescriptionNode;
        public string DisplayName => _displayName;
        public EntityMetadata Emd { get; private set; }
        public string EntityDisplayName => _entityDisplayName;
        public string EntityLogicalName => _entityLogicalName;
        public string Id => _controlNode.Attributes["id"].Value;
        public string LogicalName => _controlNode.Attributes["datafieldname"].Value;

        public PCFDetails PcfConfiguration
        {
            get { return _pcfConfiguration; }
            set
            {
                _pcfConfiguration = value;
                if (_pcfConfiguration != null && _pcfConfiguration.Parameters.Count != 0 && string.IsNullOrEmpty(_pcfConfiguration.Parameters.First().value?.ToString()))
                {
                    _pcfConfiguration.Parameters.First().value = LogicalName;
                }
            }
        }

        public string Relationship => _controlNode.Attributes["relationship"]?.Value;
        public Guid UniqueId => _uniqueId;

        #region CustomControl Management

        public void AddCustomControl(PCFDetails pcf)
        {
            RemoveCustomControl();

            _uniqueId = Guid.NewGuid();
            var uniqueIdAttr = _controlNode.OwnerDocument.CreateAttribute("uniqueid");
            uniqueIdAttr.Value = _uniqueId.ToString("B");
            _controlNode.Attributes.Append(uniqueIdAttr);

            // Node controlDescriptionsNode
            var controlDescriptionsNode = _controlNode.OwnerDocument.DocumentElement.SelectSingleNode("controlDescriptions");
            if (controlDescriptionsNode == null)
            {
                controlDescriptionsNode = _controlNode.OwnerDocument.CreateElement("controlDescriptions");
                _controlNode.OwnerDocument.DocumentElement.AppendChild(controlDescriptionsNode);
            }

            // Node controlDescriptionNode
            _controlDescriptionNode = _controlNode.OwnerDocument.CreateElement("controlDescription");
            controlDescriptionsNode.AppendChild(_controlDescriptionNode);

            var forControlAttr = _controlNode.OwnerDocument.CreateAttribute("forControl");
            forControlAttr.Value = _uniqueId.ToString("B");
            _controlDescriptionNode.Attributes.Append(forControlAttr);

            // Node customControl
            var customControlNode = _controlNode.OwnerDocument.CreateElement("customControl");
            var nameAttr = _controlNode.OwnerDocument.CreateAttribute("name");
            nameAttr.Value = pcf.Name;
            var formFactorAttr = _controlNode.OwnerDocument.CreateAttribute("formFactor");
            formFactorAttr.Value = "2";
            customControlNode.Attributes.Append(nameAttr);
            customControlNode.Attributes.Append(formFactorAttr);
            _controlDescriptionNode.AppendChild(customControlNode);

            // Node parameters
            var parametersNode = _controlNode.OwnerDocument.CreateElement("parameters");
            customControlNode.AppendChild(parametersNode);

            foreach (var param in pcf.Parameters)
            {
                var paramNode = _controlNode.OwnerDocument.CreateElement(param.name);
                if (param.usage == "bound")
                {
                    paramNode.InnerText = LogicalName;
                }
                else
                {
                    paramNode.InnerText = param.value?.ToString() ?? "";

                    var staticAttr = _controlNode.OwnerDocument.CreateAttribute("static");
                    staticAttr.Value = param.isStatic ? "true" : "false";
                    paramNode.Attributes.Append(staticAttr);

                    var typeAttr = _controlNode.OwnerDocument.CreateAttribute("type");
                    typeAttr.Value = param.ofType;
                    paramNode.Attributes.Append(typeAttr);
                }

                parametersNode.AppendChild(paramNode);
            }

            PcfConfiguration = pcf;
            Control.showHideButtons();
        }

        public void EditCustomControl(PCFDetails pcf)
        {
            var parametersNode = _controlDescriptionNode.SelectSingleNode("customControl[@formFactor=\"2\"]").SelectSingleNode(".//parameters");
            if (parametersNode != null)
            {
                foreach (var param in pcf.Parameters)
                {
                    var paramNode = parametersNode.SelectSingleNode(param.name);
                    paramNode.Attributes.RemoveAll();

                    if (param.usage == "bound")
                    {
                        paramNode.InnerText = LogicalName;
                    }
                    else
                    {
                        paramNode.InnerText = param.value?.ToString() ?? "";

                        var staticAttr = _controlNode.OwnerDocument.CreateAttribute("static");
                        staticAttr.Value = param.isStatic ? "true" : "false";
                        paramNode.Attributes.Append(staticAttr);

                        var typeAttr = _controlNode.OwnerDocument.CreateAttribute("type");
                        typeAttr.Value = param.ofType;
                        paramNode.Attributes.Append(typeAttr);
                    }
                }
            }

            Control.showHideButtons();
        }

        public void RemoveCustomControl()
        {
            _uniqueId = Guid.Empty;
            _controlNode.Attributes.Remove(_controlNode.Attributes["uniqueid"]);
            _pcfConfiguration = null;

            if (CustomControlNode != null)
            {
                CustomControlNode.ParentNode.RemoveChild(CustomControlNode);
                _controlDescriptionNode = null;
            }

            Control.showHideButtons();
        }

        #endregion CustomControl Management

        public void Initialize(List<PCFDetails> pcfAvailableDetailsList)
        {
            _uniqueId = _controlNode.Attributes["uniqueid"] != null ? new Guid(_controlNode.Attributes["uniqueid"].Value) : Guid.Empty;
            _controlDescriptionNode = _controlNode.OwnerDocument.SelectSingleNode($"//controlDescription[@forControl=\"{UniqueId:B}\"]");
            var pcfDefinition = pcfAvailableDetailsList.FirstOrDefault(x => x.Name == CustomControlName);

            if (_uniqueId != Guid.Empty && CustomControlNode == null)
            {
                _uniqueId = Guid.Empty;
            }

            if (_controlDescriptionNode != null && pcfDefinition != null)
            {
                PcfConfiguration = new PCFDetails
                {
                    Id = _uniqueId,
                    AttachedField = LogicalName,
                    ControlDescription = pcfDefinition.ControlDescription,
                    Manifest = pcfDefinition.Manifest,
                    Name = pcfDefinition.Name,
                    Resxes = pcfDefinition.Resxes,
                    TypeGroups = pcfDefinition.TypeGroups,
                    Parameters = new List<PCFParameter>()
                };

                foreach (XmlNode property in _controlDescriptionNode.SelectSingleNode("customControl[@formFactor=\"2\"]").SelectNodes("./parameters/*"))
                {
                    var paramManifestDetails = pcfDefinition.Parameters.FirstOrDefault(x => x.name == property.Name);
                    if (paramManifestDetails == null) continue;

                    PcfConfiguration.Parameters.Add(new PCFParameter()
                    {
                        name = property.Name,
                        displayname = paramManifestDetails.displayname,
                        value = property.InnerText,
                        isStatic = property.Attributes["static"] == null ? false : true,
                        ofType = property.Attributes["type"]?.Value,
                        usage = paramManifestDetails.usage,
                        required = paramManifestDetails.required,
                        description = paramManifestDetails.description,
                        ComplexTypes = paramManifestDetails.ComplexTypes,
                        ComplexValues = paramManifestDetails.ComplexValues,
                        ofTypeGroup = paramManifestDetails.ofTypeGroup,
                    });
                }
            }
        }

        public void SetMetadata(EntityMetadata emd, AttributeMetadata amd)
        {
            if (emd != null)
            {
                Emd = emd;
                _entityDisplayName = emd.DisplayName.UserLocalizedLabel.Label;
                _entityLogicalName = emd.LogicalName;
            }

            if (amd != null)
            {
                Amd = amd;
                _displayName = amd.DisplayName.UserLocalizedLabel.Label;
            }
        }

        public override string ToString()
        {
            return $"{DisplayName} ({EntityDisplayName})";
        }
    }
}