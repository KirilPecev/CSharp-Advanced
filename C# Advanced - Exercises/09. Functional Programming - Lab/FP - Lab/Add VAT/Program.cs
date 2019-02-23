using System;
using System.Linq;

namespace Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, double> parser = x => double.Parse(x);
            var nums = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(parser);
            Func<double, double> addVAT = x => x * 1.2;
            nums.Select(addVAT).ToList().ForEach(x => Console.WriteLine($"{x:f2}"));
        }
    }
}
