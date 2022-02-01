using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using System.Xml;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Crm.Sdk.Messages;
using Carfup.XTBPlugins.Controls;
using Carfup.XTBPlugins.AppCode;

namespace Carfup.XTBPlugins.PCF2BPF
{
    public partial class PCF2BPF : PluginControlBase
    {
        private Settings mySettings;
        public List<Entity> bpfEntitiesList = new List<Entity>();
        public Entity bpfForm = null;
        public List<Entity> pcfList = new List<Entity>();
        public List<PCFDetails> pcfAvailableDetailsList = new List<PCFDetails>();
        public List<PCFDetails> pcfBpfFormList = new List<PCFDetails>();
        public XmlDocument xmlBPFDoc = new XmlDocument() { };
        public List<AttributeMetadata> attributesMetadata = new List<AttributeMetadata>();
        private BindingSource dgvPCFParamsSource = null;
        public PCFDetails pcfEditing;
        public string fieldToAttachPCF;
        public List<BpfFieldControl> bpfFieldControls = new List<BpfFieldControl>();

        public ControllerManager controllerManager = null;

        public PCF2BPF()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            ShowInfoNotification("This is a notification that can lead to XrmToolBox repository >< !!!", new Uri("https://github.com/MscrmTools/XrmToolBox"));

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

            dgvPCFParamsSource = new BindingSource()
            {
                DataSource = null
            };
            dgvPCFParams.DataSource = dgvPCFParamsSource;
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
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
      
        private void btnTransformFormXml_Click(object sender, EventArgs e)
        {
            txbModifiedFormXml.Text = this.controllerManager.xmlManager.generateBpfFormXml(pcfBpfFormList, xmlBPFDoc);
        }

        private void btnLoadEntities_Click(object sender, EventArgs e)
        {
            bpfEntitiesList = this.controllerManager.dataManager.retrieveBPFEntities();

            cbBPFEntitiesList.Items.Clear();

            cbBPFEntitiesList.Items.AddRange(bpfEntitiesList.Select(x => x.GetAttributeValue<string>("uniquename")).Distinct().ToArray());

            // Load possible entities
            pcfList = this.controllerManager.dataManager.retrievePcfList();

            pcfAvailableDetailsList = this.controllerManager.xmlManager.pcfDetailsFromManifest(pcfList);
        }

        private void cbBPFEntitiesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var bpfEntityLogicalName = cbBPFEntitiesList.SelectedItem.ToString();
            var bpfPrimaryEntityLogicalName = bpfEntitiesList.First(x => x.GetAttributeValue<string>("uniquename") == bpfEntityLogicalName).GetAttributeValue<string>("primaryentity");

            bpfForm = this.controllerManager.dataManager.retrieveBpfForm(bpfEntityLogicalName);

            var bpfFormXml = bpfForm.GetAttributeValue<string>("formxml");
            txbFormXml.Text = bpfFormXml;
            xmlBPFDoc.LoadXml(bpfFormXml);

            bpfFieldControls.Clear();
            panel1.Controls.Clear();

            var controls = new List<UserControl>();

            var bpfTabs = xmlBPFDoc.SelectNodes("//tab");
            int i = 1;
            foreach (XmlElement bpfTab in bpfTabs)
            {
                controls.Add(new BpfStageControl($"Stage {i}") { Dock = DockStyle.Top });

                // Getting the fields avaiable on BPF form
                var bpfControls = bpfTab.SelectNodes(".//control");

                foreach (XmlElement bpfControl in bpfControls)
                {
                    var fieldName = bpfControl.Attributes["datafieldname"].Value;
                    Guid? controlId = null;
                    if (bpfControl.Attributes["uniqueid"] != null)
                         controlId = new Guid(bpfControl.Attributes["uniqueid"]?.Value);

                    var control = new BpfFieldControl(this, fieldName, controlId);
                    
                    controls.Add(new BpfFieldControl(this, fieldName, controlId) { Dock = DockStyle.Top });
                    bpfFieldControls.Add(control);
                }

                i++;
            }

            controls.Reverse();
            panel1.Controls.AddRange(controls.ToArray());

            attributesMetadata = this.controllerManager.dataManager.getEntityAttributesMetadata(bpfPrimaryEntityLogicalName);
            pcfBpfFormList = this.controllerManager.xmlManager.getExistingPCFDetails(xmlBPFDoc, bpfFieldControls.Select(x => x.name).ToList());
        }

        public void reloadPanel()
        {
            panel1.Refresh();
            panel1.Invalidate();
        }

        private void btnUpdatePublish_Click(object sender, EventArgs e)
        {
            txbModifiedFormXml.Text = this.controllerManager.xmlManager.generateBpfFormXml(pcfBpfFormList, xmlBPFDoc);
            this.controllerManager.dataManager.updatePublishForm(bpfForm.Id, txbModifiedFormXml.Text, cbBPFEntitiesList.SelectedItem.ToString());
        }


        public void setPossiblePCf(string field)
        {
            resetPossiblePCF();

            var fieldDefinition = attributesMetadata.First(x => x.LogicalName == field);
            var searchType = getTypeMapping(fieldDefinition.AttributeType.Value.ToString());
            var searchTypes = searchType.Split(';');
            var potentialPCFs = pcfList.Where(x => x.GetAttributeValue<string>("compatibledatatypes") != "" && x.GetAttributeValue<string>("compatibledatatypes").Split(',').Any(y => searchTypes.Contains(y)));
            cbPossiblePCFs.Items.AddRange(potentialPCFs.Select(x => x.GetAttributeValue<string>("name")).OrderBy(y => y).ToArray());

            fieldToAttachPCF = field;
            cbPossiblePCFs.Enabled = true;
        }

