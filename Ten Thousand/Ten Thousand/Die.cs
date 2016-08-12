using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ten_Thousand
{
    class Die
    {
        private int value;
        private bool rollable; //If it isn't rollable that means it's scored
        private bool scorable; //If the die can be scored this round
        private bool newValue; //If the die got the value this round

        /// <summary>
        /// Initialize the Die to a value of 0 and a rollable status of true;
        /// </summary>
        public Die()
        {
            value = 0;
            rollable = true;
            scorable = false;
            newValue = true;
        }

        /// <summary>
        /// Set the Die value to the specified amount
        /// </summary>
        /// <param name="val">A number between 1 and 6</param>
        public void SetValue(int val)
        {
            if (val < 1 || val > 6)
            {
                throw new ArgumentOutOfRangeException();
            }
            value = val;
            newValue = true;
        }

        /// <summary>
        /// Set the rollable status of die to the specified
        /// </summary>
        /// <param name="roll">New rollable status of die</param>
        public void setRollable(bool roll)
        {
            rollable = roll;
        }

        /// <summary>
        /// Set the scorable status of the die to the value specified
        /// </summary>
        /// <param name="status">Scorable status of the die</param>
        public void setScorable(bool status)
        {
            scorable = status;
        }
        
        /// <summary>
        /// Set newValue to false
        /// </summary>
        public void ageValue()
        {
            newValue = false;
        }

        /// <summary>
        /// Return the Die Value
        /// </summary>
        /// <returns>Die Value</returns>
        public int GetValue()
        {
            return value;
        }

        /// <summary>
        /// Returns the Die's Rollable Status
        /// </summary>
        /// <returns></returns>
        public bool isRollable()
        {
            return rollable;
        }

        /// <summary>
        /// Toggle the rollable Value
        /// </summary>
        public void toggleRollable()
        {
            rollable = !rollable;
        }

        /// <summary>
        /// Returns the scorable status of the die
        /// </summary>
        /// <returns>Scorable status of die</returns>
        public bool isScorable()
        {
            return scorable;
        }

        /// <summary>
        /// Returns the new Value State
        /// </summary>
        /// <returns>New Value State</returns>
        public bool isNewValue()
        {
            return newValue;
        }
        
    }
}
