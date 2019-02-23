using System;
using System.Linq;

namespace Square_With_Max_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndColumns = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[rowsAndColumns[0], rowsAndColumns[1]];
            int currentSum = int.MinValue;

            for (int rowsCount = 0; rowsCount < matrix.GetLength(0); rowsCount++)
            {
                int[] nums = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int columnsCount = 0; columnsCount < matrix.GetLength(1); columnsCount++)
                {
                    matrix[rowsCount, columnsCount] = nums[columnsCount];
                }
            }

            int tempSum = 0;
            int currentRow = 0;
            int currentColumn = 0;
            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int columns = 0; columns < matrix.GetLength(1) - 1; columns++)
                {
                    tempSum = matrix[rows, columns] + matrix[rows, columns + 1] + matrix[rows + 1, columns] + matrix[rows + 1, columns + 1];
                    if (tempSum > currentSum)
                    {
                        currentSum = tempSum;
                        currentRow = rows;
                        currentColumn = columns;
                    }
                }
            }

            Console.WriteLine($"{matrix[currentRow,currentColumn]} {matrix[currentRow,currentColumn+1]}");
            Console.WriteLine($"{matrix[currentRow+1,currentColumn]} {matrix[currentRow+1,currentColumn+1]}");
            Console.WriteLine(currentSum);
        }
    }
}
