using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// مجلدات الواجهات
using EnergyStationSystem.SystemConfigForms;
using EnergyStationSystem.ProcessForms;

namespace EnergyStationSystem
{
    public partial class MainForm : Form
    {
        private void OpenChildForm(Form childForm)
        {
            if (panelContainer.Controls.Count > 0)
                panelContainer.Controls.RemoveAt(0);
            titleLabel.Text = childForm.Text;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelContainer.Controls.Add(childForm);
            panelContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public MainForm()
        {
            InitializeComponent();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            OpenChildForm(new Regions());
            //OpenChildForm(new Collectors());
            //OpenChildForm(new SubscriptionTypes());
            //OpenChildForm(new Blocks());
            //OpenChildForm(new CentralMeters());
            //OpenChildForm(new Contracts());
            //OpenChildForm(new Services());
            //OpenChildForm(new Fines());

            //OpenChildForm(new TestForm());
        }

        private void Collectors_MenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Collectors());
        }

        private void Blocks_MenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Blocks());
        }

        private void Regions_MenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Regions());
        }

        private void CentralMeter_MenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CentralMeters());
        }

        private void Contracts_MenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Contracts());
        }

        private void Services_MenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Services());
        }

        private void Fines_MenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Fines());
        }

        private void SubscriptionTypes_MenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SubscriptionTypes());
        }

       
    }
}
