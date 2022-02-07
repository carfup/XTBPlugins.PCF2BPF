using Microsoft.Xrm.Tooling.Connector;
using System;

namespace Carfup.XTBPlugins.AppCode
{
    public class ControllerManager
    {
        public PCF2BPF.PCF2BPF pcf2bpf;

        public ControllerManager(PCF2BPF.PCF2BPF pcf2bpf)
        {
            this.pcf2bpf = pcf2bpf;
            this.serviceClient = pcf2bpf.ConnectionDetail.ServiceClient;

            this.dataManager = new DataManager(this);
        }

        public DataManager dataManager { get; private set; } = null;
        public CrmServiceClient serviceClient { get; private set; } = null;
    }
}