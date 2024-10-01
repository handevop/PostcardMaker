using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Postcard
{
    public partial class Form3 : Form
    {
        public int mijenjaj = 0;
        public Form3(string pismo , string ime , string prezime , string adresa)
        {
            InitializeComponent();
            pozovi();
            richTextBox1.Text = pismo + '\n' + "Za " + ime + ' ' + prezime + '\n' + "Na adresi " + adresa
                + '\n' + "Dana " + Convert.ToString(DateTime.Now.Date);
        }

        public void pozovi()
        {
            if (mijenjaj == 1)
            {
                pictureBox1.Hide();
                richTextBox1.Show();
                pictureBox2.Show();
            }
            else
            {
                pictureBox1.Show();
                richTextBox1.Hide();
                pictureBox2.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mijenjaj = (mijenjaj + 1) % 2;
            pozovi();
        }
    }
}
