using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PlayAround
{
    public class linearSeach
    {
        public void Search()
        {
            Global.winner = 0;


            while (Global.winner == 0)
            {

                Global.validTurnChecker = 0;

                Global.guessNumber = (Global.maxNumber + Global.minNumber) / 2;

                while (Global.validTurnChecker == 0)
                {
                    Console.WriteLine("is your number...." + Global.guessNumber + "\n\n");

                    Console.WriteLine("Please input Y for yes and N for no." + "\n\n");

                    Global.isCorrect = Console.ReadLine();

                    if (Global.isCorrect == "Y" || Global.isCorrect == "y")
                    {
                        Global.winner = 1;
                        Console.WriteLine("I win!");
                        Global.validTurnChecker++;
                        break;
                    }

                    if (Global.isCorrect == "N" || Global.isCorrect == "n")
                    {
                        if (Global.guessNumber == Global.maxNumber || Global.guessNumber == Global.minNumber)
                        {

                            Console.WriteLine("You cant lie, be honest.");
                            Global.winner = 1;
                        }

                        Global.validTurnChecker++;

                        while (Global.validTurnChecker == 1)
                        {
                            Console.WriteLine("Is your number H or L?" + "\n\n");

                            Global.higherOrLower = Console.ReadLine();


                            // if its higher, make the minimum number equal to the guess number
                            // then default the minimum number to be 0 and increment validTurnChecker so that this loop doesnt happen.
                            if (Global.higherOrLower == "H" || Global.higherOrLower == "h")
                            {
                                Global.minNumber = Global.guessNumber;
                                Global.guessNumber = 0;
                                Global.validTurnChecker++;
                            }

                            // if its higher, make the maximum number equal to the guess number
                            // then default the maximum number to be 0 and increment validTurnChecker so that this loop doesnt happen.
                            else if (Global.higherOrLower == "L" || Global.higherOrLower == "l")
                            {
                                Global.maxNumber = Global.guessNumber;
                                Global.guessNumber = 0;
                                Global.validTurnChecker++;

                            }
                            else
                            {
                                Console.WriteLine("Please input H for higher or L for lower. Invalid input.");
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("Please input Y for yes or N for no. Invalid input.");
                    }
                    }
                }

            }
        } 
    
}
