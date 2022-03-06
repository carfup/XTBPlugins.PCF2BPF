using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Carfup.XTBPlugins.AppCode
{
    public class FormXml
    {
        private readonly Entity _systemForm;

        private XmlDocument _document;

        public FormXml(Entity systemForm)
        {
            _systemForm = systemForm;

            Initialize();
        }

        public Entity SystemForm => _systemForm;
        public List<FormTab> Tabs { get; private set; } = new List<FormTab>();

        public static FormXml GetBpfForm(IOrganizationService service, string entity)
        {
            try
            {
                var record = service.RetrieveMultiple(new QueryExpression()
                {
                    EntityName = "systemform",
                    ColumnSet = new ColumnSet("name", "formxml", "objecttypecode"),
                    Criteria =
                {
                    Conditions =
                    {
                        new ConditionExpression("objecttypecode", ConditionOperator.Like, entity),
                    }
                }
                }).Entities.FirstOrDefault();

                if (record == null) return null;

                return new FormXml(record);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void ApplyMetadata(List<EntityMetadata> emds)
        {
            foreach (var tab in Tabs)
            {
                foreach (var attr in tab.Attributes)
                {
                    var emd = emds.FirstOrDefault(e => e.OneToManyRelationships.Any(r => r.SchemaName == attr.Relationship));
                    if (emd == null) continue;
                    var amd = emd.Attributes.First(a => a.LogicalName == attr.LogicalName);

                    attr.SetMetadata(emd, amd);
                }
            }
        }

        public string GetCurrentXml()
        {
            return _document.OuterXml;
        }

        public void UpdateAndPublish(IOrganizationService service)
        {
            _systemForm["formxml"] = _document.OuterXml;

            service.Update(_systemForm);

            var paramXml = string.Format("<importexportxml><entities><entity>{0}</entity></entities><nodes/><securityroles/><settings/><workflows/></importexportxml>", _systemForm.GetAttributeValue<string>("objecttypecode"));
            service.Execute(new PublishXmlRequest
            {
                ParameterXml = paramXml
            });
        }

        private void Initialize()
        {
            _document = new XmlDocument();
            _document.LoadXml(_systemForm.GetAttributeValue<string>("formxml"));

            CleanOrphanNodes();
            _document.LoadXml(_document.InnerXml);

            Tabs = new List<FormTab>();
            int i = 0;
            foreach (XmlNode tabNode in _document.SelectNodes("//tab"))
            {
                Tabs.Add(new FormTab(tabNode, ++i));
            }
        }

        public void CleanOrphanNodes()
        {
            // Looking for orphan ConstrolDescriptions
            var controls = _document.SelectNodes(".//control");         
            var pcfNodes = _document.SelectSingleNode(".//controlDescriptions");

            foreach(XmlNode pcfNode in pcfNodes.ChildNodes)
            {
                var uniqueId = pcfNode.Attributes["forControl"].Value;
                var relatedControlExist = controls.Cast<XmlNode>().Any(x => x.Attributes["uniqueid"]?.Value == uniqueId);

                if(!relatedControlExist || pcfNode.SelectNodes(".//parameters").Count == 0)
                {
                    _document.InnerXml = _document.InnerXml.Replace(pcfNode.OuterXml, "");
                }
            }

           // _document.Load(_document.OuterXml);
        }
    }
}