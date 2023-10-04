using System;

namespace TicTacToe
{
    class Program
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1; // By default player 1 starts
        static int choice; // User choice for position to mark
        static int flag = 0; // 1 means a player has won the match
        static char symbol; // 'X' or 'O'

        static void Main(string[] args)
        {
            do
            {
                Console.Clear(); // Whenever loop restarts we clear the console
                Console.WriteLine("Player 1: X and Player 2: O");
                Console.WriteLine("\n");
                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2's turn");
                    symbol = 'O';
                }
                else
                {
                    Console.WriteLine("Player 1's turn");
                    symbol = 'X';
                }
                Console.WriteLine("\n");
                Board();

                // Check for valid input (an int; a number between 1 and 9; a number not picked yet)
                bool validInput = false;
                while (true)
                {
                    string input = Console.ReadLine();
                    validInput = Int32.TryParse(input, out choice);
                    if (validInput)
                    {
                        if (choice < 1 || choice > 9)
                            validInput = false;
                        else if (arr[choice] != 'X' && arr[choice] != 'O')
                            break;
                    }
                    Console.WriteLine("Please enter a valid number between 1 and 9 that hasn't been picked yet");
                }

                // Mark O or X on the board
                arr[choice] = symbol;
                player++;

                flag = CheckWin();

            } while (flag != 1 && flag != -1);

            Console.Clear();
            Board();

            if (flag == 1)
            {
                Console.WriteLine($"Player {(player % 2) + 1} has won!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
            Console.ReadLine();
        }

        private static void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {arr[1]}  |  {arr[2]}  |  {arr[3]}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {arr[4]}  |  {arr[5]}  |  {arr[6]}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {arr[7]}  |  {arr[8]}  |  {arr[9]}");
            Console.WriteLine("     |     |      ");
        }

        private static int CheckWin()
        {
            #region Horzontal Winning Condtion
            // Winning Condition For First Row
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            // Winning Condition For Second Row
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            // Winning Condition For Third Row
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return 1;
            }
            #endregion

            #region Vertical Winning Condtion
            // Winning Condition For First Column
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            // Winning Condition For Second Column
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            // Winning Condition For Third Column
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            #endregion

            #region Diagonal Winning Condition
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }
            #endregion

            #region Checking For Draw
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            #endregion

            else
            {
                return 0;
            }
        }
    }
}
