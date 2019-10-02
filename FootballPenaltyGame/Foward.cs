using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballPenaltyGame
{
    public class Foward : Player
    {
        /* This class is an inheritance from the Player Class */
        Player player;
        protected Random randomGenerator;

        public Foward()
        {
            player = new Player();

            player.setShootAccuracy(90);
            player.setReflexes(5);
            /* Random constructor without a seed gets the clock timestamp, so we can have a new number when the program starts, 
             * if I add a seed in the constructor the random sequence will repeat everytime */
            randomGenerator = new Random();

        }

        /* Even if a User choose a position in the game, based on the attributes of the player will calculate the position after the shoot */
        /* 
         * The Formula is Accuracy * RealPowerShoot
         * 
         * The Accuracy is how accurate will be the shot
         * Accuracy =  AccFactor * PositionGrade
         * AccFactor is a Random Number, the idea is if higher the accuracy attribute of the player, less the chance that the AccFactor will influence in the shoot
         * PositionGrade = Skill * shootPosition - Position grade is the rate of the Skill and the position chose, if the Accuraccy skill is 100, the position will be the chose         
         * realPowerShoot - The best power is between  50 to 70, if you shoot with more power the ball could go off the target, but if less power and the goalie choose the correct side, 
         * it will increase the chances of the goalie defends the penalty
         */
        public override float shootScore(int shootPosition, int shootPower)
        {
            float accuracySkill = player.getShootAccuracy();
            float positionGrade = (accuracySkill / 100) * player.convertPenaltyPosition(shootPosition);           
            float accFactor = (float)randomGenerator.Next(1, 101) / 100;

            float accuracy = accFactor * positionGrade;
            float realPowershoot = 0;
            if (shootPower < 50)
            {
                // Will decrease the accuracy of the shoot
                realPowershoot = (float)shootPower / 70;
            }
            else if (shootPower>=50 && shootPower<=70) {
                realPowershoot = 1;
            }
            else if (shootPower > 70) {
                // will increase the chances of the ball goes off target...
                realPowershoot = 5;
            }
             
            float finalShoot = accuracy * realPowershoot;
            return finalShoot;
        }
    }
}
