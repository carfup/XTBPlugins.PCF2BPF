using Carfup.XTBPlugins.AppCode;
using Carfup.XTBPlugins.Controls;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;
using XrmToolBox.Extensibility;

namespace Carfup.XTBPlugins.PCF2BPF
{
    public enum actions
    {
        none,
        add,
        modify,
        delete
    }

    public partial class PCF2BPF : PluginControlBase
    {
        public actions actionInProgress = actions.none;
        public List<AttributeMetadata> attributesMetadata = new List<AttributeMetadata>();
        public List<Entity> bpfEntitiesList = new List<Entity>();
        public List<BpfFieldControl> bpfFieldControls = new List<BpfFieldControl>();
        public Entity bpfForm = null;
        public ControllerManager controllerManager = null;
        public Guid fieldIdToAttachPCF;
        public string fieldToAttachPCF;
        public Dictionary<string, string> mappingType = new Dictionary<string, string>();
        public List<PCFDetails> pcfAvailableDetailsList = new List<PCFDetails>();
        public List<PCFDetails> pcfBpfFormList = new List<PCFDetails>();
        public PCFDetails pcfEditing;
        public List<Entity> pcfList = new List<Entity>();
        public XmlDocument xmlBPFDoc = new XmlDocument() { };
        private Settings mySettings;

        public PCF2BPF()
        {
            InitializeComponent();
        }

