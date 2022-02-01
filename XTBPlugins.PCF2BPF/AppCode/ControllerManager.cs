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

        public PCF2BPF.PCF2BPF pcf2bpf;

        public ControllerManager(PCF2BPF.PCF2BPF pcf2bpf)
        {
            this.pcf2bpf = pcf2bpf;
            this.serviceClient = pcf2bpf.ConnectionDetail.ServiceClient;
            
            this.dataManager = new DataManager(this);
            this.xmlManager = new XmlManager(this, pcf2bpf);
        }
    }
}
