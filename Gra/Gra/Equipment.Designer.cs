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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerPB)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.listBox1, 3);
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 22;
            this.listBox1.Location = new System.Drawing.Point(33, 221);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(354, 359);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.SizeChanged += new System.EventHandler(this.listBox1_SizeChanged);
            // 
            // button1
            // 
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(903, 622);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 67);
            this.button1.TabIndex = 1;
            this.button1.Text = "Powrót";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.SizeChanged += new System.EventHandler(this.Button_SizeChanged);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bohaterImie
            // 
            this.bohaterImie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bohaterImie.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.bohaterImie, 3);
            this.bohaterImie.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold);
            this.bohaterImie.ForeColor = System.Drawing.Color.White;
            this.bohaterImie.Location = new System.Drawing.Point(452, 583);
            this.bohaterImie.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bohaterImie.Name = "bohaterImie";
            this.bohaterImie.Size = new System.Drawing.Size(296, 36);
            this.bohaterImie.TabIndex = 2;
            this.bohaterImie.Text = "Godric";
            this.bohaterImie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Level
            // 
            this.Level.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Level.AutoSize = true;
            this.Level.BackColor = System.Drawing.Color.Transparent;
            this.Level.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Level.Location = new System.Drawing.Point(11, 0);
            this.Level.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Level.Name = "Level";
            this.Level.Size = new System.Drawing.Size(216, 33);
            this.Level.TabIndex = 3;
            this.Level.Text = "POZIOM";
            this.Level.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Level.SizeChanged += new System.EventHandler(this.Label_SizeChanged);
            // 
            // Zloto
            // 
            this.Zloto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Zloto.AutoSize = true;
            this.Zloto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.Zloto.Location = new System.Drawing.Point(11, 298);
            this.Zloto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Zloto.Name = "Zloto";
            this.Zloto.Size = new System.Drawing.Size(216, 33);
            this.Zloto.TabIndex = 4;
            this.Zloto.Text = "ZŁOTO";
            this.Zloto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Sila
            // 
            this.Sila.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Sila.AutoSize = true;
            this.Sila.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.Sila.Location = new System.Drawing.Point(11, 182);
            this.Sila.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Sila.Name = "Sila";
            this.Sila.Size = new System.Drawing.Size(216, 33);
            this.Sila.TabIndex = 6;
            this.Sila.Text = "SIŁA";
            this.Sila.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Zrecznosc
            // 
            this.Zrecznosc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Zrecznosc.AutoSize = true;
            this.Zrecznosc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.Zrecznosc.Location = new System.Drawing.Point(11, 215);
            this.Zrecznosc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Zrecznosc.Name = "Zrecznosc";
            this.Zrecznosc.Size = new System.Drawing.Size(216, 33);
            this.Zrecznosc.TabIndex = 7;
            this.Zrecznosc.Text = "ZRĘCZNOŚĆ";
            this.Zrecznosc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Inteligencja
            // 
            this.Inteligencja.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Inteligencja.AutoSize = true;
            this.Inteligencja.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.Inteligencja.Location = new System.Drawing.Point(11, 248);
            this.Inteligencja.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Inteligencja.Name = "Inteligencja";
            this.Inteligencja.Size = new System.Drawing.Size(216, 33);
            this.Inteligencja.TabIndex = 8;
            this.Inteligencja.Text = "INTELIGENCJA";
            this.Inteligencja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HP
            // 
            this.HP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HP.AutoSize = true;
            this.HP.BackColor = System.Drawing.Color.Transparent;
            this.HP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.HP.Location = new System.Drawing.Point(11, 33);
            this.HP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.HP.Name = "HP";
            this.HP.Size = new System.Drawing.Size(216, 33);
            this.HP.TabIndex = 9;
            this.HP.Text = "PUNKTY ZDROWIA";
            this.HP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MP
            // 
            this.MP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MP.AutoSize = true;
            this.MP.BackColor = System.Drawing.Color.Transparent;
            this.MP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.MP.Location = new System.Drawing.Point(11, 66);
            this.MP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MP.Name = "MP";
            this.MP.Size = new System.Drawing.Size(216, 33);
            this.MP.TabIndex = 10;
            this.MP.Text = "PUNKTY MAGII";
            this.MP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PunktyD
            // 
            this.PunktyD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PunktyD.AutoSize = true;
            this.PunktyD.BackColor = System.Drawing.Color.Transparent;
            this.PunktyD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.PunktyD.Location = new System.Drawing.Point(11, 99);
            this.PunktyD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PunktyD.Name = "PunktyD";
            this.PunktyD.Size = new System.Drawing.Size(216, 33);
            this.PunktyD.TabIndex = 11;
            this.PunktyD.Text = "PUNKTY UMIEJĘTNOŚCI";
            this.PunktyD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bohaterLevel
            // 
            this.bohaterLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bohaterLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterLevel.Location = new System.Drawing.Point(326, 0);
            this.bohaterLevel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bohaterLevel.Name = "bohaterLevel";
            this.bohaterLevel.Size = new System.Drawing.Size(44, 33);
            this.bohaterLevel.TabIndex = 12;
            this.bohaterLevel.Text = "label1";
            this.bohaterLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bohaterHP
            // 
            this.bohaterHP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bohaterHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterHP.Location = new System.Drawing.Point(259, 33);
            this.bohaterHP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bohaterHP.Name = "bohaterHP";
            this.bohaterHP.Size = new System.Drawing.Size(44, 33);
            this.bohaterHP.TabIndex = 13;
            this.bohaterHP.Text = "label2";
            this.bohaterHP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bohaterMP
            // 
            this.bohaterMP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bohaterMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterMP.Location = new System.Drawing.Point(259, 66);
            this.bohaterMP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bohaterMP.Name = "bohaterMP";
            this.bohaterMP.Size = new System.Drawing.Size(44, 33);
            this.bohaterMP.TabIndex = 14;
            this.bohaterMP.Text = "label3";
            this.bohaterMP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bohaterPunktyD
            // 
            this.bohaterPunktyD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bohaterPunktyD.BackColor = System.Drawing.Color.Transparent;
            this.bohaterPunktyD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterPunktyD.Location = new System.Drawing.Point(326, 99);
            this.bohaterPunktyD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bohaterPunktyD.Name = "bohaterPunktyD";
            this.bohaterPunktyD.Size = new System.Drawing.Size(44, 33);
            this.bohaterPunktyD.TabIndex = 15;
            this.bohaterPunktyD.Text = "label4";
            this.bohaterPunktyD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bohaterSila
            // 
            this.bohaterSila.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bohaterSila.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterSila.Location = new System.Drawing.Point(326, 182);
            this.bohaterSila.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bohaterSila.Name = "bohaterSila";
            this.bohaterSila.Size = new System.Drawing.Size(44, 33);
            this.bohaterSila.TabIndex = 16;
            this.bohaterSila.Text = "label5";
            this.bohaterSila.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bohaterZrecznosc
            // 
            this.bohaterZrecznosc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bohaterZrecznosc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterZrecznosc.Location = new System.Drawing.Point(326, 215);
            this.bohaterZrecznosc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bohaterZrecznosc.Name = "bohaterZrecznosc";
            this.bohaterZrecznosc.Size = new System.Drawing.Size(44, 33);
            this.bohaterZrecznosc.TabIndex = 17;
            this.bohaterZrecznosc.Text = "label6";
            this.bohaterZrecznosc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bohaterInteligencja
            // 
            this.bohaterInteligencja.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bohaterInteligencja.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterInteligencja.Location = new System.Drawing.Point(326, 248);
            this.bohaterInteligencja.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bohaterInteligencja.Name = "bohaterInteligencja";
            this.bohaterInteligencja.Size = new System.Drawing.Size(44, 33);
            this.bohaterInteligencja.TabIndex = 18;
            this.bohaterInteligencja.Text = "label7";
            this.bohaterInteligencja.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bohaterZloto
            // 
            this.bohaterZloto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bohaterZloto.BackColor = System.Drawing.Color.Transparent;
            this.bohaterZloto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterZloto.Location = new System.Drawing.Point(326, 298);
            this.bohaterZloto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bohaterZloto.Name = "bohaterZloto";
            this.bohaterZloto.Size = new System.Drawing.Size(44, 33);
            this.bohaterZloto.TabIndex = 19;
            this.bohaterZloto.Text = "label8";
            this.bohaterZloto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bohaterMPMax
            // 
            this.bohaterMPMax.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bohaterMPMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterMPMax.Location = new System.Drawing.Point(326, 66);
            this.bohaterMPMax.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bohaterMPMax.Name = "bohaterMPMax";
            this.bohaterMPMax.Size = new System.Drawing.Size(44, 33);
            this.bohaterMPMax.TabIndex = 21;
            this.bohaterMPMax.Text = "label1";
            this.bohaterMPMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bohaterHPMax
            // 
            this.bohaterHPMax.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bohaterHPMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterHPMax.Location = new System.Drawing.Point(326, 33);
            this.bohaterHPMax.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bohaterHPMax.Name = "bohaterHPMax";
            this.bohaterHPMax.Size = new System.Drawing.Size(44, 33);
            this.bohaterHPMax.TabIndex = 22;
            this.bohaterHPMax.Text = "label2";
            this.bohaterHPMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ukosnik1
            // 
            this.ukosnik1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ukosnik1.AutoSize = true;
            this.ukosnik1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.ukosnik1.Location = new System.Drawing.Point(307, 33);
            this.ukosnik1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ukosnik1.Name = "ukosnik1";
            this.ukosnik1.Size = new System.Drawing.Size(15, 33);
            this.ukosnik1.TabIndex = 23;
            this.ukosnik1.Text = "/";
            this.ukosnik1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ukosnik2
            // 
            this.ukosnik2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ukosnik2.AutoSize = true;
            this.ukosnik2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.ukosnik2.Location = new System.Drawing.Point(307, 66);
            this.ukosnik2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ukosnik2.Name = "ukosnik2";
            this.ukosnik2.Size = new System.Drawing.Size(15, 33);
            this.ukosnik2.TabIndex = 24;
            this.ukosnik2.Text = "/";
            this.ukosnik2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bohaterExp
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.bohaterExp, 4);
            this.bohaterExp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bohaterExp.Location = new System.Drawing.Point(240, 134);
            this.bohaterExp.Margin = new System.Windows.Forms.Padding(2);
            this.bohaterExp.Name = "bohaterExp";
            this.bohaterExp.Size = new System.Drawing.Size(130, 29);
            this.bohaterExp.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.bohaterExp.TabIndex = 26;
            // 
            // Exp
            // 
            this.Exp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Exp.AutoSize = true;
            this.Exp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.Exp.Location = new System.Drawing.Point(11, 132);
            this.Exp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Exp.Name = "Exp";
            this.Exp.Size = new System.Drawing.Size(216, 33);
            this.Exp.TabIndex = 27;
            this.Exp.Text = "DOŚWIADCZENIE";
            this.Exp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // obramowanie_panel
            // 
            this.obramowanie_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.tableLayoutPanel1.SetColumnSpan(this.obramowanie_panel, 13);
            this.obramowanie_panel.Location = new System.Drawing.Point(0, 0);
            this.obramowanie_panel.Margin = new System.Windows.Forms.Padding(0);
            this.obramowanie_panel.Name = "obramowanie_panel";
            this.obramowanie_panel.Size = new System.Drawing.Size(1200, 36);
            this.obramowanie_panel.TabIndex = 28;
            // 
            // ekwipunek_label
            // 
            this.ekwipunek_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ekwipunek_label.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.ekwipunek_label, 3);
            this.ekwipunek_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold);
            this.ekwipunek_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.ekwipunek_label.Location = new System.Drawing.Point(32, 109);
            this.ekwipunek_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ekwipunek_label.Name = "ekwipunek_label";
            this.ekwipunek_label.Size = new System.Drawing.Size(356, 73);
            this.ekwipunek_label.TabIndex = 0;
            this.ekwipunek_label.Text = "Ewipunek";
            this.ekwipunek_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statystyki_label
            // 
            this.statystyki_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statystyki_label.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.statystyki_label, 3);
            this.statystyki_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold);
            this.statystyki_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.statystyki_label.Location = new System.Drawing.Point(812, 109);
            this.statystyki_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.statystyki_label.Name = "statystyki_label";
            this.statystyki_label.Size = new System.Drawing.Size(356, 73);
            this.statystyki_label.TabIndex = 29;
            this.statystyki_label.Text = "Statystyki";
            this.statystyki_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uzycie
            // 
            this.uzycie.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uzycie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.uzycie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uzycie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uzycie.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold);
            this.uzycie.Location = new System.Drawing.Point(122, 621);
            this.uzycie.Margin = new System.Windows.Forms.Padding(2);
            this.uzycie.Name = "uzycie";
            this.uzycie.Size = new System.Drawing.Size(176, 69);
            this.uzycie.TabIndex = 30;
            this.uzycie.Text = "Użyj";
            this.uzycie.UseVisualStyleBackColor = false;
            this.uzycie.Click += new System.EventHandler(this.uzycie_Click);
            // 
            // PlayerPB
            // 
            this.PlayerPB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerPB.Location = new System.Drawing.Point(0, 0);
            this.PlayerPB.Name = "PlayerPB";
            this.PlayerPB.Size = new System.Drawing.Size(294, 359);
            this.PlayerPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PlayerPB.TabIndex = 31;
            this.PlayerPB.TabStop = false;
            // 
            // EquippedArmor
            // 
            this.EquippedArmor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(39)))), ((int)(((byte)(28)))));
            this.EquippedArmor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EquippedArmor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EquippedArmor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.EquippedArmor.Location = new System.Drawing.Point(107, 134);
            this.EquippedArmor.MultiSelect = false;
            this.EquippedArmor.Name = "EquippedArmor";
            this.EquippedArmor.Scrollable = false;
            this.EquippedArmor.Size = new System.Drawing.Size(54, 54);
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
            this.EquippedWeapon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EquippedWeapon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EquippedWeapon.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.EquippedWeapon.Location = new System.Drawing.Point(184, 217);
            this.EquippedWeapon.MultiSelect = false;
            this.EquippedWeapon.Name = "EquippedWeapon";
            this.EquippedWeapon.Scrollable = false;
            this.EquippedWeapon.Size = new System.Drawing.Size(54, 54);
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
            this.zdjecie.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.zdjecie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.zdjecie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zdjecie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zdjecie.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold);
            this.zdjecie.Location = new System.Drawing.Point(512, 621);
            this.zdjecie.Margin = new System.Windows.Forms.Padding(2);
            this.zdjecie.Name = "zdjecie";
            this.zdjecie.Size = new System.Drawing.Size(176, 69);
            this.zdjecie.TabIndex = 36;
            this.zdjecie.Text = "Zdejmij";
            this.zdjecie.UseVisualStyleBackColor = false;
            this.zdjecie.Click += new System.EventHandler(this.zdjecie_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 13;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.obramowanie_panel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.zdjecie, 6, 6);
            this.tableLayoutPanel1.Controls.Add(this.listBox1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.ekwipunek_label, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 9, 4);
            this.tableLayoutPanel1.Controls.Add(this.statystyki_label, 9, 2);
            this.tableLayoutPanel1.Controls.Add(this.uzycie, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.button1, 10, 6);
            this.tableLayoutPanel1.Controls.Add(this.bohaterImie, 5, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1200, 731);
            this.tableLayoutPanel1.TabIndex = 37;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 4);
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(813, 221);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 359);
            this.panel1.TabIndex = 38;
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 3);
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Controls.Add(this.PlayerPB);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(453, 221);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(294, 359);
            this.panel2.TabIndex = 38;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Controls.Add(this.EquippedArmor, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.EquippedWeapon, 3, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(294, 359);
            this.tableLayoutPanel2.TabIndex = 36;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 8;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tableLayoutPanel3.Controls.Add(this.Level, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.bohaterMP, 4, 2);
            this.tableLayoutPanel3.Controls.Add(this.ukosnik2, 5, 2);
            this.tableLayoutPanel3.Controls.Add(this.bohaterHP, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.ukosnik1, 5, 1);
            this.tableLayoutPanel3.Controls.Add(this.PunktyD, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.MP, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.bohaterExp, 3, 4);
            this.tableLayoutPanel3.Controls.Add(this.bohaterHPMax, 6, 1);
            this.tableLayoutPanel3.Controls.Add(this.bohaterZloto, 6, 10);
            this.tableLayoutPanel3.Controls.Add(this.bohaterInteligencja, 6, 8);
            this.tableLayoutPanel3.Controls.Add(this.bohaterZrecznosc, 6, 7);
            this.tableLayoutPanel3.Controls.Add(this.bohaterSila, 6, 6);
            this.tableLayoutPanel3.Controls.Add(this.bohaterPunktyD, 6, 3);
            this.tableLayoutPanel3.Controls.Add(this.bohaterMPMax, 6, 2);
            this.tableLayoutPanel3.Controls.Add(this.HP, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.Exp, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.bohaterLevel, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.Sila, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.Zrecznosc, 1, 7);
            this.tableLayoutPanel3.Controls.Add(this.Inteligencja, 1, 8);
            this.tableLayoutPanel3.Controls.Add(this.Zloto, 1, 10);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 12;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.443777F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.443777F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.443777F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.443777F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.443777F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.002001F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.443777F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.443777F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.443777F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.002001F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.443777F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.002001F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(384, 359);
            this.tableLayoutPanel3.TabIndex = 28;
            // 
            // Equipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(39)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1200, 731);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
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
            ((System.ComponentModel.ISupportInitialize)(this.PlayerPB)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}

