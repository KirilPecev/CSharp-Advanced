using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Queue_Oper
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] NSX = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string[] nums = Console.ReadLine().Split(' ');
            Queue<string> queue = new Queue<string>(nums);

            for (int i = 0; i < NSX[1]; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(NSX[2].ToString()))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
