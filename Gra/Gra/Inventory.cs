﻿using System;
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
    public partial class Inventory : Form
    {
        Game game;

        public Inventory()
        {
            InitializeComponent();

            game = new Game(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
