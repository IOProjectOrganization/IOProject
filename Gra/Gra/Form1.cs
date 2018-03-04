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
    }
}
