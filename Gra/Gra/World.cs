using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Gra
{
    public class WorldMap
    {
        public struct Tile //Tworzymy małe pola jakie będą fragmentami świata
        {
            public Image TileImage; //Obrazek jaki będzie wyświetlany
            public Point TileLoc; //Lokalzacja obiektu

            public bool isWalkable; //Czy można po nim się poruszać
            public bool isInteractive; //Czy obiekt jest interaktywny
            public bool isMapLoader; //Czy wczytuje mape
            public bool SwitchState;
            public bool isShop; // Czy pole nalezy do obszaru sklepu
            public bool isNPC;
        }

        public List<WorldMapItem> worldMapItems; //Lista przedmiotów na danym świecie
        WorldMapItem item; //Przedmiot

        public List<Tile> MapTiles; //Lista wszystkich pól

        public WorldMap(Form form) //Konstruktor
        {
            MapTiles = new List<Tile>(); //Tworzymy pusty świat
        }

        public void LoadMap(string MapName, int TileWidth, int TileHeight, bool NewMap, List<Przeciwnik> EnemiesList) //Wczytywanie świata
        {
            MapTiles.Clear(); //Czyścimy obecny świat
            if (NewMap)
                worldMapItems.Clear();

            EnemiesList.Clear();

            StreamReader Reader = new StreamReader(@"MapTileData\1_maptiles" + MapName + ".txt"); //Wczytywanie danych z pliku o podanej ścieżce

            int x = 0;
            int y = 0;

            while (!Reader.EndOfStream) //Wykonuj aż do końca pliku
            {
                string line = Reader.ReadLine(); //Wczytaj linię

                for (int z = 0; z < line.Length; z += 4)
                {
                    Tile T = new Tile(); //Tworzymy obiekt
                    T.TileLoc = new Point(x * TileWidth, y * TileHeight); //Ustalamy położenie obiektu (bierzemy pod uwagę jego rozmiar)

                    if (line[z].ToString() == "t") // Przechodzenie pomiędzy światami
                    {
                        T.TileImage = new Bitmap(Gra.Properties.Resources.Empty, TileWidth, TileHeight);
                        T.isWalkable = true; //Ustalamy czy można się po nim poruszać
                        T.isInteractive = false; //Sprawdzamy czy jest interaktywny
                        T.isMapLoader = true; //Sprawdzamy czy wczytuje świat
                        T.SwitchState = false; //Sprawdzamy czy przycisko został przełączony
                        T.isShop = false;
                        T.isNPC = false;
                    }
                    if (line[z].ToString() == "s") // dostęp do sklepu
                    {
                        T.TileImage = new Bitmap(Gra.Properties.Resources.Player, TileWidth, TileHeight);
                        T.isWalkable = false;
                        T.isInteractive = true;
                        T.isMapLoader = false;
                        T.SwitchState = false;
                        T.isShop = true;
                        T.isNPC = false;
                    }
                    if (line[z].ToString() == "0") //Zablokowana przestrzeń
                    {
                        T.TileImage = new Bitmap(Gra.Properties.Resources.Empty, TileWidth, TileHeight);
                        T.isWalkable = false;
                        T.isInteractive = false;
                        T.isMapLoader = false;
                        T.SwitchState = false;
                        T.isShop = false;
                        T.isNPC = false;
                    }
                    if (line[z].ToString() == "1") //Domyślna, możliwa do chodzenia przestrzeć
                    {
                        T.TileImage = new Bitmap(Gra.Properties.Resources.Empty, TileWidth, TileHeight);
                        T.isWalkable = true;
                        T.isInteractive = false;
                        T.isMapLoader = false;
                        T.SwitchState = false;
                        T.isShop = false;
                        T.isNPC = false;
                    }
                    if (line[z].ToString() == "2") //Przedmiot
                    {
                        T.TileImage = new Bitmap(Gra.Properties.Resources.Empty, TileWidth, TileHeight);
                        T.isWalkable = false;
                        T.isInteractive = true;
                        T.isMapLoader = false;
                        T.SwitchState = false;
                        T.isShop = false;
                        T.isNPC = false;

                        if (line[z + 1].ToString() == "0")
                        {
                            if (line[z + 2].ToString() == "0")
                            {
                                worldMapItems.Add(new WorldMapItem(new Point(x * TileWidth, y * TileHeight), new Bitmap(Gra.Properties.Resources.WaterTile), Item.ItemsById(1)));
                                item = worldMapItems.Find(c => c.GetLocation() == new Point(x * TileWidth, y * TileHeight));
                                T.TileImage = new Bitmap(Gra.Properties.Resources.healthpotion_1, TileWidth, TileHeight);
                            }
                            if (line[z + 2].ToString() == "1")
                            {
                                worldMapItems.Add(new WorldMapItem(new Point(x * TileWidth, y * TileHeight), new Bitmap(Gra.Properties.Resources.GrassTile), Item.ItemsById(2)));
                                item = worldMapItems.Find(c => c.GetLocation() == new Point(x * TileWidth, y * TileHeight));
                                T.TileImage = new Bitmap(Gra.Properties.Resources.healthpotion_1, TileWidth, TileHeight);
                            }
                            if (line[z + 2].ToString() == "2")
                            {
                                worldMapItems.Add(new WorldMapItem(new Point(x * TileWidth, y * TileHeight), new Bitmap(Gra.Properties.Resources.WaterTile), Item.ItemsById(3)));
                                item = worldMapItems.Find(c => c.GetLocation() == new Point(x * TileWidth, y * TileHeight));
                                T.TileImage = new Bitmap(Gra.Properties.Resources.manapotion_1, TileWidth, TileHeight);
                            }
                            if (line[z + 2].ToString() == "3")
                            {
                                worldMapItems.Add(new WorldMapItem(new Point(x * TileWidth, y * TileHeight), new Bitmap(Gra.Properties.Resources.WaterTile), Item.ItemsById(4)));
                                item = worldMapItems.Find(c => c.GetLocation() == new Point(x * TileWidth, y * TileHeight));
                                T.TileImage = new Bitmap(Gra.Properties.Resources.manapotion_1, TileWidth, TileHeight);
                            }
                        }
                        if (line[z + 1].ToString() == "1")
                        {
                            if (line[z + 2].ToString() == "0")
                            {
                                worldMapItems.Add(new WorldMapItem(new Point(x * TileWidth, y * TileHeight), new Bitmap(Gra.Properties.Resources.WaterTile), Item.ItemsById(6)));
                                item = worldMapItems.Find(c => c.GetLocation() == new Point(x * TileWidth, y * TileHeight));
                                T.TileImage = new Bitmap(Gra.Properties.Resources.sword_1, TileWidth, TileHeight);
                            }
                            if (line[z + 2].ToString() == "1")
                            {
                                worldMapItems.Add(new WorldMapItem(new Point(x * TileWidth, y * TileHeight), new Bitmap(Gra.Properties.Resources.WaterTile), Item.ItemsById(7)));
                                item = worldMapItems.Find(c => c.GetLocation() == new Point(x * TileWidth, y * TileHeight));
                                T.TileImage = new Bitmap(Gra.Properties.Resources.sword_2, TileWidth, TileHeight);
                            }
                        }
                        if (line[z + 1].ToString() == "2")
                        {
                            if (line[z + 2].ToString() == "0")
                            {
                                worldMapItems.Add(new WorldMapItem(new Point(x * TileWidth, y * TileHeight), new Bitmap(Gra.Properties.Resources.WaterTile), Item.ItemsById(8)));
                                item = worldMapItems.Find(c => c.GetLocation() == new Point(x * TileWidth, y * TileHeight));
                                T.TileImage = new Bitmap(Gra.Properties.Resources.zloto, TileWidth, TileHeight);
                            }
                        }
                        if (line[z + 1].ToString() == "3")
                        {
                            worldMapItems.Add(new WorldMapItem(new Point(x * TileWidth, y * TileHeight), new Bitmap(Gra.Properties.Resources.WaterTile), Item.ItemsById(0)));
                            item = worldMapItems.Find(c => c.GetLocation() == new Point(x * TileWidth, y * TileHeight));
                            T.TileImage = new Bitmap(Gra.Properties.Resources.zloto, TileWidth * 2 / 3, TileHeight * 2 / 3);
                        }
                    }
                    if (line[z].ToString() == "3") //Przeciwnik
                    {
                        T.TileImage = new Bitmap(Gra.Properties.Resources.Empty, TileWidth, TileHeight);
                        T.isWalkable = true;
                        T.isInteractive = false;
                        T.isMapLoader = false;
                        T.SwitchState = false;
                        T.isShop = false;
                        T.isNPC = true;

                        if (line[z + 1].ToString() == "0") //Wrogi
                        {
                            if (line[z + 2].ToString() == "0")
                            {
                                EnemiesList.Add(new Przeciwnik( Wrog.EnemyById(Wrog.enemyId_nietoperz).getNazwa(), Wrog.EnemyById(Wrog.enemyId_nietoperz).getId(),
                                                                Wrog.EnemyById(Wrog.enemyId_nietoperz).GetObrazenia(), Wrog.EnemyById(Wrog.enemyId_nietoperz).getNagrodaExp(),
                                                                Wrog.EnemyById(Wrog.enemyId_nietoperz).getNagrodaGold(), Wrog.EnemyById(Wrog.enemyId_nietoperz).GetBaseHP(),
                                                                Wrog.EnemyById(Wrog.enemyId_nietoperz).GetBaseMP(), new Point(x * TileWidth, y * TileHeight), Gra.Properties.Resources.enemy1,
                                                                Gra.Properties.Resources.Empty));
                            }
                            if (line[z + 2].ToString() == "1")
                            {
                                EnemiesList.Add(new Przeciwnik(Wrog.EnemyById(Wrog.enemyId_ogromnyszczur).getNazwa(), Wrog.EnemyById(Wrog.enemyId_ogromnyszczur).getId(),
                                                                Wrog.EnemyById(Wrog.enemyId_ogromnyszczur).GetObrazenia(), Wrog.EnemyById(Wrog.enemyId_ogromnyszczur).getNagrodaExp(),
                                                                Wrog.EnemyById(Wrog.enemyId_ogromnyszczur).getNagrodaGold(), Wrog.EnemyById(Wrog.enemyId_ogromnyszczur).GetBaseHP(),
                                                                Wrog.EnemyById(Wrog.enemyId_ogromnyszczur).GetBaseMP(), new Point(x * TileWidth, y * TileHeight), Gra.Properties.Resources.enemy1,
                                                                Gra.Properties.Resources.Empty));
                            }
                            if (line[z + 2].ToString() == "2")
                            {
                                EnemiesList.Add(new Przeciwnik(Wrog.EnemyById(Wrog.enemyId_wilk).getNazwa(), Wrog.EnemyById(Wrog.enemyId_wilk).getId(),
                                                                Wrog.EnemyById(Wrog.enemyId_wilk).GetObrazenia(), Wrog.EnemyById(Wrog.enemyId_wilk).getNagrodaExp(),
                                                                Wrog.EnemyById(Wrog.enemyId_wilk).getNagrodaGold(), Wrog.EnemyById(Wrog.enemyId_wilk).GetBaseHP(),
                                                                Wrog.EnemyById(Wrog.enemyId_wilk).GetBaseMP(), new Point(x * TileWidth, y * TileHeight), Gra.Properties.Resources.enemy1,
                                                                Gra.Properties.Resources.Empty));
                            }
                            if (line[z + 2].ToString() == "3")
                            {
                                EnemiesList.Add(new Przeciwnik(Wrog.EnemyById(Wrog.enemyId_szkielet).getNazwa(), Wrog.EnemyById(Wrog.enemyId_szkielet).getId(),
                                                                Wrog.EnemyById(Wrog.enemyId_szkielet).GetObrazenia(), Wrog.EnemyById(Wrog.enemyId_szkielet).getNagrodaExp(),
                                                                Wrog.EnemyById(Wrog.enemyId_szkielet).getNagrodaGold(), Wrog.EnemyById(Wrog.enemyId_szkielet).GetBaseHP(),
                                                                Wrog.EnemyById(Wrog.enemyId_szkielet).GetBaseMP(), new Point(x * TileWidth, y * TileHeight), Gra.Properties.Resources.enemy1,
                                                                Gra.Properties.Resources.Empty));
                            }
                            if (line[z + 2].ToString() == "4")
                            {
                                EnemiesList.Add(new Przeciwnik(Wrog.EnemyById(Wrog.enemyId_szkielet_czarownik).getNazwa(), Wrog.EnemyById(Wrog.enemyId_szkielet_czarownik).getId(),
                                                                Wrog.EnemyById(Wrog.enemyId_szkielet_czarownik).GetObrazenia(), Wrog.EnemyById(Wrog.enemyId_szkielet_czarownik).getNagrodaExp(),
                                                                Wrog.EnemyById(Wrog.enemyId_szkielet_czarownik).getNagrodaGold(), Wrog.EnemyById(Wrog.enemyId_szkielet_czarownik).GetBaseHP(),
                                                                Wrog.EnemyById(Wrog.enemyId_szkielet_czarownik).GetBaseMP(), new Point(x * TileWidth, y * TileHeight), Gra.Properties.Resources.enemy1,
                                                                Gra.Properties.Resources.Empty));
                            }
                            if (line[z + 2].ToString() == "5")
                            {
                                EnemiesList.Add(new Przeciwnik(Wrog.EnemyById(Wrog.enemyId_minotaur).getNazwa(), Wrog.EnemyById(Wrog.enemyId_minotaur).getId(),
                                                                Wrog.EnemyById(Wrog.enemyId_minotaur).GetObrazenia(), Wrog.EnemyById(Wrog.enemyId_minotaur).getNagrodaExp(),
                                                                Wrog.EnemyById(Wrog.enemyId_minotaur).getNagrodaGold(), Wrog.EnemyById(Wrog.enemyId_minotaur).GetBaseHP(),
                                                                Wrog.EnemyById(Wrog.enemyId_minotaur).GetBaseMP(), new Point(x * TileWidth, y * TileHeight), Gra.Properties.Resources.enemy1,
                                                                Gra.Properties.Resources.Empty));
                            }
                        }
                        if (line[z + 1].ToString() == "1") //Przyjazny
                        {
                            if (line[z + 2].ToString() == "0")
                            {
                                //Do dodania
                            }
                        }
                    }

                    MapTiles.Add(T); //Dodajemy dany obiekt mapy do listy
                    x++;
                }

                x = 0;
                y++;
            }

            Reader.Close(); //Kończymy czytanie pliku
        }

        public void DrawMap(Graphics Device, int WorldX, int WorldY, int Width, int Height) //Rysowanie na ekranie
        {
            Image img;

            if (WorldX < 0 && WorldY >= 0)
            {
                WorldX *= -1;
                img = new Bitmap((Image)Gra.Properties.Resources.ResourceManager.GetObject("world_" + WorldX + "" + WorldY), Width, Height);
            }
            else if (WorldX >= 0 && WorldY < 0)
            {
                WorldY *= -1;
                img = new Bitmap((Image)Gra.Properties.Resources.ResourceManager.GetObject("world" + WorldX + "_" + WorldY), Width, Height);
            }
            else if (WorldX < 0 && WorldY < 0)
            {
                WorldX *= -1;
                WorldY *= -1;
                img = new Bitmap((Image)Gra.Properties.Resources.ResourceManager.GetObject("world_" + WorldX + "_" + WorldY), Width, Height);
            }
            else
            {
                img = new Bitmap((Image)Gra.Properties.Resources.ResourceManager.GetObject("world" + WorldX + "" + WorldY), Width, Height);
            }

            Device.DrawImage(img, new Point(0, 0));

            foreach (Tile T in MapTiles) //Dla każdego obiektu na liście MapTiles
                Device.DrawImage(T.TileImage, T.TileLoc); //Rysujemy obiekt według poszczególnych parametrów każdego obiektu
        }

        public bool GetWalkableAt(Point Loc) //Zwraca wartość czy możemy się poruszać po danym polu
        {
            foreach (Tile T in MapTiles)
                if (T.TileLoc == Loc)
                    if (T.isWalkable)
                        return true;

            return false;
        }

        public bool GetInteractiveAt(Point Loc) //Zwraca informację o interaktywności obiektu
        {
            foreach (Tile T in MapTiles)
                if (T.TileLoc == Loc)
                    if (T.isInteractive)
                        return true;

            return false;
        }

        public bool GetIsShop(Point Loc)
        {
            foreach (Tile T in MapTiles)
                if (T.TileLoc == Loc)
                    if (T.isShop)
                        return true;

            return false;
        }

        public bool GetIsMapLoader(Point Loc)
        {
            foreach (Tile T in MapTiles)
                if (T.TileLoc == Loc)
                    if (T.isMapLoader)
                        return true;
            return false;
        }
    }

    public class WorldMapSprite
    {
        private Point Location;
        private Image Image;

        public WorldMapSprite(Point location, Image image)
        {
            this.Location = location;
            this.Image = image;
        }

        public void Move(int X, int Y)
        {
            Location.X += X;
            Location.Y += Y;
        }

        public void Draw(Graphics Device, int Width, int Height)
        { Device.DrawImage(Image, Location.X, Location.Y, Width, Height); }

        public Point GetLocation()
        { return this.Location; }

        public void SetLocation(Point loc)
        { this.Location = loc; }

        public Image GetImage()
        { return this.Image; }

        public void SetImage(Image img)
        { this.Image = img; }
    }

    public class WorldMapItem : WorldMapSprite
    {
        int id;
        int amount;

        public WorldMapItem(Point location, Image image, Przedmiot item) : base(location, image)
        {
            id = item.getId();
            amount = item.getIlosc();
        }

        public int getID()
        {
            return id;
        }

        public int getAmount()
        {
            return amount;
        }

        public void Draw(Graphics Device, int Width, int Height)
        { Device.DrawImage(GetImage(), GetLocation().X, GetLocation().Y, Width, Height); }
    }
}