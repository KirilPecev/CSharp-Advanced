using System;
using System.Collections.Generic;

namespace Sequence_With_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            long N = long.Parse(Console.ReadLine());
            Queue<long> numbers = new Queue<long>();
            Queue<long> SNumbers = new Queue<long>();

            numbers.Enqueue(N);
            SNumbers.Enqueue(N);

            int count = 2;
            for (int i = 1; i < 50; i++)
            {
                if (count == 2)
                {
                    long currentS = SNumbers.Peek();
                    long num = currentS + 1;
                    numbers.Enqueue(num);
                    SNumbers.Enqueue(num);
                }
                else if (count == 3)
                {
                    long currentS = SNumbers.Peek();
                    long num = 2 * currentS + 1;
                    numbers.Enqueue(num);
                    SNumbers.Enqueue(num);
                }
                else
                {
                    long currentS = SNumbers.Peek();
                    long num = currentS + 2;
                    numbers.Enqueue(num);
                    SNumbers.Enqueue(num);
                    SNumbers.Dequeue();
                    count = 1;
                }

                count++;
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
