using Carfup.XTBPlugins.PCF2BPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class DataManager
        /// </summary>
        /// <param name="service">Details of the connected user</param>
        public XmlManager(ControllerManager connection)
        {
            this.connection = connection;
        }

        #endregion Constructor

        public List<PCFDetails> getExistingPCFDetails(XmlDocument xmlBpfDoc)
        {
            var controls = xmlBpfDoc.SelectNodes("//controlDescription");

            List<PCFDetails> pcfAvailableDetailsList = new List<PCFDetails>();
            foreach (XmlNode control in controls)
            {
                List<PCFParameters> pcfParamsExisting = new List<PCFParameters>();

                var pcfName = control.SelectSingleNode(".//customControl").Attributes["name"]?.Value;
                var pcfManifestDetails = pcfAvailableDetailsList.First(x => x.name == pcfName);

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
                    });
                }

                pcfAvailableDetailsList.Add(new PCFDetails
                {
                    name = control.SelectSingleNode(".//customControl").Attributes["name"]?.Value,
                    manifest = control.OuterXml,
                    parameters = pcfParamsExisting,
                    id = new Guid(control.Attributes["forControl"]?.Value),
                    controlDescription = pcfManifestDetails.controlDescription,
                    attachedField = pcfParamsExisting.First().name
                });
            }

            return pcfAvailableDetailsList;
        }

        private List<PCFDetails> pcfDetailsFromManifest(List<Entity> pcfList)
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

                List<PCFParameters> pcfParams = new List<PCFParameters>();
                foreach (XmlNode prop in properties)
                {
                    pcfParams.Add(new PCFParameters
                    {
                        name = prop.Attributes["name"]?.Value,
                        description = prop.Attributes["description-key"]?.Value,
                        required = prop.Attributes["required"]?.Value == "true" ? true : false,
                        usage = prop.Attributes["usage"]?.Value,
                        ofType = prop.Attributes["of-type"]?.Value ?? typeGroupValues.FirstOrDefault(x => x.name == prop.Attributes["of-type-group"].Value)?.type,
                        ofTypeGroup = prop.Attributes["of-type-group"] != null ? string.Join(";", typeGroupValues.Where(x => x.name == prop.Attributes["of-type-group"].Value).Select(x => x.type)) : null
                    });
                }

                // Generating the full list of pcf details
                pcfAvailableDetailsList.Add(new PCFDetails
                {
                    name = pcf.GetAttributeValue<string>("name"),
                    manifest = controlManifest,
                    parameters = pcfParams,
                    typeGroup = typeGroupValues,
                    id = null
                });
            }

            return pcfAvailableDetailsList;
        }
    }
}
