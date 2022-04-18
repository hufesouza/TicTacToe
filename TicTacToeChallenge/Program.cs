using System;

namespace TicTacToeChallenge
{
    internal class Program
    {   
        // Creating 2D array to be displayed 
        static string[,] matrix =
        {
            {"1","2","3"},
            {"4","5","6"},
            {"7","8","9"}
        };

        // Declaring global variables
        public static string input;
        public static string[] players = { "Player 1: ", "Player 2: " };
        public static bool matchStatus = true;
        public static int inputInt;
        static void Main(string[] args)
        {
            // Declaring local variables
            string message;
            // Calling a method to display matrix and structure 
            displayMatrix();

            int currentPlayerIndex = 0; 

            do
            {
                
                string player = players[currentPlayerIndex];

                message = players[0] == player && matchStatus == true ? "Player 1: Choose your field! " : "Player 2: Choose your field! ";
                Console.Write(message);
                input = Console.ReadLine();
                        
                if (int.TryParse(input, out inputInt)) // To ensure correct values entered.
                {
                    var isAValidTurn = game(input, player); // the valid turn variable will receive a game receiveing player and input, if input is incorrect, the if below will not run
                                                            // repeating the loop until valid entry.

                    if (isAValidTurn) // it changes player, if index 0 it changes to 1, if on changes to 0, it will run only if the entry was valid
                    {
                        if (currentPlayerIndex == 0)
                        {
                            currentPlayerIndex = 1;
                        }
                        else
                        {
                            currentPlayerIndex = 0;
                        }

                        Console.Clear(); // refreshing console and checking if match has come to the end
                        displayMatrix();
                        definingWinner();
                    }


                    if (matchStatus == false) // if a winner was defined, matchStatus becomes false. if matchStatus is "false" it breaks the foreach loop.
                    {                         // The outer loop only runs while matchStatus is "true"
                        break;
                    }
                    else if (IsDraw()) // once its called it return false for matchStatus, breaking the loop and write draw on the console
                    {
                        matchStatus = false;
                        Console.WriteLine("DRAW!!");
                    }
                }
                else
                {
                    errorMessage(input, player); //If entry is not a valid number, error message called
                }                  
                             
            } while (matchStatus == true);
        }

            // Displaying numbers and creating structure.
        static void displayMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i != 0)
                {
                    Console.WriteLine("_____|_____|_____");
                }
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j < 1 || i == 2 && j == 2)
                    {
                        Console.WriteLine($"     |     | ");

                    }
                    else if (j == 1)
                    {
                        Console.WriteLine($"  {matrix[i, 0]}  |  {matrix[i, j]}  |  {matrix[i, 2]} ");

                    }
                }
            }
        }

        // Creating a switch statement for each possible entry.
        public static bool game(string input, string player)
        {
            switch (input)
            {
                case "1":
                    if (matrix[0, 0] == "1") // Check if the field is vacant, if so:  
                    {
                        if (player == players[0]) { matrix[0, 0] = "X"; } else { matrix[0, 0] = "O"; } // Check who is the player and and mark the field, the main program will refresh
                    }
                    else
                    {
                        return errorMessage(input, player); // if the field is already taken, it calls errorMessage method
                    };
                    break;

                case "2":
                    if (matrix[0, 1] == "2")
                    {
                        if (player == players[0]) { matrix[0, 1] = "X"; } else { matrix[0, 1] = "O"; }
                    }
                    else
                    {
                        return errorMessage(input, player);
                    };
                    break;

                case "3":
                    if (matrix[0, 2] == "3")
                    {
                        if (player == players[0]) { matrix[0, 2] = "X"; } else { matrix[0, 2] = "O"; }
                    }
                    else
                    {
                        return errorMessage(input, player);
                    };
                    break;

                case "4":
                    if (matrix[1, 0] == "4")
                    {
                        if (player == players[0]) { matrix[1, 0] = "X"; } else { matrix[1, 0] = "O"; }
                    }
                    else
                    {
                        return errorMessage(input, player);
                    };
                    break;

                case "5":
                    if (matrix[1, 1] == "5")
                    {
                        if (player == players[0]) { matrix[1, 1] = "X"; } else { matrix[1, 1] = "O"; }
                    }
                    else
                    {
                        return errorMessage(input, player);
                    };
                    break;

                case "6":
                    if (matrix[1, 2] == "6")
                    {
                        if (player == players[0]) { matrix[1, 2] = "X"; } else { matrix[1, 2] = "O"; }
                    }
                    else
                    {
                        return errorMessage(input, player);
                    };
                    break;

                case "7":
                    if (matrix[2, 0] == "7")
                    {
                        if (player == players[0]) { matrix[2, 0] = "X"; } else { matrix[2, 0] = "O"; }
                    }
                    else
                    {
                        return errorMessage(input, player);
                    };
                    break;

                case "8":
                    if (matrix[2, 1] == "8")
                    {
                        if (player == players[0]) { matrix[2, 1] = "X"; } else { matrix[2, 1] = "O"; }
                    }
                    else
                    {
                        return errorMessage(input, player);
                    };
                    break;

                case "9":
                    if (matrix[2, 2] == "9")
                    {
                        if (player == players[0]) { matrix[2, 2] = "X"; } else { matrix[2, 2] = "O"; }
                    }
                    else
                    {
                        return errorMessage(input, player);
                    };
                    break;

                default:
                    return errorMessage(input, player);

            }

            return true;

        }

        // Defining rules that will drive to a winner
        public static void definingWinner()
        {
            if (IsWinner("X"))
            {
                Console.WriteLine("Player 1 is the Winner");
                matchStatus = false; // match status change interrupting foreach and do while loop in the main program.

            }
            else if (IsWinner("O"))
            {
                Console.WriteLine("Player 2 is the Winner");
                matchStatus = false;
            }

            static bool IsWinner(string playerChar) // Player character is defined on the game method, X = P1, O = P2 - this method will return the condition to define a winner
            {                                       // when it is called, it will check if the same char is allocated as per condition below.
                return matrix[0, 0] == playerChar && matrix[0, 1] == playerChar && matrix[0, 2] == playerChar || matrix[0, 2] == playerChar && matrix[1, 1] == playerChar && matrix[2, 0] == playerChar
                || matrix[2, 0] == playerChar && matrix[1, 0] == playerChar && matrix[0, 0] == playerChar || matrix[0, 0] == playerChar && matrix[1, 1] == playerChar && matrix[2, 2] == playerChar
                || matrix[2, 2] == playerChar && matrix[2, 1] == playerChar && matrix[2, 0] == playerChar || matrix[2, 2] == playerChar && matrix[1, 2] == playerChar && matrix[0, 2] == playerChar
                || matrix[0, 1] == playerChar && matrix[2, 1] == playerChar && matrix[1, 1] == playerChar;
            }
        }

        public static  bool IsDraw() // it will check if each field is different than X or O, if so the boolean result is false, if all field is taken and no winner was found
                                     // fields will be X or O and will break the loop and return true to the boolean defining it is a draw.
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != "X" && matrix[i, j] != "O")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //Defining error message  for field already taken or incorrect entry. 
        public static bool errorMessage(string input, string player)
        {
            Console.WriteLine("Field already Taken or Incorrect Entry");
     

            return false;
        }
    }
}
