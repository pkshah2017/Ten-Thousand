namespace Ten_Thousand
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dieImageOne = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CurtPlyTurnScore = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.curtPlyTotScore = new System.Windows.Forms.Label();
            this.curtPlyName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.endTurnBtn = new System.Windows.Forms.Button();
            this.rollEm = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "die1.png");
            this.imageList1.Images.SetKeyName(1, "die2.png");
            this.imageList1.Images.SetKeyName(2, "die3.png");
            this.imageList1.Images.SetKeyName(3, "die4.png");
            this.imageList1.Images.SetKeyName(4, "die5.png");
            this.imageList1.Images.SetKeyName(5, "die6.png");
            this.imageList1.Images.SetKeyName(6, "die1s.png");
            this.imageList1.Images.SetKeyName(7, "die2s.png");
            this.imageList1.Images.SetKeyName(8, "die3s.png");
            this.imageList1.Images.SetKeyName(9, "die4s.png");
            this.imageList1.Images.SetKeyName(10, "die5s.png");
            this.imageList1.Images.SetKeyName(11, "die6s.png");
            // 
            // dieImageOne
            // 
            this.dieImageOne.Image = global::Ten_Thousand.Properties.Resources.die1;
            this.dieImageOne.Location = new System.Drawing.Point(25, 38);
            this.dieImageOne.Name = "dieImageOne";
            this.dieImageOne.Size = new System.Drawing.Size(80, 80);
            this.dieImageOne.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(468, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(125, 26);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // CurtPlyTurnScore
            // 
            this.CurtPlyTurnScore.Location = new System.Drawing.Point(163, 120);
            this.CurtPlyTurnScore.Name = "CurtPlyTurnScore";
            this.CurtPlyTurnScore.Size = new System.Drawing.Size(131, 28);
            this.CurtPlyTurnScore.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 24);
            this.label5.TabIndex = 2;
            this.label5.Text = "Turn Score:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 24);
            this.label6.TabIndex = 1;
            this.label6.Text = "Total Score:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "Current Player:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CurtPlyTurnScore);
            this.groupBox2.Controls.Add(this.curtPlyTotScore);
            this.groupBox2.Controls.Add(this.curtPlyName);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.groupBox2.Location = new System.Drawing.Point(20, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 174);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Turn Info";
            // 
            // curtPlyTotScore
            // 
            this.curtPlyTotScore.Location = new System.Drawing.Point(163, 79);
            this.curtPlyTotScore.Name = "curtPlyTotScore";
            this.curtPlyTotScore.Size = new System.Drawing.Size(131, 28);
            this.curtPlyTotScore.TabIndex = 5;
            // 
            // curtPlyName
            // 
            this.curtPlyName.Location = new System.Drawing.Point(163, 39);
            this.curtPlyName.Name = "curtPlyName";
            this.curtPlyName.Size = new System.Drawing.Size(131, 28);
            this.curtPlyName.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(163, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 24);
            this.label8.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.groupBox1.Location = new System.Drawing.Point(20, 290);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 162);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scoreboard";
            // 
            // endTurnBtn
            // 
            this.endTurnBtn.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.endTurnBtn.Location = new System.Drawing.Point(341, 337);
            this.endTurnBtn.Name = "endTurnBtn";
            this.endTurnBtn.Size = new System.Drawing.Size(110, 86);
            this.endTurnBtn.TabIndex = 12;
            this.endTurnBtn.Text = "End Turn";
            this.endTurnBtn.UseVisualStyleBackColor = true;
            // 
            // rollEm
            // 
            this.rollEm.Enabled = false;
            this.rollEm.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.rollEm.Location = new System.Drawing.Point(341, 161);
            this.rollEm.Name = "rollEm";
            this.rollEm.Size = new System.Drawing.Size(110, 89);
            this.rollEm.TabIndex = 11;
            this.rollEm.Text = "Roll \'Em";
            this.rollEm.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Image = global::Ten_Thousand.Properties.Resources.die1;
            this.label9.Location = new System.Drawing.Point(111, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 80);
            this.label9.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Image = global::Ten_Thousand.Properties.Resources.die1;
            this.label1.Location = new System.Drawing.Point(197, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 80);
            this.label1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Image = global::Ten_Thousand.Properties.Resources.die1;
            this.label2.Location = new System.Drawing.Point(283, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 80);
            this.label2.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.Image = global::Ten_Thousand.Properties.Resources.die1;
            this.label3.Location = new System.Drawing.Point(369, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 80);
            this.label3.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 463);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.endTurnBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.rollEm);
            this.Controls.Add(this.dieImageOne);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Ten Thousand";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label dieImageOne;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label CurtPlyTurnScore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label curtPlyTotScore;
        private System.Windows.Forms.Label curtPlyName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button endTurnBtn;
        private System.Windows.Forms.Button rollEm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

