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
            OpenChildForm(new CollectorsForm(), "دليل المحصلين");
        }

        private void Collectors_MenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CollectorsForm(), "دليل المحصلين");
        }

        private void Areas_MenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AreasForm(), "دليل المناطق");
        }
    }
}
