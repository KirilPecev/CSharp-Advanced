using System;
using System.Collections.Generic;
using System.Linq;

namespace GreedyTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            long capacityOfTheBag = long.Parse(Console.ReadLine());
            string[] itemsQuantity = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            long totalGoldAmount = 0;
            long totalGemAmount = 0;
            long totalCashAmount = 0;

            Dictionary<string, Dictionary<string, long>> bag = new Dictionary<string, Dictionary<string, long>>();

            bag.Add("Gold", new Dictionary<string, long>());
            bag.Add("Gem", new Dictionary<string, long>());
            bag.Add("Cash", new Dictionary<string, long>());

            for (int i = 0; i < itemsQuantity.Length; i += 2)
            {
                string item = itemsQuantity[i];
                long quantity = long.Parse(itemsQuantity[i + 1]);

                if (capacityOfTheBag >= quantity)
                {
                    if (item.ToLower() == "gold")
                    {
                        if (!bag["Gold"].ContainsKey(item))
                        {
                            bag["Gold"].Add(item, quantity);
                        }
                        else
                        {
                            bag["Gold"][item] += quantity;
                        }

                        totalGoldAmount += quantity;
                        capacityOfTheBag -= quantity;
                    }
                    else if (item.Length >= 4 && item.ToLower().EndsWith("gem"))
                    {
                        if (totalGoldAmount < totalGemAmount + quantity)
                        {
                            continue;
                        }

                        if (!bag["Gem"].ContainsKey(item))
                        {
                            bag["Gem"].Add(item, quantity);
                        }
                        else
                        {
                            bag["Gem"][item] += quantity;
                        }

                        totalGemAmount += quantity;
                        capacityOfTheBag -= quantity;
                    }
                    else if (item.Length == 3)
                    {
                        if (totalGemAmount < totalCashAmount + quantity)
                        {
                            continue;
                        }

                        if (!bag["Cash"].ContainsKey(item))
                        {
                            bag["Cash"].Add(item, quantity);
                        }
                        else
                        {
                            bag["Cash"][item] += quantity;
                        }

                        totalCashAmount += quantity;
                        capacityOfTheBag -= quantity;
                    }
                }
            }

            foreach (var type in bag.OrderByDescending(x => x.Value.Values.Sum(n => n)))
            {
                if (type.Value.Values.Sum(x => x) != 0)
                {
                    Console.WriteLine($"<{type.Key}> ${type.Value.Values.Sum(x => x)}");
                    foreach (var item in type.Value.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                    {
                        if (item.Value != 0)
                        {
                            Console.WriteLine($"##{item.Key} - {item.Value}");
                        }
                    }
                }
            }
        }
    }
}
