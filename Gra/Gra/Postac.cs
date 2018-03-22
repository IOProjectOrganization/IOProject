using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;  // dla zmiennej image w klasie bohatera
using System.Windows.Forms;
using System.IO;

namespace Gra
{
    public class Postac     // bazowa klasa postaci
    {
        public int HP;
        public int MaxHP;

        private int MP; // dodane punkty MP
        private int maxMP;

        public enum MoveDirection { None, Up, Down, Left, Right };

        protected WorldMapSprite CharacterSprite; //Pozwala na obsługę postaci w świecie gry

        public Postac(int hp, int maxhp, int mp, int maxmp)
        {
            HP = hp;
            MaxHP = maxhp;
            MP = mp;
            maxMP = maxmp;
        }
    }

    public class Bohater : Postac   // klasa bohatera
    {
        private Image ObrazekPostaci;  // obrazek ktory ma przedstawiac postac
        private Point PlayerLoc;
        private MoveDirection Direction = MoveDirection.None;
        private bool isMoving = false;
        private int XTileIndex;
        private int YTileIndex;
        private int Gold;
        private int EXP;
        private int Level
        { get { return ((EXP / 100) + 1); } }   // prawdopodobnie do zastąpienia w przyszłości

        private Bron UzywanaBron;

        private List<Przedmiot> Ekwipunek;

        public Bohater(int hp, int maxhp, int mp, int maxmp, int gold, int exp, Point Location, Image SciezkaObrazku) : base(hp, maxhp, mp, maxmp)  // konstruktor // dodane mp
        {
            Gold = gold;
            EXP = exp;
            PlayerLoc = Location;
            ObrazekPostaci = new Bitmap(SciezkaObrazku);
            CharacterSprite = new WorldMapSprite(PlayerLoc, ObrazekPostaci);
            Ekwipunek = new List<Przedmiot>();
        }

        public void DodajPrzedmiot(int id)
        {
            Przedmiot DodawanyPrzedmiot = Item.ItemsById(id).Kopia();
            if (DodawanyPrzedmiot.getStackable() == false)  // jesli przedmiot nie jest stackowalny to go dodaje do ekwipunku
            {
                DodawanyPrzedmiot.setIlosc(1);
                Ekwipunek.Add(DodawanyPrzedmiot);
            }
            else
            {
                bool czyZnaleziono = false;
                foreach(Przedmiot istniejacyPrzedmiot in Ekwipunek) // jesli przedmiot jest stackowalny, sprawdza czy w ekwipunku jest juz przedmiot o tej samej nazwie aby jedynie zwiekszyc jego ilosc o 1
                {
                    if(istniejacyPrzedmiot.getId()==id)
                    {
                        czyZnaleziono = true;
                        istniejacyPrzedmiot.zwiekszIlosc(1);
                        break;
                    }
                }
                if (czyZnaleziono == false)  // jesli przedmiot jest stackowalny i go nie znaleziono w ekwipunku do stackowania to go dodaje w ilosci 1
                {
                    DodawanyPrzedmiot.setIlosc(1);
                    Ekwipunek.Add(DodawanyPrzedmiot);
                }
            }
        }

        public void UsunPrzedmiot(int id)
        {
            foreach (Przedmiot istniejacyPrzedmiot in Ekwipunek)
            {
                if (istniejacyPrzedmiot.getId() == id)
                {
                    Ekwipunek.Remove(istniejacyPrzedmiot);
                    break;
                }
            }
        }

        public void ZalozBron(Bron bron)
        {
            UzywanaBron = bron;
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

        public WorldMapSprite GetCharacterSprite()
        {   return CharacterSprite;    }

        public void SetCharacterSprite(Point location, Image img)
        {
            CharacterSprite.SetLocation(location);
            CharacterSprite.SetImage(img);
        }

        public void SetMoveDirection(MoveDirection dir)
        { Direction = dir; }

        public MoveDirection GetMoveDirection()
        { return Direction; }

        public void SetIsMoving(bool b)
        { isMoving = b; }

        public bool GetIsMoving()
        { return isMoving; }

        public void SetXTileIndex(int x)
        { XTileIndex = x; }

        public int GetXTileIndex()
        { return XTileIndex; }

        public void SetYTileIndex(int y)
        { YTileIndex = y; }

        public int GetYTileIndex()
        { return YTileIndex; }

    }

    public class Potwor : Postac   //mozliwa wczesna klasa potwora
    {
        public string Nazwa;
        public int Obrazenia;
        public int NagrodaExp;
        public int NagrodaGold;

        public Potwor(string nazwa, int obrazenia, int nagrodaexp, int nagrodagold, int hp, int maxhp, int mp, int maxmp) : base(hp, maxhp, mp, maxmp) // dodane mp
        {
            Nazwa = nazwa;
            Obrazenia = obrazenia;
            NagrodaExp = nagrodaexp;
            NagrodaGold = nagrodagold;
        }
    }
}
