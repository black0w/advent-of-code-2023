using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    internal class DayTwo
    {
        public void ExecutePartOne()
        {
            string[] input = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"DayTwoInput.txt"));
            List<int> possibleGamesIds = new List<int>();
            foreach(string line in input)
            {
                var gameId = line.Split(":").First().Split(" ").Last();
                var colors = line.Split(":").Last().Trim();
                bool isPossible = true;

                foreach(string set in colors.Split(';'))
                {
                    foreach(string color in set.Split(","))
                    {
                        var colorValue = int.Parse(color.Trim().Split(" ").First());
                        if (color.Contains("red"))
                        {
                            if(colorValue > 12)
                            {
                                isPossible = false;
                            }                 
                        }

                        if (color.Contains("green"))
                        {
                            if (colorValue > 13)
                            {
                                isPossible = false;
                            }
                        }

                        if (color.Contains("blue"))
                        {
                            if (colorValue > 14)
                            {
                                isPossible = false;
                            }
                        }
                    }
                }

                if(isPossible)
                {
                    possibleGamesIds.Add(int.Parse(gameId));
                }
            }

            int idSum = 0;
            possibleGamesIds.ForEach(id => { idSum += id; });

            Console.WriteLine(idSum);
        }

        public void ExecutePartTwo()
        {
            string[] input = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"DayTwoInput.txt"));
            int sum = 0;
            foreach (string line in input)
            {
                string colors = line.Split(":").Last().Trim();
                int redColorMax = 0;
                int greenColorMax = 0;
                int blueColorMax = 0;

                foreach (string set in colors.Split(';'))
                {
                    foreach (string color in set.Split(","))
                    {
                        var colorValue = int.Parse(color.Trim().Split(" ").First());

                        if (color.Contains("red"))
                        {
                            if (colorValue > redColorMax)
                            {
                                redColorMax = colorValue;
                            }
                        }

                        if (color.Contains("green"))
                        {
                            if (colorValue > greenColorMax)
                            {
                                greenColorMax = colorValue;
                            }
                        }

                        if (color.Contains("blue"))
                        {
                            if (colorValue > blueColorMax)
                            {
                                blueColorMax = colorValue;
                            }
                        }
                    }
                }

                sum += (redColorMax * greenColorMax * blueColorMax);
            }

            Console.Write(sum);
        }
    }
}
