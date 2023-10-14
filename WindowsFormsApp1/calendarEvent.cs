using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp1
{
    public partial class calendarEvent : Form
    {
        int dayg, monthg, yearg;

        public calendarEvent(int day, int month, int year)
        {
            InitializeComponent();
            dayg = day;
            monthg = month;
            yearg = year;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            db.openConnection();

            string sql = "SELECT COUNT(*) from c_events WHERE ce_date = '" + yearg + "-" + monthg + "-" + dayg + "'";
            MySqlCommand command = new MySqlCommand(sql, db.getConnection());

            int result = int.Parse(command.ExecuteScalar().ToString());
            if (result == 0)
            {

                sql = "INSERT INTO c_events VALUES (@descr, @date)";

            }
            else
            {
                sql = "UPDATE c_events SET ce_description = @descr WHERE ce_date = @date";

            }

            command = new MySqlCommand(sql, db.getConnection());

            command.Parameters.Add("@descr", MySqlDbType.Text).Value = textBox1.Text;
            command.Parameters.Add("@date", MySqlDbType.DateTime).Value = yearg + "-" + monthg + "-" + dayg;
            
            MySqlDataReader reader = command.ExecuteReader();
            MessageBox.Show("Сохранено!");

            reader.Close();
            db.closeConnection();
        }

        private void calendarEvent_Load(object sender, EventArgs e)
        {
            DB db = new DB();
            db.openConnection();

            string sql = "SELECT ce_description FROM c_events WHERE ce_date = '" + yearg + "-" + monthg + "-" + dayg + "'";
            MySqlCommand command = new MySqlCommand(sql, db.getConnection());
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                textBox1.Text = reader.GetString(0);
            }

            reader.Close();
            db.closeConnection();
        }
    }
}
