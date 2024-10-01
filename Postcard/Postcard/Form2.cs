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
    public partial class Form2 : Form
    {
        public int strana = 0;

        public Form2(string Ime , string Prezime , string adresaDol , string adresaKud , string pismo)
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            pokazi();
            textBox2.Text = Ime + ' ' + Prezime;
            textBox3.Text = adresaDol;
            textBox1.Text = adresaKud;
            textBox4.Text = Convert.ToString(DateTime.Now);
            richTextBox1.Text = pismo;
        }

        public void pokazi()
        {
            if (strana == 1)
            {
                pictureBox1.Hide();
                textBox3.Show();
                label3.Show();
                textBox1.Show();
                textBox2.Show();
                textBox4.Show();
                label1.Show();
                label2.Show();
                label4.Show();
                richTextBox1.Show();
                pictureBox2.Show();
            }
            else
            {
                pictureBox1.Show();
                textBox3.Hide();
                label3.Hide();
                textBox1.Hide();
                textBox2.Hide();
                textBox4.Hide();
                label1.Hide();
                label2.Hide();
                label4.Hide();
                richTextBox1.Hide();
                pictureBox2.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            strana = (strana + 1) % 2;
            pokazi();
        }
    }
}
