using System;
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
        }

        private void updateCurrentPlayerInfo()
        {
            string[] playerInfo = game.currentPlayerInfo();
            curtPlyName.Text = playerInfo[0];
            curtPlyTotScore.Text = playerInfo[1];
            CurtPlyTurnScore.Text = playerInfo[2];
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
        }
    }
}
