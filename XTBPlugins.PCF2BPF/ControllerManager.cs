using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carfup.XTBPlugins.AppCode
{
    public class ControllerManager
    {
        public CrmServiceClient serviceClient { get; private set; } = null;
        public DataManager dataManager { get; private set; } = null;
        public XmlManager xmlManager { get; private set; } = null;

        public ControllerManager(CrmServiceClient service)
        {
            this.serviceClient = service;
            
            this.dataManager = new DataManager(this);
            this.xmlManager = new XmlManager(this);
        }
    }
}
