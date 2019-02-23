using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsAndColumns = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rowsAndColumns, rowsAndColumns];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] nums = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = nums[column];
                }
            }

            int primaryDiagonalSum = 0;
            for (int index = 0; index < rowsAndColumns; index++)
            {
                primaryDiagonalSum += matrix[index, index];
            }

            int secondDiagonalSum = 0;
            int rowIndex = 0;
            for (int column = rowsAndColumns - 1; column >= 0; column--)
            {
                secondDiagonalSum += matrix[rowIndex, column];
                rowIndex++;
            }

            Console.WriteLine(Math.Abs(primaryDiagonalSum - secondDiagonalSum));
        }
    }
}
