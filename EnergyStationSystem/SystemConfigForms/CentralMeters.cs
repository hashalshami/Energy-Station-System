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
    public partial class CentralMeters : Form
    {
        private DatabaseConnection db = new DatabaseConnection();

        private void ClearFields()
        {
            txtNumber.Text = "";
            txtName.Text = "";
            txtLimit.Text = "";
            txtNote.Text = "";
        }

        private void LoadData()
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(db.connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM CentralMeters", conn);
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

        
        public CentralMeters()
        {
            InitializeComponent();
        }

        private void CentralMetersForm_Load(object sender, EventArgs e)
        {
            LoadData();
            dataGridView1.RowPrePaint += MasterClass.ApplyRowStyle;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(db.connectionString))
                {
                    con.Open();

                    string query = @"INSERT INTO CentralMeters (name, limit, note, date)
                             VALUES (@name, @limit, @note, @date)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@limit", string.IsNullOrWhiteSpace(txtLimit.Text) ? (object)DBNull.Value : Convert.ToInt32(txtLimit.Text));
                        cmd.Parameters.AddWithValue("@note", string.IsNullOrWhiteSpace(txtNote.Text) ? (object)DBNull.Value : txtNote.Text);
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            LoadData();
                            MessageBox.Show("تمت إضافة العداد المركزي بنجاح !!!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
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
                MessageBox.Show("يرجى إدخال رقم العداد المركزي لتعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int meterId;
            if (!int.TryParse(txtNumber.Text, out meterId))
            {
                MessageBox.Show("رقم العداد غير صحيح!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(db.connectionString))
                {
                    con.Open();

                    string query = @"UPDATE CentralMeters 
                             SET name = @name, limit = @limit, note = @note, date = @date 
                             WHERE id = @id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", meterId);
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@limit", string.IsNullOrWhiteSpace(txtLimit.Text) ? (object)DBNull.Value : Convert.ToInt32(txtLimit.Text));
                        cmd.Parameters.AddWithValue("@note", string.IsNullOrWhiteSpace(txtNote.Text) ? (object)DBNull.Value : txtNote.Text);
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            LoadData();
                            MessageBox.Show("تم تعديل بيانات العداد بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
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

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumber.Text))
            {
                MessageBox.Show("يرجى إدخال رقم العداد المركزي لتعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int meterId = db.GetValidatedNumber(txtNumber.Text, "يرجى إدخال رقم صحيح لحذف العداد!");
            if (meterId == -1)
                return;
    

            DialogResult result = MessageBox.Show("هل أنت متأكد أنك تريد حذف هذا العداد؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(db.connectionString))
                    {
                        con.Open();
                        string query = "DELETE FROM CentralMeters WHERE id = @id";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@id", meterId);
                            int rows = cmd.ExecuteNonQuery();

                            if (rows > 0)
                            {
                                LoadData();
                                MessageBox.Show("تم حذف العداد بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearFields();
                            }
                            else
                            {
                                MessageBox.Show("لم يتم العثور على العداد.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("حدث خطأ أثناء الحذف: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearFields();
        }

        private void printBtn_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtNumber.Text = row.Cells["colID"].Value.ToString();
                txtName.Text = row.Cells["colName"].Value.ToString();
                txtLimit.Text = row.Cells["colLimit"].Value.ToString();
                txtNote.Text = row.Cells["colNote"].Value.ToString();
            }
        }
    }
}
