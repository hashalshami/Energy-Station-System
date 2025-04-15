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
    public partial class ContractsForm : Form
    {
        private DatabaseConnection db = new DatabaseConnection();
        private void ClearFields()
        {
            txtNumber.Text = "";
            txtName.Text = "";
            txtTerms.Text = "";
            txtNote.Text = "";
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(db.connectionString))
                {
                    con.Open();
                    string query = "SELECT id, name FROM ContractsTypes";
                    SqlDataAdapter daType = new SqlDataAdapter(query, con);
                    DataTable dtType = new DataTable();
                    daType.Fill(dtType);

                    cmbType.DataSource = dtType;
                    cmbType.DisplayMember = "name";
                    cmbType.ValueMember = "id";
                    cmbType.SelectedIndex = 0;

                    
                    ////////////
                    string GridQuery = @"SELECT Contracts.id AS id, Contracts.name AS name, Contracts.terms AS terms, Contracts.note AS note, 
                                        Contracts.date AS date, ContractsTypes.name AS type
                                        FROM Contracts
                                        JOIN ContractsTypes ON Contracts.contract_type_id = ContractsTypes.id";

                    

                    SqlDataAdapter adapter = new SqlDataAdapter(GridQuery, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ عند تحميل البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public ContractsForm()
        {
            InitializeComponent();
            dataGridView1.RowPrePaint += MasterClass.ApplyRowStyle;

        }

        private void ContractsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(db.connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Contracts (contract_type_id, name, terms, note) VALUES (@contract_type_id, @name, @terms, @note)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@contract_type_id", cmbType.SelectedValue);
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@terms", txtTerms.Text);
                        cmd.Parameters.AddWithValue("@note", string.IsNullOrWhiteSpace(txtNote.Text) ? (object)DBNull.Value : txtNote.Text);
                        //cmd.Parameters.AddWithValue("@date", DateTime.Now);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("تمت إضافة البيانات بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("لم يتم إضافة البيانات!", "فشل", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ عند إضافة البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumber.Text))
            {
                MessageBox.Show("يرجى تحديد عقد للتعديل!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(db.connectionString))
                {
                    con.Open();
                    string query = "UPDATE Contracts SET contract_type_id = @contract_type_id, name = @name, terms = @terms, note = @note WHERE id = @id"; 
                                  
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@contract_type_id", cmbType.SelectedValue);
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@terms", txtTerms.Text);
                        cmd.Parameters.AddWithValue("@note", string.IsNullOrWhiteSpace(txtNote.Text) ? (object)DBNull.Value : txtNote.Text);
                        cmd.Parameters.AddWithValue("@id", txtNumber.Text);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("تم تعديل بيانات العقد بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("لم يتم تعديل البيانات!", "فشل", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ عند تعديل البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtNumber.Text = row.Cells["colId"].Value.ToString();
                txtName.Text = row.Cells["colName"].Value.ToString();
            }
        }

        
    }
}
