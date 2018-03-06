using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
    public class Przedmiot
    {
        private int ilosc;
        private string nazwa;
        private bool stackable; // czy w ekwipunku ma widniec jako osobny wpis, czy może być dołączany do innych przedmiotów tego samego typu; 

        public Przedmiot()
        {
            ilosc = 0;
            nazwa = "";
        }

        public Przedmiot(int _ilosc, string _nazwa, bool _stackable)
        {
            ilosc = _ilosc;
            nazwa = _nazwa;
            stackable = _stackable;
        }

        public bool getStackable()
        {
            return stackable;
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

        public void setStackable(bool _stackable)
        {
            stackable = _stackable;
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

    public class Bron : Przedmiot
    {
        private int obrazenia;
        //private int zuzycie; // dwa kolejne, jesli uwzgledniamy zuzycie
        //private int zywotnosc; // 

        public Bron(int _ilosc, string _nazwa, int _obrazenia, bool _stackable) : base(_ilosc, _nazwa, _stackable)
        {
            obrazenia = _obrazenia;
        }

        /*public Bron()
        {
            setNazwa = 

        }*/

        public int getObrazenia()
        {
            return obrazenia;
        }

    }

    public class Lekarstwa : Przedmiot
    {
        private int leczenie;

        public Lekarstwa(int _ilosc, string _nazwa, int _leczenie, bool _stackable) : base (_ilosc, _nazwa, _stackable)
        {
            leczenie = _leczenie;
        }

        public int getLeczenie() 
        {
            return leczenie;
        }
    }
}
