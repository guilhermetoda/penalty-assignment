using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballPenaltyGame
{
    public class Goalie : Player
    {
        /* This class is an inheritance from the Player Class */
        Player player;
        protected Random randomGenerator;

        public Goalie()
        {
            player = new Player();
            player.setShootAccuracy(70);
            player.setReflexes(20);
        }

        /* This function generates a random number between 0,1 to represents the side chose by the goalie
         * 0 - RIGHT
         * 1 - LEFT 
         */
        public int goalieChoseSide()
        {
            randomGenerator = new Random();
            return randomGenerator.Next(0, 2);
        }

        public float GoalieDefense(int sideAimedByFoward)
        {

            // If the side chose by the foward was different from the Goalie, the Goalie CAN'T Save the penalty
            // And the selected side was not CENTER (2)
            if (sideAimedByFoward != goalieChoseSide() && sideAimedByFoward != 2)
            {
                return 0;
            }
            float goalieSkill = player.getReflexes() / 100;
            float maxPositionGrade = 22;
            return goalieSkill * maxPositionGrade;
        }
    }
}