        public string getTypeMapping(string field, bool fromAttrToPcf = true)
        {
            var attributeMetadata = attributesMetadata.FirstOrDefault(x => x.LogicalName == field);

            if (attributeMetadata == null)
            {
                MessageBox.Show(this, $"The metadata for attribute {field} couldn't not be found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

            var typeToLookFor = attributeMetadata.AttributeType.Value.ToString();
            if (attributeMetadata.GetType() == typeof(StringAttributeMetadata))
            {
                typeToLookFor = ((StringAttributeMetadata)attributeMetadata).FormatName.Value;
            }
            else if (attributeMetadata.GetType() == typeof(MemoAttributeMetadata))
            {
                typeToLookFor = ((MemoAttributeMetadata)attributeMetadata).FormatName.Value;
            }
            else if (attributeMetadata.GetType() == typeof(IntegerAttributeMetadata))
            {
                typeToLookFor = ((IntegerAttributeMetadata)attributeMetadata).Format.Value.ToString();
            }
            else if (attributeMetadata.GetType() == typeof(DateTimeAttributeMetadata))
            {
                typeToLookFor = ((DateTimeAttributeMetadata)attributeMetadata).Format.Value.ToString();
            }

            if (fromAttrToPcf)
                return mappingType.FirstOrDefault(x => x.Key == typeToLookFor).Value;
            else
                return mappingType.FirstOrDefault(x => x.Value == typeToLookFor).Key;
        }

        public void loadMappingTypes()
        {
            mappingType.Add("Text", "SingleLine.Text");
            mappingType.Add("Money", "Currency");
            mappingType.Add("DateOnly", "DateAndTime.DateOnly");
            mappingType.Add("DateAndTime", "DateAndTime.DateAndTime");
            mappingType.Add("Lookup", "Lookup.Simple");
            mappingType.Add("Picklist", "OptionSet");
            mappingType.Add("BigInt", "Whole.None");
            mappingType.Add("Decimal", "Decimal");
            mappingType.Add("Email", "SingleLine.Email");
            mappingType.Add("Url", "SingleLine.URL");
            mappingType.Add("Phone", "SingleLine.Phone");
            mappingType.Add("Boolean", "TwoOptions");
            mappingType.Add("TextArea", "Multiple");
            mappingType.Add("Memo", "SingleLine.TextArea");
            mappingType.Add("TickerSymbol", "SingleLine.Ticker");
            mappingType.Add("MultiSelectPickList", "MultiSelectOptionSet");
            mappingType.Add("Double", "FP");
        }

        public void setAddPcf(string field, Guid id)
        {
            actionInProgress = actions.add;
            panelParams.Controls.Clear();
            setPossiblePCf(field, id);
        }

        public void setDeletePCFDetails(Guid id)
        {
            actionInProgress = actions.delete;

            // we reset the control in the list
            var pcfToDelete = pcfBpfFormList.FirstOrDefault(x => x.id == id);
            pcfToDelete.action = actions.delete;

            pcfBpfFormList.Add(new PCFDetails()
            {
                attachedField = pcfToDelete.attachedField,
                action = actions.none,
                id = id
            });

            this.controllerManager.xmlManager.generateBpfFormXml(pcfBpfFormList, xmlBPFDoc);
        }

        public void setExistingPCFDetails(string field, Guid id)
        {
            actionInProgress = actions.modify;

            resetPossiblePCF();

            setPossiblePCf(field, id);

            pcfEditing = PCFDetails.Clone(pcfBpfFormList.First(x => x.id == id));
            //pcfEditing = pcfBpfFormList.First(x => x.id == id).Clone();

            // Auto select the dropdown list here & disable it
            cbPossiblePCFs.Enabled = false;
            cbPossiblePCFs.SelectedText = pcfEditing.name;

            loadParamToPanel(pcfEditing.parameters);
        }

        public void setPossiblePCf(string field, Guid id)
        {
            resetPossiblePCF();

            var searchType = getTypeMapping(field);
            var potentialPCFs = pcfList.Where(x => x.GetAttributeValue<string>("compatibledatatypes") != "" && x.GetAttributeValue<string>("compatibledatatypes").Split(',').Contains(searchType));
            cbPossiblePCFs.Items.AddRange(potentialPCFs.Select(x => x.GetAttributeValue<string>("name")).OrderBy(y => y).ToArray());

            fieldToAttachPCF = field;
            fieldIdToAttachPCF = id;
            cbPossiblePCFs.Enabled = true;

            panelRight.Visible = true;
            cbPossiblePCFs.Focus();
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        private void btnAddApplyControl_Click(object sender, EventArgs e)
        {
            var requiredFieldsEmpty = pcfEditing?.parameters.Any(x => x.required && (x.value == null || x.value == ""));

            if (requiredFieldsEmpty.Value)
            {
                MessageBox.Show("One or more required fields are empty, please fill them.");
                return;
            }

            if (actionInProgress == actions.modify)
            {
                pcfEditing.action = actions.modify;

                foreach (var param in pcfEditing.parameters)
                {
                    if (param.complexTypes?.Length > 0)
                        param.ofType = param.complexTypes.First();
                }

                var element = pcfBpfFormList.First(x => /*x.attachedField == pcfEditing.parameters.First().value.ToString() &&*/ x.id == pcfEditing.id);
                var index = pcfBpfFormList.IndexOf(element);
                pcfBpfFormList[index] = pcfEditing;

                this.controllerManager.xmlManager.generateBpfFormXml(pcfBpfFormList, xmlBPFDoc);

                panelRight.Visible = false;
            }
            else if (actionInProgress == actions.add)
            {
                pcfEditing.action = actions.add;
                var element = pcfBpfFormList.First(x => x.id == pcfEditing.id);
                var index = pcfBpfFormList.IndexOf(element);
                pcfBpfFormList[index] = pcfEditing;

                var controlPosition = bpfFieldControls.IndexOf(bpfFieldControls.First(x => x.id == pcfEditing.id));

                this.controllerManager.xmlManager.generateBpfFormXml(pcfBpfFormList, xmlBPFDoc, controlPosition);

                panelRight.Visible = false;
            }

            panelParams.Controls.Clear();
        }

        private void btnLoadEntities_Click(object sender, EventArgs e)
        {
            ExecuteMethod(PrivateLoadEntities);
        }

        private void btnUpdatePublish_Click(object sender, EventArgs evt)
        {
            var targetEntity = cbBPFEntitiesList.SelectedItem.ToString();
            var generatedXml = this.controllerManager.xmlManager.generateBpfFormXml(pcfBpfFormList, xmlBPFDoc);
            txbModifiedFormXml.Text = generatedXml;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Updating and Publishing the BPF Form..",
                Work = (bw, e) =>
                {
                    this.controllerManager.dataManager.updatePublishForm(bpfForm.Id, txbModifiedFormXml.Text, targetEntity);
                },
                PostWorkCallBack = e =>
                {
                    if (e.Error != null)
                    {
                        // this.log.LogData(EventType.Exception, LogAction.UsersLoaded, e.Error);
                        MessageBox.Show(this, e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("The BPF Form was successfully updated.", "BPF Form Updated !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                },
                ProgressChanged = e => { SetWorkingMessage(e.UserState.ToString()); }
            });
        }

        private void cbBPFEntitiesList_SelectedIndexChanged(object sender, EventArgs evt)
        {
            var selectedBPFEntity = bpfEntitiesList.First(x => x.GetAttributeValue<string>("name") == cbBPFEntitiesList.SelectedItem.ToString());
            var bpfPrimaryEntityLogicalName = selectedBPFEntity.GetAttributeValue<string>("primaryentity");
            var bpfEntityLogicalName = selectedBPFEntity.GetAttributeValue<string>("uniquename");

            panelRight.Visible = false;
            panelStagesFields.Controls.Clear();

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading BPF Form details",
                Work = (bw, e) =>
                {
                    bpfForm = this.controllerManager.dataManager.retrieveBpfForm(bpfEntityLogicalName);

                    if (bpfForm == null || bpfForm.GetAttributeValue<string>("formxml").Contains("<hiddencontrols>"))
                    {
                        e.Result = "This BPF is not yet supported. We do hope it will be the case in a near future.";
                    }
                    else
                    {
                        bw.ReportProgress(0, "Loading related metadata...");
                        attributesMetadata = this.controllerManager.dataManager.getEntityAttributesMetadata(bpfPrimaryEntityLogicalName);
                    }
                },
                PostWorkCallBack = e =>
                {
                    if (e.Error != null)
                    {
                        // this.log.LogData(EventType.Exception, LogAction.UsersLoaded, e.Error);
                        MessageBox.Show(this, e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (e.Result != null)
                    {
                        MessageBox.Show(this, e.Result.ToString(), "BPF not supported", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var bpfFormXml = bpfForm.GetAttributeValue<string>("formxml");
                    txbFormXml.Text = bpfFormXml;
                    xmlBPFDoc.LoadXml(bpfFormXml);

                    bpfFieldControls.Clear();
                    panelStagesFields.Controls.Clear();

                    var controls = new List<UserControl>();

                    var bpfTabs = xmlBPFDoc.SelectNodes("//tab");
                    int i = 1;
                    foreach (XmlElement bpfTab in bpfTabs)
                    {
                        controls.Add(new BpfStageControl(bpfTab.SelectSingleNode("labels/label/@description")?.Value) { Dock = DockStyle.Top });

                        // Getting the fields avaiable on BPF form
                        var bpfControls = bpfTab.SelectNodes(".//control");

                        foreach (XmlElement bpfControl in bpfControls)
                        {
                            var fieldName = bpfControl.Attributes["datafieldname"].Value;
                            var relationship = bpfControl.Attributes["relationship"]?.Value;

                            Guid controlId = Guid.NewGuid();
                            bool pcfAttached = false;
                            if (bpfControl.Attributes["uniqueid"] != null)
                            {
                                controlId = new Guid(bpfControl.Attributes["uniqueid"]?.Value);
                                pcfAttached = true;
                            }

                            if (relationship != null
                                && relationship != $"bpf_{bpfPrimaryEntityLogicalName}_{bpfEntityLogicalName}"
                                && relationship != $"lk_{bpfEntityLogicalName}_{bpfPrimaryEntityLogicalName}id")
                            {
                                fieldName = fieldName + " (from another entity)";
                            }

                            var displayName = attributesMetadata.FirstOrDefault(x => x.LogicalName == fieldName)?.DisplayName?.UserLocalizedLabel?.Label;
                            var control = new BpfFieldControl(this, fieldName, displayName, controlId, pcfAttached);
                            control.Dock = DockStyle.Top;

                            controls.Add(control);
                            bpfFieldControls.Add(control);
                        }

                        i++;
                    }

                    controls.Reverse();
                    panelStagesFields.Controls.AddRange(controls.ToArray());

                    pcfBpfFormList = this.controllerManager.xmlManager.getExistingPCFDetails(xmlBPFDoc, bpfFieldControls).ToList();
                },
                ProgressChanged = e => { SetWorkingMessage(e.UserState.ToString()); }
            });
        }

        private void cbPossiblePCFs_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedPCF = cbPossiblePCFs.SelectedItem.ToString();
            //var tmpPcfEditing = PCFDetails.Clone(pcfAvailableDetailsList.First(x => x.name == selectedPCF));

            // reset id & values
            /*   tmpPcfEditing.parameters.ForEach(c => c.value = null);
               tmpPcfEditing.parameters.ForEach(c => c.isStatic = false);
               tmpPcfEditing.id = null;
               tmpPcfEditing.attachedField = fieldToAttachPCF;*/

            pcfEditing = PCFDetails.Clone(pcfAvailableDetailsList.First(x => x.name == selectedPCF));

            pcfEditing.parameters.First().value = fieldToAttachPCF;
            pcfEditing.attachedField = fieldToAttachPCF;
            pcfEditing.id = fieldIdToAttachPCF;

            loadParamToPanel(pcfEditing.parameters);
        }

        private void loadParamToPanel(List<PCFParameters> parameters)
        {
            panelParams.Controls.Clear();
            var controls = new List<UserControl>();

            int i = 0;
            foreach (var param in parameters)
            {
                controls.Add(new PcfControlParameter(this, param, i == 0) { Dock = DockStyle.Top });
                i++;
            }
            controls.Reverse();

            panelParams.Controls.AddRange(controls.ToArray());
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }

            if (ConnectionDetail != null && ConnectionDetail.ServiceClient != null)
            {
                // creating the controller
                controllerManager = new ControllerManager(this);
            }

            loadMappingTypes();
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        private void PrivateLoadEntities()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading BPF Entities...",
                Work = (bw, e) =>
                {
                    bpfEntitiesList = this.controllerManager.dataManager.retrieveBPFEntities();

                    bw.ReportProgress(0, "Loading available PCF in your environment...");

                    pcfList = this.controllerManager.dataManager.retrievePcfList();
                    pcfAvailableDetailsList = this.controllerManager.xmlManager.pcfDetailsFromManifest(pcfList);
                },
                PostWorkCallBack = e =>
                {
                    if (e.Error != null)
                    {
                        // this.log.LogData(EventType.Exception, LogAction.UsersLoaded, e.Error);
                        MessageBox.Show(this, e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (bpfEntitiesList != null)
                    {
                        cbBPFEntitiesList.Items.Clear();
                        cbBPFEntitiesList.Items.AddRange(bpfEntitiesList.Select(x => x.GetAttributeValue<string>("name")).OrderBy(x => x).Distinct().ToArray());
                    }

                    cbBPFEntitiesList.Enabled = true;
                },
                ProgressChanged = e => { SetWorkingMessage(e.UserState.ToString()); }
            });
        }

        private void resetPossiblePCF()
        {
            pcfEditing = null;
            cbPossiblePCFs.Items.Clear();
            cbPossiblePCFs.SelectedIndex = -1;
            cbPossiblePCFs.ResetText();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }
    }

    [Serializable]
    public class PCFDetails
    {
        public actions action = actions.none;
        public string attachedField;
        public string controlDescription;
        public Guid? id = null;
        public string manifest;
        public string name;
        public List<PCFParameters> parameters;
        public List<PCFTypeGroups> typeGroup;

        public static T Clone<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", nameof(source));
            }

            // Don't serialize a null object, simply return the default for that object
            if (ReferenceEquals(source, null)) return default;

            Stream stream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, source);
            stream.Seek(0, SeekOrigin.Begin);
            return (T)formatter.Deserialize(stream);
        }
    }

    [Serializable]
    public class PCFParameters
    {
        public string ofTypeGroup = null;

        public string[] complexTypes { get; set; }

        public string[] complexValues { get; set; }

        [DisplayName("Param Desc")]
        public string description { get; set; }

        [DisplayName("Is Static ?")]
        public bool isStatic { get; set; }

        [DisplayName("Param Name")]
        public string name { get; set; }

        [DisplayName("Param Type")]
        public string ofType { get; set; } = null;

        [DisplayName("Requied ?")]
        public bool required { get; set; }

        public string usage { get; set; }

        [DisplayName("Param Value")]
        public object value { get; set; }
    }

    [Serializable]
    public class PCFTypeGroups
    {
        public string name;
        public string type;
    }
}