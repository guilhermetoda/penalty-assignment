/* VFS - Vancouver Film School */
/* Game Design 53 */

/* Student: Guilherme Alves Toda */
/* First Assignment - Intro to Programming in C# */

/* This a "Futebol" (Soccer) Penalty shooter game, the player choose where he wants to shoot the ball and 
 * then selects the power of the shoot
 * Based on the skill of the player and 2 random variables the ball could go off target, the GK can save the penalty or the foward can score!
 */

/* TO DO: 
    * a. Tutorial for Penalty shoot and gk
    * b. Easy, Medium and Hard difficult
    * c. A 5x5 "Futebol" match
 */
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballPenaltyGame
{
    
    class Program
    {

        static void Main(string[] args)
        {
            
            bool gameOver = false;
            int countShoots = 0;
            int maxTries = 5;
            int[] arrayOfGoals = new int[5];
            // While the game is not over
            while (!gameOver && countShoots < maxTries)
            {

                Console.WriteLine(" --  The Penalty Game --");
                Console.WriteLine("  ___________________________");
                Console.WriteLine(" |             |             |");
                Console.WriteLine(" |___          |          ___|");
                Console.WriteLine(" |_  |         |         |  _|");
                Console.WriteLine(".| | |.       ,|.       .| | |.");
                Console.WriteLine("|| | | )     ( | )     ( | | ||");
                Console.WriteLine("'|_| |'       `|'       `| |_|'");
                Console.WriteLine(" |___|         |         |___|");
                Console.WriteLine(" |             |             |");
                Console.WriteLine(" |_____________|_____________|");

                Console.WriteLine("-------------------------------------");
                Console.WriteLine("-- Penalty Shoot Game! You have to Score! You have 5 chances!");
                Console.WriteLine("-- Aim you shoot based on the positions of the net and the measure your shoot power!");
                Console.WriteLine("-- Press Y when you are ready or quit to exit (Y/Quit): ");
                /* Reading the choice of the user and changing the case of the option */
                string userOptions = Console.ReadLine().ToUpper();
                if (userOptions == "Y")
                {
                    arrayOfGoals[countShoots] = PenaltyAnimation();
                    countShoots++;
                    // Creates a Shooter Player
                }
                else if (userOptions == "QUIT")
                {
                    gameOver = true;
                }
                else
                {
                    Console.WriteLine("-- Your options is not valid, please press Y to shoot or Quit to leave the game");
                }
            }

            /* This will prevent the code to not break in the IndexOutOfBounds from the array */
            if (countShoots == maxTries)
            {
                int goalsMade = 0;
                for (int i = 0; i < maxTries; i++)
                {
                    goalsMade += arrayOfGoals[i];
                }
                Console.WriteLine("-- You Scored " + goalsMade + " goals!");
                if (goalsMade > 0)
                {
                    Console.WriteLine("-- Congratulations!");
                }
                else
                {
                    Console.WriteLine("-- You have to train a little more");
                }
                Console.WriteLine("-- Press any key to leave...");
                Console.ReadKey();
            }
        }

       
        /* This function prints the goal net, so the foward can choose where aim the Penalty */
        static int PenaltyAnimation()
        {
            bool correctInput = false;
            /* If the shoot returns a goal, this function will return 1 
               This value is used to count the number of goals made */
            int returnShoot = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("    This is the Goal! SHOOT!!");
                Console.WriteLine(" ______________________________________");
                Console.WriteLine("|       '       '       '       '      |");
                Console.WriteLine("|   1   '   3   '   14  '   2   '   4  |");
                Console.WriteLine("|       '       '       '       '      |");
                Console.WriteLine("|''''''''''''''''''''''''''''''''''''''|");
                Console.WriteLine("|   5   '   7   '   0   '   6   '   8  |");
                Console.WriteLine("|       '       '       '       '      |");
                Console.WriteLine("|''''''''''''''''''''''''''''''''''''''|");
                Console.WriteLine("|   9   '   11  '   13  '   10  '  12  |");
                Console.WriteLine("|_______'_______'_______'_______'______|");

                Console.Write("Pick a position (0-14) where you want to shoot in the goal: ");
                string position = Console.ReadLine();

                int intPosition;
                bool successConverting = Int32.TryParse(position, out intPosition);
                /* If the converting (string to int32) was successfull, then continues the game
                 * else gets a valid input */
                if (successConverting)
                {

                    if (intPosition < 0 || intPosition > 14)
                    {
                        Console.WriteLine("-- Pick a position between 0 and 14");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine("-- Press ENTER to select the Shoot Power!");
                        Console.WriteLine("-- Shoot Power Bar");
                        Console.WriteLine("0.......................50.....................100");
                        int maxPower = 100;
                        int countPower = 0;
                        int powerMeter = 0;
                        // The shoot meter will stop when it reaches the 100, and counter will increase by 5
                        // Also, the meter stops when the user press the ENTER Key
                        while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter) && countPower < maxPower)
                        {
                            Console.Write(".");
                            Thread.Sleep(20);
                            countPower += 2;
                            powerMeter = countPower;
                        }
                        Console.WriteLine();
                        Console.WriteLine("Power: " + powerMeter);


                        correctInput = true;
                        returnShoot = Shoot(intPosition, powerMeter);
                    }
                }
                else
                {
                    Console.WriteLine("-- Please a NUMBER between 0 and 14");
                    Thread.Sleep(1000);
                }

            } while (correctInput == false);

            return returnShoot;
        }

        /* Based on the positions of the net, this function will return the direction of the shoot
         * LEFT, RIGHT or CENTER 
         * RIGHT == 0, LEFT == 1 and CENTER == 2
           The Numbers 0, 13 and 14 are Center 
           The odds numbers are LEFT
           The even numbers are RIGHT */
        static int sideAimed(int shootPosition)
        {
            int modulus = shootPosition % 2;
            switch (modulus)
            {
                case 0:
                    //RIGHT
                    return 0;
                case 1:
                    //LEFT
                    return 1;
                default:
                    //CENTER
                    return 2;
            }
        }

        static int Shoot(int shootPosition, int shootPower)
        {
            /*   ______________________________________
                |       '       '       '       '      |
                |   1   '   2   '   3   '   4   '   5  |
                |       '       '       '       '      |
                |''''''''''''''''''''''''''''''''''''''|
                |   6   '   7   '   8   '   9   '  10  |
                |       '       '       '       '      |
                |''''''''''''''''''''''''''''''''''''''|
                |  11   '   12  '   13  '   14  '  15  |
                |_______'_______'_______'_______'______| 
           */

            Foward attackingPlayer = new Foward();
            Goalie goaliePlayer = new Goalie();
            
            float finalShoot = attackingPlayer.shootScore(shootPosition, shootPower);
            int sideAimedByFoward = sideAimed(shootPosition);
            float goalieValue = goaliePlayer.GoalieDefense(sideAimedByFoward);
            
            if (finalShoot > 25)
            {
                // The Ball went off the target!
                // Too Much Power
                AnimationOffTheTarget();
                return 0;
            }
            else if (goalieValue > finalShoot)
            {
                //The Goalie Saves!!
                GKSaves();
                return 0;
            }
            else
            {
                AnimationGoal();
                //GOOOOALLL!
                return 1;
            }           

        }

        static void AnimationGoal()
        {
            Console.Clear();
            Console.WriteLine("  ___________________________");
            Console.WriteLine(" |             |             |");
            Console.WriteLine(" |___          |          ___|");
            Console.WriteLine(" |_  |         |         |  _|");
            Console.WriteLine(".| | |.       ,|.       .| | |.");
            Console.WriteLine("|| | | )     ( | )     ( |O| ||");
            Console.WriteLine("'|_| |'       `|'       `| |_|'");
            Console.WriteLine(" |___|         |         |___|");
            Console.WriteLine(" |             |             |");
            Console.WriteLine(" |_____________|_____________|");
            Thread.Sleep(1500);
            Console.Clear();
            Console.WriteLine("  ___________________________");
            Console.WriteLine(" |             |             |");
            Console.WriteLine(" |___          |          ___|");
            Console.WriteLine(" |_  |         |         |  _|");
            Console.WriteLine(".| | |.       ,|.       .| | |.");
            Console.WriteLine("|| | | )     ( | )     ( |o| ||");
            Console.WriteLine("'|_| |'       `|'       `| |_|'");
            Console.WriteLine(" |___|         |         |___|");
            Console.WriteLine(" |             |             |");
            Console.WriteLine(" |_____________|_____________|");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("  ___________________________");
            Console.WriteLine(" |             |             |");
            Console.WriteLine(" |___          |          ___|");
            Console.WriteLine(" |_  |         |         |  _|");
            Console.WriteLine(".| | |.       ,|.       .| | |.");
            Console.WriteLine("|| | | )     ( | )     ( | |o||");
            Console.WriteLine("'|_| |'       `|'       `| |_|'");
            Console.WriteLine(" |___|         |         |___|");
            Console.WriteLine(" |             |             |");
            Console.WriteLine(" |_____________|_____________|");
            Thread.Sleep(500);
            Console.Clear();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("  ######    #######     ###    ##       ");
                Console.WriteLine(" ##    ##  ##     ##   ## ##   ##       ");
                Console.WriteLine(" ##        ##     ##  ##   ##  ##       ");
                Console.WriteLine(" ##   #### ##     ## ##     ## ##       ");
                Console.WriteLine(" ##    ##  ##     ## ######### ##       ");
                Console.WriteLine(" ##    ##  ##     ## ##     ## ##       ");
                Console.WriteLine("  ######    #######  ##     ## ######## ");
                Thread.Sleep(200);
                Console.Clear();
                Console.WriteLine("..######....#######.....###....##......");
                Console.WriteLine(".##....##..##.....##...##.##...##......");
                Console.WriteLine(".##........##.....##..##...##..##......");
                Console.WriteLine(".##...####.##.....##.##.....##.##......");
                Console.WriteLine(".##....##..##.....##.#########.##......");
                Console.WriteLine(".##....##..##.....##.##.....##.##......");
                Console.WriteLine("..######....#######..##.....##.########");
                Thread.Sleep(200);
                Console.Clear();
            }
        }

        static void GKSaves()
        {
            Console.Clear();
            Console.WriteLine("  ___________________________");
            Console.WriteLine(" |             |             |");
            Console.WriteLine(" |___          |          ___|");
            Console.WriteLine(" |_  |         |         |  _|");
            Console.WriteLine(".| | |.       ,|.       .| | |.");
            Console.WriteLine("|| | | )     ( | )     ( |O| ||");
            Console.WriteLine("'|_| |'       `|'       `| |_|'");
            Console.WriteLine(" |___|         |         |___|");
            Console.WriteLine(" |             |             |");
            Console.WriteLine(" |_____________|_____________|");
            Thread.Sleep(1500);
            Console.Clear();
            Console.WriteLine("  ___________________________");
            Console.WriteLine(" |             |             |");
            Console.WriteLine(" |___          |          ___|");
            Console.WriteLine(" |_  |         |         |  _|");
            Console.WriteLine(".| | |.       ,|.       .| | |.");
            Console.WriteLine("|| | | )     ( | )     ( |o| ||");
            Console.WriteLine("'|_| |'       `|'       `| |_|'");
            Console.WriteLine(" |___|         |         |___|");
            Console.WriteLine(" |             |             |");
            Console.WriteLine(" |_____________|_____________|");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("  ___________________________");
            Console.WriteLine(" |             |             |");
            Console.WriteLine(" |___          |          ___|");
            Console.WriteLine(" |_  |         |         |  _|");
            Console.WriteLine(".| | |.       ,|.       .| | |.");
            Console.WriteLine("|| | | )     ( | )     ( | |o||");
            Console.WriteLine("'|_| |'       `|'       `| |_|'");
            Console.WriteLine(" |___|         |         |___|");
            Console.WriteLine(" |             |             |");
            Console.WriteLine(" |_____________|_____________|");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine(" ######   ##    ##     ######     ###    ##     ## ########  ######  ");
            Console.WriteLine("##    ##  ##   ##     ##    ##   ## ##   ##     ## ##       ##    ## ");
            Console.WriteLine("##        ##  ##      ##        ##   ##  ##     ## ##       ##       ");
            Console.WriteLine("##   #### #####        ######  ##     ## ##     ## ######    ######  ");
            Console.WriteLine("##    ##  ##  ##            ## #########  ##   ##  ##             ## ");
            Console.WriteLine("##    ##  ##   ##     ##    ## ##     ##   ## ##   ##       ##    ## ");
            Console.WriteLine(" ######   ##    ##     ######  ##     ##    ###    ########  ###### ");
            Thread.Sleep(3000);
            Console.Clear();
        }

        static void AnimationOffTheTarget()
        {
            Console.Clear();
            Console.WriteLine("  ___________________________");
            Console.WriteLine(" |             |             |");
            Console.WriteLine(" |___          |          ___|");
            Console.WriteLine(" |_  |         |         |  _|");
            Console.WriteLine(".| | |.       ,|.       .| | |.");
            Console.WriteLine("|| | | )     ( | )     ( |O| ||");
            Console.WriteLine("'|_| |'       `|'       `| |_|'");
            Console.WriteLine(" |___|         |         |___|");
            Console.WriteLine(" |             |             |");
            Console.WriteLine(" |_____________|_____________|");
            Thread.Sleep(1500);
            Console.Clear();
            Console.WriteLine("  ___________________________");
            Console.WriteLine(" |             |             |");
            Console.WriteLine(" |___          |          ___|");
            Console.WriteLine(" |_  |         |         |  _|");
            Console.WriteLine(".| | |.       ,|.       .| | |.");
            Console.WriteLine("|| | | )     ( | )     ( |o| ||");
            Console.WriteLine("'|_| |'       `|'       `| |_|'");
            Console.WriteLine(" |___|         |         |___|");
            Console.WriteLine(" |             |             |");
            Console.WriteLine(" |_____________|_____________|");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("  ___________________________");
            Console.WriteLine(" |             |             |");
            Console.WriteLine(" |___          |          ___|");
            Console.WriteLine(" |_  |         |         |  _|");
            Console.WriteLine(".| | |.       ,|.       .| | |.");
            Console.WriteLine("|| | | )     ( | )     ( | | ||");
            Console.WriteLine("'|_| |'       `|'       `| |o|'");
            Console.WriteLine(" |___|         |         |___|");
            Console.WriteLine(" |             |             |");
            Console.WriteLine(" |_____________|_____________|");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine(" #######  ######## ########    ######## ##     ## ########    ########    ###    ########   ######   ######## ######## ");
            Console.WriteLine("##     ## ##       ##             ##    ##     ## ##             ##      ## ##   ##     ## ##    ##  ##          ##    ");
            Console.WriteLine("##     ## ##       ##             ##    ##     ## ##             ##     ##   ##  ##     ## ##        ##          ##    ");
            Console.WriteLine("##     ## ######   ######         ##    ######### ######         ##    ##     ## ########  ##   #### ######      ##    ");
            Console.WriteLine("##     ## ##       ##             ##    ##     ## ##             ##    ######### ##   ##   ##    ##  ##          ##    ");
            Console.WriteLine("##     ## ##       ##             ##    ##     ## ##             ##    ##     ## ##    ##  ##    ##  ##          ##    ");
            Console.WriteLine(" #######  ##       ##             ##    ##     ## ########       ##    ##     ## ##     ##  ######   ########    ##   ");
            Thread.Sleep(3000);
            Console.Clear();
            
        }
    }
}
