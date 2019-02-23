using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BasicMarkupLang
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\s*<\s*([a-z]+)\s+(?:value\s*=\s*""\s*(\d+)\s*""\s+)?[a-z]+\s*=\s*""([^""]*)""\s*\/>\s*";

            string line = Console.ReadLine();
            int count = 1;
            while (line != "<stop/>")
            {
                Match match = Regex.Match(line, pattern);
                if (match.Success)
                {
                    string command = match.Groups[1].Value;
                    string word = match.Groups[3].Value;
                   
                    if (command == "repeat")
                    {
                        int times = int.Parse(match.Groups[2].Value);
                        if (times > 0 && word.Length > 0)
                        {
                            for (int i = 0; i < times; i++)
                            {
                                Console.WriteLine($"{count++}. {word}");
                            }
                        }

                        line = Console.ReadLine();
                        continue;
                    }

                    MakeChange(command, word, ref count);
                }

                line = Console.ReadLine();
            }
        }

        private static void MakeChange(string command, string word, ref int count)
        {
            StringBuilder newWord = new StringBuilder();
            switch (command)
            {
                case "inverse":
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] >= 'A' && word[i] <= 'Z')
                        {
                            newWord.Append(word[i].ToString().ToLower());
                        }
                        else if (word[i] >= 'a' && word[i] <= 'z')
                        {
                            newWord.Append(word[i].ToString().ToUpper());
                        }
                    }
                    break;
                case "reverse":
                    if (word.Length > 0)
                    {
                        Console.WriteLine($"{count++}. {string.Join(string.Empty, word.Reverse())}");
                    }
                    return;
            }

            Console.WriteLine($"{count++}. {newWord}");
        }
    }
}
