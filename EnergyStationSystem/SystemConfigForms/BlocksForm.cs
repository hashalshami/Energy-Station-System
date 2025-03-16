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


namespace EnergyStationSystem.SystemConfigForms
{
    public partial class BlocksForm : Form
    {
        private DatabaseConnection db = new DatabaseConnection();

        private void ClearFields()
        {
            txtNumber.Text = "";
            txtName.Text = "";
            areaBox.SelectedText ;
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(db.connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Areas", conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dt;
                    dataGridView1.DataSource = bs;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ عند الاتصال: " + ex.Message);
            }
        }

        public BlocksForm()
        {
            InitializeComponent();
        }

        private void BlocksForm_Load(object sender, EventArgs e)
        {

        }
    }
}
