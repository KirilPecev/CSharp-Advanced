using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            Stack<string> stack = new Stack<string>(input.Reverse());

            while (stack.Count > 1)
            {
                string firstOperand = stack.Pop().ToString();
                string operation = stack.Pop().ToString();
                string secondOperand = stack.Pop().ToString();
                int sum = 0;
                switch (operation)
                {
                    case "+":
                        sum = int.Parse(firstOperand) + int.Parse(secondOperand);
                        break;
                    case "-":
                        sum = int.Parse(firstOperand) - int.Parse(secondOperand);
                        break;
                }

                stack.Push(sum.ToString());
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
