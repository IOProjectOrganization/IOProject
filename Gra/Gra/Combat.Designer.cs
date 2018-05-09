namespace Gra
{
    partial class Combat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BackgroundPB = new System.Windows.Forms.PictureBox();
            this.PlayerPB = new System.Windows.Forms.PictureBox();
            this.EnemyPB = new System.Windows.Forms.PictureBox();
            this.PlayerHPCurrentLabel = new System.Windows.Forms.Label();
            this.PlayerHPMaxLabel = new System.Windows.Forms.Label();
            this.PlayerHPSlashLabel = new System.Windows.Forms.Label();
            this.PlayerMPSlashLabel = new System.Windows.Forms.Label();
            this.PlayerMPMaxLabel = new System.Windows.Forms.Label();
            this.PlayerMPCurrentLabel = new System.Windows.Forms.Label();
            this.PlayerHPBP = new System.Windows.Forms.ProgressBar();
            this.PlayerMPBP = new System.Windows.Forms.ProgressBar();
            this.EnemyMPBP = new System.Windows.Forms.ProgressBar();
            this.EnemyHPBP = new System.Windows.Forms.ProgressBar();
            this.EnemyMPSlashLabel = new System.Windows.Forms.Label();
            this.EnemyMPMaxLabel = new System.Windows.Forms.Label();
            this.EnemyMPCurrentLabel = new System.Windows.Forms.Label();
            this.EnemyHPSlashLabel = new System.Windows.Forms.Label();
            this.EnemyHPMaxLabel = new System.Windows.Forms.Label();
            this.EnemyHPCurrentLabel = new System.Windows.Forms.Label();
            this.AttackBtn = new System.Windows.Forms.Button();
            this.SpecialSkillBtn = new System.Windows.Forms.Button();
            this.BlockBtn = new System.Windows.Forms.Button();
            this.ItemsBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Delay = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyPB)).BeginInit();
            this.SuspendLayout();
            // 
            // BackgroundPB
            // 
            this.BackgroundPB.Location = new System.Drawing.Point(12, 12);
            this.BackgroundPB.Name = "BackgroundPB";
            this.BackgroundPB.Size = new System.Drawing.Size(1256, 491);
            this.BackgroundPB.TabIndex = 0;
            this.BackgroundPB.TabStop = false;
            // 
            // PlayerPB
            // 
            this.PlayerPB.Location = new System.Drawing.Point(62, 30);
            this.PlayerPB.Name = "PlayerPB";
            this.PlayerPB.Size = new System.Drawing.Size(340, 450);
            this.PlayerPB.TabIndex = 1;
            this.PlayerPB.TabStop = false;
            // 
            // EnemyPB
            // 
            this.EnemyPB.Location = new System.Drawing.Point(928, 30);
            this.EnemyPB.Name = "EnemyPB";
            this.EnemyPB.Size = new System.Drawing.Size(290, 450);
            this.EnemyPB.TabIndex = 2;
            this.EnemyPB.TabStop = false;
            // 
            // PlayerHPCurrentLabel
            // 
            this.PlayerHPCurrentLabel.AutoSize = true;
            this.PlayerHPCurrentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.PlayerHPCurrentLabel.Location = new System.Drawing.Point(141, 534);
            this.PlayerHPCurrentLabel.Name = "PlayerHPCurrentLabel";
            this.PlayerHPCurrentLabel.Size = new System.Drawing.Size(52, 17);
            this.PlayerHPCurrentLabel.TabIndex = 3;
            this.PlayerHPCurrentLabel.Text = "label1";
            this.PlayerHPCurrentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PlayerHPMaxLabel
            // 
            this.PlayerHPMaxLabel.AutoSize = true;
            this.PlayerHPMaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.PlayerHPMaxLabel.Location = new System.Drawing.Point(257, 534);
            this.PlayerHPMaxLabel.Name = "PlayerHPMaxLabel";
            this.PlayerHPMaxLabel.Size = new System.Drawing.Size(52, 17);
            this.PlayerHPMaxLabel.TabIndex = 4;
            this.PlayerHPMaxLabel.Text = "label1";
            this.PlayerHPMaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PlayerHPSlashLabel
            // 
            this.PlayerHPSlashLabel.AutoSize = true;
            this.PlayerHPSlashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.PlayerHPSlashLabel.Location = new System.Drawing.Point(199, 534);
            this.PlayerHPSlashLabel.Name = "PlayerHPSlashLabel";
            this.PlayerHPSlashLabel.Size = new System.Drawing.Size(52, 17);
            this.PlayerHPSlashLabel.TabIndex = 5;
            this.PlayerHPSlashLabel.Text = "label1";
            this.PlayerHPSlashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerMPSlashLabel
            // 
            this.PlayerMPSlashLabel.AutoSize = true;
            this.PlayerMPSlashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.PlayerMPSlashLabel.Location = new System.Drawing.Point(199, 618);
            this.PlayerMPSlashLabel.Name = "PlayerMPSlashLabel";
            this.PlayerMPSlashLabel.Size = new System.Drawing.Size(52, 17);
            this.PlayerMPSlashLabel.TabIndex = 8;
            this.PlayerMPSlashLabel.Text = "label1";
            this.PlayerMPSlashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerMPMaxLabel
            // 
            this.PlayerMPMaxLabel.AutoSize = true;
            this.PlayerMPMaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.PlayerMPMaxLabel.Location = new System.Drawing.Point(257, 618);
            this.PlayerMPMaxLabel.Name = "PlayerMPMaxLabel";
            this.PlayerMPMaxLabel.Size = new System.Drawing.Size(52, 17);
            this.PlayerMPMaxLabel.TabIndex = 7;
            this.PlayerMPMaxLabel.Text = "label1";
            this.PlayerMPMaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PlayerMPCurrentLabel
            // 
            this.PlayerMPCurrentLabel.AutoSize = true;
            this.PlayerMPCurrentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.PlayerMPCurrentLabel.Location = new System.Drawing.Point(141, 618);
            this.PlayerMPCurrentLabel.Name = "PlayerMPCurrentLabel";
            this.PlayerMPCurrentLabel.Size = new System.Drawing.Size(52, 17);
            this.PlayerMPCurrentLabel.TabIndex = 6;
            this.PlayerMPCurrentLabel.Text = "label1";
            this.PlayerMPCurrentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PlayerHPBP
            // 
            this.PlayerHPBP.Location = new System.Drawing.Point(62, 560);
            this.PlayerHPBP.Name = "PlayerHPBP";
            this.PlayerHPBP.Size = new System.Drawing.Size(290, 45);
            this.PlayerHPBP.TabIndex = 9;
            // 
            // PlayerMPBP
            // 
            this.PlayerMPBP.Location = new System.Drawing.Point(62, 638);
            this.PlayerMPBP.Name = "PlayerMPBP";
            this.PlayerMPBP.Size = new System.Drawing.Size(290, 45);
            this.PlayerMPBP.TabIndex = 10;
            // 
            // EnemyMPBP
            // 
            this.EnemyMPBP.Location = new System.Drawing.Point(928, 638);
            this.EnemyMPBP.Name = "EnemyMPBP";
            this.EnemyMPBP.Size = new System.Drawing.Size(290, 45);
            this.EnemyMPBP.TabIndex = 18;
            // 
            // EnemyHPBP
            // 
            this.EnemyHPBP.Location = new System.Drawing.Point(928, 560);
            this.EnemyHPBP.Name = "EnemyHPBP";
            this.EnemyHPBP.Size = new System.Drawing.Size(290, 45);
            this.EnemyHPBP.TabIndex = 17;
            // 
            // EnemyMPSlashLabel
            // 
            this.EnemyMPSlashLabel.AutoSize = true;
            this.EnemyMPSlashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.EnemyMPSlashLabel.Location = new System.Drawing.Point(1065, 618);
            this.EnemyMPSlashLabel.Name = "EnemyMPSlashLabel";
            this.EnemyMPSlashLabel.Size = new System.Drawing.Size(52, 17);
            this.EnemyMPSlashLabel.TabIndex = 16;
            this.EnemyMPSlashLabel.Text = "label1";
            this.EnemyMPSlashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EnemyMPMaxLabel
            // 
            this.EnemyMPMaxLabel.AutoSize = true;
            this.EnemyMPMaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.EnemyMPMaxLabel.Location = new System.Drawing.Point(1123, 618);
            this.EnemyMPMaxLabel.Name = "EnemyMPMaxLabel";
            this.EnemyMPMaxLabel.Size = new System.Drawing.Size(52, 17);
            this.EnemyMPMaxLabel.TabIndex = 15;
            this.EnemyMPMaxLabel.Text = "label1";
            this.EnemyMPMaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EnemyMPCurrentLabel
            // 
            this.EnemyMPCurrentLabel.AutoSize = true;
            this.EnemyMPCurrentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.EnemyMPCurrentLabel.Location = new System.Drawing.Point(1007, 618);
            this.EnemyMPCurrentLabel.Name = "EnemyMPCurrentLabel";
            this.EnemyMPCurrentLabel.Size = new System.Drawing.Size(52, 17);
            this.EnemyMPCurrentLabel.TabIndex = 14;
            this.EnemyMPCurrentLabel.Text = "label1";
            this.EnemyMPCurrentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EnemyHPSlashLabel
            // 
            this.EnemyHPSlashLabel.AutoSize = true;
            this.EnemyHPSlashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.EnemyHPSlashLabel.Location = new System.Drawing.Point(1065, 534);
            this.EnemyHPSlashLabel.Name = "EnemyHPSlashLabel";
            this.EnemyHPSlashLabel.Size = new System.Drawing.Size(52, 17);
            this.EnemyHPSlashLabel.TabIndex = 13;
            this.EnemyHPSlashLabel.Text = "label1";
            this.EnemyHPSlashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EnemyHPMaxLabel
            // 
            this.EnemyHPMaxLabel.AutoSize = true;
            this.EnemyHPMaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.EnemyHPMaxLabel.Location = new System.Drawing.Point(1123, 534);
            this.EnemyHPMaxLabel.Name = "EnemyHPMaxLabel";
            this.EnemyHPMaxLabel.Size = new System.Drawing.Size(52, 17);
            this.EnemyHPMaxLabel.TabIndex = 12;
            this.EnemyHPMaxLabel.Text = "label1";
            this.EnemyHPMaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EnemyHPCurrentLabel
            // 
            this.EnemyHPCurrentLabel.AutoSize = true;
            this.EnemyHPCurrentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.EnemyHPCurrentLabel.Location = new System.Drawing.Point(1007, 534);
            this.EnemyHPCurrentLabel.Name = "EnemyHPCurrentLabel";
            this.EnemyHPCurrentLabel.Size = new System.Drawing.Size(52, 17);
            this.EnemyHPCurrentLabel.TabIndex = 11;
            this.EnemyHPCurrentLabel.Text = "label1";
            this.EnemyHPCurrentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AttackBtn
            // 
            this.AttackBtn.Location = new System.Drawing.Point(570, 509);
            this.AttackBtn.Name = "AttackBtn";
            this.AttackBtn.Size = new System.Drawing.Size(140, 45);
            this.AttackBtn.TabIndex = 19;
            this.AttackBtn.Text = "Atak";
            this.AttackBtn.UseVisualStyleBackColor = true;
            this.AttackBtn.Click += new System.EventHandler(this.AttackBtn_Click);
            // 
            // SpecialSkillBtn
            // 
            this.SpecialSkillBtn.Location = new System.Drawing.Point(570, 560);
            this.SpecialSkillBtn.Name = "SpecialSkillBtn";
            this.SpecialSkillBtn.Size = new System.Drawing.Size(140, 45);
            this.SpecialSkillBtn.TabIndex = 19;
            this.SpecialSkillBtn.Text = "Umiejętności specjalne";
            this.SpecialSkillBtn.UseVisualStyleBackColor = true;
            this.SpecialSkillBtn.Click += new System.EventHandler(this.SpecialSkillBtn_Click);
            // 
            // BlockBtn
            // 
            this.BlockBtn.Location = new System.Drawing.Point(570, 611);
            this.BlockBtn.Name = "BlockBtn";
            this.BlockBtn.Size = new System.Drawing.Size(140, 45);
            this.BlockBtn.TabIndex = 19;
            this.BlockBtn.Text = "Obrona";
            this.BlockBtn.UseVisualStyleBackColor = true;
            this.BlockBtn.Click += new System.EventHandler(this.BlockBtn_Click);
            // 
            // ItemsBtn
            // 
            this.ItemsBtn.Location = new System.Drawing.Point(570, 662);
            this.ItemsBtn.Name = "ItemsBtn";
            this.ItemsBtn.Size = new System.Drawing.Size(140, 45);
            this.ItemsBtn.TabIndex = 19;
            this.ItemsBtn.Text = "Przedmioty";
            this.ItemsBtn.UseVisualStyleBackColor = true;
            this.ItemsBtn.Click += new System.EventHandler(this.ItemsBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(782, 616);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Delay
            // 
            this.Delay.Enabled = true;
            this.Delay.Interval = 1000;
            this.Delay.Tick += new System.EventHandler(this.Delay_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(603, 353);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "label1";
            // 
            // Combat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ItemsBtn);
            this.Controls.Add(this.BlockBtn);
            this.Controls.Add(this.SpecialSkillBtn);
            this.Controls.Add(this.AttackBtn);
            this.Controls.Add(this.EnemyMPBP);
            this.Controls.Add(this.EnemyHPBP);
            this.Controls.Add(this.EnemyMPSlashLabel);
            this.Controls.Add(this.EnemyMPMaxLabel);
            this.Controls.Add(this.EnemyMPCurrentLabel);
            this.Controls.Add(this.EnemyHPSlashLabel);
            this.Controls.Add(this.EnemyHPMaxLabel);
            this.Controls.Add(this.EnemyHPCurrentLabel);
            this.Controls.Add(this.PlayerMPBP);
            this.Controls.Add(this.PlayerHPBP);
            this.Controls.Add(this.PlayerMPSlashLabel);
            this.Controls.Add(this.PlayerMPMaxLabel);
            this.Controls.Add(this.PlayerMPCurrentLabel);
            this.Controls.Add(this.PlayerHPSlashLabel);
            this.Controls.Add(this.PlayerHPMaxLabel);
            this.Controls.Add(this.PlayerHPCurrentLabel);
            this.Controls.Add(this.EnemyPB);
            this.Controls.Add(this.PlayerPB);
            this.Controls.Add(this.BackgroundPB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Combat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Combat";
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BackgroundPB;
        private System.Windows.Forms.PictureBox PlayerPB;
        private System.Windows.Forms.PictureBox EnemyPB;
        private System.Windows.Forms.Label PlayerHPCurrentLabel;
        private System.Windows.Forms.Label PlayerHPMaxLabel;
        private System.Windows.Forms.Label PlayerHPSlashLabel;
        private System.Windows.Forms.Label PlayerMPSlashLabel;
        private System.Windows.Forms.Label PlayerMPMaxLabel;
        private System.Windows.Forms.Label PlayerMPCurrentLabel;
        private System.Windows.Forms.ProgressBar PlayerHPBP;
        private System.Windows.Forms.ProgressBar PlayerMPBP;
        private System.Windows.Forms.ProgressBar EnemyMPBP;
        private System.Windows.Forms.ProgressBar EnemyHPBP;
        private System.Windows.Forms.Label EnemyMPSlashLabel;
        private System.Windows.Forms.Label EnemyMPMaxLabel;
        private System.Windows.Forms.Label EnemyMPCurrentLabel;
        private System.Windows.Forms.Label EnemyHPSlashLabel;
        private System.Windows.Forms.Label EnemyHPMaxLabel;
        private System.Windows.Forms.Label EnemyHPCurrentLabel;
        private System.Windows.Forms.Button AttackBtn;
        private System.Windows.Forms.Button SpecialSkillBtn;
        private System.Windows.Forms.Button BlockBtn;
        private System.Windows.Forms.Button ItemsBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer Delay;
        private System.Windows.Forms.Label label1;
    }
}