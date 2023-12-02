using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    internal class Day1
    {
        public static void Day1A()
        {
            List<string> fileData = File.ReadAllLines(@"C:\AdventOfCode2023\challenge.txt").ToList();
            int tot = 0;
            foreach (string line in fileData)
            {
                // Get the chars that are digits
                List<char> chars = line.ToCharArray().Where(x => char.IsDigit(x)).ToList();
                // Only the first and last
                string numString = chars[0].ToString() + chars[chars.Count - 1].ToString();
                int num = int.Parse(numString);
                tot += num;
            }
            Console.WriteLine(tot);
        }

        public static void Day1B()
        {
            List<string> fileData = File.ReadAllLines(@"C:\AdventOfCode2023\challenge.txt").ToList();
            int tot = 0;
            foreach (string line in fileData)
            {
                // First num
                int firstNum = -1;
                for (int j = 0; j <= line.Length; j++)
                {
                    firstNum = FindNum(line.Substring(0, j));
                    if (firstNum != -1)
                    {
                        break;
                    }
                }

                // Last Num
                int lastNum = -1;
                for (int j = 0; j <= line.Length; j++)
                {
                    lastNum = FindNum(line.Substring(line.Length - j, j));
                    if (lastNum != -1)
                    {
                        break;
                    }
                }

                // Convert them to a string representation
                string numString = firstNum + "" + lastNum;

                // And get the numerical value of it
                int num = int.Parse(numString);
                tot += num;
            }
            Console.WriteLine(tot);
        }

        static int FindNum(string input)
        {
            // Check for numerics
            List<char> chars = input.ToCharArray().Where(x => char.IsDigit(x)).ToList();
            if (chars.Any())
            {
                char firstChar = chars[0];
                return int.Parse(firstChar.ToString());
            }

            // Check for word version
            // This technically doesn't work given the example as I hadn't coded in the xteen's, but my final data set didn't have any
            Dictionary<string, int> wordNumbers = new Dictionary<string, int>()
            {
                {"one", 1},
                {"two", 2},
                {"three", 3},
                {"four", 4},
                {"five", 5},
                {"six", 6},
                {"seven", 7},
                {"eight", 8},
                {"nine", 9}
            };

            foreach (var item in wordNumbers)
            {
                if (input.Contains(item.Key))
                {
                    return item.Value;
                }
            }

            // Nothing - Continue loop
            return -1;
        }
    }

}
