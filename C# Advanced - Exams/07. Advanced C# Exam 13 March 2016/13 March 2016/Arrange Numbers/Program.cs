using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arrange_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
            Dictionary<string, string> numsNames = new Dictionary<string, string>()
            {
                {"0","zero"},
                {"1","one"},
                {"2","two"},
                {"3","three"},
                {"4","four"},
                {"5","five"},
                {"6","six"},
                {"7","seven"},
                {"8","eight"},
                {"9","nine"}
            };


            Dictionary<string, string> namesNum = new Dictionary<string, string>()
            {
                {"zero","0"},
                {"one","1"},
                {"two","2"},
                {"three","3"},
                {"four","4"},
                {"five","5"},
                {"six","6"},
                {"seven","7"},
                {"eight","8"},
                {"nine","9"}
            };

            List<string> result = new List<string>();
            StringBuilder current = new StringBuilder();
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums[i].Length; j++)
                {
                    string name = numsNames[nums[i][j].ToString()];
                    if (count > 0)
                    {
                        current.Append("-" + name);
                    }
                    else
                    {
                        current.Append(name);
                    }
                    count++;
                }

                result.Add(current.ToString());
                current.Clear();
                count = 0;
            }

            result = result.OrderBy(x => x).ToList();

            List<int> res = new List<int>();
            for (int i = 0; i < result.Count; i++)
            {
                string[] num = result[i].Split('-');
                for (int j = 0; j < num.Length; j++)
                {
                    string currentNum = namesNum[num[j]];
                    current.Append(currentNum);
                }

                res.Add(int.Parse(current.ToString()));
                current.Clear();
            }

            Console.WriteLine(string.Join(", ", res));
        }
    }
}
