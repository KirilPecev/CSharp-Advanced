using System;
using System.Collections;
using System.Collections.Generic;

namespace DecimalToBinaryConv
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            if (input == 0)
            {
                Console.WriteLine(0);
                return;
            }

            while (input > 0)
            {
                int remainder = input % 2;
                stack.Push(remainder);
                input /= 2;
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }
    }
}
