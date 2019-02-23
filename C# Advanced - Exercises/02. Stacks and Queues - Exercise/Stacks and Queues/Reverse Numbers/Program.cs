using System;
using System.Collections.Generic;

namespace Reverse_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>(Console.ReadLine().Split());

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop()+" ");
            }

            Console.WriteLine();
        }
    }
}
