namespace Carfup.XTBPlugins.Controls
{
    partial class BpfStageControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblStage = new System.Windows.Forms.Label();
            this.pbWarning = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarning)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStage
            // 
            this.lblStage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStage.ForeColor = System.Drawing.Color.White;
            this.lblStage.Location = new System.Drawing.Point(0, 0);
            this.lblStage.Name = "lblStage";
            this.lblStage.Size = new System.Drawing.Size(426, 44);
            this.lblStage.TabIndex = 4;
            this.lblStage.Text = "label1";
            this.lblStage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbWarning
            // 
            this.pbWarning.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbWarning.Image = global::Carfup.XTBPlugins.Properties.Resources.warning;
            this.pbWarning.Location = new System.Drawing.Point(438, 0);
            this.pbWarning.Name = "pbWarning";
            this.pbWarning.Size = new System.Drawing.Size(44, 44);
            this.pbWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbWarning.TabIndex = 2;
            this.pbWarning.TabStop = false;
            this.pbWarning.Visible = false;
            // 
            // BpfStageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblStage);
            this.Controls.Add(this.pbWarning);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BpfStageControl";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.Size = new System.Drawing.Size(421, 37);
            ((System.ComponentModel.ISupportInitialize)(this.pbWarning)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbWarning;
        private System.Windows.Forms.Label lblStage;
    }
}
