using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gra
{
    public partial class Quit : Form
    {
        Form form;

        public Quit()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Quit_Load(object sender, EventArgs e)
        {
            button1.Scale(2);
            button2.Scale(2);
            label1.Scale(2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Close();
            form.Close();
        }
        public void sendForm(Form _form)
        {
            form = _form;
        }

        private void label1_SizeChanged(object sender, EventArgs e)
        {
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(fakeImage);


            SizeF extent = graphics.MeasureString(label1.Text, label1.Font);


            float hRatio = label1.Height / extent.Height * 2 / 3;
            float wRatio = label1.Width / extent.Width * 2 / 3;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = label1.Font.Size * ratio;

            label1.Font = new Font(label1.Font.FontFamily, newSize, label1.Font.Style);
        }

        private void button1_SizeChanged(object sender, EventArgs e)
        {
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(fakeImage);


            SizeF extent = graphics.MeasureString(button1.Text, button1.Font);


            float hRatio = button1.Height / extent.Height / 2;
            float wRatio = button1.Width / extent.Width / 2;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = button1.Font.Size * ratio;

            button1.Font = new Font(button1.Font.FontFamily, newSize, button1.Font.Style);
        }

        private void button2_SizeChanged(object sender, EventArgs e)
        {
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(fakeImage);


            SizeF extent = graphics.MeasureString(button2.Text, button2.Font);


            float hRatio = button2.Height / extent.Height / 2;
            float wRatio = button2.Width / extent.Width / 2;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = button2.Font.Size * ratio;

            button2.Font = new Font(button2.Font.FontFamily, newSize, button2.Font.Style);
        }
    }
}
