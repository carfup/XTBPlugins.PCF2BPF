using Carfup.XTBPlugins.AppCode;
using Microsoft.Xrm.Sdk;
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
        private EntityMetadata emd;
        private List<string> fields = new List<string>();
        private bool isPrimaryField = false;
        private Dictionary<string, string> mappingType;
        private PCFParameter param;
        private PCFDetails pcf;
        private IOrganizationService service;

        public PcfControlParameter(IOrganizationService service, Dictionary<string, string> mappingType, PCFDetails pcf, PCFParameter param, EntityMetadata emd, bool isPrimaryField)
        {
            InitializeComponent();

            this.service = service;
            this.pcf = pcf;
            this.mappingType = mappingType;
            this.param = param;
            this.emd = emd;
            this.isPrimaryField = isPrimaryField;

            var name = pcf.Resxes.FirstOrDefault()?.GetText(param.displayname) ?? param.name;
            var description = pcf.Resxes.FirstOrDefault()?.GetText(param.description) ?? param.description;

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

            if (param.ComplexTypes?.Length > 0)
            {
                lblParamType.Text = lblParamType.Text + " *";
                var typeToolTip = new ToolTip()
                {
                    ToolTipIcon = ToolTipIcon.Info,
                    IsBalloon = true,
                    ShowAlways = true,
                    ToolTipTitle = "Accepted Types"
                };
                typeToolTip.SetToolTip(lblParamType, string.Join(", ", param.ComplexTypes));
            }

            handleStaticDisplay();

            // Manage visibility
            tbValue.Visible = !cbValue.Visible;
            tbValue.Enabled = !this.isPrimaryField;
        }

        private void cbValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            param.value = ((PCFEnumValue)cbValue.SelectedItem).Value;
        }

        private void ckbStatic_CheckedChanged(object sender, EventArgs e)
        {
            handleStaticDisplay();
        }

        private void handleStaticDisplay()
        {
            if (this.param.ofType == "Enum")
            {
                param.ComplexValues.ForEach((a) => a.LoadLabel(pcf, service));

                cbValue.Items.Clear();
                cbValue.Items.AddRange(param.ComplexValues.ToArray());
                cbValue.Visible = true;
                cbValue.SelectedIndex = cbValue.FindString(param.ComplexValues.FirstOrDefault(cv => cv.Value == param.value?.ToString())?.Label ?? param.value?.ToString());
                ckbStatic.Enabled = false;
                ckbStatic.Checked = true;
            }
            else if (ckbStatic.Checked && !isPrimaryField)
            {
                cbValue.Visible = false;
                tbValue.Visible = true;
            }
            else if (!ckbStatic.Checked && !isPrimaryField)
            {
                cbValue.Items.Clear();

                if (fields.Count == 0)
                {
                    var typeToSearch = mappingType.Where(x => param.ComplexTypes.Contains(x.Value) || param.ofType == x.Value).Select(y => y.Key).ToList();
                    List<string> types = new List<string>();

                    fields = emd.Attributes.Where(x =>
                        (x.GetType() == typeof(StringAttributeMetadata) && typeToSearch.Contains(((StringAttributeMetadata)x)?.FormatName?.Value)) ||
                        (x.GetType() == typeof(MemoAttributeMetadata) && typeToSearch.Contains(((MemoAttributeMetadata)x)?.FormatName?.Value)) ||
                        (x.GetType() == typeof(IntegerAttributeMetadata) && typeToSearch.Contains(((IntegerAttributeMetadata)x)?.Format.Value.ToString())) ||
                        (x.GetType() == typeof(DateTimeAttributeMetadata) && typeToSearch.Contains(((DateTimeAttributeMetadata)x)?.Format.Value.ToString())) ||
                        typeToSearch.Contains(x.AttributeType.ToString())).Select(x => x.LogicalName).OrderBy(z => z).ToList();
                }

                if (fields.Count() > 0)
                {
                    cbValue.Items.AddRange(fields.ToArray());
                    cbValue.SelectedIndex = cbValue.FindString(param.value?.ToString());
                    cbValue.Visible = true;
                    tbValue.Visible = false;
                }
            }
            else if (isPrimaryField)
            {
                tbValue.Text = param.value?.ToString();
            }

            param.isStatic = ckbStatic.Checked;
        }

        private void tbValue_TextChanged(object sender, EventArgs e)
        {
            param.value = tbValue.Text;
        }
    }
}