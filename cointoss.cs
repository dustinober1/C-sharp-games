using System;

namespace CoinTossGame
{
    class Program
    {
        enum Coin { Heads, Tails }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Coin Toss!");

            Random rand = new Random();

            while (true)
            {
                Console.WriteLine("\nChoose: \n1. Heads \n2. Tails \n3. Exit");
                int choice;

                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
                {
                    Console.WriteLine("Please enter a valid choice.");
                    continue;
                }

                if (choice == 3) break; // Exit the game

                Coin playerChoice = (Coin)(choice - 1);
                Coin tossResult = (Coin)rand.Next(0, 2);

                Console.WriteLine($"You chose {playerChoice}");
                Console.WriteLine($"Coin toss result: {tossResult}");

                if (playerChoice == tossResult)
                {
                    Console.WriteLine("Congratulations! You guessed correctly.");
                }
                else
                {
                    Console.WriteLine("Sorry, better luck next time.");
                }
            }
        }
    }
}
