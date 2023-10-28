using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Calendar : Form
    {
        int month = DateTime.Today.Month;
        int year = DateTime.Today.Year;

        public Calendar()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int day = Convert.ToInt32(dataGridView1[e.ColumnIndex, e.RowIndex].Value);
            calendarEvent ce = new calendarEvent(day,month,year);
            ce.Show();
        }

        private void Calendar_Load(object sender, EventArgs e)
        {

            int maxDays = DateTime.DaysInMonth(year, month);
            int day = 0;
            DateTime dateValue = new DateTime(year, month, 1);
            int firstDatOfWeek = (int) dateValue.DayOfWeek;
            if (firstDatOfWeek == 0)
            {
                firstDatOfWeek = 7; //воскресенье почему-то стоит на 0, ставим его на заслуженный 7 день недели
            }

            for (int i = 0; i < 6; i++)
            {
                dataGridView1.Rows.Add();
                for (int j = 0; j < 7; j++)
                {
                    if (firstDatOfWeek > 1)
                    {
                        firstDatOfWeek--;
                        continue;
                    }
                    
                    day++;
                    if (day > maxDays)
                    {
                        break;
                    }
                    dataGridView1.Rows[i].Cells[j].Value = day;
                    
                }
            }

            label1.Text = month.ToString() + " месяц, "+year.ToString() + " год";
        }
    }
}
