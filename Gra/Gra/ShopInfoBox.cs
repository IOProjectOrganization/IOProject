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

        public void checkTradeState(bool state, string itemName)
        {
            if(state == false)
            {
                tradeInfo.Text = "Zakupiono:\t" + itemName;
            }
            else
            {
                tradeInfo.Text = "Sprzedano:\t" + itemName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
