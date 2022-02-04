using Carfup.XTBPlugins.Controls;
using Carfup.XTBPlugins.PCF2BPF;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Carfup.XTBPlugins.AppCode
{
    public class XmlManager
    {
        #region Variables

        /// <summary>
        /// Crm web service
        /// </summary>
        private readonly ControllerManager connection = null;

        private PCF2BPF.PCF2BPF pcf2bpf = null;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class DataManager
        /// </summary>
        /// <param name="service">Details of the connected user</param>
        public XmlManager(ControllerManager connection, PCF2BPF.PCF2BPF pcf2bpf)
        {
            this.connection = connection;
            this.pcf2bpf = pcf2bpf;
        }

        #endregion Constructor

        public string constructionControlDescription(PCFDetails pcfEditing, string fieldToAttachPCF)
        {
            var selectedPCF = pcfEditing.name;
            var action = pcfEditing.action;
            // pcfEditing.id = action == actions.add ? Guid.NewGuid() : pcfEditing.id;
            var controlDescription = action == actions.add ?
                "<controlDescription forControl=\"{" + pcfEditing.id + "}\"><customControl name=\"" + selectedPCF + "\" formFactor=\"2\"><parameters>" :
                "<customControl name=\"" + selectedPCF + "\" formFactor=\"2\"><parameters>";

            foreach (var param in pcfEditing.parameters)
            {
                if (param.usage == "bound")
                    controlDescription += $"<{param.name}>{fieldToAttachPCF}</{param.name}>";
                else
                    controlDescription += $"<{param.name} static=\"{param.isStatic}\" type=\"{param.ofType}\">{param.value}</{param.name}>";
            }

            controlDescription += action == actions.add ? $"</parameters></customControl></controlDescription>" : $"</parameters></customControl>";

            //bpfFieldControls.First(x => x.name == pcfEditing.parameters.First().value.ToString()).changeIdValue(uniqueGuid);

            return controlDescription;
        }

        public string generateBpfFormXml(List<PCFDetails> pcfList, XmlDocument xmlBpf, int fieldPosition = 0)
        {
            foreach (var pcf in pcfList.Where(x => x.action != actions.none))
            {
                if (pcf.action == actions.add)
                {
                    // generate controldescription
                    var controlDescriptions = $"{constructionControlDescription(pcf, pcf.attachedField)}";

                    // mapping the ID of control to field
                    var control = xmlBpf.SelectSingleNode($"//control[@datafieldname='{pcf.attachedField}']");

                    if (fieldPosition != 0)
                        control = xmlBpf.SelectNodes($"//control")[fieldPosition];

                    XmlAttribute typeAttr = xmlBpf.CreateAttribute("uniqueid");
                    typeAttr.Value = "{" + pcf.id.ToString() + "}";
                    control.Attributes.Append(typeAttr);

                    // appending the new definition to xml
                    xmlBpf.InnerXml = xmlBpf.InnerXml.Contains("</controlDescriptions>") ?
                            xmlBpf.InnerXml.Replace("</controlDescriptions>", $"{controlDescriptions}</controlDescriptions>") :
                            xmlBpf.InnerXml.Replace("</form>", $"<controlDescriptions>{controlDescriptions}</controlDescriptions></form>");

                    this.pcf2bpf.bpfFieldControls.First(x => x.id == pcf.id).changePcfAttachedValue(true);

                    pcf.action = actions.none;
                }
                else if (pcf.action == actions.modify)
                {
                    var pcfControls = xmlBpf.SelectNodes("//controlDescription");
                    int i = 0;
                    foreach (XmlNode pcfControl in pcfControls.Cast<XmlNode>().ToList())
                    {
                        var param = pcfControl.SelectNodes("//customControl/parameters").Count > 0 ? pcfControl.SelectNodes("//customControl/parameters")[i].FirstChild.InnerText : null;
                        if (param != null && param == pcf.attachedField)
                        {
                            pcfControl.InnerXml = constructionControlDescription(pcf, pcf.attachedField);
                        }
                        i++;
                    }
                    pcf.action = actions.none;
                }
                else if (pcf.action == actions.delete)
                {
                    // removing reference of the control on the fieldattribute
                    var control = xmlBpf.SelectSingleNode("//control[@uniqueid='{" + pcf.id + "}']");

                    if (control == null)
                    {
                        throw new Exception("Action Delete : control cant be found.");
                    }

                    control.Attributes.Remove(control.Attributes["uniqueid"]);

                    // removing the related controlDescription
                    var controlDescription = xmlBpf.SelectSingleNode("//controlDescription[@forControl='{" + pcf.id + "}']");
                    var parentNode = controlDescription.ParentNode;
                    if (controlDescription != null) { parentNode.RemoveChild(controlDescription); }

                    this.pcf2bpf.bpfFieldControls.First(x => x.name == pcf.attachedField).changePcfAttachedValue();
                }
            }

            pcfList.RemoveAll(x => x.action == actions.delete);

            return xmlBpf.InnerXml;
        }

        public List<PCFDetails> getExistingPCFDetails(XmlDocument xmlBpfDoc, List<BpfFieldControl> fields = null)
        {
            var controls = xmlBpfDoc.SelectNodes("//controlDescription");

            List<PCFDetails> fieldsAndPcfBpfForm = new List<PCFDetails>();

            foreach (XmlNode control in controls)
            {
                List<PCFParameters> pcfParamsExisting = new List<PCFParameters>();

                var pcfName = control.SelectSingleNode(".//customControl").Attributes["name"]?.Value;
                var pcfManifestDetails = this.pcf2bpf.pcfAvailableDetailsList.First(x => x.name == pcfName);

                foreach (XmlNode property in control.SelectNodes(".//parameters/*"))
                {
                    var paramManifestDetails = pcfManifestDetails.parameters.First(x => x.name == property.Name);

                    pcfParamsExisting.Add(new PCFParameters()
                    {
                        name = property.Name,
                        value = property.InnerText,
                        isStatic = property.Attributes["static"] == null ? false : true,
                        ofType = property.Attributes["type"]?.Value,
                        usage = paramManifestDetails.usage,
                        required = paramManifestDetails.required,
                        description = paramManifestDetails.description,
                        complexTypes = paramManifestDetails.complexTypes,
                        complexValues = paramManifestDetails.complexValues,
                        ofTypeGroup = paramManifestDetails.ofTypeGroup,
                    });
                }

                fieldsAndPcfBpfForm.Add(new PCFDetails()
                {
                    name = control.SelectSingleNode(".//customControl").Attributes["name"]?.Value,
                    manifest = control.OuterXml,
                    parameters = pcfParamsExisting,
                    id = new Guid(control.Attributes["forControl"]?.Value),
                    controlDescription = pcfManifestDetails.controlDescription,
                    attachedField = pcfParamsExisting.First().value.ToString(),
                });
            }

            // Fields without PCF
            foreach (var field in fields.Where(y => !fieldsAndPcfBpfForm.Select(x => x.id).Contains(y.id)))
            {
                fieldsAndPcfBpfForm.Add(new PCFDetails()
                {
                    attachedField = field.name,
                    id = field.id
                });
            }

            return fieldsAndPcfBpfForm;
        }

        public List<PCFDetails> pcfDetailsFromManifest(List<Entity> pcfList)
        {
            List<PCFDetails> pcfAvailableDetailsList = new List<PCFDetails>();

            foreach (var pcf in pcfList)
            {
                var controlManifest = pcf.GetAttributeValue<string>("manifest");

                var xmlDocPCF = new XmlDocument() { };
                xmlDocPCF.LoadXml(controlManifest);

                var properties = xmlDocPCF.SelectNodes("//property");
                var typeGroups = xmlDocPCF.SelectNodes("//type-group");

                var typeGroupValues = new List<PCFTypeGroups>();
                foreach (XmlNode typeg in typeGroups)
                {
                    foreach (XmlNode type in typeg.SelectNodes("type"))
                        typeGroupValues.Add(new PCFTypeGroups
                        {
                            name = typeg.Attributes["name"].Value,
                            type = type.InnerText,
                        });
                }
                List<PCFResx> pcfResxes = new List<PCFResx>();

                var resxes = xmlDocPCF.SelectNodes("//resx");
                foreach (XmlNode resx in resxes)
                {
                    var pcfResx = new PCFResx(resx.Attributes["path"].Value,
                        xmlDocPCF.SelectSingleNode("//control").Attributes["namespace"].Value,
                        xmlDocPCF.SelectSingleNode("//control").Attributes["constructor"].Value);

                    pcfResxes.Add(pcfResx);
                }

                List<PCFParameters> pcfParams = new List<PCFParameters>();
                foreach (XmlNode prop in properties)
                {
                    var complexValues = new List<string>();
                    var complexTypes = new List<string>();
                    if (prop.Attributes["of-type"]?.Value == "Enum")
                    {
                        complexValues = prop.ChildNodes.Cast<XmlNode>().Select(x => x.Attributes["name"].Value).ToList();
                    }

                    if (prop.Attributes["of-type-group"]?.Value != null)
                    {
                        complexTypes = typeGroupValues.Select(x => x.type).ToList();
                    }

                    pcfParams.Add(new PCFParameters
                    {
                        name = prop.Attributes["display-name-key"]?.Value,
                        description = prop.Attributes["description-key"]?.Value,
                        required = prop.Attributes["required"]?.Value == "true" ? true : false,
                        usage = prop.Attributes["usage"]?.Value,
                        ofType = prop.Attributes["of-type"]?.Value ?? prop.Attributes["of-type-group"]?.Value,
                        ofTypeGroup = prop.Attributes["of-type-group"]?.Value,
                        complexTypes = complexTypes.ToArray(),
                        complexValues = complexValues.ToArray()
                    });
                }

                // Generating the full list of pcf details
                pcfAvailableDetailsList.Add(new PCFDetails
                {
                    name = pcf.GetAttributeValue<string>("name"),
                    manifest = controlManifest,
                    parameters = pcfParams,
                    typeGroup = typeGroupValues,
                    resx = pcfResxes,
                    id = null
                });
            }

            return pcfAvailableDetailsList;
        }
    }
}