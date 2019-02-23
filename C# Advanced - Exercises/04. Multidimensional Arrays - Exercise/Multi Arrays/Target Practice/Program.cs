using System;
using System.Linq;

namespace Target_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndColumns = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string snake = Console.ReadLine();
            int[] shotParameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            char[,] matrix = new char[rowsAndColumns[0], rowsAndColumns[1]];

            int impactRow = shotParameters[0];
            int impactColumn = shotParameters[1];
            int radius = shotParameters[2];

            InitializeMatrix(rowsAndColumns[0], rowsAndColumns[1], snake, matrix);

            RadiusOfTheShot(matrix, impactRow, impactColumn, radius);

            Rearrange(matrix);

            PrintMatrix(matrix);

        }

        private static void Rearrange(char[,] matrix)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                {
                    if (matrix[row, col] == ' ')
                    {
                        for (int currentRow = row; currentRow >= 0; currentRow--)
                        {
                            if (matrix[currentRow, col]!=' ')
                            {
                                matrix[row, col] = matrix[currentRow, col];
                                matrix[currentRow, col] = ' ';
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void RadiusOfTheShot(char[,] matrix, int impactRow, int impactColumn, int radius)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (Math.Pow(row-impactRow,2)+Math.Pow(col-impactColumn,2)<=Math.Pow(radius,2))
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
        }
        private static void InitializeMatrix(int rowCount, int columnCount, string snake, char[,] matrix)
        {
            bool startPositionLeft = false;
            int counter = 0;

            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                if (startPositionLeft)
                {
                    for (int column = 0; column < matrix.GetLength(1); column++)
                    {
                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }

                        matrix[row, column] = snake[counter];
                        counter++;
                    }

                    startPositionLeft = false;
                }
                else
                {
                    for (int column = matrix.GetLength(1) - 1; column >= 0; column--)
                    {
                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }

                        matrix[row, column] = snake[counter];
                        counter++;
                    }

                    startPositionLeft = true;
                }
            }
        }
        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    Console.Write(matrix[row, column]);
                }

                Console.WriteLine();
            }
        }
    }
}
