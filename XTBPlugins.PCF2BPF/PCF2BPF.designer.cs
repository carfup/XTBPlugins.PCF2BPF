
namespace Carfup.XTBPlugins.PCF2BPF
{
    partial class PCF2BPF
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSample = new System.Windows.Forms.ToolStripButton();
            this.btnLoadForms = new System.Windows.Forms.Button();
            this.cbFormsList = new System.Windows.Forms.ComboBox();
            this.txbFormXml = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPCFFields = new System.Windows.Forms.ComboBox();
            this.btnLoadBPFForms = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbBFPFormsList = new System.Windows.Forms.ComboBox();
            this.btnTransformFormXml = new System.Windows.Forms.Button();
            this.txbModifiedFormXml = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbEntitiesList = new System.Windows.Forms.ComboBox();
            this.btnLoadEntities = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbBPFEntitiesList = new System.Windows.Forms.ComboBox();
            this.btnUpdatePublish = new System.Windows.Forms.Button();
            this.toolStripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.tsbSample});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1327, 25);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(86, 22);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSample
            // 
            this.tsbSample.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSample.Name = "tsbSample";
            this.tsbSample.Size = new System.Drawing.Size(46, 22);
            this.tsbSample.Text = "Try me";
            this.tsbSample.Click += new System.EventHandler(this.tsbSample_Click);
            // 
            // btnLoadForms
            // 
            this.btnLoadForms.Location = new System.Drawing.Point(17, 171);
            this.btnLoadForms.Name = "btnLoadForms";
            this.btnLoadForms.Size = new System.Drawing.Size(368, 28);
            this.btnLoadForms.TabIndex = 5;
            this.btnLoadForms.Text = "Load forms";
            this.btnLoadForms.UseVisualStyleBackColor = true;
            this.btnLoadForms.Click += new System.EventHandler(this.btnLoadForms_Click);
            // 
            // cbFormsList
            // 
            this.cbFormsList.FormattingEnabled = true;
            this.cbFormsList.Location = new System.Drawing.Point(17, 229);
            this.cbFormsList.Name = "cbFormsList";
            this.cbFormsList.Size = new System.Drawing.Size(368, 21);
            this.cbFormsList.TabIndex = 6;
            this.cbFormsList.SelectedIndexChanged += new System.EventHandler(this.cbFormsList_SelectedIndexChanged);
            // 
            // txbFormXml
            // 
            this.txbFormXml.Location = new System.Drawing.Point(493, 28);
            this.txbFormXml.Multiline = true;
            this.txbFormXml.Name = "txbFormXml";
            this.txbFormXml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbFormXml.Size = new System.Drawing.Size(814, 275);
            this.txbFormXml.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Forms List (with PCF)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "PCF Fields";
            // 
            // cbPCFFields
            // 
            this.cbPCFFields.FormattingEnabled = true;
            this.cbPCFFields.Location = new System.Drawing.Point(17, 282);
            this.cbPCFFields.Name = "cbPCFFields";
            this.cbPCFFields.Size = new System.Drawing.Size(368, 21);
            this.cbPCFFields.TabIndex = 9;
            // 
            // btnLoadBPFForms
            // 
            this.btnLoadBPFForms.Location = new System.Drawing.Point(17, 398);
            this.btnLoadBPFForms.Name = "btnLoadBPFForms";
            this.btnLoadBPFForms.Size = new System.Drawing.Size(368, 28);
            this.btnLoadBPFForms.TabIndex = 11;
            this.btnLoadBPFForms.Text = "Load BPF Forms";
            this.btnLoadBPFForms.UseVisualStyleBackColor = true;
            this.btnLoadBPFForms.Click += new System.EventHandler(this.btnLoadBPFForms_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 431);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "BPF To Modify";
            // 
            // cbBFPFormsList
            // 
            this.cbBFPFormsList.FormattingEnabled = true;
            this.cbBFPFormsList.Location = new System.Drawing.Point(17, 450);
            this.cbBFPFormsList.Name = "cbBFPFormsList";
            this.cbBFPFormsList.Size = new System.Drawing.Size(368, 21);
            this.cbBFPFormsList.TabIndex = 12;
            this.cbBFPFormsList.SelectedIndexChanged += new System.EventHandler(this.cbBFPFormsList_SelectedIndexChanged);
            // 
            // btnTransformFormXml
            // 
            this.btnTransformFormXml.Location = new System.Drawing.Point(17, 491);
            this.btnTransformFormXml.Name = "btnTransformFormXml";
            this.btnTransformFormXml.Size = new System.Drawing.Size(368, 75);
            this.btnTransformFormXml.TabIndex = 14;
            this.btnTransformFormXml.Text = "Integrate PCF";
            this.btnTransformFormXml.UseVisualStyleBackColor = true;
            this.btnTransformFormXml.Click += new System.EventHandler(this.btnTransformFormXml_Click);
            // 
            // txbModifiedFormXml
            // 
            this.txbModifiedFormXml.Location = new System.Drawing.Point(493, 344);
            this.txbModifiedFormXml.Multiline = true;
            this.txbModifiedFormXml.Name = "txbModifiedFormXml";
            this.txbModifiedFormXml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbModifiedFormXml.Size = new System.Drawing.Size(814, 310);
            this.txbModifiedFormXml.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(490, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Before";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(490, 328);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "After";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Entities list";
            // 
            // cbEntitiesList
            // 
            this.cbEntitiesList.FormattingEnabled = true;
            this.cbEntitiesList.Location = new System.Drawing.Point(17, 124);
            this.cbEntitiesList.Name = "cbEntitiesList";
            this.cbEntitiesList.Size = new System.Drawing.Size(368, 21);
            this.cbEntitiesList.TabIndex = 19;
            // 
            // btnLoadEntities
            // 
            this.btnLoadEntities.Location = new System.Drawing.Point(17, 74);
            this.btnLoadEntities.Name = "btnLoadEntities";
            this.btnLoadEntities.Size = new System.Drawing.Size(368, 28);
            this.btnLoadEntities.TabIndex = 18;
            this.btnLoadEntities.Text = "Load Entities";
            this.btnLoadEntities.UseVisualStyleBackColor = true;
            this.btnLoadEntities.Click += new System.EventHandler(this.btnLoadEntities_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 344);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "BPF Entities list";
            // 
            // cbBPFEntitiesList
            // 
            this.cbBPFEntitiesList.FormattingEnabled = true;
            this.cbBPFEntitiesList.Location = new System.Drawing.Point(20, 363);
            this.cbBPFEntitiesList.Name = "cbBPFEntitiesList";
            this.cbBPFEntitiesList.Size = new System.Drawing.Size(368, 21);
            this.cbBPFEntitiesList.TabIndex = 22;
            this.cbBPFEntitiesList.SelectedIndexChanged += new System.EventHandler(this.cbBPFEntitiesList_SelectedIndexChanged);
            // 
            // btnUpdatePublish
            // 
            this.btnUpdatePublish.Location = new System.Drawing.Point(17, 579);
            this.btnUpdatePublish.Name = "btnUpdatePublish";
            this.btnUpdatePublish.Size = new System.Drawing.Size(368, 75);
            this.btnUpdatePublish.TabIndex = 24;
            this.btnUpdatePublish.Text = "Update and Publish";
            this.btnUpdatePublish.UseVisualStyleBackColor = true;
            this.btnUpdatePublish.Click += new System.EventHandler(this.btnUpdatePublish_Click);
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUpdatePublish);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbBPFEntitiesList);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbEntitiesList);
            this.Controls.Add(this.btnLoadEntities);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbModifiedFormXml);
            this.Controls.Add(this.btnTransformFormXml);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbBFPFormsList);
            this.Controls.Add(this.btnLoadBPFForms);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbPCFFields);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbFormXml);
            this.Controls.Add(this.cbFormsList);
            this.Controls.Add(this.btnLoadForms);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(1327, 680);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbSample;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.Button btnLoadForms;
        private System.Windows.Forms.ComboBox cbFormsList;
        private System.Windows.Forms.TextBox txbFormXml;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPCFFields;
        private System.Windows.Forms.Button btnLoadBPFForms;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbBFPFormsList;
        private System.Windows.Forms.Button btnTransformFormXml;
        private System.Windows.Forms.TextBox txbModifiedFormXml;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbEntitiesList;
        private System.Windows.Forms.Button btnLoadEntities;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbBPFEntitiesList;
        private System.Windows.Forms.Button btnUpdatePublish;
    }
}
