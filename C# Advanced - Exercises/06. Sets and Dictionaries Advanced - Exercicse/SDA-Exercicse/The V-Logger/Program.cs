using System;
using System.Collections.Generic;
using System.Linq;

namespace The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedSet<string>> followers = new Dictionary<string, SortedSet<string>>();
            Dictionary<string, SortedSet<string>> following = new Dictionary<string, SortedSet<string>>();
            while (true)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "Statistics")
                {
                    break;
                }


                switch (input[1])
                {
                    case "joined":
                        if (input.Length == 4)
                        {
                            Join(followers, following, input[0]);
                        }

                        break;
                    case "followed":
                        if (input.Length == 3)
                        {
                            Follow(followers, following, input[0], input[2]);
                        }

                        break;
                }
            }

            Console.WriteLine($"The V-Logger has a total of {followers.Keys.Count} vloggers in its logs.");
            int counter = 1;
            foreach (var vlogger in followers.OrderByDescending(x => x.Value.Count).ThenBy(x => following[x.Key].Count()))
            {
                Console.WriteLine($"{counter}. {vlogger.Key} : {followers[vlogger.Key].Count} followers, {following[vlogger.Key].Count} following");
                if (counter==1)
                {
                    foreach (var follower in followers[vlogger.Key])
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                counter++;
            }
        }

        private static void Follow(Dictionary<string, SortedSet<string>> followers, Dictionary<string, SortedSet<string>> following, string name, string followThisVlogger)
        {
            if (followers.ContainsKey(followThisVlogger) && followThisVlogger != name && followers.ContainsKey(name))
            {
                followers[followThisVlogger].Add(name);
            }

            if (following.ContainsKey(name) && followThisVlogger != name && followers.ContainsKey(followThisVlogger))
            {
                following[name].Add(followThisVlogger);
            }
        }

        private static void Join(Dictionary<string, SortedSet<string>> followers, Dictionary<string, SortedSet<string>> following, string vlogger)
        {
            if (!followers.ContainsKey(vlogger))
            {
                followers.Add(vlogger, new SortedSet<string>());
            }

            if (!following.ContainsKey(vlogger))
            {
                following.Add(vlogger, new SortedSet<string>());
            }
        }
    }
}
