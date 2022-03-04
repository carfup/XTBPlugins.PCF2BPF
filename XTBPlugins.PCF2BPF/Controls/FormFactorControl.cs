using Carfup.XTBPlugins.AppCode;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Carfup.XTBPlugins.Controls
{
    public partial class FormFactorControl : UserControl
    {
        private FormAttribute _attribute;

        public FormFactorControl(FormAttribute attribute)
        {
            InitializeComponent();
            _attribute = attribute;
        }

        public event EventHandler<FormFactorActionEventArgs> OnActionRequested;

        public void showHideButtons()
        {
            pbDeleteWeb.Visible = this._attribute.PcfConfiguration?[2]?.Name != null;
            pbModifyWeb.Visible = this._attribute.PcfConfiguration?[2]?.Name != null;
            pbAddWeb.Visible = this._attribute.PcfConfiguration?[2]?.Name == null;

            pbDeleteTablet.Visible = this._attribute.PcfConfiguration?[1]?.Name != null;
            pbModifyTablet.Visible = this._attribute.PcfConfiguration?[1]?.Name != null;
            pbAddTablet.Visible = this._attribute.PcfConfiguration?[1]?.Name == null;

            pbDeletePhone.Visible = this._attribute.PcfConfiguration?[0]?.Name != null;
            pbModifyPhone.Visible = this._attribute.PcfConfiguration?[0]?.Name != null;
            pbAddPhone.Visible = this._attribute.PcfConfiguration?[0]?.Name == null;
        }

        private void FormFactorControl_Load(object sender, EventArgs e)
        {
            showHideButtons();
        }

        private void pbAddPhone_Click(object sender, EventArgs e)
        {
            setBackColor(FormFactor.Phone);
            OnActionRequested?.Invoke(this, new FormFactorActionEventArgs(FormFactorAction.Add, FormFactor.Phone));
        }

        private void pbAddTablet_Click(object sender, EventArgs e)
        {
            setBackColor(FormFactor.Tablet);
            OnActionRequested?.Invoke(this, new FormFactorActionEventArgs(FormFactorAction.Add, FormFactor.Tablet));
        }

        private void pbAddWeb_Click(object sender, EventArgs e)
        {
            setBackColor(FormFactor.Web);
            OnActionRequested?.Invoke(this, new FormFactorActionEventArgs(FormFactorAction.Add, FormFactor.Web));
        }

        private void pbDeletePhone_Click(object sender, EventArgs e)
        {
            setBackColor(FormFactor.Phone);
            OnActionRequested?.Invoke(this, new FormFactorActionEventArgs(FormFactorAction.Remove, FormFactor.Phone));
        }

        private void pbDeleteTablet_Click(object sender, EventArgs e)
        {
            setBackColor(FormFactor.Tablet);
            OnActionRequested?.Invoke(this, new FormFactorActionEventArgs(FormFactorAction.Remove, FormFactor.Tablet));
        }

        private void pbDeleteWeb_Click(object sender, EventArgs e)
        {
            setBackColor(FormFactor.Web);
            OnActionRequested?.Invoke(this, new FormFactorActionEventArgs(FormFactorAction.Remove, FormFactor.Web));
        }

        private void pbModifyPhone_Click(object sender, EventArgs e)
        {
            setBackColor(FormFactor.Phone);
            OnActionRequested?.Invoke(this, new FormFactorActionEventArgs(FormFactorAction.Edit, FormFactor.Phone));
        }

        private void pbModifyTablet_Click(object sender, EventArgs e)
        {
            setBackColor(FormFactor.Tablet);
            OnActionRequested?.Invoke(this, new FormFactorActionEventArgs(FormFactorAction.Edit, FormFactor.Tablet));
        }

        private void pbModifyWeb_Click(object sender, EventArgs e)
        {
            setBackColor(FormFactor.Web);
            OnActionRequested?.Invoke(this, new FormFactorActionEventArgs(FormFactorAction.Edit, FormFactor.Web));
        }

        private void setBackColor(FormFactor formFactor)
        {
            panelPhone.BackColor = Color.Transparent;
            panelTablet.BackColor = Color.Transparent;
            panelWeb.BackColor = Color.Transparent;

            switch (formFactor)
            {
                case FormFactor.Phone:
                    panelPhone.BackColor = Color.FromArgb(226, 226, 226);
                    break;

                case FormFactor.Tablet:
                    panelTablet.BackColor = Color.FromArgb(226, 226, 226);
                    break;

                case FormFactor.Web:
                    panelWeb.BackColor = Color.FromArgb(226, 226, 226);
                    break;
            }
        }
    }
}