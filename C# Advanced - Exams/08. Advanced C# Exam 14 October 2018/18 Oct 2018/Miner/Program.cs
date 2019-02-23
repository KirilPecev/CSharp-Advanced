using System;
using System.Linq;

namespace Miner
{
    class Program
    {
        public static int minerRow;
        public static int minerCol;
        public static int totalCoal;
        public static int currentCoal = 0;
        public static bool gameOver = false;

        static void Main(string[] args)
        {
            int dimension = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split();
            char[][] field = new char[dimension][];
            GetField(field);

            foreach (var command in commands)
            {
                if (!gameOver)
                {
                    Move(field, command);
                }
            }

            if (!gameOver)
            {
                Console.WriteLine($"{totalCoal - currentCoal} coals left. ({minerRow}, {minerCol})");
            }
           
        }

        private static void Move(char[][] field, string command)
        {
            bool hasTurn = false;
            switch (command)
            {
                case "up":
                    if (IsInside(minerRow - 1, minerCol, field))
                    {
                        minerRow--;
                        hasTurn = true;
                    }
                    break;
                case "down":
                    if (IsInside(minerRow + 1, minerCol, field))
                    {
                        minerRow++;
                        hasTurn = true;
                    }
                    break;
                case "right":
                    if (IsInside(minerRow, minerCol + 1, field))
                    {
                        minerCol++;
                        hasTurn = true;
                    }
                    break;
                case "left":
                    if (IsInside(minerRow, minerCol - 1, field))
                    {
                        minerCol--;
                        hasTurn = true;
                    }
                    break;
            }

            if (hasTurn)
            {
                if (field[minerRow][minerCol] == 'c')
                {
                    field[minerRow][minerCol] = '*';
                    currentCoal++;
                }

                if (currentCoal == totalCoal)
                {
                    Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                    gameOver = true;
                    return;
                }

                if (field[minerRow][minerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                    gameOver = true;
                }
            }
        }

        private static bool IsInside(int minerRow, int minerCol, char[][] field)
        {
            return minerRow >= 0 && minerRow < field.Length && minerCol >= 0 && minerCol < field.Length;
        }

        private static void GetField(char[][] field)
        {
            for (int row = 0; row < field.Length; row++)
            {
                field[row] = Console.ReadLine().Split().Select(char.Parse).ToArray();
                if (field[row].Contains('s'))
                {
                    minerRow = row;
                    minerCol = Array.IndexOf(field[row], 's');
                }

                if (field[row].Contains('c'))
                {
                    for (int i = 0; i < field[row].Length; i++)
                    {
                        if (field[row][i] == 'c')
                        {
                            totalCoal++;
                        }
                    }
                }
            }
        }
    }
}
