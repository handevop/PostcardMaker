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
    public partial class Form1 : Form
    {
        int prvo = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            richTextBox1.ForeColor = Color.Black;
            if (prvo == 1)
            {
                richTextBox1.Text = richTextBox1.Text.Substring(12);
                prvo = 0;
            }
        }

        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                richTextBox1.Text = "Pismo poruke";
                richTextBox1.ForeColor = Color.Gray;
                prvo = 1;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Razglednica");
            comboBox1.Items.Add("Sretan rođendan");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() == "Razglednica")
            {
                Form2 razglednica = new Form2(textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text,richTextBox1.Text);
                razglednica.Show();
            }
            else if (comboBox1.Text.Trim() == "Sretan rođendan")
            {
                Form3 rod = new Form3(richTextBox1.Text, textBox1.Text, textBox2.Text, textBox4.Text);
                rod.Show();
            }
            else
            {
                MessageBox.Show("Niste odabrali valjan događaj!");
            }
        }

        private Bitmap GetControlImage(Control ctl)
        {
            Bitmap bm = new Bitmap(ctl.Width, ctl.Height);
            ctl.DrawToBitmap(bm,
                new Rectangle(0, 0, ctl.Width, ctl.Height));
            return bm;
        }

        private Bitmap GetFormImageWithoutBorders(Form frm)
        {
            // Get the form's whole image.
            using (Bitmap whole_form = GetControlImage(frm))
            {
                // See how far the form's upper left corner is
                // from the upper left corner of its client area.
                Point origin = frm.PointToScreen(new Point(0, 0));
                int dx = origin.X - frm.Left;
                int dy = origin.Y - frm.Top;

                // Copy the client area into a new Bitmap.
                int wid = frm.ClientSize.Width;
                int hgt = frm.ClientSize.Height;
                Bitmap bm = new Bitmap(wid, hgt);
                using (Graphics gr = Graphics.FromImage(bm))
                {
                    gr.DrawImage(whole_form, 0, 0,
                        new Rectangle(dx, dy, wid, hgt),
                        GraphicsUnit.Pixel);
                }
                return bm;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "Razglednica")
                {
                    Form2 razglednica = new Form2(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, richTextBox1.Text);
                    razglednica.Show();

                    Bitmap bmp = GetFormImageWithoutBorders(razglednica);

                    razglednica.strana = (razglednica.strana + 1) % 2;
                    razglednica.pokazi();

                    SaveFileDialog saveImageDialog = new SaveFileDialog();
                    saveImageDialog.Title = "Select output file:";
                    saveImageDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
                    //saveImageDialog.FileName = printFileName;
                    if (saveImageDialog.ShowDialog() == DialogResult.OK)
                    {
                        bmp.Save(saveImageDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }

                    Bitmap bmp1 = GetFormImageWithoutBorders(razglednica);

                    SaveFileDialog saveImageDialog1 = new SaveFileDialog();
                    saveImageDialog1.Title = "Select output file:";
                    saveImageDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
                    //saveImageDialog.FileName = printFileName;
                    if (saveImageDialog1.ShowDialog() == DialogResult.OK)
                    {
                        bmp1.Save(saveImageDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
                else if (comboBox1.Text == "Sretan rođendan")
                {
                    Form3 rod = new Form3(richTextBox1.Text, textBox1.Text, textBox2.Text, textBox4.Text);
                    rod.Show();

                    Bitmap bmp = GetFormImageWithoutBorders(rod);

                    rod.mijenjaj = (rod.mijenjaj + 1) % 2;
                    rod.pozovi();

                    SaveFileDialog saveImageDialog = new SaveFileDialog();
                    saveImageDialog.Title = "Select output file:";
                    saveImageDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
                    //saveImageDialog.FileName = printFileName;
                    if (saveImageDialog.ShowDialog() == DialogResult.OK)
                    {
                        bmp.Save(saveImageDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }

                    Bitmap bmp1 = GetFormImageWithoutBorders(rod);

                    SaveFileDialog saveImageDialog1 = new SaveFileDialog();
                    saveImageDialog1.Title = "Select output file:";
                    saveImageDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
                    //saveImageDialog.FileName = printFileName;
                    if (saveImageDialog1.ShowDialog() == DialogResult.OK)
                    {
                        bmp1.Save(saveImageDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
                else
                {
                    MessageBox.Show("Niste odabrali valjani događaj!");
                }

            }
            catch
            {
                MessageBox.Show("Neuspješno spremanje");
            }
        }
    }
}
