namespace cgarzaCS3020Project
{
    partial class GameInterface
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameInterface));
            panel1 = new Panel();
            enemy2 = new PictureBox();
            enemy1 = new PictureBox();
            enemy3 = new PictureBox();
            clericBox = new PictureBox();
            warriorBox = new PictureBox();
            mageBox = new PictureBox();
            menuStrip1 = new MenuStrip();
            gameToolStripMenuItem = new ToolStripMenuItem();
            restartToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            statsToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            instructionsToolStripMenuItem = new ToolStripMenuItem();
            madeByToolStripMenuItem = new ToolStripMenuItem();
            actionTextbox = new RichTextBox();
            groupBox1 = new GroupBox();
            endTurnButton = new Button();
            healButton = new Button();
            defendButton = new Button();
            attackButton = new Button();
            groupBox2 = new GroupBox();
            partyTextbox = new RichTextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)enemy2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)enemy1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)enemy3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clericBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)warriorBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mageBox).BeginInit();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(enemy2);
            panel1.Controls.Add(enemy1);
            panel1.Controls.Add(enemy3);
            panel1.Controls.Add(clericBox);
            panel1.Controls.Add(warriorBox);
            panel1.Controls.Add(mageBox);
            panel1.Location = new Point(27, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(740, 247);
            panel1.TabIndex = 0;
            // 
            // enemy2
            // 
            enemy2.BackColor = Color.Transparent;
            enemy2.Enabled = false;
            enemy2.Location = new Point(661, 26);
            enemy2.Name = "enemy2";
            enemy2.Size = new Size(60, 60);
            enemy2.TabIndex = 7;
            enemy2.TabStop = false;
            enemy2.Click += enemyPictureBox_Click;
            // 
            // enemy1
            // 
            enemy1.BackColor = Color.Transparent;
            enemy1.Enabled = false;
            enemy1.Location = new Point(573, 98);
            enemy1.Name = "enemy1";
            enemy1.Size = new Size(60, 60);
            enemy1.TabIndex = 6;
            enemy1.TabStop = false;
            enemy1.Click += enemyPictureBox_Click;
            // 
            // enemy3
            // 
            enemy3.BackColor = Color.Transparent;
            enemy3.Enabled = false;
            enemy3.Location = new Point(647, 167);
            enemy3.Name = "enemy3";
            enemy3.Size = new Size(60, 60);
            enemy3.TabIndex = 5;
            enemy3.TabStop = false;
            enemy3.Click += enemyPictureBox_Click;
            // 
            // clericBox
            // 
            clericBox.BackColor = Color.Transparent;
            clericBox.Image = (Image)resources.GetObject("clericBox.Image");
            clericBox.Location = new Point(40, 26);
            clericBox.Name = "clericBox";
            clericBox.Size = new Size(60, 60);
            clericBox.TabIndex = 4;
            clericBox.TabStop = false;
            clericBox.Click += pictureBox_Click;
            // 
            // warriorBox
            // 
            warriorBox.BackColor = Color.Transparent;
            warriorBox.Image = (Image)resources.GetObject("warriorBox.Image");
            warriorBox.Location = new Point(125, 86);
            warriorBox.Name = "warriorBox";
            warriorBox.Size = new Size(60, 60);
            warriorBox.TabIndex = 3;
            warriorBox.TabStop = false;
            warriorBox.Click += pictureBox_Click;
            // 
            // mageBox
            // 
            mageBox.BackColor = Color.Transparent;
            mageBox.Image = (Image)resources.GetObject("mageBox.Image");
            mageBox.Location = new Point(38, 147);
            mageBox.Name = "mageBox";
            mageBox.Size = new Size(60, 60);
            mageBox.TabIndex = 2;
            mageBox.TabStop = false;
            mageBox.Click += pictureBox_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Anchor = AnchorStyles.Top;
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { gameToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(27, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(275, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            gameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { restartToolStripMenuItem, exitToolStripMenuItem, statsToolStripMenuItem });
            gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            gameToolStripMenuItem.Size = new Size(62, 24);
            gameToolStripMenuItem.Text = "Game";
            // 
            // restartToolStripMenuItem
            // 
            restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            restartToolStripMenuItem.Size = new Size(224, 26);
            restartToolStripMenuItem.Text = "Restart";
            restartToolStripMenuItem.Click += restartToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(224, 26);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // statsToolStripMenuItem
            // 
            statsToolStripMenuItem.Name = "statsToolStripMenuItem";
            statsToolStripMenuItem.Size = new Size(224, 26);
            statsToolStripMenuItem.Text = "Stats";
            statsToolStripMenuItem.Click += statsToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { instructionsToolStripMenuItem, madeByToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(55, 24);
            helpToolStripMenuItem.Text = "Help";
            // 
            // instructionsToolStripMenuItem
            // 
            instructionsToolStripMenuItem.Name = "instructionsToolStripMenuItem";
            instructionsToolStripMenuItem.Size = new Size(167, 26);
            instructionsToolStripMenuItem.Text = "Instructions";
            instructionsToolStripMenuItem.Click += instructionsToolStripMenuItem_Click;
            // 
            // madeByToolStripMenuItem
            // 
            madeByToolStripMenuItem.Name = "madeByToolStripMenuItem";
            madeByToolStripMenuItem.Size = new Size(167, 26);
            madeByToolStripMenuItem.Text = "Developer";
            madeByToolStripMenuItem.Click += madeByToolStripMenuItem_Click;
            // 
            // actionTextbox
            // 
            actionTextbox.BorderStyle = BorderStyle.FixedSingle;
            actionTextbox.Location = new Point(519, 291);
            actionTextbox.Name = "actionTextbox";
            actionTextbox.ReadOnly = true;
            actionTextbox.ScrollBars = RichTextBoxScrollBars.Vertical;
            actionTextbox.Size = new Size(248, 147);
            actionTextbox.TabIndex = 3;
            actionTextbox.Text = "";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(endTurnButton);
            groupBox1.Controls.Add(healButton);
            groupBox1.Controls.Add(defendButton);
            groupBox1.Controls.Add(attackButton);
            groupBox1.Location = new Point(27, 281);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(239, 157);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Actions:";
            // 
            // endTurnButton
            // 
            endTurnButton.Location = new Point(6, 123);
            endTurnButton.Name = "endTurnButton";
            endTurnButton.Size = new Size(227, 28);
            endTurnButton.TabIndex = 8;
            endTurnButton.Text = "End Turn";
            endTurnButton.UseVisualStyleBackColor = true;
            endTurnButton.Click += action_Click;
            // 
            // healButton
            // 
            healButton.Enabled = false;
            healButton.Location = new Point(6, 90);
            healButton.Name = "healButton";
            healButton.Size = new Size(227, 27);
            healButton.TabIndex = 7;
            healButton.Text = "Heal";
            healButton.UseVisualStyleBackColor = true;
            healButton.Click += action_Click;
            // 
            // defendButton
            // 
            defendButton.Enabled = false;
            defendButton.Location = new Point(6, 56);
            defendButton.Name = "defendButton";
            defendButton.Size = new Size(227, 28);
            defendButton.TabIndex = 6;
            defendButton.Text = "Defend";
            defendButton.UseVisualStyleBackColor = true;
            defendButton.Click += action_Click;
            // 
            // attackButton
            // 
            attackButton.Enabled = false;
            attackButton.Location = new Point(6, 23);
            attackButton.Name = "attackButton";
            attackButton.Size = new Size(227, 27);
            attackButton.TabIndex = 5;
            attackButton.Text = "Attack";
            attackButton.UseVisualStyleBackColor = true;
            attackButton.Click += action_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(partyTextbox);
            groupBox2.Location = new Point(272, 281);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(241, 157);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Party Stats:";
            // 
            // partyTextbox
            // 
            partyTextbox.BorderStyle = BorderStyle.None;
            partyTextbox.Location = new Point(6, 23);
            partyTextbox.Name = "partyTextbox";
            partyTextbox.ReadOnly = true;
            partyTextbox.Size = new Size(229, 128);
            partyTextbox.TabIndex = 0;
            partyTextbox.Text = "";
            // 
            // GameInterface
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(actionTextbox);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "GameInterface";
            Text = "Form1";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)enemy2).EndInit();
            ((System.ComponentModel.ISupportInitialize)enemy1).EndInit();
            ((System.ComponentModel.ISupportInitialize)enemy3).EndInit();
            ((System.ComponentModel.ISupportInitialize)clericBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)warriorBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)mageBox).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private RichTextBox actionTextbox;
        private GroupBox groupBox1;
        private Button healButton;
        private Button defendButton;
        private Button attackButton;
        private GroupBox groupBox2;
        private PictureBox enemy2;
        private PictureBox enemy1;
        private PictureBox enemy3;
        private PictureBox clericBox;
        private PictureBox warriorBox;
        private PictureBox mageBox;
        private RichTextBox partyTextbox;
        private Button endTurnButton;
        private ToolStripMenuItem restartToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem statsToolStripMenuItem;
        private ToolStripMenuItem instructionsToolStripMenuItem;
        private ToolStripMenuItem madeByToolStripMenuItem;
    }
}
