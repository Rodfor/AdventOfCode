using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace AdventOfCode.Year2025
{
    internal class Day03 : IAoC
    {
        // Puzzle can be found on: https://adventofcode.com/2025/day/2

        public string SolvePart1(string input)
        {
            long result = 0;
            int iterations = 2;
            string[] banks = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            foreach (string B in banks)
            {
               result += FindJoltage(B, 2);    
            }

            return "" + result;
        }

        public long FindJoltage(string bank, int iterations)
        {
            string result = "";
            int index = -1;
            string curString = bank;

            for (int i = 1; i <= iterations; i++)
            {
                curString = curString[(index + 1)..];
                index = FindNextNumber(curString[..^(iterations - i)]);
                result += curString[index];
            }        
            return long.Parse(result);
        }

        public int FindNextNumber(string bank)
        {
            for (int i = 9; i >= 0; i--)
            {
                int index = bank.IndexOf(i.ToString());
                if (index >= 0)
                 {
                    return index;
                }
            }
            return -1;
        }

        public string SolvePart2(string input)
        {
            long result = 0;
            int iterations = 12;
            string[] banks = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            foreach (string B in banks)
            {
                result += FindJoltage(B, 12);
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
