﻿using System;
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

        public void LoadMap(string MapName, int TileWidth, int TileHeight, bool NewMap, List<Przeciwnik> EnemiesList, List<PrzyjaznyNPC> FriendlyList) //Wczytywanie świata
        {
            MapTiles.Clear(); //Czyścimy obecny świat
            if (NewMap)
                worldMapItems.Clear();

            EnemiesList.Clear();
            FriendlyList.Clear();

            StreamReader Reader = new StreamReader(@"MapTileData\1_maptiles" + MapName + ".txt"); //Wczytywanie danych z pliku o podanej ścieżce

            int x = 0;
            int y = 0;
            int enemycount = 0;
            int friendlycount = 0;

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
                    else if (line[z].ToString() == "s") // dostęp do sklepu
                    {
                        T.TileImage = new Bitmap(Gra.Properties.Resources.shop, TileWidth * 3, TileHeight * 2);
                        T.isWalkable = false;
                        T.isInteractive = true;
                        T.isMapLoader = false;
                        T.SwitchState = false;
                        T.isShop = true;
                        T.isNPC = false;
                    }
                    else if (line[z].ToString() == "S") // dostęp do sklepu
                    {
                        T.TileImage = new Bitmap(Gra.Properties.Resources.Empty, TileWidth, TileHeight);
                        T.isWalkable = false;
                        T.isInteractive = true;
                        T.isMapLoader = false;
                        T.SwitchState = false;
                        T.isShop = true;
                        T.isNPC = false;
                    }
                    else if (line[z].ToString() == "0") //Zablokowana przestrzeń
                    {
                        T.TileImage = new Bitmap(Gra.Properties.Resources.Empty, TileWidth, TileHeight);
                        T.isWalkable = false;
                        T.isInteractive = false;
                        T.isMapLoader = false;
                        T.SwitchState = false;
                        T.isShop = false;
                        T.isNPC = false;
                    }
                    else if (line[z].ToString() == "1") //Domyślna, możliwa do chodzenia przestrzeć
                    {
                        T.TileImage = new Bitmap(Gra.Properties.Resources.Empty, TileWidth, TileHeight);
                        T.isWalkable = true;
                        T.isInteractive = false;
                        T.isMapLoader = false;
                        T.SwitchState = false;
                        T.isShop = false;
                        T.isNPC = false;
                    }
                    else if (line[z].ToString() == "2") //Przedmiot
                    {
                        T.TileImage = new Bitmap(Gra.Properties.Resources.Empty, TileWidth, TileHeight);
                        T.isWalkable = false;
                        T.isInteractive = true;
                        T.isMapLoader = false;
                        T.SwitchState = false;
                        T.isShop = false;
                        T.isNPC = false;

                        if (line[z + 1].ToString() == "0") // potions
                        {
                            if (line[z + 2].ToString() == "0") 
                            {
                                worldMapItems.Add(new WorldMapItem(new Point(x * TileWidth, y * TileHeight), new Bitmap(Gra.Properties.Resources.WaterTile), Item.ItemsById(1)));
                                item = worldMapItems.Find(c => c.GetLocation() == new Point(x * TileWidth, y * TileHeight));
                                T.TileImage = new Bitmap(Gra.Properties.Resources.healthpotion_1, TileWidth, TileHeight);
                            }
                            else if (line[z + 2].ToString() == "1")
                            {
                                worldMapItems.Add(new WorldMapItem(new Point(x * TileWidth, y * TileHeight), new Bitmap(Gra.Properties.Resources.GrassTile), Item.ItemsById(2)));
                                item = worldMapItems.Find(c => c.GetLocation() == new Point(x * TileWidth, y * TileHeight));
                                T.TileImage = new Bitmap(Gra.Properties.Resources.healthpotion_1, TileWidth, TileHeight);
                            }
                            else if (line[z + 2].ToString() == "2")
                            {
                                worldMapItems.Add(new WorldMapItem(new Point(x * TileWidth, y * TileHeight), new Bitmap(Gra.Properties.Resources.WaterTile), Item.ItemsById(3)));
                                item = worldMapItems.Find(c => c.GetLocation() == new Point(x * TileWidth, y * TileHeight));
                                T.TileImage = new Bitmap(Gra.Properties.Resources.manapotion_1, TileWidth, TileHeight);
                            }
                            else if (line[z + 2].ToString() == "3")
                            {
                                worldMapItems.Add(new WorldMapItem(new Point(x * TileWidth, y * TileHeight), new Bitmap(Gra.Properties.Resources.WaterTile), Item.ItemsById(4)));
                                item = worldMapItems.Find(c => c.GetLocation() == new Point(x * TileWidth, y * TileHeight));
                                T.TileImage = new Bitmap(Gra.Properties.Resources.manapotion_1, TileWidth, TileHeight);
                            }
                        }
                        else if (line[z + 1].ToString() == "1") // weapons
                        {
                            if (line[z + 2].ToString() == "0")
                            {
                                worldMapItems.Add(new WorldMapItem(new Point(x * TileWidth, y * TileHeight), new Bitmap(Gra.Properties.Resources.WaterTile), Item.ItemsById(6)));
                                item = worldMapItems.Find(c => c.GetLocation() == new Point(x * TileWidth, y * TileHeight));
                                T.TileImage = new Bitmap(Gra.Properties.Resources.sword_1, TileWidth, TileHeight);
                            }
                            else if (line[z + 2].ToString() == "1")
                            {
                                worldMapItems.Add(new WorldMapItem(new Point(x * TileWidth, y * TileHeight), new Bitmap(Gra.Properties.Resources.WaterTile), Item.ItemsById(7)));
                                item = worldMapItems.Find(c => c.GetLocation() == new Point(x * TileWidth, y * TileHeight));
                                T.TileImage = new Bitmap(Gra.Properties.Resources.sword_2, TileWidth, TileHeight);
                            }
                        }
                        else if (line[z + 1].ToString() == "2") // armors
                        {
                            if (line[z + 2].ToString() == "0")
                            {
                                worldMapItems.Add(new WorldMapItem(new Point(x * TileWidth, y * TileHeight), new Bitmap(Gra.Properties.Resources.WaterTile), Item.ItemsById(8)));
                                item = worldMapItems.Find(c => c.GetLocation() == new Point(x * TileWidth, y * TileHeight));
                                T.TileImage = new Bitmap(Gra.Properties.Resources.armor_1, TileWidth, TileHeight);
                            }
                        }
                        else if (line[z + 1].ToString() == "3") // gold
                        {
                            worldMapItems.Add(new WorldMapItem(new Point(x * TileWidth, y * TileHeight), new Bitmap(Gra.Properties.Resources.WaterTile), Item.ItemsById(0)));
                            item = worldMapItems.Find(c => c.GetLocation() == new Point(x * TileWidth, y * TileHeight));
                            T.TileImage = new Bitmap(Gra.Properties.Resources.zloto, TileWidth * 2 / 3, TileHeight * 2 / 3);
                        }
                    }
                    else if (line[z].ToString() == "3") //NPC
                    {
                        T.TileImage = new Bitmap(Gra.Properties.Resources.Empty, TileWidth, TileHeight);
                        T.isWalkable = false;
                        T.isInteractive = false;
                        T.isMapLoader = false;
                        T.SwitchState = false;
                        T.isShop = false;
                        T.isNPC = true;

                        if (line[z + 1].ToString() == "0") //Wrogi
                        {
                            if (line[z + 2].ToString() == "0")
                            {
                                EnemiesList.Add(new Przeciwnik(NPC.EnemyById(NPC.enemyId_nietoperz).getNazwa(), NPC.EnemyById(NPC.enemyId_nietoperz).getId(),
                                                               NPC.EnemyById(NPC.enemyId_nietoperz).GetObrazenia(), NPC.EnemyById(NPC.enemyId_nietoperz).getNagrodaExp(),
                                                               NPC.EnemyById(NPC.enemyId_nietoperz).getNagrodaGold(), NPC.EnemyById(NPC.enemyId_nietoperz).GetBaseHP(),
                                                               NPC.EnemyById(NPC.enemyId_nietoperz).GetBaseMP(), new Point(x * TileWidth, y * TileHeight), Gra.Properties.Resources.babybat,
                                                               Gra.Properties.Resources.babybat_battleimage));

                                foreach (Atak atak in NPC.EnemyById(NPC.enemyId_nietoperz).SpecjalneAtaki)
                                {
                                    EnemiesList.ElementAt(enemycount).PoznajAtak(atak.GetId());
                                }

                                foreach (Przedmiot item in NPC.EnemyById(NPC.enemyId_nietoperz).Ekwipunek)
                                {
                                    EnemiesList.ElementAt(enemycount).DodajPrzedmiot(item.getId());
                                }

                                //EnemiesList.Add(NPC.przeciwnik.ElementAt(NPC.enemyId_nietoperz - 1));
                                //EnemiesList.ElementAt(enemycount).SetCharacterSprite(new Point(x * TileWidth, y * TileHeight), NPC.przeciwnik.ElementAt(NPC.enemyId_nietoperz - 1).getObrazekPostaci());
                                enemycount++;

                            }
                            else if (line[z + 2].ToString() == "1")
                            {
                                EnemiesList.Add(new Przeciwnik(NPC.EnemyById(NPC.enemyId_ogromnyszczur).getNazwa(), NPC.EnemyById(NPC.enemyId_ogromnyszczur).getId(),
                                                               NPC.EnemyById(NPC.enemyId_ogromnyszczur).GetObrazenia(), NPC.EnemyById(NPC.enemyId_ogromnyszczur).getNagrodaExp(),
                                                               NPC.EnemyById(NPC.enemyId_ogromnyszczur).getNagrodaGold(), NPC.EnemyById(NPC.enemyId_ogromnyszczur).GetBaseHP(),
                                                               NPC.EnemyById(NPC.enemyId_ogromnyszczur).GetBaseMP(), new Point(x * TileWidth, y * TileHeight), Gra.Properties.Resources.Empty,
                                                               Gra.Properties.Resources.Empty));

                                foreach (Atak atak in NPC.EnemyById(NPC.enemyId_ogromnyszczur).SpecjalneAtaki)
                                {
                                    EnemiesList.ElementAt(enemycount).PoznajAtak(atak.GetId());
                                }

                                foreach (Przedmiot item in NPC.EnemyById(NPC.enemyId_ogromnyszczur).Ekwipunek)
                                {
                                    EnemiesList.ElementAt(enemycount).DodajPrzedmiot(item.getId());
                                }

                                //EnemiesList.Add(NPC.przeciwnik.ElementAt(NPC.enemyId_ogromnyszczur - 1));
                                //EnemiesList.ElementAt(enemycount).SetCharacterSprite(new Point(x * TileWidth, y * TileHeight), NPC.przeciwnik.ElementAt(NPC.enemyId_ogromnyszczur - 1).getObrazekPostaci());
                                enemycount++;
                            }
                            else if (line[z + 2].ToString() == "2")
                            {
                                EnemiesList.Add(new Przeciwnik(NPC.EnemyById(NPC.enemyId_wilk).getNazwa(), NPC.EnemyById(NPC.enemyId_wilk).getId(),
                                                               NPC.EnemyById(NPC.enemyId_wilk).GetObrazenia(), NPC.EnemyById(NPC.enemyId_wilk).getNagrodaExp(),
                                                               NPC.EnemyById(NPC.enemyId_wilk).getNagrodaGold(), NPC.EnemyById(NPC.enemyId_wilk).GetBaseHP(),
                                                               NPC.EnemyById(NPC.enemyId_wilk).GetBaseMP(), new Point(x * TileWidth, y * TileHeight), Gra.Properties.Resources.Wolf,
                                                               Gra.Properties.Resources.Wolf_battleimage));

                                foreach (Atak atak in NPC.EnemyById(NPC.enemyId_wilk).SpecjalneAtaki)
                                {
                                    EnemiesList.ElementAt(enemycount).PoznajAtak(atak.GetId());
                                }

                                foreach (Przedmiot item in NPC.EnemyById(NPC.enemyId_wilk).Ekwipunek)
                                {
                                    EnemiesList.ElementAt(enemycount).DodajPrzedmiot(item.getId());
                                }

                                //EnemiesList.Add(NPC.przeciwnik.ElementAt(NPC.enemyId_wilk - 1));
                                //EnemiesList.ElementAt(enemycount).SetCharacterSprite(new Point(x * TileWidth, y * TileHeight), NPC.przeciwnik.ElementAt(NPC.enemyId_wilk - 1).getObrazekPostaci());
                                enemycount++;
                            }
                            else if (line[z + 2].ToString() == "3")
                            {
                                EnemiesList.Add(new Przeciwnik(NPC.EnemyById(NPC.enemyId_szkielet).getNazwa(), NPC.EnemyById(NPC.enemyId_szkielet).getId(),
                                                               NPC.EnemyById(NPC.enemyId_szkielet).GetObrazenia(), NPC.EnemyById(NPC.enemyId_szkielet).getNagrodaExp(),
                                                               NPC.EnemyById(NPC.enemyId_szkielet).getNagrodaGold(), NPC.EnemyById(NPC.enemyId_szkielet).GetBaseHP(),
                                                               NPC.EnemyById(NPC.enemyId_szkielet).GetBaseMP(), new Point(x * TileWidth, y * TileHeight), Gra.Properties.Resources.Empty,
                                                               Gra.Properties.Resources.Empty));

                                foreach (Atak atak in NPC.EnemyById(NPC.enemyId_szkielet).SpecjalneAtaki)
                                {
                                    EnemiesList.ElementAt(enemycount).PoznajAtak(atak.GetId());
                                }

                                foreach (Przedmiot item in NPC.EnemyById(NPC.enemyId_szkielet).Ekwipunek)
                                {
                                    EnemiesList.ElementAt(enemycount).DodajPrzedmiot(item.getId());
                                }

                                //EnemiesList.Add(NPC.przeciwnik.ElementAt(NPC.enemyId_szkielet - 1));
                                //EnemiesList.ElementAt(enemycount).SetCharacterSprite(new Point(x * TileWidth, y * TileHeight), NPC.przeciwnik.ElementAt(NPC.enemyId_szkielet - 1).getObrazekPostaci());
                                enemycount++;
                            }
                            else if (line[z + 2].ToString() == "4")
                            {
                                EnemiesList.Add(new Przeciwnik(NPC.EnemyById(NPC.enemyId_szkielet_czarownik).getNazwa(), NPC.EnemyById(NPC.enemyId_szkielet_czarownik).getId(),
                                                               NPC.EnemyById(NPC.enemyId_szkielet_czarownik).GetObrazenia(), NPC.EnemyById(NPC.enemyId_szkielet_czarownik).getNagrodaExp(),
                                                               NPC.EnemyById(NPC.enemyId_szkielet_czarownik).getNagrodaGold(), NPC.EnemyById(NPC.enemyId_szkielet_czarownik).GetBaseHP(),
                                                               NPC.EnemyById(NPC.enemyId_szkielet_czarownik).GetBaseMP(), new Point(x * TileWidth, y * TileHeight), Gra.Properties.Resources.Empty,
                                                               Gra.Properties.Resources.Empty));

                                foreach (Atak atak in NPC.EnemyById(NPC.enemyId_szkielet_czarownik).SpecjalneAtaki)
                                {
                                    EnemiesList.ElementAt(enemycount).PoznajAtak(atak.GetId());
                                }

                                foreach (Przedmiot item in NPC.EnemyById(NPC.enemyId_szkielet_czarownik).Ekwipunek)
                                {
                                    EnemiesList.ElementAt(enemycount).DodajPrzedmiot(item.getId());
                                }

                                //EnemiesList.Add(NPC.przeciwnik.ElementAt(NPC.enemyId_szkielet_czarownik - 1));
                                //EnemiesList.ElementAt(enemycount).SetCharacterSprite(new Point(x * TileWidth, y * TileHeight), NPC.przeciwnik.ElementAt(NPC.enemyId_szkielet_czarownik - 1).getObrazekPostaci());
                                enemycount++;
                            }
                            else if (line[z + 2].ToString() == "5")
                            {
                                EnemiesList.Add(new Przeciwnik(NPC.EnemyById(NPC.enemyId_minotaur).getNazwa(), NPC.EnemyById(NPC.enemyId_minotaur).getId(),
                                                               NPC.EnemyById(NPC.enemyId_minotaur).GetObrazenia(), NPC.EnemyById(NPC.enemyId_minotaur).getNagrodaExp(),
                                                               NPC.EnemyById(NPC.enemyId_minotaur).getNagrodaGold(), NPC.EnemyById(NPC.enemyId_minotaur).GetBaseHP(),
                                                               NPC.EnemyById(NPC.enemyId_minotaur).GetBaseMP(), new Point(x * TileWidth, y * TileHeight), Gra.Properties.Resources.Minotaur,
                                                               Gra.Properties.Resources.Minotaur_battleimage));

                                foreach (Atak atak in NPC.EnemyById(NPC.enemyId_minotaur).SpecjalneAtaki)
                                {
                                    EnemiesList.ElementAt(enemycount).PoznajAtak(atak.GetId());
                                }
                                
                                foreach (Przedmiot item in NPC.EnemyById(NPC.enemyId_minotaur).Ekwipunek)
                                {
                                    EnemiesList.ElementAt(enemycount).DodajPrzedmiot(item.getId());
                                }

                                //EnemiesList.Add(NPC.przeciwnik.ElementAt(NPC.enemyId_minotaur - 1));
                                //EnemiesList.ElementAt(enemycount).SetCharacterSprite(new Point(x * TileWidth, y * TileHeight), NPC.przeciwnik.ElementAt(NPC.enemyId_minotaur - 1).getObrazekPostaci());
                                enemycount++;
                            }
                        }
                        else if (line[z + 1].ToString() == "1") //Przyjazny
                        {
                            if (line[z + 2].ToString() == "0")
                            {
                                FriendlyList.Add(NPC.przyjazny.ElementAt(NPC.friendlyId_Vincent - 1));
                                FriendlyList.ElementAt(friendlycount).SetCharacterSprite(new Point(x * TileWidth, y * TileHeight), NPC.przyjazny.ElementAt(NPC.friendlyId_Vincent - 1).getObrazekPostaci());
                                friendlycount++;
                            }
                            else if (line[z + 2].ToString() == "1")
                            {
                                FriendlyList.Add(NPC.przyjazny.ElementAt(NPC.friendlyId_King - 1));
                                FriendlyList.ElementAt(friendlycount).SetCharacterSprite(new Point(x * TileWidth, y * TileHeight), NPC.przyjazny.ElementAt(NPC.friendlyId_King - 1).getObrazekPostaci());
                                friendlycount++;
                            }
                            else if (line[z + 2].ToString() == "2")
                            {
                                FriendlyList.Add(NPC.przyjazny.ElementAt(NPC.friendlyId_Peasant - 1));
                                FriendlyList.ElementAt(friendlycount).SetCharacterSprite(new Point(x * TileWidth, y * TileHeight), NPC.przyjazny.ElementAt(NPC.friendlyId_Peasant - 1).getObrazekPostaci());
                                friendlycount++;
                            }
                            else if (line[z + 2].ToString() == "3")
                            {
                                FriendlyList.Add(NPC.przyjazny.ElementAt(NPC.friendlyId_Sorceress - 1));
                                FriendlyList.ElementAt(friendlycount).SetCharacterSprite(new Point(x * TileWidth, y * TileHeight), NPC.przyjazny.ElementAt(NPC.friendlyId_Sorceress - 1).getObrazekPostaci());
                                friendlycount++;
                            }
                            else if (line[z + 2].ToString() == "4")
                            {
                                PrzyjaznyNPC friendly = new PrzyjaznyNPC(999, "Rycerz", Gra.Properties.Resources.npc_knight_2, Gra.Properties.Resources.Empty, "Za króla!");
                                FriendlyList.Add(friendly);
                                FriendlyList.ElementAt(friendlycount).SetCharacterSprite(new Point(x * TileWidth, y * TileHeight), friendly.getObrazekPostaci());
                                friendlycount++;
                            }
                            else if (line[z + 2].ToString() == "5")
                            {
                                PrzyjaznyNPC friendly = new PrzyjaznyNPC(999, "Rycerz", Gra.Properties.Resources.npc_knight_3, Gra.Properties.Resources.Empty, "Za króla!");
                                FriendlyList.Add(friendly);
                                FriendlyList.ElementAt(friendlycount).SetCharacterSprite(new Point(x * TileWidth, y * TileHeight), friendly.getObrazekPostaci());
                                friendlycount++;
                            }
                            else if (line[z + 2].ToString() == "6")
                            {
                                PrzyjaznyNPC friendly = new PrzyjaznyNPC(999, "Rycerz", Gra.Properties.Resources.npc_knight_4, Gra.Properties.Resources.Empty, "Za cezara! Znaczy... Uhm... Za króla!");
                                FriendlyList.Add(friendly);
                                FriendlyList.ElementAt(friendlycount).SetCharacterSprite(new Point(x * TileWidth, y * TileHeight), friendly.getObrazekPostaci());
                                friendlycount++;
                            }
                            else if (line[z + 2].ToString() == "7")
                            {
                                PrzyjaznyNPC friendly = new PrzyjaznyNPC(999, "Rycerz", Gra.Properties.Resources.npc_knight_5, Gra.Properties.Resources.Empty, "Za króla!");
                                FriendlyList.Add(friendly);
                                FriendlyList.ElementAt(friendlycount).SetCharacterSprite(new Point(x * TileWidth, y * TileHeight), friendly.getObrazekPostaci());
                                friendlycount++;
                            }
                            else if (line[z + 2].ToString() == "8")
                            {
                                PrzyjaznyNPC friendly = new PrzyjaznyNPC(999, "Chłop", Gra.Properties.Resources.npc_peasant_2, Gra.Properties.Resources.Empty, "Chłop potęgą jest i basta.");
                                FriendlyList.Add(friendly);
                                FriendlyList.ElementAt(friendlycount).SetCharacterSprite(new Point(x * TileWidth, y * TileHeight), friendly.getObrazekPostaci());
                                friendlycount++;
                            }
                            else if (line[z + 2].ToString() == "9")
                            {
                                PrzyjaznyNPC friendly = new PrzyjaznyNPC(999, "Chłop", Gra.Properties.Resources.npc_peasant_3, Gra.Properties.Resources.Empty, "Cóż tam, panie w polityce? Magowi trzymają się mocno!?");
                                FriendlyList.Add(friendly);
                                FriendlyList.ElementAt(friendlycount).SetCharacterSprite(new Point(x * TileWidth, y * TileHeight), friendly.getObrazekPostaci());
                                friendlycount++;
                            }
                            else if (line[z + 2].ToString() == "a")
                            {
                                PrzyjaznyNPC friendly = new PrzyjaznyNPC(999, "Chłop", Gra.Properties.Resources.npc_peasant_4, Gra.Properties.Resources.Empty, "Kiedyś to było...");
                                FriendlyList.Add(friendly);
                                FriendlyList.ElementAt(friendlycount).SetCharacterSprite(new Point(x * TileWidth, y * TileHeight), friendly.getObrazekPostaci());
                                friendlycount++;
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

        public bool GetIsNPC(Point Loc)
        {
            foreach (Tile T in MapTiles)
                if (T.TileLoc == Loc)
                    if (T.isNPC)
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

        public WorldMapSprite() {}

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