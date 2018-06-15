using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Gra
{
    public enum ItemType { None, Consumable, Weapon, Armor };

    public class Przedmiot
    {
        private int ilosc;
        private int id;
        private string nazwa;
        private bool stackable; // czy w ekwipunku ma widniec jako osobny wpis, czy może być dołączany do innych przedmiotów tego samego typu; 
        private int sellPrice; // gracz sprzedaje
        private int buyPrice; // gracz kupuje

        private int itemHP;
        private int itemMP;
        private int itemStrength;
        private int itemDexterity;
        private int itemIntelligence;

        private ItemType itemType;

        public Przedmiot()
        {
            ilosc = 0;
            nazwa = "";
        }

        public Przedmiot(int _ilosc, int _id, string _nazwa, bool _stackable, int hp, int mp, int str, int dex, int intel, int _sellPrice, int _buyPrice, ItemType _itemType)
        {
            ilosc = _ilosc;
            id = _id;
            nazwa = _nazwa;
            stackable = _stackable;
            sellPrice = _sellPrice;
            buyPrice = _buyPrice;

            itemHP = hp;
            itemMP = mp;
            itemDexterity = dex;
            itemIntelligence = intel;
            itemStrength = str;

            itemType = _itemType;
        }

        public virtual Przedmiot Kopia()  //wirtualna metoda glebokiej kopii
        {
            Przedmiot temp = new Przedmiot(this.getIlosc(), this.getId(), this.getNazwa(), this.getStackable(), this.getItemHP(), this.getItemMP(), this.getItemStrength(), this.getItemDexterity(), this.getItemIntelligence(), this.getItemSellPrice(), this.getItemBuyPrice(), this.getItemType());
            return temp;
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

        public int getId()
        {
            return id;
        }
        //
        public int getItemHP()
        {
            return itemHP;
        }

        public int getItemMP()
        {
            return itemMP;
        }

        public int getItemIntelligence()
        {
            return itemIntelligence;
        }

        public int getItemStrength()
        {
            return itemStrength;
        }

        public int getItemDexterity()
        {
            return itemDexterity;
        }

        public int getItemSellPrice()
        {
            return sellPrice;
        }

        public int getItemBuyPrice()
        {
            return buyPrice;
        }
        //
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

        public void setId(int _i)
        {
            id = _i;
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

        public ItemType getItemType()
        {
            return itemType;
        }
    }

    public class Bron : Przedmiot
    {
        private int obrazenia;
        private Image WeaponImage;
        //private int zuzycie; // dwa kolejne, jesli uwzgledniamy zuzycie
        //private int zywotnosc; // 

        public Bron(int _ilosc, int _id, string _nazwa, int _obrazenia, bool _stackable, int hp, int mp, int str, int dex, int intel, int _sellprice, int _buyprice, ItemType _itemType, Image WeaponImagePath) : base(_ilosc, _id, _nazwa, _stackable, hp, mp, str, dex, intel, _sellprice, _buyprice, _itemType)
        {
            obrazenia = _obrazenia;
            WeaponImage = new Bitmap(WeaponImagePath);
        }

        public override Przedmiot Kopia()  //gleboka kopia
        {
            Przedmiot temp = new Bron(this.getIlosc(), this.getId(), this.getNazwa(), this.getObrazenia(), this.getStackable(), this.getItemHP(), this.getItemMP(), this.getItemStrength(), this.getItemDexterity(), this.getItemIntelligence(), this.getItemSellPrice(), this.getItemBuyPrice(), this.getItemType(), this.getWeaponImage());
            return temp;
        }

        public int getObrazenia()
        {
            return obrazenia;
        }

        public Image getWeaponImage()
        {
            return WeaponImage;
        }
    }

    public class Zbroja : Przedmiot
    {
        private int obrona;
        private Image ArmorImage;
        //private int zuzycie; //
        //private int zywotnosc; //

        public Zbroja(int _ilosc, int _id, string _nazwa, int _obrona, bool _stackable, int hp, int mp, int str, int dex, int intel, int _sellprice, int _buyprice, ItemType _itemType, Image ArmorImagePath) : base(_ilosc, _id, _nazwa, _stackable, hp, mp, str, dex, intel, _sellprice, _buyprice, _itemType)
        {
            obrona = _obrona;
            ArmorImage = new Bitmap(ArmorImagePath);
        }

        public override Przedmiot Kopia()
        {
            Przedmiot temp = new Zbroja(this.getIlosc(), this.getId(), this.getNazwa(), this.getObrona(), this.getStackable(), this.getItemHP(), this.getItemMP(), this.getItemStrength(), this.getItemDexterity(), this.getItemIntelligence(), this.getItemSellPrice(), this.getItemBuyPrice(), this.getItemType(), this.getArmorImage());
            return temp;
        }

        public int getObrona()
        {
            return obrona;
        }

        public Image getArmorImage()
        {
            return ArmorImage;
        }
    }

    public class Mikstury : Przedmiot // zmienione tak, by obslugiwalo zarowno przedmioty zwiekszajace HP, jak i te zwiekszajace MP
    {
        private int potionHp;
        private int potionMp;

        public Mikstury(int _ilosc, int _id, string _nazwa, int _potionHp, int _potionMP, bool _stackable, int hp ,int mp, int str, int dex, int intel, int _sellprice, int _buyprice, ItemType _itemType) : base(_ilosc, _id, _nazwa, _stackable, hp, mp, str, dex, intel, _sellprice, _buyprice, _itemType)
        {
            potionHp = _potionHp;
            potionMp = _potionMP;
        }

        public override Przedmiot Kopia()  //gleboka kopia
        {
            Przedmiot temp = new Mikstury(this.getIlosc(), this.getId(), this.getNazwa(), this.getPotionHp(), this.getPotionMp(), this.getStackable(), this.getItemHP(), this.getItemMP(), this.getItemStrength(), this.getItemDexterity(), this.getItemIntelligence(), this.getItemSellPrice(), this.getItemBuyPrice(), this.getItemType());
            return temp;
        }

        public int getPotionHp()
        {
            return potionHp;
        }

        public int getPotionMp()
        {
            return potionMp;
        }
    }

    ///////

    public static class Item
    {
        public static readonly List<Przedmiot> Items = new List<Przedmiot>(); // uzytkowe temp
        public static readonly List<Mikstury> Medicine = new List<Mikstury>(); // lekarstwa
        public static readonly List<Bron> Weapon = new List<Bron>(); // bron
        public static readonly List<Zbroja> Armor = new List<Zbroja>(); // zbroja

        // Zloto
        
        public const int itemId_gold = 0;
        
        // Mikstury

        public const int itemId_smallPotion = 1;
        public const int itemId_bigPotion = 2;
        public const int itemId_smallMpPotion = 3;
        public const int itemId_bigMpPotion = 4;

        // Uzytkowe

        public const int itemId_bone = 5;

        // Bronie

        public static int weaponId_normalSword = 6;
        public static int weaponId_bigSword = 7;

        // Zbroje

        public static int armorId_lightSteelArmor = 8;

        static Item()
        {
            zaladujPrzedmioty();
        }

        private static void zaladujPrzedmioty()
        {
            Medicine.Add(new Mikstury(0, itemId_smallPotion, "Mala mikstura", 50, 0, true, 0, 0, 0, 0, 0, 10, 20, ItemType.Consumable));
            Medicine.Add(new Mikstury(0, itemId_bigPotion, "Duza mikstura", 100, 0, true, 0, 0, 0, 0, 0, 50, 100, ItemType.Consumable));
            Medicine.Add(new Mikstury(0, itemId_smallMpPotion, "Ether", 0, 25, true, 0, 0, 0, 0, 0, 10, 20, ItemType.Consumable));
            Medicine.Add(new Mikstury(0, itemId_bigMpPotion, "Mega Ether", 0, 50, true, 0, 0, 0, 0, 0, 50, 100, ItemType.Consumable));

            Items.Add(new Przedmiot(0, itemId_bone, "Ludzka kosc", true, 0, 0, 0, 0, 0, 2, -1, ItemType.None));
            Items.Add(new Przedmiot(0, itemId_gold, "Zloto", true, 0, 0, 0, 0, 0, 0, 0, ItemType.None));

            Weapon.Add(new Bron(0, weaponId_normalSword, "Zwykly rycerski miecz", 5, false, 0, 0, 2, 0, 0, 200, 350, ItemType.Weapon, Gra.Properties.Resources.sword_1));
            Weapon.Add(new Bron(0, weaponId_bigSword, "Duzy rycerski miecz", 10, false, 0, 0, 0, 0, 0, 400, 600, ItemType.Weapon, Gra.Properties.Resources.sword_2));

            Armor.Add(new Zbroja(0, armorId_lightSteelArmor, "Lekka stalowa zbroja", 30, false, 0, 0, 0, 0, 0, 300, 500, ItemType.Armor, Gra.Properties.Resources.armor_1));
        }

        public static Przedmiot ItemsById(int _id)
        {
            foreach (Przedmiot item in Medicine)
            {
                if (item.getId() == _id)
                {
                    return item;
                }
            }
            foreach (Przedmiot item in Weapon)   //dodatkowo przeszukiwanie Weapon
            {
                if (item.getId() == _id)
                {
                    return item;
                }
            }
            foreach (Przedmiot item in Items)   //dodatkowo przeszukiwanie Items
            {
                if (item.getId() == _id)
                {
                    return item;
                }

            }
            foreach (Przedmiot item in Armor)
            {
                if (item.getId() == _id)
                {
                    return item;
                }
            }

            return null;
        }
    }
}