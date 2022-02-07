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
            this.pbAdd = new System.Windows.Forms.PictureBox();
            this.lblField = new System.Windows.Forms.Label();
            this.pbModify = new System.Windows.Forms.PictureBox();
            this.pbDelete = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbModify)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // pbAdd
            // 
            this.pbAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbAdd.Image = global::Carfup.XTBPlugins.Properties.Resources.add;
            this.pbAdd.Location = new System.Drawing.Point(768, 3);
            this.pbAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbAdd.Name = "pbAdd";
            this.pbAdd.Size = new System.Drawing.Size(48, 48);
            this.pbAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbAdd.TabIndex = 2;
            this.pbAdd.TabStop = false;
            this.pbAdd.Click += new System.EventHandler(this.pbAdd_Click);
            // 
            // lblField
            // 
            this.lblField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblField.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblField.Location = new System.Drawing.Point(3, 3);
            this.lblField.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblField.Name = "lblField";
            this.lblField.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.lblField.Size = new System.Drawing.Size(765, 48);
            this.lblField.TabIndex = 3;
            this.lblField.Text = "label1";
            this.lblField.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbModify
            // 
            this.pbModify.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbModify.Image = global::Carfup.XTBPlugins.Properties.Resources.pencil;
            this.pbModify.Location = new System.Drawing.Point(718, 3);
            this.pbModify.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbModify.Name = "pbModify";
            this.pbModify.Size = new System.Drawing.Size(50, 48);
            this.pbModify.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbModify.TabIndex = 5;
            this.pbModify.TabStop = false;
            this.pbModify.Click += new System.EventHandler(this.pbModify_Click);
            // 
            // pbDelete
            // 
            this.pbDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbDelete.Image = global::Carfup.XTBPlugins.Properties.Resources.delete;
            this.pbDelete.Location = new System.Drawing.Point(668, 3);
            this.pbDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbDelete.Name = "pbDelete";
            this.pbDelete.Size = new System.Drawing.Size(50, 48);
            this.pbDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbDelete.TabIndex = 6;
            this.pbDelete.TabStop = false;
            this.pbDelete.Click += new System.EventHandler(this.pbDelete_Click);
            // 
            // BpfFieldControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pbDelete);
            this.Controls.Add(this.pbModify);
            this.Controls.Add(this.lblField);
            this.Controls.Add(this.pbAdd);
            this.Name = "BpfFieldControl";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(819, 54);
            this.Load += new System.EventHandler(this.BpfFieldControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbModify)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDelete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbAdd;
        private System.Windows.Forms.Label lblField;
        private System.Windows.Forms.PictureBox pbModify;
        private System.Windows.Forms.PictureBox pbDelete;
    }
}
