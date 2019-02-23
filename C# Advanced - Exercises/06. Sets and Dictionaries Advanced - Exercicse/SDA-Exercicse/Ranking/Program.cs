using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        private static object contest;

        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> candidates = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            while (input != "end of contests")
            {
                string[] info = input.Split(':');
                if (!contests.ContainsKey(info[0]))
                {
                    contests.Add(info[0], info[1]);
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "end of submissions")
            {
                string[] info = input.Split("=>");
                string currentContest = info[0];
                string contestPassword = info[1];
                string candidateName = info[2];
                int points = int.Parse(info[3]);

                if (!candidates.ContainsKey(candidateName))
                {
                    if (contests.ContainsKey(currentContest) && contests[currentContest] == contestPassword)
                    {
                        candidates.Add(candidateName, new Dictionary<string, int>());
                        candidates[candidateName].Add(currentContest, points);
                    }
                }
                else
                {
                    if (contests.ContainsKey(currentContest) && contests[currentContest] == contestPassword)
                    {
                        if (!candidates[candidateName].ContainsKey(currentContest))
                        {
                            candidates[candidateName].Add(currentContest, points);
                        }
                        else
                        {
                            if (candidates[candidateName][currentContest] < points)
                            {
                                candidates[candidateName][currentContest] = points;
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            BestUser(candidates);

            Console.WriteLine($"Ranking: ");
            foreach (var candidate in candidates.OrderBy(x=>x.Key))
            {
                Console.WriteLine(candidate.Key);
                foreach (var contest in candidates[candidate.Key].OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }

        private static void BestUser(Dictionary<string, Dictionary<string, int>> candidates)
        {
            foreach (var candidate in candidates.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine($"Best candidate is {candidate.Key} with total {candidates[candidate.Key].Values.Sum()} points.");
                return;
            }
        }
    }
}
