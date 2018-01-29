using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //decalring variables
            int startNum;
            int endNum;
            int[] userNum = new int[6];
            string answer = "yes";
            double winings;
            double jackpot = 50000;

            do
            {
                int correctNumbers = 0;

                //Ask user for a starting and end number gets a range
                Console.WriteLine("Enter a starting number");
                startNum = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter a ending number");
                endNum = int.Parse(Console.ReadLine());

                //Asks user to enter six numbers for a chance at the jackpot
                Console.WriteLine("Enter six numbers within the range of " + startNum + " and " + endNum 
                    + " for a chance to win $50,000 dollars!");


                //A for loop that takes user input and enter the values into an array
                for (int i = 0; i < userNum.Length; i++)
                {
                    userNum[i] = int.Parse(Console.ReadLine());

                    while ((userNum[i] < startNum) || (userNum[i] > endNum))
                    {

                        Console.WriteLine("Please enter a valid number within the range");
                        userNum[i] = int.Parse(Console.ReadLine());
                    }
                }
                Console.WriteLine("\n");

                //declares a variable r of class Random, assigning new instance of the class to the variable
                Random r = new Random();


                //declaring an integer array variable luckyNumbers, 
                //assigning a new instance of the array of size 6 to variable
                int[] luckyNumbers = new int[6];
                

                //for loop that assigns each index of the luckNumbers array with random numbers
                for (int j = 0; j < luckyNumbers.Length; j++)
                {
                    luckyNumbers[j] = r.Next(startNum, endNum);
                }


                //nested for loop that checks for duplicate values within the luckyNumbers array, 
                //then prints out Lucky Numbers
                for (int k = 5; k > -1; k--)
                {
                    for (int l = 0; l < k; l++)
                    {
                        if (luckyNumbers[k] == luckyNumbers[l])
                        {
                            luckyNumbers[l] = r.Next(startNum, endNum);
                        }
                    }
                    
                }

                for(int p = 0; p < luckyNumbers.Length; p++)
                {
                    Console.WriteLine("Lucky Number:" + luckyNumbers[p]);
                }
                Console.WriteLine("\n");


                //nested for loop that compares each index value of the userNum array to each index of
                //luckyNumbers array, counts matching values and assigns the amount to correctNumbers variable
                for (int m = 0; m < luckyNumbers.Length; m++)
                {
                    for (int n = 0; n < luckyNumbers.Length; n++)
                    {
                        if ((userNum[n] == luckyNumbers[m]))
                        {
                            correctNumbers += 1;

                        }
                    }
                }

                
                Console.WriteLine("you guessed " + correctNumbers + " numbers correctly! \n");

                if (correctNumbers == 6)
                {
                    Console.WriteLine("JACKPOT!!!");
                }


                //assigns value returend from the Earnings method to the variable winings, prints winings
                winings = Earmings(jackpot, correctNumbers);
                Console.WriteLine("Congrats!, You just won $" + winings + "!\n");


                Console.WriteLine("would you like to play agian?:");
                answer = Console.ReadLine();


                //
                if (answer == "no")
                {
                    Console.WriteLine("\nThanks for Playing!");
                }

            //conditional that checks the user response to determine if the program continues 
            } while (answer != "no");
        }

        //method that returns calculates the user winings based on the number of correct matches
        static double Earmings(double numOne, double numTwo)
        {
            double amount = numOne * (numTwo / 6);
            return amount;
        }
    }
}
