using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                int[] commands = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                switch (commands[0])
                {
                    case 1:
                        stack.Push(commands[1]);
                        break;
                    case 2:
                        stack.Pop();
                        break;
                    case 3:
                        Console.WriteLine(stack.Max());
                        break;
                }
            }
        }
    }
}
