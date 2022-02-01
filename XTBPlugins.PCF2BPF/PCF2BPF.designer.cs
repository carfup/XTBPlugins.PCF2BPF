
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
            this.txbFormXml = new System.Windows.Forms.TextBox();
            this.txbModifiedFormXml = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbControlDescription = new System.Windows.Forms.TextBox();
            this.cbPossiblePCFs = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvPCFParams = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnUpdatePublish = new System.Windows.Forms.Button();
            this.btnTransformFormXml = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbBPFEntitiesList = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLoadEntities = new System.Windows.Forms.Button();
            this.btnApplyChanges = new System.Windows.Forms.Button();
            this.btnAddControl = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPCFParams)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1536, 25);
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
            // txbFormXml
            // 
            this.txbFormXml.Location = new System.Drawing.Point(1211, 45);
            this.txbFormXml.Multiline = true;
            this.txbFormXml.Name = "txbFormXml";
            this.txbFormXml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbFormXml.Size = new System.Drawing.Size(322, 126);
            this.txbFormXml.TabIndex = 7;
            // 
            // txbModifiedFormXml
            // 
            this.txbModifiedFormXml.Location = new System.Drawing.Point(1211, 208);
            this.txbModifiedFormXml.Multiline = true;
            this.txbModifiedFormXml.Name = "txbModifiedFormXml";
            this.txbModifiedFormXml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbModifiedFormXml.Size = new System.Drawing.Size(322, 270);
            this.txbModifiedFormXml.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1208, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Before";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1208, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "After";
            // 
            // tbControlDescription
            // 
            this.tbControlDescription.Location = new System.Drawing.Point(433, 508);
            this.tbControlDescription.Multiline = true;
            this.tbControlDescription.Name = "tbControlDescription";
            this.tbControlDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbControlDescription.Size = new System.Drawing.Size(751, 159);
            this.tbControlDescription.TabIndex = 27;
            // 
            // cbPossiblePCFs
            // 
            this.cbPossiblePCFs.FormattingEnabled = true;
            this.cbPossiblePCFs.Location = new System.Drawing.Point(538, 25);
            this.cbPossiblePCFs.Name = "cbPossiblePCFs";
            this.cbPossiblePCFs.Size = new System.Drawing.Size(203, 21);
            this.cbPossiblePCFs.TabIndex = 28;
            this.cbPossiblePCFs.SelectedIndexChanged += new System.EventHandler(this.cbPossiblePCFs_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(445, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Possible PCF";
            // 
            // dgvPCFParams
            // 
            this.dgvPCFParams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPCFParams.Location = new System.Drawing.Point(433, 66);
            this.dgvPCFParams.Name = "dgvPCFParams";
            this.dgvPCFParams.Size = new System.Drawing.Size(751, 436);
            this.dgvPCFParams.TabIndex = 32;
            this.dgvPCFParams.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPCFParams_CellValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnUpdatePublish);
            this.panel2.Controls.Add(this.btnTransformFormXml);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.cbBPFEntitiesList);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.btnLoadEntities);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(413, 655);
            this.panel2.TabIndex = 34;
            // 
            // btnUpdatePublish
            // 
            this.btnUpdatePublish.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUpdatePublish.Location = new System.Drawing.Point(0, 534);
            this.btnUpdatePublish.Name = "btnUpdatePublish";
            this.btnUpdatePublish.Size = new System.Drawing.Size(413, 32);
            this.btnUpdatePublish.TabIndex = 36;
            this.btnUpdatePublish.Text = "Update and Publish";
            this.btnUpdatePublish.UseVisualStyleBackColor = true;
            this.btnUpdatePublish.Click += new System.EventHandler(this.btnUpdatePublish_Click);
            // 
            // btnTransformFormXml
            // 
            this.btnTransformFormXml.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTransformFormXml.Location = new System.Drawing.Point(0, 504);
            this.btnTransformFormXml.Name = "btnTransformFormXml";
            this.btnTransformFormXml.Size = new System.Drawing.Size(413, 30);
            this.btnTransformFormXml.TabIndex = 35;
            this.btnTransformFormXml.Text = "Integrate PCF";
            this.btnTransformFormXml.UseVisualStyleBackColor = true;
            this.btnTransformFormXml.Click += new System.EventHandler(this.btnTransformFormXml_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 442);
            this.panel1.TabIndex = 34;
            // 
            // cbBPFEntitiesList
            // 
            this.cbBPFEntitiesList.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbBPFEntitiesList.FormattingEnabled = true;
            this.cbBPFEntitiesList.Location = new System.Drawing.Point(0, 41);
            this.cbBPFEntitiesList.Name = "cbBPFEntitiesList";
            this.cbBPFEntitiesList.Size = new System.Drawing.Size(413, 21);
            this.cbBPFEntitiesList.TabIndex = 25;
            this.cbBPFEntitiesList.SelectedIndexChanged += new System.EventHandler(this.cbBPFEntitiesList_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "BPF Entities list";
            // 
            // btnLoadEntities
            // 
            this.btnLoadEntities.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoadEntities.Location = new System.Drawing.Point(0, 0);
            this.btnLoadEntities.Name = "btnLoadEntities";
            this.btnLoadEntities.Size = new System.Drawing.Size(413, 28);
            this.btnLoadEntities.TabIndex = 19;
            this.btnLoadEntities.Text = "Load BPF Entities";
            this.btnLoadEntities.UseVisualStyleBackColor = true;
            this.btnLoadEntities.Click += new System.EventHandler(this.btnLoadEntities_Click);
            // 
            // btnApplyChanges
            // 
            this.btnApplyChanges.Location = new System.Drawing.Point(879, 23);
            this.btnApplyChanges.Name = "btnApplyChanges";
            this.btnApplyChanges.Size = new System.Drawing.Size(107, 23);
            this.btnApplyChanges.TabIndex = 35;
            this.btnApplyChanges.Text = "Apply changes";
            this.btnApplyChanges.UseVisualStyleBackColor = true;
            this.btnApplyChanges.Click += new System.EventHandler(this.btnApplyChanges_Click);
            // 
            // btnAddControl
            // 
            this.btnAddControl.Location = new System.Drawing.Point(766, 23);
            this.btnAddControl.Name = "btnAddControl";
            this.btnAddControl.Size = new System.Drawing.Size(107, 23);
            this.btnAddControl.TabIndex = 36;
            this.btnAddControl.Text = "Add Control";
            this.btnAddControl.UseVisualStyleBackColor = true;
            this.btnAddControl.Click += new System.EventHandler(this.btnAddControl_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1040, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 37;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PCF2BPF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAddControl);
            this.Controls.Add(this.btnApplyChanges);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvPCFParams);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbPossiblePCFs);
            this.Controls.Add(this.tbControlDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbModifiedFormXml);
            this.Controls.Add(this.txbFormXml);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "PCF2BPF";
            this.Size = new System.Drawing.Size(1536, 680);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPCFParams)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.TextBox txbFormXml;
        private System.Windows.Forms.TextBox txbModifiedFormXml;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbControlDescription;
        private System.Windows.Forms.ComboBox cbPossiblePCFs;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvPCFParams;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnUpdatePublish;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbBPFEntitiesList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLoadEntities;
        private System.Windows.Forms.Button btnApplyChanges;
        private System.Windows.Forms.Button btnAddControl;
        private System.Windows.Forms.Button btnTransformFormXml;
        private System.Windows.Forms.Button button1;
    }
}
