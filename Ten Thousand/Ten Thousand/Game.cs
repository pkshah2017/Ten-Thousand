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
        private int rollNum;
        private bool availableMove;
        private bool[] scoredAtRoundBegining; //An array containg which dice were scored at the begining of the round
        private int holdingCurrentTurnScore;

        public Game(string[] names)
        {
            players = new Player[names.Length];
            for (int i = 0; i < names.Length; i++)
                players[i] = new Player(names[i]);
            Dice = new Die[5] { new Die(), new Die(), new Die(), new Die(), new Die() };
            currentPlayer = 0;
            generator = new Random();
            sets = new int[7][];
            scoredAtRoundBegining = new bool[5];
            rollNum = 0;
            holdingCurrentTurnScore = 0;
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
            if (checkAllScored())
            {
                foreach (Die dice in Dice)
                {
                    dice.setRollable(true);
                }
            }
            for (int i = 0; i < Dice.Length; i++)
            {
                scoredAtRoundBegining[i] = Dice[i].isRollable();
                if (Dice[i].isRollable())
                {
                    Dice[i].SetValue(generator.Next(6) + 1);
                    Dice[i].setRollNum(rollNum);
                }
                else
                    Dice[i].ageValue();
            }
            rollNum++;
            checkScorable();
            checkForAvailableMoves();
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
            for (int i = 1; i < 7; i++)//One iteration for each possible die value 
            {
                tempLocations = new List<int>();
                for (int die = 0; die < Dice.Length; die++) // One iteration for each die
                    if (Dice[die].GetValue() == i) //If the die is equal to the value we are checking for this iteration, add the die location to teh array
                        tempLocations.Add(die);

                sets[i] = tempLocations.ToArray(); // Add the array to the sets array
            }

            for (int i = 1; i < sets.Length; i++) //One iteration for each possible die value
                if (sets[i].Length > 2)//If there are 3 or more of that value in the die...
                {
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
        ///  <returns>Whether the Die was toggled</returns>
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
            Dice[dieNumber].isScorable();
            checkForAvailableMoves();
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
        
        /// <summary>
        /// Updates the current turn score
        /// </summary>
        private void calculateScore()
        {
            currentTurnScore = 0;
            currentTurnScore += holdingCurrentTurnScore;            
            int[][] scoredSets = new int[7][];
            for (int i = 1; i < scoredSets.Length; i++)//One iteration for each possible die value
            {
                List<int> localSet = new List<int>();
                for (int dieNumber = 0; dieNumber < Dice.Length; dieNumber++)     //Check every die...
                    if (Dice[dieNumber].GetValue() == i && !Dice[dieNumber].isRollable())         //If it matches the number we are currently checkint and that it is scored
                        localSet.Add(dieNumber); //Than add it to a local set of all scored die locations for that value
                scoredSets[i] = localSet.ToArray(); //Add the list to the scored sets
            }

            for (int i = 2; i < scoredSets.Length; i++) //For every die value from 2 to 6
            {
                if (i == 5) //Skip 5, we handle it seperately
                    continue;
                
                if (scoredSets[i].Length == 3)
                    currentTurnScore += 100 * i;
                if (scoredSets[i].Length == 4)
                    currentTurnScore += 3000;
                if (scoredSets[i].Length == 5)
                    currentTurnScore += 10000;
            }

            //How to score the number 5
            if (scoredSets[5].Length == 3)
            {
                bool allSameAge = true;
                for (int i = 1; i < scoredSets[5].Length; i++)
                    if (Dice[scoredSets[5][0]].getRollNum() != Dice[scoredSets[5][i]].getRollNum())
                        allSameAge = false;

                if (allSameAge)
                    currentTurnScore += 750;                
                else
                    currentTurnScore += 50 * scoredSets[5].Length;
            }
            else if (scoredSets[5].Length == 4)
            {
                bool allSameAge = true;
                for (int i = 1; i < scoredSets[5].Length; i++)
                    if (Dice[scoredSets[5][0]].getRollNum() != Dice[scoredSets[5][i]].getRollNum())
                        allSameAge = false;

                int[] ages = new int[4];
                for (int i = 0; i < scoredSets[5].Length; i++)
                    ages[i] = Dice[scoredSets[5][i]].getRollNum();

                var dict = new Dictionary<int, int>();
                foreach (int d in ages)
                    if (dict.ContainsKey(d))
                        dict[d]++;
                    else
                        dict.Add(d, 1);

                bool setOfThree = false;
                foreach (KeyValuePair<int, int> kvp in dict)
                    if (kvp.Value == 3)
                        setOfThree = true;

                if (allSameAge)
                    currentTurnScore += 3000;
                else if (setOfThree)
                    currentTurnScore += 800;
                else
                    currentTurnScore += 50 * scoredSets[5].Length;
            }
            else if (scoredSets[5].Length == 5)
            {
                bool allSameAge = true;
                for (int i = 1; i < scoredSets[5].Length; i++)
                    if (Dice[scoredSets[5][0]].getRollNum() != Dice[scoredSets[5][i]].getRollNum())
                        allSameAge = false;

                int[] ages = new int[5];
                for (int i = 0; i < scoredSets[5].Length; i++)
                    ages[i] = Dice[scoredSets[5][i]].getRollNum();

                var dict = new Dictionary<int, int>();
                foreach (int d in ages)
                    if (dict.ContainsKey(d))
                        dict[d]++;
                    else
                        dict.Add(d, 1);

                bool setOfThree = false;
                foreach (KeyValuePair<int, int> kvp in dict)
                    if (kvp.Value == 3)
                        setOfThree = true;

                bool setofFour = false;
                foreach (KeyValuePair<int, int> kvp in dict)
                    if (kvp.Value == 4)
                        setofFour = true;


                if (allSameAge)
                    currentTurnScore += 10000;
                else if (setofFour)
                    currentTurnScore += 3050;
                else if (setOfThree)
                    currentTurnScore += 850;
                else
                    currentTurnScore += 50 * scoredSets[5].Length;
            }
            else if (scoredSets[5].Length < 3)
                currentTurnScore += 50 * scoredSets[5].Length;
            //Scoring the die value 1
            if (scoredSets[1].Length == 3)
            {
                bool allSameAge = true;
                for (int i = 1; i < scoredSets[1].Length; i++)
                    if (Dice[scoredSets[1][0]].getRollNum() != Dice[scoredSets[1][i]].getRollNum())
                        allSameAge = false;

                if (allSameAge)
                    currentTurnScore += 1000;
                else
                    currentTurnScore += 100 * scoredSets[1].Length;
            }
            else if (scoredSets[1].Length == 4)
            {
                bool allSameAge = true;
                for (int i = 1; i < scoredSets[1].Length; i++)
                    if (Dice[scoredSets[1][0]].getRollNum() != Dice[scoredSets[1][i]].getRollNum())
                        allSameAge = false;

                int[] ages = new int[4];
                for (int i = 0; i < scoredSets[1].Length; i++)
                    ages[i] = Dice[scoredSets[1][i]].getRollNum();

                var dict = new Dictionary<int, int>();
                foreach (int d in ages)                
                    if (dict.ContainsKey(d))
                        dict[d]++;
                    else
                        dict.Add(d, 1);

                bool setOfThree = false;
                foreach (KeyValuePair<int, int> kvp in dict)
                    if (kvp.Value == 3)
                        setOfThree = true;

                if (allSameAge)
                    currentTurnScore += 3000;
                else if(setOfThree)
                    currentTurnScore += 1100;
                else
                    currentTurnScore += 100 * scoredSets[1].Length;
            }
            else if (scoredSets[1].Length == 5)
            {
                bool allSameAge = true;
                for (int i = 1; i < scoredSets[1].Length; i++)
                    if (Dice[scoredSets[1][0]].getRollNum() != Dice[scoredSets[1][i]].getRollNum())
                        allSameAge = false;

                int[] ages = new int[5];
                for (int i = 0; i < scoredSets[1].Length; i++)
                    ages[i] = Dice[scoredSets[1][i]].getRollNum();

                var dict = new Dictionary<int, int>();
                foreach (int d in ages)
                    if (dict.ContainsKey(d))
                        dict[d]++;
                    else
                        dict.Add(d, 1);

                bool setOfThree = false;
                foreach (KeyValuePair<int, int> kvp in dict)
                    if (kvp.Value == 3)
                        setOfThree = true;

                bool setofFour = false;
                foreach (KeyValuePair<int, int> kvp in dict)
                    if (kvp.Value == 4)
                        setofFour = true;


                if (allSameAge)
                    currentTurnScore += 10000;
                else if (setofFour)
                    currentTurnScore += 3100;
                else if (setOfThree)
                    currentTurnScore += 1200;
                else
                    currentTurnScore += 100 * scoredSets[1].Length;
            }
            else if (scoredSets[1].Length < 3)
                currentTurnScore += 100 * scoredSets[1].Length;
        }

        public void endTurn()
        {
            if (players[currentPlayer].getScore() == 0 && currentTurnScore >= 500)
                players[currentPlayer].setScore(currentTurnScore);
            else if (players[currentPlayer].getScore() != 0)
                players[currentPlayer].addScore(currentTurnScore);
            currentTurnScore = 0;
            foreach (Die dice in Dice)
            {
                dice.setRollable(true);
                dice.setScorable(false);
            }  
                     

            if (++currentPlayer == players.Length)
                currentPlayer = 0;

            rollEm();     
        }

        /// <summary>
        /// Checks if there are any die that are rollable and scorable and updates the avaiable move based on that
        /// </summary>
        private void checkForAvailableMoves()
        {
            availableMove = false;
            foreach (Die dice in Dice)
                if (dice.isRollable() && dice.isScorable())
                    availableMove = true;
        }

        /// <summary>
        /// Returns whether there were moves avaiable.
        /// </summary>
        /// <returns>Wherther there were moves available at the begining of the round</returns>
        public bool getAvaialableMove()
        {
            return availableMove;
        }

        /// <summary>
        /// Returns a Dictionary with Player Names as Keys and Their Score as the value
        /// </summary>
        /// <returns>A dictionary with player names as keys and their scores as the values</returns>
        public Dictionary<string, int> getScores()
        {
            Dictionary<string, int> scores = new Dictionary<string, int>();
            foreach (Player player in players)            
                scores.Add(player.getName(), player.getScore());            
            return scores;
        }

        public bool readyForNextMove()
        {
            if(checkAllScored())
                return false;

            //Make sure atleast one die is scorable
            bool oneScored = false;
            for (int i = 0; i < Dice.Length; i++)
                if (!Dice[i].isRollable())
                    oneScored = true;
            if(!oneScored)
                return false;

            //Check to see if any of the values have changed
            bool ready = false;
            for (int i = 0; i < Dice.Length; i++)
                if (Dice[i].isRollable() != scoredAtRoundBegining[i])
                    ready = true;
            return ready;
        }

        private void allDieSelected()
        {
            holdingCurrentTurnScore += currentTurnScore;
            foreach (Die dice in Dice)
            {
                dice.setRollable(true);
                dice.setScorable(false);
            }
        }

        /// <summary>
        /// Checks if all dice are scored
        /// </summary>
        /// <returns>If all die are scored return true, otherwise returns false</returns>
        private bool checkAllScored()
        {
            bool allScored = true;
            foreach (Die dice in Dice)            
                if (dice.isRollable())                
                    allScored = false;
              
            return allScored;
        }
    }
}
