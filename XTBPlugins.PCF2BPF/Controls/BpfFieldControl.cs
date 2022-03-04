using Carfup.XTBPlugins.AppCode;
using System;
using System.Windows.Forms;

namespace Carfup.XTBPlugins.Controls
{
    public partial class BpfFieldControl : UserControl
    {
        public string name;

        public BpfFieldControl(string name)
        {
            InitializeComponent();

            this.name = name;
            lblField.Text = name;
        }

        public event EventHandler<BpfFieldControlActionEventArgs> OnActionRequested;

        private void pbGoField_Click(object sender, EventArgs e)
        {
            OnActionRequested?.Invoke(this, new BpfFieldControlActionEventArgs(BpfFieldControlAction.Go));
        }
    }
}