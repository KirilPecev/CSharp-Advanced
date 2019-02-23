using System;
using System.Collections.Generic;

namespace SDA_Exercicse
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            HashSet<string> usernames = new HashSet<string>();
            for (int i = 0; i < count; i++)
            {
                string name = Console.ReadLine();
                usernames.Add(name);
            }

            Console.WriteLine(string.Join("\n", usernames));
        }
    }
}