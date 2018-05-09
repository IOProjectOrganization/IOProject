using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
    public enum TypAtaku
    {
       Obrazenia,
       Leczenie,
    }

    public class Atak  // klasa bazowa
    {
        public TypAtaku Typ;    // dla rozroznienia w jaki sposob wybrana umiejetnosc ma wykonac system walki     if (wybranyatak.Typ == TypAtaku.Obrazenia)  .....
        protected bool AppliesStun;
        int id;
        Postac Parent;   // postac posiadajaca pewien atak, potrzebne aby wyliczac obrazenia pod wzgledem statystyk
        private string Nazwa;
        private string Opis;
        private int ManaCost;

        public virtual int GetValue() { return 0; }     // zwraca wartosc obrazen/leczenia

        public Atak(int _id, string _nazwa, string _opis, int _manacost, bool _appliesstun)
        {
            id = _id;
            Nazwa = _nazwa;
            Opis = _opis;
            ManaCost = _manacost;
            AppliesStun = _appliesstun;
        }

        public void AssignParent(Postac _parent)  // parent przypisywany atakowi podczas jego dodawania w klasie postaci
        {
            Parent = _parent;
        }

        public int GetParentObrazenia()
        {
            return Parent.GetObrazenia();
        }

        public int GetId()
        {
            return id;
        }

        public string GetNazwa()
        {
            return Nazwa;
        }

        public string GetOpis()
        {
            return Opis;
        }

        public int GetManaCost()
        {
            return ManaCost;
        }

        public bool IsStun()
        {
            return AppliesStun;
        }
    }


    public class AtkObrazenia : Atak   // ataki majace pewna okreslona ilosc obrazen
    {
        private int Obrazenia;
        public AtkObrazenia(int _id, string _nazwa, string _opis, int _manacost, int obrazenia, bool _appliesstun) : base(_id, _nazwa, _opis, _manacost, _appliesstun)
        {
            Obrazenia = obrazenia;
            Typ = TypAtaku.Obrazenia;
        }

        public override int GetValue()
        {
            return Obrazenia;
        }
    }

    public class AtkMultiplier : Atak   // ataki zwracajace obrazenia postaci pomnozone przez multiplier
    {
        private double Multiplier;
        public AtkMultiplier(int _id, string _nazwa, string _opis, int _manacost, double _multiplier, bool _appliesstun) : base(_id, _nazwa, _opis, _manacost, _appliesstun)
        {
            Multiplier = _multiplier;
            Typ = TypAtaku.Obrazenia;
        }

        public override int GetValue()
        {
            return (int)(GetParentObrazenia() * Multiplier);
        }

        public double GetMultiplier()
        {
            return Multiplier;
        }
    }

    public class AtkLeczenie : Atak
    {
        private int WartoscLeczenia;

        public AtkLeczenie(int _id, string _nazwa, string _opis, int _manacost, int _wartoscleczenia, bool _appliesstun) : base(_id, _nazwa, _opis, _manacost, _appliesstun)
        {
            WartoscLeczenia = _wartoscleczenia;
            Typ = TypAtaku.Leczenie;
        }

        public override int GetValue()
        {
            return WartoscLeczenia;
        }
    }



    public static class Ataki
    {
        public static readonly List<AtkObrazenia> DamageATK = new List<AtkObrazenia>(); // ataki zwracajace czysta ilosc obrazen
        public static readonly List<AtkMultiplier> DamageMultiply = new List<AtkMultiplier>(); // ataki zwracajace obrazenia postaci pomnozone przez multiplier
        public static readonly List<AtkLeczenie> HealingATK = new List<AtkLeczenie>();  // ataki sluzace leczeniu postaci

        // AtkObrazenia

        public const int AtakId_MagicznyPocisk = 1;

        // AtkMultiplier

        public const int AtakId_SkupionyAtak = 2;
        public const int AtakId_Hak = 4;

        //AtkLeczenie

        public const int AtakId_PomniejszeUzdrowienie = 3;

        static Ataki()
        {
            zaladujAtaki();
        }

        private static void zaladujAtaki()
        {
            DamageATK.Add(new AtkObrazenia(AtakId_MagicznyPocisk, "Magiczny pocisk", "Prosty magiczny pocisk zadający niewielkie obrażenia", 8, 24, false));


            DamageMultiply.Add(new AtkMultiplier(AtakId_SkupionyAtak, "Skupiony atak", "Specjalny cios zadający większe obrażenia niż zwykły atak", 10, 1.5, false));
            DamageMultiply.Add(new AtkMultiplier(AtakId_Hak, "Hak", "Niespodziewany cios pięścią w stanie oszołomić przeciwnika", 10, 0.2, true));


            HealingATK.Add(new AtkLeczenie(AtakId_PomniejszeUzdrowienie, "Pomniejsze uzdrowienie", "Niskiego poziomu zaklęcie leczące użytkownika", 10, 50, false));
        }

        public static Atak AttacksById(int _id)
        {
            foreach (AtkObrazenia atak in DamageATK)
            {
                if (atak.GetId() == _id)
                {
                    AtkObrazenia temp = new AtkObrazenia(atak.GetId(), atak.GetNazwa(), atak.GetOpis(), atak.GetManaCost(), atak.GetValue(), atak.IsStun());
                    return temp;
                }
            }
            foreach (AtkMultiplier atak in DamageMultiply)
            {
                if (atak.GetId() == _id)
                {
                    AtkMultiplier temp = new AtkMultiplier(atak.GetId(), atak.GetNazwa(), atak.GetOpis(), atak.GetManaCost(), atak.GetMultiplier(), atak.IsStun());
                    return temp;
                }
            }
            foreach(AtkLeczenie atak in HealingATK)
            {
                if (atak.GetId() == _id)
                {
                    AtkLeczenie temp = new AtkLeczenie(atak.GetId(), atak.GetNazwa(), atak.GetOpis(), atak.GetManaCost(), atak.GetValue(), atak.IsStun());
                }
            }

            return null;
        }
    }
}

