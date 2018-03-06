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
    public partial class Form1 : Form
    {
        Game game;

        public Form1()
        {
            InitializeComponent();

            game = new Game(this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // private void Form1_KeyDown(object sender, KeyEventArgs e)  //Kiedy probuje dodac event keydown to modyfikuja sie tez kilka innych plikow jak np form1 designer i zmieniaja tam size, nie wiem czy to poprawne
        // {                   
        //if (e.KeyCode == Keys.Right) zmiennaBohatera.RuchWPrawo();   
        //else if (e.KeyCode == Keys.Left) zmiennaBohatera.RuchWLewo();
        //else if (e.KeyCode == Keys.Up) zmiennaBohatera.RuchWGore();
        //else if (e.KeyCode == Keys.Down) zmiennaBohatera.RuchWDol();
        // }
    }
}
