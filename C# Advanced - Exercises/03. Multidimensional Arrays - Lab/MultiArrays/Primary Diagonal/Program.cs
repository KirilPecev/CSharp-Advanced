using System;
using System.Linq;

namespace Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsAndColumns = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rowsAndColumns, rowsAndColumns];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    matrix[rows, columns] = nums[columns];
                }
            }

            int sum = 0;

            for (int index = 0; index < rowsAndColumns; index++)
            {
                sum += matrix[index, index];
            }

            Console.WriteLine(sum);
        }
    }
}
