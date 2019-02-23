using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoMast
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
               .Split(new[] { ", " },
                   StringSplitOptions.RemoveEmptyEntries)
               .Select(long.Parse)
               .ToList();

            long seqLength = nums.Count;
            long maxLength = 0;

            for (int step = 1; step < seqLength; step++)
            {
                for (int stNode = 0; stNode < seqLength; stNode++)
                {
                    var localMax = 1;

                    var currentElementIndex = stNode;
                    var nextElementIndex = (currentElementIndex + step) % nums.Count;

                    while (nums[nextElementIndex] > nums[currentElementIndex])
                    {
                        localMax++;

                        currentElementIndex = nextElementIndex;
                        nextElementIndex = (currentElementIndex + step) % nums.Count;
                    }

                    if (maxLength < localMax)
                    {
                        maxLength = localMax;
                    }
                }
            }

            Console.WriteLine(maxLength);
        }
    }
}
