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
            this.SuspendLayout();
            // 
            // lblStage
            // 
            this.lblStage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStage.ForeColor = System.Drawing.Color.White;
            this.lblStage.Location = new System.Drawing.Point(0, 0);
            this.lblStage.Name = "lblStage";
            this.lblStage.Size = new System.Drawing.Size(506, 45);
            this.lblStage.TabIndex = 1;
            this.lblStage.Text = "label1";
            this.lblStage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BpfStageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblStage);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BpfStageControl";
            this.Size = new System.Drawing.Size(506, 45);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStage;
    }
}
