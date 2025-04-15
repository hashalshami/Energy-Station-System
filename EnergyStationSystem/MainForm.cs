using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnergyStationSystem.SystemConfigForms;

namespace EnergyStationSystem
{
    public partial class MainForm : Form
    {
        private void OpenChildForm(Form childForm)
        {
            if (panelContainer.Controls.Count > 0)
                panelContainer.Controls.RemoveAt(0);
            titleBtn.Text = childForm.Text;
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
            OpenChildForm(new ContractsForm());
            //OpenChildForm(new TestForm());
        }

        private void Collectors_MenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CollectorsForm());
        }

        private void Blocks_MenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BlocksForm());
        }

        private void Regions_MenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new RegionsForm());
        }

        private void CentralMeter_MenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CentralMetersForm());
        }

        private void SubscriptionFees_MenuItem_Click(object sender, EventArgs e)
        {
        }

        private void Contracts_MenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ContractsForm());
        }

        private void Services_MenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ServicesForm());
        }

        private void Fines_MenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FinesForm());
        }

       
    }
}
