using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ten_Thousand
{
    class Game
    {
        private Player[] players;
        private int currentPlayer;
        private Random generator;
        private bool[] rollable;
        private bool[] scorable;
        private int[] dieValue;
        private int[][] sets;
        private int currentTurnScore;

        public Game(string[] names)
        {
            players = new Player[names.Length];
            for (int i = 0; i < names.Length; i++)
                players[i] = new Player(names[i]);
            rollable = new bool[] { true, true, true, true, true };
            scorable = new bool[5];
            dieValue = new int[5];
            currentPlayer = 0;
            generator = new Random();
            sets = new int[7][];
        }

        /// <summary>
        /// Returns the current players name and score
        /// </summary>
        /// <returns>Array in which first item is player name and second item it player score</returns>
        public string[] currentPlayerInfo()
        {
            return new string[] { players[currentPlayer].getName(), Convert.ToString(players[currentPlayer].getScore()) };
        }

        /// <summary>
        /// Randomly sets the values of the rollable die
        /// </summary>
        public void rollEm()
        {
            for (int i = 0; i < dieValue.Length; i++)
                if (rollable[i])
                    dieValue[i] = generator.Next(6) + 1;
            checkScorable();
        }

        /// <summary>
        /// Figures out which die are scoreable and sets the values in the array scorable
        /// </summary>
        private void checkScorable()
        {
            //Reset the scorable array
            scorable = new bool[5];

            //If the number is 1 or 5, the number is always scorable
            for (int i = 0; i < dieValue.Length; i++)
                if (dieValue[i] == 5 || dieValue[i] == 1)
                    scorable[i] = true;


            List<int> tempLocations;
            for (int i = 2; i < 7; i++)//One iteration for each possible die value (except 1, it does 5 to handle null exception)
            {
                tempLocations = new List<int>();
                for (int die = 0; die < dieValue.Length; die++) // One iteration for each die
                    if (dieValue[die] == i) //If the die is equal to the value we are checking for thi iteration, add the die location to teh array
                        tempLocations.Add(die);

                sets[i] = tempLocations.ToArray(); // Add the array to the sets array
            }

            for (int i = 2; i < sets.Length; i++) //One iteration for each possible die value
                if (sets[i].Length > 2) //If there are 3 or more of that value in the die...
                    foreach (int location in sets[i]) //Go through each of the locations where that value occurs
                        scorable[location] = true; //Set that location's scorable status to true

        }

        /// <summary>
        /// Toggles the status of die at die Number if it is scorable
        /// </summary>
        /// <param name="dieNumber">The die to toggle</param>
        public void dieClick(int dieNumber)
        {
            if (scorable[dieNumber])
            {
                if (dieValue[dieNumber] == 1 || dieValue[dieNumber] == 5)
                    rollable[dieNumber] = !rollable[dieNumber];
                else
                    foreach (int location in sets[dieValue[dieNumber]]) //Go through each of the locations where that value occurs
                        rollable[location] = !rollable[location]; //Toggle that location's rollable status
            }
        }

        /// <summary>
        /// Returns an array of bool, indicating which are rollable
        /// </summary>
        /// <returns>Array of booleans indicating which are rollable</returns>
        public bool[] getRollable()
        {
            return rollable;
        }

        /// <summary>
        /// Returns and array of int, indicating the values of the die
        /// </summary>
        /// <returns>An array of ints indicating the values of the die</returns>
        public int[] getDieValues()
        {
            return dieValue;
        }

        private int calculateScore()
        {
            return 0;
        }
    }
}
