namespace Carfup.XTBPlugins.Controls
{
    partial class BpfFieldControl
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
            this.lblField = new System.Windows.Forms.Label();
            this.pbGoField = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbGoField)).BeginInit();
            this.SuspendLayout();
            // 
            // lblField
            // 
            this.lblField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblField.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblField.Location = new System.Drawing.Point(2, 2);
            this.lblField.Name = "lblField";
            this.lblField.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblField.Size = new System.Drawing.Size(542, 31);
            this.lblField.TabIndex = 3;
            this.lblField.Text = "label1";
            this.lblField.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbGoField
            // 
            this.pbGoField.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbGoField.Image = global::Carfup.XTBPlugins.Properties.Resources.right;
            this.pbGoField.Location = new System.Drawing.Point(511, 2);
            this.pbGoField.Name = "pbGoField";
            this.pbGoField.Size = new System.Drawing.Size(33, 31);
            this.pbGoField.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbGoField.TabIndex = 7;
            this.pbGoField.TabStop = false;
            this.pbGoField.Click += new System.EventHandler(this.pbGoField_Click);
            // 
            // BpfFieldControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pbGoField);
            this.Controls.Add(this.lblField);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BpfFieldControl";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(546, 35);
            ((System.ComponentModel.ISupportInitialize)(this.pbGoField)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblField;
        private System.Windows.Forms.PictureBox pbGoField;
    }
}
