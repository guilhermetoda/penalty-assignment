using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballPenaltyGame
{
    public class Player
    {
        /* This class represents the player from any position */

        /* Attributes of a player 
        /* Accuracy: 1-100, how accurate is the shoot of the player 
        /* Reflexes: 1-100, how accurate is the reflexes of the goalie to saves a penalty */
        private float shootAccuracy;
        private float reflexes;

        public Player()
        {
            

        }

        public virtual float shootScore(int shootPosition, int shootPower)
        {
            // Function to be override in the Foward class
            Console.WriteLine("Do Nothing");
            return 0;
        }

        /* This converts the positions of the goal a factor, so it fits in the Goal Formula */
        public int convertPenaltyPosition(int position)
        {
            /*  
             *  I use some weight to each position in the goal
             *  ______________________________________
                |       '       '       '       '      |
                |   25  '   20  '   10  '   20  '  25  |
                |       '       '       '       '      |
                |''''''''''''''''''''''''''''''''''''''|
                |   20  '   10  '   5   '   10  '  20  |
                |       '       '       '       '      |
                |''''''''''''''''''''''''''''''''''''''|
                |   25  '   20  '   10  '   20  '  25  |
                |_______'_______'_______'_______'______|

            */

            if (position == 1 || position == 9 || position == 4 || position == 12)
            {
                return 25;
            }
            else if (position == 3 || position == 5 || position == 11 || position == 2 || position == 8 || position == 10)
            {
                return 20;
            }
            else if (position == 14 || position == 7 || position == 6 || position == 13)
            {
                return 10;
            }
            else
            {
                return 5;
            }

        }

        /* Set Shoot Accuracy Attribute*/
        public void setShootAccuracy(float newAccuracy)
        {
            shootAccuracy = newAccuracy;
        }
        /* Set Reflexes Attribute*/
        public void setReflexes(float newReflexes)
        {
            reflexes = newReflexes;
        }
        /* Get Shoot Accuracy Attribute*/
        public float getShootAccuracy()
        {
            return shootAccuracy;
        }
        /* Get Reflexes Attribute*/
        public float getReflexes()
        {
            return reflexes;
        }
    }
}
