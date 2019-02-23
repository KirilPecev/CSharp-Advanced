using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Jedi_Code_X
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            List<string> lines = new List<string>();
            for (int i = 0; i < n; i++)
            {
                lines.Add(Console.ReadLine());
            }

            string namePat = Console.ReadLine();
            string messPat = Console.ReadLine();

            string namePattern = string.Format("{0}(?<name>[A-Za-z]{{{1}}})(?![A-Za-z])", namePat, namePat.Length);
            string messagePattern = string.Format("{0}(?<message>[A-Za-z0-9]{{{1}}})(?![A-Za-z0-9])", messPat, messPat.Length);

            Queue<string> names = new Queue<string>();
            List<string> messages = new List<string>();

            foreach (var item in lines)
            {
                MatchCollection name = Regex.Matches(item, namePattern);
                MatchCollection message = Regex.Matches(item, messagePattern);
                foreach (Match match in name)
                {
                    names.Enqueue(match.Groups["name"].Value);
                }

                foreach (Match match in message)
                {
                    messages.Add(match.Groups["message"].Value);
                }
            }

            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            if (names.Count != 0)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (names.Count > 0)
                    {
                        string name = names.Dequeue();

                        if (isValid(messages, input[i] - 1))
                        {
                            string message = messages[input[i] - 1];
                            Console.WriteLine($"{name} - {message}");
                        }
                        else
                        {
                            for (int j = i + 1; j < messages.Count; j++)
                            {
                                if (isValid(messages, input[j] - 1))
                                {
                                    string message = messages[input[j] - 1];
                                    Console.WriteLine($"{name} - {message}");
                                }
                            }
                        }
                    }
                }
            }
        }

        private static bool isValid(List<string> messages, int index)
        {
            return index >= 0 && index < messages.Count;
        }
    }
}
