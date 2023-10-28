using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class hint : Form
    {
        public hint()
        {
            InitializeComponent();
        }

        private void hint_Load(object sender, EventArgs e)
        {
            richTextBox1.Hide();


            DB db = new DB();
            db.openConnection();

            string sql = "SELECT h_id, h_name from hints";

            MySqlCommand command = new MySqlCommand(sql, db.getConnection());
            MySqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1));
            }

            reader.Close();
            db.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            db.openConnection();

            string sql = "SELECT h_id, h_name from hints WHERE h_name LIKE '%" + textBox1.Text + "%'";

            MySqlCommand command = new MySqlCommand(sql, db.getConnection());
            MySqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1));
            }

            reader.Close();
            db.closeConnection();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string row = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Hide();
            dataGridView1.Hide();
            button1.Hide();
            richTextBox1.Show();

            DB db = new DB();
            db.openConnection();

            string sql = "SELECT h_text from hints WHERE h_id = " + row;

            MySqlCommand command = new MySqlCommand(sql, db.getConnection());
            MySqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                richTextBox1.Rtf = reader.GetString(0);
            }

            reader.Close();
            db.closeConnection();


        }

        private void panel7_MouseClick(object sender, MouseEventArgs e)
        {
            richTextBox1.Hide();
            textBox1.Show();
            dataGridView1.Show();
            button1.Show();
        }
    }
}
