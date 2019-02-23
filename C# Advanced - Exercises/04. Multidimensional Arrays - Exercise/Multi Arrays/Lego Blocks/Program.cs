using System;
using System.Collections.Generic;
using System.Linq;

namespace Lego_Blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] firstJaggedArray = new int[rows][];
            int[][] secondJaggedArray = new int[rows][];
            int[][] matchedJaggedArray = new int[rows][];

            InitializeArray(firstJaggedArray);
            InitializeArray(secondJaggedArray);

            MatchTheArrays(firstJaggedArray, secondJaggedArray, matchedJaggedArray);

            bool compareArrays = CompareArrays(matchedJaggedArray);

            if (compareArrays)
            {
                for (int row = 0; row < matchedJaggedArray.Length; row++)
                {
                    Console.WriteLine($"[{string.Join(", ",matchedJaggedArray[row])}]");
                }
            }
            else
            {
                int count = 0;
                for (int row = 0; row < matchedJaggedArray.Length; row++)
                {
                    for (int col = 0; col < matchedJaggedArray[row].Length; col++)
                    {
                        count++;
                    }
                }

                Console.WriteLine($"The total number of cells is: {count}");
            }
        }

        private static bool CompareArrays(int[][] matchedJaggedArray)
        {
            for (int row = 0; row < matchedJaggedArray.Length; row++)
            {
                if (matchedJaggedArray[row].Length != matchedJaggedArray[0].Length)
                {
                    return false;
                }
            }

            return true;
        }

        private static void MatchTheArrays(int[][] firstJaggedArray, int[][] secondJaggedArray, int[][] matchedJaggedArray)
        {
            ReverseJaggedArray(secondJaggedArray);
            List<int> currrentRowNums = new List<int>();
            for (int row = 0; row < firstJaggedArray.Length; row++)
            {
                currrentRowNums.AddRange(firstJaggedArray[row]);
                currrentRowNums.AddRange(secondJaggedArray[row]);
                matchedJaggedArray[row] = currrentRowNums.ToArray();
                currrentRowNums.Clear();
            }
        }

        private static void ReverseJaggedArray(int[][] secondJaggedArray)
        {
            for (int row = 0; row < secondJaggedArray.Length; row++)
            {
                secondJaggedArray[row] = secondJaggedArray[row].Reverse().ToArray();
            }
        }

        private static void InitializeArray(int[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
        }
    }
}
