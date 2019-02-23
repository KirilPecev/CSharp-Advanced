using System;
using System.Linq;

namespace Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split();
            Action<string> printer = x => Console.WriteLine(x);
            list.ToList().ForEach(printer);
        }
    }
}
