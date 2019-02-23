using System;
using System.Linq;

namespace Cubic_s_Rube
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimension = int.Parse(Console.ReadLine());
            long allCells = (int)Math.Pow(dimension, 3);
            long sum = 0;

            string input = Console.ReadLine();
            int count = 0;
            while (input != "Analyze")
            {
                var bombardingData = input.Split().Select(int.Parse).ToArray();

                if (bombardingData[0] >= 0 && bombardingData[0] < dimension &&
                    bombardingData[1] >= 0 && bombardingData[1] < dimension &&
                    bombardingData[2] >= 0 && bombardingData[2] < dimension &&
                    bombardingData[3] != 0)
                {
                    sum += bombardingData[3];
                    allCells--;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(sum);
            Console.WriteLine(allCells);
        }

    }
}
