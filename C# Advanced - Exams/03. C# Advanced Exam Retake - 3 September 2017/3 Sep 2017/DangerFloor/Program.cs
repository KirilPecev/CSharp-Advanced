using System;
using System.Linq;

namespace DangerFloor
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] chessBoard = new char[8][];
            GetChessBoard(chessBoard);

            while (true)
            {
                string[] commands = Console.ReadLine().Split('-');
                if (commands[0] == "END")
                {
                    break;
                }

                // current figure
                char figure = commands[0][0];
                int figureRow = int.Parse(commands[0][1].ToString());
                int figureCol = int.Parse(commands[0][2].ToString());

                //where to go
                int rowToGo = int.Parse(commands[1][0].ToString());
                int colToGo = int.Parse(commands[1][1].ToString());

                if (isThereAPieceOnThatSquare(chessBoard, figureRow, figureCol, figure))
                {
                    if (CheckForValidMove(chessBoard, figureRow, figureCol, rowToGo, colToGo, figure))
                    {
                        if (IsInBoard(chessBoard, rowToGo, colToGo))
                        {
                            Move(chessBoard, figureRow, figureCol, rowToGo, colToGo, figure);
                        }
                        else
                        {
                            Console.WriteLine("Move go out of board!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }
                }
                else
                {
                    Console.WriteLine("There is no such a piece!");
                }
            }
        }

        private static void Move(char[][] chessBoard, int figureRow, int figureCol, int rowToGo, int colToGo, char figure)
        {
            chessBoard[figureRow][figureCol] = 'x';
            chessBoard[rowToGo][colToGo] = figure;
        }

        private static bool IsInBoard(char[][] chessBoard, int rowToGo, int colToGo)
        {
            return rowToGo >= 0 && rowToGo < chessBoard.Length && colToGo >= 0 && colToGo < chessBoard[0].Length;
        }

        private static bool CheckForValidMove(char[][] chessBoard, int figureRow, int figureCol, int rowToGo, int colToGo, char figure)
        {
            switch (figure)
            {
                case 'P':
                    if (figureRow - rowToGo == 1)
                    {
                        if (figureCol - colToGo == 0)
                        {
                            return true;
                        }
                    }
                    break;
                case 'Q':
                    return Math.Abs(rowToGo - figureRow) == Math.Abs(colToGo - figureCol) || (figureRow == rowToGo || figureCol == colToGo); ;
                case 'B':
                    if (figureRow - rowToGo != 0 && figureCol - colToGo != 0)
                    {
                        return true;
                    }
                    break;
                case 'R':
                    if (figureRow - rowToGo == 0 && figureCol - colToGo != 0)
                    {
                        return true;
                    }
                    else if (figureRow - rowToGo != 0 && figureCol - colToGo == 0)
                    {
                        return true;
                    }
                    break;
                case 'K':
                    return Math.Max(Math.Abs(rowToGo - figureRow), Math.Abs(colToGo - figureCol)) == 1;
            }

            return false;
        }

        private static bool isThereAPieceOnThatSquare(char[][] chessBoard, int figureRow, int figureCol, char figure)
        {
            if (chessBoard[figureRow][figureCol] != 'x' && chessBoard[figureRow][figureCol] == figure)
            {
                return true;
            }

            return false;
        }

        private static void GetChessBoard(char[][] chessBoard)
        {
            for (int row = 0; row < chessBoard.Length; row++)
            {
                chessBoard[row] = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            }
        }
    }
}
