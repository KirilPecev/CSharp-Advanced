using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> updates = new Stack<string>();
            string text = "";
            updates.Push(text);
            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split(' ').ToArray();
                switch (commands[0])
                {
                    case "1":
                        text += commands[1];
                        updates.Push(text);
                        break;
                    case "2":
                        int countOfLastEl = int.Parse(commands[1]);
                        text = text.Substring(0, text.Length - countOfLastEl);
                        updates.Push(text);
                        break;
                    case "3":
                        int indexForPrint = int.Parse(commands[1]);
                        Console.WriteLine(text[indexForPrint - 1]);
                        break;
                    case "4":
                        updates.Pop();
                        text = updates.Peek();
                        break;
                }
            }
        }
    }
}
