using System;
using System.Collections.Generic;
using System.Linq;

namespace String_Matrix_Rota
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("(", StringSplitOptions.RemoveEmptyEntries).Select(x => x.TrimEnd(')')).ToArray();

            int degrees = int.Parse(input[1]);
            char[][] jaggedArray = InitializeArray();

            if (degrees % 360 == 0)
            {
                PrintArray0Degrees(jaggedArray);
            }
            else if (degrees % 360 == 90)
            {
                PrintArray90Degrees(jaggedArray);
            }
            else if (degrees % 360 == 180)
            {
                PrintArray180Degrees(jaggedArray);
            }
            else if (degrees % 360 == 270)
            {
                PrintArray270Degrees(jaggedArray);
            }

        }

        private static void PrintArray270Degrees(char[][] jaggedArray)
        {
            for (int col = jaggedArray[0].Length - 1; col >= 0; col--)
            {
                for (int row = 0; row < jaggedArray.Length; row++)
                {
                    Console.Write(jaggedArray[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void PrintArray90Degrees(char[][] jaggedArray)
        {
            for (int col = 0; col < jaggedArray[0].Length; col++)
            {
                for (int row = jaggedArray.Length - 1; row >= 0; row--)
                {
                    Console.Write(jaggedArray[row][col]);
                }

                Console.WriteLine();
            }
        }

        private static void PrintArray180Degrees(char[][] jaggedArray)
        {
            for (int row = jaggedArray.Length - 1; row >= 0; row--)
            {
                for (int col = jaggedArray[row].Length - 1; col >= 0; col--)
                {
                    Console.Write(jaggedArray[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void PrintArray0Degrees(char[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                Console.WriteLine(string.Join("", jaggedArray[row]));
            }
        }

        private static char[][] InitializeArray()
        {
            List<string> words = new List<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                words.Add(input);
            }

            int len = words.Select(x => x.Length).Max();
            for (int i = 0; i < words.Count; i++)
            {
                string currentWord = words[i];
                while (currentWord.Length < len)
                {
                    currentWord += ' ';
                }

                words[i] = currentWord;
            }

            char[][] jaggedArray = new char[words.Count][];
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = words[row].ToCharArray();
            }

            return jaggedArray;
        }
    }
}
