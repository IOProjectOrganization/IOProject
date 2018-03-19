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

            Player = new Bohater(1, 100, 50, 0, 0, 4, 4, 4, new Point(23*40, 10*40), Gra.Properties.Resources.Player); // nowy konstruktor ze statystykami(4 do wszystkich)

            WorldMapPB = new PictureBox();
            WorldMapPB.Width = GameForm.Width;
            WorldMapPB.Height = GameForm.Height;
            WorldMapPB.BackColor = Color.Transparent;
            WorldMapPB.Parent = GameForm;

            timer.Tick += timer_Tick;
            timer.Interval = 65;

            Draw();
        }

        void LoadNewMap(int MoveX, int MoveY)
        {
            mapX += MoveX;
            mapY += MoveY;
            worldMap.LoadMap(mapX + "" + mapY);
        }

        void Draw()
        {
            Graphics Device;
            Image Img = new Bitmap(GameForm.Width, GameForm.Height);
            Device = Graphics.FromImage(Img);

            worldMap.DrawMap(Device, mapX, mapY);
            Player.GetCharacterSprite().Draw(Device);

            WorldMapPB.Image = Img;
        }

        Point DesiredMove = new Point(0, 0);

        public void HandleKeyPress(KeyEventArgs e)
        {
            if (Player.GetIsMoving() == false)
            {
                Point p = new Point(0, 0);

                if (e.KeyCode == Keys.Left)
                {
                    p = new Point(Player.GetCharacterSprite().GetLocation().X - 40, Player.GetCharacterSprite().GetLocation().Y);
                    DesiredMove = p;

                    if (CanMove(p))
                    {
                        Player.SetMoveDirection(Postac.MoveDirection.Left);
                        Player.SetIsMoving(true);
                        timer.Start();
                    }
                }

                if (e.KeyCode == Keys.Right)
                {
                    p = new Point(Player.GetCharacterSprite().GetLocation().X + 40, Player.GetCharacterSprite().GetLocation().Y);
                    DesiredMove = p;

                    if (CanMove(p))
                    {
                        Player.SetMoveDirection(Postac.MoveDirection.Right);
                        Player.SetIsMoving(true);
                        timer.Start();
                    }
                }

                if (e.KeyCode == Keys.Up)
                {
                    p = new Point(Player.GetCharacterSprite().GetLocation().X, Player.GetCharacterSprite().GetLocation().Y - 40);
                    DesiredMove = p;

                    if (CanMove(p))
                    {
                            Player.SetMoveDirection(Postac.MoveDirection.Up);
                            Player.SetIsMoving(true);
                            timer.Start();
                    }
                }


                if (e.KeyCode == Keys.Down)
                {
                    p = new Point(Player.GetCharacterSprite().GetLocation().X, Player.GetCharacterSprite().GetLocation().Y + 40);
                    DesiredMove = p;

                    if (CanMove(p))
                    {
                        Player.SetMoveDirection(Postac.MoveDirection.Down);
                        Player.SetIsMoving(true);
                        timer.Start();
                    }
                }
            }
            Draw();
        }

        void timer_Tick(object sender, System.EventArgs e)
        {
            if (Player.GetCharacterSprite().GetLocation().X == DesiredMove.X && Player.GetCharacterSprite().GetLocation().Y == DesiredMove.Y)
            {
                if (worldMap.GetIsMapLoader(Player.GetCharacterSprite().GetLocation()))
                {
                    if (Player.GetMoveDirection() == Postac.MoveDirection.Left)
                    {
                        LoadNewMap(-1, 0);

                        Point z = new Point(32 * 40, Player.GetCharacterSprite().GetLocation().Y);

                        while (worldMap.GetWalkableAt(z) == false || worldMap.GetIsMapLoader(z) == true)
                            z.X -= 40;

                        Player.GetCharacterSprite().SetLocation(z);
                    }

                    if (Player.GetMoveDirection() == Postac.MoveDirection.Right)
                    {
                        LoadNewMap(1, 0);

                        Point z = new Point(0, Player.GetCharacterSprite().GetLocation().Y);

                        while (worldMap.GetWalkableAt(z) == false || worldMap.GetIsMapLoader(z) == true)
                            z.X += 40;

                        Player.GetCharacterSprite().SetLocation(z);
                    }

                    if (Player.GetMoveDirection() == Postac.MoveDirection.Up)
                    {
                        LoadNewMap(0, -1);

                        Point z = new Point(Player.GetCharacterSprite().GetLocation().X, 18 * 40);

                        while (worldMap.GetWalkableAt(z) == false || worldMap.GetIsMapLoader(z) == true)
                            z.Y -= 40;

                        Player.GetCharacterSprite().SetLocation(z);
                    }

                    if (Player.GetMoveDirection() == Postac.MoveDirection.Down)
                    {
                        LoadNewMap(0, 1);

                        Point z = new Point(Player.GetCharacterSprite().GetLocation().X, 0);

                        while (worldMap.GetWalkableAt(z) == false || worldMap.GetIsMapLoader(z) == true)
                            z.X += 40;

                        Player.GetCharacterSprite().SetLocation(z);
                    }
                }
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
            if (worldMap.GetWalkableAt(p))
                return true;
            return false;
        }
    }
}