namespace EnergySystem
{
    partial class EnergySystem
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.EnergySystemMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SystemConfigMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Collectors_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CentralMeter_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Areas_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Blocks_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SubscriptionFees_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Contracts_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Services_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Fines_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.دليلالمشتركينToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EnergySystemMenuItem,
            this.دليلالمشتركينToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(787, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // EnergySystemMenuItem
            // 
            this.EnergySystemMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SystemConfigMenuItem});
            this.EnergySystemMenuItem.Name = "EnergySystemMenuItem";
            this.EnergySystemMenuItem.Size = new System.Drawing.Size(115, 20);
            this.EnergySystemMenuItem.Text = "نظام محطة الكهرباء";
            // 
            // SystemConfigMenuItem
            // 
            this.SystemConfigMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Collectors_MenuItem,
            this.CentralMeter_MenuItem,
            this.Areas_MenuItem,
            this.Blocks_MenuItem,
            this.SubscriptionFees_MenuItem,
            this.Contracts_MenuItem,
            this.Services_MenuItem,
            this.Fines_MenuItem});
            this.SystemConfigMenuItem.Name = "SystemConfigMenuItem";
            this.SystemConfigMenuItem.Size = new System.Drawing.Size(152, 22);
            this.SystemConfigMenuItem.Text = "تهيئة النظام";
            // 
            // Collectors_MenuItem
            // 
            this.Collectors_MenuItem.Name = "Collectors_MenuItem";
            this.Collectors_MenuItem.Size = new System.Drawing.Size(185, 22);
            this.Collectors_MenuItem.Text = "دليل المحصلين";
            this.Collectors_MenuItem.Click += new System.EventHandler(this.Collectors_MenuItem_Click);
            // 
            // CentralMeter_MenuItem
            // 
            this.CentralMeter_MenuItem.Name = "CentralMeter_MenuItem";
            this.CentralMeter_MenuItem.Size = new System.Drawing.Size(185, 22);
            this.CentralMeter_MenuItem.Text = "دليل العدادات المركزية";
            // 
            // Areas_MenuItem
            // 
            this.Areas_MenuItem.Name = "Areas_MenuItem";
            this.Areas_MenuItem.Size = new System.Drawing.Size(185, 22);
            this.Areas_MenuItem.Text = "دليل المناطق";
            // 
            // Blocks_MenuItem
            // 
            this.Blocks_MenuItem.Name = "Blocks_MenuItem";
            this.Blocks_MenuItem.Size = new System.Drawing.Size(185, 22);
            this.Blocks_MenuItem.Text = "دليل المربعات";
            // 
            // SubscriptionFees_MenuItem
            // 
            this.SubscriptionFees_MenuItem.Name = "SubscriptionFees_MenuItem";
            this.SubscriptionFees_MenuItem.Size = new System.Drawing.Size(185, 22);
            this.SubscriptionFees_MenuItem.Text = "دليل تعرفة الاشتراكات";
            // 
            // Contracts_MenuItem
            // 
            this.Contracts_MenuItem.Name = "Contracts_MenuItem";
            this.Contracts_MenuItem.Size = new System.Drawing.Size(185, 22);
            this.Contracts_MenuItem.Text = "دليل نماذج العقود";
            // 
            // Services_MenuItem
            // 
            this.Services_MenuItem.Name = "Services_MenuItem";
            this.Services_MenuItem.Size = new System.Drawing.Size(185, 22);
            this.Services_MenuItem.Text = "دليل الخدمات";
            // 
            // Fines_MenuItem
            // 
            this.Fines_MenuItem.Name = "Fines_MenuItem";
            this.Fines_MenuItem.Size = new System.Drawing.Size(185, 22);
            this.Fines_MenuItem.Text = "دليل الغرامات";
            // 
            // دليلالمشتركينToolStripMenuItem
            // 
            this.دليلالمشتركينToolStripMenuItem.Name = "دليلالمشتركينToolStripMenuItem";
            this.دليلالمشتركينToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.دليلالمشتركينToolStripMenuItem.Text = "دليل المشتركين";
            // 
            // EnergySystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 442);
            this.Controls.Add(this.menuStrip1);
            this.Name = "EnergySystem";
            this.Text = "Energy System";
            this.Load += new System.EventHandler(this.EnergySystem_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem EnergySystemMenuItem;
        private System.Windows.Forms.ToolStripMenuItem دليلالمشتركينToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SystemConfigMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Collectors_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem CentralMeter_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Areas_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Blocks_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem SubscriptionFees_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Contracts_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Services_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Fines_MenuItem;
        public System.Windows.Forms.MenuStrip menuStrip1;
    }
}

