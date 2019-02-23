using System;
using System.Linq;
using System.Collections.Generic;

namespace Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfEachBullet = int.Parse(Console.ReadLine());
            int sizeOfTheGunBarrel = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int valueOfIntelligence = int.Parse(Console.ReadLine());
            int bulletCounter = 0;
            int totalBulletBangs = 0;
            while (true)
            {
                if (bulletCounter == sizeOfTheGunBarrel && bullets.Count != 0)
                {
                    bulletCounter = 0;
                    Console.WriteLine("Reloading!");
                }

                if (locks.Count == 0 || bullets.Count == 0)
                {
                    break;
                }

                int bullet = bullets.Pop();
                bulletCounter++;
                if (bullet <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                totalBulletBangs++;
            }

            if (locks.Count != 0 && bullets.Count == 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                int earned = valueOfIntelligence - totalBulletBangs * priceOfEachBullet;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${earned}");
            }
        }
    }
}
