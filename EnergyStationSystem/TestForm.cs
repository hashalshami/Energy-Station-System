using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EnergyStationSystem
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            // تأكد من وجود إعدادات
            if (Properties.Settings.Default.MeterStatus == null)
                Properties.Settings.Default.MeterStatus = new System.Collections.Specialized.StringCollection();
            Properties.Settings.Default.Save();
            // تعبئة الكومبوبوكس من الإعدادات
            comboBox1.Items.Clear();
            foreach (string item in Properties.Settings.Default.MeterStatus)
            {
                comboBox1.Items.Add(item);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
