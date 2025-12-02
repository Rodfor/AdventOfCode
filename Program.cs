using System;

var aoc = new AdventOfCode.AdventOfCode();
aoc.Solved2025();
Console.ReadLine();

namespace AdventOfCode
{
    using System.Diagnostics;

    public class AdventOfCode
    {
        internal void Solved2025()
        {
            var aoc = new AdventOfCode();
            //aoc.Solve(new Year2025.Day01());
            aoc.Solve(new Year2025.Day02());
        }
        public void Solve(IAoC aoc)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine($"{aoc.GetType().Namespace}");
            Console.WriteLine($"{aoc.GetType().Name}, part 1: {aoc.SolvePart1(aoc.GetInput())}");
            Console.WriteLine($"{aoc.GetType().Name}, part 2: {aoc.SolvePart2(aoc.GetInput())}");
            Console.WriteLine(string.Empty);
            Console.WriteLine($"Execution time was about {stopwatch.ElapsedMilliseconds}ms");
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
        }
    }
}