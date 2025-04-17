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
    public partial class FinesForm : Form
    {
        private DatabaseConnection db = new DatabaseConnection();

        private void ClearFields()
        {
            txtNumber.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            txtDescription.Text = "";
        }

        private void LoadData()
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(db.connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Fines", conn);
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
            ClearFields();
        }

        
        public FinesForm()
        {
            InitializeComponent();
            dataGridView1.RowPrePaint += MasterClass.ApplyRowStyle;
        }

        private void FinesForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPrice.Text) )
            {
                MessageBox.Show("يرجى ملء جميع الحقول!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long price;
            if (!long.TryParse(txtPrice.Text, out price) )
            {
                MessageBox.Show("يرجى إدخال مبلغ صحيح !", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(db.connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Fines (name, price, description, date) VALUES (@name, @price, @description, @date)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@description", string.IsNullOrWhiteSpace(txtDescription.Text) ? (object)DBNull.Value : txtDescription.Text);
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);


                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            LoadData();
                            MessageBox.Show("تمت إضافة الغرامة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("حدث خطأ أثناء الإضافة!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            int fineId;
            long price;
            if (string.IsNullOrWhiteSpace(txtNumber.Text) || !int.TryParse(txtNumber.Text, out fineId))
            {
                MessageBox.Show("يرجى تحديد رقم صحيح للغرامة!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!long.TryParse(txtPrice.Text, out  price))
            {
                MessageBox.Show("يرجى إدخال مبلغ صحيح !!!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(db.connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Fines SET name = @name, price = @price, description = @description WHERE id = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", fineId);
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@description", string.IsNullOrWhiteSpace(txtDescription.Text) ? (object)DBNull.Value : txtDescription.Text);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            LoadData();
                            MessageBox.Show("تم تعديل البيانات بنجاح!", "تم التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);                            
                        }
                        else
                        {
                            MessageBox.Show("لم يتم العثور على السجل لتحديثه!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int fineID;

            if (!int.TryParse(txtNumber.Text, out fineID))
            {
                MessageBox.Show("يرجى تحديد غرامة صحيحة  !", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("هل أنت متأكد أنك تريد حذف هذه الغرامة؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(db.connectionString))
                    {
                        con.Open();
                        string query = "DELETE FROM Fines WHERE id = @id";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@id", fineID);

                            int rows = cmd.ExecuteNonQuery();
                            if (rows > 0)
                            {
                                LoadData();
                                MessageBox.Show("تم حذف السجل بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearFields();
                            }
                            else
                            {
                                MessageBox.Show("لم يتم العثور على السجل.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("حدث خطأ: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {

        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            LoadData();
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
                txtPrice.Text = row.Cells["colPrice"].Value.ToString();
                txtDescription.Text = row.Cells["colDescription"].Value.ToString();
            }
        }



    }
}
