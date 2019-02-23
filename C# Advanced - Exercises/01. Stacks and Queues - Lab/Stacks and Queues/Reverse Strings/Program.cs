using System;
using System.Collections.Generic;

namespace Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>(input.ToCharArray());
            int len = stack.Count;
            for (int i = 0; i < len; i++)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}
