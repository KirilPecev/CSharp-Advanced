using System;

namespace Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            long[][] jaggedArray = new long[rows][];
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                jaggedArray[i] = new long[i + 1];
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row][0] = 1;
                jaggedArray[row][jaggedArray[row].Length - 1] = 1;
            }

            for (int row = 1; row < jaggedArray.Length-1; row++)
            {
                for (int index = 0; index < jaggedArray[row].Length-1; index++)
                {
                    long num = jaggedArray[row][index] + jaggedArray[row][index + 1];
                    jaggedArray[row + 1][index+1] = num;
                }
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[i]));
            }
        }
    }
}
