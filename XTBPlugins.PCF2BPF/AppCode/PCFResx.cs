using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;

namespace Carfup.XTBPlugins.AppCode
{
    [Serializable]
    public class PCFResx
    {
        private static List<Entity> _resources = new List<Entity>();
        private string _constructor;
        private int _lcid;
        private string _publisher;
        private ResXResourceSet resxSet;

        public PCFResx(string path, string publisher, string constructor)
        {
            _publisher = publisher;
            _constructor = constructor;
            Path = path;

            var languagePart = path.Split('.')[1];

            if (!int.TryParse(languagePart, out _lcid))
            {
                _lcid = new CultureInfo(languagePart).LCID;
            }
        }

        public bool IsLoaded { get; private set; }
        public int Lcid => _lcid;
        public string Path { get; set; }
        public string WebresourceName => $"cc_{_publisher}.{_constructor}/{Path}";

        public string GetText(string key)
        {
            return resxSet?.GetString(key) ?? key;
        }

        public void Load(IOrganizationService service)
        {
            if (resxSet == null)
            {
                var resource = service.RetrieveMultiple(new QueryExpression("webresource")
                {
                    ColumnSet = new ColumnSet("name", "content"),
                    Criteria = new FilterExpression
                    {
                        Conditions =
                    {
                        new ConditionExpression("name", ConditionOperator.Equal, WebresourceName)
                    }
                    }
                }).Entities.FirstOrDefault();

                if (resource != null)
                {
                    try
                    {
                        resxSet = new ResXResourceSet(new MemoryStream(Convert.FromBase64String(resource.GetAttributeValue<string>("content"))));
                        IsLoaded = true;
                    }
                    catch { }
                }
            }
        }
    }
}