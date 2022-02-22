using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Carfup.XTBPlugins.AppCode
{
    [Serializable]
    public class PCFDetails
    {
        public string AttachedField { get; set; }
        public List<string> CompatibleDataTypes { get; private set; }
        public string ControlDescription { get; set; }

        public string CustomControlName
        {
            get
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(Manifest);

                return $"{xmlDoc.SelectSingleNode("//control").Attributes["namespace"].Value}.{xmlDoc.SelectSingleNode("//control").Attributes["constructor"].Value}";
            }
        }

        public Guid? Id { get; set; } = null;
        public string Manifest { get; set; }
        public string Name { get; set; }
        public List<PCFParameter> Parameters { get; set; }
        public List<PCFTypeGroup> TypeGroups { get; set; }
        internal List<PCFResx> Resxes { get; set; }

        public static PCFDetails Load(Entity pcf, int userLcid)
        {
            var doc = new XmlDocument();
            doc.LoadXml(pcf.GetAttributeValue<string>("manifest"));

            var properties = doc.SelectNodes("//property");
            var typeGroups = doc.SelectNodes("//type-group");

            var typeGroupValues = new List<PCFTypeGroup>();
            foreach (XmlNode typeg in typeGroups)
            {
                foreach (XmlNode type in typeg.SelectNodes("type"))
                    typeGroupValues.Add(new PCFTypeGroup
                    {
                        name = typeg.Attributes["name"]?.Value,
                        type = type.InnerText,
                    });
            }
            List<PCFResx> pcfResxes = new List<PCFResx>();

            var resxes = doc.SelectNodes("//resx");
            foreach (XmlNode resx in resxes)
            {
                var pcfResx = new PCFResx(resx.Attributes["path"]?.Value,
                    doc.SelectSingleNode("//control").Attributes["namespace"]?.Value,
                    doc.SelectSingleNode("//control").Attributes["constructor"]?.Value);

                pcfResxes.Add(pcfResx);
            }

            List<PCFParameter> pcfParams = new List<PCFParameter>();
            foreach (XmlNode prop in properties)
            {
                var complexValues = new List<PCFEnumValue>();
                var complexTypes = new List<string>();
                if (prop.Attributes["of-type"]?.Value == "Enum")
                {
                    complexValues = prop.ChildNodes.Cast<XmlNode>().Select(x => new PCFEnumValue(x.Attributes["name"]?.Value, pcfResxes.FirstOrDefault(r => r.Lcid == userLcid)?.GetText(x.Attributes["display-name-key"]?.Value), x.InnerText)).ToList();
                }

                if (prop.Attributes["of-type-group"]?.Value != null)
                {
                    complexTypes = typeGroupValues.Select(x => x.type).ToList();
                }

                pcfParams.Add(new PCFParameter
                {
                    name = prop.Attributes["name"]?.Value,
                    displayname = prop.Attributes["display-name-key"]?.Value,
                    description = prop.Attributes["description-key"]?.Value,
                    required = prop.Attributes["required"]?.Value == "true" ? true : false,
                    usage = prop.Attributes["usage"]?.Value,
                    ofType = prop.Attributes["of-type"]?.Value ?? prop.Attributes["of-type-group"]?.Value,
                    ofTypeGroup = prop.Attributes["of-type-group"]?.Value,
                    ComplexTypes = complexTypes.ToArray(),
                    ComplexValues = complexValues
                });
            }

            // Generating the full list of pcf details
            return new PCFDetails
            {
                Name = pcf.GetAttributeValue<string>("name"),
                Manifest = pcf.GetAttributeValue<string>("manifest"),
                CompatibleDataTypes = pcf.GetAttributeValue<string>("compatibledatatypes").Split(',').ToList(),
                Parameters = pcfParams,
                TypeGroups = typeGroupValues,
                Resxes = pcfResxes,
                Id = null
            };
        }

        public PCFDetails Clone()
        {
            var cloned = new PCFDetails
            {
                AttachedField = AttachedField,
                ControlDescription = ControlDescription,
                Manifest = Manifest,
                Name = Name,
                Parameters = Parameters.ToList(),
                TypeGroups = TypeGroups.ToList(),
                Resxes = Resxes.ToList()
            };

            cloned.Parameters.ForEach((parameter) => { parameter.value = null; });

            return cloned;
        }

        public override string ToString()
        {
            return Resxes.FirstOrDefault()?.GetText(Name) ?? Name;
        }
    }
}