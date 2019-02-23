using System;
using System.Linq;

namespace Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] rowsAndColumns = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[,] matrix = new int[rowsAndColumns[0], rowsAndColumns[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = nums[column];
                }
            }

            int currentSum = 0;
            int currentRow = 0;
            int currentColumn = 0;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                int tempSum = 0;
                for (int column = 0; column < matrix.GetLength(1) - 2; column++)
                {
                    tempSum = matrix[row, column] + matrix[row, column + 1] + matrix[row, column + 2]
                        + matrix[row + 1, column] + matrix[row + 1, column + 1] + matrix[row + 1, column + 2]
                        + matrix[row + 2, column] + matrix[row + 2, column + 1] + matrix[row + 2, column + 2];

                    if (tempSum > currentSum)
                    {
                        currentSum = tempSum;
                        currentRow = row;
                        currentColumn = column;
                    }
                }
            }

            Console.WriteLine($"Sum = {currentSum}");
            Console.WriteLine($"{matrix[currentRow, currentColumn]} {matrix[currentRow, currentColumn + 1]} {matrix[currentRow, currentColumn + 2]}");
            Console.WriteLine($"{matrix[currentRow + 1, currentColumn]} {matrix[currentRow + 1, currentColumn + 1]} {matrix[currentRow + 1, currentColumn + 2]}");
            Console.WriteLine($"{matrix[currentRow + 2, currentColumn]} {matrix[currentRow + 2, currentColumn + 1]} {matrix[currentRow + 2, currentColumn + 2]}");
        }
    }
}
