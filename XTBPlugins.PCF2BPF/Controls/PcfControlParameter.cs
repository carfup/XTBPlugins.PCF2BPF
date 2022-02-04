using Carfup.XTBPlugins.PCF2BPF;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Carfup.XTBPlugins.Controls
{
    public partial class PcfControlParameter : UserControl
    {
        private List<string> fields = new List<string>();
        private bool isPrimaryField = false;
        private PCFParameters param;
        private PCF2BPF.PCF2BPF pcf2bpf;

        public PcfControlParameter(PCF2BPF.PCF2BPF pcf2bpf, PCFDetails pcf, PCFParameters param, bool isPrimaryField)
        {
            InitializeComponent();

            this.param = param;
            this.pcf2bpf = pcf2bpf;
            this.isPrimaryField = isPrimaryField;

            var name = pcf.resx.FirstOrDefault()?.GetText(param.name) ?? param.name;
            var description = pcf.resx.FirstOrDefault()?.GetText(param.description) ?? param.description;

            lblParamName.Text = $"{name} *";
            lblParamUsage.Text = param.usage;
            ckbRequired.Checked = param.required;
            lblParamType.Text = param.ofType ?? param.ofTypeGroup;
            tbValue.Text = param.value?.ToString();
            ckbStatic.Checked = param.isStatic;

            var descToolTip = new ToolTip()
            {
                ToolTipIcon = ToolTipIcon.Info,
                IsBalloon = true,
                ShowAlways = true,
                ToolTipTitle = "Description"
            };
            descToolTip.SetToolTip(lblParamName, description);

            if (param.complexTypes?.Length > 0)
            {
                lblParamType.Text = lblParamType.Text + " *";
                var typeToolTip = new ToolTip()
                {
                    ToolTipIcon = ToolTipIcon.Info,
                    IsBalloon = true,
                    ShowAlways = true,
                    ToolTipTitle = "Accepted Types"
                };
                typeToolTip.SetToolTip(lblParamType, string.Join(", ", param.complexTypes));
            }

            handleStaticDisplay();

            // Manage visibility
            tbValue.Visible = !cbValue.Visible;
            tbValue.Enabled = !this.isPrimaryField;
        }

        private void cbValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.param.value = cbValue.SelectedItem;
        }

        private void ckbStatic_CheckedChanged(object sender, EventArgs e)
        {
            handleStaticDisplay();
        }

        private void handleStaticDisplay()
        {
            if (this.param.ofType == "Enum")
            {
                cbValue.Items.Clear();
                cbValue.Items.AddRange(param.complexValues);
                cbValue.Visible = true;
                cbValue.SelectedIndex = cbValue.FindString(param.value?.ToString());
                ckbStatic.Enabled = false;
                ckbStatic.Checked = true;
            }
            else if (ckbStatic.Checked && !this.isPrimaryField)
            {
                cbValue.Visible = false;
                tbValue.Visible = true;
            }
            else if (!ckbStatic.Checked && !this.isPrimaryField)
            {
                cbValue.Items.Clear();

                if (this.fields.Count == 0)
                {
                    var typeToSearch = pcf2bpf.mappingType.Where(x => param.complexTypes.Contains(x.Value) || param.ofType == x.Value).Select(y => y.Key).ToList();
                    List<string> types = new List<string>();

                    this.fields = pcf2bpf.attributesMetadata.Where(x =>
                        (x.GetType() == typeof(StringAttributeMetadata) && typeToSearch.Contains(((StringAttributeMetadata)x)?.FormatName?.Value)) ||
                        (x.GetType() == typeof(MemoAttributeMetadata) && typeToSearch.Contains(((MemoAttributeMetadata)x)?.FormatName?.Value)) ||
                        (x.GetType() == typeof(IntegerAttributeMetadata) && typeToSearch.Contains(((IntegerAttributeMetadata)x)?.Format.Value.ToString())) ||
                        (x.GetType() == typeof(DateTimeAttributeMetadata) && typeToSearch.Contains(((DateTimeAttributeMetadata)x)?.Format.Value.ToString())) ||
                        typeToSearch.Contains(x.AttributeType.ToString())).Select(x => x.LogicalName).OrderBy(z => z).ToList();
                }

                if (this.fields.Count() > 0)
                {
                    cbValue.Items.AddRange(this.fields.ToArray());
                    cbValue.SelectedIndex = cbValue.FindString(param.value?.ToString());
                    cbValue.Visible = true;
                    tbValue.Visible = false;
                }
            }

            this.param.isStatic = ckbStatic.Checked;
        }

        private void tbValue_TextChanged(object sender, EventArgs e)
        {
            this.param.value = tbValue.Text;
        }
    }
}