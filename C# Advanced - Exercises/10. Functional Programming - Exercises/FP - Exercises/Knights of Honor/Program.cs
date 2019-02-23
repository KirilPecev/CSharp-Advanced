using System;
using System.Linq;

namespace Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            Action<string> printer = x => Console.WriteLine($"Sir {x}");
            list.ToList().ForEach(printer);
        }
    }
}
