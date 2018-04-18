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

            if (HP > MaxHP)
                HP = MaxHP;
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

            if (MP > maxMP)
                MP = maxMP;
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
        private int XTileIndex;
        private int YTileIndex;


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

        public List<Przedmiot> Ekwipunek;

        public Bohater(int level, int basehp, int basemp, int gold, int exp, int STR, int DEX, int INT, /*int posx, int posy,*/ Point Location, Image SciezkaObrazku) : base(basehp, basemp)  // konstruktor // dodane mp
        {
            Level = level;
            Gold = gold;
            EXP = exp;
            PlayerLoc = Location;
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
                Obrazenia = UzywanaBron.getObrazenia() + Strength * 5;
            }
            else
                Obrazenia = Strength * 5;
        }

        public int GetObrazenia()
        {
            return Obrazenia;
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
        // mozliwosc dodania wartosci z przedmiotow do cech

        public void addStrenght(int str)
        {
            Strength += str;
        }

        public void addDexterity(int dex)
        {
            Dexterity += dex;
        }

        public void addIntelligence(int intel)
        {
            Intelligence += intel;
        }

        //
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

        public int GetGold()
        {
            return Gold;
        }
        public int GetIntelligence()
        {
            return Intelligence;
        }
        public int GetDexterity()
        {
            return Dexterity;
        }
        public int GetStrength()
        {
            return Strength;
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
                foreach (Przedmiot istniejacyPrzedmiot in Ekwipunek) // jesli przedmiot jest stackowalny, sprawdza czy w ekwipunku jest juz przedmiot o tej samej nazwie aby jedynie zwiekszyc jego ilosc o 1
                {
                    if (istniejacyPrzedmiot.getId() == id)
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
                    istniejacyPrzedmiot.zmniejszIlosc(1);
                    if(istniejacyPrzedmiot.getIlosc()==0)
                    {
                        Ekwipunek.Remove(istniejacyPrzedmiot);
                    }
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
            CheckLevelUp();
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
        { return CharacterSprite; }

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

    public class Przeciwnik : Postac
    {
       //private Image ObrazekPostaci;  // obrazek ktory ma przedstawiac postac
       //private Point PlayerLoc;
        private int id;
        private Image ObrazekPostaci;
        private string Nazwa;
        private int Obrazenia;
        private int NagrodaExp;
        private int NagrodaGold;

        public Przeciwnik(string nazwa, int _id, int obrazenia, int nagrodaexp, int nagrodagold, int basehp, int basemp, Image SciezkaObrazku) : base(basehp, basemp) // dodane mp
        {
            id = _id;
            SetMaxHP(basehp);
            SetHP(basehp);
            SetMaxMP(basemp);
            SetMP(basemp);
            Nazwa = nazwa;
            Obrazenia = obrazenia;
            NagrodaExp = nagrodaexp;
            NagrodaGold = nagrodagold;
            ObrazekPostaci = new Bitmap(SciezkaObrazku);
        }

        public int GetObrazenia()
        {
            return Obrazenia;
        }
        public int getId()
        {
            return id;
        }
        public string getNazwa()
        {
            return Nazwa;
        }
        public int getNagrodaExp()
        {
            return NagrodaExp;
        }
        public int getNagrodaGold()
        {
            return NagrodaGold;
        }
        public Image getObrazekPostaci()
        {
            return ObrazekPostaci;
        }
    }
    
    public static class Wrog   // baza przeciwnikow
    {
        public static readonly List<Przeciwnik> Przeciwnik = new List<Przeciwnik>();

        // ID

        //public const int enemyId_szkielet = 1;

        static Wrog()
        {
            zaladujPrzedmioty();
        }

        private static void zaladujPrzedmioty()
        {
            //Przeciwnik.Add(new Przeciwnik("Szkielet", enemyId_szkielet, 20, 25, 10, 80, 0, jakassciezkaobrazu));
        }


        public static Przeciwnik EnemyById(int _id)   // zwraca obiekt bedacy kopia przeciwnika o podanym id
        {
            foreach (Przeciwnik enemy in Przeciwnik)
            {
                if (enemy.getId() == _id)
                {
                    Przeciwnik temp = new Przeciwnik(enemy.getNazwa(), enemy.getId(), enemy.GetObrazenia(), enemy.getNagrodaExp(), enemy.getNagrodaGold(), enemy.GetBaseHP(), enemy.GetBaseMP(), enemy.getObrazekPostaci());
                    return temp;
                }
            }
            return null;
        }
    }
}