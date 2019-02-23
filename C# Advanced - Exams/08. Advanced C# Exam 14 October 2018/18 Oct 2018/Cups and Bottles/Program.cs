using System;
using System.Collections.Generic;
using System.Linq;

namespace Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int wastedWater = 0;
            Queue<int> cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            int bottle = bottles.Pop();
            int cup = cups.Peek();
            bool end = false;

            while (!end)
            {
                if (bottle >= cup)
                {
                    wastedWater += bottle - cup;
                    cups.Dequeue();

                    if (cups.Count > 0)
                    {
                        cup = cups.Peek();
                    }
                    else
                    {
                        end = true;
                        break;
                    }

                    if (bottles.Count > 0)
                    {
                        bottle = bottles.Pop();
                    }
                    else
                    {
                        end = true;
                        break;
                    }

                    continue;
                }

                if (cup > bottle)
                {
                    while (true)
                    {
                        if (cup - bottle > 0)
                        {
                            cup -= bottle;
                            if (bottles.Count > 0)
                            {
                                bottle = bottles.Pop();
                            }
                            else
                            {
                                end = true;
                                break;
                            }

                            continue;
                        }

                        wastedWater += bottle - cup;
                        cups.Dequeue();

                        if (bottles.Count > 0)
                        {
                            bottle = bottles.Pop();
                        }
                        else
                        {
                            end = true;
                            break;
                        }

                        if (cups.Count > 0)
                        {
                            cup = cups.Peek();
                        }
                        else
                        {
                            end = true;
                            break;
                        }

                        break;
                    }
                }
            }

            if (bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else if (cups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
