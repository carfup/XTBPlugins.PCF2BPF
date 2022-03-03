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

        public Guid id { get; set; }

        public void pbAdd_Click(object sender, EventArgs e)
        {
            //OnActionRequested?.Invoke(this, new BpfFieldControlActionEventArgs(BpfFieldControlAction.Add));
            //showHideButtons();
        }

        public void showHideButtons()
        {
            pbDelete.Visible = ((FormAttribute)Tag).UniqueId != Guid.Empty;
            pbModify.Visible = ((FormAttribute)Tag).UniqueId != Guid.Empty;
            pbAdd.Visible = ((FormAttribute)Tag).UniqueId == Guid.Empty;
        }

        private void BpfFieldControl_Load(object sender, EventArgs e)
        {
            //showHideButtons();
        }

        private void pbDelete_Click(object sender, EventArgs e)
        {
            //OnActionRequested?.Invoke(this, new BpfFieldControlActionEventArgs(BpfFieldControlAction.Remove));
        }

        private void pbModify_Click(object sender, EventArgs e)
        {
            //OnActionRequested?.Invoke(this, new BpfFieldControlActionEventArgs(BpfFieldControlAction.Edit));
        }

        private void pbGoField_Click(object sender, EventArgs e)
        {
            OnActionRequested?.Invoke(this, new BpfFieldControlActionEventArgs(BpfFieldControlAction.Go));
        }
    }
}