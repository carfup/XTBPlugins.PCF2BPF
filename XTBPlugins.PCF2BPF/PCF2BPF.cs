using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using System.Xml;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Crm.Sdk.Messages;

namespace Carfup.XTBPlugins.PCF2BPF
{
    public partial class PCF2BPF : PluginControlBase
    {
        private Settings mySettings;
        public List<Entity> formsList = new List<Entity>();
        public List<Entity> bpfFormsList = new List<Entity>();
        public XmlDocument xmlDoc = new XmlDocument() { };
        public XmlDocument xmlBPFDoc = new XmlDocument() { };
        public List<PCFContent> controlPCFList = new List<PCFContent>();
        public string BPFFormXml;

        public PCF2BPF()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            ShowInfoNotification("This is a notification that can lead to XrmToolBox repository !!!", new Uri("https://github.com/MscrmTools/XrmToolBox"));

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
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tsbSample_Click(object sender, EventArgs e)
        {
            // The ExecuteMethod method handles connecting to an
            // organization if XrmToolBox is not yet connected
            ExecuteMethod(GetAccounts);
        }

        private void GetAccounts()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting accounts",
                Work = (worker, args) =>
                {
                    args.Result = Service.RetrieveMultiple(new QueryExpression("account")
                    {
                        TopCount = 50
                    });
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as EntityCollection;
                    if (result != null)
                    {
                        MessageBox.Show($"Found {result.Entities.Count} accounts");
                    }
                }
            });
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

        private void btnLoadForms_Click(object sender, EventArgs e)
        {
            formsList = Service.RetrieveMultiple(new QueryExpression()
            {
                EntityName = "systemform",
                ColumnSet = new ColumnSet("name", "formxml"),
                Criteria =
                {
                    Conditions =
                    {
                        new ConditionExpression("formxml", ConditionOperator.Like, "%<customControl%"),
                        new ConditionExpression("objecttypecode", ConditionOperator.Equal, cbEntitiesList.SelectedItem.ToString())
                    }
                }
            }).Entities.ToList();

            cbFormsList.Items.AddRange(formsList.Select(x => x.GetAttributeValue<string>("name")).ToArray());

        }

        private void cbFormsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedForm = formsList.First(x => x.GetAttributeValue<string>("name") == cbFormsList.SelectedItem.ToString()).GetAttributeValue<string>("formxml");
            xmlDoc.LoadXml(selectedForm);
            var pcfs = xmlDoc.SelectNodes("//controlDescription");
            controlPCFList = new List<PCFContent>();
            foreach (XmlNode control in pcfs)
            {
                if (control.SelectSingleNode("//datafieldname") == null)
                    continue;

                controlPCFList.Add(new PCFContent()
                {
                    content = control.OuterXml,
                    id = control.Attributes["forControl"].Value,
                    name = control.SelectSingleNode("//datafieldname").InnerText
                });
            }
                

            cbPCFFields.Items.AddRange(controlPCFList.Select(x => x.name).ToArray());
        }

        private void btnLoadBPFForms_Click(object sender, EventArgs e)
        {
            bpfFormsList = Service.RetrieveMultiple(new QueryExpression()
            {
                EntityName = "systemform",
                ColumnSet = new ColumnSet("name", "formxml"),
                Criteria =
                {
                    Conditions =
                    {
                        new ConditionExpression("formxml", ConditionOperator.Like, "%StageStep%"),
                        new ConditionExpression("objecttypecode", ConditionOperator.Like, cbBPFEntitiesList.SelectedItem.ToString()),
                    }
                }
            }).Entities.ToList();

            cbBFPFormsList.Items.AddRange(bpfFormsList.Select(x => x.GetAttributeValue<string>("name")).ToArray());
        }

        private void cbBFPFormsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BPFFormXml = bpfFormsList.First(x => x.GetAttributeValue<string>("name") == cbBFPFormsList.SelectedItem.ToString()).GetAttributeValue<string>("formxml");
            txbFormXml.Text = BPFFormXml;
            xmlBPFDoc.LoadXml(BPFFormXml);
        }
        private void btnTransformFormXml_Click(object sender, EventArgs e)
        {
            var bpfControls = xmlBPFDoc.SelectNodes("//control");

            foreach (XmlNode bpfControl in bpfControls)
            {
                var control = controlPCFList.FirstOrDefault(x => x.name == bpfControl.Attributes["datafieldname"].Value);
                if (control != null)
                {
                    XmlAttribute typeAttr = xmlBPFDoc.CreateAttribute("uniqueid");
                    typeAttr.Value = control.id;
                    bpfControl.Attributes.Append(typeAttr);
                    control.added = true;
                }
            }

            //check if controlDescriptions exist already
            var bpfControlsControlDescriptions = xmlBPFDoc.SelectNodes("//controlDescriptions");
            if (bpfControlsControlDescriptions.Count == 1)
            {
                // Append controldescription
                var controlDescriptions = "";
                foreach (var c in controlPCFList.Where(x => x.added))
                {
                    controlDescriptions += c.content;
                }
                controlDescriptions += "</controlDescriptions>";
                xmlBPFDoc.InnerXml = xmlBPFDoc.InnerXml.Replace("</controlDescriptions>", controlDescriptions);

            }
            else
            {
                // add the full part
                var controlDescriptions = "<controlDescriptions>";
                foreach (var c in controlPCFList.Where(x => x.added))
                {
                    controlDescriptions += c.content;
                }
                controlDescriptions += "</controlDescriptions></form>";

                xmlBPFDoc.InnerXml = xmlBPFDoc.InnerXml.Replace("</form>", controlDescriptions);
            }

            txbModifiedFormXml.Text = xmlBPFDoc.InnerXml;
        }

        private void btnLoadEntities_Click(object sender, EventArgs e)
        {
            List<EntityMetadata> entities = new List<EntityMetadata>();

            RetrieveAllEntitiesRequest request = new RetrieveAllEntitiesRequest
            {
                RetrieveAsIfPublished = true,
                EntityFilters = EntityFilters.Entity
            };

            RetrieveAllEntitiesResponse response = (RetrieveAllEntitiesResponse)Service.Execute(request);

            foreach (EntityMetadata emd in response.EntityMetadata)
            {
                if (emd.DisplayName.UserLocalizedLabel != null &&
                    (emd.IsCustomizable.Value || emd.IsManaged.Value == false))
                {
                    entities.Add(emd);
                }
            }           

            cbEntitiesList.Items.AddRange(entities.Select(x => x.LogicalName).ToArray());
            cbBPFEntitiesList.Items.AddRange(entities.Where(x => x.IsBPFEntity.Value).Select(x => x.LogicalName).ToArray());
        }

        private void cbBPFEntitiesList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdatePublish_Click(object sender, EventArgs e)
        {
            var formId = bpfFormsList.First(x => x.GetAttributeValue<string>("name") == cbBFPFormsList.SelectedItem.ToString()).Id;
            var form = new Entity("systemform", formId)
            {
                ["formxml"] = txbModifiedFormXml.Text
            };
            Service.Update(form);

            var paramXml = string.Format(" <importexportxml><entities><entity>{0}</entity></entities><nodes/><securityroles/><settings/><workflows/></importexportxml>", cbBPFEntitiesList.SelectedItem.ToString());
            Service.Execute(new PublishXmlRequest
            {
                ParameterXml = paramXml
            });
        }
    }

    public class PCFContent
    {
        public string id;
        public string name;
        public string content;
        public bool added = false;
    }
}