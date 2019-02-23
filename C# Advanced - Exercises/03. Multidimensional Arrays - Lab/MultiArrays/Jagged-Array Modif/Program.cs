using System;
using System.Linq;

namespace Jagged_Array_Modif
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                jaggedArray[row] = nums;
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split(' ').ToArray();
                if (commands[0] == "END")
                {
                    break;
                }

                switch (commands[0])
                {
                    case "Add":
                        int row = int.Parse(commands[1]);
                        int index = int.Parse(commands[2]);
                        int value = int.Parse(commands[3]);

                        if (row < 0 || row >= jaggedArray.Length || index>=jaggedArray[row].Length || index<0)
                        {
                            Console.WriteLine("Invalid coordinates");
                            continue;
                        }

                        jaggedArray[row][index] += value;
                        break;
                    case "Subtract":
                        row = int.Parse(commands[1]);
                        index = int.Parse(commands[2]);
                        value = int.Parse(commands[3]);

                        if (row < 0 || row >= jaggedArray.Length || index >= jaggedArray[row].Length || index < 0)
                        {
                            Console.WriteLine("Invalid coordinates");
                            continue;
                        }

                        jaggedArray[row][index] -= value;
                        break;
                }
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                Console.WriteLine(string.Join(" ",jaggedArray[row]));
            }
        }
    }
}
