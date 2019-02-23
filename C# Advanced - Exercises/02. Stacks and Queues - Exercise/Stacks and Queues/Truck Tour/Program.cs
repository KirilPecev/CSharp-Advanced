using System;
using System.Collections.Generic;
using System.Linq;

namespace Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Queue<int> truckTour = new Queue<int>();
            long totalPetrol = 0;
            for (int i = 0; i < N; i++)
            {
                long[] input = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                long amountOfPetrol = input[0];
                long distance = input[1];
                totalPetrol += amountOfPetrol;

                if (totalPetrol >= distance)
                {
                    truckTour.Enqueue(i);
                    totalPetrol -= distance;
                }
                else
                {
                    truckTour.Clear();
                    totalPetrol = 0;
                }
            }

            Console.WriteLine(truckTour.Dequeue());
        }
    }
}
