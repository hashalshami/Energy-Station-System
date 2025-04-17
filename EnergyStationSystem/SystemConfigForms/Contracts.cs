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
    public partial class Contracts : Form
    {
        private DatabaseConnection db = new DatabaseConnection();
        private MasterClass mc = new MasterClass();

        private void SearchName(string name)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(db.connectionString))
                {
                    conn.Open();
                    string query = @"SELECT Contracts.id AS id, Contracts.name AS name, Contracts.terms AS terms, Contracts.note AS note, 
                            Contracts.date AS date, ContractTypes.name AS type
                            FROM Contracts
                            JOIN ContractTypes ON Contracts.type_id = ContractTypes.id
                            WHERE Contracts.name LIKE @name";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@name", name + "%");

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء البحث: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtNumber.Text = "";
            txtName.Text = "";
            txtTerms.Text = "";
            txtNote.Text = "";
        }

        private void LoadData()
        {
            ClearFields();
            try
            {
                using (SqlConnection con = new SqlConnection(db.connectionString))
                {
                    con.Open();
                    string query = "SELECT id, name FROM ContractTypes";
                    SqlDataAdapter daType = new SqlDataAdapter(query, con);
                    DataTable dtType = new DataTable();
                    daType.Fill(dtType);

                    cmbType.DataSource = dtType;
                    cmbType.DisplayMember = "name";
                    cmbType.ValueMember = "id";
                    cmbType.SelectedIndex = 0;

                    
                    ////////////
                    string GridQuery = @"SELECT Contracts.id AS id, Contracts.name AS name, Contracts.terms AS terms, Contracts.note AS note, 
                                        Contracts.date AS date, ContractTypes.name AS type
                                        FROM Contracts
                                        JOIN ContractTypes ON Contracts.type_id = ContractTypes.id";

                    

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

        public Contracts()
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
                    string query = "INSERT INTO Contracts (type_id, name, terms, note) VALUES (@type_id, @name, @terms, @note)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@type_id", cmbType.SelectedValue);
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
                    int contractId = db.GetValidatedNumber(txtNumber.Text, "يرجى تحديد رقم صحيح للعداد المركزي!", "خطأ"); ;
                    if(contractId == -1)
                        return;

                    string query = "UPDATE Contracts SET type_id = @type_id, name = @name, terms = @terms, note = @note WHERE id = @id"; 
                          
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", contractId);
                        cmd.Parameters.AddWithValue("@type_id", cmbType.SelectedValue);
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@terms", txtTerms.Text);
                        cmd.Parameters.AddWithValue("@note", string.IsNullOrWhiteSpace(txtNote.Text) ? (object)DBNull.Value : txtNote.Text);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            LoadData();
                            MessageBox.Show("تم تعديل بيانات العقد بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int contractId = db.GetValidatedNumber(txtNumber.Text, "يرجى تحديد رقم صحيح لنموذج العقد!"); ;
            if (contractId == -1)
                return;


            DialogResult result = MessageBox.Show("هل أنت متأكد أنك تريد حذف نموذج العقد ؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(db.connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Contracts WHERE id = @id";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", contractId);

                            int rows = cmd.ExecuteNonQuery();
                            if (rows > 0)
                            {
                                LoadData();
                                MessageBox.Show("تم حذف نموذج العقد بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtNumber.Text = row.Cells["colId"].Value.ToString();
                cmbType.SelectedIndex = cmbType.FindString(row.Cells["colType"].Value.ToString());
                txtName.Text = row.Cells["colName"].Value.ToString();
                txtTerms.Text = row.Cells["colTerms"].Value.ToString();
                txtNote.Text = row.Cells["colNote"].Value.ToString();
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadData();
        }

        

        
    }
}
