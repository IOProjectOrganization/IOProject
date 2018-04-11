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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Font = new System.Drawing.Font("BankGothic Md BT", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 24;
            this.listBox1.Location = new System.Drawing.Point(25, 108);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(527, 696);
            this.listBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("BankGothic Md BT", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(711, 717);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(249, 91);
            this.button1.TabIndex = 1;
            this.button1.Text = "Powrót";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bohaterImie
            // 
            this.bohaterImie.AutoSize = true;
            this.bohaterImie.Font = new System.Drawing.Font("BankGothic Lt BT", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bohaterImie.ForeColor = System.Drawing.Color.White;
            this.bohaterImie.Location = new System.Drawing.Point(1269, 649);
            this.bohaterImie.Name = "bohaterImie";
            this.bohaterImie.Size = new System.Drawing.Size(201, 50);
            this.bohaterImie.TabIndex = 2;
            this.bohaterImie.Text = "Godric";
            // 
            // Level
            // 
            this.Level.AutoSize = true;
            this.Level.BackColor = System.Drawing.Color.Transparent;
            this.Level.Font = new System.Drawing.Font("BankGothic Md BT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Level.Location = new System.Drawing.Point(626, 264);
            this.Level.Name = "Level";
            this.Level.Size = new System.Drawing.Size(92, 18);
            this.Level.TabIndex = 3;
            this.Level.Text = "POZIOM";
            // 
            // Zloto
            // 
            this.Zloto.AutoSize = true;
            this.Zloto.Font = new System.Drawing.Font("BankGothic Md BT", 10.2F, System.Drawing.FontStyle.Bold);
            this.Zloto.Location = new System.Drawing.Point(627, 623);
            this.Zloto.Name = "Zloto";
            this.Zloto.Size = new System.Drawing.Size(78, 18);
            this.Zloto.TabIndex = 4;
            this.Zloto.Text = "ZŁOTO";
            // 
            // Sila
            // 
            this.Sila.AutoSize = true;
            this.Sila.Font = new System.Drawing.Font("BankGothic Md BT", 10.2F, System.Drawing.FontStyle.Bold);
            this.Sila.Location = new System.Drawing.Point(626, 467);
            this.Sila.Name = "Sila";
            this.Sila.Size = new System.Drawing.Size(58, 18);
            this.Sila.TabIndex = 6;
            this.Sila.Text = "SIŁA";
            // 
            // Zrecznosc
            // 
            this.Zrecznosc.AutoSize = true;
            this.Zrecznosc.Font = new System.Drawing.Font("BankGothic Md BT", 10.2F, System.Drawing.FontStyle.Bold);
            this.Zrecznosc.Location = new System.Drawing.Point(626, 503);
            this.Zrecznosc.Name = "Zrecznosc";
            this.Zrecznosc.Size = new System.Drawing.Size(129, 18);
            this.Zrecznosc.TabIndex = 7;
            this.Zrecznosc.Text = "ZRĘCZNOŚĆ";
            // 
            // Inteligencja
            // 
            this.Inteligencja.AutoSize = true;
            this.Inteligencja.Font = new System.Drawing.Font("BankGothic Md BT", 10.2F, System.Drawing.FontStyle.Bold);
            this.Inteligencja.Location = new System.Drawing.Point(626, 538);
            this.Inteligencja.Name = "Inteligencja";
            this.Inteligencja.Size = new System.Drawing.Size(166, 18);
            this.Inteligencja.TabIndex = 8;
            this.Inteligencja.Text = "INTELIGENCJA";
            // 
            // HP
            // 
            this.HP.AutoSize = true;
            this.HP.BackColor = System.Drawing.Color.Transparent;
            this.HP.Font = new System.Drawing.Font("BankGothic Md BT", 10.2F, System.Drawing.FontStyle.Bold);
            this.HP.Location = new System.Drawing.Point(627, 296);
            this.HP.Name = "HP";
            this.HP.Size = new System.Drawing.Size(197, 18);
            this.HP.TabIndex = 9;
            this.HP.Text = "PUNKTY ZDROWIA";
            // 
            // MP
            // 
            this.MP.AutoSize = true;
            this.MP.BackColor = System.Drawing.Color.Transparent;
            this.MP.Font = new System.Drawing.Font("BankGothic Md BT", 10.2F, System.Drawing.FontStyle.Bold);
            this.MP.Location = new System.Drawing.Point(626, 331);
            this.MP.Name = "MP";
            this.MP.Size = new System.Drawing.Size(162, 18);
            this.MP.TabIndex = 10;
            this.MP.Text = "PUNKTY MAGII";
            // 
            // PunktyD
            // 
            this.PunktyD.AutoSize = true;
            this.PunktyD.BackColor = System.Drawing.Color.Transparent;
            this.PunktyD.Font = new System.Drawing.Font("BankGothic Md BT", 10.2F, System.Drawing.FontStyle.Bold);
            this.PunktyD.Location = new System.Drawing.Point(626, 368);
            this.PunktyD.Name = "PunktyD";
            this.PunktyD.Size = new System.Drawing.Size(250, 18);
            this.PunktyD.TabIndex = 11;
            this.PunktyD.Text = "PUNKTY UMIEJĘTNOŚCI";
            // 
            // bohaterLevel
            // 
            this.bohaterLevel.Font = new System.Drawing.Font("BankGothic Md BT", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterLevel.Location = new System.Drawing.Point(1070, 264);
            this.bohaterLevel.Name = "bohaterLevel";
            this.bohaterLevel.Size = new System.Drawing.Size(84, 17);
            this.bohaterLevel.TabIndex = 12;
            this.bohaterLevel.Text = "label1";
            this.bohaterLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bohaterHP
            // 
            this.bohaterHP.Font = new System.Drawing.Font("BankGothic Md BT", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterHP.Location = new System.Drawing.Point(962, 297);
            this.bohaterHP.Name = "bohaterHP";
            this.bohaterHP.Size = new System.Drawing.Size(84, 17);
            this.bohaterHP.TabIndex = 13;
            this.bohaterHP.Text = "label2";
            this.bohaterHP.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bohaterMP
            // 
            this.bohaterMP.Font = new System.Drawing.Font("BankGothic Md BT", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterMP.Location = new System.Drawing.Point(962, 331);
            this.bohaterMP.Name = "bohaterMP";
            this.bohaterMP.Size = new System.Drawing.Size(84, 17);
            this.bohaterMP.TabIndex = 14;
            this.bohaterMP.Text = "label3";
            this.bohaterMP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bohaterPunktyD
            // 
            this.bohaterPunktyD.BackColor = System.Drawing.Color.Transparent;
            this.bohaterPunktyD.Font = new System.Drawing.Font("BankGothic Md BT", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterPunktyD.Location = new System.Drawing.Point(1070, 368);
            this.bohaterPunktyD.Name = "bohaterPunktyD";
            this.bohaterPunktyD.Size = new System.Drawing.Size(84, 17);
            this.bohaterPunktyD.TabIndex = 15;
            this.bohaterPunktyD.Text = "label4";
            this.bohaterPunktyD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bohaterSila
            // 
            this.bohaterSila.Font = new System.Drawing.Font("BankGothic Md BT", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterSila.Location = new System.Drawing.Point(1070, 467);
            this.bohaterSila.Name = "bohaterSila";
            this.bohaterSila.Size = new System.Drawing.Size(84, 17);
            this.bohaterSila.TabIndex = 16;
            this.bohaterSila.Text = "label5";
            this.bohaterSila.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bohaterZrecznosc
            // 
            this.bohaterZrecznosc.Font = new System.Drawing.Font("BankGothic Md BT", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterZrecznosc.Location = new System.Drawing.Point(1070, 504);
            this.bohaterZrecznosc.Name = "bohaterZrecznosc";
            this.bohaterZrecznosc.Size = new System.Drawing.Size(84, 17);
            this.bohaterZrecznosc.TabIndex = 17;
            this.bohaterZrecznosc.Text = "label6";
            this.bohaterZrecznosc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bohaterInteligencja
            // 
            this.bohaterInteligencja.Font = new System.Drawing.Font("BankGothic Md BT", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterInteligencja.Location = new System.Drawing.Point(1070, 538);
            this.bohaterInteligencja.Name = "bohaterInteligencja";
            this.bohaterInteligencja.Size = new System.Drawing.Size(84, 17);
            this.bohaterInteligencja.TabIndex = 18;
            this.bohaterInteligencja.Text = "label7";
            this.bohaterInteligencja.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bohaterZloto
            // 
            this.bohaterZloto.BackColor = System.Drawing.Color.Transparent;
            this.bohaterZloto.Font = new System.Drawing.Font("BankGothic Md BT", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterZloto.Location = new System.Drawing.Point(1070, 623);
            this.bohaterZloto.Name = "bohaterZloto";
            this.bohaterZloto.Size = new System.Drawing.Size(84, 17);
            this.bohaterZloto.TabIndex = 19;
            this.bohaterZloto.Text = "label8";
            this.bohaterZloto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bohaterMPMax
            // 
            this.bohaterMPMax.Font = new System.Drawing.Font("BankGothic Md BT", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterMPMax.Location = new System.Drawing.Point(1070, 332);
            this.bohaterMPMax.Name = "bohaterMPMax";
            this.bohaterMPMax.Size = new System.Drawing.Size(82, 18);
            this.bohaterMPMax.TabIndex = 21;
            this.bohaterMPMax.Text = "label1";
            this.bohaterMPMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bohaterHPMax
            // 
            this.bohaterHPMax.Font = new System.Drawing.Font("BankGothic Md BT", 10.2F, System.Drawing.FontStyle.Bold);
            this.bohaterHPMax.Location = new System.Drawing.Point(1070, 296);
            this.bohaterHPMax.Name = "bohaterHPMax";
            this.bohaterHPMax.Size = new System.Drawing.Size(82, 18);
            this.bohaterHPMax.TabIndex = 22;
            this.bohaterHPMax.Text = "label2";
            this.bohaterHPMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ukosnik1
            // 
            this.ukosnik1.AutoSize = true;
            this.ukosnik1.Location = new System.Drawing.Point(1052, 296);
            this.ukosnik1.Name = "ukosnik1";
            this.ukosnik1.Size = new System.Drawing.Size(12, 17);
            this.ukosnik1.TabIndex = 23;
            this.ukosnik1.Text = "/";
            // 
            // ukosnik2
            // 
            this.ukosnik2.AutoSize = true;
            this.ukosnik2.Location = new System.Drawing.Point(1052, 331);
            this.ukosnik2.Name = "ukosnik2";
            this.ukosnik2.Size = new System.Drawing.Size(12, 17);
            this.ukosnik2.TabIndex = 24;
            this.ukosnik2.Text = "/";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.pictureBox1.Location = new System.Drawing.Point(601, 251);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(574, 418);
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // bohaterExp
            // 
            this.bohaterExp.Location = new System.Drawing.Point(960, 420);
            this.bohaterExp.Name = "bohaterExp";
            this.bohaterExp.Size = new System.Drawing.Size(194, 18);
            this.bohaterExp.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.bohaterExp.TabIndex = 26;
            // 
            // Exp
            // 
            this.Exp.AutoSize = true;
            this.Exp.Font = new System.Drawing.Font("BankGothic Md BT", 10.2F, System.Drawing.FontStyle.Bold);
            this.Exp.Location = new System.Drawing.Point(626, 420);
            this.Exp.Name = "Exp";
            this.Exp.Size = new System.Drawing.Size(182, 18);
            this.Exp.TabIndex = 27;
            this.Exp.Text = "DOŚWIADCZENIE";
            // 
            // obramowanie_panel
            // 
            this.obramowanie_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.obramowanie_panel.Location = new System.Drawing.Point(0, 0);
            this.obramowanie_panel.Name = "obramowanie_panel";
            this.obramowanie_panel.Size = new System.Drawing.Size(1600, 45);
            this.obramowanie_panel.TabIndex = 28;
            // 
            // ekwipunek_label
            // 
            this.ekwipunek_label.AutoSize = true;
            this.ekwipunek_label.Font = new System.Drawing.Font("BankGothic Md BT", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ekwipunek_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.ekwipunek_label.Location = new System.Drawing.Point(674, 89);
            this.ekwipunek_label.Name = "ekwipunek_label";
            this.ekwipunek_label.Size = new System.Drawing.Size(252, 35);
            this.ekwipunek_label.TabIndex = 0;
            this.ekwipunek_label.Text = "EKWIPUNEK";
            // 
            // Equipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(39)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.ControlBox = false;
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1600, 900);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1600, 900);
            this.Name = "Equipment";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ekwipunek";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
    }
}

