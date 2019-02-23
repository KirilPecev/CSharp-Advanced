using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsofElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine().Split().Select(int.Parse).ToArray();
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            for (int i = 0; i < dimension[0]; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < dimension[1]; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            foreach (var num in firstSet)
            {
                if (secondSet.Contains(num))
                {
                    Console.Write(num + " ");
                }
            }

            Console.WriteLine();
        }
    }
}
