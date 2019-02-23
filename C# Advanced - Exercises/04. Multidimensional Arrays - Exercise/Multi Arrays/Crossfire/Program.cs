using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            List<List<int>> matrix = new List<List<int>>();

            GetMatrix(matrix, rows, cols);

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Nuke it from orbit")
                {
                    break;
                }

                int[] destructionPoint = input.Split().Select(int.Parse).ToArray();

                int row = destructionPoint[0];
                int col = destructionPoint[1];
                int radius = destructionPoint[2];

                DestructMatrix(matrix, row, col, radius);
            }

            PrintMatrix(matrix);
        }

        private static void DestructMatrix(List<List<int>> matrix, int targetRow, int targetCol, int radius)
        {
            for (int row = targetRow - radius; row <= targetRow + radius; row++)
            {
                if (IsInside(matrix, row, targetCol))
                {
                    matrix[row][targetCol] = 0;
                }
            }

            for (int col = targetCol - radius; col <= targetCol + radius; col++)
            {
                if (IsInside(matrix, targetRow, col))
                {
                    matrix[targetRow][col] = 0;
                }
            }



            foreach (var currentRow in matrix)
            {
                currentRow.RemoveAll(x => x == 0);
            }

            for (int row = 0; row < matrix.Count; row++)
            {
                if (matrix[row].Count == 0)
                {
                    matrix.RemoveAt(row);
                }
            }
        }


        private static bool IsInside(List<List<int>> matrix, int row, int col)
        {
            return row >= 0 && row < matrix.Count && col >= 0 && col < matrix[row].Count;
        }

        private static void PrintMatrix(List<List<int>> matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void GetMatrix(List<List<int>> matrix, int rows, int cols)
        {
            int counter = 1;
            for (int row = 0; row < rows; row++)
            {
                List<int> currentList = new List<int>();
                for (int col = 0; col < cols; col++)
                {
                    currentList.Add(counter++);
                }
                matrix.Add(currentList);
            }
        }
    }
}
