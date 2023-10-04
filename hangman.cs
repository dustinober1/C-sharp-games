using System;
using System.Collections.Generic;
using System.Linq;

namespace HangmanGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hangman!");

            List<string> wordList = new List<string>() { "programming", "hangman", "computer", "software", "developer" };
            Random rand = new Random();
            string randomWord = wordList[rand.Next(wordList.Count)];
            char[] guessWord = new string('_', randomWord.Length).ToCharArray();
            char[] actualWord = randomWord.ToCharArray();
            List<char> guessedLetters = new List<char>();

            int attempts = 6;

            while (attempts > 0 && !guessWord.SequenceEqual(actualWord))
            {
                Console.WriteLine("\nWord: " + new string(guessWord));
                Console.WriteLine($"Attempts left: {attempts}");
                Console.WriteLine("Guessed letters: " + string.Join(", ", guessedLetters));
                Console.Write("Guess a letter: ");

                char guess = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (guessedLetters.Contains(guess))
                {
                    Console.WriteLine($"You've already guessed the letter {guess}.");
                    continue;
                }

                guessedLetters.Add(guess);

                if (actualWord.Contains(guess))
                {
                    for (int i = 0; i < randomWord.Length; i++)
                    {
                        if (actualWord[i] == guess)
                        {
                            guessWord[i] = guess;
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"The word does not contain the letter {guess}.");
                    attempts--;
                }
            }

            if (guessWord.SequenceEqual(actualWord))
            {
                Console.WriteLine("\nCongratulations! You've guessed the word.");
            }
            else
            {
                Console.WriteLine("\nSorry, you've lost. The word was: " + randomWord);
            }
        }
    }
}
