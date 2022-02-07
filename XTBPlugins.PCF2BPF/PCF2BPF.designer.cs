
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelParams = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddApplyControl = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cbPossiblePCFs = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelStagesFields = new System.Windows.Forms.Panel();
            this.btnUpdatePublish = new System.Windows.Forms.Button();
            this.cbBPFEntitiesList = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLoadEntities = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txbFormXml = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbModifiedFormXml = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCurrentBpfField = new System.Windows.Forms.Label();
            this.toolStripMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(2120, 34);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(129, 29);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 34);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(2120, 1001);
            this.tabControl1.TabIndex = 37;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.panelRight);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(2112, 968);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "PCFs Configuration";
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.Transparent;
            this.panelRight.Controls.Add(this.panelParams);
            this.panelRight.Controls.Add(this.panel4);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(624, 5);
            this.panelRight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(1484, 958);
            this.panelRight.TabIndex = 36;
            this.panelRight.Visible = false;
            // 
            // panelParams
            // 
            this.panelParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelParams.Location = new System.Drawing.Point(0, 97);
            this.panelParams.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelParams.Name = "panelParams";
            this.panelParams.Padding = new System.Windows.Forms.Padding(15, 15, 0, 0);
            this.panelParams.Size = new System.Drawing.Size(1484, 861);
            this.panelParams.TabIndex = 43;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblCurrentBpfField);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.btnAddApplyControl);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.cbPossiblePCFs);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1484, 97);
            this.panel4.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(26, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(693, 20);
            this.label1.TabIndex = 45;
            this.label1.Text = "Tips : If you are not binding your parameter to a field, please consider checking" +
    " the \"Is Static\" box.";
            // 
            // btnAddApplyControl
            // 
            this.btnAddApplyControl.Location = new System.Drawing.Point(770, 9);
            this.btnAddApplyControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddApplyControl.Name = "btnAddApplyControl";
            this.btnAddApplyControl.Size = new System.Drawing.Size(297, 35);
            this.btnAddApplyControl.TabIndex = 44;
            this.btnAddApplyControl.Text = "Add Control / Apply Changes";
            this.btnAddApplyControl.UseVisualStyleBackColor = true;
            this.btnAddApplyControl.Click += new System.EventHandler(this.btnAddApplyControl_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 15);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(183, 20);
            this.label9.TabIndex = 42;
            this.label9.Text = "Select a compatible PCF";
            // 
            // cbPossiblePCFs
            // 
            this.cbPossiblePCFs.FormattingEnabled = true;
            this.cbPossiblePCFs.Location = new System.Drawing.Point(236, 11);
            this.cbPossiblePCFs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbPossiblePCFs.Name = "cbPossiblePCFs";
            this.cbPossiblePCFs.Size = new System.Drawing.Size(504, 28);
            this.cbPossiblePCFs.TabIndex = 41;
            this.cbPossiblePCFs.SelectedIndexChanged += new System.EventHandler(this.cbPossiblePCFs_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelStagesFields);
            this.panel2.Controls.Add(this.btnUpdatePublish);
            this.panel2.Controls.Add(this.cbBPFEntitiesList);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.btnLoadEntities);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(4, 5);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(620, 958);
            this.panel2.TabIndex = 35;
            // 
            // panelStagesFields
            // 
            this.panelStagesFields.AutoScroll = true;
            this.panelStagesFields.BackColor = System.Drawing.Color.White;
            this.panelStagesFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStagesFields.Location = new System.Drawing.Point(0, 148);
            this.panelStagesFields.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelStagesFields.Name = "panelStagesFields";
            this.panelStagesFields.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.panelStagesFields.Size = new System.Drawing.Size(620, 721);
            this.panelStagesFields.TabIndex = 37;
            // 
            // btnUpdatePublish
            // 
            this.btnUpdatePublish.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnUpdatePublish.Location = new System.Drawing.Point(0, 869);
            this.btnUpdatePublish.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUpdatePublish.Name = "btnUpdatePublish";
            this.btnUpdatePublish.Size = new System.Drawing.Size(620, 89);
            this.btnUpdatePublish.TabIndex = 36;
            this.btnUpdatePublish.Text = "Update and Publish";
            this.btnUpdatePublish.UseVisualStyleBackColor = true;
            this.btnUpdatePublish.Click += new System.EventHandler(this.btnUpdatePublish_Click);
            // 
            // cbBPFEntitiesList
            // 
            this.cbBPFEntitiesList.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbBPFEntitiesList.Enabled = false;
            this.cbBPFEntitiesList.FormattingEnabled = true;
            this.cbBPFEntitiesList.Location = new System.Drawing.Point(0, 120);
            this.cbBPFEntitiesList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbBPFEntitiesList.Name = "cbBPFEntitiesList";
            this.cbBPFEntitiesList.Size = new System.Drawing.Size(620, 28);
            this.cbBPFEntitiesList.TabIndex = 25;
            this.cbBPFEntitiesList.SelectedIndexChanged += new System.EventHandler(this.cbBPFEntitiesList_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 89);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.MinimumSize = new System.Drawing.Size(0, 31);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.label7.Size = new System.Drawing.Size(120, 31);
            this.label7.TabIndex = 24;
            this.label7.Text = "BPF Entities list";
            // 
            // btnLoadEntities
            // 
            this.btnLoadEntities.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoadEntities.Location = new System.Drawing.Point(0, 0);
            this.btnLoadEntities.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLoadEntities.Name = "btnLoadEntities";
            this.btnLoadEntities.Size = new System.Drawing.Size(620, 89);
            this.btnLoadEntities.TabIndex = 19;
            this.btnLoadEntities.Text = "Load BPF Entities";
            this.btnLoadEntities.UseVisualStyleBackColor = true;
            this.btnLoadEntities.Click += new System.EventHandler(this.btnLoadEntities_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(2112, 968);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Xml Details";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(4, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txbFormXml);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txbModifiedFormXml);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Size = new System.Drawing.Size(2104, 958);
            this.splitContainer1.SplitterDistance = 967;
            this.splitContainer1.TabIndex = 21;
            // 
            // txbFormXml
            // 
            this.txbFormXml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbFormXml.Location = new System.Drawing.Point(0, 20);
            this.txbFormXml.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbFormXml.Multiline = true;
            this.txbFormXml.Name = "txbFormXml";
            this.txbFormXml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbFormXml.Size = new System.Drawing.Size(967, 938);
            this.txbFormXml.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Before";
            // 
            // txbModifiedFormXml
            // 
            this.txbModifiedFormXml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbModifiedFormXml.Location = new System.Drawing.Point(0, 20);
            this.txbModifiedFormXml.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbModifiedFormXml.Multiline = true;
            this.txbModifiedFormXml.Name = "txbModifiedFormXml";
            this.txbModifiedFormXml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbModifiedFormXml.Size = new System.Drawing.Size(1133, 938);
            this.txbModifiedFormXml.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "After";
            // 
            // lblCurrentBpfField
            // 
            this.lblCurrentBpfField.AutoSize = true;
            this.lblCurrentBpfField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentBpfField.Location = new System.Drawing.Point(1074, 16);
            this.lblCurrentBpfField.Name = "lblCurrentBpfField";
            this.lblCurrentBpfField.Size = new System.Drawing.Size(0, 24);
            this.lblCurrentBpfField.TabIndex = 46;
            // 
            // PCF2BPF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PCF2BPF";
            this.Size = new System.Drawing.Size(2120, 1035);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnUpdatePublish;
        private System.Windows.Forms.ComboBox cbBPFEntitiesList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLoadEntities;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnAddApplyControl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbPossiblePCFs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelParams;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txbFormXml;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbModifiedFormXml;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelStagesFields;
        private System.Windows.Forms.Label lblCurrentBpfField;
    }
}
