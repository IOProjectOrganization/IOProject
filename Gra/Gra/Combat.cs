using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gra
{
    public partial class Combat : Form
    {
        private bool playerTurn = true;

        private bool playerWin = false;
        private bool inCombat = false;

        private int PlayerDmgMultiplier = 1;
        private int PlayerDefMultiplier = 1;
        private int EnemyDmgMultiplier = 1;
        private int EnemyDefMultiplier = 1;

        Bohater Player = null;
        Przeciwnik Enemy = null;

        Random random = new Random();

        Timer timer1 = new Timer();
        Timer timer2 = new Timer();
        bool volume1 = false;
        bool volume2 = false;

        public static WMPLib.WindowsMediaPlayer CombatSoundPlayer = new WMPLib.WindowsMediaPlayer();

        public Combat()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            tableLayoutPanel2.Parent = BackgroundPB;

            button1.Enabled = false;
            button1.Visible = false;

            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            timer1.Interval = 50;

            timer2.Enabled = true;
            timer2.Tick += timer2_Tick;
            timer2.Interval = 50;

            timer1.Stop();
            timer2.Stop();

            PlayerHPCurrentLabel.Scale(2);
            PlayerHPSlashLabel.Scale(2);
            PlayerHPMaxLabel.Scale(2);
            PlayerHPText.Scale(2);
            PlayerMPCurrentLabel.Scale(2);
            PlayerMPSlashLabel.Scale(2);
            PlayerMPMaxLabel.Scale(2);
            PlayerMPText.Scale(2);

            EnemyHPCurrentLabel.Scale(2);
            EnemyHPSlashLabel.Scale(2);
            EnemyHPMaxLabel.Scale(2);
            EnemyHPText.Scale(2);
            EnemyMPCurrentLabel.Scale(2);
            EnemyMPSlashLabel.Scale(2);
            EnemyMPMaxLabel.Scale(2);
            EnemyMPText.Scale(2);

            AttackBtn.Scale(2);
            SpecialSkillBtn.Scale(2);
            BlockBtn.Scale(2);
            ItemsBtn.Scale(2);
            button1.Scale(2);

            Delay.Enabled = true;
            Delay.Stop();

            if (Sound.SongPlayer.settings.volume > 0)
                timer1.Start();

            CombatSoundPlayer.settings.volume = 0;
            CombatPlay(Sound.Song_battle);

            timer2.Start();
        }

        void timer1_Tick(object sender, System.EventArgs e)
        {
            if (Sound.SongPlayer.settings.volume == 0)
            {
                volume1 = false;
                Sound.SongUnpause();
            }
            else if (Sound.SongPlayer.settings.volume == 50)
                volume1 = true;

            if (volume1 == true)
                Sound.SongPlayer.settings.volume -= 1;
            else if (volume1 == false)
                Sound.SongPlayer.settings.volume += 1;

            if (Sound.SongPlayer.settings.volume == 0)
            {
                Sound.SongPause();
                timer1.Stop();
            }
            else if (Sound.SongPlayer.settings.volume == 50)
            {
                timer1.Stop();
            }
        }

        void timer2_Tick(object sender, System.EventArgs e)
        {
            if (CombatSoundPlayer.settings.volume == 0)
                volume2 = false;
            else if (CombatSoundPlayer.settings.volume == 50)
                volume2 = true;

            if (volume2 == true)
                CombatSoundPlayer.settings.volume -= 1;
            else if (volume2 == false)
                CombatSoundPlayer.settings.volume += 1;

            if (CombatSoundPlayer.settings.volume == 0)
            {
                CombatStop();
                timer2.Stop();
            }
            else if (CombatSoundPlayer.settings.volume == 50)
                timer2.Stop();
        }

        private static void CombatPlay(string _song)
        {
            if (CombatSoundPlayer.URL != _song)
            {
                CombatSoundPlayer.URL = _song;
                CombatSoundPlayer.settings.setMode("loop", true);  //zapetlanie muzyki
                CombatSoundPlayer.controls.play();
            }
        }
        private static void CombatStop()  // jesli chcemy na sile zatrzymac muzyke
        {
            CombatSoundPlayer.controls.stop();
        }

        public bool GetIsInCombat()
        {
            return inCombat;
        }

        public bool GetIsPlayerWinner()
        {
            return playerWin;
        }

        public void StartCombat(Bohater player, Przeciwnik enemy, int mapX, int mapY)
        {
            if (Player == null)
                Player = player;

            if (Enemy == null)
                Enemy = enemy;

            inCombat = true;
            playerTurn = true;

            PlayerPB.Image = player.getBattleImage();
            EnemyPB.Image = enemy.getBattleImage();

            Image img;

            if (mapX < 0 && mapY >= 0)
            {
                mapX *= -1;
                img = new Bitmap((Image)Gra.Properties.Resources.ResourceManager.GetObject("world_" + mapX + "" + mapY), Width, Height);
            }
            else if (mapX >= 0 && mapY < 0)
            {
                mapY *= -1;
                img = new Bitmap((Image)Gra.Properties.Resources.ResourceManager.GetObject("world" + mapX + "_" + mapY), Width, Height);
            }
            else if (mapX < 0 && mapY < 0)
            {
                mapX *= -1;
                mapY *= -1;
                img = new Bitmap((Image)Gra.Properties.Resources.ResourceManager.GetObject("world_" + mapX + "_" + mapY), Width, Height);
            }
            else
            {
                img = new Bitmap((Image)Gra.Properties.Resources.ResourceManager.GetObject("world" + mapX + "" + mapY), Width, Height);
            }

            BackgroundPB.SizeMode = PictureBoxSizeMode.Zoom;
            BackgroundPB.Image = img;

            UpdateStats();
        }

        private void UpdateStats()
        {
            if (Player != null && Enemy != null)
            {
                PlayerHPBP.Maximum = Player.GetMaxHP();
                PlayerHPBP.Value = Player.GetHP();
                PlayerHPCurrentLabel.Text = Player.GetHP().ToString();
                PlayerHPSlashLabel.Text = "/";
                PlayerHPMaxLabel.Text = Player.GetMaxHP().ToString();
                PlayerHPText.Text = "Życie";

                PlayerMPBP.Maximum = Player.GetMaxMP();
                PlayerMPBP.Value = Player.GetMP();
                PlayerMPCurrentLabel.Text = Player.GetMP().ToString();
                PlayerMPSlashLabel.Text = "/";
                PlayerMPMaxLabel.Text = Player.GetMaxMP().ToString();
                PlayerMPText.Text = "Mana";

                EnemyHPBP.Maximum = Enemy.GetMaxHP();
                EnemyHPBP.Value = Enemy.GetHP();
                EnemyHPCurrentLabel.Text = Enemy.GetHP().ToString();
                EnemyHPSlashLabel.Text = "/";
                EnemyHPMaxLabel.Text = Enemy.GetMaxHP().ToString();
                EnemyHPText.Text = "Życie";

                EnemyMPBP.Maximum = Enemy.GetMaxMP();
                EnemyMPBP.Value = Enemy.GetMP();
                EnemyMPCurrentLabel.Text = Enemy.GetMP().ToString();
                EnemyMPSlashLabel.Text = "/";
                EnemyMPMaxLabel.Text = Enemy.GetMaxMP().ToString();
                EnemyMPText.Text = "Mana";
            }
        }

        private void scaleFont(Button Btn)
        {
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(fakeImage);


            SizeF extent = graphics.MeasureString(Btn.Text, Btn.Font);


            float hRatio = Btn.Height / extent.Height / 2;
            float wRatio = Btn.Width / extent.Width / 2;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = Btn.Font.Size * ratio;

            Btn.Font = new Font(Btn.Font.FontFamily, newSize, Btn.Font.Style);
        }

        private void scaleFont(Label lab)
        {
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(fakeImage);


            SizeF extent = graphics.MeasureString(lab.Text, lab.Font);


            float hRatio = lab.Height / extent.Height;
            float wRatio = lab.Width / extent.Width;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = lab.Font.Size * ratio;
            
            lab.Font = new Font(lab.Font.FontFamily, newSize, lab.Font.Style);
        }

        private void Label_SizeChanged(object sender, EventArgs e)
        {
            scaleFont(PlayerHPCurrentLabel);
            scaleFont(PlayerHPSlashLabel);
            scaleFont(PlayerHPMaxLabel);
            scaleFont(PlayerHPText);
            scaleFont(PlayerMPCurrentLabel);
            scaleFont(PlayerMPSlashLabel);
            scaleFont(PlayerMPMaxLabel);
            scaleFont(PlayerMPText);

            scaleFont(EnemyHPCurrentLabel);
            scaleFont(EnemyHPSlashLabel);
            scaleFont(EnemyHPMaxLabel);
            scaleFont(EnemyHPText);
            scaleFont(EnemyMPCurrentLabel);
            scaleFont(EnemyMPSlashLabel);
            scaleFont(EnemyMPMaxLabel);
            scaleFont(EnemyMPText);
        }

        private void Button_SizeChanged(object sender, EventArgs e)
        {
            scaleFont(AttackBtn);
            scaleFont(SpecialSkillBtn);
            scaleFont(BlockBtn);
            scaleFont(ItemsBtn);
            scaleFont(button1);
        }

        private void AttackBtn_Click(object sender, EventArgs e)
        {
            if (playerTurn)
            {
                Enemy.SetHP(Enemy.GetHP() - (Player.GetObrazenia() * PlayerDmgMultiplier) / EnemyDefMultiplier);
                Sound.PlaySound(Sound.Sound_playerbasicattack);

                if (Enemy.GetHP() <= 0)
                {
                    Enemy.SetHP(0);
                    Enemy.SetMP(0);
                    Enemy.setIsAlive(false);

                    playerWin = true;
                    inCombat = false;

                    Player.DodajEXP(Enemy.getNagrodaExp());
                    Player.DodajGold(Enemy.getNagrodaGold());

                    foreach (Quest quest in Player.quests)
                    {
                        if (quest.getStatus() == QuestStatus.Active)
                        {
                            if (quest.GetType() == typeof(QuestKillEnemy))
                            {
                                QuestKillEnemy _quest = quest as QuestKillEnemy;
                                if (_quest.GetQuestEnemyID() == Enemy.getId())
                                {
                                    _quest.IncrementCounter();
                                    _quest.CheckCompletion();
                                }
                            }
                        }
                    }

                    Enemy = null;

                    if (CombatSoundPlayer.settings.volume > 0)
                        timer2.Start();

                    if (Sound.SongPlayer.settings.volume < 100)
                        timer1.Start();

                    this.Close();
                }
            }

            PlayerDmgMultiplier = 1;
            PlayerDefMultiplier = 1;
            EnemyDmgMultiplier = 1;
            EnemyDefMultiplier = 1;

            playerTurn = false;
            AttackBtn.Enabled = false;
            SpecialSkillBtn.Enabled = false;
            BlockBtn.Enabled = false;
            ItemsBtn.Enabled = false;

            UpdateStats();
            Delay.Start();
        }

        private void SpecialSkillBtn_Click(object sender, EventArgs e)
        {
            /*  if(playerTurn)
              {
                  Atak wybranyAtak = new Atak();

                  //    <     --------     >

                  // okno z listą ataków z Player.SpecjalneAtaki pozwalajace wybrac atak ktory bedzie przypisany do "wybranyAtak"

                  //    <     --------     >

                  if(wybranyAtak.GetTyp()==TypAtaku.Obrazenia)
                  {
                      Enemy.SetHP(Enemy.GetHP() - (wybranyAtak.GetValue() * PlayerDmgMultiplier) / EnemyDefMultiplier);
                  }
                  else if(wybranyAtak.GetTyp()==TypAtaku.Leczenie)
                  {
                      Player.SetHP(Player.GetHP() + wybranyAtak.GetValue());
                      if (Player.GetHP() > Player.GetMaxHP())
                          Player.SetHP(Player.GetMaxHP());
                  }
                  else if(wybranyAtak.GetTyp()==TypAtaku.Trucizna)
                  {
                     Enemy.ApplyDOTEffect(wybranyAtak.GetDOT());
                  }
                  if(wybranyAtak.IsStun()==true)
                  {
                      Enemy.ApplyStun();
                  }

                  Player.SetMP(Player.GetMP() - wybranyAtak.GetManaCost());
              }  */

            PlayerDmgMultiplier = 1;
            PlayerDefMultiplier = 1;
            EnemyDmgMultiplier = 1;
            EnemyDefMultiplier = 1;

            playerTurn = false;
            AttackBtn.Enabled = false;
            SpecialSkillBtn.Enabled = false;
            BlockBtn.Enabled = false;
            ItemsBtn.Enabled = false;

            UpdateStats();
            Delay.Start();
        }

        private void BlockBtn_Click(object sender, EventArgs e)
        {
            PlayerDmgMultiplier = 1;
            PlayerDefMultiplier = 2;
            EnemyDmgMultiplier = 1;
            EnemyDefMultiplier = 1;

            playerTurn = false;
            AttackBtn.Enabled = false;
            SpecialSkillBtn.Enabled = false;
            BlockBtn.Enabled = false;
            ItemsBtn.Enabled = false;

            UpdateStats();
            Delay.Start();
        }

        private void ItemsBtn_Click(object sender, EventArgs e)
        {




            PlayerDmgMultiplier = 1;
            PlayerDefMultiplier = 1;
            EnemyDmgMultiplier = 1;
            EnemyDefMultiplier = 1;

            playerTurn = false;
            AttackBtn.Enabled = false;
            SpecialSkillBtn.Enabled = false;
            BlockBtn.Enabled = false;
            ItemsBtn.Enabled = false;

            UpdateStats();
            Delay.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void EnemyAttack()
        {
            Player.SetHP(Player.GetHP() - (Enemy.GetObrazenia() * EnemyDmgMultiplier) / PlayerDefMultiplier);
            Sound.PlaySound(Sound.Sound_enemybasicattack);

            if (Player.GetHP() <= 0)
            {
                Player.SetHP(0);
                Player.SetMP(0);

                playerWin = false;
                inCombat = false;

                if (CombatSoundPlayer.settings.volume > 0)
                    timer2.Start();

                if (Sound.SongPlayer.settings.volume < 100)
                    timer1.Start();

                this.Close();
            }

            PlayerDmgMultiplier = 1;
            PlayerDefMultiplier = 1;
            EnemyDmgMultiplier = 1;
            EnemyDefMultiplier = 1;

            playerTurn = true;
            AttackBtn.Enabled = true;
            SpecialSkillBtn.Enabled = true;
            BlockBtn.Enabled = true;
            ItemsBtn.Enabled = true;

            UpdateStats();
        }

        private void EnemySpecialSkill()
        {
            int randomValue = random.Next(Enemy.SpecjalneAtaki.Count);
           
            if (Enemy.GetMP() >= Enemy.SpecjalneAtaki.ElementAt(randomValue).GetManaCost())
            {
                if (Enemy.SpecjalneAtaki.ElementAt(randomValue).GetType() == typeof(AtkLeczenie))
                {
                    Enemy.SetHP(Enemy.GetHP() + Enemy.SpecjalneAtaki.ElementAt(randomValue).GetValue());
                    Sound.PlaySound(Sound.Sound_enemyhealingspell);

                    if (Enemy.GetHP() > Enemy.GetMaxHP())
                        Enemy.SetHP(Enemy.GetMaxHP());
                }
                else
                {
                    Player.SetHP(Player.GetHP() - (Enemy.SpecjalneAtaki.ElementAt(randomValue).GetValue() * EnemyDmgMultiplier) / PlayerDefMultiplier);
                    Sound.PlaySound(Sound.Sound_enemyattackspell);
                }
                Enemy.SetMP(Enemy.GetMP() - Enemy.SpecjalneAtaki.ElementAt(randomValue).GetManaCost());

                if (Enemy.GetMP() <= 0)
                    Enemy.SetMP(0);

                if (Player.GetHP() <= 0)
                {
                    Player.SetHP(0);
                    Player.SetMP(0);

                    playerWin = false;
                    inCombat = false;

                    if (CombatSoundPlayer.settings.volume > 0)
                        timer2.Start();

                    if (Sound.SongPlayer.settings.volume < 100)
                        timer1.Start();

                    this.Close();
                }

                PlayerDmgMultiplier = 1;
                PlayerDefMultiplier = 1;
                EnemyDmgMultiplier = 1;
                EnemyDefMultiplier = 1;

                playerTurn = true;
                AttackBtn.Enabled = true;
                SpecialSkillBtn.Enabled = true;
                BlockBtn.Enabled = true;
                ItemsBtn.Enabled = true;

                UpdateStats();
            }
        }

        private void EnemyBlock()
        {
            PlayerDmgMultiplier = 1;
            PlayerDefMultiplier = 1;
            EnemyDmgMultiplier = 1;
            EnemyDefMultiplier = 2;

            playerTurn = true;
            AttackBtn.Enabled = true;
            SpecialSkillBtn.Enabled = true;
            BlockBtn.Enabled = true;
            ItemsBtn.Enabled = true;

            UpdateStats();
        }

        private void EnemyItems()
        {




            PlayerDmgMultiplier = 1;
            PlayerDefMultiplier = 1;
            EnemyDmgMultiplier = 1;
            EnemyDefMultiplier = 1;

            playerTurn = true;
            AttackBtn.Enabled = true;
            SpecialSkillBtn.Enabled = true;
            BlockBtn.Enabled = true;
            ItemsBtn.Enabled = true;

            UpdateStats();
        }

        private void Delay_Tick(object sender, EventArgs e)
        {
            if (Enemy != null)
            {
                if (!playerTurn)
                {
                    int randomValue;

                    if (Enemy.GetMP() > 0 && Enemy.SpecjalneAtaki.Count > 0)
                    {
                        randomValue = random.Next(1000);

                        if (randomValue < 500)
                            EnemyAttack();

                        else if (randomValue < 800)
                            EnemySpecialSkill();

                        else
                            EnemyBlock();

                        Delay.Stop();
                    }
                    else
                    {
                        randomValue = random.Next(1000);
                        
                        if (randomValue < 800)
                            EnemyAttack();

                        else
                            EnemyBlock();

                        Delay.Stop();
                    }
                }
            }
        }
    }
}
