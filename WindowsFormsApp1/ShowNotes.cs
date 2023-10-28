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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class ShowNotes : Form
    {
        public ShowNotes()
        {
            InitializeComponent();
        }

        private void ShowNotes_Load(object sender, EventArgs e)
        {
            DB db = new DB();
            db.openConnection();

            string sql = "SELECT ID, title, datetime from notes";

            MySqlCommand command = new MySqlCommand(sql, db.getConnection());
            MySqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2));
            }

            reader.Close();
            db.closeConnection();
        
    }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            int row = e.RowIndex + 1;

            Notes notes = new Notes(row);
            notes.Show();
            this.Close();
            /*Notes.Notes_Load(sender, row);*/
        }
    }
}
