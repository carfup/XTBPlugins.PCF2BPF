namespace Carfup.XTBPlugins.Controls
{
    partial class PcfControlParameter
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblParamName = new System.Windows.Forms.Label();
            this.lblParamUsage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblParamType = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ckbStatic = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.ckbRequired = new System.Windows.Forms.CheckBox();
            this.cbValue = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Param Name";
            // 
            // lblParamName
            // 
            this.lblParamName.AutoSize = true;
            this.lblParamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParamName.Location = new System.Drawing.Point(14, 24);
            this.lblParamName.Name = "lblParamName";
            this.lblParamName.Size = new System.Drawing.Size(78, 13);
            this.lblParamName.TabIndex = 1;
            this.lblParamName.Text = "Param Name";
            // 
            // lblParamUsage
            // 
            this.lblParamUsage.AutoSize = true;
            this.lblParamUsage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParamUsage.Location = new System.Drawing.Point(208, 23);
            this.lblParamUsage.Name = "lblParamUsage";
            this.lblParamUsage.Size = new System.Drawing.Size(78, 13);
            this.lblParamUsage.TabIndex = 3;
            this.lblParamUsage.Text = "Param Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Param Usage";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(305, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Required ?";
            // 
            // lblParamType
            // 
            this.lblParamType.AutoSize = true;
            this.lblParamType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParamType.Location = new System.Drawing.Point(420, 23);
            this.lblParamType.Name = "lblParamType";
            this.lblParamType.Size = new System.Drawing.Size(78, 13);
            this.lblParamType.TabIndex = 9;
            this.lblParamType.Text = "Param Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(420, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Param Type";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(525, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Is Static ?";
            // 
            // ckbStatic
            // 
            this.ckbStatic.AutoSize = true;
            this.ckbStatic.Location = new System.Drawing.Point(528, 24);
            this.ckbStatic.Name = "ckbStatic";
            this.ckbStatic.Size = new System.Drawing.Size(53, 17);
            this.ckbStatic.TabIndex = 11;
            this.ckbStatic.Text = "Static";
            this.ckbStatic.UseVisualStyleBackColor = true;
            this.ckbStatic.CheckedChanged += new System.EventHandler(this.ckbStatic_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(609, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Param Value";
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(612, 20);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(397, 20);
            this.tbValue.TabIndex = 13;
            this.tbValue.TextChanged += new System.EventHandler(this.tbValue_TextChanged);
            // 
            // ckbRequired
            // 
            this.ckbRequired.AutoSize = true;
            this.ckbRequired.Enabled = false;
            this.ckbRequired.Location = new System.Drawing.Point(322, 25);
            this.ckbRequired.Name = "ckbRequired";
            this.ckbRequired.Size = new System.Drawing.Size(15, 14);
            this.ckbRequired.TabIndex = 14;
            this.ckbRequired.UseVisualStyleBackColor = true;
            // 
            // cbValue
            // 
            this.cbValue.FormattingEnabled = true;
            this.cbValue.Location = new System.Drawing.Point(612, 20);
            this.cbValue.Name = "cbValue";
            this.cbValue.Size = new System.Drawing.Size(397, 21);
            this.cbValue.TabIndex = 15;
            this.cbValue.Visible = false;
            this.cbValue.SelectedIndexChanged += new System.EventHandler(this.cbValue_SelectedIndexChanged);
            // 
            // PcfControlParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbValue);
            this.Controls.Add(this.ckbRequired);
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ckbStatic);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblParamType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblParamUsage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblParamName);
            this.Controls.Add(this.label1);
            this.Name = "PcfControlParameter";
            this.Size = new System.Drawing.Size(1037, 54);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblParamName;
        private System.Windows.Forms.Label lblParamUsage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblParamType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox ckbStatic;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.CheckBox ckbRequired;
        private System.Windows.Forms.ComboBox cbValue;
    }
}
