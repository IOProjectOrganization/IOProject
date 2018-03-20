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
        private int BaseHP;    // bazowe hp, do obliczania maxHP w polaczeniu z atrybutami
        private int BaseMP;  // bazowe mp

        private int HP;
        private int MaxHP;

        private int MP;
        private int maxMP;

        public enum MoveDirection { None, Up, Down, Left, Right };

        protected WorldMapSprite CharacterSprite; //Pozwala na obsługę postaci w świecie gry

        public Postac(int basehp, int basemp)
        {
            BaseHP = basehp;
            BaseMP = basemp;
        }

        public int GetBaseHP()
        {
            return BaseHP;
        }
        public int GetBaseMP()
        {
            return BaseMP;
        }
        public void SetHP(int hp)
        {
            HP = hp;
        }
        public int GetHP()
        {
            return HP;
        }
        public void SetMaxHP(int maxhp)
        {
            MaxHP = maxhp;
        }
        public int GetMaxHP()
        {
            return MaxHP;
        }
        public void SetMP(int mp)
        {
            MP = mp;
        }
        public int GetMP()
        {
            return MP;
        }
        public void SetMaxMP(int maxmp)
        {
            maxMP = maxmp;
        }
        public int GetMaxMP()
        {
            return maxMP;
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
        private int Strength;
        private int Dexterity;
        private int Intelligence;
        private int Skillpoints;

        private int Obrazenia;
        //private int Obrona;       //kiedy/jesli dodamy armor

        private int Gold;
        private int EXP;
        private int Level;
        private int EXPtoLevel
        {
            get
            {
                return (int)(100 * Level * 1.15);    // zwraca exp potrzebny do nastepnego levela, mozliwie do zmian 
            }
        }
        //{ get { return ((EXP / 100) + 1); } }   // prawdopodobnie do zastąpienia w przyszłości
        private Bron UzywanaBron;

        private List<Przedmiot> Ekwipunek;

        public Bohater(int level, int basehp, int basemp, int gold, int exp, int STR, int DEX, int INT, /*int posx, int posy,*/ Point Location, Image SciezkaObrazku) : base(basehp, basemp)  // konstruktor // dodane mp
        {
            Level = level;
            Gold = gold;
            EXP = exp;
            PlayerLoc = Location;
//            posX = posx;
//            posY = posy;
            ObrazekPostaci = new Bitmap(SciezkaObrazku);
            CharacterSprite = new WorldMapSprite(PlayerLoc, ObrazekPostaci);
            Ekwipunek = new List<Przedmiot>();
            Strength = STR;
            Dexterity = DEX;
            Intelligence = INT;
            UpdateStats();
            SetHP(GetMaxHP());
            SetMP(GetMaxMP());
            Skillpoints = 0;
        }

        public void UpdateStats()  // zapewnić aktualność danych kiedykolwiek zmienią się statystyki
        {
            SetMaxHP(GetBaseHP() + Strength * 7);
            if (GetHP() > GetMaxHP()) SetHP(GetMaxHP());
            SetMaxMP(GetBaseMP() + Intelligence * 5);
            if (GetMP() > GetMaxMP()) SetMP(GetMaxMP());
            if (UzywanaBron != null)
            {
                Obrazenia = UzywanaBron.getObrazenia() + Strength*5;
            }
            else
                Obrazenia = Strength*5;
        }

        public int GetEXP()
        {
            return EXP;
        }
        public int GetEXPtoLevel()
        {
            return EXPtoLevel;
        }
        public int GetLevel()
        {
            return Level;
        }
        public int GetSkillpoints()
        {
            return Skillpoints;
        }
        public void LevelUp()
        {
            SetExp(EXP - EXPtoLevel);
            Level++;
            Strength++;
            Dexterity++;
            Intelligence++;
            Skillpoints += 2;
            UpdateStats();
        }

        public void SkillpointSTR()
        {
            if (Skillpoints > 0)
            {
                Skillpoints--;
                Strength++;
                UpdateStats();
            }
        }
        public void SkillpointDEX()
        {
            if (Skillpoints > 0)
            {
                Skillpoints--;
                Dexterity++;
                UpdateStats();
            }
        }
        public void SkillpointINT()
        {
            if (Skillpoints > 0)
            {
                Skillpoints--;
                Intelligence++;
                UpdateStats();
            }
        }

        public bool CheckLevelUp()  //jesli starczy doswiadczenia do levela, leveluje postac oraz zwraca true/false
        {
            if (EXP > EXPtoLevel)
            {
                while (EXP > EXPtoLevel)
                {
                    LevelUp();
                }
                return true;
            }
            else
                return false;
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
            UpdateStats();
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

        public Potwor(string nazwa, int obrazenia, int nagrodaexp, int nagrodagold, int basehp, int basemp) : base(basehp, basemp) // dodane mp
        {
            SetMaxHP(basehp);
            SetHP(basehp);
            SetMaxMP(basemp);
            SetMP(basemp);
            Nazwa = nazwa;
            Obrazenia = obrazenia;
            NagrodaExp = nagrodaexp;
            NagrodaGold = nagrodagold;
        }
    }
}
