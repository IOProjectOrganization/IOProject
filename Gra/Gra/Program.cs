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

        public WorldMap worldMap; //Ustawienie zmiennej świata
        public PictureBox WorldMapPB; //Ustawienie zmiennej PictureBox'a

        Bohater Player; //Tworzymy gracza
        Equipment equipment = new Equipment();

        Timer timer = new Timer();

        public int mapX = 0; //Zmienna X świata
        public int mapY = 0; //Zmienna Y świata

        public int _Width;
        public int _Height;

        public Game(Form form)
        {
            GameForm = form; //Przypisanie obsługiwanego Forma do tego danego forma
            GameForm.BackColor = Color.White; //Ustawiamy kolor tła na biały

            worldMap = new WorldMap(GameForm);
            worldMap.worldMapItems = new List<WorldMapItem>();

            mapX = 0;
            mapY = 0;

            _Width = GameForm.Width;
            _Height = GameForm.Height;

            LoadNewMap(0, 0);

            Player = new Bohater(1, 100, 50, 0, 0, 4, 4, 4, new Point(23 * (_Width / 32), 10 * (_Height / 18)), Gra.Properties.Resources.Player); // nowy konstruktor ze statystykami(4 do wszystkich)

            WorldMapPB = new PictureBox();
            WorldMapPB.Width = GameForm.Width;
            WorldMapPB.Height = GameForm.Height;
            WorldMapPB.BackColor = Color.Transparent;
            WorldMapPB.Parent = GameForm;

            timer.Tick += timer_Tick;
            timer.Interval = 10;

            Draw();
        }

        void LoadNewMap(int MoveX, int MoveY)
        {
            mapX += MoveX;
            mapY += MoveY;
            worldMap.LoadMap(mapX + "" + mapY, _Width / 32, _Height / 18, true);
        }

        void ReloadMap()
        { worldMap.LoadMap(mapX + "" + mapY, _Width / 32, _Height / 18, false); }

        public void Draw()
        {
            WorldMapPB.Width = GameForm.Width;
            WorldMapPB.Height = GameForm.Height;
            _Width = GameForm.Width;
            _Height = GameForm.Height;

            Graphics Device;
            Image Img = new Bitmap(_Width, _Height);
            Device = Graphics.FromImage(Img);

            worldMap.DrawMap(Device, mapX, mapY, _Width, _Height);
            Player.GetCharacterSprite().Draw(Device, _Width / 32, _Height / 18);

            WorldMapPB.Image = Img;
        }

        Point DesiredMove = new Point(0, 0);

        public void HandleKeyPress(KeyEventArgs e)
        {
            if (Player.GetIsMoving() == false)
            {
                Point p = new Point(0, 0);

                if (worldMap.GetInteractiveAt(new Point(Player.GetCharacterSprite().GetLocation().X, Player.GetCharacterSprite().GetLocation().Y)) ||
                    worldMap.GetInteractiveAt(new Point(Player.GetCharacterSprite().GetLocation().X - _Width / 32, Player.GetCharacterSprite().GetLocation().Y)) ||
                    worldMap.GetInteractiveAt(new Point(Player.GetCharacterSprite().GetLocation().X + _Width / 32, Player.GetCharacterSprite().GetLocation().Y)) ||
                    worldMap.GetInteractiveAt(new Point(Player.GetCharacterSprite().GetLocation().X, Player.GetCharacterSprite().GetLocation().Y - _Height / 18)) ||
                    worldMap.GetInteractiveAt(new Point(Player.GetCharacterSprite().GetLocation().X, Player.GetCharacterSprite().GetLocation().Y + _Height / 18)))
                {
                    if (e.KeyCode == Keys.E)
                    {
                        //########################################################
                        WorldMapItem item = null;

                        if (item == null) item = worldMap.worldMapItems.Find(c => c.GetLocation().X == Player.GetCharacterSprite().GetLocation().X - _Width / 32 && c.GetLocation().Y == Player.GetCharacterSprite().GetLocation().Y);
                        if (item == null) item = worldMap.worldMapItems.Find(c => c.GetLocation().X == Player.GetCharacterSprite().GetLocation().X + _Width / 32 && c.GetLocation().Y == Player.GetCharacterSprite().GetLocation().Y);
                        if (item == null) item = worldMap.worldMapItems.Find(c => c.GetLocation().X == Player.GetCharacterSprite().GetLocation().X && c.GetLocation().Y == Player.GetCharacterSprite().GetLocation().Y - _Height / 18);
                        if (item == null) item = worldMap.worldMapItems.Find(c => c.GetLocation().X == Player.GetCharacterSprite().GetLocation().X && c.GetLocation().Y == Player.GetCharacterSprite().GetLocation().Y + _Height / 18);

                        if (item != null)
                        {
                            Player.DodajPrzedmiot(item.getID());
                            ReloadMap();

                            int i = 0;
                            StringBuilder newFile = new StringBuilder();
                            string[] text = File.ReadAllLines(@"MapTileData\1_maptiles" + mapX + "" + mapY + ".txt");
                            string temp = "";

                            foreach (string line in text)
                            {
                                if (i != item.GetLocation().Y / (_Height / 18))
                                {
                                    newFile.AppendLine(line);
                                }
                                if (i == item.GetLocation().Y / (_Height / 18))
                                {
                                    temp = line.Substring(0, item.GetLocation().X / (_Width / 32) * 4);
                                    temp += "1";
                                    temp += line.Substring(item.GetLocation().X / (_Width / 32) * 4 + 1);

                                    newFile.Append(temp + "\r\n");
                                }

                                i++;
                            }

                            File.WriteAllText(@"MapTileData\1_maptiles" + mapX + "" + mapY + ".txt", newFile.ToString());
                            worldMap.worldMapItems.Remove(item);
                            ReloadMap();
                        }
                        //########################################################
                    }
                }

                if (e.KeyCode == Keys.I)
                {
                    equipment.UpdateEquipment(Player);
                    equipment.Show();
                    equipment.Focus();


                    //MessageBox.Show(Player.Ekwipunek.ElementAt(0).getNazwa().ToString());
                    //foreach (Przedmiot item in Player.Ekwipunek)
                    //{
                    //    MessageBox.Show(item.getNazwa().ToString());
                    //}
                }

                if (e.KeyCode == Keys.Left)
                {
                    p = new Point(Player.GetCharacterSprite().GetLocation().X - (_Width / 32), Player.GetCharacterSprite().GetLocation().Y);
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
                    p = new Point(Player.GetCharacterSprite().GetLocation().X + (_Width / 32), Player.GetCharacterSprite().GetLocation().Y);
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
                    p = new Point(Player.GetCharacterSprite().GetLocation().X, Player.GetCharacterSprite().GetLocation().Y - (_Height / 18));
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
                    p = new Point(Player.GetCharacterSprite().GetLocation().X, Player.GetCharacterSprite().GetLocation().Y + (_Height / 18));
                    DesiredMove = p;

                    if (CanMove(p))
                    {
                        Player.SetMoveDirection(Postac.MoveDirection.Down);
                        Player.SetIsMoving(true);
                        timer.Start();
                    }
                }

                if (e.KeyCode == Keys.Escape)
                {
                    if (DialogResult.Yes == MessageBox.Show("Are you sure?", "Quit", MessageBoxButtons.YesNo)) // zamyka program, jeśli w wyświetlonym oknie Quit wybrano Yes
                    {
                        GameForm.Close();
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

                        Point z = new Point(32 * (_Width / 32), Player.GetCharacterSprite().GetLocation().Y);

                        Player.SetXTileIndex(32);

                        while (worldMap.GetWalkableAt(z) == false || worldMap.GetIsMapLoader(z) == true)
                        {
                            z.X -= (_Width / 32);
                        }

                        Player.GetCharacterSprite().SetLocation(z);
                    }

                    if (Player.GetMoveDirection() == Postac.MoveDirection.Right)
                    {
                        LoadNewMap(1, 0);

                        Point z = new Point(0, Player.GetCharacterSprite().GetLocation().Y);

                        Player.SetXTileIndex(0);

                        while (worldMap.GetWalkableAt(z) == false || worldMap.GetIsMapLoader(z) == true)
                        {
                            z.X += (_Width / 32);
                            Player.SetXTileIndex(Player.GetXTileIndex() + 1);
                        }

                        Player.GetCharacterSprite().SetLocation(z);
                    }

                    if (Player.GetMoveDirection() == Postac.MoveDirection.Up)
                    {
                        LoadNewMap(0, -1);

                        Point z = new Point(Player.GetCharacterSprite().GetLocation().X, 18 * 40);

                        Player.SetYTileIndex(18);

                        while (worldMap.GetWalkableAt(z) == false || worldMap.GetIsMapLoader(z) == true)
                        {
                            z.Y -= (_Height / 18);
                            Player.SetYTileIndex(Player.GetYTileIndex() - 1);
                        }

                        Player.GetCharacterSprite().SetLocation(z);
                    }

                    if (Player.GetMoveDirection() == Postac.MoveDirection.Down)
                    {
                        LoadNewMap(0, 1);

                        Point z = new Point(Player.GetCharacterSprite().GetLocation().X, 0);

                        Player.SetYTileIndex(0);

                        while (worldMap.GetWalkableAt(z) == false || worldMap.GetIsMapLoader(z) == true)
                        {
                            z.X += (_Height / 18);
                            Player.SetYTileIndex(Player.GetYTileIndex() + 1);
                        }
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
                    Point p = new Point(Player.GetCharacterSprite().GetLocation().X - (_Width / 32) / 4, Player.GetCharacterSprite().GetLocation().Y);
                    Player.GetCharacterSprite().SetLocation(p);
                    Player.SetXTileIndex(Player.GetXTileIndex() - 1);
                }
                if (Player.GetMoveDirection() == Postac.MoveDirection.Right)
                {
                    Point p = new Point(Player.GetCharacterSprite().GetLocation().X + (_Width / 32) / 4, Player.GetCharacterSprite().GetLocation().Y);
                    Player.GetCharacterSprite().SetLocation(p);
                    Player.SetXTileIndex(Player.GetXTileIndex() + 1);
                }
                if (Player.GetMoveDirection() == Postac.MoveDirection.Up)
                {
                    Point p = new Point(Player.GetCharacterSprite().GetLocation().X, Player.GetCharacterSprite().GetLocation().Y - (_Height / 18) / 3);
                    Player.GetCharacterSprite().SetLocation(p);
                    Player.SetYTileIndex(Player.GetYTileIndex() - 1);
                }
                if (Player.GetMoveDirection() == Postac.MoveDirection.Down)
                {
                    Point p = new Point(Player.GetCharacterSprite().GetLocation().X, Player.GetCharacterSprite().GetLocation().Y + (_Height / 18) / 3);
                    Player.GetCharacterSprite().SetLocation(p);
                    Player.SetYTileIndex(Player.GetYTileIndex() + 1);
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