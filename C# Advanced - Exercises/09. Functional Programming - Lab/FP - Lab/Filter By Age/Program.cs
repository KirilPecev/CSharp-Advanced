using System;
using System.Collections.Generic;
using System.Linq;

namespace Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Dictionary<string, int> profile = new Dictionary<string, int>();
            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                string name = input[0];
                int age = int.Parse(input[1]);
                profile.Add(name, age);
            }

            string condition = Console.ReadLine();
            int ageCondition = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> tester = CreateTester(condition, ageCondition);
            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);

            PrintFilteredStudents(profile, tester, printer);
        }

        private static void PrintFilteredStudents(Dictionary<string, int> profile, Func<int, bool> tester, Action<KeyValuePair<string, int>> printer)
        {
            foreach (var person in profile)
            {
                if (tester(person.Value))
                {
                    printer(person);
                }
            }
        }

        private static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return person => Console.WriteLine(person.Key);
                case "age":
                    return person => Console.WriteLine(person.Value);
                case "name age":
                    return person => Console.WriteLine($"{person.Key} - {person.Value}");
                default:
                    return null;
            }
        }

        private static Func<int, bool> CreateTester(string condition, int age)
        {
            switch (condition)
            {
                case "younger":
                    return x => x < age;
                case "older":
                    return x => x >= age;
                default:
                    return null;
            }
        }
    }
}
