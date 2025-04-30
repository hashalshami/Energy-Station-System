using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace EnergyStationSystem
{
    class MasterClass
    {
        
        //دالة تقوم بتلوين صفوف الجدول داتا جريد  (صف بصف) لون بلون
        public static void ApplyRowStyle(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv != null)
            {
                if (e.RowIndex % 2 == 0)
                {
                    dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.WhiteSmoke; // لون للسطر الزوجي
                }
                else
                {
                    dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gainsboro; // لون للسطر الفردي
                }
            }
        }

       






    }
}
