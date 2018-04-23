using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
    public class Atak  // klasa bazowa
    {
        int id;
        Postac Parent;   // postac posiadajaca pewien atak, potrzebne aby wyliczac obrazenia pod wzgledem statystyk
        private string Nazwa;
        private string Opis;
        private int ManaCost;

        public virtual int GetObrazenia() { return 0; }

        public Atak(int _id, string _nazwa, string _opis, int _manacost)
        {
            id = _id;
            Nazwa = _nazwa;
            Opis = _opis;
            ManaCost = _manacost;
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
    }


    public class AtkObrazenia : Atak   // ataki majace pewna okreslona ilosc obrazen
    {
        private int Obrazenia;
        public AtkObrazenia(int _id, string _nazwa, string _opis, int _manacost, int obrazenia) : base(_id, _nazwa, _opis, _manacost)
        {
            Obrazenia = obrazenia;
        }

        public override int GetObrazenia()
        {
            return Obrazenia;
        }
    }

    public class AtkMultiplier : Atak   // ataki zwracajace obrazenia postaci pomnozone przez multiplier
    {
        private double Multiplier;
        public AtkMultiplier(int _id, string _nazwa, string _opis, int _manacost, double _multiplier) : base(_id, _nazwa, _opis, _manacost)
        {
            Multiplier = _multiplier;
        }

        public override int GetObrazenia()
        {
            return (int)(GetParentObrazenia() * Multiplier);
        }

        public double GetMultiplier()
        {
            return Multiplier;
        }
    }



    public static class Ataki   // do zrobienia: oprocz id przeciwnikow tez do jakich atakow maja dostep
    {
        public static readonly List<AtkObrazenia> DamageATK = new List<AtkObrazenia>(); // ataki zwracajace czysta ilosc obrazen
        public static readonly List<AtkMultiplier> DamageMultiply = new List<AtkMultiplier>(); // ataki zwracajace obrazenia postaci pomnozone przez multiplier

        // AtkObrazenia

        public const int AtakId_MagicznyPocisk = 1;

        // AtkMultiplier

        public const int AtakId_SkupionyAtak = 2;

        static Ataki()
        {
            zaladujAtaki();
        }

        private static void zaladujAtaki()
        {
            DamageATK.Add(new AtkObrazenia(AtakId_MagicznyPocisk, "Magiczny pocisk", "Prosty magiczny pocisk zadający niewielkie obrażenia", 8, 75));


            DamageMultiply.Add(new AtkMultiplier(AtakId_SkupionyAtak, "Skupiony atak", "Specjalny cios zadający większe obrażenia niż zwykły atak", 10, 1.5));
        }

        public static Atak AttacksById(int _id)
        {
            foreach (AtkObrazenia atak in DamageATK)
            {
                if (atak.GetId() == _id)
                {
                    AtkObrazenia temp = new AtkObrazenia(atak.GetId(), atak.GetNazwa(), atak.GetOpis(), atak.GetManaCost(), atak.GetObrazenia());
                    return temp;
                }
            }
            foreach (AtkMultiplier atak in DamageMultiply)
            {
                if (atak.GetId() == _id)
                {
                    AtkMultiplier temp = new AtkMultiplier(atak.GetId(), atak.GetNazwa(), atak.GetOpis(), atak.GetManaCost(), atak.GetMultiplier());
                    return temp;
                }
            }

            return null;
        }
    }
}

