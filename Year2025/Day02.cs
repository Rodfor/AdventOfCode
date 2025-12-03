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
                int length = minmax[0].Length;

                for (var i = 1; i <= Math.Max(length / 2, 1); i++)
                {
                    string current = minmax[0][..i];
                    int minBound = (int) decimal.Round((decimal) minmax[0].Length / i, MidpointRounding.AwayFromZero);
                    int maxBound = (int) decimal.Round((decimal) minmax[0].Length / i, MidpointRounding.ToZero);
                
                    for (var x = minBound; x <= maxBound; x++)
                    {
                        long ID = long.Parse(string.Concat(Enumerable.Repeat(current,x)));

                        while (ID <= max)
                        {
                            if (ID >= min)
                            {
                                //Console.WriteLine(ID + " is invalid");it
                                result += ID;
                            }
                            current = (int.Parse(current) + 1).ToString();
                            ID = long.Parse(string.Concat(Enumerable.Repeat(current,x)));
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