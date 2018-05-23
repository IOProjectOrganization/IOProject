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
    public partial class Shop : Form
    {
        Bohater postac;
        Postac seller;

        ShopInfoBox infoBox;
        bool selling;

        float LB1Height;
        float LB2Height;
        float PanelHeight;

        public Shop()
        {
            InitializeComponent();

            LB1Height = listBox1.Height;
            LB2Height = listBox2.Height;
        }

        private void Shop_Load(object sender, EventArgs e)
        {

        }

        public void UpdateEquipment(Bohater Player)
        {
            postac = Player;
            
            listBox1.Items.Clear();

            int i = 0;

            foreach (Przedmiot item in Player.Ekwipunek)
            {
                listBox1.Items.Add(Player.Ekwipunek.ElementAt(i).getNazwa().ToString() + " - " +
                                   Player.Ekwipunek.ElementAt(i).getIlosc().ToString());
                i++;
            }

            bohaterZloto.Text = postac.GetGold().ToString();
        }

        public void UpdateProducts(Postac Seller)   //Bohater zmienony na Postac
        {
            seller = Seller;

            listBox2.Items.Clear();

            int i = 0;

            foreach (Przedmiot item in Seller.Ekwipunek)
            {
                listBox2.Items.Add(Seller.Ekwipunek.ElementAt(i).getNazwa().ToString() + " - " + 
                                   Seller.Ekwipunek.ElementAt(i).getIlosc().ToString() + " \t " +
                                   Seller.Ekwipunek.ElementAt(i).getItemBuyPrice().ToString());
                i++;
            }
        }

        private void button_powrot_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_sprzedaz_Click(object sender, EventArgs e)
        {
            selling = true;

            if (listBox1.SelectedItem != null)
            {
                Przedmiot P = postac.Ekwipunek.ElementAt(listBox1.SelectedIndex) as Przedmiot;
                if (P != null)
                {
                    //if (seller.GetGold() >= P.getItemBuyPrice())
                    //{
                        postac.DodajGold(P.getItemSellPrice());
                        //seller.DecreaseGold(P.getItemBuyPrice());

                        if (postac.Ekwipunek.ElementAt(listBox1.SelectedIndex).getIlosc() == 1)
                            postac.Ekwipunek.RemoveAt(listBox1.SelectedIndex);

                        else
                            postac.Ekwipunek.ElementAt(listBox1.SelectedIndex).zmniejszIlosc(1);

                        seller.DodajPrzedmiot(P.getId());

                        infoBox = new ShopInfoBox();
                        infoBox.Size = new Size(this.Width / 2, this.Height / 3);
                        infoBox.PointToScreen(new Point(this.Width / 2, this.Height / 2));

                        infoBox.checkTradeState(selling, P.getNazwa().ToString());

                        infoBox.Show();
                        infoBox.Focus();

                        UpdateEquipment(postac);
                        UpdateProducts(seller);
                    //}
               }
            }



            /*string listbox_nazwa;
            int indeks;

            selling = true;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.GetSelected(i) == true)
                {
                    listbox_nazwa = listBox1.SelectedItem.ToString();

                    bool czySpacja = false;

                    for (int k = listbox_nazwa.Length - 1; k >= 0; k--)
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

                    foreach (Przedmiot istniejacyPrzedmiot in postac.Ekwipunek)
                    {
                        if (istniejacyPrzedmiot.getNazwa().ToString() == listbox_nazwa)
                        {
                            postac.DodajGold(istniejacyPrzedmiot.getItemSellPrice());

                            if (postac.Ekwipunek.ElementAt(i).getIlosc() == 1)
                                postac.Ekwipunek.RemoveAt(i);
                            else
                                postac.Ekwipunek.ElementAt(i).zmniejszIlosc(1);

                            seller.DodajPrzedmiot(istniejacyPrzedmiot.getId());

                            UpdateProducts(seller);
                            UpdateEquipment(postac);


                            infoBox.Height = this.Height / 3;
                            infoBox.Width = this.Width / 2;
                            infoBox.PointToScreen(new Point(this.Width / 2, this.Height / 2));

                            infoBox.checkTradeState(selling, istniejacyPrzedmiot.getNazwa().ToString());

                            infoBox.Show();
                            infoBox.Focus();

                            break;
                        }
                        else
                            j++;
                    }
                }
            }*/

        }

        private void button_kupno_Click(object sender, EventArgs e)
        {
            selling = false;

            if (listBox2.SelectedItem != null)
            {
                Przedmiot P = seller.Ekwipunek.ElementAt(listBox2.SelectedIndex) as Przedmiot;
                if (P != null)
                {
                    if (postac.GetGold() >= P.getItemBuyPrice())
                    {
                        seller.DodajGold(P.getItemBuyPrice());
                        postac.DecreaseGold(P.getItemBuyPrice());

                        if (seller.Ekwipunek.ElementAt(listBox2.SelectedIndex).getIlosc() == 1)
                            seller.Ekwipunek.RemoveAt(listBox2.SelectedIndex);

                        else
                            seller.Ekwipunek.ElementAt(listBox2.SelectedIndex).zmniejszIlosc(1);

                        postac.DodajPrzedmiot(P.getId());

                        infoBox = new ShopInfoBox();
                        infoBox.Size = new Size(this.Width / 2, this.Height / 3);

                        infoBox.PointToScreen(new Point(this.Width / 2, this.Height / 2));

                        infoBox.checkTradeState(selling, P.getNazwa().ToString());

                        infoBox.Show();
                        infoBox.Focus();

                        UpdateEquipment(postac);
                        UpdateProducts(seller);
                    }
                }
            }



            /*string listbox_nazwa;
            int indeks;

            selling = false;

            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                if (listBox2.GetSelected(i) == true)
                {
                    listbox_nazwa = listBox2.SelectedItem.ToString();

                    bool czySpacja = false;

                    for (int k = listbox_nazwa.Length - 1; k >= 0; k--)
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

                    foreach (Przedmiot istniejacyPrzedmiot in seller.Ekwipunek)
                    {
                        if (istniejacyPrzedmiot.getNazwa().ToString() == listbox_nazwa)
                        {
                            if (postac.GetGold() >= istniejacyPrzedmiot.getItemBuyPrice())
                            {
                                seller.DodajGold(istniejacyPrzedmiot.getItemBuyPrice());
                                postac.DecreaseGold(istniejacyPrzedmiot.getItemBuyPrice());

                                if (seller.Ekwipunek.ElementAt(i).getIlosc() == 1)
                                    seller.Ekwipunek.RemoveAt(i);
                                else
                                    seller.Ekwipunek.ElementAt(i).zmniejszIlosc(1);

                                postac.DodajPrzedmiot(istniejacyPrzedmiot.getId());

                                infoBox.Height = this.Height / 3;
                                infoBox.Width = this.Width / 2;
                                infoBox.PointToScreen(new Point(this.Width / 2, this.Height / 2));

                                infoBox.checkTradeState(selling, istniejacyPrzedmiot.getNazwa().ToString());

                                infoBox.Show();
                                infoBox.Focus();
                            }
                            
                            UpdateEquipment(postac);
                            UpdateProducts(seller);

                            break;
                        }
                        else
                            j++;
                    }
                }
            }*/
        }

        private void ekwipunek_label_SizeChanged(object sender, EventArgs e)
        {
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(fakeImage);


            SizeF extent = graphics.MeasureString(ekwipunek_label.Text, ekwipunek_label.Font);


            float hRatio = ekwipunek_label.Height / extent.Height;
            float wRatio = ekwipunek_label.Width / extent.Width;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = ekwipunek_label.Font.Size * ratio;

            ekwipunek_label.Font = new Font(ekwipunek_label.Font.FontFamily, newSize, ekwipunek_label.Font.Style);
        }

        private void towar_label_SizeChanged(object sender, EventArgs e)
        {
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(fakeImage);


            SizeF extent = graphics.MeasureString(towar_label.Text, towar_label.Font);


            float hRatio = towar_label.Height / extent.Height;
            float wRatio = towar_label.Width / extent.Width;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = towar_label.Font.Size * ratio;

            towar_label.Font = new Font(towar_label.Font.FontFamily, newSize, towar_label.Font.Style);
        }

        private void listBox1_SizeChanged(object sender, EventArgs e)
        {
            float ratio = listBox1.Size.Height / LB1Height;
            listBox1.Font = new Font(listBox1.Font.FontFamily, listBox1.Font.Size * ratio, listBox1.Font.Style);
            LB1Height = listBox1.Height;
        }

        private void listBox2_SizeChanged(object sender, EventArgs e)
        {
            float ratio = listBox2.Size.Height / LB2Height;
            listBox2.Font = new Font(listBox2.Font.FontFamily, listBox2.Font.Size * ratio, listBox2.Font.Style);
            LB2Height = listBox2.Height;
        }

        private void label1_SizeChanged(object sender, EventArgs e)
        {
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(fakeImage);


            SizeF extent = graphics.MeasureString(label1.Text, label1.Font);


            float hRatio = label1.Height / extent.Height * 2 / 3;
            float wRatio = label1.Width / extent.Width * 2 / 3;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = label1.Font.Size * ratio;

            label1.Font = new Font(label1.Font.FontFamily, newSize, label1.Font.Style);
        }

        private void bohaterZloto_SizeChanged(object sender, EventArgs e)
        {
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(fakeImage);


            SizeF extent = graphics.MeasureString(bohaterZloto.Text, bohaterZloto.Font);


            float hRatio = bohaterZloto.Height / extent.Height * 2 / 3;
            float wRatio = bohaterZloto.Width / extent.Width *2 / 3;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = bohaterZloto.Font.Size * ratio;

            bohaterZloto.Font = new Font(bohaterZloto.Font.FontFamily, newSize, bohaterZloto.Font.Style);
        }

        private void button_sprzedaz_SizeChanged(object sender, EventArgs e)
        {
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(fakeImage);


            SizeF extent = graphics.MeasureString(button_sprzedaz.Text, button_sprzedaz.Font);


            float hRatio = button_sprzedaz.Height / extent.Height / 2;
            float wRatio = button_sprzedaz.Width / extent.Width / 2;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = button_sprzedaz.Font.Size * ratio;

            button_sprzedaz.Font = new Font(button_sprzedaz.Font.FontFamily, newSize, button_sprzedaz.Font.Style);
        }

        private void button_powrot_SizeChanged(object sender, EventArgs e)
        {
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(fakeImage);


            SizeF extent = graphics.MeasureString(button_powrot.Text, button_powrot.Font);


            float hRatio = button_powrot.Height / extent.Height / 2;
            float wRatio = button_powrot.Width / extent.Width / 2;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = button_powrot.Font.Size * ratio;

            button_powrot.Font = new Font(button_powrot.Font.FontFamily, newSize, button_powrot.Font.Style);
        }

        private void button_kupno_SizeChanged(object sender, EventArgs e)
        {
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(fakeImage);


            SizeF extent = graphics.MeasureString(button_kupno.Text, button_kupno.Font);


            float hRatio = button_kupno.Height / extent.Height / 2;
            float wRatio = button_kupno.Width / extent.Width / 2;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = button_kupno.Font.Size * ratio;

            button_kupno.Font = new Font(button_kupno.Font.FontFamily, newSize, button_kupno.Font.Style);
        }

        private void Shop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
