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

        public Combat()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            tableLayoutPanel2.Parent = BackgroundPB;

            PlayerHPCurrentLabel.Scale(2);
            PlayerHPSlashLabel.Scale(2);
            PlayerHPMaxLabel.Scale(2);
            PlayerMPCurrentLabel.Scale(2);
            PlayerMPSlashLabel.Scale(2);
            PlayerMPMaxLabel.Scale(2);

            EnemyHPCurrentLabel.Scale(2);
            EnemyHPSlashLabel.Scale(2);
            EnemyHPMaxLabel.Scale(2);
            EnemyMPCurrentLabel.Scale(2);
            EnemyMPSlashLabel.Scale(2);
            EnemyMPMaxLabel.Scale(2);

            AttackBtn.Scale(2);
            SpecialSkillBtn.Scale(2);
            BlockBtn.Scale(2);
            ItemsBtn.Scale(2);
            button1.Scale(2);

            Delay.Enabled = true;
            Delay.Stop();
        }

        public bool GetIsInCombat()
        {
            return inCombat;
        }

        public bool GetIsPlayerWinner()
        {
            return playerWin;
        }

        public void StartCombat(Bohater player, Przeciwnik enemy)
        {
            if (Player == null)
                Player = player;

            if (Enemy == null)
                Enemy = enemy;

            inCombat = true;
            playerTurn = true;

            PlayerPB.Image = Player.getBattleImage();
            EnemyPB.Image = Enemy.getBattleImage();

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

                PlayerMPBP.Maximum = Player.GetMaxMP();
                PlayerMPBP.Value = Player.GetMP();
                PlayerMPCurrentLabel.Text = Player.GetMP().ToString();
                PlayerMPSlashLabel.Text = "/";
                PlayerMPMaxLabel.Text = Player.GetMaxMP().ToString();

                EnemyHPBP.Maximum = Enemy.GetMaxHP();
                EnemyHPBP.Value = Enemy.GetHP();
                EnemyHPCurrentLabel.Text = Enemy.GetHP().ToString();
                EnemyHPSlashLabel.Text = "/";
                EnemyHPMaxLabel.Text = Enemy.GetMaxHP().ToString();

                EnemyMPBP.Maximum = Enemy.GetMaxMP();
                EnemyMPBP.Value = Enemy.GetMP();
                EnemyMPCurrentLabel.Text = Enemy.GetMP().ToString();
                EnemyMPSlashLabel.Text = "/";
                EnemyMPMaxLabel.Text = Enemy.GetMaxMP().ToString();
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
            scaleFont(PlayerMPCurrentLabel);
            scaleFont(PlayerMPSlashLabel);
            scaleFont(PlayerMPMaxLabel);

            scaleFont(EnemyHPCurrentLabel);
            scaleFont(EnemyHPSlashLabel);
            scaleFont(EnemyHPMaxLabel);
            scaleFont(EnemyMPCurrentLabel);
            scaleFont(EnemyMPSlashLabel);
            scaleFont(EnemyMPMaxLabel);
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

                if (Enemy.GetHP() <= 0)
                {
                    Enemy.SetHP(0);
                    Enemy.SetMP(0);
                    Enemy.setIsAlive(false);

                    playerWin = true;
                    inCombat = false;

                    Player.DodajEXP(Enemy.getNagrodaExp());
                    Player.DodajGold(Enemy.getNagrodaGold());

                    Enemy = null;

                    this.Hide();
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

            if (Player.GetHP() <= 0)
            {
                Player.SetHP(0);
                Player.SetMP(0);

                playerWin = false;
                inCombat = false;

                this.Hide();
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

                    if (Enemy.GetHP() > Enemy.GetMaxHP())
                        Enemy.SetHP(Enemy.GetMaxHP());
                }
                else
                    Player.SetHP(Player.GetHP() - (Enemy.SpecjalneAtaki.ElementAt(randomValue).GetValue() * EnemyDmgMultiplier) / PlayerDefMultiplier);

                Enemy.SetMP(Enemy.GetMP() - Enemy.SpecjalneAtaki.ElementAt(randomValue).GetManaCost());

                if (Enemy.GetMP() <= 0)
                    Enemy.SetMP(0);

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
