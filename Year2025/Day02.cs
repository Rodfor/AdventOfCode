using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace AdventOfCode.Year2025
{
    public class Day02 : IAoC
    {
        // Puzzle can be found on: https://adventofcode.com/2025/day/2

        public string SolvePart1(string input)
        {
            string[] pairs = input.Split(",");
            long result = 0;

            foreach (string P in pairs)
            {
                string[] minxmax = P.Split("-");
                long min = long.Parse(minxmax[0]);
                long max = long.Parse(minxmax[1]);
                int length = Math.Max(minxmax[0].Length / 2, 1);

                string current = minxmax[0][..length];
                long ID = long.Parse(current + current);

                while (ID <= max)
                {
                    if (ID >= min)
                    {
                        //Console.WriteLine(ID + " is invalid");
                        result += ID;
                    }
                    current = (int.Parse(current) + 1).ToString();
                    ID = long.Parse(current + current);
                }

            }

            return "" + result;
        }


        public string SolvePart2(string input)
        {
            string[] pairs = input.Split(",");
            long result = 0;


            foreach (string P in pairs)
            {
                string[] minmax = P.Split("-");
                long min = long.Parse(minmax[0]);
                long max = long.Parse(minmax[1]);
                int minLength = minmax[0].Length;
                int maxLength = minmax[1].Length;
                List<long> invalids = [];
                List<int> pairings = []; ;

                for (var x = 2; x <= maxLength; x++)
                {
                    if (!pairings.Contains(x) && (minLength % x == 0 || maxLength % x == 0))
                    {
                        for (var offset = 0; offset <= maxLength - minLength; offset++)
                        {
                            int current = (int) Math.Pow(10, (minLength + offset) / x) / 10;
                            long ID = long.Parse(string.Concat(Enumerable.Repeat(current, x + offset)));
                            int IDLength = ID.ToString().Length;

                            while (ID <= max)
                            {
                                if (ID >= min)
                                {
                                    if (!invalids.Contains(ID))
                                    {
                                        invalids.Add(ID);
                                        //Console.WriteLine(ID + " is invalid");
                                        result += ID;
                                    }
                                }
                                current = current += 1;

                                ID = long.Parse(string.Concat(Enumerable.Repeat(current, x + offset)));
                            }
                        }
                    }
                }
            }
            return "" + result;
        }

        public string GetInput()
        {
            var file_contents = File.ReadAllText("./input.txt");
            return file_contents;
        }

        
    }
}