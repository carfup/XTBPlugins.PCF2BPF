
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
            this.cbFieldToAttach = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbControlDescription = new System.Windows.Forms.TextBox();
            this.cbPossiblePCFs = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
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
            this.btnLoadForms.Location = new System.Drawing.Point(0, 28);
            this.btnLoadForms.Name = "btnLoadForms";
            this.btnLoadForms.Size = new System.Drawing.Size(216, 28);
            this.btnLoadForms.TabIndex = 5;
            this.btnLoadForms.Text = "Load forms";
            this.btnLoadForms.UseVisualStyleBackColor = true;
            this.btnLoadForms.Click += new System.EventHandler(this.btnLoadForms_Click);
            // 
            // cbFormsList
            // 
            this.cbFormsList.FormattingEnabled = true;
            this.cbFormsList.Location = new System.Drawing.Point(222, 44);
            this.cbFormsList.Name = "cbFormsList";
            this.cbFormsList.Size = new System.Drawing.Size(216, 21);
            this.cbFormsList.TabIndex = 6;
            this.cbFormsList.SelectedIndexChanged += new System.EventHandler(this.cbFormsList_SelectedIndexChanged);
            // 
            // txbFormXml
            // 
            this.txbFormXml.Location = new System.Drawing.Point(543, 28);
            this.txbFormXml.Multiline = true;
            this.txbFormXml.Name = "txbFormXml";
            this.txbFormXml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbFormXml.Size = new System.Drawing.Size(764, 275);
            this.txbFormXml.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Forms List (with PCF)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "PCF Fields";
            // 
            // cbPCFFields
            // 
            this.cbPCFFields.FormattingEnabled = true;
            this.cbPCFFields.Location = new System.Drawing.Point(87, 71);
            this.cbPCFFields.Name = "cbPCFFields";
            this.cbPCFFields.Size = new System.Drawing.Size(287, 21);
            this.cbPCFFields.TabIndex = 9;
            // 
            // btnLoadBPFForms
            // 
            this.btnLoadBPFForms.Location = new System.Drawing.Point(6, 230);
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
            this.label3.Location = new System.Drawing.Point(6, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "BPF To Modify";
            // 
            // cbBFPFormsList
            // 
            this.cbBFPFormsList.FormattingEnabled = true;
            this.cbBFPFormsList.Location = new System.Drawing.Point(6, 282);
            this.cbBFPFormsList.Name = "cbBFPFormsList";
            this.cbBFPFormsList.Size = new System.Drawing.Size(368, 21);
            this.cbBFPFormsList.TabIndex = 12;
            this.cbBFPFormsList.SelectedIndexChanged += new System.EventHandler(this.cbBFPFormsList_SelectedIndexChanged);
            // 
            // btnTransformFormXml
            // 
            this.btnTransformFormXml.Location = new System.Drawing.Point(17, 586);
            this.btnTransformFormXml.Name = "btnTransformFormXml";
            this.btnTransformFormXml.Size = new System.Drawing.Size(368, 30);
            this.btnTransformFormXml.TabIndex = 14;
            this.btnTransformFormXml.Text = "Integrate PCF";
            this.btnTransformFormXml.UseVisualStyleBackColor = true;
            this.btnTransformFormXml.Click += new System.EventHandler(this.btnTransformFormXml_Click);
            // 
            // txbModifiedFormXml
            // 
            this.txbModifiedFormXml.Location = new System.Drawing.Point(543, 344);
            this.txbModifiedFormXml.Multiline = true;
            this.txbModifiedFormXml.Name = "txbModifiedFormXml";
            this.txbModifiedFormXml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbModifiedFormXml.Size = new System.Drawing.Size(764, 310);
            this.txbModifiedFormXml.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(540, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Before";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(540, 316);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "After";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Entities list";
            // 
            // cbEntitiesList
            // 
            this.cbEntitiesList.FormattingEnabled = true;
            this.cbEntitiesList.Location = new System.Drawing.Point(107, 98);
            this.cbEntitiesList.Name = "cbEntitiesList";
            this.cbEntitiesList.Size = new System.Drawing.Size(191, 21);
            this.cbEntitiesList.TabIndex = 19;
            this.cbEntitiesList.SelectedIndexChanged += new System.EventHandler(this.cbEntitiesList_SelectedIndexChanged);
            // 
            // btnLoadEntities
            // 
            this.btnLoadEntities.Location = new System.Drawing.Point(6, 152);
            this.btnLoadEntities.Name = "btnLoadEntities";
            this.btnLoadEntities.Size = new System.Drawing.Size(371, 28);
            this.btnLoadEntities.TabIndex = 18;
            this.btnLoadEntities.Text = "Load BPF Entities";
            this.btnLoadEntities.UseVisualStyleBackColor = true;
            this.btnLoadEntities.Click += new System.EventHandler(this.btnLoadEntities_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "BPF Entities list";
            // 
            // cbBPFEntitiesList
            // 
            this.cbBPFEntitiesList.FormattingEnabled = true;
            this.cbBPFEntitiesList.Location = new System.Drawing.Point(9, 202);
            this.cbBPFEntitiesList.Name = "cbBPFEntitiesList";
            this.cbBPFEntitiesList.Size = new System.Drawing.Size(365, 21);
            this.cbBPFEntitiesList.TabIndex = 22;
            this.cbBPFEntitiesList.SelectedIndexChanged += new System.EventHandler(this.cbBPFEntitiesList_SelectedIndexChanged);
            // 
            // btnUpdatePublish
            // 
            this.btnUpdatePublish.Location = new System.Drawing.Point(17, 622);
            this.btnUpdatePublish.Name = "btnUpdatePublish";
            this.btnUpdatePublish.Size = new System.Drawing.Size(368, 32);
            this.btnUpdatePublish.TabIndex = 24;
            this.btnUpdatePublish.Text = "Update and Publish";
            this.btnUpdatePublish.UseVisualStyleBackColor = true;
            this.btnUpdatePublish.Click += new System.EventHandler(this.btnUpdatePublish_Click);
            // 
            // cbFieldToAttach
            // 
            this.cbFieldToAttach.FormattingEnabled = true;
            this.cbFieldToAttach.Location = new System.Drawing.Point(6, 332);
            this.cbFieldToAttach.Name = "cbFieldToAttach";
            this.cbFieldToAttach.Size = new System.Drawing.Size(233, 21);
            this.cbFieldToAttach.TabIndex = 25;
            this.cbFieldToAttach.SelectedIndexChanged += new System.EventHandler(this.cbFieldToAttach_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 316);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Field To attach the PCF to";
            // 
            // tbControlDescription
            // 
            this.tbControlDescription.Location = new System.Drawing.Point(6, 359);
            this.tbControlDescription.Multiline = true;
            this.tbControlDescription.Name = "tbControlDescription";
            this.tbControlDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbControlDescription.Size = new System.Drawing.Size(451, 221);
            this.tbControlDescription.TabIndex = 27;
            // 
            // cbPossiblePCFs
            // 
            this.cbPossiblePCFs.FormattingEnabled = true;
            this.cbPossiblePCFs.Location = new System.Drawing.Point(254, 332);
            this.cbPossiblePCFs.Name = "cbPossiblePCFs";
            this.cbPossiblePCFs.Size = new System.Drawing.Size(203, 21);
            this.cbPossiblePCFs.TabIndex = 28;
            this.cbPossiblePCFs.SelectedIndexChanged += new System.EventHandler(this.cbPossiblePCFs_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(254, 316);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Possible PCF";
            // 
            // PCF2BPF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbPossiblePCFs);
            this.Controls.Add(this.tbControlDescription);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbFieldToAttach);
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
            this.Name = "PCF2BPF";
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
        private System.Windows.Forms.ComboBox cbFieldToAttach;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbControlDescription;
        private System.Windows.Forms.ComboBox cbPossiblePCFs;
        private System.Windows.Forms.Label label9;
    }
}
