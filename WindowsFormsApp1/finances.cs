using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class finances : Form
    {

        public finances()
        {
            InitializeComponent();
        }

        private void finances_Load(object sender, EventArgs e)
        {
            string typeOfFinances = "";
            int finalsumm = 0;
            DB db = new DB();
            db.openConnection();

            string sql = "SELECT type, name, cost, f_dateend from finances";

            MySqlCommand command = new MySqlCommand(sql, db.getConnection());
            MySqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                if (reader.GetString(0) == "+")
                {
                    typeOfFinances = "Доход";
                    finalsumm = finalsumm + reader.GetInt32(2);
                }
                else
                {
                    typeOfFinances = "Расход";
                    finalsumm = finalsumm - reader.GetInt32(2);
                }


                int currentyear = DateTime.Now.Year;
                int endyear = DateTime.Parse(reader.GetString(3)).Year;

                int currentmonth = DateTime.Now.Month;
                int endmonth = DateTime.Parse(reader.GetString(3)).Month;

                if (currentyear < endyear)
                {
                    dataGridView1.Rows.Add(typeOfFinances, reader.GetString(1), reader.GetString(2));
                }
                else if (currentyear == endyear)
                {
                    if (currentmonth <= endmonth)
                    {
                        dataGridView1.Rows.Add(typeOfFinances, reader.GetString(1), reader.GetString(2));
                    }
                }

            }

            label8.Text = finalsumm.ToString();
            reader.Close();
            db.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            db.openConnection();

            string sql = "INSERT INTO finances VALUES (id, @name, @cost, @type, @f_dateend, @period)";

            MySqlCommand command = new MySqlCommand(sql, db.getConnection());

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@cost", MySqlDbType.Int64).Value = textBox2.Text;
            command.Parameters.Add("@type", MySqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@f_dateend", MySqlDbType.Date).Value = maskedTextBox1.Text;
            command.Parameters.Add("@period", MySqlDbType.Int16).Value = 1;

            MySqlDataReader reader = command.ExecuteReader();

            MessageBox.Show("Сохранено!");

            reader.Close();
            db.closeConnection();
            this.Close();
            finances fin = new finances();
            fin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            db.openConnection();

            string sql = "INSERT INTO finances VALUES (id, @name, @cost, @type, @f_dateend, @period)";

            MySqlCommand command = new MySqlCommand(sql, db.getConnection());

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@cost", MySqlDbType.Int64).Value = textBox2.Text;
            command.Parameters.Add("@type", MySqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@period", MySqlDbType.Int16).Value = 0;

            int currentyear = DateTime.Now.Year;
            int currentmonth = DateTime.Now.Month;
            string convertSQLDateTime = currentyear + "-" + currentmonth + "-" + DateTime.DaysInMonth(currentyear, currentmonth);
            command.Parameters.Add("@f_dateend", MySqlDbType.Date).Value = convertSQLDateTime;

            MySqlDataReader reader = command.ExecuteReader();

            MessageBox.Show("Сохранено!");

            reader.Close();
            db.closeConnection();
            this.Close();
            finances fin = new finances();
            fin.Show();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hint hint = new hint();
            hint.Show();
        }
    }
}
