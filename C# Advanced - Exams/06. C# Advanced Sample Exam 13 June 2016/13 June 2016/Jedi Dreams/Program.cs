using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Jedi_Dreams
{
    class Program
    {
        static void Main(string[] args)
        {
            string methodDeclarations = @"static\s+.*\s+(?<name>[a-zA-Z]*[A-Z][a-zA-Z]*)\s*\(";
            string inlineMethods = @"(?<name>[a-zA-Z]*[A-Z][a-zA-Z]*)\s*\(";

            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            List<string> lines = new List<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                lines.Add(Console.ReadLine());
            }

            string lastOpenMethod = string.Empty;
            for (int i = 0; i < lines.Count; i++)
            {
                string line = lines[i];
                Match declaration = Regex.Match(line, methodDeclarations);
                if (declaration.Success)
                {
                    dict.Add(declaration.Groups["name"].Value, new List<string>());
                    lastOpenMethod = declaration.Groups["name"].Value;
                }

                MatchCollection inlineMethod = Regex.Matches(line, inlineMethods);
                foreach (Match match in inlineMethod)
                {
                    if (lastOpenMethod!= match.Groups["name"].Value)
                    {
                        dict[lastOpenMethod].Add(match.Groups["name"].Value);
                    }                   
                }
            }

            foreach (var method in dict.OrderByDescending(x=>x.Value.Count()).ThenBy(x=>x.Key))
            {
                foreach (var m in method.Value)
                {
                    Console.WriteLine($"{method.Key} -> {method.Value.Count} -> {string.Join(", ",method.Value.OrderBy(x=>x))}");
                    break;
                }
            }
        }
    }
}
