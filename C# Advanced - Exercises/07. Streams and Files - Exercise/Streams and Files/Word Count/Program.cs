using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            List<string> words = new List<string>();
            StreamReader readStream;
            string pattern = "([^-,.?!' ]+)";
            using (readStream = new StreamReader(@"..\..\..\..\..\04. Streams-Exercise\words.txt"))
            {
                string line;
                while ((line = readStream.ReadLine()) != null)
                {
                    words.Add(line.ToLower());
                }
            }

            using (readStream = new StreamReader(@"..\..\..\..\..\04. Streams-Exercise\text.txt"))
            {
                string line;
                while ((line = readStream.ReadLine()) != null)
                {
                    MatchCollection matched = Regex.Matches(line, pattern);
                    foreach (var word in matched)
                    {
                        if (words.Contains(word.ToString().ToLower()))
                        {
                            if (!dict.ContainsKey(word.ToString().ToLower()))
                            {
                                dict.Add(word.ToString().ToLower(), 1);
                            }
                            else
                            {
                                dict[word.ToString().ToLower()]++;
                            }
                        }
                    }
                }
            }

            using (var streamWriter = new StreamWriter(@"..\..\..\..\..\04. Streams-Exercise\result.txt"))
            {
                foreach (var word in dict.OrderByDescending(x=>x.Value))
                {
                    streamWriter.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
