﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Gra
{
    public partial class Dialog : Form
    {
        float TBHeight;

        Bohater postac;
        PrzyjaznyNPC npc;

        QuestNotification questNotification;

        StreamReader Reader;
        string line;
        int i = 0;
        int j = 0;

        bool PlayerIsTalking;

        public Dialog()
        {
            InitializeComponent();

            TBHeight = textBox1.Height;
        }

        public void UpdateDialog(Bohater Player, PrzyjaznyNPC Npc)
        {
            postac = Player;
            npc = Npc;

            PlayerPB.Image = postac.getDialogImage();
            NPCPB.Image = npc.getDialogImage();

            PlayerName.Text = "Godric";
            NPCName.Text = npc.getNazwa();

            if (npc.getActiveQuestID() > 0)
            {
                for (i = 0; ; i++)
                {
                    if (npc.Questy.ElementAt(i).getIsActive())
                        break;
                }

                if (npc.Questy.ElementAt(i).getDialogOccured() == false)
                {
                    Reader = new StreamReader(@"Dialogs\Quest" + npc.getActiveQuestID() + npc.Questy.ElementAt(i).getStatus().ToString() + ".txt");
                    if (!Reader.EndOfStream)
                    {
                        line = Reader.ReadLine();

                        if (line == npc.getId().ToString())
                        {
                            line = Reader.ReadLine();
                            if (line != "PLAYER" && line != "NPC" && line != "NEWQUEST" && line != "UPDATEQUEST" && line != "UPDATEFAKE" && line != "STARTNEWDIALOG")
                                Player.ChangeQuestDescription(npc.getActiveQuestID(), line);

                            while (line != "PLAYER" && line != "NPC")
                                line = Reader.ReadLine();

                            if (line == "PLAYER")
                            {
                                textBox1.Text = "Godric" + Environment.NewLine;
                                PlayerIsTalking = true;
                            }
                            else if (line == "NPC")
                            {
                                textBox1.Text = npc.getNazwa() + Environment.NewLine;
                                PlayerIsTalking = false;
                            }

                            line = Reader.ReadLine();

                            while (line != "PLAYER" && line != "NPC")
                            {
                                if (!Reader.EndOfStream)
                                {
                                    if (line == "\n")
                                        textBox1.Text += Environment.NewLine;
                                    else if (line == "NEWQUEST")
                                    {
                                        bool found = false;

                                        foreach (Quest quest in Player.quests)
                                            if (quest.getId() == npc.Questy.ElementAt(i).getId() && quest.getIsActive() == true && quest.getStatus() != QuestStatus.Complited)
                                                found = true;

                                        if (!found)
                                        {
                                            for (i = 0; i < npc.Questy.Count; i++)
                                            {
                                                if (npc.Questy.ElementAt(i).getIsActive())
                                                    break;
                                            }
                                            Player.AddQuest(npc.Questy.ElementAt(i).getId());
                                            Player.ChangeQuestIsActive(npc.Questy.ElementAt(i).getId(), true);
                                            Player.ChangeQuestStatus(npc.Questy.ElementAt(i).getId(), QuestStatus.Active);
                                            questNotification = new QuestNotification();
                                            questNotification.Size = new Size(DesktopBounds.Width / 5, DesktopBounds.Height * 3 / 7);
                                            questNotification.DesktopLocation = new Point(DesktopBounds.Width * 2 / 5, DesktopBounds.Height / 16);
                                            questNotification.Show();
                                            questNotification.Owner = Owner;
                                            this.Focus();
                                            this.Activate();
                                        }
                                    }
                                    else if (line == "UPDATEQUEST")
                                    {
                                        bool found = false;

                                        foreach (Quest quest in Player.quests)
                                            if (quest.getId() == npc.Questy.ElementAt(i).getId())
                                                found = true;

                                        if (found)
                                        {
                                            Player.UpdateQuestStatus(npc.Questy.ElementAt(i).getId());
                                            //npc.UpdateQuestStatus(npc.Questy.ElementAt(i).getId());
                                            questNotification = new QuestNotification();
                                            questNotification.Size = new Size(DesktopBounds.Width / 5, DesktopBounds.Height * 3 / 7);
                                            questNotification.DesktopLocation = new Point(DesktopBounds.Width * 2 / 5, DesktopBounds.Height / 16);
                                            questNotification.Show();
                                            questNotification.Owner = Owner;
                                            this.Focus();
                                            this.Activate();
                                        }
                                    }
                                    else if (line == "UPDATEFAKE")
                                    {
                                        questNotification = new QuestNotification();
                                        questNotification.Size = new Size(DesktopBounds.Width / 5, DesktopBounds.Height * 3 / 7);
                                        questNotification.DesktopLocation = new Point(DesktopBounds.Width * 2 / 5, DesktopBounds.Height / 16);
                                        questNotification.Show();
                                        questNotification.Owner = Owner;
                                        this.Focus();
                                        this.Activate();
                                    }
                                    else if (line == "STARTNEWDIALOG")
                                    {
                                        Dialog dialog = new Dialog();
                                        dialog.Size = new Size(this.Width, this.Height);
                                        dialog.DesktopLocation = new Point(0, this.Location.Y);
                                        dialog.UpdateDialog(Player, npc);
                                        dialog.Show();
                                        dialog.Focus();

                                        this.Close();
                                    }
                                    else
                                        textBox1.Text = textBox1.Text + line;

                                    line = Reader.ReadLine();
                                }
                                else
                                {
                                    //npc.Questy.ElementAt(i).setDialogOccured(true);

                                    if (line == "NEWQUEST")
                                    {
                                        bool found = false;

                                        foreach (Quest quest in Player.quests)
                                            if (quest.getId() == npc.Questy.ElementAt(i).getId() && quest.getIsActive() == true && quest.getStatus() != QuestStatus.Complited)
                                                found = true;

                                        if (!found)
                                        {
                                            for (i = 0; i < npc.Questy.Count; i++)
                                            {
                                                if (npc.Questy.ElementAt(i).getIsActive())
                                                    break;
                                            }
                                            Player.AddQuest(npc.Questy.ElementAt(i).getId());
                                            Player.ChangeQuestIsActive(npc.Questy.ElementAt(i).getId(), true);
                                            Player.ChangeQuestStatus(npc.Questy.ElementAt(i).getId(), QuestStatus.Active);
                                            questNotification = new QuestNotification();
                                            questNotification.Size = new Size(DesktopBounds.Width / 5, DesktopBounds.Height * 3 / 7);
                                            questNotification.DesktopLocation = new Point(DesktopBounds.Width * 2 / 5, DesktopBounds.Height / 16);
                                            questNotification.Show();
                                            questNotification.Owner = Owner;
                                            this.Focus();
                                            this.Activate();
                                        }
                                    }
                                    else if (line == "UPDATEQUEST")
                                    {
                                        bool found = false;

                                        foreach (Quest quest in Player.quests)
                                            if (quest.getId() == npc.Questy.ElementAt(i).getId())
                                                found = true;

                                        if (found)
                                        {
                                            Player.UpdateQuestStatus(npc.Questy.ElementAt(i).getId());
                                            //npc.UpdateQuestStatus(npc.Questy.ElementAt(i).getId());
                                            questNotification = new QuestNotification();
                                            questNotification.Size = new Size(DesktopBounds.Width / 5, DesktopBounds.Height * 3 / 7);
                                            questNotification.DesktopLocation = new Point(DesktopBounds.Width * 2 / 5, DesktopBounds.Height / 16);
                                            questNotification.Show();
                                            questNotification.Owner = Owner;
                                            this.Focus();
                                            this.Activate();
                                        }
                                    }
                                    else if (line == "UPDATEFAKE")
                                    {
                                        questNotification = new QuestNotification();
                                        questNotification.Size = new Size(DesktopBounds.Width / 5, DesktopBounds.Height * 3 / 7);
                                        questNotification.DesktopLocation = new Point(DesktopBounds.Width * 2 / 5, DesktopBounds.Height / 16);
                                        questNotification.Show();
                                        questNotification.Owner = Owner;
                                        this.Focus();
                                        this.Activate();
                                    }
                                    else if (line == "STARTNEWDIALOG")
                                    {
                                        Dialog dialog = new Dialog();
                                        dialog.Size = new Size(this.Width, this.Height);
                                        dialog.DesktopLocation = new Point(0, this.Location.Y);
                                        dialog.UpdateDialog(Player, npc);
                                        dialog.Show();
                                    }
                                    else
                                        textBox1.Text = textBox1.Text + line;
                                    break;
                                }
                            }
                        }
                        else
                            textBox1.Text = npc.getEndingLine();
                    }
                }
                else
                    textBox1.Text = npc.getEndingLine();
            }
            else
                textBox1.Text = npc.getEndingLine();
        }

        private void PlayerName_SizeChanged(object sender, EventArgs e)
        {
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(fakeImage);

            SizeF extent = graphics.MeasureString(PlayerName.Text, PlayerName.Font);

            float hRatio = PlayerName.Height / extent.Height / 2;
            float wRatio = PlayerName.Width / extent.Width / 2;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = PlayerName.Font.Size * ratio;

            PlayerName.Font = new Font(PlayerName.Font.FontFamily, newSize, PlayerName.Font.Style);
        }

        private void NPCName_SizeChanged(object sender, EventArgs e)
        {
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(fakeImage);

            SizeF extent = graphics.MeasureString(NPCName.Text, NPCName.Font);

            float hRatio = NPCName.Height / extent.Height / 2;
            float wRatio = NPCName.Width / extent.Width / 2;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = NPCName.Font.Size * ratio;

            NPCName.Font = new Font(NPCName.Font.FontFamily, newSize, NPCName.Font.Style);
        }

        private void textBox1_SizeChanged(object sender, EventArgs e)
        {
            float ratio = textBox1.Size.Height / TBHeight;
            textBox1.Font = new Font(textBox1.Font.FontFamily, textBox1.Font.Size * ratio, textBox1.Font.Style);
            TBHeight = textBox1.Height;
        }

        private void Dialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (Reader != null)
                    Reader.Close();
                this.Close();
            }
            else if (e.KeyCode == Keys.Space)
            {
                ReadDialog(postac, npc);
            }
        }
        
        private void Dialog_Click(object sender, EventArgs e)
        {
            ReadDialog(postac, npc);
        }

        private void ReadDialog(Bohater Player, PrzyjaznyNPC Npc)
        {
            if (textBox1.Text == npc.getEndingLine())
                this.Close();

            else if (!Reader.EndOfStream)
            {
                if (line == "PLAYER")
                {
                    textBox1.Text = "Godric" + Environment.NewLine;
                    PlayerIsTalking = true;
                    line = Reader.ReadLine();
                }
                else if (line == "NPC")
                {
                    textBox1.Text = npc.getNazwa() + Environment.NewLine;
                    PlayerIsTalking = false;
                    line = Reader.ReadLine();
                }

                while (line != "PLAYER" && line != "NPC")
                {
                    if (!Reader.EndOfStream)
                    {
                        if (line == "\\n")
                            textBox1.Text = textBox1.Text + Environment.NewLine;
                        else if (line == "NEWQUEST")
                        {
                            bool found = false;

                            foreach (Quest quest in Player.quests)
                                if (quest.getId() == npc.Questy.ElementAt(i).getId())
                                    found = true;

                            if (!found)
                            {
                                Player.AddQuest(npc.Questy.ElementAt(i).getId());
                                Player.ChangeQuestIsActive(npc.Questy.ElementAt(i).getId(), true);
                                Player.ChangeQuestStatus(npc.Questy.ElementAt(i).getId(), QuestStatus.Active);
                                questNotification = new QuestNotification();
                                questNotification.Size = new Size(DesktopBounds.Width / 5, DesktopBounds.Height * 3 / 7);
                                questNotification.DesktopLocation = new Point(DesktopBounds.Width * 2 / 5, DesktopBounds.Height / 16);
                                questNotification.Show();
                                questNotification.Owner = Owner;
                                this.Focus();
                                this.Activate();
                            }
                        }
                        else if (line == "UPDATEQUEST")
                        {
                            bool found = false;

                            foreach (Quest quest in Player.quests)
                                if (quest.getId() == npc.Questy.ElementAt(i).getId())
                                    found = true;

                            if (found)
                            {
                                Player.UpdateQuestStatus(npc.Questy.ElementAt(i).getId());
                                //npc.UpdateQuestStatus(npc.Questy.ElementAt(i).getId());
                                questNotification = new QuestNotification();
                                questNotification.Size = new Size(DesktopBounds.Width / 5, DesktopBounds.Height * 3 / 7);
                                questNotification.DesktopLocation = new Point(DesktopBounds.Width * 2 / 5, DesktopBounds.Height / 16);
                                questNotification.Show();
                                questNotification.Owner = Owner;
                                this.Focus();
                                this.Activate();
                            }
                        }
                        else if (line == "UPDATEFAKE")
                        {
                            questNotification = new QuestNotification();
                            questNotification.Size = new Size(DesktopBounds.Width / 5, DesktopBounds.Height * 3 / 7);
                            questNotification.DesktopLocation = new Point(DesktopBounds.Width * 2 / 5, DesktopBounds.Height / 16);
                            questNotification.Show();
                            questNotification.Owner = Owner;
                            this.Focus();
                            this.Activate();
                        }
                        else if (line == "STARTNEWDIALOG")
                        {
                            Dialog dialog = new Dialog();
                            dialog.Size = new Size(this.Width, this.Height);
                            dialog.DesktopLocation = new Point(0, this.Location.Y);
                            dialog.UpdateDialog(Player, npc);
                            dialog.Show();
                            dialog.Focus();

                            this.Close();
                        }
                        else
                            textBox1.Text = textBox1.Text + line;

                        line = Reader.ReadLine();
                    }
                    else
                    {
                        npc.Questy.ElementAt(i).setDialogOccured(true);

                        if (line == "NEWQUEST")
                        {
                            bool found = false;

                            foreach (Quest quest in Player.quests)
                                if (quest.getId() == npc.Questy.ElementAt(i).getId())
                                    found = true;

                            if (!found)
                            {
                                Player.AddQuest(npc.Questy.ElementAt(i).getId());
                                Player.ChangeQuestIsActive(npc.Questy.ElementAt(i).getId(), true);
                                Player.ChangeQuestStatus(npc.Questy.ElementAt(i).getId(), QuestStatus.Active);
                                questNotification = new QuestNotification();
                                questNotification.Size = new Size(DesktopBounds.Width / 5, DesktopBounds.Height * 3 / 7);
                                questNotification.DesktopLocation = new Point(DesktopBounds.Width * 2 / 5, DesktopBounds.Height / 16);
                                questNotification.Show();
                                questNotification.Owner = Owner;
                                this.Focus();
                                this.Activate();
                            }
                        }
                        else if (line == "UPDATEQUEST")
                        {
                            bool found = false;

                            foreach (Quest quest in Player.quests)
                                if (quest.getId() == npc.Questy.ElementAt(i).getId())
                                    found = true;

                            if (found)
                            {
                                Player.UpdateQuestStatus(npc.Questy.ElementAt(i).getId());
                                //npc.UpdateQuestStatus(npc.Questy.ElementAt(i).getId());
                                questNotification = new QuestNotification();
                                questNotification.Size = new Size(DesktopBounds.Width / 5, DesktopBounds.Height * 3 / 7);
                                questNotification.DesktopLocation = new Point(DesktopBounds.Width * 2 / 5, DesktopBounds.Height / 16);
                                questNotification.Show();
                                questNotification.Owner = Owner;
                                this.Focus();
                                this.Activate();
                            }
                        }
                        else if (line == "UPDATEFAKE")
                        {
                            questNotification = new QuestNotification();
                            questNotification.Size = new Size(DesktopBounds.Width / 5, DesktopBounds.Height * 3 / 7);
                            questNotification.DesktopLocation = new Point(DesktopBounds.Width * 2 / 5, DesktopBounds.Height / 16);
                            questNotification.Show();
                            questNotification.Owner = Owner;
                            this.Focus();
                            this.Activate();
                            //npc.Questy.ElementAt(i).setDialogOccured(false);
                        }
                        else if (line == "STARTNEWDIALOG")
                        {
                            Dialog dialog = new Dialog();
                            dialog.Size = new Size(this.Width, this.Height);
                            dialog.DesktopLocation = new Point(0, this.Location.Y);
                            dialog.UpdateDialog(Player, npc);
                            dialog.Show();
                        }
                        else
                            textBox1.Text = textBox1.Text + line;

                        break;
                    }
                }
            }
            else
            {
                foreach (Quest _quest in Player.quests)
                {
                    if (_quest.getId() == Task.questId_Danger)
                    {
                        if (_quest.getStatus() == QuestStatus.Complited)
                        {
                            Ending ending = new Ending();
                            ending.Size = new Size(DesktopBounds.Width, DesktopBounds.Height);
                            ending.sendForm(Owner);
                            ending.UpdateEnding(true);
                            ending.Show();
                            ending.Focus();
                        }
                    }
                }
                this.Close();
            }
        }
    }
}
