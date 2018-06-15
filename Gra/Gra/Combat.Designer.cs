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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.PlayerHPText = new System.Windows.Forms.Label();
            this.PlayerMPText = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.EnemyHPText = new System.Windows.Forms.Label();
            this.EnemyMPText = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyPB)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BackgroundPB
            // 
            this.BackgroundPB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackgroundPB.Image = global::Gra.Properties.Resources.world00;
            this.BackgroundPB.InitialImage = null;
            this.BackgroundPB.Location = new System.Drawing.Point(0, 0);
            this.BackgroundPB.Name = "BackgroundPB";
            this.BackgroundPB.Size = new System.Drawing.Size(1210, 426);
            this.BackgroundPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.BackgroundPB.TabIndex = 0;
            this.BackgroundPB.TabStop = false;
            // 
            // PlayerPB
            // 
            this.PlayerPB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerPB.Location = new System.Drawing.Point(63, 45);
            this.PlayerPB.Name = "PlayerPB";
            this.PlayerPB.Size = new System.Drawing.Size(236, 334);
            this.PlayerPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PlayerPB.TabIndex = 1;
            this.PlayerPB.TabStop = false;
            // 
            // EnemyPB
            // 
            this.EnemyPB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EnemyPB.Location = new System.Drawing.Point(910, 45);
            this.EnemyPB.Name = "EnemyPB";
            this.EnemyPB.Size = new System.Drawing.Size(236, 334);
            this.EnemyPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EnemyPB.TabIndex = 2;
            this.EnemyPB.TabStop = false;
            // 
            // PlayerHPCurrentLabel
            // 
            this.PlayerHPCurrentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerHPCurrentLabel.AutoSize = true;
            this.PlayerHPCurrentLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.PlayerHPCurrentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.PlayerHPCurrentLabel.Location = new System.Drawing.Point(97, 23);
            this.PlayerHPCurrentLabel.Name = "PlayerHPCurrentLabel";
            this.PlayerHPCurrentLabel.Size = new System.Drawing.Size(46, 23);
            this.PlayerHPCurrentLabel.TabIndex = 3;
            this.PlayerHPCurrentLabel.Text = "label1";
            this.PlayerHPCurrentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PlayerHPCurrentLabel.SizeChanged += new System.EventHandler(this.Label_SizeChanged);
            // 
            // PlayerHPMaxLabel
            // 
            this.PlayerHPMaxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerHPMaxLabel.AutoSize = true;
            this.PlayerHPMaxLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.PlayerHPMaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.PlayerHPMaxLabel.Location = new System.Drawing.Point(201, 23);
            this.PlayerHPMaxLabel.Name = "PlayerHPMaxLabel";
            this.PlayerHPMaxLabel.Size = new System.Drawing.Size(46, 23);
            this.PlayerHPMaxLabel.TabIndex = 4;
            this.PlayerHPMaxLabel.Text = "label1";
            this.PlayerHPMaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerHPSlashLabel
            // 
            this.PlayerHPSlashLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerHPSlashLabel.AutoSize = true;
            this.PlayerHPSlashLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.PlayerHPSlashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.PlayerHPSlashLabel.Location = new System.Drawing.Point(149, 23);
            this.PlayerHPSlashLabel.Name = "PlayerHPSlashLabel";
            this.PlayerHPSlashLabel.Size = new System.Drawing.Size(46, 23);
            this.PlayerHPSlashLabel.TabIndex = 5;
            this.PlayerHPSlashLabel.Text = "label1";
            this.PlayerHPSlashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerMPSlashLabel
            // 
            this.PlayerMPSlashLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerMPSlashLabel.AutoSize = true;
            this.PlayerMPSlashLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.PlayerMPSlashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.PlayerMPSlashLabel.Location = new System.Drawing.Point(149, 128);
            this.PlayerMPSlashLabel.Name = "PlayerMPSlashLabel";
            this.PlayerMPSlashLabel.Size = new System.Drawing.Size(46, 23);
            this.PlayerMPSlashLabel.TabIndex = 8;
            this.PlayerMPSlashLabel.Text = "label1";
            this.PlayerMPSlashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerMPMaxLabel
            // 
            this.PlayerMPMaxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerMPMaxLabel.AutoSize = true;
            this.PlayerMPMaxLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.PlayerMPMaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.PlayerMPMaxLabel.Location = new System.Drawing.Point(201, 128);
            this.PlayerMPMaxLabel.Name = "PlayerMPMaxLabel";
            this.PlayerMPMaxLabel.Size = new System.Drawing.Size(46, 23);
            this.PlayerMPMaxLabel.TabIndex = 7;
            this.PlayerMPMaxLabel.Text = "label1";
            this.PlayerMPMaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerMPCurrentLabel
            // 
            this.PlayerMPCurrentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerMPCurrentLabel.AutoSize = true;
            this.PlayerMPCurrentLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.PlayerMPCurrentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.PlayerMPCurrentLabel.Location = new System.Drawing.Point(97, 128);
            this.PlayerMPCurrentLabel.Name = "PlayerMPCurrentLabel";
            this.PlayerMPCurrentLabel.Size = new System.Drawing.Size(46, 23);
            this.PlayerMPCurrentLabel.TabIndex = 6;
            this.PlayerMPCurrentLabel.Text = "label1";
            this.PlayerMPCurrentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerHPBP
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.PlayerHPBP, 5);
            this.PlayerHPBP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerHPBP.Location = new System.Drawing.Point(37, 49);
            this.PlayerHPBP.Name = "PlayerHPBP";
            this.PlayerHPBP.Size = new System.Drawing.Size(270, 53);
            this.PlayerHPBP.TabIndex = 9;
            // 
            // PlayerMPBP
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.PlayerMPBP, 5);
            this.PlayerMPBP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerMPBP.Location = new System.Drawing.Point(37, 154);
            this.PlayerMPBP.Name = "PlayerMPBP";
            this.PlayerMPBP.Size = new System.Drawing.Size(270, 53);
            this.PlayerMPBP.TabIndex = 10;
            // 
            // EnemyMPBP
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.EnemyMPBP, 5);
            this.EnemyMPBP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EnemyMPBP.Location = new System.Drawing.Point(37, 154);
            this.EnemyMPBP.Name = "EnemyMPBP";
            this.EnemyMPBP.Size = new System.Drawing.Size(270, 53);
            this.EnemyMPBP.TabIndex = 18;
            // 
            // EnemyHPBP
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.EnemyHPBP, 5);
            this.EnemyHPBP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EnemyHPBP.Location = new System.Drawing.Point(37, 49);
            this.EnemyHPBP.Name = "EnemyHPBP";
            this.EnemyHPBP.Size = new System.Drawing.Size(270, 53);
            this.EnemyHPBP.TabIndex = 17;
            // 
            // EnemyMPSlashLabel
            // 
            this.EnemyMPSlashLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EnemyMPSlashLabel.AutoSize = true;
            this.EnemyMPSlashLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.EnemyMPSlashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.EnemyMPSlashLabel.Location = new System.Drawing.Point(149, 128);
            this.EnemyMPSlashLabel.Name = "EnemyMPSlashLabel";
            this.EnemyMPSlashLabel.Size = new System.Drawing.Size(46, 23);
            this.EnemyMPSlashLabel.TabIndex = 16;
            this.EnemyMPSlashLabel.Text = "label1";
            this.EnemyMPSlashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EnemyMPMaxLabel
            // 
            this.EnemyMPMaxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EnemyMPMaxLabel.AutoSize = true;
            this.EnemyMPMaxLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.EnemyMPMaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.EnemyMPMaxLabel.Location = new System.Drawing.Point(201, 128);
            this.EnemyMPMaxLabel.Name = "EnemyMPMaxLabel";
            this.EnemyMPMaxLabel.Size = new System.Drawing.Size(46, 23);
            this.EnemyMPMaxLabel.TabIndex = 15;
            this.EnemyMPMaxLabel.Text = "label1";
            this.EnemyMPMaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EnemyMPCurrentLabel
            // 
            this.EnemyMPCurrentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EnemyMPCurrentLabel.AutoSize = true;
            this.EnemyMPCurrentLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.EnemyMPCurrentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.EnemyMPCurrentLabel.Location = new System.Drawing.Point(97, 128);
            this.EnemyMPCurrentLabel.Name = "EnemyMPCurrentLabel";
            this.EnemyMPCurrentLabel.Size = new System.Drawing.Size(46, 23);
            this.EnemyMPCurrentLabel.TabIndex = 14;
            this.EnemyMPCurrentLabel.Text = "label1";
            this.EnemyMPCurrentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EnemyHPSlashLabel
            // 
            this.EnemyHPSlashLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EnemyHPSlashLabel.AutoSize = true;
            this.EnemyHPSlashLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.EnemyHPSlashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.EnemyHPSlashLabel.Location = new System.Drawing.Point(149, 23);
            this.EnemyHPSlashLabel.Name = "EnemyHPSlashLabel";
            this.EnemyHPSlashLabel.Size = new System.Drawing.Size(46, 23);
            this.EnemyHPSlashLabel.TabIndex = 13;
            this.EnemyHPSlashLabel.Text = "label1";
            this.EnemyHPSlashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EnemyHPMaxLabel
            // 
            this.EnemyHPMaxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EnemyHPMaxLabel.AutoSize = true;
            this.EnemyHPMaxLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.EnemyHPMaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.EnemyHPMaxLabel.Location = new System.Drawing.Point(201, 23);
            this.EnemyHPMaxLabel.Name = "EnemyHPMaxLabel";
            this.EnemyHPMaxLabel.Size = new System.Drawing.Size(46, 23);
            this.EnemyHPMaxLabel.TabIndex = 12;
            this.EnemyHPMaxLabel.Text = "label1";
            this.EnemyHPMaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EnemyHPCurrentLabel
            // 
            this.EnemyHPCurrentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EnemyHPCurrentLabel.AutoSize = true;
            this.EnemyHPCurrentLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.EnemyHPCurrentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.EnemyHPCurrentLabel.Location = new System.Drawing.Point(97, 23);
            this.EnemyHPCurrentLabel.Name = "EnemyHPCurrentLabel";
            this.EnemyHPCurrentLabel.Size = new System.Drawing.Size(46, 23);
            this.EnemyHPCurrentLabel.TabIndex = 11;
            this.EnemyHPCurrentLabel.Text = "label1";
            this.EnemyHPCurrentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AttackBtn
            // 
            this.AttackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.AttackBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AttackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AttackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.AttackBtn.Location = new System.Drawing.Point(547, 462);
            this.AttackBtn.Name = "AttackBtn";
            this.AttackBtn.Size = new System.Drawing.Size(186, 48);
            this.AttackBtn.TabIndex = 19;
            this.AttackBtn.Text = "Atak";
            this.AttackBtn.UseVisualStyleBackColor = false;
            this.AttackBtn.SizeChanged += new System.EventHandler(this.Button_SizeChanged);
            this.AttackBtn.Click += new System.EventHandler(this.AttackBtn_Click);
            // 
            // SpecialSkillBtn
            // 
            this.SpecialSkillBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.SpecialSkillBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpecialSkillBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SpecialSkillBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.SpecialSkillBtn.Location = new System.Drawing.Point(547, 525);
            this.SpecialSkillBtn.Name = "SpecialSkillBtn";
            this.SpecialSkillBtn.Size = new System.Drawing.Size(186, 48);
            this.SpecialSkillBtn.TabIndex = 19;
            this.SpecialSkillBtn.Text = "Atak specjalny";
            this.SpecialSkillBtn.UseVisualStyleBackColor = false;
            this.SpecialSkillBtn.Click += new System.EventHandler(this.SpecialSkillBtn_Click);
            // 
            // BlockBtn
            // 
            this.BlockBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.BlockBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BlockBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BlockBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.BlockBtn.Location = new System.Drawing.Point(547, 588);
            this.BlockBtn.Name = "BlockBtn";
            this.BlockBtn.Size = new System.Drawing.Size(186, 48);
            this.BlockBtn.TabIndex = 19;
            this.BlockBtn.Text = "Obrona";
            this.BlockBtn.UseVisualStyleBackColor = false;
            this.BlockBtn.Click += new System.EventHandler(this.BlockBtn_Click);
            // 
            // ItemsBtn
            // 
            this.ItemsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.ItemsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ItemsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.ItemsBtn.Location = new System.Drawing.Point(547, 651);
            this.ItemsBtn.Name = "ItemsBtn";
            this.ItemsBtn.Size = new System.Drawing.Size(186, 48);
            this.ItemsBtn.TabIndex = 19;
            this.ItemsBtn.Text = "Przedmioty";
            this.ItemsBtn.UseVisualStyleBackColor = false;
            this.ItemsBtn.Click += new System.EventHandler(this.ItemsBtn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(739, 588);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 48);
            this.button1.TabIndex = 20;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Delay
            // 
            this.Delay.Interval = 1000;
            this.Delay.Tick += new System.EventHandler(this.Delay_Tick);
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(66, 461);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 7);
            this.panel1.Size = new System.Drawing.Size(348, 239);
            this.panel1.TabIndex = 21;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 7;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.Controls.Add(this.PlayerMPBP, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.PlayerMPMaxLabel, 4, 4);
            this.tableLayoutPanel3.Controls.Add(this.PlayerHPCurrentLabel, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.PlayerMPSlashLabel, 3, 4);
            this.tableLayoutPanel3.Controls.Add(this.PlayerHPSlashLabel, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.PlayerMPCurrentLabel, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.PlayerHPMaxLabel, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.PlayerHPBP, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.PlayerHPText, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.PlayerMPText, 2, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(348, 239);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // PlayerHPText
            // 
            this.PlayerHPText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerHPText.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.PlayerHPText, 3);
            this.PlayerHPText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.PlayerHPText.Location = new System.Drawing.Point(97, 0);
            this.PlayerHPText.Name = "PlayerHPText";
            this.PlayerHPText.Size = new System.Drawing.Size(150, 23);
            this.PlayerHPText.TabIndex = 11;
            this.PlayerHPText.Text = "Życie";
            this.PlayerHPText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerMPText
            // 
            this.PlayerMPText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerMPText.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.PlayerMPText, 3);
            this.PlayerMPText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.PlayerMPText.Location = new System.Drawing.Point(97, 105);
            this.PlayerMPText.Name = "PlayerMPText";
            this.PlayerMPText.Size = new System.Drawing.Size(150, 23);
            this.PlayerMPText.TabIndex = 12;
            this.PlayerMPText.Text = "Mana";
            this.PlayerMPText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.panel2.Controls.Add(this.tableLayoutPanel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(866, 461);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.tableLayoutPanel1.SetRowSpan(this.panel2, 7);
            this.panel2.Size = new System.Drawing.Size(348, 239);
            this.panel2.TabIndex = 22;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 7;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.Controls.Add(this.EnemyMPMaxLabel, 4, 4);
            this.tableLayoutPanel4.Controls.Add(this.EnemyMPBP, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this.EnemyMPSlashLabel, 3, 4);
            this.tableLayoutPanel4.Controls.Add(this.EnemyHPBP, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.EnemyMPCurrentLabel, 2, 4);
            this.tableLayoutPanel4.Controls.Add(this.EnemyHPSlashLabel, 3, 1);
            this.tableLayoutPanel4.Controls.Add(this.EnemyHPCurrentLabel, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.EnemyHPMaxLabel, 4, 1);
            this.tableLayoutPanel4.Controls.Add(this.EnemyHPText, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.EnemyMPText, 2, 3);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 7;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(348, 239);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // EnemyHPText
            // 
            this.EnemyHPText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EnemyHPText.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.EnemyHPText, 3);
            this.EnemyHPText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.EnemyHPText.Location = new System.Drawing.Point(97, 0);
            this.EnemyHPText.Name = "EnemyHPText";
            this.EnemyHPText.Size = new System.Drawing.Size(150, 23);
            this.EnemyHPText.TabIndex = 19;
            this.EnemyHPText.Text = "Życie";
            this.EnemyHPText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EnemyMPText
            // 
            this.EnemyMPText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EnemyMPText.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.EnemyMPText, 3);
            this.EnemyMPText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.EnemyMPText.Location = new System.Drawing.Point(97, 105);
            this.EnemyMPText.Name = "EnemyMPText";
            this.EnemyMPText.Size = new System.Drawing.Size(150, 23);
            this.EnemyMPText.TabIndex = 20;
            this.EnemyMPText.Text = "Mana";
            this.EnemyMPText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.button1, 5, 7);
            this.tableLayoutPanel1.Controls.Add(this.AttackBtn, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.ItemsBtn, 4, 9);
            this.tableLayoutPanel1.Controls.Add(this.SpecialSkillBtn, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.BlockBtn, 4, 7);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 6, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1280, 720);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // panel3
            // 
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 7);
            this.panel3.Controls.Add(this.tableLayoutPanel2);
            this.panel3.Controls.Add(this.BackgroundPB);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(35, 21);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1210, 426);
            this.panel3.TabIndex = 24;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.Controls.Add(this.EnemyPB, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.PlayerPB, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1210, 426);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // Combat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(39)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Combat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Combat";
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyPB)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label PlayerHPText;
        private System.Windows.Forms.Label PlayerMPText;
        private System.Windows.Forms.Label EnemyHPText;
        private System.Windows.Forms.Label EnemyMPText;
    }
}