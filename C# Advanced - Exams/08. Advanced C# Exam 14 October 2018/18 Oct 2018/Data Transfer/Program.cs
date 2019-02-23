using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Data_Transfer
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^s:(?<sender>[^;]*);?r:(?<receiver>[^;]+);?m--""(?<message>[a-zA-Z\s+]+)""$";
            int totalDataTransfer = 0;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string resultSender = string.Empty;
                string resultReceiver = string.Empty;
                Match m = Regex.Match(line, pattern);
                if (m.Success)
                {
                    string sender = m.Groups["sender"].Value;
                    string receiver = m.Groups["receiver"].Value;
                    string message = m.Groups["message"].Value;

                    totalDataTransfer += Calculate(sender);
                    totalDataTransfer += Calculate(receiver);

                    resultSender = GetName(sender);
                    resultReceiver = GetName(receiver);

                    Console.WriteLine($"{resultSender} says \"{message}\" to {resultReceiver}");
                }

            }

            Console.WriteLine($"Total data transferred: {totalDataTransfer}MB");
        }

        private static string GetName(string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] >= 'a' && str[i] <= 'z') || (str[i] >= 'A' && str[i] <= 'Z') || str[i] == ' ')
                {
                    sb.Append(str[i]);
                }
            }

            return sb.ToString();
        }

        private static int Calculate(string str)
        {
            int data = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= '1' && str[i] <= '9')
                {
                    data += int.Parse(str[i].ToString());
                }
            }

            return data;
        }
    }
}
