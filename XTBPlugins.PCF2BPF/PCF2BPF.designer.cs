
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
            this.btnUpdatePublish = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbBPFEntitiesList = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLoadEntities = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.txbModifiedFormXml = new System.Windows.Forms.TextBox();
            this.txbFormXml = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStripMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1536, 655);
            this.tabControl1.TabIndex = 37;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.panelRight);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1528, 629);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "PCFs Configuration";
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.Transparent;
            this.panelRight.Controls.Add(this.panelParams);
            this.panelRight.Controls.Add(this.panel4);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(416, 3);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(1109, 623);
            this.panelRight.TabIndex = 36;
            this.panelRight.Visible = false;
            // 
            // panelParams
            // 
            this.panelParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelParams.Location = new System.Drawing.Point(0, 63);
            this.panelParams.Name = "panelParams";
            this.panelParams.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.panelParams.Size = new System.Drawing.Size(1109, 560);
            this.panelParams.TabIndex = 43;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.btnAddApplyControl);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.cbPossiblePCFs);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1109, 63);
            this.panel4.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(17, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(470, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Tips : If you are not binding your parameter to a field, please consider checking" +
    " the \"Is Static\" box.";
            // 
            // btnAddApplyControl
            // 
            this.btnAddApplyControl.Location = new System.Drawing.Point(513, 6);
            this.btnAddApplyControl.Name = "btnAddApplyControl";
            this.btnAddApplyControl.Size = new System.Drawing.Size(198, 23);
            this.btnAddApplyControl.TabIndex = 44;
            this.btnAddApplyControl.Text = "Add Control / Apply Changes";
            this.btnAddApplyControl.UseVisualStyleBackColor = true;
            this.btnAddApplyControl.Click += new System.EventHandler(this.btnAddApplyControl_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Select a compatible PCF";
            // 
            // cbPossiblePCFs
            // 
            this.cbPossiblePCFs.FormattingEnabled = true;
            this.cbPossiblePCFs.Location = new System.Drawing.Point(157, 7);
            this.cbPossiblePCFs.Name = "cbPossiblePCFs";
            this.cbPossiblePCFs.Size = new System.Drawing.Size(337, 21);
            this.cbPossiblePCFs.TabIndex = 41;
            this.cbPossiblePCFs.SelectedIndexChanged += new System.EventHandler(this.cbPossiblePCFs_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnUpdatePublish);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.cbBPFEntitiesList);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.btnLoadEntities);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(413, 623);
            this.panel2.TabIndex = 35;
            // 
            // btnUpdatePublish
            // 
            this.btnUpdatePublish.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnUpdatePublish.Location = new System.Drawing.Point(0, 565);
            this.btnUpdatePublish.Name = "btnUpdatePublish";
            this.btnUpdatePublish.Size = new System.Drawing.Size(413, 58);
            this.btnUpdatePublish.TabIndex = 36;
            this.btnUpdatePublish.Text = "Update and Publish";
            this.btnUpdatePublish.UseVisualStyleBackColor = true;
            this.btnUpdatePublish.Click += new System.EventHandler(this.btnUpdatePublish_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 69);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel1.Size = new System.Drawing.Size(413, 554);
            this.panel1.TabIndex = 34;
            // 
            // cbBPFEntitiesList
            // 
            this.cbBPFEntitiesList.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbBPFEntitiesList.Enabled = false;
            this.cbBPFEntitiesList.FormattingEnabled = true;
            this.cbBPFEntitiesList.Location = new System.Drawing.Point(0, 48);
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
            this.label7.MinimumSize = new System.Drawing.Size(0, 20);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label7.Size = new System.Drawing.Size(79, 20);
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
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txbModifiedFormXml);
            this.tabPage2.Controls.Add(this.txbFormXml);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1528, 629);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Xml Details";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label5.Location = new System.Drawing.Point(3, 424);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "After";
            // 
            // txbModifiedFormXml
            // 
            this.txbModifiedFormXml.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txbModifiedFormXml.Location = new System.Drawing.Point(3, 437);
            this.txbModifiedFormXml.Multiline = true;
            this.txbModifiedFormXml.Name = "txbModifiedFormXml";
            this.txbModifiedFormXml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbModifiedFormXml.Size = new System.Drawing.Size(1522, 189);
            this.txbModifiedFormXml.TabIndex = 19;
            // 
            // txbFormXml
            // 
            this.txbFormXml.Dock = System.Windows.Forms.DockStyle.Top;
            this.txbFormXml.Location = new System.Drawing.Point(3, 16);
            this.txbFormXml.Multiline = true;
            this.txbFormXml.Name = "txbFormXml";
            this.txbFormXml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbFormXml.Size = new System.Drawing.Size(1522, 214);
            this.txbFormXml.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Before";
            // 
            // PCF2BPF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "PCF2BPF";
            this.Size = new System.Drawing.Size(1536, 680);
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
            this.tabPage2.PerformLayout();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbBPFEntitiesList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLoadEntities;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbModifiedFormXml;
        private System.Windows.Forms.TextBox txbFormXml;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnAddApplyControl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbPossiblePCFs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelParams;
    }
}
