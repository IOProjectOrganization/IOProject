using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;

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
        public List<PrzyjaznyNPC> worldFriendlies;
        Postac sklepikarz = new Postac();   // Bohater zmieniony na Postac

        Shop shop;
        Equipment equipment;
        QuestsList questsList;
        Combat combat;
        Dialog dialog;
        Quit quit;

        public XmlDocument xml = new XmlDocument();

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
            worldFriendlies = new List<PrzyjaznyNPC>();

            xml.Load(@"../../SaveFile.xml");
            XmlNodeList xmlNodeList;

            mapX = 0;
            mapY = 0;

            _Width = GameForm.Width;
            _Height = GameForm.Height;

            LoadNewMap(0, 0);

            if (int.Parse(xml.SelectSingleNode("/postac/save").Attributes["save"].Value) > 0)
            {
                Player = new Bohater(int.Parse(xml.SelectNodes("/postac/postac").Item(0).Attributes["level"].Value),
                                     int.Parse(xml.SelectNodes("/postac/postac").Item(6).Attributes["maxhp"].Value),
                                     int.Parse(xml.SelectNodes("/postac/postac").Item(7).Attributes["maxmp"].Value),
                                     int.Parse(xml.SelectNodes("/postac/postac").Item(5).Attributes["gold"].Value),
                                     int.Parse(xml.SelectNodes("/postac/postac").Item(1).Attributes["exp"].Value),
                                     int.Parse(xml.SelectNodes("/postac/postac").Item(2).Attributes["str"].Value),
                                     int.Parse(xml.SelectNodes("/postac/postac").Item(3).Attributes["dex"].Value),
                                     int.Parse(xml.SelectNodes("/postac/postac").Item(4).Attributes["int"].Value),
                                     new Point(int.Parse(xml.SelectNodes("/postac/postac").Item(8).Attributes["XTile"].Value) * (_Width / 32),
                                               int.Parse(xml.SelectNodes("/postac/postac").Item(8).Attributes["YTile"].Value) * (_Height / 18)),
                                     Gra.Properties.Resources.Player,
                                     Gra.Properties.Resources.PlayerCombat,
                                     Gra.Properties.Resources.player_talk);

                Player.SetXTileIndex(int.Parse(xml.SelectNodes("/postac/postac").Item(8).Attributes["XTile"].Value));
                Player.SetYTileIndex(int.Parse(xml.SelectNodes("/postac/postac").Item(8).Attributes["YTile"].Value));

                mapX = int.Parse(xml.SelectNodes("/postac/world").Item(0).Attributes["mapx"].Value);
                mapY = int.Parse(xml.SelectNodes("/postac/world").Item(0).Attributes["mapy"].Value);

                xmlNodeList = xml.GetElementsByTagName("item");
                for (int i = 0; i < xmlNodeList.Count; i++)
                {
                    for (int j = 0; j < int.Parse(xmlNodeList[i].Attributes.Item(1).Value); j++)
                    {
                        Player.DodajPrzedmiot(int.Parse(xmlNodeList[i].Attributes.Item(0).Value));
                    }
                }


                xmlNodeList = xml.GetElementsByTagName("equippedWeapon");
                if (xmlNodeList.Count > 0)
                {
                    Player.DodajPrzedmiot(int.Parse(xmlNodeList[0].Attributes.Item(0).Value));
                    Player.ZalozBron(Player.Ekwipunek.ElementAt(Player.Ekwipunek.Count - 1) as Bron);
                    Player.Ekwipunek.RemoveAt(Player.Ekwipunek.Count - 1);
                }

                xmlNodeList = xml.GetElementsByTagName("equippedArmor");
                if (xmlNodeList.Count > 0)
                {
                    Player.DodajPrzedmiot(int.Parse(xmlNodeList[0].Attributes.Item(0).Value));
                    Player.ZalozZbroje(Player.Ekwipunek.ElementAt(Player.Ekwipunek.Count - 1) as Zbroja);
                    Player.Ekwipunek.RemoveAt(Player.Ekwipunek.Count - 1);
                }

                ReloadMap();
            }
            else
            {
                Player = new Bohater(1,
                                     100,
                                     50,
                                     0,
                                     0,
                                     4,
                                     4,
                                     4,
                                     new Point(23 * (_Width / 32), 10 * (_Height / 18)),
                                     Gra.Properties.Resources.Player,
                                     Gra.Properties.Resources.PlayerCombat,
                                     Gra.Properties.Resources.player_talk);

                Player.SetXTileIndex(23);
                Player.SetYTileIndex(10);
            }

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

            int g = int.Parse(xml.SelectSingleNode("/postac/save").Attributes["save"].Value);
            xml.SelectSingleNode("postac/save").Attributes["save"].Value = (++g).ToString();

            xml.SelectNodes("/postac/postac").Item(0).Attributes["level"].Value = Player.GetLevel().ToString();
            xml.SelectNodes("/postac/postac").Item(1).Attributes["exp"].Value = Player.GetEXP().ToString();
            xml.SelectNodes("/postac/postac").Item(2).Attributes["str"].Value = Player.GetStrength().ToString();
            xml.SelectNodes("/postac/postac").Item(3).Attributes["dex"].Value = Player.GetDexterity().ToString();
            xml.SelectNodes("/postac/postac").Item(4).Attributes["int"].Value = Player.GetIntelligence().ToString();
            xml.SelectNodes("/postac/postac").Item(5).Attributes["gold"].Value = Player.GetGold().ToString();
            xml.SelectNodes("/postac/postac").Item(6).Attributes["maxhp"].Value = Player.GetMaxHP().ToString();
            xml.SelectNodes("/postac/postac").Item(6).Attributes["hp"].Value = Player.GetHP().ToString();
            xml.SelectNodes("/postac/postac").Item(7).Attributes["maxmp"].Value = Player.GetMaxMP().ToString();
            xml.SelectNodes("/postac/postac").Item(7).Attributes["mp"].Value = Player.GetMP().ToString();
            xml.SelectNodes("/postac/postac").Item(8).Attributes["XTile"].Value = Player.GetXTileIndex().ToString();
            xml.SelectNodes("/postac/postac").Item(8).Attributes["YTile"].Value = Player.GetYTileIndex().ToString();

            xml.SelectNodes("postac/world").Item(0).Attributes["mapx"].Value = mapX.ToString();
            xml.SelectNodes("postac/world").Item(0).Attributes["mapy"].Value = mapY.ToString();

            xmlNodeList = xml.GetElementsByTagName("item");
            for (int i = 0; i < xmlNodeList.Count; ++i)
                xmlNodeList[i].ParentNode.RemoveChild(xmlNodeList[i]);

            xmlNodeList = xml.GetElementsByTagName("item");
            for (int i = 0; i < xmlNodeList.Count; ++i)
                xmlNodeList[i].ParentNode.RemoveChild(xmlNodeList[i]);

            foreach (Przedmiot item in Player.Ekwipunek)
            {
                XmlElement items = xml.CreateElement("item");
                XmlAttribute attribute1 = xml.CreateAttribute("id");
                XmlAttribute attribute2 = xml.CreateAttribute("amount");

                attribute1.Value = item.getId().ToString();
                attribute2.Value = item.getIlosc().ToString();

                items.Attributes.Append(attribute1);
                items.Attributes.Append(attribute2);

                xml.DocumentElement.AppendChild(items);
            }

            xmlNodeList = xml.GetElementsByTagName("equippedWeapon");
            for (int i = 0; i < xmlNodeList.Count; i++)
                xmlNodeList[i].ParentNode.RemoveChild(xmlNodeList[i]);

            xmlNodeList = xml.GetElementsByTagName("equippedWeapon");
            for (int i = 0; i < xmlNodeList.Count; i++)
                xmlNodeList[i].ParentNode.RemoveChild(xmlNodeList[i]);

            if (Player.getZalozonaBron() != null)
            {
                XmlElement equippedWeapon = xml.CreateElement("equippedWeapon");

                XmlAttribute attribute1 = xml.CreateAttribute("id");
                attribute1.Value = Player.getZalozonaBron().getId().ToString();

                equippedWeapon.Attributes.Append(attribute1);
                xml.DocumentElement.AppendChild(equippedWeapon);
            }

            xmlNodeList = xml.GetElementsByTagName("equippedArmor");
            for (int i = 0; i < xmlNodeList.Count; i++)
                xmlNodeList[i].ParentNode.RemoveChild(xmlNodeList[i]);

            xmlNodeList = xml.GetElementsByTagName("equippedArmor");
            for (int i = 0; i < xmlNodeList.Count; i++)
                xmlNodeList[i].ParentNode.RemoveChild(xmlNodeList[i]);

            if (Player.getZalozonaZbroja() != null)
            {
                XmlElement equippedArmor = xml.CreateElement("equippedArmor");

                XmlAttribute attribute1 = xml.CreateAttribute("id");
                attribute1.Value = Player.getZalozonaZbroja().getId().ToString();

                equippedArmor.Attributes.Append(attribute1);
                xml.DocumentElement.AppendChild(equippedArmor);
            }

            xmlNodeList = xml.GetElementsByTagName("quest");
            for (int i = 0; i < xmlNodeList.Count; i++)
                xmlNodeList[i].ParentNode.RemoveChild(xmlNodeList[i]);

            xmlNodeList = xml.GetElementsByTagName("quest");
            for (int i = 0; i < xmlNodeList.Count; i++)
                xmlNodeList[i].ParentNode.RemoveChild(xmlNodeList[i]);

            foreach (Quest quest in Player.quests)
            {
                XmlElement quests = xml.CreateElement("quest");
                XmlAttribute attribute1 = xml.CreateAttribute("id");
                XmlAttribute attribute2 = xml.CreateAttribute("isActive");
                XmlAttribute attribute3 = xml.CreateAttribute("Status");
                XmlAttribute attribute4 = xml.CreateAttribute("DialogOccured");

                attribute1.Value = quest.getId().ToString();
                attribute2.Value = quest.getIsActive().ToString();
                attribute3.Value = quest.getStatus().ToString();
                attribute4.Value = quest.getDialogOccured().ToString();

                quests.Attributes.Append(attribute1);
                quests.Attributes.Append(attribute2);
                quests.Attributes.Append(attribute3);
                quests.Attributes.Append(attribute4);

                xml.DocumentElement.AppendChild(quests);
            }

            xml.Save(@"../../SaveFile.xml");
        }

        void LoadNewMap(int MoveX, int MoveY)
        {
            sklepikarz.WyczyscEkwipunek();

            MTB = random.Next(15, 20);
            mapX += MoveX;
            mapY += MoveY;
            worldMap.LoadMap(mapX + "" + mapY, _Width / 32, _Height / 18, true, worldEnemies, worldFriendlies);

            System.Random product = new Random(System.DateTime.Now.Millisecond);
            for (int i = 0; i < 3; i++)
            {
                sklepikarz.DodajPrzedmiot(product.Next(1, 7));
            }

            if ((mapX == 0 && mapY == 0) || (mapX == -1 && mapY == 0))
            {
                if (Sound.SongPlayer.currentMedia.name != "cave")
                    Sound.PlaySong(Sound.Song_cave);
            }
            else
            {
                if (Sound.SongPlayer.currentMedia.name != "grasslands")
                {
                    Sound.StopSong();
                    Sound.PlaySong(Sound.Song_grassland);
                }
            }
        }

        void ReloadMap()
        { worldMap.LoadMap(mapX + "" + mapY, _Width / 32, _Height / 18, false, worldEnemies, worldFriendlies); }

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
                {
                    //MessageBox.Show("Enemy: " + P.getNazwa().ToString() + "\nID: " + P.getId().ToString());
                    P.GetCharacterSprite().Draw(Device, _Width / 32, _Height / 18);
                }
            }

            foreach (PrzyjaznyNPC P in worldFriendlies)
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
                            shop = new Shop();
                            shop.Size = new Size(_Width * 2 / 3, _Height * 2 / 3);
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
                                    Sound.PlaySound(Sound.Sound_itempickup);
                                }
                                else
                                {
                                    System.Random goldToGet = new Random();
                                    int gold;
                                    gold = goldToGet.Next(1, 500);

                                    Player.DodajGold(gold);
                                    Sound.PlaySound(Sound.Sound_goldpickup);
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
                    else if (worldMap.GetIsNPC(new Point(Player.GetCharacterSprite().GetLocation().X, Player.GetCharacterSprite().GetLocation().Y)) ||
                    worldMap.GetIsNPC(new Point(Player.GetCharacterSprite().GetLocation().X - _Width / 32, Player.GetCharacterSprite().GetLocation().Y)) ||
                    worldMap.GetIsNPC(new Point(Player.GetCharacterSprite().GetLocation().X + _Width / 32, Player.GetCharacterSprite().GetLocation().Y)) ||
                    worldMap.GetIsNPC(new Point(Player.GetCharacterSprite().GetLocation().X, Player.GetCharacterSprite().GetLocation().Y - _Height / 18)) ||
                    worldMap.GetIsNPC(new Point(Player.GetCharacterSprite().GetLocation().X, Player.GetCharacterSprite().GetLocation().Y + _Height / 18)))
                    {
                        foreach (PrzyjaznyNPC P in worldFriendlies)
                        {
                            if (isFriendlyInRange(P))
                            {
                                if (P != null)
                                {
                                    dialog = new Dialog();
                                    dialog.Size = new Size(_Width, _Height / 3);
                                    dialog.DesktopLocation = new Point(0, _Height - dialog.Height);
                                    dialog.UpdateDialog(Player, P);
                                    dialog.Show();
                                    dialog.Focus();
                                }
                            }
                        }
                    }
                }

                else if (e.KeyCode == Keys.I)
                {
                    equipment = new Equipment();
                    equipment.Size = new Size(_Width * 2 / 3, _Height * 2 / 3);
                    equipment.UpdateEquipment(Player);
                    equipment.Show();
                    equipment.Focus();
                }

                else if (e.KeyCode == Keys.L)
                {
                    questsList = new QuestsList();
                    questsList.Size = new Size(_Width * 2 / 3, _Height * 2 / 3);
                    questsList.UpdateQuestsList(Player);
                    questsList.Show();
                    questsList.Focus();
                }

                else if (e.KeyCode == Keys.Escape)
                {
                    xml.Load(@"../../SaveFile.xml");

                    XmlNodeList xmlNodeList = xml.GetElementsByTagName("item");
                    for (int i = 0; i < xmlNodeList.Count; ++i)
                        xmlNodeList[i].ParentNode.RemoveChild(xmlNodeList[i]);

                    xmlNodeList = xml.GetElementsByTagName("item");
                    for (int i = 0; i < xmlNodeList.Count; ++i)
                        xmlNodeList[i].ParentNode.RemoveChild(xmlNodeList[i]);

                    int g = int.Parse(xml.SelectSingleNode("/postac/save").Attributes["save"].Value);
                    xml.SelectSingleNode("postac/save").Attributes["save"].Value = (++g).ToString();

                    xml.SelectNodes("/postac/postac").Item(0).Attributes["level"].Value = Player.GetLevel().ToString();
                    xml.SelectNodes("/postac/postac").Item(1).Attributes["exp"].Value = Player.GetEXP().ToString();
                    xml.SelectNodes("/postac/postac").Item(2).Attributes["str"].Value = Player.GetStrength().ToString();
                    xml.SelectNodes("/postac/postac").Item(3).Attributes["dex"].Value = Player.GetDexterity().ToString();
                    xml.SelectNodes("/postac/postac").Item(4).Attributes["int"].Value = Player.GetIntelligence().ToString();
                    xml.SelectNodes("/postac/postac").Item(5).Attributes["gold"].Value = Player.GetGold().ToString();
                    xml.SelectNodes("/postac/postac").Item(6).Attributes["maxhp"].Value = Player.GetMaxHP().ToString();
                    xml.SelectNodes("/postac/postac").Item(6).Attributes["hp"].Value = Player.GetHP().ToString();
                    xml.SelectNodes("/postac/postac").Item(7).Attributes["maxmp"].Value = Player.GetMaxMP().ToString();
                    xml.SelectNodes("/postac/postac").Item(7).Attributes["mp"].Value = Player.GetMP().ToString();
                    xml.SelectNodes("/postac/postac").Item(8).Attributes["XTile"].Value = Player.GetXTileIndex().ToString();
                    xml.SelectNodes("/postac/postac").Item(8).Attributes["YTile"].Value = Player.GetYTileIndex().ToString();

                    xml.SelectNodes("postac/world").Item(0).Attributes["mapx"].Value = mapX.ToString();
                    xml.SelectNodes("postac/world").Item(0).Attributes["mapy"].Value = mapY.ToString();

                    foreach (Przedmiot item in Player.Ekwipunek)
                    {
                        XmlElement items = xml.CreateElement("item");
                        XmlAttribute attribute1 = xml.CreateAttribute("id");
                        XmlAttribute attribute2 = xml.CreateAttribute("amount");

                        attribute1.Value = item.getId().ToString();
                        attribute2.Value = item.getIlosc().ToString();

                        items.Attributes.Append(attribute1);
                        items.Attributes.Append(attribute2);

                        xml.DocumentElement.AppendChild(items);
                    }

                    xmlNodeList = xml.GetElementsByTagName("equippedWeapon");
                    for (int i = 0; i < xmlNodeList.Count; i++)
                        xmlNodeList[i].ParentNode.RemoveChild(xmlNodeList[i]);

                    xmlNodeList = xml.GetElementsByTagName("equippedWeapon");
                    for (int i = 0; i < xmlNodeList.Count; i++)
                        xmlNodeList[i].ParentNode.RemoveChild(xmlNodeList[i]);

                    if (Player.getZalozonaBron() != null)
                    {
                        XmlElement equippedWeapon = xml.CreateElement("equippedWeapon");

                        XmlAttribute attribute1 = xml.CreateAttribute("id");
                        attribute1.Value = Player.getZalozonaBron().getId().ToString();

                        equippedWeapon.Attributes.Append(attribute1);
                        xml.DocumentElement.AppendChild(equippedWeapon);
                    }

                    xmlNodeList = xml.GetElementsByTagName("equippedArmor");
                    for (int i = 0; i < xmlNodeList.Count; i++)
                        xmlNodeList[i].ParentNode.RemoveChild(xmlNodeList[i]);

                    xmlNodeList = xml.GetElementsByTagName("equippedArmor");
                    for (int i = 0; i < xmlNodeList.Count; i++)
                        xmlNodeList[i].ParentNode.RemoveChild(xmlNodeList[i]);

                    if (Player.getZalozonaZbroja() != null)
                    {
                        XmlElement equippedArmor = xml.CreateElement("equippedArmor");

                        XmlAttribute attribute1 = xml.CreateAttribute("id");
                        attribute1.Value = Player.getZalozonaZbroja().getId().ToString();

                        equippedArmor.Attributes.Append(attribute1);
                        xml.DocumentElement.AppendChild(equippedArmor);
                    }

                    xmlNodeList = xml.GetElementsByTagName("quest");
                    for (int i = 0; i < xmlNodeList.Count; i++)
                        xmlNodeList[i].ParentNode.RemoveChild(xmlNodeList[i]);

                    xmlNodeList = xml.GetElementsByTagName("quest");
                    for (int i = 0; i < xmlNodeList.Count; i++)
                        xmlNodeList[i].ParentNode.RemoveChild(xmlNodeList[i]);

                    foreach (Quest quest in Player.quests)
                    {
                        XmlElement quests = xml.CreateElement("quest");
                        XmlAttribute attribute1 = xml.CreateAttribute("id");
                        XmlAttribute attribute2 = xml.CreateAttribute("isActive");
                        XmlAttribute attribute3 = xml.CreateAttribute("Status");
                        XmlAttribute attribute4 = xml.CreateAttribute("DialogOccured");

                        attribute1.Value = quest.getId().ToString();
                        attribute2.Value = quest.getIsActive().ToString();
                        attribute3.Value = quest.getStatus().ToString();
                        attribute4.Value = quest.getDialogOccured().ToString();

                        quests.Attributes.Append(attribute1);
                        quests.Attributes.Append(attribute2);
                        quests.Attributes.Append(attribute3);
                        quests.Attributes.Append(attribute4);

                        xml.DocumentElement.AppendChild(quests);
                    }

                    xml.Save(@"../../SaveFile.xml");

                    quit = new Quit();
                    quit.Size = new Size(_Width / 4, _Height / 6);
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
                        Player.SetXTileIndex(Player.GetXTileIndex() - 1);

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
                        Player.SetXTileIndex(Player.GetXTileIndex() + 1);

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
                        Player.SetYTileIndex(Player.GetYTileIndex() - 1);

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
                        Player.SetYTileIndex(Player.GetYTileIndex() + 1);

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
                            Player.SetXTileIndex(Player.GetXTileIndex() - 1);
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
                    combat.StartCombat(Player, NPC.EnemyById(NPC.enemyId_nietoperz));
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
                    //Player.SetXTileIndex(Player.GetXTileIndex() - 1);
                }

                else if (Player.GetMoveDirection() == Postac.MoveDirection.Right)
                {
                    Point p = new Point(Player.GetCharacterSprite().GetLocation().X + (_Width / 32) / 4, Player.GetCharacterSprite().GetLocation().Y);
                    Player.GetCharacterSprite().SetLocation(p);
                    //Player.SetXTileIndex(Player.GetXTileIndex() + 1);
                }

                else if (Player.GetMoveDirection() == Postac.MoveDirection.Up)
                {
                    Point p = new Point(Player.GetCharacterSprite().GetLocation().X, Player.GetCharacterSprite().GetLocation().Y - (_Height / 18) / 3);
                    Player.GetCharacterSprite().SetLocation(p);
                    //Player.SetYTileIndex(Player.GetYTileIndex() - 1);
                }

                else if (Player.GetMoveDirection() == Postac.MoveDirection.Down)
                {
                    Point p = new Point(Player.GetCharacterSprite().GetLocation().X, Player.GetCharacterSprite().GetLocation().Y + (_Height / 18) / 3);
                    Player.GetCharacterSprite().SetLocation(p);
                    //Player.SetYTileIndex(Player.GetYTileIndex() + 1);
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

                    gameEnd(false);
                }

                if ((mapX == 0 && mapY == 0) || (mapX == -1 && mapY == 0))
                {
                    if (Sound.SongPlayer.currentMedia.name != "cave")
                        Sound.PlaySong(Sound.Song_cave);
                }
                else
                {
                    if (Sound.SongPlayer.currentMedia.name != "grasslands")
                    {
                        Sound.StopSong();
                        Sound.PlaySong(Sound.Song_grassland);
                    }
                }
            }
        }

        public void gameEnd(bool state)
        {
            Ending ending = new Ending();
            ending.Size = new Size(_Width, _Height);
            ending.sendForm(GameForm);
            ending.UpdateEnding(state);
            ending.Show();
            ending.Focus();
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

        bool isFriendlyInRange(PrzyjaznyNPC przyjazny)
        {
            if (przyjazny != null)
            {
                if ((Player.GetCharacterSprite().GetLocation().X - (_Width / 32) == przyjazny.GetCharacterSprite().GetLocation().X && Player.GetCharacterSprite().GetLocation().Y + (_Height / 18) == przyjazny.GetCharacterSprite().GetLocation().Y) ||
                  (Player.GetCharacterSprite().GetLocation().X == przyjazny.GetCharacterSprite().GetLocation().X && Player.GetCharacterSprite().GetLocation().Y + (_Height / 18) == przyjazny.GetCharacterSprite().GetLocation().Y) ||
                  (Player.GetCharacterSprite().GetLocation().X + (_Width / 32) == przyjazny.GetCharacterSprite().GetLocation().X && Player.GetCharacterSprite().GetLocation().Y + (_Height / 18) == przyjazny.GetCharacterSprite().GetLocation().Y) ||
                  (Player.GetCharacterSprite().GetLocation().X - (_Width / 32) == przyjazny.GetCharacterSprite().GetLocation().X && Player.GetCharacterSprite().GetLocation().Y == przyjazny.GetCharacterSprite().GetLocation().Y) ||
                  (Player.GetCharacterSprite().GetLocation().X + (_Width / 32) == przyjazny.GetCharacterSprite().GetLocation().X && Player.GetCharacterSprite().GetLocation().Y == przyjazny.GetCharacterSprite().GetLocation().Y) ||
                  (Player.GetCharacterSprite().GetLocation().X - (_Width / 32) == przyjazny.GetCharacterSprite().GetLocation().X && Player.GetCharacterSprite().GetLocation().Y - (_Height / 18) == przyjazny.GetCharacterSprite().GetLocation().Y) ||
                  (Player.GetCharacterSprite().GetLocation().X == przyjazny.GetCharacterSprite().GetLocation().X && Player.GetCharacterSprite().GetLocation().Y - (_Height / 18) == przyjazny.GetCharacterSprite().GetLocation().Y) ||
                  (Player.GetCharacterSprite().GetLocation().X + (_Width / 32) == przyjazny.GetCharacterSprite().GetLocation().X && Player.GetCharacterSprite().GetLocation().Y - (_Height / 18) == przyjazny.GetCharacterSprite().GetLocation().Y))
                {
                    return true;
                }
            }
            return false;
        }

    }
}