using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[][] bunniesLair = new char[dimensions[0]][];
            int playerRow = 0;
            int playerCol = 0;

            InitializeBunniesLair(bunniesLair);
            for (int row = 0; row < bunniesLair.Length; row++)
            {
                if (bunniesLair[row].Contains('P'))
                {
                    playerRow = row;
                    playerCol = Array.IndexOf(bunniesLair[row], 'P');
                    bunniesLair[playerRow][playerCol] = '.';
                }
            }

            string directions = Console.ReadLine();
            foreach (var move in directions)
            {
                int oldPlayerRow = playerRow;
                int oldPlayerCol = playerCol;
                switch (move)
                {
                    case 'U': playerRow--; break;
                    case 'D': playerRow++; break;
                    case 'L': playerCol--; break;
                    case 'R': playerCol++; break;
                }

                bunniesLair = SpreadBunnies(bunniesLair, dimensions[0] - 1, dimensions[1] - 1);

                if (playerRow < 0 || playerRow >= dimensions[0] || playerCol < 0 || playerCol >= dimensions[1])
                {
                    PrintArray(bunniesLair);
                    Console.WriteLine($"won: {oldPlayerRow} {oldPlayerCol}");
                    return;
                }

                if (bunniesLair[playerRow][playerCol] == 'B')
                {
                    PrintArray(bunniesLair);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    return;
                }
            }

        }

        private static void PrintArray(char[][] bunniesLair)
        {
            for (int row = 0; row < bunniesLair.Length; row++)
            {
                Console.WriteLine(string.Join(null, bunniesLair[row]));
            }
        }

        private static char[][] SpreadBunnies(char[][] bunniesLair, int rows, int cols)
        {
            char[][] newLair = new char[bunniesLair.Length][];
            for (int row = 0; row < bunniesLair.Length; row++)
            {
                newLair[row] = (char[])bunniesLair[row].Clone();
            }

            for (int row = 0; row <= rows; row++)
            {
                for (int col = 0; col <= cols; col++)
                {
                    if (bunniesLair[row][col] == 'B')
                    {
                        if (row > 0) newLair[row - 1][col] = 'B';
                        if (row < rows) newLair[row + 1][col] = 'B';
                        if (col > 0) newLair[row][col - 1] = 'B';
                        if (col < cols) newLair[row][col + 1] = 'B';
                    }
                }
            }

            return newLair;
        }

        private static void InitializeBunniesLair(char[][] bunniesLair)
        {
            for (int row = 0; row < bunniesLair.Length; row++)
            {
                bunniesLair[row] = Console.ReadLine().ToCharArray();
            }
        }
    }
}
