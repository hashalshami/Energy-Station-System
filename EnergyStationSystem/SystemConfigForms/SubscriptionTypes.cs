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
            int unit_price = db.GetValidatedNumber(txtUnitPrice.Text ,"يرجى إدخال سعر الوحدة !", "تنبيه");
            int service_fees = db.GetValidatedNumber(txtUnitPrice.Text, "يرجى إدخال تكلفة الخدمة !", "تنبيه");
            if(unit_price == -1 || service_fees ==-1)
                return;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("يرجى إدخال اسم نوع الاشتراك!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(db.connectionString))
                {
                    con.Open();
                    string query = @"INSERT INTO SubscriptionTypes (name, unit_price, service_fees, note, date) 
                             VALUES (@name, @unit_price, @service_fees, @note, @date)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@unit_price", int.Parse(txtUnitPrice.Text));
                        cmd.Parameters.AddWithValue("@service_fees", int.Parse(txtServiceFees.Text));
                        cmd.Parameters.AddWithValue("@note", string.IsNullOrWhiteSpace(txtNote.Text) ? (object)DBNull.Value : txtNote.Text);
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            LoadData();
                            MessageBox.Show("تمت إضافة نوع الاشتراك بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
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
            if (string.IsNullOrWhiteSpace(txtNumber.Text))
            {
                MessageBox.Show("يرجى تحديد رقم نوع الاشتراك!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("يرجى إدخال اسم نوع الاشتراك!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int unit_price = db.GetValidatedNumber(txtUnitPrice.Text, "يرجى إدخال سعر الوحدة !", "تنبيه");
            int service_fees = db.GetValidatedNumber(txtUnitPrice.Text, "يرجى إدخال تكلفة الخدمة !", "تنبيه");
            if (unit_price == -1 || service_fees == -1)
                return;

            try
            {
                using (SqlConnection con = new SqlConnection(db.connectionString))
                {
                    con.Open();
                    string query = "UPDATE SubscriptionTypes SET name = @name, unit_price = @unit_price, service_fees = @service_fees, note = @note WHERE id = @id";
                                  
                                 
                                 
                             

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", int.Parse(txtNumber.Text));
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@unit_price", unit_price);
                        cmd.Parameters.AddWithValue("@service_fees", service_fees);
                        cmd.Parameters.AddWithValue("@note", string.IsNullOrWhiteSpace(txtNote.Text) ? (object)DBNull.Value : txtNote.Text);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            LoadData();
                            MessageBox.Show("تم تعديل نوع الاشتراك بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("لم يتم العثور على السجل!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (string.IsNullOrWhiteSpace(txtNumber.Text))
            {
                MessageBox.Show("يرجى تحديد رقم نوع الاشتراك!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialog = MessageBox.Show("هل أنت متأكد من حذف نوع الاشتراك؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(db.connectionString))
                    {
                        con.Open();
                        string query = "DELETE FROM SubscriptionTypes WHERE id = @id";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@id", int.Parse(txtNumber.Text));
                            int rows = cmd.ExecuteNonQuery();

                            if (rows > 0)
                            {
                                LoadData();
                                MessageBox.Show("تم حذف نوع الاشتراك بنجاح.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);                                
                            }
                            else
                            {
                                MessageBox.Show("لم يتم العثور على السجل!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
