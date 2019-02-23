using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            int counter = 0;
            Queue<string> cars = new Queue<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                else if (input == "green")
                {
                    int currentGreenLightDuration = greenLightDuration;
                    int currentFreeWindowDuration = freeWindowDuration;
                    for (int i = 0; i < cars.Count; i++)
                    {
                        bool isGreen = false;
                        string car = cars.Peek();
                        Queue<char> currentCar = new Queue<char>(car.ToCharArray());
                        while (currentGreenLightDuration > 0 && currentCar.Count != 0)
                        {
                            currentCar.Dequeue();
                            currentGreenLightDuration--;
                            isGreen = true;
                        }

                        if (isGreen && currentGreenLightDuration == 0 && currentCar.Count > 0)
                        {
                            while (currentFreeWindowDuration > 0 && currentCar.Count != 0)
                            {
                                currentCar.Dequeue();
                                currentFreeWindowDuration--;
                            }
                        }

                        if (isGreen && currentFreeWindowDuration == 0 && currentCar.Count > 0)
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{car} was hit at {currentCar.Dequeue()}.");
                            return;
                        }

                        if (currentCar.Count == 0)
                        {
                            cars.Dequeue();
                            i--;
                            counter++;
                        }
                    }

                }

                if (input!="green")
                {
                    cars.Enqueue(input);

                }

            }

            Console.WriteLine($"Everyone is safe.");
            Console.WriteLine($"{counter} total cars passed the crossroads.");
        }
    }
}
