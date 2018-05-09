namespace Gra
{
    partial class Equipment
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.bohaterImie = new System.Windows.Forms.Label();
            this.Level = new System.Windows.Forms.Label();
            this.Zloto = new System.Windows.Forms.Label();
            this.Sila = new System.Windows.Forms.Label();
            this.Zrecznosc = new System.Windows.Forms.Label();
            this.Inteligencja = new System.Windows.Forms.Label();
            this.HP = new System.Windows.Forms.Label();
            this.MP = new System.Windows.Forms.Label();
            this.PunktyD = new System.Windows.Forms.Label();
            this.bohaterLevel = new System.Windows.Forms.Label();
            this.bohaterHP = new System.Windows.Forms.Label();
            this.bohaterMP = new System.Windows.Forms.Label();
            this.bohaterPunktyD = new System.Windows.Forms.Label();
            this.bohaterSila = new System.Windows.Forms.Label();
            this.bohaterZrecznosc = new System.Windows.Forms.Label();
            this.bohaterInteligencja = new System.Windows.Forms.Label();
            this.bohaterZloto = new System.Windows.Forms.Label();
            this.bohaterMPMax = new System.Windows.Forms.Label();
            this.bohaterHPMax = new System.Windows.Forms.Label();
            this.ukosnik1 = new System.Windows.Forms.Label();
            this.ukosnik2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bohaterExp = new System.Windows.Forms.ProgressBar();
            this.Exp = new System.Windows.Forms.Label();
            this.obramowanie_panel = new System.Windows.Forms.Panel();
            this.ekwipunek_label = new System.Windows.Forms.Label();
            this.statystyki_label = new System.Windows.Forms.Label();
            this.uzycie = new System.Windows.Forms.Button();
            this.PlayerPB = new System.Windows.Forms.PictureBox();
            this.EquippedArmor = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.EquippedWeapon = new System.Windows.Forms.ListView();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.zdjecie = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerPB)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 22;
            this.listBox1.Location = new System.Drawing.Point(21, 204);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(302, 352);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(909, 605);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 74);
            this.button1.TabIndex = 1;
            this.button1.Text = "Powrót";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bohaterImie
            // 
            this.bohaterImie.AutoSize = true;
            this.bohaterImie.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold);
            this.bohaterImie.ForeColor = System.Drawing.Color.White;
            this.bohaterImie.Location = new System.Drawing.Point(482, 558);
            this.bohaterImie.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bohaterImie.Name = "bohaterImie";
            this.bohaterImie.Size = new System.Drawing.Size(110, 36);
            this.bohaterImie.TabIndex = 2;
            this.bohaterImie.Text = "Godric";
            // 
            // Level
            // 
            this.Level.AutoSize = true;
            this.Level.BackColor = System.Drawing.Color.Transparent;
            this.Level.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Level.Location = new System.Drawing.Point(767, 214);
            this.Level.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Level.Name = "Level";
            this.Level.Size = new System.Drawing.Size(68, 17);
            this.Level.TabIndex = 3;
            this.Level.Text = "POZIOM";
            // 
            // Zloto
            // 
            this.Zloto.AutoSize = true;
            this.Zloto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.Zloto.Location = new System.Drawing.Point(768, 506);
            this.Zloto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Zloto.Name = "Zloto";
            this.Zloto.Size = new System.Drawing.Size(61, 17);
            this.Zloto.TabIndex = 4;
            this.Zloto.Text = "ZŁOTO";
            // 
            // Sila
            // 
            this.Sila.AutoSize = true;
            this.Sila.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.Sila.Location = new System.Drawing.Point(767, 379);
            this.Sila.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Sila.Name = "Sila";
            this.Sila.Size = new System.Drawing.Size(41, 17);
            this.Sila.TabIndex = 6;
            this.Sila.Text = "SIŁA";
            // 
            // Zrecznosc
            // 
            this.Zrecznosc.AutoSize = true;
            this.Zrecznosc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.Zrecznosc.Location = new System.Drawing.Point(767, 409);
            this.Zrecznosc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Zrecznosc.Name = "Zrecznosc";
            this.Zrecznosc.Size = new System.Drawing.Size(102, 17);
            this.Zrecznosc.TabIndex = 7;
            this.Zrecznosc.Text = "ZRĘCZNOŚĆ";
            // 
            // Inteligencja
            // 
            this.Inteligencja.AutoSize = true;
            this.Inteligencja.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.Inteligencja.Location = new System.Drawing.Point(767, 437);
            this.Inteligencja.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Inteligencja.Name = "Inteligencja";
            this.Inteligencja.Size = new System.Drawing.Size(117, 17);
            this.Inteligencja.TabIndex = 8;
            this.Inteligencja.Text = "INTELIGENCJA";
            // 
            // HP
            // 
            this.HP.AutoSize = true;
            this.HP.BackColor = System.Drawing.Color.Transparent;
            this.HP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.HP.Location = new System.Drawing.Point(768, 240);
            this.HP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.HP.Name = "HP";
            this.HP.Size = new System.Drawing.Size(147, 17);
            this.HP.TabIndex = 9;
            this.HP.Text = "PUNKTY ZDROWIA";
            // 
            // MP
            // 
            this.MP.AutoSize = true;
            this.MP.BackColor = System.Drawing.Color.Transparent;
            this.MP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.MP.Location = new System.Drawing.Point(767, 269);
            this.MP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MP.Name = "MP";
            this.MP.Size = new System.Drawing.Size(117, 17);
            this.MP.TabIndex = 10;
            this.MP.Text = "PUNKTY MAGII";
            // 
            // PunktyD
            // 
            this.PunktyD.AutoSize = true;
            this.PunktyD.BackColor = System.Drawing.Color.Transparent;
            this.PunktyD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.PunktyD.Location = new System.Drawing.Point(767, 299);
            this.PunktyD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PunktyD.Name = "PunktyD";
            this.PunktyD.Size = new System.Drawing.Size(187, 17);
            this.PunktyD.TabIndex = 11;
            this.PunktyD.Text = "PUNKTY UMIEJĘTNOŚCI";
            // 
            // bohaterLevel
            // 
            this.bohaterLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterLevel.Location = new System.Drawing.Point(1100, 214);
            this.bohaterLevel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bohaterLevel.Name = "bohaterLevel";
            this.bohaterLevel.Size = new System.Drawing.Size(63, 18);
            this.bohaterLevel.TabIndex = 12;
            this.bohaterLevel.Text = "label1";
            this.bohaterLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bohaterHP
            // 
            this.bohaterHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterHP.Location = new System.Drawing.Point(1019, 241);
            this.bohaterHP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bohaterHP.Name = "bohaterHP";
            this.bohaterHP.Size = new System.Drawing.Size(63, 17);
            this.bohaterHP.TabIndex = 13;
            this.bohaterHP.Text = "label2";
            this.bohaterHP.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bohaterMP
            // 
            this.bohaterMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterMP.Location = new System.Drawing.Point(1019, 269);
            this.bohaterMP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bohaterMP.Name = "bohaterMP";
            this.bohaterMP.Size = new System.Drawing.Size(63, 18);
            this.bohaterMP.TabIndex = 14;
            this.bohaterMP.Text = "label3";
            this.bohaterMP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bohaterPunktyD
            // 
            this.bohaterPunktyD.BackColor = System.Drawing.Color.Transparent;
            this.bohaterPunktyD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterPunktyD.Location = new System.Drawing.Point(1100, 299);
            this.bohaterPunktyD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bohaterPunktyD.Name = "bohaterPunktyD";
            this.bohaterPunktyD.Size = new System.Drawing.Size(63, 18);
            this.bohaterPunktyD.TabIndex = 15;
            this.bohaterPunktyD.Text = "label4";
            this.bohaterPunktyD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bohaterSila
            // 
            this.bohaterSila.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterSila.Location = new System.Drawing.Point(1100, 379);
            this.bohaterSila.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bohaterSila.Name = "bohaterSila";
            this.bohaterSila.Size = new System.Drawing.Size(63, 18);
            this.bohaterSila.TabIndex = 16;
            this.bohaterSila.Text = "label5";
            this.bohaterSila.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bohaterZrecznosc
            // 
            this.bohaterZrecznosc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterZrecznosc.Location = new System.Drawing.Point(1100, 410);
            this.bohaterZrecznosc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bohaterZrecznosc.Name = "bohaterZrecznosc";
            this.bohaterZrecznosc.Size = new System.Drawing.Size(63, 17);
            this.bohaterZrecznosc.TabIndex = 17;
            this.bohaterZrecznosc.Text = "label6";
            this.bohaterZrecznosc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bohaterInteligencja
            // 
            this.bohaterInteligencja.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterInteligencja.Location = new System.Drawing.Point(1100, 437);
            this.bohaterInteligencja.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bohaterInteligencja.Name = "bohaterInteligencja";
            this.bohaterInteligencja.Size = new System.Drawing.Size(63, 18);
            this.bohaterInteligencja.TabIndex = 18;
            this.bohaterInteligencja.Text = "label7";
            this.bohaterInteligencja.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bohaterZloto
            // 
            this.bohaterZloto.BackColor = System.Drawing.Color.Transparent;
            this.bohaterZloto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterZloto.Location = new System.Drawing.Point(1100, 506);
            this.bohaterZloto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bohaterZloto.Name = "bohaterZloto";
            this.bohaterZloto.Size = new System.Drawing.Size(63, 18);
            this.bohaterZloto.TabIndex = 19;
            this.bohaterZloto.Text = "label8";
            this.bohaterZloto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bohaterMPMax
            // 
            this.bohaterMPMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterMPMax.Location = new System.Drawing.Point(1100, 270);
            this.bohaterMPMax.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bohaterMPMax.Name = "bohaterMPMax";
            this.bohaterMPMax.Size = new System.Drawing.Size(62, 19);
            this.bohaterMPMax.TabIndex = 21;
            this.bohaterMPMax.Text = "label1";
            this.bohaterMPMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bohaterHPMax
            // 
            this.bohaterHPMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterHPMax.Location = new System.Drawing.Point(1100, 240);
            this.bohaterHPMax.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bohaterHPMax.Name = "bohaterHPMax";
            this.bohaterHPMax.Size = new System.Drawing.Size(62, 18);
            this.bohaterHPMax.TabIndex = 22;
            this.bohaterHPMax.Text = "label2";
            this.bohaterHPMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ukosnik1
            // 
            this.ukosnik1.AutoSize = true;
            this.ukosnik1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.ukosnik1.Location = new System.Drawing.Point(1087, 240);
            this.ukosnik1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ukosnik1.Name = "ukosnik1";
            this.ukosnik1.Size = new System.Drawing.Size(13, 17);
            this.ukosnik1.TabIndex = 23;
            this.ukosnik1.Text = "/";
            // 
            // ukosnik2
            // 
            this.ukosnik2.AutoSize = true;
            this.ukosnik2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.ukosnik2.Location = new System.Drawing.Point(1087, 269);
            this.ukosnik2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ukosnik2.Name = "ukosnik2";
            this.ukosnik2.Size = new System.Drawing.Size(13, 17);
            this.ukosnik2.TabIndex = 24;
            this.ukosnik2.Text = "/";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.pictureBox1.Location = new System.Drawing.Point(748, 204);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(430, 351);
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // bohaterExp
            // 
            this.bohaterExp.Location = new System.Drawing.Point(1018, 341);
            this.bohaterExp.Margin = new System.Windows.Forms.Padding(2);
            this.bohaterExp.Name = "bohaterExp";
            this.bohaterExp.Size = new System.Drawing.Size(146, 15);
            this.bohaterExp.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.bohaterExp.TabIndex = 26;
            // 
            // Exp
            // 
            this.Exp.AutoSize = true;
            this.Exp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.Exp.Location = new System.Drawing.Point(767, 341);
            this.Exp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Exp.Name = "Exp";
            this.Exp.Size = new System.Drawing.Size(135, 17);
            this.Exp.TabIndex = 27;
            this.Exp.Text = "DOŚWIADCZENIE";
            // 
            // obramowanie_panel
            // 
            this.obramowanie_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.obramowanie_panel.Location = new System.Drawing.Point(0, 0);
            this.obramowanie_panel.Margin = new System.Windows.Forms.Padding(2);
            this.obramowanie_panel.Name = "obramowanie_panel";
            this.obramowanie_panel.Size = new System.Drawing.Size(1200, 37);
            this.obramowanie_panel.TabIndex = 28;
            // 
            // ekwipunek_label
            // 
            this.ekwipunek_label.AutoSize = true;
            this.ekwipunek_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold);
            this.ekwipunek_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.ekwipunek_label.Location = new System.Drawing.Point(83, 136);
            this.ekwipunek_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ekwipunek_label.Name = "ekwipunek_label";
            this.ekwipunek_label.Size = new System.Drawing.Size(154, 36);
            this.ekwipunek_label.TabIndex = 0;
            this.ekwipunek_label.Text = "Ewipunek";
            // 
            // statystyki_label
            // 
            this.statystyki_label.AutoSize = true;
            this.statystyki_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold);
            this.statystyki_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.statystyki_label.Location = new System.Drawing.Point(884, 127);
            this.statystyki_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.statystyki_label.Name = "statystyki_label";
            this.statystyki_label.Size = new System.Drawing.Size(152, 36);
            this.statystyki_label.TabIndex = 29;
            this.statystyki_label.Text = "Statystyki";
            // 
            // uzycie
            // 
            this.uzycie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.uzycie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uzycie.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold);
            this.uzycie.Location = new System.Drawing.Point(83, 605);
            this.uzycie.Margin = new System.Windows.Forms.Padding(2);
            this.uzycie.Name = "uzycie";
            this.uzycie.Size = new System.Drawing.Size(187, 74);
            this.uzycie.TabIndex = 30;
            this.uzycie.Text = "Użyj";
            this.uzycie.UseVisualStyleBackColor = false;
            this.uzycie.Click += new System.EventHandler(this.uzycie_Click);
            // 
            // PlayerPB
            // 
            this.PlayerPB.Location = new System.Drawing.Point(394, 204);
            this.PlayerPB.Name = "PlayerPB";
            this.PlayerPB.Size = new System.Drawing.Size(284, 351);
            this.PlayerPB.TabIndex = 31;
            this.PlayerPB.TabStop = false;
            // 
            // EquippedArmor
            // 
            this.EquippedArmor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(39)))), ((int)(((byte)(28)))));
            this.EquippedArmor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.EquippedArmor.Location = new System.Drawing.Point(516, 347);
            this.EquippedArmor.MultiSelect = false;
            this.EquippedArmor.Name = "EquippedArmor";
            this.EquippedArmor.Scrollable = false;
            this.EquippedArmor.Size = new System.Drawing.Size(50, 50);
            this.EquippedArmor.SmallImageList = this.imageList1;
            this.EquippedArmor.TabIndex = 34;
            this.EquippedArmor.UseCompatibleStateImageBehavior = false;
            this.EquippedArmor.View = System.Windows.Forms.View.SmallIcon;
            this.EquippedArmor.SelectedIndexChanged += new System.EventHandler(this.EquippedArmor_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(50, 50);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // EquippedWeapon
            // 
            this.EquippedWeapon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(39)))), ((int)(((byte)(28)))));
            this.EquippedWeapon.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.EquippedWeapon.Location = new System.Drawing.Point(595, 405);
            this.EquippedWeapon.MultiSelect = false;
            this.EquippedWeapon.Name = "EquippedWeapon";
            this.EquippedWeapon.Scrollable = false;
            this.EquippedWeapon.Size = new System.Drawing.Size(50, 50);
            this.EquippedWeapon.SmallImageList = this.imageList2;
            this.EquippedWeapon.TabIndex = 35;
            this.EquippedWeapon.UseCompatibleStateImageBehavior = false;
            this.EquippedWeapon.View = System.Windows.Forms.View.SmallIcon;
            this.EquippedWeapon.SelectedIndexChanged += new System.EventHandler(this.EquippedWeapon_SelectedIndexChanged);
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(50, 50);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // zdjecie
            // 
            this.zdjecie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.zdjecie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zdjecie.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold);
            this.zdjecie.Location = new System.Drawing.Point(458, 605);
            this.zdjecie.Margin = new System.Windows.Forms.Padding(2);
            this.zdjecie.Name = "zdjecie";
            this.zdjecie.Size = new System.Drawing.Size(187, 74);
            this.zdjecie.TabIndex = 36;
            this.zdjecie.Text = "Zdejmij";
            this.zdjecie.UseVisualStyleBackColor = false;
            this.zdjecie.Click += new System.EventHandler(this.zdjecie_Click);
            // 
            // Equipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(39)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1200, 731);
            this.ControlBox = false;
            this.Controls.Add(this.zdjecie);
            this.Controls.Add(this.EquippedWeapon);
            this.Controls.Add(this.EquippedArmor);
            this.Controls.Add(this.PlayerPB);
            this.Controls.Add(this.uzycie);
            this.Controls.Add(this.statystyki_label);
            this.Controls.Add(this.ekwipunek_label);
            this.Controls.Add(this.obramowanie_panel);
            this.Controls.Add(this.Exp);
            this.Controls.Add(this.bohaterExp);
            this.Controls.Add(this.ukosnik2);
            this.Controls.Add(this.ukosnik1);
            this.Controls.Add(this.bohaterHPMax);
            this.Controls.Add(this.bohaterMPMax);
            this.Controls.Add(this.MP);
            this.Controls.Add(this.PunktyD);
            this.Controls.Add(this.bohaterZloto);
            this.Controls.Add(this.bohaterInteligencja);
            this.Controls.Add(this.bohaterZrecznosc);
            this.Controls.Add(this.bohaterSila);
            this.Controls.Add(this.bohaterPunktyD);
            this.Controls.Add(this.bohaterMP);
            this.Controls.Add(this.bohaterHP);
            this.Controls.Add(this.bohaterLevel);
            this.Controls.Add(this.HP);
            this.Controls.Add(this.Inteligencja);
            this.Controls.Add(this.Zrecznosc);
            this.Controls.Add(this.Sila);
            this.Controls.Add(this.Zloto);
            this.Controls.Add(this.Level);
            this.Controls.Add(this.bohaterImie);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1200, 731);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1200, 731);
            this.Name = "Equipment";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ekwipunek";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label bohaterImie;
        private System.Windows.Forms.Label Level;
        private System.Windows.Forms.Label Zloto;
        private System.Windows.Forms.Label Sila;
        private System.Windows.Forms.Label Zrecznosc;
        private System.Windows.Forms.Label Inteligencja;
        private System.Windows.Forms.Label HP;
        private System.Windows.Forms.Label MP;
        private System.Windows.Forms.Label PunktyD;
        private System.Windows.Forms.Label bohaterLevel;
        private System.Windows.Forms.Label bohaterHP;
        private System.Windows.Forms.Label bohaterMP;
        private System.Windows.Forms.Label bohaterPunktyD;
        private System.Windows.Forms.Label bohaterSila;
        private System.Windows.Forms.Label bohaterZrecznosc;
        private System.Windows.Forms.Label bohaterInteligencja;
        private System.Windows.Forms.Label bohaterZloto;
        private System.Windows.Forms.Label bohaterMPMax;
        private System.Windows.Forms.Label bohaterHPMax;
        private System.Windows.Forms.Label ukosnik1;
        private System.Windows.Forms.Label ukosnik2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar bohaterExp;
        private System.Windows.Forms.Label Exp;
        private System.Windows.Forms.Panel obramowanie_panel;
        private System.Windows.Forms.Label ekwipunek_label;
        private System.Windows.Forms.Label statystyki_label;
        private System.Windows.Forms.Button uzycie;
        private System.Windows.Forms.PictureBox PlayerPB;
        private System.Windows.Forms.ListView EquippedArmor;
        private System.Windows.Forms.ListView EquippedWeapon;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button zdjecie;
        private System.Windows.Forms.ImageList imageList2;
    }
}

