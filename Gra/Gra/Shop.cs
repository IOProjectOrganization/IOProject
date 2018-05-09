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
        Bohater postac, seller;
        ShopInfoBox infoBox = new ShopInfoBox();
        bool selling;

        public Shop()
        {
            InitializeComponent();
        }

        public void UpdateEquipment(Bohater Player)
        {
            postac = Player;

            listBox1.Items.Clear();

            int i = 0;

            foreach (Przedmiot item in Player.Ekwipunek)
            {
                if (Player.Ekwipunek.ElementAt(i).getIlosc() > 0)
                    listBox1.Items.Add(Player.Ekwipunek.ElementAt(i).getNazwa().ToString() + " - " + Player.Ekwipunek.ElementAt(i).getIlosc().ToString());
                i++;
            }

            bohaterZloto.Text = postac.GetGold().ToString();
        }

        public void UpdateProducts(Bohater Seller)
        {
            seller = Seller;

            listBox2.Items.Clear();

            int i = 0;

            foreach (Przedmiot item in Seller.Ekwipunek)
            {
                if (Seller.Ekwipunek.ElementAt(i).getIlosc() > 0)
                    listBox2.Items.Add(Seller.Ekwipunek.ElementAt(i).getNazwa().ToString() + " - " + Seller.Ekwipunek.ElementAt(i).getIlosc().ToString());
                i++;
            }
        }

        private void button_powrot_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button_sprzedaz_Click(object sender, EventArgs e)
        {
            string listbox_nazwa;
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

                            infoBox.checkTradeState(selling, istniejacyPrzedmiot.getNazwa().ToString());

                            infoBox.Show();
                            infoBox.Focus();

                            break;
                        }
                        else
                            j++;
                    }
                }
            }

        }

        private void button_kupno_Click(object sender, EventArgs e)
        {
            string listbox_nazwa;
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
            }
        }
    }
}
