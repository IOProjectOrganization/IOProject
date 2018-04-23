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

        public virtual int GetObrazenia() { return 0; }

        public Atak(int _id, string _nazwa, string _opis)
        {
            id = _id;
            Nazwa = _nazwa;
            Opis = _opis;
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
    }


    public class AtkObrazenia : Atak   // ataki majace pewna okreslona ilosc obrazen
    {
        private int Obrazenia;
        public AtkObrazenia(int _id, string _nazwa, string _opis, int obrazenia) : base(_id, _nazwa, _opis)
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
        public AtkMultiplier(int _id, string _nazwa, string _opis, double _multiplier) : base(_id, _nazwa, _opis)
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



    public static class Ataki
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
            DamageATK.Add(new AtkObrazenia(AtakId_MagicznyPocisk, "Magiczny pocisk", "Prosty magiczny pocisk zadający niewielkie obrażenia", 75));


            DamageMultiply.Add(new AtkMultiplier(AtakId_SkupionyAtak, "Skupiony atak", "Specjalny cios zadający większe obrażenia niż zwykły atak", 1.5));
        }

        public static Atak AttacksById(int _id)
        {
            foreach (AtkObrazenia atak in DamageATK)
            {
                if (atak.GetId() == _id)
                {
                    AtkObrazenia temp = new AtkObrazenia(atak.GetId(), atak.GetNazwa(), atak.GetOpis(), atak.GetObrazenia());
                    return temp;
                }
            }
            foreach (AtkMultiplier atak in DamageMultiply)   //dodatkowo przeszukiwanie Weapon
            {
                if (atak.GetId() == _id)
                {
                    AtkMultiplier temp = new AtkMultiplier(atak.GetId(), atak.GetNazwa(), atak.GetOpis(), atak.GetMultiplier());
                    return temp;
                }
            }

            return null;
        }
    }
}

