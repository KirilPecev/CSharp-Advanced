using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace TicketTrouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string location = Console.ReadLine();
            string ticket = Console.ReadLine();
            string pattern = @"((?<opener>\[)|{)(?(opener)[^[\]]*?|[^{}]*?)(?(opener){|\[)" + location +
            @"(?(opener)}|\])(?(opener)[^\[\]]*?|[^{}]*?)(?(opener){|\[)(?<seat>[A-Z][0-9]{1,2})(?(opener)}|\])(?(opener)[^\[\]]*?|[^{}]*?)(?(opener)\]|})";

            // {[^\]}]*?\[(?<trip>[A-Z]{3} [A-Z]{2})\].*?\[(?<seats>[A-Z]{1}[0-9]{1,2})\][^{]*}|\[[^}\]]*?([A-Z]{3} [A-Z]{2})}.*?{([A-Z]{1}[0-9]{1,2})}[^[]*\]

            List<string> seats = new List<string>();
            MatchCollection validTickets = Regex.Matches(ticket, pattern);
            foreach (Match currentTicket in validTickets)
            {
                seats.Add(currentTicket.Groups["seat"].Value);
            }

            if (seats.Count == 2)
            {
                Console.WriteLine($"You are traveling to {location} on seats {seats[0]} and {seats[1]}.");
            }
            else
            {
                for (int i = 0; i < seats.Count; i++)
                {
                    string currentSeat = seats[i].Substring(1, seats[i].Length-1);
                    for (int j = i + 1; j < seats.Count; j++)
                    {
                        if (seats[j].Contains(currentSeat))
                        {
                            Console.WriteLine($"You are traveling to {location} on seats {seats[i]} and {seats[j]}.");
                            return;
                        }
                    }
                }
            }
        }
    }
}
