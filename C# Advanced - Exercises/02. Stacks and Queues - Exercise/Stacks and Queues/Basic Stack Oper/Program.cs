using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Stack_Oper
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] NSX = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string[] nums = Console.ReadLine().Split(' ');
            Stack<string> stack = new Stack<string>(nums);
           
            for (int i = 0; i < NSX[1]; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(NSX[2].ToString()))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
