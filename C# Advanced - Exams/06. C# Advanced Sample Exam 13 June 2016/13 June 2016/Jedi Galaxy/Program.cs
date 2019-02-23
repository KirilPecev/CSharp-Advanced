using System;
using System.Linq;

namespace JediGalaxy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[,] galaxy = new int[dimensions[0], dimensions[1]];
            long totalSum = 0;

            GetTheGalaxy(galaxy);

            string input = Console.ReadLine();
            while (input != "Let the Force be with you")
            {
                var ivoPosition = input.Split().Select(int.Parse).ToArray();
                var evilPosition = Console.ReadLine().Split().Select(int.Parse).ToArray();


                DestroyedStars(galaxy, evilPosition);

                totalSum += CollectStart(galaxy, ivoPosition);


                input = Console.ReadLine();
            }

            Console.WriteLine(totalSum);
        }

        private static void DestroyedStars(int[,] galaxy, int[] evilPosition)
        {
            while (evilPosition[0] >= 0 && evilPosition[1] >= 0)
            {
                if (IsInMatrix(galaxy, evilPosition))
                {
                    galaxy[evilPosition[0], evilPosition[1]] = 0;
                }

                evilPosition[0]--;
                evilPosition[1]--;
            }
        }

        private static long CollectStart(int[,] galaxy, int[] ivoPosition)
        {
            var stars = 0L;

            while (ivoPosition[0] >= 0 && ivoPosition[1] < galaxy.GetLength(1))
            {
                if (IsInMatrix(galaxy, ivoPosition))
                {
                    stars += galaxy[ivoPosition[0],ivoPosition[1]];
                }

                ivoPosition[0]--;
                ivoPosition[1]++;
            }

            return stars;
        }

        private static bool IsInMatrix(int[,] matrix, int[] position)
        {
            return position[0] >= 0 && position[1] >= 0 && position[0] < matrix.GetLength(0) && position[1] < matrix.GetLength(1);
        }

        private static void GetTheGalaxy(int[,] galaxy)
        {
            int counter = 0;
            for (int row = 0; row < galaxy.GetLength(0); row++)
            {
                for (int col = 0; col < galaxy.GetLength(1); col++)
                {
                    galaxy[row, col] = counter++;
                }
            }
        }
    }
}
