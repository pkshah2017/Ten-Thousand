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
        private Die[] Dice;
        private Random generator;
        private int[][] sets;
        private int currentTurnScore;

        public Game(string[] names)
        {
            players = new Player[names.Length];
            for (int i = 0; i < names.Length; i++)
                players[i] = new Player(names[i]);
            Dice = new Die[5] { new Die(), new Die(), new Die(), new Die(), new Die() };
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
            return new string[] { players[currentPlayer].getName(), Convert.ToString(players[currentPlayer].getScore()), Convert.ToString(currentTurnScore) };
        }

        /// <summary>
        /// Returns the score of the current turn
        /// </summary>
        /// <returns>Current Turn Score</returns>
        public int getTurnScore()
        {
            return currentTurnScore;
        }

        /// <summary>
        /// Randomly sets the values of the rollable die
        /// </summary>
        public void rollEm()
        {
            for (int i = 0; i < Dice.Length; i++)
                if (Dice[i].isRollable())
                    Dice[i].SetValue(generator.Next(6) + 1);
                else
                    Dice[i].ageValue();
            checkScorable();
        }

        /// <summary>
        /// Figures out which die are scoreable and sets the values in the array scorable
        /// </summary>
        private void checkScorable()
        {
            //If the number is 1 or 5, the number is always scorable
            for (int i = 0; i < Dice.Length; i++)
                if (Dice[i].GetValue() == 5 || Dice[i].GetValue() == 1)
                    Dice[i].setScorable(true);


            List<int> tempLocations;
            for (int i = 1; i < 7; i++)//One iteration for each possible die value (except 1, it does 5 to handle null exception)
            {
                tempLocations = new List<int>();
                for (int die = 0; die < Dice.Length; die++) // One iteration for each die
                    if (Dice[die].GetValue() == i) //If the die is equal to the value we are checking for this iteration, add the die location to teh array
                        tempLocations.Add(die);

                sets[i] = tempLocations.ToArray(); // Add the array to the sets array
            }

            for (int i = 2; i < sets.Length; i++) //One iteration for each possible die value
                if (sets[i].Length > 2)
                {//If there are 3 or more of that value in the die...
                    //Check if any of them are old values
                    bool allNew = true;
                    foreach (int location in sets[i])
                    {                        
                        if (!Dice[location].isNewValue())
                            allNew = false;
                    }
                    if(allNew)//If all the values are new
                        foreach (int location in sets[i]) //Go through each of the locations where that value occurs
                            Dice[location].setScorable(true); //Set that location's scorable status to true
                    else//If some of the values are new
                        foreach (int location in sets[i]) //Go through each of the locations where that value occurs
                            if(!Dice[location].isNewValue())//Find the locations where the value isn't new
                                Dice[location].setScorable(true); //Set that location's scorable status to true
                }
        }

        /// <summary>
        /// Toggles the status of die at die Number if it is scorable
        /// </summary>
        /// <param name="dieNumber">The die to toggle (first die is 0)</param>
        public void dieClick(int dieNumber)
        {
            if (Dice[dieNumber].isScorable())
            {
                if (Dice[dieNumber].GetValue() == 1 || Dice[dieNumber].GetValue() == 5)
                    Dice[dieNumber].toggleRollable();
                else                
                    foreach (int location in sets[Dice[dieNumber].GetValue()]) //Go through each of the locations where that value occurs
                        if (Dice[location].isScorable())//Make sure that Dice is scorable
                            Dice[location].toggleRollable();//Toggle that location's rollable status
                
            }
            calculateScore();
        }

        
        /// <summary>
        /// Returns an array of bool, indicating which are rollable
        /// </summary>
        /// <returns>Array of booleans indicating which are rollable</returns>
        public bool[] getRollable()
        {
            bool[] rollable = new bool[5];
            for (int i = 0; i < Dice.Length; i++)
            {
                rollable[i] = Dice[i].isRollable();
            }
            return rollable;
        }

        /// <summary>
        /// Returns and array of int, indicating the values of the die
        /// </summary>
        /// <returns>An array of ints indicating the values of the die</returns>
        public int[] getDieValues()
        {
            int[] dieValue = new int[5];
            for (int i = 0; i < Dice.Length; i++)
            {
                dieValue[i] = Dice[i].GetValue();
            }
            return dieValue;
        }
        
        private void calculateScore()
        {
            currentTurnScore = 0;
            int[][] scoredSets = new int[7][];
            for (int i = 1; i < scoredSets.Length; i++)
            {
                List<int> localSet = new List<int>();
                for (int dieNumber = 0; dieNumber < Dice.Length; dieNumber++)
                {
                    if (Dice[dieNumber].GetValue() == i && !Dice[dieNumber].isRollable())
                    {
                        localSet.Add(dieNumber);
                    }
                }
                scoredSets[i] = localSet.ToArray();
            }

            for (int i = 2; i < scoredSets.Length; i++)
            {
                if (i == 5 && scoredSets[i].Length<=3)
                    continue;
                
                if (scoredSets[i].Length == 3)
                    currentTurnScore += 100 * i;
                if (scoredSets[i].Length == 4)
                    currentTurnScore += 3000;
                if (scoredSets[i].Length == 5)
                    currentTurnScore += 10000;
            }
            if (scoredSets[5].Length == 3)
                currentTurnScore += 750;
            else if (scoredSets[5].Length < 3)
                currentTurnScore += 50 * scoredSets[5].Length;
            if (scoredSets[1].Length == 3)
                currentTurnScore += 1000;
            else if (scoredSets[1].Length < 3)
                currentTurnScore += 100 * scoredSets[1].Length;
        }
    }
}
