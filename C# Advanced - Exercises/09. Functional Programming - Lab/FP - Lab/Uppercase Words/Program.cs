using System;
using System.Collections.Generic;
using System.Linq;

namespace Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> text = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();
            Func<string, bool> filtered = x => x[0] == x.ToUpper()[0];

            text.Where(filtered).ToList().ForEach(s => Console.WriteLine(s));


        }
    }
}
