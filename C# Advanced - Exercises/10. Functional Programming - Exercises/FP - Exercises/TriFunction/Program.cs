using System;
using System.Collections.Generic;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int characterSum = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<string, int, bool> validWord = (name, num) => name.ToCharArray().Select(c => (int)c).Sum() >= num;

            Func<List<string>, int, Func<string, int, bool>, string> firstValidName = (list, num, func) =>
              list.FirstOrDefault(s => func(s, num));

            string result = firstValidName(names, characterSum, validWord);
            Console.WriteLine(result);
        }
    }
}
