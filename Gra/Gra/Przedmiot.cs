using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
    class Przedmiot
    {
        private int ilosc;
        private string nazwa;

        public Przedmiot()
        {
            ilosc = 0;
            nazwa = "";
        }

        public Przedmiot(int _ilosc, string _nazwa)
        {
            ilosc = _ilosc;
            nazwa = _nazwa;
        }

        public int getIlosc()
        {
            return ilosc;
        }

        public string getNazwa()
        {
            return nazwa;
        }

        public void setIlosc(int _ilosc) // na wypadek, jakby wykorzystano konsruktor domyslny
        {
            ilosc = _ilosc;
        }

        public void setNazwa(string _nazwa)
        {
            nazwa = _nazwa;
        }

        public void zmniejszIlosc(int _x)
        {
            if (ilosc >= _x)
            {
                ilosc -= _x;
            }
            else
                ilosc = 0;
        }

        public void zwiekszIlosc(int _x)
        {
            ilosc += _x;
        }
    }

    class Bron : Przedmiot
    {
        private int obrazenia;
        //private int zuzycie; // dwa kolejne, jesli uwzgledniamy zuzycie
        //private int zywotnosc; // 

        public Bron(int _ilosc, string _nazwa, int _obrazenia) : base(_ilosc, _nazwa)
        {
            obrazenia = _obrazenia;
        }

        public int getObrazenia()
        {
            return obrazenia;
        }

    }

    class Lekarstwa : Przedmiot
    {
        private int leczenie;

        public Lekarstwa(int _ilosc, string _nazwa, int _leczenie) : base (_ilosc, _nazwa)
        {
            leczenie = _leczenie;
        }

        public int getLeczenie() 
        {
            return leczenie;
        }
    }
}
