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
    public partial class BpfStageControl : UserControl
    {
        public BpfStageControl(string stageName)
        {
            InitializeComponent();

            lblStage.Text = stageName;
        }
    }
}
