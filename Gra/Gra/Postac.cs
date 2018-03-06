using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;  // dla zmiennej image w klasie bohatera
namespace Gra
{
    public class Postac     // bazowa klasa postaci
    {
        public int HP;
        public int MaxHP;

        public Postac(int hp, int maxhp)
        {
            HP = hp;
            MaxHP = maxhp;
        }
    }

    public class Bohater : Postac   // klasa bohatera
    {
        public Image ObrazekPostaci;  // obrazek ktory ma przedstawiac postac
        public int posX;   //polozenie x
        public int posY;   //polozenie y
        public int Gold;
        public int EXP;
        public int Level
        { get { return ((EXP / 100) + 1); } }   // prawdopodobnie do zastąpienia w przyszłości

        public Bron UzywanaBron;    
    
        public List<Przedmiot> Ekwipunek;

        public Bohater(int hp, int maxhp, int gold, int exp, int posx, int posy, Image SciezkaObrazku) : base(hp, maxhp)  // konstruktor
        {
            Gold = gold;
            EXP = exp;
            posX = posx;
            posY = posy;
            ObrazekPostaci = new Bitmap(SciezkaObrazku);
        }

        public void DodajEXP(int exp)
        {
            EXP += exp;
        }

        public void SetExp(int exp)
        {
            EXP = exp;
        }

        public void DodajGold(int gold)
        {
            Gold += gold;
        }

        public void SetGold(int gold)
        {
            Gold = gold;
        }

        public void RuchWPrawo()
        {
            posX += 40;
            // zmiana obrazekpostaci
        }
        public void RuchWLewo()
        {
            posX -= 40;
            //zmiana obrazekpostaci
        }
        public void RuchWDol()
        {
            posY += 40;
            //zmiana obrazekpostaci
        }
        public void RuchWGore()
        {
            posY -= 40;
            //zmiana obrazekpostaci
        }

    }

    public class Potwor : Postac   //mozliwa wczesna klasa potwora
    {
        public string Nazwa;
        public int Obrazenia;
        public int NagrodaExp;
        public int NagrodaGold;

        public Potwor(string nazwa, int obrazenia, int nagrodaexp, int nagrodagold, int hp, int maxhp) : base(hp, maxhp)
        {
            Nazwa = nazwa;
            Obrazenia = obrazenia;
            NagrodaExp = nagrodaexp;
            NagrodaGold = nagrodagold;
        }
    }
}
