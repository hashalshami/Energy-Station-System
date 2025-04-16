using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EnergyStationSystem
{
    class DatabaseConnection
    {
        public string connectionString = "Data Source=HASH;Initial Catalog=EnergyStation_Database;Integrated Security=True";
        public string ReseedID = "DBCC CHECKIDENT ('Collectors', RESEED, 0)";

        public int GetValidatedNumber(string input, string message = "يرجى تحديد رقم صحيح!", string title = "خطأ")
        {
            int number;
            if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out number))
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; 
            }
            
            return number;
        }

        public bool TestConnection()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("✅ تم الاتصال بقاعدة البيانات بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ فشل الاتصال: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    
    }
}
