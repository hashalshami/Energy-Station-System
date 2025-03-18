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
        private void OpenChildForm(Form childForm, string title = "دليل محطة الكهرباء")
        {
            if (panelContainer.Controls.Count > 0)
                panelContainer.Controls.RemoveAt(0);
            titleBtn.Text = title;
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
            OpenChildForm(new BlocksForm(), "دليل المربعات");
        }

        private void Collectors_MenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CollectorsForm(), "دليل المحصلين");
        }

        private void Blocks_MenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BlocksForm(), "دليل المربعات");
        }

        private void titleBtn_Click(object sender, EventArgs e)
        {

        }

        private void Regions_MenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new RegionsForm(), "دليل المناطق");
        }

        private void CentralMeter_MenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CentralMetersForm(), "دليل العدادات المركزية");
        }

        private void SubscriptionFees_MenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SubscriptionRatesForm(), "دليل تعرفة الاشتراكات ");
        }

        private void Contracts_MenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ContractsForm(), "دليل نماذج العقود ");
        }

        private void Services_MenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ServicesForm(), "دليل الخدمات ");
        }

        private void Fines_MenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FinesForm(), "دليل الغرامات ");
        }

       
    }
}
