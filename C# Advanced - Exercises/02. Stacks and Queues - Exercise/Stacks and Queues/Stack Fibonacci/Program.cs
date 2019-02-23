using System;
using System.Collections.Generic;

namespace Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<ulong> stack = new Stack<ulong>();
            stack.Push(0);
            stack.Push(1);
            for (int i = 0; i < n-1; i++)
            {
                ulong currentNum = stack.Pop();
                ulong num = stack.Peek();
                stack.Push(currentNum);
                stack.Push(currentNum + num);
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
