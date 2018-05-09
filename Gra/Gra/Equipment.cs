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
    public partial class Equipment : Form
    {
        Bohater postac;

        public Equipment()
        {
            InitializeComponent();
        }

        private void Equipment_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
        }

        public void UpdateEquipment(Bohater Player)
        {
            postac = Player;

            setTextColor();

            listBox1.Items.Clear();

            int i = 0;

            foreach (Przedmiot item in Player.Ekwipunek)
            {
                if(Player.Ekwipunek.ElementAt(i).getIlosc() > 0)
                listBox1.Items.Add(Player.Ekwipunek.ElementAt(i).getNazwa().ToString() + " - " + Player.Ekwipunek.ElementAt(i).getIlosc().ToString());
                i++;
            }

            bohaterHP.Text = Player.GetHP().ToString();
            bohaterMP.Text = Player.GetMP().ToString();
            bohaterHPMax.Text = Player.GetMaxHP().ToString();
            bohaterMPMax.Text = Player.GetMaxMP().ToString();

            bohaterLevel.Text = Player.GetLevel().ToString();
            bohaterPunktyD.Text = Player.GetSkillpoints().ToString();

            bohaterZloto.Text = Player.GetGold().ToString();

            bohaterInteligencja.Text = Player.GetIntelligence().ToString();
            bohaterZrecznosc.Text = Player.GetDexterity().ToString();
            bohaterSila.Text = Player.GetStrength().ToString();

            bohaterExp.Maximum = Player.GetEXPtoLevel();
            bohaterExp.Value = Player.GetEXP();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Equipment_KeyDown(object sender, KeyEventArgs e)
        {
            this.Hide();
        }

        private void setTextColor()
        {
            //var pos = this.PointToScreen(bohaterHP.Location);
            //pos = pictureBox1.PointToClient(pos);
            //bohaterHP.Parent = pictureBox1;
            //bohaterHP.Location = pos;
            bohaterHP.ForeColor = Color.Black;
            bohaterHP.BackColor = pictureBox1.BackColor;

            //pos = this.PointToScreen(bohaterMP.Location);
            //pos = pictureBox1.PointToClient(pos);
            //bohaterMP.Parent = pictureBox1;
            //bohaterMP.Location = pos;
            bohaterMP.ForeColor = Color.Black;
            bohaterMP.BackColor = pictureBox1.BackColor;

            //pos = this.PointToScreen(bohaterHPMax.Location);
            //pos = pictureBox1.PointToClient(pos);
            //bohaterHPMax.Parent = pictureBox1;
            //bohaterHPMax.Location = pos;
            bohaterHPMax.ForeColor = Color.Black;
            bohaterHPMax.BackColor = pictureBox1.BackColor;

            //pos = this.PointToScreen(bohaterMPMax.Location);
            //pos = pictureBox1.PointToClient(pos);
            //bohaterMPMax.Parent = pictureBox1;
            //bohaterMPMax.Location = pos;
            bohaterMPMax.ForeColor = Color.Black;
            bohaterMPMax.BackColor = pictureBox1.BackColor;

            //pos = this.PointToScreen(bohaterZloto.Location);
            //pos = pictureBox1.PointToClient(pos);
            //bohaterZloto.Parent = pictureBox1;
            //bohaterZloto.Location = pos;
            bohaterZloto.ForeColor = Color.Black;
            bohaterZloto.BackColor = pictureBox1.BackColor;

            //pos = this.PointToScreen(bohaterLevel.Location);
            //pos = pictureBox1.PointToClient(pos);
            //bohaterLevel.Parent = pictureBox1;
            //bohaterLevel.Location = pos;
            bohaterLevel.ForeColor = Color.Black;
            bohaterLevel.BackColor = pictureBox1.BackColor;

            //pos = this.PointToScreen(bohaterPunktyD.Location);
            //pos = pictureBox1.PointToClient(pos);
            //bohaterPunktyD.Parent = pictureBox1;
            //bohaterPunktyD.Location = pos;
            bohaterPunktyD.ForeColor = Color.Black;
            bohaterPunktyD.BackColor = pictureBox1.BackColor;

            //pos = this.PointToScreen(bohaterInteligencja.Location);
            //pos = pictureBox1.PointToClient(pos);
            //bohaterInteligencja.Parent = pictureBox1;
            //bohaterInteligencja.Location = pos;
            bohaterInteligencja.ForeColor = Color.Black;
            bohaterInteligencja.BackColor = pictureBox1.BackColor;

            //pos = this.PointToScreen(bohaterZrecznosc.Location);
            //pos = pictureBox1.PointToClient(pos);
            //bohaterZrecznosc.Parent = pictureBox1;
            //bohaterZrecznosc.Location = pos;
            bohaterZrecznosc.ForeColor = Color.Black;
            bohaterZrecznosc.BackColor = pictureBox1.BackColor;

            //pos = this.PointToScreen(bohaterSila.Location);
            //pos = pictureBox1.PointToClient(pos);
            //bohaterSila.Parent = pictureBox1;
            //bohaterSila.Location = pos;
            bohaterSila.ForeColor = Color.Black;
            bohaterSila.BackColor = pictureBox1.BackColor;

            //

            //pos = this.PointToScreen(HP.Location);
            //pos = pictureBox1.PointToClient(pos);
            //HP.Parent = pictureBox1;
            //HP.Location = pos;
            HP.ForeColor = Color.Black;
            HP.BackColor = pictureBox1.BackColor;

            //pos = this.PointToScreen(MP.Location);
            //pos = pictureBox1.PointToClient(pos);
            //MP.Parent = pictureBox1;
            //MP.Location = pos;
            MP.ForeColor = Color.Black;
            MP.BackColor = pictureBox1.BackColor;

            //pos = this.PointToScreen(Zloto.Location);
            //pos = pictureBox1.PointToClient(pos);
            //Zloto.Parent = pictureBox1;
            //Zloto.Location = pos;
            Zloto.ForeColor = Color.Black;
            Zloto.BackColor = pictureBox1.BackColor;

            //pos = this.PointToScreen(Level.Location);
            //pos = pictureBox1.PointToClient(pos);
            //Level.Parent = pictureBox1;
            //Level.Location = pos;
            Level.ForeColor = Color.Black;
            Level.BackColor = pictureBox1.BackColor;

            //pos = this.PointToScreen(PunktyD.Location);
            //pos = pictureBox1.PointToClient(pos);
            //PunktyD.Parent = pictureBox1;
            //PunktyD.Location = pos;
            PunktyD.ForeColor = Color.Black;
            PunktyD.BackColor = pictureBox1.BackColor;

            //pos = this.PointToScreen(Inteligencja.Location);
            //pos = pictureBox1.PointToClient(pos);
            //Inteligencja.Parent = pictureBox1;
            //Inteligencja.Location = pos;
            Inteligencja.ForeColor = Color.Black;
            Inteligencja.BackColor = pictureBox1.BackColor;

            //pos = this.PointToScreen(Zrecznosc.Location);
            //pos = pictureBox1.PointToClient(pos);
            //Zrecznosc.Parent = pictureBox1;
            //Zrecznosc.Location = pos;
            Zrecznosc.ForeColor = Color.Black;
            Zrecznosc.BackColor = pictureBox1.BackColor;

            //pos = this.PointToScreen(Sila.Location);
            //pos = pictureBox1.PointToClient(pos);
            //Sila.Parent = pictureBox1;
            //Sila.Location = pos;
            Sila.ForeColor = Color.Black;
            Sila.BackColor = pictureBox1.BackColor;

            //pos = this.PointToScreen(ukosnik1.Location);
            //pos = pictureBox1.PointToClient(pos);
            //ukosnik1.Parent = pictureBox1;
            //ukosnik1.Location = pos;
            ukosnik1.ForeColor = Color.Black;
            ukosnik1.BackColor = pictureBox1.BackColor;

            //pos = this.PointToScreen(ukosnik2.Location);
            //pos = pictureBox1.PointToClient(pos);
            ////ukosnik2.Parent = pictureBox1;
            //ukosnik2.Location = pos;
            ukosnik2.ForeColor = Color.Black;
            ukosnik2.BackColor = pictureBox1.BackColor;

            Exp.ForeColor = Color.Black;
            Exp.BackColor = pictureBox1.BackColor;
        }

        private void uzycie_Click(object sender, EventArgs e)
        {
            string listbox_nazwa;
            int indeks;

            for(int i = 0; i < listBox1.Items.Count; i++)
            {
                if(listBox1.GetSelected(i) == true)
                {
                    listbox_nazwa = listBox1.SelectedItem.ToString();

                    bool czySpacja = false;

                    for(int k = listbox_nazwa.Length -1; k >=0 ; k--)
                    {
                        if (listbox_nazwa[k] == ' ' && czySpacja == true)
                        {
                            indeks = listbox_nazwa.Length - k;
                            listbox_nazwa = listbox_nazwa.Remove(k, indeks);

                            break;
                        }
                        else if (listbox_nazwa[k] == ' ' && czySpacja == false)
                            czySpacja = true;
                    }

                    int j = 0;

                    foreach(Przedmiot istniejacyPrzedmiot in postac.Ekwipunek)
                    {
                        if (istniejacyPrzedmiot.getNazwa().ToString() == listbox_nazwa)
                        {
                            if(istniejacyPrzedmiot.getId() <= 4)
                            {
                                Mikstury potka = (Mikstury)istniejacyPrzedmiot;

                                postac.SetHP(postac.GetHP() + istniejacyPrzedmiot.getItemHP());
                                postac.SetMP(postac.GetMP() + istniejacyPrzedmiot.getItemMP());

                                postac.SetHP(postac.GetHP() + potka.getPotionHp());
                                postac.SetMP(postac.GetMP() + potka.getPotionMp());

                                postac.addStrenght(istniejacyPrzedmiot.getItemStrength());
                                postac.addDexterity(istniejacyPrzedmiot.getItemDexterity());
                                postac.addIntelligence(istniejacyPrzedmiot.getItemIntelligence());
                            }

                            if (postac.Ekwipunek.ElementAt(i).getIlosc() == 1)
                                postac.Ekwipunek.RemoveAt(i);
                            else
                                postac.Ekwipunek.ElementAt(i).zmniejszIlosc(1);

                            UpdateEquipment(postac);

                            break;
                        }
                        else
                            j++;
                    }
                }
            }

        }
    }
}
