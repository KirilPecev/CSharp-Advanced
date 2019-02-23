using System;
using System.Collections.Generic;

namespace Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int count = 0;
            Queue<string> trafficJam = new Queue<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                if (input!="green")
                {
                    trafficJam.Enqueue(input);
                }
                else
                {
                    int len = Math.Min(trafficJam.Count, N);
                    for (int i = 0; i < len; i++)
                    {
                        Console.WriteLine(trafficJam.Dequeue() + " passed!");
                        count++;
                    }
                }
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
