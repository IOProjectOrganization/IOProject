using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int Gold;
        public int EXP;
        public int Level
        { get { return ((EXP / 100) + 1); } }   // prawdopodobnie do zastąpienia w przyszłości
        

        //public Bron UzywanaBron;    //problem - bron ma dostepnosc prywatną więc nie moze to byc funkcja public oraz nie byłem w stanie
                                      //stworzyc funkcji przykladowo public void ZalozBron(Bron ZakladanaBron) {} rowniez z powodu braku
                                      //dostepu

        //public List<Przedmiot> Ekwipunek;   // tak samo jak wyżej
                                              // nie jestem pewien jak temu poradzić
                                              // mozliwa jest zmiana dostepu tych klas w przedmiotach ale chciałbym usłyszeć o
                                              // waszych alternatywach/pomysłach 


        public Bohater(int hp, int maxhp, int gold, int exp) : base(hp, maxhp)  // konstruktor
        {
            Gold = gold;
            EXP = exp;
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
