﻿using System;
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
    public partial class ServicesForm : Form
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
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Services", conn);
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

        public ServicesForm()
        {
            InitializeComponent();
        }

        private void ServicesForm_Load(object sender, EventArgs e)
        {
            LoadData();
            dataGridView1.RowPrePaint += MasterClass.ApplyRowStyle;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("يرجى ملء جميع الحقول!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int price;
            if (!int.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("يرجى إدخال مبلغ صحيح !", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(db.connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Services (name, price, description) VALUES (@name, @price, @description)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@description", string.IsNullOrWhiteSpace(txtDescription.Text) ? (object)DBNull.Value : txtDescription.Text);


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
            int serviceID;
            int price;
            if (string.IsNullOrWhiteSpace(txtNumber.Text) || !int.TryParse(txtNumber.Text, out serviceID))
            {
                MessageBox.Show("يرجى تحديد رقم صحيح للخدمة!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtPrice.Text, out  price))
            {
                MessageBox.Show("يرجى إدخال مبلغ صحيح !!!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(db.connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Services SET name = @name, price = @price, description = @description WHERE id = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", serviceID);
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
            int serviceID;

            if (!int.TryParse(txtNumber.Text, out serviceID))
            {
                MessageBox.Show("يرجى تحديد خدمة صحيحة  !", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("هل أنت متأكد أنك تريد حذف هذه الخدمة؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(db.connectionString))
                    {
                        con.Open();
                        string query = "DELETE FROM Services WHERE id = @id";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@id", serviceID);

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
                txtPrice.Text = row.Cells["colPrice"].Value.ToString();
                txtDescription.Text = row.Cells["colDescription"].Value.ToString();
            }
        }
    }
}
