using Carfup.XTBPlugins.AppCode;
using Carfup.XTBPlugins.Controls;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
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
        private FormAttribute _currentAttribute;
        private actions actionInProgress = actions.none;
        private List<Entity> bpfEntitiesList = new List<Entity>();
        private FormXml bpfForm = null;
        private ControllerManager controllerManager = null;
        private Dictionary<string, string> mappingType = new Dictionary<string, string>();
        private List<PCFDetails> pcfAvailableDetailsList = new List<PCFDetails>();
        private PCFDetails pcfEditing;

        public PCF2BPF()
        {
            InitializeComponent();
        }

        public void SetAddPcf(FormAttribute attribute)
        {
            actionInProgress = actions.add;
            panelParams.Controls.Clear();

            attribute.PcfConfiguration = null;

            SetPossiblePCf(attribute);
        }

        public void SetExistingPCFDetails(FormAttribute attribute)
        {
            actionInProgress = actions.modify;

            ResetPossiblePCF();
            SetPossiblePCf(attribute);

            // Auto select the dropdown list here & disable it
            cbPossiblePCFs.Enabled = false;
            cbPossiblePCFs.SelectedText = attribute.PcfConfiguration.Name;

            LoadParamToPanel(attribute.PcfConfiguration);
        }

        public void SetPossiblePCf(FormAttribute attribute)
        {
            ResetPossiblePCF();
            _currentAttribute = attribute;
            _currentAttribute.Control.BackColor = Color.FromArgb(226, 226, 226);
            var searchType = GetTypeMapping(attribute.Amd);
            var potentialPCFs = pcfAvailableDetailsList.Where(x => x.CompatibleDataTypes.Contains(searchType));

            cbPossiblePCFs.Items.AddRange(potentialPCFs.Select(x => x.Name).OrderBy(y => y).ToArray());
            cbPossiblePCFs.Enabled = true;
            cbPossiblePCFs.Focus();

            panelRight.Visible = true;
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);
        }

        private void BpfFieldCtrl_OnActionRequested(object sender, BpfFieldControlActionEventArgs e)
        {
            var attribute = (FormAttribute)((BpfFieldControl)sender).Tag;

            lblCurrentBpfField.Text = attribute.ToString();

            switch (e.Action)
            {
                case BpfFieldControlAction.Add:

                    if (_currentAttribute != null) _currentAttribute.Control.BackColor = Color.Transparent;
                    SetAddPcf(attribute);
                    break;

                case BpfFieldControlAction.Remove:
                    attribute.RemoveCustomControl();
                    ResetPossiblePCF();
                    panelRight.Visible = false;
                    panelParams.Controls.Clear();
                    txbModifiedFormXml.Text = bpfForm.GetCurrentXml();
                    break;

                case BpfFieldControlAction.Edit:
                    if (_currentAttribute != null) _currentAttribute.Control.BackColor = Color.Transparent;
                    SetExistingPCFDetails(attribute);
                    break;
            }
        }

        private void btnAddApplyControl_Click(object sender, EventArgs e)
        {
            var requiredFieldsEmpty = pcfEditing?.Parameters.Any(x => x.required && string.IsNullOrEmpty(x.value?.ToString()));

            if (requiredFieldsEmpty.Value)
            {
                MessageBox.Show("One or more required fields are empty, please fill them.");
                return;
            }

            if (actionInProgress == actions.modify)
            {
                _currentAttribute.EditCustomControl(pcfEditing);
            }
            else if (actionInProgress == actions.add)
            {
                _currentAttribute.AddCustomControl(pcfEditing);
            }

            panelRight.Visible = false;
            panelParams.Controls.Clear();

            txbModifiedFormXml.Text = bpfForm.GetCurrentXml();
        }

        private void btnLoadEntities_Click(object sender, EventArgs e)
        {
            ExecuteMethod(PrivateLoadEntities);
        }

        private void btnUpdatePublish_Click(object sender, EventArgs evt)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Updating and Publishing the BPF Form..",
                Work = (bw, e) =>
                {
                    bpfForm.UpdateAndPublish(Service);
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
                    bpfForm = FormXml.GetBpfForm(Service, bpfEntityLogicalName);

                    if (bpfForm == null || bpfForm.SystemForm.GetAttributeValue<string>("formxml").Contains("<hiddencontrols>"))
                    {
                        throw new Exception("This BPF is not yet supported. We do hope it will be the case in a near future.");
                    }
                    else
                    {
                        var rels = bpfForm.Tabs.SelectMany(t => t.Attributes).Select(a => a.Relationship);

                        bw.ReportProgress(0, "Loading related metadata...");

                        List<EntityMetadata> emds = this.controllerManager.dataManager.GetMetadata(rels);
                        bpfForm.ApplyMetadata(emds);

                        e.Result = bpfForm;
                    }
                },
                PostWorkCallBack = e =>
                {
                    if (e.Error != null)
                    {
                        MessageBox.Show(this, e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var fx = (FormXml)e.Result;
                    var ctrls = new List<UserControl>();

                    foreach (var tab in fx.Tabs)
                    {
                        var bpfStageCtrl = new BpfStageControl(tab.ToString()) { Dock = DockStyle.Top };
                        bpfStageCtrl.Tag = tab;
                        tab.Control = bpfStageCtrl;
                        ctrls.Add(bpfStageCtrl);

                        foreach (var attr in tab.Attributes)
                        {
                            var pcfDefinition = pcfAvailableDetailsList.FirstOrDefault(x => x.Name == attr.CustomControlName);

                            attr.Initialize(pcfDefinition);
                            var bpfFieldCtrl = new BpfFieldControl(attr.ToString()) { Dock = DockStyle.Top };
                            bpfFieldCtrl.OnActionRequested += BpfFieldCtrl_OnActionRequested;
                            bpfFieldCtrl.Tag = attr;
                            attr.Control = bpfFieldCtrl;
                            ctrls.Add(bpfFieldCtrl);
                        }
                    }

                    ctrls.Reverse();
                    panelStagesFields.Controls.AddRange(ctrls.ToArray());

                    txbFormXml.Text = fx.SystemForm.GetAttributeValue<string>("formxml");
                },
                ProgressChanged = e => { SetWorkingMessage(e.UserState.ToString()); }
            });
        }

        private void cbPossiblePCFs_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedPCF = cbPossiblePCFs.SelectedItem.ToString();

            pcfAvailableDetailsList.FirstOrDefault(x => x.Name == selectedPCF)?.Resxes?.FirstOrDefault()?.Load(Service);
            _currentAttribute.PcfConfiguration?.Resxes?.FirstOrDefault()?.Load(Service);

            pcfEditing = pcfAvailableDetailsList.First(x => x.Name == selectedPCF).Clone();

            if (_currentAttribute.PcfConfiguration == null)
            {
                _currentAttribute.PcfConfiguration = pcfEditing.Clone();
            }

            LoadParamToPanel(_currentAttribute.PcfConfiguration);
        }

        private string GetTypeMapping(AttributeMetadata amd, bool fromAttrToPcf = true)
        {
            var typeToLookFor = amd.AttributeType.Value.ToString();
            if (amd.GetType() == typeof(StringAttributeMetadata))
            {
                typeToLookFor = ((StringAttributeMetadata)amd).FormatName.Value;
            }
            else if (amd.GetType() == typeof(MemoAttributeMetadata))
            {
                typeToLookFor = ((MemoAttributeMetadata)amd).FormatName.Value;
            }
            else if (amd.GetType() == typeof(IntegerAttributeMetadata))
            {
                typeToLookFor = ((IntegerAttributeMetadata)amd).Format.Value.ToString();
            }
            else if (amd.GetType() == typeof(DateTimeAttributeMetadata))
            {
                typeToLookFor = ((DateTimeAttributeMetadata)amd).Format.Value.ToString();
            }

            if (fromAttrToPcf)
                return mappingType.FirstOrDefault(x => x.Key == typeToLookFor).Value;
            else
                return mappingType.FirstOrDefault(x => x.Value == typeToLookFor).Key;
        }

        private void LoadMappingTypes()
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

        private void LoadParamToPanel(PCFDetails pcf)
        {
            panelParams.Controls.Clear();
            var controls = new List<UserControl>();

            int i = 0;
            foreach (var param in pcf.Parameters)
            {
                controls.Add(new PcfControlParameter(Service, mappingType, pcf, param, _currentAttribute.Emd, i == 0) { Dock = DockStyle.Top });
                i++;
            }
            controls.Reverse();

            panelParams.Controls.AddRange(controls.ToArray());
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            if (ConnectionDetail != null && ConnectionDetail.ServiceClient != null)
            {
                // creating the controller
                controllerManager = new ControllerManager(this);
            }

            LoadMappingTypes();
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
        }

        private void PrivateLoadEntities()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading BPF Entities...",
                Work = (bw, e) =>
                {
                    bpfEntitiesList = this.controllerManager.dataManager.RetrieveBPFEntities();

                    bw.ReportProgress(0, "Loading available PCF in your environment...");

                    pcfAvailableDetailsList = this.controllerManager.dataManager.RetrievePcfList().Select(pcf => PCFDetails.Load(pcf)).ToList();
                },
                PostWorkCallBack = e =>
                {
                    if (e.Error != null)
                    {
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

        private void ResetPossiblePCF()
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
}