namespace Gra
{
    partial class Dialog
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PlayerPB = new System.Windows.Forms.PictureBox();
            this.NPCPB = new System.Windows.Forms.PictureBox();
            this.PlayerName = new System.Windows.Forms.Label();
            this.NPCName = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NPCPB)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel1.Controls.Add(this.PlayerPB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.NPCPB, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.PlayerName, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.NPCName, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1280, 270);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // PlayerPB
            // 
            this.PlayerPB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerPB.Location = new System.Drawing.Point(12, 6);
            this.PlayerPB.Margin = new System.Windows.Forms.Padding(0);
            this.PlayerPB.Name = "PlayerPB";
            this.PlayerPB.Size = new System.Drawing.Size(192, 195);
            this.PlayerPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PlayerPB.TabIndex = 0;
            this.PlayerPB.TabStop = false;
            // 
            // NPCPB
            // 
            this.NPCPB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NPCPB.Location = new System.Drawing.Point(1072, 6);
            this.NPCPB.Margin = new System.Windows.Forms.Padding(0);
            this.NPCPB.Name = "NPCPB";
            this.NPCPB.Size = new System.Drawing.Size(192, 195);
            this.NPCPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.NPCPB.TabIndex = 1;
            this.NPCPB.TabStop = false;
            // 
            // PlayerName
            // 
            this.PlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerName.AutoSize = true;
            this.PlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold);
            this.PlayerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.PlayerName.Location = new System.Drawing.Point(15, 207);
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.Size = new System.Drawing.Size(186, 54);
            this.PlayerName.TabIndex = 2;
            this.PlayerName.Text = "PlayerName";
            this.PlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PlayerName.SizeChanged += new System.EventHandler(this.PlayerName_SizeChanged);
            // 
            // NPCName
            // 
            this.NPCName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NPCName.AutoSize = true;
            this.NPCName.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold);
            this.NPCName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.NPCName.Location = new System.Drawing.Point(1075, 207);
            this.NPCName.Name = "NPCName";
            this.NPCName.Size = new System.Drawing.Size(186, 54);
            this.NPCName.TabIndex = 3;
            this.NPCName.Text = "NPCName";
            this.NPCName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NPCName.SizeChanged += new System.EventHandler(this.NPCName_SizeChanged);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(143)))), ((int)(((byte)(65)))));
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.textBox1.Location = new System.Drawing.Point(216, 6);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.textBox1, 3);
            this.textBox1.Size = new System.Drawing.Size(844, 255);
            this.textBox1.TabIndex = 4;
            this.textBox1.TabStop = false;
            this.textBox1.SizeChanged += new System.EventHandler(this.textBox1_SizeChanged);
            // 
            // Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(39)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1280, 270);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Dialog";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Dialog_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NPCPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox PlayerPB;
        private System.Windows.Forms.PictureBox NPCPB;
        private System.Windows.Forms.Label PlayerName;
        private System.Windows.Forms.Label NPCName;
        private System.Windows.Forms.TextBox textBox1;
    }
}