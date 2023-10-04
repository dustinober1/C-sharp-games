using System;

namespace RockPaperScissors
{
    class Program
    {
        enum Choice { Rock = 1, Paper, Scissors }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rock, Paper, Scissors!");
            Random random = new Random();

            while (true)
            {
                Console.WriteLine("\nChoose your move: \n1. Rock \n2. Paper \n3. Scissors \n4. Exit");
                int playerChoice;

                if (!int.TryParse(Console.ReadLine(), out playerChoice) || playerChoice < 1 || playerChoice > 4)
                {
                    Console.WriteLine("Please enter a valid choice.");
                    continue;
                }

                if (playerChoice == 4) break; // Exit the game

                Choice playerMove = (Choice)playerChoice;
                Choice computerMove = (Choice)random.Next(1, 4);

                Console.WriteLine($"You chose {playerMove}");
                Console.WriteLine($"Computer chose {computerMove}");

                if (playerMove == computerMove)
                {
                    Console.WriteLine("It's a tie!");
                }
                else if ((playerMove == Choice.Rock && computerMove == Choice.Scissors) ||
                         (playerMove == Choice.Scissors && computerMove == Choice.Paper) ||
                         (playerMove == Choice.Paper && computerMove == Choice.Rock))
                {
                    Console.WriteLine("You win!");
                }
                else
                {
                    Console.WriteLine("Computer wins!");
                }
            }
        }
    }
}
