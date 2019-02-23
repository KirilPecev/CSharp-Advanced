using System;
using System.Linq;

namespace Matrix_of_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndColumns = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            string[,] matrix = new string[rowsAndColumns[0], rowsAndColumns[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    char firstAndThirdLetter = (char)(row + 97);
                    char secondLetter = (char)(row + column + 97);
                    matrix[row, column] = firstAndThirdLetter.ToString() + secondLetter.ToString() + firstAndThirdLetter.ToString();
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    Console.Write(matrix[row,column] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
