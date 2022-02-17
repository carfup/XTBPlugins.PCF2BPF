﻿using System;
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

            if (stageName.StartsWith("Stage"))
            {
                pbWarning.Visible = true;

                var descToolTip = new ToolTip()
                {
                    ToolTipIcon = ToolTipIcon.Warning,
                    IsBalloon = true,
                    ShowAlways = true,
                    ToolTipTitle = "Why do I see this?"
                };
                descToolTip.SetToolTip(pbWarning, "Your BPF definition does not contain title for this stage. Consider updating the PBF definition to force title display");
            }
        }
    }
}