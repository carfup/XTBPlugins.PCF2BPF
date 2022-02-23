﻿using Carfup.XTBPlugins.AppCode;
using Carfup.XTBPlugins.Controls;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace Carfup.XTBPlugins.PCF2BPF
{
    public enum actions
    {
        none,
        add,
        modify,
        delete
    }

    public partial class PCF2BPF : PluginControlBase, IGitHubPlugin, IPayPalPlugin
    {
        public LogUsageManager log = null;
        internal PluginSettings settings = new PluginSettings();
        private FormAttribute _currentAttribute;
        private actions actionInProgress = actions.none;
        private List<Entity> bpfEntitiesList = new List<Entity>();
        private FormXml bpfForm = null;
        private ControllerManager controllerManager = null;
        private Dictionary<string, string> mappingType = new Dictionary<string, string>();
        private List<PCFDetails> pcfAvailableDetailsList = new List<PCFDetails>();
        private PCFDetails pcfEditing;
        private int userLcid;

        public PCF2BPF()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        public static string CurrentVersion
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
                return fileVersionInfo.ProductVersion;
            }
        }

        public string DonationDescription => "Thanks a lot for your support, this really mean something to me, and push me to keep going for sure ! Long life to PCF2BPF ! =)";
        public string EmailAccount => "clement@carfup.com";
        public string RepositoryName => "XTBPlugins.PCF2BPF";
        public string UserName => "carfup";

        public void SaveSettings(bool closeApp = false)
        {
            if (closeApp)
                log.LogData(EventType.Event, LogAction.SettingsSavedWhenClosing);
            else
                log.LogData(EventType.Event, LogAction.SettingsSaved);
            SettingsManager.Instance.Save(typeof(PCF2BPF), settings);
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

            cbPossiblePCFs.SelectedText = attribute.PcfConfiguration.Name;
            cbPossiblePCFs.Enabled = false;

            pcfEditing = bpfForm.Tabs.SelectMany(x => x.Attributes).FirstOrDefault(y => y.UniqueId == attribute.UniqueId)?.PcfConfiguration;
            _currentAttribute = attribute;

            LoadParamToPanel(attribute.PcfConfiguration);
            log.LogData(EventType.Event, LogAction.ExistingPcfDetailsLoaded);
        }

        public void SetPossiblePCf(FormAttribute attribute)
        {
            ResetPossiblePCF();
            _currentAttribute = attribute;
            _currentAttribute.Control.BackColor = Color.FromArgb(226, 226, 226);
            var searchType = GetTypeMapping(attribute.Amd);
            var potentialPCFs = pcfAvailableDetailsList.Where(x => x.CompatibleDataTypes.Contains(searchType));

            var items = potentialPCFs.Select(x => x.Name).OrderBy(y => y).ToArray();

            cbPossiblePCFs.Items.AddRange(items);
            cbPossiblePCFs.Enabled = true;
            cbPossiblePCFs.Focus();

            panelRight.Visible = true;

            if (items.Length == 0)
            {
                MessageBox.Show($"There are not compatible PCF with the field type '{attribute.Amd.AttributeType.Value.ToString()}'.", "No PCF available for this field.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.LogData(EventType.Exception, LogAction.FieldTypeNotSupported, new Exception($"{attribute.Amd.AttributeType.Value.ToString()} no compatible PCF"));
                return;
            }

            log.LogData(EventType.Event, LogAction.PossiblePcfSet);
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
                    log.LogData(EventType.Event, LogAction.AddingControl);
                    break;

                case BpfFieldControlAction.Remove:
                    attribute.RemoveCustomControl();
                    ResetPossiblePCF();
                    panelRight.Visible = false;
                    panelParams.Controls.Clear();
                    txbModifiedFormXml.Text = bpfForm.GetCurrentXml();
                    log.LogData(EventType.Event, LogAction.ControlRemoved);
                    break;

                case BpfFieldControlAction.Edit:
                    if (_currentAttribute != null) _currentAttribute.Control.BackColor = Color.Transparent;
                    SetExistingPCFDetails(attribute);
                    log.LogData(EventType.Event, LogAction.ModifyingControl);
                    break;
            }
        }

        private void btnAddApplyControl_Click(object sender, EventArgs e)
        {
            var requiredFieldsEmpty = pcfEditing?.Parameters.Any(x => x.required && string.IsNullOrEmpty(x.value?.ToString()));

            if (requiredFieldsEmpty ?? false)
            {
                MessageBox.Show("One or more required fields are empty, please fill them.");
                return;
            }

            if (actionInProgress == actions.modify)
            {
                _currentAttribute.EditCustomControl(pcfEditing);
                log.LogData(EventType.Event, LogAction.ControlModified);
            }
            else if (actionInProgress == actions.add)
            {
                _currentAttribute.AddCustomControl(pcfEditing);
                log.LogData(EventType.Event, LogAction.ControlAdded);
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
                        this.log.LogData(EventType.Exception, LogAction.UpdateAndPublish, e.Error);
                        MessageBox.Show(this, e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    log.LogData(EventType.Event, LogAction.UpdateAndPublish);
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
                        log.LogData(EventType.Trace, LogAction.BpfNotSupportedYet);
                        throw new Exception($"This BPF is not yet supported. {Environment.NewLine}{Environment.NewLine}Please try to perform an update or activate the selected BPF in order to regenerate the XML and fix the issue.{Environment.NewLine}{Environment.NewLine}Else we do hope it will be the case in a near future.");
                    }
                    else
                    {
                        var rels = bpfForm.Tabs.SelectMany(t => t.Attributes).Select(a => a.Relationship).Where(a => a != null).Distinct();

                        bw.ReportProgress(0, "Loading related metadata...");

                        var emds = this.controllerManager.dataManager.GetMetadata(rels);
                        bpfForm.ApplyMetadata(emds);

                        bw.ReportProgress(0, "Building BPF...");

                        var ctrls = new List<UserControl>();

                        foreach (var tab in bpfForm.Tabs)
                        {
                            var bpfStageCtrl = new BpfStageControl(tab.ToString()) { Dock = DockStyle.Top };
                            bpfStageCtrl.Tag = tab;
                            tab.Control = bpfStageCtrl;
                            ctrls.Add(bpfStageCtrl);

                            foreach (var attr in tab.Attributes)
                            {
                                attr.Initialize(pcfAvailableDetailsList);
                                var bpfFieldCtrl = new BpfFieldControl(attr.ToString()) { Dock = DockStyle.Top };
                                bpfFieldCtrl.OnActionRequested += BpfFieldCtrl_OnActionRequested;
                                bpfFieldCtrl.Tag = attr;
                                attr.Control = bpfFieldCtrl;
                                ctrls.Add(bpfFieldCtrl);
                            }
                        }

                        ctrls.Reverse();

                        e.Result = new Tuple<List<UserControl>, string>(ctrls, bpfForm.SystemForm.GetAttributeValue<string>("formxml"));
                    }
                },
                PostWorkCallBack = e =>
                {
                    if (e.Error != null)
                    {
                        log.LogData(EventType.Exception, LogAction.LoadingBpfFormDetails, e.Error);
                        MessageBox.Show(this, e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var result = (Tuple<List<UserControl>, string>)e.Result;

                    panelStagesFields.Controls.AddRange(result.Item1.ToArray());
                    txbFormXml.Text = result.Item2;
                    log.LogData(EventType.Event, LogAction.LoadingBpfFormDetails);
                },
                ProgressChanged = e => { SetWorkingMessage(e.UserState.ToString()); }
            });
        }

        private void cbPossiblePCFs_SelectedIndexChanged(object sender, EventArgs evt)
        {
            var selectedPCF = cbPossiblePCFs.SelectedItem.ToString();

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading PCF parameters details...",
                Work = (bw, e) =>
                {
                    pcfEditing = pcfAvailableDetailsList.First(x => x.Name == selectedPCF).Clone();

                    _currentAttribute.PcfConfiguration = pcfEditing.Clone();

                    Invoke(new Action(() =>
                    {
                        LoadParamToPanel(_currentAttribute.PcfConfiguration);
                    }));
                },
                PostWorkCallBack = e =>
                {
                    if (e.Error != null)
                    {
                        log.LogData(EventType.Exception, LogAction.PossiblePcfLoaded, e.Error);
                        MessageBox.Show(this, e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    log.LogData(EventType.Event, LogAction.PossiblePcfLoaded);
                },
                ProgressChanged = e => { SetWorkingMessage(e.UserState.ToString()); }
            });
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

            if (pcf.Resxes.Any(r => r.IsLoaded == false))
            {
                pcf.Resxes.ForEach(r => r.Load(Service));
            }

            int i = 0;
            foreach (var param in pcf.Parameters)
            {
                controls.Add(new PcfControlParameter(Service, mappingType, pcf, param, _currentAttribute.Emd, i == 0, userLcid) { Dock = DockStyle.Top });
                i++;
            }
            controls.Reverse();

            panelParams.Controls.AddRange(controls.ToArray());
        }

        private void LoadSetting()
        {
            try
            {
                if (SettingsManager.Instance.TryLoad<PluginSettings>(typeof(PCF2BPF), out settings))
                {
                    return;
                }
                else
                    settings = new PluginSettings();
            }
            catch (InvalidOperationException ex)
            {
                log.LogData(EventType.Exception, LogAction.SettingLoaded, ex);
            }

            log.LogData(EventType.Event, LogAction.SettingLoaded);

            if (!settings.AllowLogUsage.HasValue)
            {
                log.PromptToLog();
                SaveSettings();
            }
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            log = new LogUsageManager(this);
            LoadSetting();
            log.LogData(EventType.Event, LogAction.SettingLoaded);

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

                    bw.ReportProgress(0, "Loading current user language...");

                    userLcid = this.controllerManager.dataManager.GetUserLcid();

                    bw.ReportProgress(0, "Loading available PCF in your environment...");

                    var pcflist = this.controllerManager.dataManager.RetrievePcfList();

                    foreach(var pcf in pcflist)
                        pcfAvailableDetailsList.Add(PCFDetails.Load(pcf, userLcid));
                    
                },
                PostWorkCallBack = e =>
                {
                    if (e.Error != null)
                    {
                        log.LogData(EventType.Exception, LogAction.BpfEntitiesLoaded, e.Error);
                        MessageBox.Show(this, e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (bpfEntitiesList != null)
                    {
                        cbBPFEntitiesList.Items.Clear();
                        cbBPFEntitiesList.Items.AddRange(bpfEntitiesList.Select(x => x.GetAttributeValue<string>("name")).OrderBy(x => x).Distinct().ToArray());
                    }

                    cbBPFEntitiesList.Enabled = true;
                    this.log.LogData(EventType.Event, LogAction.BpfEntitiesLoaded);
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
            this.log.LogData(EventType.Event, LogAction.PluginClosed);

            // Saving settings for the next usage of plugin
            SaveSettings();

            // Making sure that all message are sent if stats are enabled
            this.log.Flush();

            CloseTool();
        }
    }
}