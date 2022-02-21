using System;
using System.Drawing;
using System.Windows.Forms;

namespace Carfup.XTBPlugins.Controls
{
    public partial class BpfStageControl : UserControl
    {
        public BpfStageControl(string stageName)
        {
            InitializeComponent();

            BackColor = Color.FromArgb(232, 62, 15);

            lblStage.Text = stageName;
        }

        private void BpfStageControl_Load(object sender, EventArgs e)
        {
            if (lblStage.Text.StartsWith("Stage"))
            {
                pbWarning.Visible = true;

                var descToolTip = new ToolTip()
                {
                    ToolTipIcon = ToolTipIcon.Warning,
                    IsBalloon = true,
                    ShowAlways = true,
                    ToolTipTitle = "Why do I see this?"
                };
                descToolTip.SetToolTip(pbWarning, "Your BPF definition does not contain title for this stage. Consider updating the BPF definition to force title display.");
            }
        }
    }
}