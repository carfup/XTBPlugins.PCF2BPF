using Carfup.XTBPlugins.AppCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carfup.XTBPlugins.Controls
{
    public partial class FormFactorControl : UserControl
    {
        public event EventHandler<FormFactorActionEventArgs> OnActionRequested;
        private FormAttribute _attribute;
        public FormFactorControl(FormAttribute attribute)
        {
            InitializeComponent();
            _attribute = attribute;
        }

        private void pbDeleteWeb_Click(object sender, EventArgs e)
        {
            OnActionRequested?.Invoke(this, new FormFactorActionEventArgs(FormFactorAction.Remove, FormFactor.Web));
        }

        private void pbModifyWeb_Click(object sender, EventArgs e)
        {
            OnActionRequested?.Invoke(this, new FormFactorActionEventArgs(FormFactorAction.Edit, FormFactor.Web));
        }

        private void pbAddWeb_Click(object sender, EventArgs e)
        {
            OnActionRequested?.Invoke(this, new FormFactorActionEventArgs(FormFactorAction.Add, FormFactor.Web));
        }

        private void pbDeleteTablet_Click(object sender, EventArgs e)
        {
            OnActionRequested?.Invoke(this, new FormFactorActionEventArgs(FormFactorAction.Remove, FormFactor.Tablet));
        }

        private void pbModifyTablet_Click(object sender, EventArgs e)
        {
            OnActionRequested?.Invoke(this, new FormFactorActionEventArgs(FormFactorAction.Edit, FormFactor.Tablet));
        }

        private void pbAddTablet_Click(object sender, EventArgs e)
        {
            OnActionRequested?.Invoke(this, new FormFactorActionEventArgs(FormFactorAction.Add, FormFactor.Tablet));
        }

        private void FormFactorControl_Load(object sender, EventArgs e)
        {
            showHideButtons();
        }

        public void showHideButtons()
        {
            pbDeleteWeb.Visible = this._attribute.PcfConfiguration[2]?.Name != null;
            pbModifyWeb.Visible = this._attribute.PcfConfiguration[2]?.Name != null;
            pbAddWeb.Visible = this._attribute.PcfConfiguration[2]?.Name == null;

            pbDeleteTablet.Visible = this._attribute.PcfConfiguration[1]?.Name != null;
            pbModifyTablet.Visible = this._attribute.PcfConfiguration[1]?.Name != null;
            pbAddTablet.Visible = this._attribute.PcfConfiguration[1]?.Name == null;

            pbDeletePhone.Visible = this._attribute.PcfConfiguration[0]?.Name != null;
            pbModifyPhone.Visible = this._attribute.PcfConfiguration[0]?.Name != null;
            pbAddPhone.Visible = this._attribute.PcfConfiguration[0]?.Name == null;
        }

        private void pbDeletePhone_Click(object sender, EventArgs e)
        {
            OnActionRequested?.Invoke(this, new FormFactorActionEventArgs(FormFactorAction.Remove, FormFactor.Phone));
        }

        private void pbModifyPhone_Click(object sender, EventArgs e)
        {
            OnActionRequested?.Invoke(this, new FormFactorActionEventArgs(FormFactorAction.Edit, FormFactor.Phone));
        }

        private void pbAddPhone_Click(object sender, EventArgs e)
        {
            OnActionRequested?.Invoke(this, new FormFactorActionEventArgs(FormFactorAction.Add, FormFactor.Phone));
        }
    }
}
