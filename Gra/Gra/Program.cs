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
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form());
            Application.Run(new Menu()); // odsyła do menu gry
        }
    }

    public class Game
    {
        Form GameForm; //Ustawienie zmiennej na form
        WorldMap worldMap; //Ustawienie zmiennej świata
        PictureBox WorldMapPB; //Ustawienie zmiennej PictureBox'a

        int mapX; //Zmienna X świata
        int mapY; //Zmienna Y świata

        public Game(Form form)
        {
            GameForm = form; //Przypisanie obsługiwanego Forma do tego danego forma
            GameForm.BackColor = Color.White; //Ustawiamy kolor tła na biały

            worldMap = new WorldMap(GameForm);

            mapX = 0;
            mapY = 0;

            LoadNewMap(0, 0);

            WorldMapPB = new PictureBox();
            WorldMapPB.Width = GameForm.Width;
            WorldMapPB.Height = GameForm.Height;
            WorldMapPB.BackColor = Color.Transparent;
            WorldMapPB.Parent = GameForm;

            Draw();
        }

        void LoadNewMap(int MoveX, int MoveY)
        {
            mapX += MoveX;
            mapY += MoveY;
            worldMap.LoadMap(mapX + " " + mapY);
        }

        void Draw()
        {
            Graphics Device;
            Image Img = new Bitmap(GameForm.Width, GameForm.Height);
            Device = Graphics.FromImage(Img);

            worldMap.DrawMap(Device);

            WorldMapPB.Image = Img;
        }
    }
}