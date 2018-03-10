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
        Bohater Player; //Tworzymy gracza
        Timer timer = new Timer();

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

            Player = new Bohater(100, 100, 0, 0, new Point(23*40, 10*40), Gra.Properties.Resources.Player);

            WorldMapPB = new PictureBox();
            WorldMapPB.Width = GameForm.Width;
            WorldMapPB.Height = GameForm.Height;
            WorldMapPB.BackColor = Color.Transparent;
            WorldMapPB.Parent = GameForm;

            timer.Interval = 1000;

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
            Player.GetCharacterSprite().Draw(Device);

            WorldMapPB.Image = Img;
        }

        Point DesiredMove = new Point(0, 0);

        public void HandleKeyPress(KeyEventArgs e)
        {
            Point p = new Point(0, 0);

            if (e.KeyCode == Keys.Left)
            {
                p = new Point(Player.GetCharacterSprite().GetLocation().X - 40, Player.GetCharacterSprite().GetLocation().Y);
                DesiredMove = p;

                if (CanMove(p))
                {
                    timer.Tick += timer_Tick;

                    if (worldMap.GetIsMapLoader(p))
                    {
                        LoadNewMap(-1, 0);
                        //Player.GetCharacterSprite().SetLocation(p);
                    }
                    else
                    {
                        Player.SetMoveDirection(Postac.MoveDirection.Left);
                        Player.SetIsMoving(true);
                        timer.Start();
                        //Player.GetCharacterSprite().SetLocation(p);
                        //animacja
                    }
                }
            }

            if (e.KeyCode == Keys.Right)
            {
                p = new Point(Player.GetCharacterSprite().GetLocation().X + 40, Player.GetCharacterSprite().GetLocation().Y);
                DesiredMove = p;
                
                if (CanMove(p))
                {
                    timer.Tick += timer_Tick;

                    if (worldMap.GetIsMapLoader(p))
                    {
                        LoadNewMap(+1, 0);
                        //Player.GetCharacterSprite().SetLocation(p);
                    }
                    else
                    {
                        Player.SetMoveDirection(Postac.MoveDirection.Right);
                        Player.SetIsMoving(true);
                        timer.Start();
                        //Player.GetCharacterSprite().SetLocation(p);
                        //animacja
                    }
                }
            }

            if (e.KeyCode == Keys.Up)
            {
                p = new Point(Player.GetCharacterSprite().GetLocation().X, Player.GetCharacterSprite().GetLocation().Y - 40);
                DesiredMove = p;

                if (CanMove(p))
                {
                    timer.Tick += timer_Tick;

                    if (worldMap.GetIsMapLoader(p))
                    {
                        LoadNewMap(0, -1);
                        //Player.GetCharacterSprite().SetLocation(p);
                    }
                    else
                    {
                        Player.SetMoveDirection(Postac.MoveDirection.Up);
                        Player.SetIsMoving(true);
                        timer.Start();
                        //Player.GetCharacterSprite().SetLocation(p);
                        //animacja
                    }
                }
            }

            if (e.KeyCode == Keys.Down)
            {
                p = new Point(Player.GetCharacterSprite().GetLocation().X, Player.GetCharacterSprite().GetLocation().Y + 40);
                DesiredMove = p;

                if (CanMove(p))
                {
                    timer.Tick += timer_Tick;

                    if (worldMap.GetIsMapLoader(p))
                    {
                        LoadNewMap(0, +1);
                        //Player.GetCharacterSprite().SetLocation(p);
                    }
                    else
                    {
                        Player.SetMoveDirection(Postac.MoveDirection.Down);
                        Player.SetIsMoving(true);
                        timer.Start();
                        //Player.GetCharacterSprite().SetLocation(p);
                        //animacja
                    }
                }
            }

            Draw();
        }

        void timer_Tick(object sender, System.EventArgs e)
        {
            if (Player.GetCharacterSprite().GetLocation().X == DesiredMove.X && Player.GetCharacterSprite().GetLocation().Y == DesiredMove.Y)
            {
                Player.SetIsMoving(false);
                timer.Stop();
            }
            else
            {
                if (Player.GetMoveDirection() == Postac.MoveDirection.Left)
                {
                    Point p = new Point(Player.GetCharacterSprite().GetLocation().X - 5, Player.GetCharacterSprite().GetLocation().Y);
                    Player.GetCharacterSprite().SetLocation(p);
                }
                if (Player.GetMoveDirection() == Postac.MoveDirection.Right)
                {
                    Point p = new Point(Player.GetCharacterSprite().GetLocation().X + 5, Player.GetCharacterSprite().GetLocation().Y);
                    Player.GetCharacterSprite().SetLocation(p);
                }
                if (Player.GetMoveDirection() == Postac.MoveDirection.Up)
                {
                    Point p = new Point(Player.GetCharacterSprite().GetLocation().X, Player.GetCharacterSprite().GetLocation().Y - 5);
                    Player.GetCharacterSprite().SetLocation(p);
                }
                if (Player.GetMoveDirection() == Postac.MoveDirection.Down)
                {
                    Point p = new Point(Player.GetCharacterSprite().GetLocation().X, Player.GetCharacterSprite().GetLocation().Y + 5);
                    Player.GetCharacterSprite().SetLocation(p);
                }
            }

            Draw();
        }

        bool CanMove(Point p)
        {
            if (Player.GetIsMoveing() == false)
                if (worldMap.GetWalkableAt(p))
                    return true;
            return false;
        }
    }
}