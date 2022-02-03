using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Carfup.XTBPlugins.Controls
{
    public partial class BpfFieldControl : UserControl
    {
        private PCF2BPF.PCF2BPF pcf2bpf;
        public Guid id { get; set; }
        public string name;
        public bool pcfAttached = false;

        public BpfFieldControl(PCF2BPF.PCF2BPF pcf2bpf, string name, string displayName, Guid id, bool pcfAttached)
        {
            InitializeComponent();

            this.pcf2bpf = pcf2bpf;
            this.name = name;
            this.pcfAttached = pcfAttached;



            lblField.Text = displayName ?? name;
            this.id = id;
            showHideButtons();
        }

        public void changePcfAttachedValue(bool pcfAttached = false)
        {
            this.pcfAttached = pcfAttached;
            this.showHideButtons();

        }

        private void pbDelete_Click(object sender, EventArgs e)
        {
            pcf2bpf.setDeletePCFDetails(this.id);
            this.pcfAttached = false;
            this.showHideButtons();
        }

        private void pbModify_Click(object sender, EventArgs e)
        {
            pcf2bpf.setExistingPCFDetails(this.name, this.id);
        }

        public void pbAdd_Click(object sender, EventArgs e)
        {
            pcf2bpf.setAddPcf(this.name, this.id);
            
            showHideButtons();
        }

        public void showHideButtons()
        {
            var fromAnotherEntity = this.name.Contains("(from another entity)");
            this.pbDelete.Visible = this.pcfAttached && !fromAnotherEntity;
            this.pbModify.Visible = this.pcfAttached && !fromAnotherEntity;
            this.pbAdd.Visible = !this.pcfAttached && !fromAnotherEntity;
        }
    }
}
