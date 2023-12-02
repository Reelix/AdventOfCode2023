using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    internal class Day2
    {
        public static void Day2A()
        {
            List<string> fileData = File.ReadAllLines(@"C:\AdventOfCode2023\input.txt").ToList();
            int totIds = 0;
            int gameId = 1;

            // Iterate through all games
            foreach (string line in fileData)
            {
                bool isValid = true;

                // Remove the game text
                string cubes = line.Remove(0, line.IndexOf(":") + 2);

                // Iterate through each set
                List<string> setList = cubes.Split(';').ToList();
                foreach (string set in setList)
                {
                    int red = 0;
                    int green = 0;
                    int blue = 0;
                    List<string> cubeSet = set.Split(' ').ToList();
                    cubeSet = cubeSet.Where(x => x != "").ToList();

                    // Count the number of cubes per set
                    for (int j = 0; j < cubeSet.Count; j += 2)
                    {
                        int count = int.Parse(cubeSet[j]);
                        string cubeColor = cubeSet[j + 1];
                        if (cubeColor.Contains("red"))
                        {
                            red += count;
                        }
                        else if (cubeColor.Contains("green"))
                        {
                            green += count;
                        }
                        else if (cubeColor.Contains("blue"))
                        {
                            blue += count;
                        }
                    }

                    // If a set contains too many of a single cube type, it's invalid
                    if (red > 12 || green > 13 || blue > 14)
                    {
                        isValid = false;
                    }
                }

                // If the set is valid, add it to the total
                if (isValid)
                {
                    totIds += gameId;
                }

                // The games are sequential, so no need to calculate the ID each time
                gameId++; 
            }
            Console.WriteLine(totIds);
        }

        public static void Day2B()
        {
            List<string> fileData = File.ReadAllLines(@"C:\AdventOfCode2023\input.txt").ToList();
            int totPower = 0;

            // Iterate through all games
            foreach (string line in fileData)
            {
                int minRed = 0;
                int minGreen = 0;
                int minBlue = 0;
                bool isValid = true;

                // Remove the game text
                string cubes = line.Remove(0, line.IndexOf(":") + 2);

                // Iterate through each set
                List<string> setList = cubes.Split(';').ToList();
                foreach (string set in setList)
                {
                    List<string> cubeSet = set.Split(' ').ToList();
                    cubeSet = cubeSet.Where(x => x != "").ToList();

                    // Count the number of cubes per set
                    for (int j = 0; j < cubeSet.Count; j += 2)
                    {
                        int count = int.Parse(cubeSet[j]);
                        string cubeColor = cubeSet[j + 1];

                        // If the amount of the color is larger than the max count for the color in the game, increase it
                        if (cubeColor.Contains("red"))
                        {
                            if (count > minRed)
                            {
                                minRed = count;
                            }
                        }
                        else if (cubeColor.Contains("green"))
                        {
                            if (count > minGreen)
                            {
                                minGreen = count;
                            }
                        }
                        else if (cubeColor.Contains("blue"))
                        {
                            if (count > minBlue)
                            {
                                minBlue = count;
                            }
                        }
                    }
                }

                int power = minRed * minBlue * minGreen;
                totPower += power;
            }
            Console.WriteLine(totPower);
        }
    }
}
