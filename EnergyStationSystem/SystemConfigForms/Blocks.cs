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
    public partial class Blocks : Form
    {
        private DatabaseConnection db = new DatabaseConnection();

        private void ClearFields()
        {
            editBtn.Enabled = false;
            deleteBtn.Enabled = false;
            addBtn.Enabled = true;
            txtNumber.Text = "";
            txtName.Text = "";
            comboRegions.SelectedIndex = -1;
            comboCollectors.SelectedIndex = -1;
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(db.connectionString))
                {
                    con.Open();
                    string queryCollectors = "SELECT id, name FROM Collectors";
                    SqlDataAdapter daCollectors = new SqlDataAdapter(queryCollectors, con);
                    DataTable dtCollectors = new DataTable();
                    daCollectors.Fill(dtCollectors);

                    comboCollectors.DataSource = dtCollectors;
                    comboCollectors.DisplayMember = "name";
                    comboCollectors.ValueMember = "id";
                    comboCollectors.SelectedIndex = -1;

                    string queryRegions = "SELECT id, name FROM Regions";
                    SqlDataAdapter daRegions = new SqlDataAdapter(queryRegions, con);
                    DataTable dtRegions = new DataTable();
                    daRegions.Fill(dtRegions);

                    comboRegions.DataSource = dtRegions;
                    comboRegions.DisplayMember = "name";
                    comboRegions.ValueMember = "id";
                    comboRegions.SelectedIndex = -1;
                    ////////////

                    string GridQuery = @"SELECT Blocks.id, Blocks.name AS 'BlockName', 
                                    Regions.name AS 'RegionName', Collectors.name AS 'CollectorName', Blocks.date AS 'date' 
                                    FROM Blocks JOIN Regions ON Blocks.region_id = Regions.id
                                    JOIN Collectors ON Blocks.collector_id = Collectors.id";

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

        public Blocks()
        {
            InitializeComponent();
        }

        private void BlocksForm_Load(object sender, EventArgs e)
        {
            ClearFields();
            LoadData();
            dataGridView1.RowPrePaint += MasterClass.ApplyRowStyle;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(db.connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Blocks (name, region_id, collector_id) VALUES (@name, @region_id, @collector_id)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@region_id", comboRegions.SelectedValue);
                        cmd.Parameters.AddWithValue("@collector_id", comboCollectors.SelectedValue);
                        //cmd.Parameters.AddWithValue("@date", DateTime.Now);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("تمت إضافة البيانات بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields(); 
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
            if (string.IsNullOrWhiteSpace(txtName.Text) || comboRegions.SelectedIndex == -1 || comboCollectors.SelectedIndex == -1)
            {
                MessageBox.Show("يرجى تحديد بيانات صحيحة قبل التعديل!", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(db.connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Blocks SET name=@name, region_id=@region_id, collector_id=@collector_id WHERE id= '" + txtNumber.Text+"'";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        //cmd.Parameters.AddWithValue("@id", txtNumber.Text);
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@region_id", comboRegions.SelectedValue);
                        cmd.Parameters.AddWithValue("@collector_id", comboCollectors.SelectedValue);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("تم تعديل بيانات المربع بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
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

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumber.Text))
            {
                MessageBox.Show("يرجى تحديد السجل المراد حذفه!", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("هل أنت متأكد من حذف هذا المربع؟", "تأكيد حذف المربع", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(db.connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Blocks WHERE id='" + txtNumber.Text+"'";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            //cmd.Parameters.AddWithValue("@id", txtNumber.Text);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("تم حذف المربع بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearFields();
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("لم يتم العثور على المربع!", "فشل", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("حدث خطأ عند حذف البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            editBtn.Enabled = true;
            deleteBtn.Enabled = true;
            addBtn.Enabled = false;


            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtNumber.Text = row.Cells["colID"].Value.ToString();
                txtName.Text = row.Cells["colName"].Value.ToString();
                comboRegions.SelectedIndex = comboRegions.FindString(row.Cells["colRegion"].Value.ToString());
                comboCollectors.SelectedIndex = comboCollectors.FindString(row.Cells["colCollector"].Value.ToString());
            }
        }

        
    }
}
