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
        public List<Przeciwnik> worldEnemies;

        Equipment equipment = new Equipment();

        Shop shop = new Shop();
        Postac sklepikarz = new Postac();   // Bohater zmieniony na Postac

        QuestsList questsList = new QuestsList();

        Combat combat;

        Quit quit = new Quit();

        Timer timer = new Timer();
        Timer CombatTimer = new Timer();

        Random random = new Random();
        int MTB = 0;

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
            worldEnemies = new List<Przeciwnik>();

            mapX = 0;
            mapY = 0;

            _Width = GameForm.Width;
            _Height = GameForm.Height;

            LoadNewMap(0, 0);

            Player = new Bohater(1, 100, 50, 0, 0, 4, 4, 4, new Point(23 * (_Width / 32), 10 * (_Height / 18)), Gra.Properties.Resources.Player, Gra.Properties.Resources.PlayerCombat); // nowy konstruktor ze statystykami(4 do wszystkich)

            Player.AddQuest(Task.questId_Cave);
            Player.ChangeQuestIsActive(Task.questId_Cave, true);
            Player.ChangeQuestStatus(Task.questId_Cave, QuestStatus.Active);
            

            WorldMapPB = new PictureBox();
            WorldMapPB.Width = GameForm.Width;
            WorldMapPB.Height = GameForm.Height;
            WorldMapPB.BackColor = Color.Transparent;
            WorldMapPB.Parent = GameForm;

            timer.Tick += timer_Tick;
            timer.Interval = 10;

            CombatTimer.Tick += combatTimer_Tick;
            CombatTimer.Interval = 100;

            Draw();
        }

        void LoadNewMap(int MoveX, int MoveY)
        {
            sklepikarz.WyczyscEkwipunek();

            MTB = random.Next(15, 20);
            mapX += MoveX;
            mapY += MoveY;
            worldMap.LoadMap(mapX + "" + mapY, _Width / 32, _Height / 18, true, worldEnemies);

            System.Random product = new Random(System.DateTime.Now.Millisecond);
            for(int i = 0; i < 3; i++)
            {
                sklepikarz.DodajPrzedmiot(product.Next(1, 7));
            }
        }

        void ReloadMap()
        { worldMap.LoadMap(mapX + "" + mapY, _Width / 32, _Height / 18, false, worldEnemies); }

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

            foreach (Przeciwnik P in worldEnemies)
            {
                if (P != null && P.getIsAlive() == true)
                    P.GetCharacterSprite().Draw(Device, _Width / 32, _Height / 18);
            }


            WorldMapPB.Image = Img;
        }

        Point DesiredMove = new Point(0, 0);

        public void HandleKeyPress(KeyEventArgs e)
        {
            if (Player.GetIsMoving() == false)
            {
                Point p = new Point(0, 0);
                if (e.KeyCode == Keys.E)
                {
                    if (worldMap.GetInteractiveAt(new Point(Player.GetCharacterSprite().GetLocation().X, Player.GetCharacterSprite().GetLocation().Y)) ||
                    worldMap.GetInteractiveAt(new Point(Player.GetCharacterSprite().GetLocation().X - _Width / 32, Player.GetCharacterSprite().GetLocation().Y)) ||
                    worldMap.GetInteractiveAt(new Point(Player.GetCharacterSprite().GetLocation().X + _Width / 32, Player.GetCharacterSprite().GetLocation().Y)) ||
                    worldMap.GetInteractiveAt(new Point(Player.GetCharacterSprite().GetLocation().X, Player.GetCharacterSprite().GetLocation().Y - _Height / 18)) ||
                    worldMap.GetInteractiveAt(new Point(Player.GetCharacterSprite().GetLocation().X, Player.GetCharacterSprite().GetLocation().Y + _Height / 18)))
                    {
                        if ((worldMap.GetIsShop(new Point(Player.GetCharacterSprite().GetLocation().X, Player.GetCharacterSprite().GetLocation().Y)) ||
                            worldMap.GetIsShop(new Point(Player.GetCharacterSprite().GetLocation().X - _Width / 32, Player.GetCharacterSprite().GetLocation().Y)) ||
                            worldMap.GetIsShop(new Point(Player.GetCharacterSprite().GetLocation().X + _Width / 32, Player.GetCharacterSprite().GetLocation().Y)) ||
                            worldMap.GetIsShop(new Point(Player.GetCharacterSprite().GetLocation().X, Player.GetCharacterSprite().GetLocation().Y - _Height / 18)) ||
                            worldMap.GetIsShop(new Point(Player.GetCharacterSprite().GetLocation().X, Player.GetCharacterSprite().GetLocation().Y + _Height / 18))))
                        {
                            shop.UpdateEquipment(Player);
                            shop.UpdateProducts(sklepikarz);
                            shop.Show();
                            shop.Focus();
                        }
                        else
                        {


                            WorldMapItem item = null;

                            if (item == null) item = worldMap.worldMapItems.Find(c => c.GetLocation().X == Player.GetCharacterSprite().GetLocation().X - _Width / 32 && c.GetLocation().Y == Player.GetCharacterSprite().GetLocation().Y);
                            if (item == null) item = worldMap.worldMapItems.Find(c => c.GetLocation().X == Player.GetCharacterSprite().GetLocation().X + _Width / 32 && c.GetLocation().Y == Player.GetCharacterSprite().GetLocation().Y);
                            if (item == null) item = worldMap.worldMapItems.Find(c => c.GetLocation().X == Player.GetCharacterSprite().GetLocation().X && c.GetLocation().Y == Player.GetCharacterSprite().GetLocation().Y - _Height / 18);
                            if (item == null) item = worldMap.worldMapItems.Find(c => c.GetLocation().X == Player.GetCharacterSprite().GetLocation().X && c.GetLocation().Y == Player.GetCharacterSprite().GetLocation().Y + _Height / 18);

                            if (item != null)
                            {
                                if (item.getID() != Item.itemId_gold)
                                {
                                    Player.DodajPrzedmiot(item.getID());
                                }
                                else
                                {
                                    System.Random goldToGet = new Random();
                                    int gold;
                                    gold = goldToGet.Next(1, 500);

                                    Player.DodajGold(gold);
                                }


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
                        }
                    }
                }

                else if (e.KeyCode == Keys.I)
                {
                    equipment.Height = _Height * 2 / 3;
                    equipment.Width = _Width * 2 / 3;
                    equipment.UpdateEquipment(Player);
                    equipment.Show();
                    equipment.Focus();
                }

                else if (e.KeyCode == Keys.L)
                {
                    questsList.Height = _Height * 2 / 3;
                    questsList.Width = _Width * 2 / 3;
                    questsList.UpdateQuestsList(Player);
                    questsList.Show();
                    questsList.Focus();
                }

                else if (e.KeyCode == Keys.Escape)
                {
                    quit.Height = _Height / 6;
                    quit.Width = _Width / 4;
                    quit.Show();
                    quit.sendForm(GameForm);
                    quit.Focus();
                }

                else if (e.KeyCode == Keys.W)
                {
                    Player.DodajEXP(20);
                }

                else if (e.KeyCode == Keys.Left)
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

                else if (e.KeyCode == Keys.Right)
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

                else if (e.KeyCode == Keys.Up)
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


                else if (e.KeyCode == Keys.Down)
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

                    else if (Player.GetMoveDirection() == Postac.MoveDirection.Right)
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

                    else if (Player.GetMoveDirection() == Postac.MoveDirection.Up)
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

                    else if (Player.GetMoveDirection() == Postac.MoveDirection.Down)
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

                MTB--;

                if (MTB <= 0)
                {
                    combat = new Combat();
                    combat.StartCombat(Player, Wrog.EnemyById(Wrog.enemyId_nietoperz));
                    combat.Show();
                    combat.Focus();

                    CombatTimer.Start();

                    MTB = random.Next(15, 20);
                }

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

                else if (Player.GetMoveDirection() == Postac.MoveDirection.Right)
                {
                    Point p = new Point(Player.GetCharacterSprite().GetLocation().X + (_Width / 32) / 4, Player.GetCharacterSprite().GetLocation().Y);
                    Player.GetCharacterSprite().SetLocation(p);
                    Player.SetXTileIndex(Player.GetXTileIndex() + 1);
                }

                else if (Player.GetMoveDirection() == Postac.MoveDirection.Up)
                {
                    Point p = new Point(Player.GetCharacterSprite().GetLocation().X, Player.GetCharacterSprite().GetLocation().Y - (_Height / 18) / 3);
                    Player.GetCharacterSprite().SetLocation(p);
                    Player.SetYTileIndex(Player.GetYTileIndex() - 1);
                }

                else if (Player.GetMoveDirection() == Postac.MoveDirection.Down)
                {
                    Point p = new Point(Player.GetCharacterSprite().GetLocation().X, Player.GetCharacterSprite().GetLocation().Y + (_Height / 18) / 3);
                    Player.GetCharacterSprite().SetLocation(p);
                    Player.SetYTileIndex(Player.GetYTileIndex() + 1);
                }

                foreach (Przeciwnik P in worldEnemies)
                {
                    if (isInEnemyRange(P))
                    {
                        if (P != null)
                        {
                            combat = new Combat();

                            combat.StartCombat(Player, P);
                            combat.Show();
                            combat.Focus();

                            CombatTimer.Start();

                            MTB = random.Next(15, 20);
                        }
                    }
                }
            }

            Draw();
        }

        void combatTimer_Tick(object sender, System.EventArgs e)
        {
            if (!combat.GetIsInCombat())
            {
                if (combat.GetIsPlayerWinner())
                {
                    int i = 0;
                    StringBuilder newFile = new StringBuilder();
                    string[] text = File.ReadAllLines(@"MapTileData\1_maptiles" + mapX + "" + mapY + ".txt");
                    string temp = "";

                    foreach (Przeciwnik P in worldEnemies)
                    {
                        if (!P.getIsAlive())
                        {
                            foreach (string line in text)
                            {
                                if (i != P.GetCharacterSprite().GetLocation().Y / (_Height / 18))
                                {
                                    newFile.AppendLine(line);
                                }
                                if (i == P.GetCharacterSprite().GetLocation().Y / (_Height / 18))
                                {
                                    temp = line.Substring(0, P.GetCharacterSprite().GetLocation().X / (_Width / 32) * 4);
                                    temp += 1;
                                    temp += 0;
                                    temp += 0;
                                    temp += line.Substring(P.GetCharacterSprite().GetLocation().X / (_Width / 32) * 4 + 3);

                                    newFile.Append(temp + "\r\n");
                                }

                                i++;
                            }

                            File.WriteAllText(@"MapTileData\1_maptiles" + mapX + "" + mapY + ".txt", newFile.ToString());
                        }
                    }

                    worldEnemies.RemoveAll(P => P.getIsAlive() == false);
                    ReloadMap();

                    CombatTimer.Stop();
                    Draw();
                }
                else
                {
                    CombatTimer.Stop();
                    Draw();
                }
            }
        }


        bool CanMove(Point p)
        {
            if (worldMap.GetWalkableAt(p))
                return true;
            return false;
        }

        bool isInEnemyRange(Przeciwnik Enemy)
        {
            if (Enemy != null)
            {
                if ((Player.GetCharacterSprite().GetLocation().X - (_Width / 32) == Enemy.GetCharacterSprite().GetLocation().X && Player.GetCharacterSprite().GetLocation().Y + (_Height / 18) == Enemy.GetCharacterSprite().GetLocation().Y) ||
                  (Player.GetCharacterSprite().GetLocation().X == Enemy.GetCharacterSprite().GetLocation().X && Player.GetCharacterSprite().GetLocation().Y + (_Height / 18) == Enemy.GetCharacterSprite().GetLocation().Y) ||
                  (Player.GetCharacterSprite().GetLocation().X + (_Width / 32) == Enemy.GetCharacterSprite().GetLocation().X && Player.GetCharacterSprite().GetLocation().Y + (_Height / 18) == Enemy.GetCharacterSprite().GetLocation().Y) ||
                  (Player.GetCharacterSprite().GetLocation().X - (_Width / 32) == Enemy.GetCharacterSprite().GetLocation().X && Player.GetCharacterSprite().GetLocation().Y == Enemy.GetCharacterSprite().GetLocation().Y) ||
                  (Player.GetCharacterSprite().GetLocation().X + (_Width / 32) == Enemy.GetCharacterSprite().GetLocation().X && Player.GetCharacterSprite().GetLocation().Y == Enemy.GetCharacterSprite().GetLocation().Y) ||
                  (Player.GetCharacterSprite().GetLocation().X - (_Width / 32) == Enemy.GetCharacterSprite().GetLocation().X && Player.GetCharacterSprite().GetLocation().Y - (_Height / 18) == Enemy.GetCharacterSprite().GetLocation().Y) ||
                  (Player.GetCharacterSprite().GetLocation().X == Enemy.GetCharacterSprite().GetLocation().X && Player.GetCharacterSprite().GetLocation().Y - (_Height / 18) == Enemy.GetCharacterSprite().GetLocation().Y) ||
                  (Player.GetCharacterSprite().GetLocation().X + (_Width / 32) == Enemy.GetCharacterSprite().GetLocation().X && Player.GetCharacterSprite().GetLocation().Y - (_Height / 18) == Enemy.GetCharacterSprite().GetLocation().Y))
                {
                    return true;
                }
            }
            return false;
        }

    }
}