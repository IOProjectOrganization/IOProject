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
    public partial class Ending : Form
    {
        Form form;

        public Ending()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            Sound.StopSong();
        }

        public void UpdateEnding(bool state)
        {
            if (state == true)
            {
                pictureBox1.Image = Gra.Properties.Resources.victory;
                Sound.PlaySong(Sound.Song_victory);
            }
            else
            {
                pictureBox1.Image = Gra.Properties.Resources.gameover;
                Sound.PlaySong(Sound.Song_lost);
            }
        }

        public void sendForm(Form _form)
        {
            form = _form;
        }

        private void Ending_KeyDown(object sender, KeyEventArgs e)
        {
            form.Close();
        }
    }
}
