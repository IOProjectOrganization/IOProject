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
        List<Przedmiot> przedmioty = new List<Przedmiot>();

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
            przedmioty.Clear();

            int i = 0;

            foreach (Przedmiot item in Player.Ekwipunek)
            {
                for (int j = 0; j < Player.Ekwipunek.ElementAt(i).getIlosc(); j++)
                    przedmioty.Add(Player.Ekwipunek.ElementAt(i));

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

            uzycie.Enabled = false;
            uzycie.Visible = false;

            zdjecie.Enabled = false;
            zdjecie.Visible = false;
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
            if (listBox1.SelectedItem != null)
            {
                Przedmiot P = przedmioty.ElementAt(listBox1.SelectedIndex) as Przedmiot;
                if (P != null)
                {
                    if (P.getItemType() == ItemType.Armor)
                    {
                        if (postac.getZalozonaZbroja() != null)
                        {
                            przedmioty.Add(postac.getZalozonaZbroja());
                            listBox1.Items.Add(postac.getZalozonaZbroja().getNazwa().ToString() + " - " + postac.getZalozonaZbroja().getIlosc().ToString());
                            postac.Ekwipunek.Add(postac.getZalozonaZbroja());
                            EquippedArmor.Clear();
                            imageList1.Images.RemoveAt(0);
                        }

                        postac.ZalozZbroje(P as Zbroja);
                        imageList1.Images.Add(Gra.Properties.Resources.zloto);

                        ListViewItem listViewItem = new ListViewItem();
                        listViewItem.ImageIndex = 0;
                        EquippedArmor.Items.Add(listViewItem);

                        postac.Ekwipunek.RemoveAt(listBox1.SelectedIndex);
                        przedmioty.RemoveAt(listBox1.SelectedIndex);
                        listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                        listBox1.ClearSelected();
                    }
                    else if (P.getItemType() == ItemType.Consumable)
                    {
                        if (P.GetType() == typeof(Mikstury))
                        {
                            Mikstury potion = P as Mikstury;
                            postac.SetHP(postac.GetHP() + potion.getPotionHp());
                            postac.SetMP(postac.GetMP() + potion.getPotionMp());
                        }

                        postac.addStrenght(P.getItemStrength());
                        postac.addDexterity(P.getItemDexterity());
                        postac.addIntelligence(P.getItemIntelligence());


                        if (postac.Ekwipunek.ElementAt(listBox1.SelectedIndex).getIlosc() == 1)
                        {
                            postac.Ekwipunek.RemoveAt(listBox1.SelectedIndex);
                            przedmioty.RemoveAt(listBox1.SelectedIndex);
                            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                            listBox1.ClearSelected();
                        }
                        else
                        {
                            postac.Ekwipunek.ElementAt(listBox1.SelectedIndex).zmniejszIlosc(1);
                            przedmioty.RemoveAt(listBox1.SelectedIndex);
                            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                            listBox1.ClearSelected();
                        }
                    }
                    else if (P.getItemType() == ItemType.Weapon)
                    {
                        if (postac.getZalozonaBron() != null)
                        {
                            przedmioty.Add(postac.getZalozonaBron());
                            listBox1.Items.Add(postac.getZalozonaBron().getNazwa().ToString() + " - " + postac.getZalozonaBron().getIlosc().ToString());
                            postac.Ekwipunek.Add(postac.getZalozonaBron());
                            EquippedWeapon.Clear();
                            imageList2.Images.RemoveAt(0);
                        }

                        postac.ZalozBron(P as Bron);
                        imageList2.Images.Add(Gra.Properties.Resources.sword_1);

                        ListViewItem listViewItem = new ListViewItem();
                        listViewItem.ImageIndex = 0;
                        EquippedWeapon.Items.Add(listViewItem);

                        postac.Ekwipunek.RemoveAt(listBox1.SelectedIndex);
                        przedmioty.RemoveAt(listBox1.SelectedIndex);
                        listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                        listBox1.ClearSelected();
                    }
                }

                P = null;
            }

            UpdateEquipment(postac);

        }

        private void zdjecie_Click(object sender, EventArgs e)
        {
            if (EquippedArmor.Items.Count > 0 && EquippedArmor.Items[0].Selected == true)
            {
                Przedmiot P = postac.getZalozonaZbroja() as Przedmiot;
                if (P != null)
                {
                    EquippedArmor.Items[0].Selected = false;

                    if (EquippedWeapon.Items.Count > 0 && EquippedWeapon.Items[0].Selected == true)
                        EquippedWeapon.Items[0].Selected = false;

                    przedmioty.Add(postac.getZalozonaZbroja());
                    listBox1.Items.Add(postac.getZalozonaZbroja().getNazwa().ToString() + " - " + postac.getZalozonaZbroja().getIlosc().ToString());
                    postac.Ekwipunek.Add(postac.getZalozonaZbroja());
                    EquippedArmor.Clear();
                    imageList1.Images.RemoveAt(0);
                    postac.ZalozZbroje(null);

                }

                P = null;
            }
            else if (EquippedWeapon.Items.Count > 0 && EquippedWeapon.Items[0].Selected == true)
            {
                Przedmiot P = postac.getZalozonaBron() as Przedmiot;
                if (P != null)
                {
                    EquippedWeapon.SelectedItems[0].Selected = false;

                    if (EquippedArmor.Items.Count > 0 && EquippedArmor.Items[0].Selected == true)
                        EquippedArmor.Items[0].Selected = false;

                    przedmioty.Add(postac.getZalozonaBron());
                    listBox1.Items.Add(postac.getZalozonaBron().getNazwa().ToString() + " - " + postac.getZalozonaBron().getIlosc().ToString());
                    postac.Ekwipunek.Add(postac.getZalozonaBron());
                    EquippedWeapon.Clear();
                    imageList2.Images.RemoveAt(0);
                    postac.ZalozBron(null);
                }

                P = null;
            }

            UpdateEquipment(postac);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Przedmiot P = przedmioty.ElementAt(listBox1.SelectedIndex) as Przedmiot;
                if (P != null)
                {
                    if (P.getItemType() == ItemType.None)
                    {
                        uzycie.Enabled = false;
                        uzycie.Visible = false;
                    }
                    else if (P.getItemType() == ItemType.Armor)
                    {
                        uzycie.Enabled = true;
                        uzycie.Visible = true;
                        uzycie.Text = "Załóż";
                    }
                    else if (P.getItemType() == ItemType.Consumable)
                    {
                        uzycie.Enabled = true;
                        uzycie.Visible = true;
                        uzycie.Text = "Użyj";
                    }
                    else if (P.getItemType() == ItemType.Weapon)
                    {
                        uzycie.Enabled = true;
                        uzycie.Visible = true;
                        uzycie.Text = "Wyposaż";
                    }
                }
            }
        }

        private void EquippedArmor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EquippedArmor.Items.Count > 0 && EquippedArmor.Items[0].Selected == true)
            {
                zdjecie.Enabled = true;
                zdjecie.Visible = true;

                if (EquippedWeapon.Items.Count > 0 && EquippedWeapon.Items[0].Selected == true)
                    EquippedWeapon.Items[0].Selected = false;
            }
            else
            {
                if (EquippedArmor.Items.Count > 0 && EquippedArmor.Items[0].Selected == false)
                {
                    if (EquippedWeapon.Items.Count > 0 && EquippedWeapon.Items[0].Selected == false)
                    {
                        zdjecie.Enabled = false;
                        zdjecie.Visible = false;
                    }
                    else if (EquippedWeapon.Items.Count == 0)
                    {
                        zdjecie.Enabled = false;
                        zdjecie.Visible = false;
                    }
                }
                else if (EquippedArmor.Items.Count == 0)
                {
                    if (EquippedWeapon.Items.Count > 0 && EquippedWeapon.Items[0].Selected == false)
                    {
                        zdjecie.Enabled = false;
                        zdjecie.Visible = false;
                    }
                    else if (EquippedWeapon.Items.Count == 0)
                    {
                        zdjecie.Enabled = false;
                        zdjecie.Visible = false;
                    }
                }
            }
        }

        private void EquippedWeapon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EquippedWeapon.Items.Count > 0 && EquippedWeapon.Items[0].Selected == true)
            {
                zdjecie.Enabled = true;
                zdjecie.Visible = true;

                if (EquippedArmor.Items.Count > 0 && EquippedArmor.Items[0].Selected == true)
                    EquippedArmor.Items[0].Selected = false;
            }
            /*else
            {
                if (EquippedWeapon.Items.Count > 0 && EquippedWeapon.Items[0].Selected == false)
                {
                    if (EquippedArmor.Items.Count > 0 && EquippedArmor.Items[0].Selected == false)
                    {
                        zdjecie.Enabled = false;
                        zdjecie.Visible = false;
                    }
                    else if (EquippedArmor.Items.Count == 0)
                    {
                        zdjecie.Enabled = false;
                        zdjecie.Visible = false;
                    }
                }
                else if (EquippedWeapon.Items.Count == 0)
                {
                    if (EquippedArmor.Items.Count > 0 && EquippedArmor.Items[0].Selected == false)
                    {
                        zdjecie.Enabled = false;
                        zdjecie.Visible = false;
                    }
                    else if (EquippedArmor.Items.Count == 0)
                    {
                        zdjecie.Enabled = false;
                        zdjecie.Visible = false;
                    }
                }
            }*/
        }
    }
}
