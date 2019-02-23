using System;
using System.Collections.Generic;

namespace BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> openParentheses = new Stack<char>();

            if (input.Length % 2 == 1)
            {
                Console.WriteLine("NO");
                return;
            }

            foreach (char c in input)
            {
                switch (c)
                {
                    case '(':
                    case '{':
                    case '[':
                        openParentheses.Push(c);
                        break;
                    default:
                        if ((c == ')' || c == '}' || c == ']') && openParentheses.Count > 0)
                        {
                            if (openParentheses.Peek() == '(' && c == ')' || openParentheses.Peek() == '{' && c == '}' || openParentheses.Peek() == '[' && c == ']')
                            {
                                openParentheses.Pop();
                            }
                            else
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        break;
                }
            }
            Console.WriteLine("YES");

        }
    }
}
