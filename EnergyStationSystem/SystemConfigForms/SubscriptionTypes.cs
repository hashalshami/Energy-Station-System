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
using System.Globalization;
using System.Threading;


namespace EnergyStationSystem.SystemConfigForms
{
    public partial class SubscriptionTypes : Form
    {
        private DatabaseConnection db = new DatabaseConnection();


        private void ClearFields()
        {
            txtNumber.Text = "";
            txtName.Text = "";
            txtUnitPrice.Text = "";
            txtServiceFees.Text = "";
            txtNote.Text = "";
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(db.connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM SubscriptionTypes", con);
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

        
        public SubscriptionTypes()
        {
            InitializeComponent();
        }

        private void SubscriptionTypes_Load(object sender, EventArgs e)
        {
            LoadData();
            dataGridView1.RowPrePaint += MasterClass.ApplyRowStyle;


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtNumber.Text = row.Cells["colID"].Value.ToString();
                txtName.Text = row.Cells["colName"].Value.ToString();
                txtUnitPrice.Text = row.Cells["colUnitPrice"].Value.ToString();
                txtServiceFees.Text = row.Cells["colServiceFees"].Value.ToString();
                txtNote.Text = row.Cells["colNote"].Value.ToString();
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearFields();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "رقم") // اسم العمود
    {
                int number;
        if (e.Value != null && int.TryParse(e.Value.ToString(), out number))
        {
            e.Value = number.ToString(CultureInfo.InvariantCulture); // عرض الرقم بالإنجليزي
            e.FormattingApplied = true;
        }
    }
        }
    }
}
