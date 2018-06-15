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
    public partial class QuestNotification : Form
    {
        Timer timer = new Timer();
        Timer timer2 = new Timer();

        public QuestNotification()
        {
            InitializeComponent();

            timer.Tick += timer_Tick;
            timer.Interval = 5000;

            timer2.Tick += timer2_Tick;
            timer2.Interval = 10;

            Sound.PlaySound(Sound.Sound_questupdate);
            timer.Start();
            timer2.Start();
        }

        void timer_Tick(object sender, System.EventArgs e)
        {
            this.Close();
        }

        void timer2_Tick(object sender, System.EventArgs e)
        {
            if (this.Focused)
                if (Owner != null)
                    Owner.Focus();
        }
    }
}
