using System;
using System.Linq;

namespace Group_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] sizes = new int[3];

            foreach (var num in nums)
            {
                sizes[Math.Abs(num % 3)]++;
            }

            int[][] jaggedArray = new int[3][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = new int[sizes[row]];
            }

            int[] indexes = new int[3];

            foreach (var num in nums)
            {
                int remainder = Math.Abs(num % 3);
                jaggedArray[remainder][indexes[remainder]] = num;
                indexes[remainder]++;
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine(string.Join(" ",jaggedArray[i]));
            }
        }
    }
}
