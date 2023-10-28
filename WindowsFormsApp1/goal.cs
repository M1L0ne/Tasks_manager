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
            textBox4.Hide();
            DB db = new DB();
            db.openConnection();

            string sql = "SELECT id, g_name, g_cost, g_date from goal";

            MySqlCommand command = new MySqlCommand(sql, db.getConnection());
            MySqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
            }

            reader.Close();
            db.closeConnection();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.Hide();
            button2.Hide();
            textBox4.Show();
            int row = e.RowIndex + 1;
            int goalCost = 0;
            int finalsumm = 0;
            string goalDateEnd = "";
            button1.Enabled = false;
            button1.Visible = false;
            DB db = new DB();
            db.openConnection();

            string sql = "SELECT COUNT(*) FROM `goal`";

            MySqlCommand command = new MySqlCommand(sql, db.getConnection());
            MySqlDataReader reader = command.ExecuteReader();

            reader.Read();
            int goalsCount = reader.GetInt32(0);

            reader.Close();

            sql = "SELECT g_name,g_cost,g_date from goal where id = " + row;

            command = new MySqlCommand(sql, db.getConnection());
            reader = command.ExecuteReader();

            try
            {
                if (reader.Read())
                {
                    textBox1.Text = reader.GetString(0);
                    goalCost = reader.GetInt32(1);
                    textBox2.Text = goalCost.ToString();
                    goalDateEnd = reader.GetDateTime(2).ToString();
                    textBox3.Text = goalDateEnd;

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
                        textBox4.Hide();
                        button1.Enabled = true;
                        button1.Visible = true;
                    }
                }

            }
            finally
            {
                reader.Close();
            }

            sql = "SELECT type, name, cost, f_dateend from finances";

            command = new MySqlCommand(sql, db.getConnection());
            reader = command.ExecuteReader();


            while (reader.Read())
            {
                if (reader.GetString(0) == "+")
                {
                    finalsumm = finalsumm + reader.GetInt32(2);
                }
                else
                {
                    finalsumm = finalsumm - reader.GetInt32(2);
                }
            }


            int mounthToEndGoal = goalCost / finalsumm;
            int goalCostEachMonth = finalsumm / mounthToEndGoal;
            int yearsToEndGoal = mounthToEndGoal / 12;
            mounthToEndGoal = mounthToEndGoal % 12;

            textBox4.Text = "За месяц накоплено: " + finalsumm / goalsCount + "/" + goalCostEachMonth;
            if (goalCostEachMonth < finalsumm / goalsCount)
            {
                textBox4.Text = textBox4.Text + ". Выше плана!";
            }
            else
            {
                textBox4.Text = textBox4.Text + ". Надо стараться лучше!";
            }

            textBox4.Text = textBox4.Text + Environment.NewLine + Environment.NewLine + "С таким же сальдо через " + yearsToEndGoal + " лет и " + mounthToEndGoal + " месяца вы сможете осуществить свою мечту!";


            reader.Close();
            db.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            db.openConnection();
            MySqlCommand command;

            string sql = "INSERT INTO goal VALUES (id, @g_name,@g_cost,@g_date)";

            command = new MySqlCommand(sql, db.getConnection());

            command.Parameters.Add("@g_name", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@g_cost", MySqlDbType.Int64).Value = textBox2.Text;
            command.Parameters.Add("@g_date", MySqlDbType.DateTime).Value = textBox3.Text;
            

            MySqlDataReader reader = command.ExecuteReader();

            MessageBox.Show("Сохранено!");

            reader.Close();

            db.closeConnection();

            this.Close();
            goal goal = new goal();
            goal.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label4.Hide();
            textBox4.Hide();
            button1.Enabled = true;
            button1.Visible = true;
            dataGridView1.Hide();
            button2.Enabled = false;
            button2.Visible = false;
        }

        private void panel7_MouseClick(object sender, MouseEventArgs e)
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
