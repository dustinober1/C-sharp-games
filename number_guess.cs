using System;

namespace NumberGuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Number Guessing Game!");
            Console.WriteLine("I have selected a number between 1 and 100. Try to guess what number I picked.");

            // Generate a random number between 1 and 100
            Random random = new Random();
            int numberToGuess = random.Next(1, 101);
            int numberofAttempts = 10;
            bool hasGuessedCorrectly = false;

            for (int i = 0; i < numberofAttempts; i++)
            {
                Console.WriteLine($"Attempt {i + 1}: Enter your guess");
                int playerGuess;

                // Check if the input is a valid number
                if (!int.TryParse(Console.ReadLine(), out playerGuess))
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }

                // Check if the guess is correct
                if (playerGuess == numberToGuess)
                {
                    hasGuessedCorrectly = true;
                    break;
                }
                else if (playerGuess > numberToGuess)
                {
                    Console.WriteLine("Too High!");
                }
                else
                {
                    Console.WriteLine("Too Low!");
                }
            }
            
            if (hasGuessedCorrectly)
            {
                Console.WriteLine($"Congratulations! You guessed the number {numberToGuess} correctly.");
            }
            
            else
            {
                Console.WriteLine($"Sorry, you ran out of attempts. The correct number was {numberToGuess}.");
            }
        }
    }
}