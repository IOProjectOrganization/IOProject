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
    public partial class ShopInfoBox : Form
    {
        public ShopInfoBox()
        {
            InitializeComponent();
        }

        private void ShopInfoBox_Load(object sender, EventArgs e)
        {
            tradeInfo.Scale(2);
            button1.Scale(2);
        }

        public void checkTradeState(bool state, string itemName)
        {
            if(state == false)
            {
                tradeInfo.Text = "Zakupiono:\t " + itemName;
            }
            else
            {
                tradeInfo.Text = "Sprzedano:\t " + itemName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tradeInfo_SizeChanged(object sender, EventArgs e)
        {
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(fakeImage);


            SizeF extent = graphics.MeasureString(tradeInfo.Text, tradeInfo.Font);


            float hRatio = tradeInfo.Height / extent.Height * 2 / 3;
            float wRatio = tradeInfo.Width / extent.Width * 2 / 3;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = tradeInfo.Font.Size * ratio;

            tradeInfo.Font = new Font(tradeInfo.Font.FontFamily, newSize, tradeInfo.Font.Style);
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

        private void ShopInfoBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
