﻿using System;
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

        public enum MoveDirection { None, Up, Down, Left, Right };

        protected WorldMapSprite CharacterSprite; //Pozwala na obsługę postaci w świecie gry

        public Postac(int hp, int maxhp)
        {
            HP = hp;
            MaxHP = maxhp;
        }
    }

    public class Bohater : Postac   // klasa bohatera
    {
        private Image ObrazekPostaci;  // obrazek ktory ma przedstawiac postac
        private Point PlayerLoc;
        private MoveDirection Direction = MoveDirection.None;
        private bool isMoving = false;

//        private int posX;   //polozenie x
//        private int posY;   //polozenie y
        private int Gold;
        private int EXP;
        private int Level
        { get { return ((EXP / 100) + 1); } }   // prawdopodobnie do zastąpienia w przyszłości

        private Bron UzywanaBron;

        private List<Przedmiot> Ekwipunek;

        public Bohater(int hp, int maxhp, int gold, int exp, /*int posx, int posy,*/ Point Location, Image SciezkaObrazku) : base(hp, maxhp)  // konstruktor
        {
            Gold = gold;
            EXP = exp;
            PlayerLoc = Location;
//            posX = posx;
//            posY = posy;
            ObrazekPostaci = new Bitmap(SciezkaObrazku);
            CharacterSprite = new WorldMapSprite(PlayerLoc, ObrazekPostaci);
            Ekwipunek = new List<Przedmiot>();
        }

        public void DodajPrzedmiot(Przedmiot item)
        {
            if (item.getStackable() == false)  // jesli przedmiot nie jest stackowalny to go dodaje do ekwipunku
            {
                Ekwipunek.Add(item);
            }
            else
            {
                bool czyZnaleziono = false;
                foreach(Przedmiot istniejacyPrzedmiot in Ekwipunek) // jesli przedmiot jest stackowalny, sprawdza czy w ekwipunku jest juz przedmiot o tej samej nazwie aby jedynie zwiekszyc jego ilosc o 1
                {
                    if(istniejacyPrzedmiot.getNazwa()==item.getNazwa())
                    {
                        czyZnaleziono = true;
                        istniejacyPrzedmiot.zwiekszIlosc(item.getIlosc());
                        break;
                    }
                }
                if (czyZnaleziono == false)  // jesli nie znaleziono itemu juz w ekwipunku do stackowania to go dodaje
                    Ekwipunek.Add(item);
            }
        }

        public void UsunPrzedmiot(Przedmiot item)
        {
            Ekwipunek.Remove(item);
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

        
/*
        public void RuchWPrawo()
        {
//            posX += 40;
            PlayerLoc.X += 40;
            // zmiana obrazekpostaci
        }
        public void RuchWLewo()
        {
//            posX -= 40;
            PlayerLoc.X -= 40;
            //zmiana obrazekpostaci
        }
        public void RuchWDol()
        {
//            posY += 40;
            PlayerLoc.Y += 40;
            //zmiana obrazekpostaci
        }
        public void RuchWGore()
        {
//            posY -= 40;
            PlayerLoc.Y -= 40;
            //zmiana obrazekpostaci
        }
*/

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
