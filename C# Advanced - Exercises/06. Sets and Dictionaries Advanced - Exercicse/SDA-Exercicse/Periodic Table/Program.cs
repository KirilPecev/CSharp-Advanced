using System;
using System.Collections.Generic;
using System.Linq;

namespace Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            HashSet<string> periodicTable = new HashSet<string>();
            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split();
                foreach (var element in input)
                {
                    periodicTable.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", periodicTable.OrderBy(x => x)));

        }
    }
}
