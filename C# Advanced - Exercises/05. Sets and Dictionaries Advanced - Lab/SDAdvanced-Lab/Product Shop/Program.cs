using System;
using System.Collections.Generic;

namespace Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> dict = new SortedDictionary<string, Dictionary<string, double>>();
            while (true)
            {
                string[] input = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);
                if (input[0]=="Revision")
                {
                    break;
                }

                if (!dict.ContainsKey(input[0]))
                {
                    dict.Add(input[0], new Dictionary<string, double>());
                    dict[input[0]].Add(input[1], double.Parse(input[2]));
                }
                else
                {
                    dict[input[0]].Add(input[1], double.Parse(input[2]));
                }
            }

            foreach (var shop in dict)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in dict[shop.Key])
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
