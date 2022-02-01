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
        public Guid? id { get; set; }
        public string name;

        public BpfFieldControl(PCF2BPF.PCF2BPF pcf2bpf, string name, Guid? id)
        {
            InitializeComponent();

            this.pcf2bpf = pcf2bpf;
            this.name = name;
            

            //lblField.Text = setLabel();
            this.id = id;
            showHideButtons();
        }

      
        private void setLabel()
        {
            lblField.Text = $"{this.name}({this.id}) - a:{this.pbAdd.Visible} / m:{this.pbModify.Visible} / d:{this.pbDelete.Visible}";
        }

        public void changeIdValue(Guid? id = null)
        {
            this.id = id;
            this.showHideButtons();

        }

        private void pbDelete_Click(object sender, EventArgs e)
        {
            pcf2bpf.setDeletePCFDetails(this.id.Value);
            this.id = null;
            this.showHideButtons();
        }

        private void pbModify_Click(object sender, EventArgs e)
        {
            pcf2bpf.setExistingPCFDetails(this.name, this.id.Value);
            //showHideButtons();
        }

        public void pbAdd_Click(object sender, EventArgs e)
        {
            pcf2bpf.setPossiblePCf(this.name);
            
            showHideButtons();
        }

        public void showHideButtons()
        {
            this.pbDelete.Visible = this.id.HasValue;
            this.pbModify.Visible = this.id.HasValue;
            this.pbAdd.Visible = !this.id.HasValue;
           
            setLabel();
        }
    }
}
