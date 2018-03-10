using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Plik w przyszłości do rozszerzenia, prototyp


namespace Gra
{
    public partial class Menu : Form
    {
        Game game;

        public Menu()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Start.Visible = false; // uniewidacznia przycisk Start
            Start.Enabled = false; // wyłącza przycisk Start
            Quit.Visible = false; // analogicznie
            Quit.Enabled = false;
            Help.Visible = false;
            Help.Enabled = false;

            game = new Game(this); // zaczyna grę
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure?", "Quit", MessageBoxButtons.YesNo)) // zamyka program, jeśli w wyświetlonym oknie Quit wybrano Yes
            {
                this.Close();
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Controls"); // okienko Help, na razie z miejscem na sterowanie
        }

        private void Menu_KeyDown(object sender, KeyEventArgs e)
        {
            game.HandleKeyPress(e);
        }
    }
}
