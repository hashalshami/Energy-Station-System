namespace EnergyStationSystem
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.masterPanel = new System.Windows.Forms.Panel();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.دليلالمشتركينToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Fines_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Services_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Contracts_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Blocks_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CentralMeter_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Collectors_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SystemConfig_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Regions_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SubscriptionTypes_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnergySystemMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.kryptonPalette1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.masterPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // masterPanel
            // 
            this.masterPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.masterPanel.Controls.Add(this.panelContainer);
            this.masterPanel.Controls.Add(this.topPanel);
            this.masterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.masterPanel.Location = new System.Drawing.Point(0, 24);
            this.masterPanel.Name = "masterPanel";
            this.masterPanel.Size = new System.Drawing.Size(1244, 567);
            this.masterPanel.TabIndex = 7;
            // 
            // panelContainer
            // 
            this.panelContainer.AutoSize = true;
            this.panelContainer.BackColor = System.Drawing.Color.Silver;
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 42);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.panelContainer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelContainer.Size = new System.Drawing.Size(1244, 525);
            this.panelContainer.TabIndex = 2;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.White;
            this.topPanel.Controls.Add(this.panel1);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.topPanel.Size = new System.Drawing.Size(1244, 42);
            this.topPanel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.titleLabel);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 2);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(1234, 38);
            this.panel1.TabIndex = 0;
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.White;
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(100, 0);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(3);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(1032, 36);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "محطة الكهرباء";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1132, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // دليلالمشتركينToolStripMenuItem
            // 
            this.دليلالمشتركينToolStripMenuItem.Name = "دليلالمشتركينToolStripMenuItem";
            this.دليلالمشتركينToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.دليلالمشتركينToolStripMenuItem.Text = "دليل المشتركين";
            // 
            // Fines_MenuItem
            // 
            this.Fines_MenuItem.Name = "Fines_MenuItem";
            this.Fines_MenuItem.Size = new System.Drawing.Size(185, 22);
            this.Fines_MenuItem.Text = "دليل الغرامات";
            this.Fines_MenuItem.Click += new System.EventHandler(this.Fines_MenuItem_Click);
            // 
            // Services_MenuItem
            // 
            this.Services_MenuItem.Name = "Services_MenuItem";
            this.Services_MenuItem.Size = new System.Drawing.Size(185, 22);
            this.Services_MenuItem.Text = "دليل الخدمات";
            this.Services_MenuItem.Click += new System.EventHandler(this.Services_MenuItem_Click);
            // 
            // Contracts_MenuItem
            // 
            this.Contracts_MenuItem.Name = "Contracts_MenuItem";
            this.Contracts_MenuItem.Size = new System.Drawing.Size(185, 22);
            this.Contracts_MenuItem.Text = "دليل نماذج العقود";
            this.Contracts_MenuItem.Click += new System.EventHandler(this.Contracts_MenuItem_Click);
            // 
            // Blocks_MenuItem
            // 
            this.Blocks_MenuItem.Name = "Blocks_MenuItem";
            this.Blocks_MenuItem.Size = new System.Drawing.Size(185, 22);
            this.Blocks_MenuItem.Text = "دليل المربعات";
            this.Blocks_MenuItem.Click += new System.EventHandler(this.Blocks_MenuItem_Click);
            // 
            // CentralMeter_MenuItem
            // 
            this.CentralMeter_MenuItem.Name = "CentralMeter_MenuItem";
            this.CentralMeter_MenuItem.Size = new System.Drawing.Size(185, 22);
            this.CentralMeter_MenuItem.Text = "دليل العدادات المركزية";
            this.CentralMeter_MenuItem.Click += new System.EventHandler(this.CentralMeter_MenuItem_Click);
            // 
            // Collectors_MenuItem
            // 
            this.Collectors_MenuItem.Name = "Collectors_MenuItem";
            this.Collectors_MenuItem.Size = new System.Drawing.Size(185, 22);
            this.Collectors_MenuItem.Text = "دليل المحصلين";
            this.Collectors_MenuItem.Click += new System.EventHandler(this.Collectors_MenuItem_Click);
            // 
            // SystemConfig_MenuItem
            // 
            this.SystemConfig_MenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SystemConfig_MenuItem.AutoSize = false;
            this.SystemConfig_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Collectors_MenuItem,
            this.CentralMeter_MenuItem,
            this.Regions_MenuItem,
            this.Blocks_MenuItem,
            this.SubscriptionTypes_MenuItem,
            this.Contracts_MenuItem,
            this.Services_MenuItem,
            this.Fines_MenuItem});
            this.SystemConfig_MenuItem.Name = "SystemConfig_MenuItem";
            this.SystemConfig_MenuItem.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.SystemConfig_MenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.SystemConfig_MenuItem.Size = new System.Drawing.Size(152, 20);
            this.SystemConfig_MenuItem.Text = "تهيئة النظام";
            this.SystemConfig_MenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // Regions_MenuItem
            // 
            this.Regions_MenuItem.Name = "Regions_MenuItem";
            this.Regions_MenuItem.Size = new System.Drawing.Size(185, 22);
            this.Regions_MenuItem.Text = "دليل المناطق";
            this.Regions_MenuItem.Click += new System.EventHandler(this.Regions_MenuItem_Click);
            // 
            // SubscriptionTypes_MenuItem
            // 
            this.SubscriptionTypes_MenuItem.Name = "SubscriptionTypes_MenuItem";
            this.SubscriptionTypes_MenuItem.Size = new System.Drawing.Size(185, 22);
            this.SubscriptionTypes_MenuItem.Text = "دليل انواع الاشتراكات";
            this.SubscriptionTypes_MenuItem.Click += new System.EventHandler(this.SubscriptionTypes_MenuItem_Click);
            // 
            // EnergySystemMenuItem
            // 
            this.EnergySystemMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SystemConfig_MenuItem});
            this.EnergySystemMenuItem.Name = "EnergySystemMenuItem";
            this.EnergySystemMenuItem.Size = new System.Drawing.Size(115, 20);
            this.EnergySystemMenuItem.Text = "نظام محطة الكهرباء";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EnergySystemMenuItem,
            this.دليلالمشتركينToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(1244, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.White;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 591);
            this.Controls.Add(this.masterPanel);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.masterPanel.ResumeLayout(false);
            this.masterPanel.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel masterPanel;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.ToolStripMenuItem دليلالمشتركينToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Fines_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Services_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Contracts_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Blocks_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem CentralMeter_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Collectors_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem SystemConfig_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem SubscriptionTypes_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem EnergySystemMenuItem;
        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Regions_MenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette1;
    }
}