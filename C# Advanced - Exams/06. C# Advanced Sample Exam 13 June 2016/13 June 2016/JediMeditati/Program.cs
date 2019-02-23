using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JediMeditati
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder masterJedis = new StringBuilder();
            StringBuilder knightJedis = new StringBuilder();
            StringBuilder padawanJedis = new StringBuilder();
            StringBuilder toshkoSlav = new StringBuilder();
            bool isThereYoda = false;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                CollectJedis(Console.ReadLine().Split(' '), masterJedis, knightJedis, padawanJedis, toshkoSlav, ref isThereYoda);
            }

            if (isThereYoda)
            {
                result.Append(masterJedis.ToString() + knightJedis.ToString() + toshkoSlav.ToString() + padawanJedis.ToString());
            }
            else
            {
                result.Append(toshkoSlav.ToString() + masterJedis.ToString() + knightJedis.ToString() + padawanJedis.ToString());
            }

            Console.WriteLine(result);
        }

        private static void CollectJedis(string[] input, StringBuilder masterJedis, StringBuilder knightJedis, StringBuilder padawanJedis, StringBuilder toshkoSlav,  ref bool isThereYoda)
        {
            foreach (var jedi in input)
            {
                switch (jedi[0])
                {
                    case 'm':
                        masterJedis.Append($"{jedi} ");
                        break;
                    case 'k':
                        knightJedis.Append($"{jedi} ");
                        break;
                    case 'p':
                        padawanJedis.Append($"{jedi} ");
                        break;
                    case 't':
                    case 's':
                        toshkoSlav.Append($"{jedi} ");
                        break;
                    case 'y':
                        isThereYoda = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
