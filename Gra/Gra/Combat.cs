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
        }

        private void Combat_Load(object sender, EventArgs e)
        {
            
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

            PlayerPB.Image = Gra.Properties.Resources.PlayerCombat;

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
                label1.Text = Enemy.getNazwa();
            }
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
                    }
                    else
                    {
                        randomValue = random.Next(1000);
                        
                        if (randomValue < 800)
                            EnemyAttack();

                        else
                            EnemyBlock();
                    }
                }
            }
        }
    }
}
