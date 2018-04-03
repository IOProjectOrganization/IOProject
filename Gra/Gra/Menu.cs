using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.DirectX.AudioVideoPlayback;
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

            //File.Copy(@"MapTileData\maptiles" + MapName + ".txt", @"MapTileData\maptiles" + MapName + "_1.txt", true)
            foreach (var file in System.IO.Directory.GetFiles(@"MapTileData"))
            {
                if (!file.Contains("1_"))
                    System.IO.File.Copy(file, System.IO.Path.Combine(@"MapTileData", "1_" + System.IO.Path.GetFileName(file)), true);
            }

            axWindowsMediaPlayer1.Visible = true;
            axWindowsMediaPlayer1.URL = @"intro.mp4";
            axWindowsMediaPlayer1.Dock = DockStyle.Fill;
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
            //this.TopMost = true;

            this.FormBorderStyle = FormBorderStyle.None;

            this.WindowState = FormWindowState.Maximized;

            axWindowsMediaPlayer1.Visible = false;
        }

        private void Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Controls"); // okienko Help, na razie z miejscem na sterowanie
        }

        private void Menu_KeyDown(object sender, KeyEventArgs e)
        {
            if (game == null)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    axWindowsMediaPlayer1.close();
                    axWindowsMediaPlayer1.Visible = false;
                    game = new Game(this); // zaczyna grę
                    this.Focus();
                }
            }
            else
                game.HandleKeyPress(e);
        }


        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (axWindowsMediaPlayer1.playState.Equals(WMPLib.WMPPlayState.wmppsMediaEnded))
            {
                axWindowsMediaPlayer1.close();
                axWindowsMediaPlayer1.Visible = false;
                game = new Game(this); // zaczyna grę
                this.Focus();
            }
        }
    }
}