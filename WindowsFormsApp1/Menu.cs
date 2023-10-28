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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Notes notes = new Notes(0);
            notes.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowNotes notes = new ShowNotes();
            notes.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Calculator calculator = new Calculator();
            calculator.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Calendar calendar = new Calendar();
            calendar.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            finances finances = new finances();
            finances.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            goal goal = new goal();
            goal.Show();
        }
    }
}
