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
    public partial class goal : Form
    {
        public goal()
        {
            InitializeComponent();
        }

        private void goal_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button1.Visible = false;
            DB db = new DB();
            db.openConnection();

            string sql = "SELECT g_name,g_cost,g_date from goal";

            MySqlCommand command = new MySqlCommand(sql, db.getConnection());
            MySqlDataReader reader = command.ExecuteReader();

            try
            {
                if (reader.Read())
                {
                    textBox1.Text = reader.GetString(0);
                    textBox2.Text = reader.GetInt64(1).ToString();
                    textBox3.Text = reader.GetDateTime(2).ToString();

                }
                else
                {
                    DialogResult newgoal = MessageBox.Show("Цель не задана. Хотите задать новую цель?", "Моя цель", MessageBoxButtons.YesNo);
                    if (newgoal == DialogResult.No)
                    {
                        this.Close();
                    }
                    else
                    {
                        label4.Hide();
                        label5.Hide();
                        label7.Hide();
                        button1.Enabled = true;
                        button1.Visible = true;
                    }
                }

            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }
            db.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            db.openConnection();
            MySqlCommand command;

            string sql = "INSERT INTO goal VALUES (id, 0, @g_name,@g_cost,@g_date)";

            command = new MySqlCommand(sql, db.getConnection());

            command.Parameters.Add("@g_name", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@g_cost", MySqlDbType.Int64).Value = textBox2.Text;
            command.Parameters.Add("@g_date", MySqlDbType.DateTime).Value = textBox3.Text;
            

            MySqlDataReader reader = command.ExecuteReader();

            MessageBox.Show("Сохранено!");

            reader.Close();

            db.closeConnection();

            this.Close();
        }
    }
}
