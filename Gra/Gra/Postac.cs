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

        private bool isAlive = true;

        private int Gold;

        public enum MoveDirection { None, Up, Down, Left, Right };

        protected WorldMapSprite CharacterSprite; //Pozwala na obsługę postaci w świecie gry

        public List<Atak> SpecjalneAtaki;
        public List<Przedmiot> Ekwipunek;

        public Postac(int basehp, int basemp)
        {
            BaseHP = basehp;
            BaseMP = basemp;
            Ekwipunek = new List<Przedmiot>();
            SpecjalneAtaki = new List<Atak>();
            DOTEffects = new List<DOTEffect>();
            StunResistance = BaseStunResistance;
            StunRecoveryChance = BaseStunRecoveryChance;
            Stunned = false;
        }

        public Postac()
        {
            Ekwipunek = new List<Przedmiot>();
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

        public virtual int GetObrazenia()
        {
            return 0;
        }

        public WorldMapSprite GetCharacterSprite()
        { return CharacterSprite; }

        public void SetCharacterSprite(Point location, Image img)
        {
            CharacterSprite.SetLocation(location);
            CharacterSprite.SetImage(img);
        }

        public bool getIsAlive()
        { return isAlive; }

        public void setIsAlive(bool b)
        { isAlive = b; }

        public int GetGold()
        {
            return Gold;
        }

        public void DodajGold(int gold)
        {
            Gold += gold;
        }

        public void DecreaseGold(int gold)
        {
            Gold -= gold;
        }

        public void SetGold(int gold)
        {
            Gold = gold;
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
                    if (istniejacyPrzedmiot.getIlosc() == 0)
                    {
                        Ekwipunek.Remove(istniejacyPrzedmiot);
                    }
                    break;
                }
            }
        }

        public void WyczyscEkwipunek()
        {
            Ekwipunek.Clear();
        }

        public void PoznajAtak(int id)
        {
            bool JuzPoznany = false;
            Atak PoznawanyAtak = Ataki.AttacksById(id);
            PoznawanyAtak.AssignParent(this);
            foreach (Atak ZnanyAtak in SpecjalneAtaki)
            {
                if (ZnanyAtak.GetId() == PoznawanyAtak.GetId())
                {
                    JuzPoznany = true;
                }
            }

            if (JuzPoznany == false)
            {
                SpecjalneAtaki.Add(PoznawanyAtak);
            }
        }

        //  Obsluga statusów(oszołomienie, krwawienie itd)   wyjasnienie na dole

        public List<DOTEffect> DOTEffects;  // efekty zadajace obrazenia co ture przez jakis okres czasu spowodowane np. atakami trującymi

        public void ApplyDOTEffect(DOTEffect atak)
        {
            DOTEffects.Add(atak);
        }

        public bool IsPoisoned()  // sprawdza czy jest na postaci efekt obrazen czasowych(np trucizny), moze byc uzyte do wyswietlania statusow
        {
            if (DOTEffects.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Stunned;
        public bool IsStunned() // sprawdza czy jest na postaci efekt, moze byc uzyte do wyswietlania statusow, potrzebne jest tez aby poprawnie postepowac w takim wypadku
        {
            return Stunned;
        }

        protected int BaseStunResistance = 30;
        protected int StunResistance;
        public int GetStunResistance()
        { return StunResistance; }
        protected int BaseStunRecoveryChance = 40;
        protected int StunRecoveryChance;
        public int GetStunRecoveryChance()
        { return StunRecoveryChance; }

        public void ApplyStun()   // probuje nalozyc oszolomienie, sprawdza czy sie powiodlo
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 101);
            if (randomNumber > GetStunResistance())
            {
                if(Stunned!=true)
                { StunResistance = StunResistance + 50; }      // oszolomiona postac bedzie mniej podatna na kolejne proby oszolomienia
                Stunned=true;
            }
        }
        public void StunEscapeCheck()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 101);
            if (randomNumber > GetStunRecoveryChance())
            {
                StunRecoveryChance = StunRecoveryChance + 20;     // im dluzej postac jest oszolomiona tym bardziej prawdopodobne wydostanie sie
            }
            else
            {
                Stunned = false;
                StunRecoveryChance = BaseStunRecoveryChance;
            }
        }
        public void ResolveDOT()  // obrazenia z efektow trucizny/krawienia-czasowych obrazen
        {
            int obrazenia = 0;
            foreach (DOTEffect DOT in DOTEffects.Reverse<DOTEffect>())   // oblicza sume wszystkich obrazen czasowych oraz usuwa te ktorych czas dzialania sie skonczyl
            {
                obrazenia = obrazenia + DOT.GetDamage();
                DOT.DecrementTurnsLeft();
                if (DOT.GetTurnsLeft() <= 0)
                {
                    DOTEffects.Remove(DOT);
                }
            }
            SetHP(GetHP() - obrazenia);
        }
        public void ResolveStatuses()  // wykonywane co ture, sprawdza czy udalo sie wydostac z oszolomienia, obrazenia z krwawienia pozniej
        {
            StunEscapeCheck();
        
            ResolveDOT();


            if (StunResistance > BaseStunResistance)
            { StunResistance = StunResistance - 10; }      // zmniejsza odpornosc postaci na kolejne proby oszolomienia wraz z traktem walki
        }

        public void ClearStatuses() // wywolane po skończonej bitwie
        {
            StunResistance = BaseStunResistance;
            StunRecoveryChance = BaseStunRecoveryChance;
            Stunned = false;

            foreach (DOTEffect DOT in DOTEffects)
            {
                DOTEffects.Remove(DOT);
            }
        }
        /*
          Wyjasnienie:
          Walka
          Na poczatku albo na koncu tury dla postaci wykonujacej swoja ture powinna byc wywolywana funkcja ResolveStatuses(), ktora bedzie zajmowala sie obsluga roznych
          statusow(oszolomienie, krwawienie, itd)
          Gdy wybrany jest atak specjalny z atrybutem IsStun=true, to atak oprocz swoich zwyklych czynnosci(obrazenia) wykonuje na przeciwniku funkcje Applystun()
          Kazda postac ma poczatkowo bazowo stunresistance 30% aby nie zostac oszolomiona oraz stunrecoverychance 40% aby sie wydostac z tego statusu
          Kiedy postac jest oszolomiona, dostaje ona premie do stunresistance +50%, ktora zmniejsza sie o 10 co ture, co oznacza ze kolejne proby oszolomienia
          w bliskim przedziale czasowym beda mniej efektywne.
          Co ture postac ktora jest oszolomiona probuje sie wydostac(wykonywane w funkcji ResolveStatuses()). Jesli sie to nie powiedzie to dostaje bonus +20% do stunrecoverychance
          az uda sie jej wydostac z oszolomienia, jest to resetowane wtedy spowrotem do domyslnej bazowej szansy.
          Mechanizm walki powinien omijac ture gracza, ktorego IsStunned() zwraca true, poki nie zmieni tego na false funkcja ResolveStatuses()


          Po zakonczeniu walki, powinna byc wywolywana na bohaterze funkcja ClearStatuses, aby zapewnic ze rzeczy takie jak stan oszolomienia i premie statystykowe beda
          spowrotem w domyslnych postaciach
        */
    }


    public class PrzyjaznyNPC : Postac
    {
        private int id;
        private string Nazwa;
        private Image ObrazekPostaci;
        private Point FriendlyLoc;

        //public List<Quest> Questy;

        public PrzyjaznyNPC(int _id, string _nazwa, Point Location, Image SciezkaObrazku) : base()
        {
            Nazwa = _nazwa;
            id = _id;
            FriendlyLoc = Location;
            ObrazekPostaci = new Bitmap(SciezkaObrazku);
            CharacterSprite = new WorldMapSprite(FriendlyLoc, ObrazekPostaci);
            //Questy = new List<Quest>();
        }

        public int getId()
        {
            return id;
        }
        public string getNazwa()
        {
            return Nazwa;
        }

    }


    public class Bohater : Postac   // klasa bohatera
    {
        private Image ObrazekPostaci;  // obrazek ktory ma przedstawiac postac
        private Image BattleImage;
        private Point PlayerLoc;
        private MoveDirection Direction = MoveDirection.None;
        private bool isMoving = false;
        private int XTileIndex;
        private int YTileIndex;


        private int Strength;
        private int Dexterity;
        private int Intelligence;
        private int Skillpoints;

        //private int Obrazenia;
        //private int Obrona;       //kiedy/jesli dodamy armor

            // przeniesione do klasy postaci
        //private int Gold;
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
        private Zbroja UzywanaZbroja;

        // ekwipunek przeniesiony do klasy postaci
        //public List<Przedmiot> Ekwipunek;


        public Bohater(int level, int basehp, int basemp, int gold, int exp, int STR, int DEX, int INT, Point Location, Image SciezkaObrazku) : base(basehp, basemp)  // konstruktor
        {
            Level = level;
            SetGold(gold);
            EXP = exp;
            PlayerLoc = Location;
            ObrazekPostaci = new Bitmap(SciezkaObrazku);
            CharacterSprite = new WorldMapSprite(PlayerLoc, ObrazekPostaci);
            Strength = STR;
            Dexterity = DEX;
            Intelligence = INT;
            UpdateStats();
            SetHP(GetMaxHP());
            SetMP(GetMaxMP());
            Skillpoints = 0;
        }

        public Bohater(int basehp, int basemp) : base(basehp,basemp)
        {
            Ekwipunek = new List<Przedmiot>();
        }

        public void UpdateStats()  // zapewnić aktualność danych kiedykolwiek zmienią się statystyki
        {
            SetMaxHP(GetBaseHP() + Strength * 7);
            if (GetHP() > GetMaxHP()) SetHP(GetMaxHP());
            SetMaxMP(GetBaseMP() + Intelligence * 5);
            if (GetMP() > GetMaxMP()) SetMP(GetMaxMP());
          /*  if (UzywanaBron != null)
            {
                Obrazenia = UzywanaBron.getObrazenia() + Strength * 3;
            }
            else
                Obrazenia = Strength * 3; */
        }

        public override int GetObrazenia()
        {
            if (UzywanaBron != null)
            {
                return UzywanaBron.getObrazenia() + Strength * 3;
            }
            else
                return Strength * 3;
            //return Obrazenia;
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

        public void ZalozBron(Bron bron)
        {
            UzywanaBron = bron;
            UpdateStats();
        }

        public Bron getZalozonaBron()
        {
            return UzywanaBron;
        }

        public void ZalozZbroje(Zbroja zbroja)
        {
            UzywanaZbroja = zbroja;
            UpdateStats();
        }

        public Zbroja getZalozonaZbroja()
        {
            return UzywanaZbroja;
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
        private int id;
        private Image ObrazekPostaci;
        private Image BattleImage;
        private Point EnemyLoc;
        private string Nazwa;
        private int Obrazenia;
        private int NagrodaExp;
        private int NagrodaGold;

        public Przeciwnik(string nazwa, int _id, int obrazenia, int nagrodaexp, int nagrodagold, int basehp, int basemp, Point Location, Image SciezkaObrazku, Image BattleImagePath) : base(basehp, basemp)
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
            BattleImage = new Bitmap(BattleImagePath);
            EnemyLoc = Location;
            CharacterSprite = new WorldMapSprite(EnemyLoc, ObrazekPostaci);
        }

        public Przeciwnik(string nazwa, int _id, int obrazenia, int nagrodaexp, int nagrodagold, int basehp, int basemp, Image BattleImagePath) : base(basehp, basemp)
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
            BattleImage = BattleImagePath;
        }

        public override int GetObrazenia()
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
        public Image getBattleImage()
        {
            return BattleImage;
        }
    }
    
    public static class Wrog   // baza przeciwnikow losowych
    {
        public static readonly List<Przeciwnik> Przeciwnik = new List<Przeciwnik>();

        // ID

        public const int enemyId_nietoperz = 1;
        public const int enemyId_ogromnyszczur = 2;
        public const int enemyId_wilk = 3;
        public const int enemyId_szkielet = 4;
        public const int enemyId_szkielet_czarownik = 5;
        public const int enemyId_minotaur = 6;

        static Wrog()
        {
            zaladujWrogow();
        }

        //public Przeciwnik(string nazwa, int _id, int obrazenia, int nagrodaexp, int nagrodagold, int basehp, int basemp) : base(basehp, basemp)
        private static void zaladujWrogow()   // wykorzystany konstruktor bez obrazka postaci i lokacji, przeznaczony wiec dla walk losowych gdzie nie sa potrzebne
        {
            Przeciwnik temp;

            temp = new Przeciwnik("Nietoperz", enemyId_nietoperz, 4, 10, 10, 25, 0, Gra.Properties.Resources.Empty);
            Przeciwnik.Add(temp);

            temp = new Przeciwnik("Ogromny szczur", enemyId_ogromnyszczur, 5, 15, 15, 30, 0, Gra.Properties.Resources.Empty);
            Przeciwnik.Add(temp);

            temp = new Przeciwnik("Wilk", enemyId_wilk, 7, 20, 20, 40, 0, Gra.Properties.Resources.Empty);
            Przeciwnik.Add(temp);

            temp = new Przeciwnik("Szkielet", enemyId_szkielet, 8, 25, 25, 30, 0, Gra.Properties.Resources.Empty);
            Przeciwnik.Add(temp);

            temp = new Przeciwnik("Szkielet czarownik", enemyId_szkielet_czarownik, 4, 30, 20, 40, 30, Gra.Properties.Resources.Empty);
            temp.PoznajAtak(1);
            Przeciwnik.Add(temp);

            temp = new Przeciwnik("Minotaur", enemyId_minotaur, 12, 50, 40, 80, 30, Gra.Properties.Resources.Empty);
            temp.PoznajAtak(2);
            temp.PoznajAtak(4);
            Przeciwnik.Add(temp);

        }


        public static Przeciwnik EnemyById(int _id)   // zwraca obiekt bedacy kopia przeciwnika o podanym id
        {
            foreach (Przeciwnik enemy in Przeciwnik)
            {
                if (enemy.getId() == _id)
                {
                    Przeciwnik temp = new Przeciwnik(enemy.getNazwa(), enemy.getId(), enemy.GetObrazenia(), enemy.getNagrodaExp(), enemy.getNagrodaGold(), enemy.GetBaseHP(), enemy.GetBaseMP(), enemy.getBattleImage());
                    foreach(Atak atak in enemy.SpecjalneAtaki)
                    {
                        temp.PoznajAtak(atak.GetId());
                    }
                    foreach(Przedmiot przedmiot in enemy.Ekwipunek)
                    {
                        temp.DodajPrzedmiot(przedmiot.getId());
                    }
                    return temp;
                }
            }
            return null;
        }
    }
}