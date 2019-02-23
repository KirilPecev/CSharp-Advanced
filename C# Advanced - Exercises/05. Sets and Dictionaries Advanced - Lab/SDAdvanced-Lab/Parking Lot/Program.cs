using System;
using System.Collections.Generic;
using System.Linq;

namespace Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingLot = new HashSet<string>();
            while (true)
            {
                string[] input = Console.ReadLine().Split(", ");
                if (input[0] == "END")
                {
                    break;
                }

                string car = input[1];
                switch (input[0])
                {
                    case "IN":
                        parkingLot.Add(car);                       
                        break;
                    case "OUT":
                        parkingLot.Remove(car);
                        break;
                }
            }

            if (parkingLot.Count!=0)
            {
                Console.WriteLine(string.Join("\n", parkingLot));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            
        }
    }
}
