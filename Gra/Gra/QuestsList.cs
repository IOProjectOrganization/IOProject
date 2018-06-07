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
    public partial class QuestsList : Form
    {
        float TBHeight;
        float LBHeight;

        Bohater postac;
        List<Quest> quests = new List<Quest>();

        public QuestsList()
        {
            InitializeComponent();

            TBHeight = textBox1.Height;
            LBHeight = listBox1.Height;
        }

        private void QuestsList_Load(object sender, EventArgs e)
        {
            label1.Scale(2);
            button1.Scale(2);
            listBox1.Scale(2);
            textBox1.Scale(2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
            this.Close();
        }

        public void UpdateQuestsList(Bohater Player)
        {
            postac = Player;
            
            listBox1.Items.Clear();
            quests.Clear();

            int i = 0;
            foreach (Quest quest in Player.quests)
            {
                if ((quest.getIsActive() == true && (quest.getStatus() == QuestStatus.Active || quest.getStatus() == QuestStatus.Success)) || (quest.getIsActive() == false && quest.getStatus() == QuestStatus.Complited))
                {
                    quests.Add(quest);
                    listBox1.Items.Add(Player.quests.ElementAt(i).getName().ToString() + "\t\t\t\t" + Player.quests.ElementAt(i).getStatus().ToString());
                }

                i++;
            }
        }

        /*private void scaleFont(Label lab)
        {
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(fakeImage);


            SizeF extent = graphics.MeasureString(lab.Text, lab.Font);


            float hRatio = lab.Height / extent.Height;
            float wRatio = lab.Width / extent.Width;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = lab.Font.Size * ratio;
            
            lab.Font = new Font(lab.Font.FontFamily, newSize, lab.Font.Style);
        }*/

        private void button1_SizeChanged(object sender, EventArgs e)
        {
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(fakeImage);


            SizeF extent = graphics.MeasureString(button1.Text, button1.Font);


            float hRatio = button1.Height / extent.Height / 2;
            float wRatio = button1.Width / extent.Width / 2;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = button1.Font.Size * ratio;

            button1.Font = new Font(button1.Font.FontFamily, newSize, button1.Font.Style);
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

        private void textBox1_SizeChanged(object sender, EventArgs e)
        {
            float ratio = textBox1.Size.Height / TBHeight;
            textBox1.Font = new Font(textBox1.Font.FontFamily, textBox1.Font.Size * ratio, textBox1.Font.Style);
            TBHeight = textBox1.Height;
        }

        private void listBox1_SizeChanged(object sender, EventArgs e)
        {
            float ratio = listBox1.Size.Height / LBHeight;
            listBox1.Font = new Font(listBox1.Font.FontFamily, listBox1.Font.Size * ratio, listBox1.Font.Style);
            LBHeight = listBox1.Height;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
                textBox1.Text = "";
            else
            {
                textBox1.Text = quests.ElementAt(listBox1.SelectedIndex).getDescription().ToString();

                if (quests.ElementAt(listBox1.SelectedIndex).GetType() == typeof(QuestKillEnemy))
                {
                    QuestKillEnemy _quest = quests.ElementAt(listBox1.SelectedIndex) as QuestKillEnemy;

                    textBox1.Text += Environment.NewLine;
                    textBox1.Text += Environment.NewLine;

                    textBox1.Text += _quest.GetEnemiesKilled().ToString() + " / " + _quest.GetEnemiesToKill().ToString();
                }
            }
        }

        private void QuestsList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                listBox1.ClearSelected();
                this.Close();
            }
        }
    }
}