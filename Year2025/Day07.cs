using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Xml.Linq;

namespace AdventOfCode.Year2025
{
    internal class Day07 : IAoC
    {
        public string GetInput()
        {
            var file_contents = File.ReadAllText("./input.txt");
            return file_contents;
        }

        public string SolvePart1(string input)
        {
            string[] grid = input.Split(Environment.NewLine);
            string eersteLijn = grid[0];

            List<int> kolommen = [];
            kolommen.Add(eersteLijn.IndexOf("S"));

            long totalSplits = 0;

            for (int i = 2; i < grid.Length; i+=2)
            {
                List<int> nieuweKolommen = [];

                foreach (int k in kolommen)
                {
                    if (grid[i][k] == char.Parse("^"))
                    {
                        if (!nieuweKolommen.Contains(k-1))
                        {
                            nieuweKolommen.Add(k - 1);
                        }

                        if (!nieuweKolommen.Contains(k + 1))
                        {
                            nieuweKolommen.Add(k + 1);
                        }
                        totalSplits += 1;
                    }
                    else
                    {
                        if (!nieuweKolommen.Contains(k))
                        {
                            nieuweKolommen.Add(k);
                        }
                    }
                }
                kolommen = nieuweKolommen;
            }

            return "" + totalSplits;
        }

        public string SolvePart2(string input)
        {
            string[] grid = input.Split(Environment.NewLine);
            string eersteLijn = grid[0];
            int lengte = eersteLijn.Length;

            long[] kolommen = new long[lengte];
            kolommen[eersteLijn.IndexOf("S")]+=1;

            for (int i = 2; i < grid.Length; i += 2)
            {
                long[] nieuweKolommen = new long[lengte];

                for (int k=0; k < lengte; k++)
                {
                    long beams = kolommen[k];

                    if (beams == 0) continue;

                    if (grid[i][k] == char.Parse("^"))
                    {
                        nieuweKolommen[k - 1] += beams;
                        nieuweKolommen[k + 1] += beams;
                    }
                    else
                    {
                        nieuweKolommen[k] += beams;
                    }
                }
                kolommen = nieuweKolommen;
            }

            return "" + kolommen.Sum();
        }
    }
        
}
