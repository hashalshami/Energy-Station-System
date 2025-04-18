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
    public partial class Regions : Form
    {
        private DatabaseConnection db = new DatabaseConnection();

        private void SearchName(string name) 
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(db.connectionString))
                {
                    string query = "SELECT * FROM Regions WHERE name LIKE @name";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@name", "%" + name + "%");

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
        
        private void ClearFields()
        {
            txtNumber.Text = "";
            txtName.Text = "";
            txtNote.Text = "";
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(db.connectionString))
                {
                    con.Open();
                    string queryCentral = "SELECT id, name FROM CentralMeters";
                    SqlDataAdapter daCollectors = new SqlDataAdapter(queryCentral, con);
                    DataTable dtCentral = new DataTable();
                    daCollectors.Fill(dtCentral);

                    cmbCentralMeter.DataSource = dtCentral;
                    cmbCentralMeter.DisplayMember = "name";
                    cmbCentralMeter.ValueMember = "id";
                    cmbCentralMeter.SelectedIndex = -1;


                    string GridQuery = @"SELECT Regions.id, Regions.name AS 'name',
                                    CentralMeters.name AS 'central_meter',Regions.note AS 'note'  , Regions.date AS 'date' 
                                    FROM Regions 
                                    JOIN CentralMeters ON Regions.central_meter_id = CentralMeters.id";

                    SqlDataAdapter adapter = new SqlDataAdapter(GridQuery, con);
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
        public Regions()
        {
            InitializeComponent();
        }

        private void RegionsForm_Load(object sender, EventArgs e)
        {
            dataGridView1.RowPrePaint += MasterClass.ApplyRowStyle;
            LoadData();
            ClearFields();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("يرجى ملء اسم المنطقة  !", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(db.connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO Regions (name, central_meter_id, note, date) VALUES (@name, @central_meter_id, @note, @date)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        if (cmbCentralMeter.SelectedIndex == -1)
                        {
                            MessageBox.Show("يرجى اختيار العداد المركزي!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@central_meter_id", cmbCentralMeter.SelectedValue);
                        cmd.Parameters.AddWithValue("@note", string.IsNullOrWhiteSpace(txtNote.Text) ? (object)DBNull.Value : txtNote.Text);
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            LoadData();
                            MessageBox.Show("تمت إضافة المنطقة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int regionID;
            if (string.IsNullOrWhiteSpace(txtNumber.Text) || !int.TryParse(txtNumber.Text, out regionID))
            {
                MessageBox.Show("يرجى تحديد منطقة صحيحة او رقم منطقة صحيح  !", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {
                using (SqlConnection conn = new SqlConnection(db.connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Regions SET name = @name,central_meter_id =@central_meter_id, note = @note WHERE id = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", regionID);
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@central_meter_id", cmbCentralMeter.SelectedValue);
                        cmd.Parameters.AddWithValue("@note", string.IsNullOrWhiteSpace(txtNote.Text) ? (object)DBNull.Value : txtNote.Text);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            LoadData();
                            MessageBox.Show("تم تعديل بيانات المنطقة بنجاح!", "تم التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
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
            int regtionID;

            if (!int.TryParse(txtNumber.Text, out regtionID))
            {
                MessageBox.Show("يرجى تحديد رقم صحيح للمنطقة!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("هل أنت متأكد أنك تريد حذف هذه المنطقة؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(db.connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Regions WHERE id = @id";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", regtionID);

                            int rows = cmd.ExecuteNonQuery();
                            if (rows > 0)
                            {
                                LoadData();
                                MessageBox.Show("تم حذف المنطقة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadData();
        }

        private void printBtn_Click(object sender, EventArgs e)
        {

        }

        

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtNumber.Text = row.Cells["colID"].Value.ToString();
                txtName.Text = row.Cells["colName"].Value.ToString();
                txtNote.Text = row.Cells["colNote"].Value.ToString();
                cmbCentralMeter.Text = row.Cells["colCentralMeter"].Value.ToString();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
