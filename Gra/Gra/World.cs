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
        }
        
        public List<Tile> MapTiles; //Lista wszystkich pól

        public WorldMap(Form form) //Konstruktor
        {
            MapTiles = new List<Tile>(); //Tworzymy pusty świat
        }

        public void LoadMap(string MapName) //Wczytywanie świata
        {
            MapTiles.Clear(); //Czyścimy obecny świat
            StreamReader Reader = new StreamReader(@"MapTileData\" + MapName + ".txt"); //Wczytywanie danych z pliku o podanej ścieżce
            int TileSize = 40;

            int y = 0;

            while (!Reader.EndOfStream) //Wykonuj aż do końca pliku
            {
                string line = Reader.ReadLine(); //Wczytaj linię

                for (int x = 0; x < line.Length; x++)
                {
                    Tile T = new Tile(); //Tworzymy obiekt
                    T.TileLoc = new Point(x * TileSize, y * TileSize); //Ustalamy położenie obiektu (bierzemy pod uwagę jego rozmiar)

                    if (line[x].ToString() == "0") //Sprawdzamy wartość w pliku
                    {
                        T.TileImage = new Bitmap(Gra.Properties.Resources.WaterTile); //Ustalamy obraz                  NOTE: Zmienić na EMPTY - wywoływać tylko kolizję
                        T.isWalkable = false; //Ustalamy czy można się po nim poruszać
                        T.isInteractive = false;
                    }
                    if (line[x].ToString() == "1")
                    {
                        T.TileImage = new Bitmap(Gra.Properties.Resources.GrassTile);
                        T.isWalkable = true;
                        T.isInteractive = false;
                    }
                    if (line[x].ToString() == "2")
                    {
                        T.TileImage = new Bitmap(Gra.Properties.Resources.Empty); //Niewidoczny, interaktywny obiekt
                        T.isWalkable = true;
                        T.isInteractive = true;
                    }

                    MapTiles.Add(T); //Dodajemy dany obiekt mapy do listy
                }

                y++;
            }

            Reader.Close(); //Kończymy czytanie pliku
        }

        public void DrawMap(Graphics Device) //Rysowanie na ekranie
        {
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
    }

    public class WorldMapSprite
    {
        public Point Location;
        public Image Image;
        public int ID;
        public string TextFilename = "";

        public WorldMapSprite(Point location, Image image, int ID)
        {
            this.Location = location;
            this.Image = image;
            this.ID = ID;
        }

        public void Draw(Graphics Device)
        {
            Device.DrawImage(Image, Location);
        }
    }
}