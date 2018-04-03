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
    public partial class Equipment : Form
    {
        public Equipment()
        {
            InitializeComponent();
        }

        private void Equipment_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;

            this.FormBorderStyle = FormBorderStyle.None;
        }

        public void UpdateEquipment(Bohater Player)
        {
            listBox1.Items.Clear();

            int i = 0;

            foreach (Przedmiot item in Player.Ekwipunek)
            {
                listBox1.Items.Add(Player.Ekwipunek.ElementAt(i).getNazwa().ToString() + " - " + Player.Ekwipunek.ElementAt(i).getIlosc().ToString());
                i++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Equipment_KeyDown(object sender, KeyEventArgs e)
        {
            this.Hide();
        }
    }
}
