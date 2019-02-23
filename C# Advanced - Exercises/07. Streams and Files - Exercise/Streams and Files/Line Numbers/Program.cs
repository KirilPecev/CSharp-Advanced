using System;
using System.IO;

namespace Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader readStream = new StreamReader(@"..\..\..\..\..\04. Streams-Exercise\text.txt"))
            {
                using (StreamWriter writeStream = new StreamWriter(@"..\..\..\..\..\04. Streams-Exercise\output.txt"))
                {
                    string line;
                    int counter = 1;
                    while ((line = readStream.ReadLine()) != null)
                    {
                        writeStream.WriteLine($"Line {counter++}:{line}");
                    }
                }
            }
        }
    }
}
