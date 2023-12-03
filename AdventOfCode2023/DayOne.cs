using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    internal class DayOne
    {
        public void Execute()
        {
            string[] input = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"DayOneInput.txt"));
            Dictionary<string, int> numbersDictionary = new Dictionary<string, int>()
            {
                { "one", 1 }, { "two", 2 }, {"three", 3}, { "four", 4}, {"five", 5}, {"six", 6}, {"seven", 7}, {"eight", 8}, {"nine", 9}
            };

            int endSum = 0;
            foreach (string line in input)
            {
                Dictionary<int, string> FoundNumberDictionary = new Dictionary<int, string>();

                foreach (string digitName in numbersDictionary.Keys)
                {
                    if (line.Contains(digitName))
                    {
                        FoundNumberDictionary.TryAdd(line.IndexOf(digitName), digitName);
                        FoundNumberDictionary.TryAdd(line.LastIndexOf(digitName), digitName);
                    }
                }

                if (line.Any(char.IsDigit))
                {
                    char firstDigit = line.FirstOrDefault(x => char.IsDigit(x));
                    if (firstDigit != 0)
                    {
                        FoundNumberDictionary.TryAdd(line.IndexOf(firstDigit), firstDigit.ToString());
                    }

                    char lastDigit = line.LastOrDefault(x => char.IsDigit(x));
                    FoundNumberDictionary.TryAdd(line.LastIndexOf(lastDigit), lastDigit.ToString());
                }

                var orderedDic = FoundNumberDictionary.OrderBy(x => x.Key);
                string firstFoundLetterNumber = orderedDic.FirstOrDefault().Value;
                string lastFoundLetterNumber = orderedDic.LastOrDefault().Value;

                int convertedFirstFoundDigit = firstFoundLetterNumber.Length > 1 ? numbersDictionary[firstFoundLetterNumber] : int.Parse(firstFoundLetterNumber);
                int convertedLastFoundDigit = -1;
                if (lastFoundLetterNumber != "")
                {
                    convertedLastFoundDigit = lastFoundLetterNumber?.Length > 1 ? numbersDictionary[lastFoundLetterNumber] : int.Parse(lastFoundLetterNumber ?? "0");
                }

                endSum += int.Parse(convertedFirstFoundDigit.ToString() + (convertedLastFoundDigit != -1 ? convertedLastFoundDigit.ToString() : ""));
            }

            Console.WriteLine(endSum.ToString());
        }
    }
}
