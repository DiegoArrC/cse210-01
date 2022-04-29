using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
            {
                // variable creations
                string firstPlayer = "x";
                string secondPlayer = "o";
                string currentPlayer = firstPlayer;
                string[] boardSpaces = new string[]{"1","2","3","4","5","6","7","8","9"};
                bool stillPlaying = true;

                displayBoard(ref boardSpaces);

                while (stillPlaying == true)
                {
                    // input phase
                    Console.WriteLine($"{currentPlayer}'s turn to choose a square (1-9):");
                    string playerSquare = Console.ReadLine();
                    boardSpaces[int.Parse(playerSquare) - 1] = currentPlayer;

                    // update board
                    displayBoard(ref boardSpaces);
                    bool winner = checkWinner(boardSpaces);
                    bool fullBoard = checkDraw(boardSpaces);
                    
                    // game end conditions
                    if (winner == true)
                    {
                        stillPlaying = false;
                        Console.WriteLine($"{firstPlayer}'s wins!");
                    }
                    
                    if (fullBoard == true)
                    {
                        stillPlaying = false;
                        Console.WriteLine("Looks like it's a tie, good game.");
                    }

                    // change current player
                    if (currentPlayer == firstPlayer)
                    {
                        currentPlayer = secondPlayer;
                    }
                    else{
                        currentPlayer = firstPlayer;
                    }
                }


            }
        
        
        static void displayBoard(ref string[] boardSpaces)
        {
            Console.WriteLine($"{boardSpaces[0]} | {boardSpaces[1]} | {boardSpaces[2]}");
            Console.WriteLine("--+---+---");
            Console.WriteLine($"{boardSpaces[3]} | {boardSpaces[4]} | {boardSpaces[5]}");
            Console.WriteLine("--+---+---");
            Console.WriteLine($"{boardSpaces[6]} | {boardSpaces[7]} | {boardSpaces[8]}");
        }

        static bool checkWinner(string[] boardSpaces)
        {
            if (boardSpaces[0] == boardSpaces[1] && boardSpaces[1] == boardSpaces[2] || // horizontal matches
                boardSpaces[3] == boardSpaces[4] && boardSpaces[4] == boardSpaces[5] ||
                boardSpaces[6] == boardSpaces[7] && boardSpaces[7] == boardSpaces[8] ||
                boardSpaces[0] == boardSpaces[3] && boardSpaces[3] == boardSpaces[6] || // vertical matches
                boardSpaces[1] == boardSpaces[4] && boardSpaces[4] == boardSpaces[7] ||
                boardSpaces[2] == boardSpaces[5] && boardSpaces[5] == boardSpaces[8] ||
                boardSpaces[0] == boardSpaces[4] && boardSpaces[4] == boardSpaces[8] ||
                boardSpaces[2] == boardSpaces[4] && boardSpaces[4] == boardSpaces[6] )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool checkDraw(string[] boardSpaces)
        {
            bool boardFull = true;
            foreach (string space in boardSpaces) // check each individual space for nonumber value
            {
                if (space != "x" && space != "o")
                {
                    boardFull = false;
                }
            }
            if (boardFull == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}