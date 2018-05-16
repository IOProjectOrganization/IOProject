﻿using System;
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
        Quit quit2 = new Quit();
        Help help = new Help();

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

            panel1.Hide();
            label1.Hide();
            tableLayoutPanel2.Hide();
            tableLayoutPanel1.Hide();

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
            //if (DialogResult.Yes == MessageBox.Show("Na pewno?", "Wyjście", MessageBoxButtons.YesNo)) // zamyka program, jeśli w wyświetlonym oknie Quit wybrano Yes
            //{
            //    this.Close();
            //}
            quit2.Height = this.Height / 5;
            quit2.Width = this.Width / 4;
            quit2.PointToScreen(new Point(this.Width / 2, this.Height / 2));

            quit2.Show();
            quit2.sendForm(this);
            quit2.Focus();
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
            //MessageBox.Show("Controls"); // okienko Help, na razie z miejscem na sterowanie

            help.Height = this.Height / 5;
            help.Width = this.Width / 4;
            help.PointToScreen(new Point(this.Width / 2, this.Height / 2));

            help.Show();
            help.Focus();
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

        private void label1_SizeChanged(object sender, EventArgs e)
        {
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(fakeImage);


            SizeF extent = graphics.MeasureString(label1.Text, label1.Font);


            float hRatio = label1.Height / extent.Height;
            float wRatio = label1.Width / extent.Width;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = label1.Font.Size * ratio;

            label1.Font = new Font(label1.Font.FontFamily, newSize, label1.Font.Style);
        }

        private void Start_SizeChanged(object sender, EventArgs e)
        {
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(fakeImage);


            SizeF extent = graphics.MeasureString(Start.Text, Start.Font);


            float hRatio = Start.Height / extent.Height / 2;
            float wRatio = Start.Width / extent.Width / 2;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = Start.Font.Size * ratio;

            Start.Font = new Font(Start.Font.FontFamily, newSize, Start.Font.Style);
        }

        private void Help_SizeChanged(object sender, EventArgs e)
        {
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(fakeImage);


            SizeF extent = graphics.MeasureString(Help.Text, Help.Font);


            float hRatio = Help.Height / extent.Height / 2;
            float wRatio = Help.Width / extent.Width / 2;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = Help.Font.Size * ratio;

            Help.Font = new Font(Help.Font.FontFamily, newSize, Help.Font.Style);
        }

        private void Quit_SizeChanged(object sender, EventArgs e)
        {
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(fakeImage);


            SizeF extent = graphics.MeasureString(Quit.Text, Quit.Font);


            float hRatio = Quit.Height / extent.Height / 2;
            float wRatio = Quit.Width / extent.Width / 2;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = Quit.Font.Size * ratio;

            Quit.Font = new Font(Quit.Font.FontFamily, newSize, Quit.Font.Style);
        }

        private void axWindowsMediaPlayer1_KeyDownEvent(object sender, AxWMPLib._WMPOCXEvents_KeyDownEvent e)
        {
            if (game == null)
            {
                axWindowsMediaPlayer1.close();
                axWindowsMediaPlayer1.Visible = false;
                game = new Game(this); // zaczyna grę
                this.Focus();
            }
        }
    }
}