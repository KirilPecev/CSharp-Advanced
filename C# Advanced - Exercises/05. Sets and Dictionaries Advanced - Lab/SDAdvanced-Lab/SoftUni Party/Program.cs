using System;
using System.Collections.Generic;

namespace SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> VIPGuests = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();

            string input = Console.ReadLine();
            while (input != "PARTY")
            {
                if (input[0] >= 48 && input[0] <= 57 && input.Length == 8)
                {
                    VIPGuests.Add(input);
                }
                else
                {
                    regularGuests.Add(input);
                }


                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "END")
            {
                if (input[0] >= 48 && input[0] <= 57 && input.Length == 8)
                {
                    VIPGuests.Remove(input);
                }
                else
                {
                    regularGuests.Remove(input);
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(VIPGuests.Count + regularGuests.Count);
            if (VIPGuests.Count != 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, VIPGuests));
            }

            if (regularGuests.Count != 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, regularGuests));
            }

        }
    }
}
