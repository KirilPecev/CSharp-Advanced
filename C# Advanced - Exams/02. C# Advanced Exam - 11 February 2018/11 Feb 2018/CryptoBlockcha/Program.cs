using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CryptoBlockcha
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\[[^\[\]{}]*?([0-9]{3,})[^\[\]{}]*?\]|{[^{}\]\[]*?([0-9]{3,})[^{}\]\[]*?}";
            int n = int.Parse(Console.ReadLine());
            string cryptoBlockchain = null;
            for (int i = 0; i < n; i++)
            {
                cryptoBlockchain += Console.ReadLine();
            }

            string decrypted = null;
            List<int> numbers = new List<int>();
            MatchCollection matched = Regex.Matches(cryptoBlockchain, pattern);
            foreach (Match m in matched)
            {
                string num = m.Groups[2].Value;
                if (num == "")
                {
                    num = m.Groups[1].Value;
                }

                string splitedNum = null;
                int counter = 0;
                for (int i = 0; i < num.Length; i++)
                {
                    splitedNum += num[i];
                    counter++;
                    if (counter == 3)
                    {
                        numbers.Add(int.Parse(splitedNum));
                        counter = 0;
                        splitedNum = null;
                    }
                }

                numbers = numbers.Select(x => x - m.Length).ToList();

                for (int i = 0; i < numbers.Count; i++)
                {
                    decrypted += (char)numbers[i];
                }

                numbers.Clear();
            }

            Console.WriteLine(decrypted);
        }
    }
}
