using System;
using System.Collections.Generic;
using System.Linq;

namespace Movie_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, TimeSpan> films = new Dictionary<string, TimeSpan>();
            string favoriteGenre = Console.ReadLine();
            string favoriteDuration = Console.ReadLine();
            TimeSpan totalPlayListDuration = new TimeSpan();
            while (true)
            {
                string[] information = Console.ReadLine().Split('|');
                if (information[0] == "POPCORN!")
                {
                    break;
                }

                string film = information[0];
                string genre = information[1];
                TimeSpan duration = TimeSpan.Parse(information[2]);
                totalPlayListDuration += duration;

                if (genre == favoriteGenre)
                {
                    if (!films.ContainsKey(film))
                    {
                        films.Add(film, duration);
                    }
                }
            }

            if (favoriteDuration == "Short")
            {
                foreach (var film in films.OrderBy(x => x.Value))
                {
                    Console.WriteLine(film.Key);
                    string command = Console.ReadLine();
                    if (command == "Yes")
                    {
                        Console.WriteLine($"We're watching {film.Key} - {film.Value}");
                        break;
                    }
                }
            }
            else if (favoriteDuration == "Long")
            {
                foreach (var film in films.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine(film.Key);
                    string command = Console.ReadLine();
                    if (command == "Yes")
                    {
                        Console.WriteLine($"We're watching {film.Key} - {film.Value}");
                        break;
                    }
                }
            }

            Console.WriteLine($"Total Playlist Duration: {totalPlayListDuration}");
        }
    }
}
