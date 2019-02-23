using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            var departments = new Dictionary<string, List<string>>();
            var doctors = new Dictionary<string, List<string>>();
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "Output")
                {
                    break;
                }

                string department = input[0];
                string doctor = input[1] + " " + input[2];
                string patient = input[3];

                if (!departments.ContainsKey(department))
                {
                    departments[department] = new List<string>();
                }

                departments[department].Add(patient);
                if (!doctors.ContainsKey(doctor))
                {
                    doctors[doctor] = new List<string>();
                }

                doctors[doctor].Add(patient);
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "End")
                {
                    break;
                }

                if (input.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", departments[input[0]]));
                }
                else if (int.TryParse(input[1], out int result))
                {
                    if (int.Parse(input[1]) > 20)
                    {
                        continue;
                    }

                    var patients = departments[input[0]];
                    var room = patients.Skip(3 * (int.Parse(input[1]) - 1)).Take(3).OrderBy(p => p);

                    Console.WriteLine(string.Join("\n", room));
                }
                else
                {
                    var pat = doctors[input[0] + " " + input[1]];
                    pat.Sort();
                    Console.WriteLine(string.Join("\n", pat));
                }
            }
        }
    }
}