        public void setExistingPCFDetails(string field, Guid id)
        {
            resetPossiblePCF();

            tbControlDescription.Text = "";
            setPossiblePCf(field);

            pcfEditing = pcfBpfFormList.First(x => x.id == id);

            // Auto select the dropdown list here & disable it
            cbPossiblePCFs.Enabled = false;
            cbPossiblePCFs.SelectedText = pcfEditing.name;
            
            dgvPCFParamsSource.DataSource = pcfEditing.parameters;
        }

        public void setDeletePCFDetails(Guid id)
        {
            // we reset the control in the list
            var pcfToDelete = pcfBpfFormList.FirstOrDefault(x => x.id == id);
            pcfToDelete.action = actions.delete;

            pcfBpfFormList.Add(new PCFDetails()
            {
                attachedField = pcfToDelete.attachedField,
                action = actions.none
            });

            this.controllerManager.xmlManager.generateBpfFormXml(pcfBpfFormList, xmlBPFDoc);
        }

        private void resetPossiblePCF()
        {
            pcfEditing = null;
            cbPossiblePCFs.Items.Clear();
            cbPossiblePCFs.SelectedIndex = -1;
            cbPossiblePCFs.ResetText();
            dgvPCFParamsSource.DataSource = null;
        }

        public string getTypeMapping(string typeValue)
        {
            switch (typeValue)
            {
                case "Money": return "Currency";
                case "Integer": return "Whole.None"; 
                case "Lookup": return "Lookup.Simple";
                case "DateTime": return "DateAndTime.DateAndTime";
                case "Decimal": return "Decimal";
                case "BigInt": return "Whole.None";
                case "Boolean": return "TwoOptions";
                case "Picklist": return "OptionSet";
                case "Memo": return "Multiple;SingleLine.TextArea";
                default: return "SingleLine.Text;SingleLine.Email;SingleLine.URL";
            }
        }

        private void cbPossiblePCFs_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbControlDescription.Text = "";

            var selectedPCF = cbPossiblePCFs.SelectedItem.ToString();
            pcfEditing = pcfAvailableDetailsList.First(x => x.name == selectedPCF);

            pcfEditing.parameters.First().value = fieldToAttachPCF;
            pcfEditing.attachedField = fieldToAttachPCF;

            dgvPCFParamsSource.DataSource = pcfEditing.parameters;

            for (int i = 0; i < dgvPCFParams.Columns.Count - 1; i++)
                dgvPCFParams.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void dgvPCFParams_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

        }

        private void btnApplyChanges_Click(object sender, EventArgs e)
        {
            var requiredFieldsEmpty = pcfEditing.parameters.Any(x => x.required && x.value == null);

            if (requiredFieldsEmpty)
            {
                MessageBox.Show("One or more required fields are empty, please fill them.");
                return;
            }
            //pcfBPFFormList.First(x => x.id == pcfEditing.id).parameters = pcfEditing.parameters;
            pcfEditing.action = actions.modify;

            var element = pcfBpfFormList.First(x => x.attachedField == pcfEditing.parameters.First().value.ToString());
            var index = pcfBpfFormList.IndexOf(element);
            pcfBpfFormList[index] = pcfEditing;

            this.controllerManager.xmlManager.generateBpfFormXml(pcfBpfFormList, xmlBPFDoc);
        }

        private void btnAddControl_Click(object sender, EventArgs e)
        {
            var requiredFieldsEmpty = pcfEditing.parameters.Any(x => x.required && x.value == null);

            if (requiredFieldsEmpty)
            {
                MessageBox.Show("One or more required fields are empty, please fill them.");
                return;
            }

            pcfEditing.action = actions.add;

            var element = pcfBpfFormList.First(x => x.attachedField == pcfEditing.parameters.First().value.ToString());
            var index = pcfBpfFormList.IndexOf(element);
            pcfBpfFormList[index] = pcfEditing;

            this.controllerManager.xmlManager.generateBpfFormXml(pcfBpfFormList, xmlBPFDoc);
        }
    }

    public class PCFDetails
    {
        public string name;
        public string manifest;
        public string controlDescription;
        public string attachedField;
        public Guid? id = null;
        public List<PCFParameters> parameters;
        public List<PCFTypeGroups> typeGroup;
        public actions action = actions.none;
    }

    public class PCFParameters
    {
        [DisplayName("Param Name")]
        public string name { get; set; }

        [DisplayName("Param Desc")]
        public string description { get; set; }
     
        public string usage { get; set; }                  

        [DisplayName("Requied ?")]
        public bool required { get; set; }

        [DisplayName("Param Type")]
        public string ofType { get; set; }

        public string ofTypeGroup;

         [DisplayName("Param Value")]
        public object value { get; set; }

        [DisplayName("Is Static ?")]
        public bool isStatic { get; set; }
    }

    public class PCFTypeGroups
    {
        public string name;
        public string type;
    }

    public enum actions
    {
        none,
        add,
        modify,
        delete
    }
}