using System;
using System.Linq;

namespace Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndColumns = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            char[,] matrix = new char[rowsAndColumns[0], rowsAndColumns[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] chars = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = chars[column];
                }
            }

            int count = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int column = 0; column < matrix.GetLength(1) - 1; column++)
                {
                    char firstLetter = matrix[row, column];
                    char secondLetter = matrix[row, column + 1];
                    char thirdLetter = matrix[row + 1, column];
                    char fourthLetter = matrix[row + 1, column + 1];

                    if (firstLetter == secondLetter && firstLetter == thirdLetter && firstLetter == fourthLetter)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
