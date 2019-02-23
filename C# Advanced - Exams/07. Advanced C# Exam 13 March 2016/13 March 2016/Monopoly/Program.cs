using System;
using System.Linq;

namespace Monopoly
{
    class Program
    {
        public static int playerMoney = 50;
        public static int hotelsCounter = 0;
        public static int turns = 0;
        public static bool position = true;

        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[][] monopoly = new char[dimensions[0]][];
            GetMonopoly(monopoly);

            for (int row = 0; row < monopoly.Length; row++)
            {
                if (position)
                {
                    position = false;

                    for (int col = 0; col < monopoly[row].Length; col++)
                    {
                        Move(monopoly, row, col);
                    }
                }
                else
                {
                    position = true;

                    for (int col = monopoly[row].Length - 1; col >= 0; col--)
                    {
                        Move(monopoly, row, col);
                    }
                }
            }

            Console.WriteLine($"Turns {turns}");
            Console.WriteLine($"Money {playerMoney}");
        }

        private static void Move(char[][] monopoly, int row, int col)
        {

            if (monopoly[row][col] == 'H')
            {
                hotelsCounter++;
                Console.WriteLine($"Bought a hotel for {playerMoney}. Total hotels: {hotelsCounter}.");
                playerMoney = 0;
            }

            if (monopoly[row][col] == 'J')
            {
                Console.WriteLine($"Gone to jail at turn {turns}.");
                turns += 2;
                playerMoney += 10 * hotelsCounter * 2;
            }

            if (monopoly[row][col] == 'S')
            {
                int spentMoney = Math.Min((col + 1) * (row + 1), playerMoney);
                Console.WriteLine($"Spent {spentMoney} money at the shop.");
                if (playerMoney - spentMoney < 0)
                {
                    playerMoney = 0;
                }
                else
                {
                    playerMoney -= spentMoney;
                }
            }

            playerMoney += 10 * hotelsCounter;
            turns++;
        }

        private static void GetMonopoly(char[][] monopoly)
        {
            for (int row = 0; row < monopoly.Length; row++)
            {
                monopoly[row] = Console.ReadLine().ToCharArray();
            }
        }
    }
}
