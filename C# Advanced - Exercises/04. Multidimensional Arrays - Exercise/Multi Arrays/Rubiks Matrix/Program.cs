using System;
using System.Linq;

namespace Rubiks_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] rowsAndColumns = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[,] matrix = new int[rowsAndColumns[0], rowsAndColumns[1]];

            GetMatrix(matrix);

            int countOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfCommands; i++)
            {
                string[] commands = Console.ReadLine().Split();
                int rowColIndex = int.Parse(commands[0]);
                int moves = int.Parse(commands[2]);

                switch (commands[1])
                {
                    case "up":                       
                        MoveUp(matrix, rowColIndex, moves % matrix.GetLength(1));
                        break;
                    case "down":
                        MoveDown(matrix, rowColIndex, moves % matrix.GetLength(1));
                        break;
                    case "left":
                        MoveLeft(matrix, rowColIndex, moves % matrix.GetLength(0));
                        break;
                    case "right":
                        MoveRight(matrix, rowColIndex, moves % matrix.GetLength(0));
                        break;
                }
            }

            int counter = 1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col] == counter)
                    {
                        Console.WriteLine("No swap required");
                        counter++;
                    }
                    else
                    {
                        RearangeMatrix(matrix, row, col, counter);
                        counter++;
                    }
                }
            }
        }

        private static void RearangeMatrix(int[,] matrix, int row, int col, int counter)
        {
            for (int targetRow = 0; targetRow < matrix.GetLength(0); targetRow++)
            {
                for (int targetCol = 0; targetCol < matrix.GetLength(1); targetCol++)
                {
                    if (matrix[targetRow,targetCol] == counter)
                    {
                        matrix[targetRow, targetCol] = matrix[row, col];
                        matrix[row, col] = counter;
                        Console.WriteLine($"Swap ({row}, {col}) with ({targetRow}, {targetCol})");
                        return;
                    }
                }
            }
        }

        private static void MoveRight(int[,] matrix, int row, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int lastElement = matrix[row, matrix.GetLength(1) - 1];
                for (int col = matrix.GetLength(1) - 1; col > 0; col--)
                {
                    matrix[row, col] = matrix[row, col - 1];
                }

                matrix[row, 0] = lastElement;
            }
        }

        private static void MoveLeft(int[,] matrix, int row, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int firstElement = matrix[row, 0];
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    matrix[row, col] = matrix[row, col + 1];
                }

                matrix[row, matrix.GetLength(1) - 1] = firstElement;
            }
        }

        private static void MoveDown(int[,] matrix, int col, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int lastElement = matrix[matrix.GetLength(0) - 1, col];
                for (int row = matrix.GetLength(0) - 1; row > 0; row--)
                {
                    matrix[row, col] = matrix[row - 1, col];
                }

                matrix[0, col] = lastElement;
            }
        }

        private static void MoveUp(int[,] matrix, int col, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int firstElement = matrix[0, col];
                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                    matrix[row, col] = matrix[row + 1, col];
                }

                matrix[matrix.GetLength(0) - 1, col] = firstElement;
            }
        }

        private static void GetMatrix(int[,] matrix)
        {
            int num = 1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = num++;
                }
            }
        }
    }
}
