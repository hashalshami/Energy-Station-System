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


        public static void ApplyButtonStyle(Button button)
        {
            button.FlatStyle = FlatStyle.Flat; 
            button.FlatAppearance.BorderSize = 0;
            button.ForeColor = Color.White;
            button.Font = new Font("Tahoma", 12, FontStyle.Bold); 

            switch (button.Name)
            {
                case "addBtn":
                    button.BackColor = Color.Green;
                    break;
                case "editBtn":
                    button.BackColor = Color.DodgerBlue;
                    break;
                case "deleteBtn":
                    button.BackColor = Color.Red;
                    break;
                case "searchBtn":
                    button.BackColor = Color.Teal;
                    break;
                case "updateBtn":
                    button.BackColor = Color.LightBlue;
                    break;
                case "printBtn":
                    button.BackColor = Color.White;
                    button.ForeColor = Color.Black; 
                    break;
                default:
                    button.BackColor = Color.Gray;
                    break;
            }
        }









    }
}
