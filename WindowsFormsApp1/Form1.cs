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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Menu menu = new Menu();
            menu.Show();

        }


        private void button1_Click(object sender, EventArgs e)
        {

            DB db = new DB();
            db.openConnection();

            string sql = "SELECT login,password FROM users";

            MySqlCommand command = new MySqlCommand(sql, db.getConnection());
            MySqlDataReader reader = command.ExecuteReader();

            string loginGet, passwordGet;
            string loginWrite = textBox1.Text;
            string passwordWrite = textBox2.Text;

            while (reader.Read())
            {
                loginGet = reader[0].ToString();
                passwordGet = reader[1].ToString();

                if (loginGet == loginWrite && passwordGet == passwordWrite)
                {
                    Menu menu = new Menu();
                    menu.Show();
                    this.Hide();
                }
            }

            reader.Close();
            db.closeConnection();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
