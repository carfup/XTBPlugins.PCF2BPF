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
    }
}