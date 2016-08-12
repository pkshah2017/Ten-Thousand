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

        /// <summary>
        /// Initialize the Die to a value of 0 and a rollable status of true;
        /// </summary>
        public Die()
        {
            value = 0;
            rollable = true;
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
        public bool GetRollable()
        {
            return rollable;
        }
        
    }
}
