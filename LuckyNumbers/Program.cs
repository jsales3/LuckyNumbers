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
            int startNum;
            int endNum;
            int[] userNum = new int[6];
            int correctNumbers = 0;
            string answer = "yes";
            double winings;
            double jackpot = 50000;

            do
            {


                Console.WriteLine("Enter a starting number");
                startNum = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter a ending number");
                endNum = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter six numbers within the range of " + startNum + " and " + endNum + " for a chance to win " + "$" + jackpot);
                for (int i = 0; i < userNum.Length; i++)
                {
                    userNum[i] = int.Parse(Console.ReadLine());

                    while ((userNum[i] < startNum) || (userNum[i] > endNum))
                    {

                        Console.WriteLine("Please enter a valid number within the range");
                        userNum[i] = int.Parse(Console.ReadLine());
                    }
                }

                Random r = new Random();
                int[] luckyNumbers = new int[6];
                int[] luckyNum = new int[6];
                for (int j = 0; j < luckyNumbers.Length; j++)
                {
                    luckyNumbers[j] = r.Next(startNum, endNum);
                }

                for (int k = 5; k > -1; k--)
                {
                    for (int l = 0; l < k; l++)
                    {
                        if (luckyNumbers[k] == luckyNumbers[l])
                        {
                            luckyNumbers[l] = r.Next(startNum, endNum);
                        }
                    }
                    Console.WriteLine("Lucky Numbers:" + luckyNumbers[k]);
                }

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
                Console.WriteLine("you guessed " + correctNumbers + " numbers correctly!");

                winings = Earmings(jackpot, correctNumbers);
                Console.WriteLine("Congrats!, You won $" + winings + "!");


                Console.WriteLine("would you like to play agian?: ");
                answer = Console.ReadLine();

                if (answer == "no")
                {
                    Console.WriteLine("Thanks for Playing!");
                }

            } while (answer != "no");
        }

        static double Earmings(double numOne, double numTwo)
        {


            double amount = numOne * (numTwo / 6);
            return amount;
        }
    }
}
