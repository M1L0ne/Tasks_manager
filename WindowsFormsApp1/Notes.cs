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
using Org.BouncyCastle.Utilities;
using static System.Net.Mime.MediaTypeNames;


namespace WindowsFormsApp1
{
    public partial class Notes : Form
    {
        DateTime dateTime = DateTime.Now;
        int idCheck;
        public Notes(int row)
        {
            InitializeComponent();
            if (row > 0)
            {
                DB db = new DB();
                db.openConnection();

                string sql = "SELECT * from notes WHERE id = @row";


                MySqlCommand command = new MySqlCommand(sql, db.getConnection());
                command.Parameters.Add("@row", MySqlDbType.Int16).Value = row;

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text = reader.GetString(1);
                    richTextBox1.Rtf = reader.GetString(2);
                    label1.Text = reader.GetString(3);
                }

                idCheck = row;
                reader.Close();
                db.closeConnection();
            }
            else
            {
                label1.Text = dateTime.ToString();
            }    
        }

        public void Notes_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isItalic = richTextBox1.SelectionFont != null && richTextBox1.SelectionFont.Italic;
            if (isItalic)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style & ~FontStyle.Italic);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Italic);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool isBold = richTextBox1.SelectionFont != null && richTextBox1.SelectionFont.Bold;
            if (isBold)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style & ~FontStyle.Bold);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Bold);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string formattedText = richTextBox1.Rtf;

            DB db = new DB();
            db.openConnection();
            MySqlCommand command;

            if (idCheck == 0)
            {
                string sql = "INSERT INTO notes VALUES (id, @title,@text,@datetime)";

                command = new MySqlCommand(sql, db.getConnection());

                command.Parameters.Add("@title", MySqlDbType.VarChar).Value = textBox1.Text;
                command.Parameters.Add("@text", MySqlDbType.Text).Value = formattedText;
                command.Parameters.Add("@datetime", MySqlDbType.DateTime).Value = dateTime;
            }
            else
            {
                string sql = "UPDATE notes SET title = @title, text = @text, datetime = @datetime WHERE id = @id";

                command = new MySqlCommand(sql, db.getConnection());

                command.Parameters.Add("@id", MySqlDbType.Int64).Value = idCheck;
                command.Parameters.Add("@title", MySqlDbType.VarChar).Value = textBox1.Text;
                command.Parameters.Add("@text", MySqlDbType.Text).Value = formattedText;
                command.Parameters.Add("@datetime", MySqlDbType.DateTime).Value = dateTime;
            }

            MySqlDataReader reader = command.ExecuteReader();

            MessageBox.Show("Сохранено!");

            reader.Close();

            db.closeConnection();
        }
    }
    
}
