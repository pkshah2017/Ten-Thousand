﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ten_Thousand
{
    public partial class Form1 : Form
    {
        private Game game;
        private Label[] dieImageLabels;
        private Bitmap[] redImages;
        private Bitmap[] whiteImages;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame loader = new NewGame();
            loader.ShowDialog();

            game = new Game(loader.names);
            rollEm.Enabled = true;
            dieImageLabels = new Label[] { dieImageOne, dieImageTwo, dieImageThree, dieImageFour, dieImageFive };
            redImages = new Bitmap[] { Ten_Thousand.Properties.Resources.die1 , Ten_Thousand.Properties.Resources.die2,
                Ten_Thousand.Properties.Resources.die3,Ten_Thousand.Properties.Resources.die4,Ten_Thousand.Properties.Resources.die5,
                Ten_Thousand.Properties.Resources.die6};
            whiteImages = new Bitmap[] {Ten_Thousand.Properties.Resources.die1s, Ten_Thousand.Properties.Resources.die2s, Ten_Thousand.Properties.Resources.die3s,
                Ten_Thousand.Properties.Resources.die4s,Ten_Thousand.Properties.Resources.die5s,Ten_Thousand.Properties.Resources.die6s};
            updateCurrentPlayerInfo();
            rollEm.PerformClick();
        }

        private void updateCurrentPlayerInfo()
        {
            string[] playerInfo = game.currentPlayerInfo();
            curtPlyName.Text = playerInfo[0];
            curtPlyTotScore.Text = playerInfo[1];
            CurtPlyTurnScore.Text = playerInfo[2];
            Dictionary<string, int> playerScores = game.getScores();
            string scoreboardText = "";
            foreach (KeyValuePair<string, int> kvp in playerScores)
                scoreboardText += kvp.Value + "\t:\t" + kvp.Key + "\r\n";
            scoreBoardLbl.Text = scoreboardText;

        }

        private void updateDieImages()
        {
            bool[] status = game.getRollable();
            int[] values = game.getDieValues();
            for (int i = 0; i < dieImageLabels.Length; i++)
            {
                dieImageLabels[i].Image = status[i] ? redImages[values[i] - 1] : whiteImages[values[i] - 1];
            }
        }
        
        private void rollEm_Click(object sender, EventArgs e)
        {
            game.rollEm();
            updateCurrentPlayerInfo();
            updateDieImages();
            //rollEm.Enabled = game.getAvaialableMove();
            rollEm.Enabled = false;
        }

        private void dieImageOne_Click(object sender, EventArgs e)
        {
            dieClick(0);
        }

        private void dieImageTwo_Click(object sender, EventArgs e)
        {
            dieClick(1);
        }

        private void dieImageThree_Click(object sender, EventArgs e)
        {
            dieClick(2);
        }

        private void dieImageFour_Click(object sender, EventArgs e)
        {
            dieClick(3);
        }

        private void dieImageFive_Click(object sender, EventArgs e)
        {
            dieClick(4);
        }

        private void endTurnBtn_Click(object sender, EventArgs e)
        {
            game.endTurn();
            updateCurrentPlayerInfo();
            updateDieImages();
            rollEm.Enabled = true;            
        }

        private void dieClick(int die)
        {
            if (game != null)
            {
                bool successful = game.dieClick(die);
                if (successful)
                    rollEm.Enabled = true;
                updateDieImages();
                updateCurrentPlayerInfo();
            }
        }
    }
}
