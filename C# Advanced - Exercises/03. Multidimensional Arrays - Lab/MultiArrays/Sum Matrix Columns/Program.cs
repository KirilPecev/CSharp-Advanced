using System;
using System.Linq;

namespace Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndColumns = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[rowsAndColumns[0], rowsAndColumns[1]];
            int sum = 0;

            for (int rowsCount = 0; rowsCount < matrix.GetLength(0); rowsCount++)
            {
                int[] nums = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int columnsCount = 0; columnsCount < matrix.GetLength(1); columnsCount++)
                {
                    matrix[rowsCount, columnsCount] = nums[columnsCount];
                }
            }

            for (int columns = 0; columns < matrix.GetLength(1); columns++)
            {
                sum = 0;
                for (int rows = 0; rows < matrix.GetLength(0); rows++)
                {
                    sum += matrix[rows, columns];
                }

                Console.WriteLine(sum);
            }
        }
    }
}
