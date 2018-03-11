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
            public bool isMapLoader;
        }
        
        public List<Tile> MapTiles; //Lista wszystkich pól

        public WorldMap(Form form) //Konstruktor
        {
            MapTiles = new List<Tile>(); //Tworzymy pusty świat
        }

        public void LoadMap(string MapName) //Wczytywanie świata
        {
            MapTiles.Clear(); //Czyścimy obecny świat

            StreamReader Reader = new StreamReader(@"MapTileData\maptiles" + MapName + ".txt"); //Wczytywanie danych z pliku o podanej ścieżce

            int TileSize = 40;

            int y = 0;

            while (!Reader.EndOfStream) //Wykonuj aż do końca pliku
            {
                string line = Reader.ReadLine(); //Wczytaj linię

                for (int x = 0; x < line.Length; x++)
                {
                    Tile T = new Tile(); //Tworzymy obiekt
                    T.TileLoc = new Point(x * TileSize, y * TileSize); //Ustalamy położenie obiektu (bierzemy pod uwagę jego rozmiar)

                    if (line[x].ToString() == "t")
                    {
                        T.TileImage = new Bitmap(Gra.Properties.Resources.Empty);
                        T.isWalkable = true;
                        T.isInteractive = false;
                        T.isMapLoader = true;
                    }
                    if (line[x].ToString() == "0") //Sprawdzamy wartość w pliku
                    {
                        T.TileImage = new Bitmap(Gra.Properties.Resources.Empty); //Ustalamy obraz                  NOTE: Zmienić na EMPTY - wywoływać tylko kolizję
                        T.isWalkable = false; //Ustalamy czy można się po nim poruszać
                        T.isInteractive = false;
                        T.isMapLoader = false;
                    }
                    if (line[x].ToString() == "1") 
                    {
                        T.TileImage = new Bitmap(Gra.Properties.Resources.Empty);
                        T.isWalkable = true;
                        T.isInteractive = false;
                        T.isMapLoader = false;
                    }
                    if (line[x].ToString() == "2")
                    {
                        T.TileImage = new Bitmap(Gra.Properties.Resources.Empty); //Niewidoczny, interaktywny obiekt
                        T.isWalkable = true;
                        T.isInteractive = true;
                        T.isMapLoader = false;
                    }

                    MapTiles.Add(T); //Dodajemy dany obiekt mapy do listy
                }

                y++;
            }

            Reader.Close(); //Kończymy czytanie pliku
        }

        public void DrawMap(Graphics Device, int WorldX, int WorldY) //Rysowanie na ekranie
        {
            Image img;

            foreach (Tile T in MapTiles) //Dla każdego obiektu na liście MapTiles
                Device.DrawImage(T.TileImage, T.TileLoc); //Rysujemy obiekt według poszczególnych parametrów każdego obiektu

            if (WorldX < 0 && WorldY >= 0)
            {
                WorldX *= -1;
                img = new Bitmap((Image)Gra.Properties.Resources.ResourceManager.GetObject("world_" + WorldX + "" + WorldY));
            }
            else if (WorldX >= 0 && WorldY < 0)
            {
                WorldY *= -1;
                img = new Bitmap((Image)Gra.Properties.Resources.ResourceManager.GetObject("world" + WorldX + "_" + WorldY));
            }
            else if (WorldX < 0 && WorldY < 0)
            {
                WorldX *= -1;
                WorldY *= -1;
                img = new Bitmap((Image)Gra.Properties.Resources.ResourceManager.GetObject("world_" + WorldX + "_" + WorldY));
            }
            else
            {
                img = new Bitmap((Image)Gra.Properties.Resources.ResourceManager.GetObject("world" + WorldX + "" + WorldY));
            }

            Device.DrawImage(img, new Point(0, 0));
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

        public void Draw(Graphics Device)
        {
            Device.DrawImage(Image, Location);
        }

        public Point GetLocation()
        { return this.Location; }

        public void SetLocation(Point loc)
        { this.Location = loc; }

        public Image GetImage()
        { return this.Image; }

        public void SetImage(Image img)
        { this.Image = img; }
    }
}