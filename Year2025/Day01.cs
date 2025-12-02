using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Runtime.InteropServices;

namespace AdventOfCode.Year2025
{
    public class Day01 : IAoC
    {
        // Puzzle can be found on: https://adventofcode.com/2025/day/1

        public string SolvePart1(string input)
        {           
            string[] splitInput = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            int cur = 50;
            int result = 0;    
            foreach (string line in splitInput)
            {
                if (line.StartsWith("L"))
                {
                    cur -= int.Parse(line[1..]);
                    while (cur < 0)
                    {
                        cur += 100;
                    }
                }
                else
                {
                    cur += int.Parse(line[1..]);
                    while (cur > 99)
                    {
                        cur -= 100;
                    }
                }

                if (cur == 0)
                {
                    result++;
                }   
            }

            return "" + result;
        }

        public string SolvePart2(string input)
        {
            string[] splitInput = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            int cur = 50;
            int result = 0;
            foreach (string line in splitInput)
            {
                if (line.StartsWith("L"))
                {
                    cur -= int.Parse(line[1..]);
                    while (cur < 0)
                    {
                        cur += 100;
                        result++;
                    }
                }
                else
                {
                    cur += int.Parse(line[1..]);
                    while (cur > 99)
                    {
                        cur -= 100;
                        result++;
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