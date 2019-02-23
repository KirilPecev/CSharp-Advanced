using System;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            Func<double[], double> minFunc = GetMin;

            double minNumber = minFunc(nums);

            Console.WriteLine(minNumber);
        }

        private static double GetMin(double[] numbers)
        {
            double min = double.MaxValue;

            foreach (var num in numbers)
            {
                if (num < min)
                {
                    min = num;
                }
            }

            return min;
        }
    }
}
