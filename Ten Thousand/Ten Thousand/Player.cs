using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ten_Thousand
{
    class Player
    {
        private int score;
        private string name;

        public Player(string playerName)
        {
            score = 0;
            name = playerName;
        }

        /// <summary>
        /// Returns player name
        /// </summary>
        /// <returns>Player name</returns>
        public string getName()
        {
            return name;
        }

        /// <summary>
        /// Returns Player score
        /// </summary>
        /// <returns>Player Score</returns>
        public int getScore()
        {
            return score;
        }

        /// <summary>
        /// Sets the player score to a certain value
        /// </summary>
        /// <param name="newScore">The player's new score</param>
        public void setScore(int newScore)
        {
            score = newScore;
        }

        /// <summary>
        /// Adds a value to the players current score
        /// </summary>
        /// <param name="value">Value to add to score</param>
        public void addScore(int value)
        {
            score += value;
        }
    }
}
