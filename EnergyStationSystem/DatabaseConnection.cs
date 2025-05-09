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
        public string connectionString = @"Data Source=HASH;Initial Catalog=EnergyStation;Integrated Security=True";
        //public string ReseedID = "DBCC CHECKIDENT ('Table', RESEED, 0)";

        // دالة تقوم بتحويل قيمة نصية إلى رقم صحيح (int)
        // إذا كانت القيمة غير صالحة (فارغة أو غير رقم)، تعرض رسالة خطأ وتعيد -1
        //طريقة استدعائها نمرر مربع النص مع قيمته النصية ثم الرسالة المعروضة مثلا
        // GetValidatedNumber(TextBox.Text , "يرجى ادخال رقم صحيح")
        public int GetValidatedNumber(string input, string message = "يرجى تحديد رقم صحيح!",string title="خطأ !" )
        {
            int number;

            // التحقق إذا كانت القيمة النصية فارغة أو لا يمكن تحويلها إلى int
            if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out number))
            {
                // عرض رسالة خطأ للمستخدم في حال كانت القيمة غير صحيحة
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return -1; // إرجاع -1 للدلالة على أن القيمة غير صالحة
            }

            // إذا كانت القيمة صحيحة، يتم إرجاع الرقم بعد التحويل
            return number;
        }


        //دالة اختبار صممتها كي تتحقق من اتصال قاعدة البيانات ولكنها ليست مهمة ولم استخدمها
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
