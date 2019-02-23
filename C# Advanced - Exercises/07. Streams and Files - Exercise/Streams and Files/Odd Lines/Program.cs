using System;
using System.IO;

namespace Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"..\..\..\..\..\04. Streams-Exercise\text.txt"))
            {
                string line;
                int counter = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if (counter++ % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }
    }
}
