using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Cubic_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder decrypted = new StringBuilder();
            while (input != "Over!")
            {
                int lenOfTheMessage = int.Parse(Console.ReadLine());

                string pattern = $"^[0-9]+(?<text>[A-Za-z]+)([^A-Za-z]*)$";

                if (Regex.Match(input, pattern).Success && Regex.Match(input, pattern).Groups["text"].Value.Length == lenOfTheMessage)
                {
                    Queue<int> nums = new Queue<int>();

                    foreach (var c in input)
                    {
                        if (c >= '0' && c <= '9')
                        {
                            nums.Enqueue(c - 48);
                        }
                    }

                    string text = Regex.Match(input, pattern).Groups["text"].Value;
                    for (int i = 0; i < nums.Count; i++)
                    {
                        int index = nums.Dequeue();
                        i--;
                        if (IsInside(text, index))
                        {
                            decrypted.Append(text[index]);
                        }
                        else
                        {
                            decrypted.Append(" ");
                        }
                    }

                    Console.WriteLine($"{Regex.Match(input, pattern).Groups["text"].Value} == {decrypted}");
                    decrypted.Clear();
                }

                input = Console.ReadLine();
            }
        }

        private static bool IsInside(string text, int index)
        {
            return index >= 0 && index < text.Length;
        }
    }
}
