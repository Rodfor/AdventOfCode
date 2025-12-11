using AdventOfCode.Utilities;

namespace AdventOfCode.Year2025
{
    internal class Day04 : IAoC
    {

        public string SolvePart1(string input)
        {
            string[] rijen = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            short[,] solMatrix = new short[rijen.Length,rijen[0].Length];

            int maxI = rijen.Length;
            int maxJ = rijen[0].Length;

            int totalRolls = 0;
            int inaccesibleRolls = 0;

            for (int i = 0; i < maxI; i++)
            {
                for (int j = 0; j < maxJ; j++)
                {
                    if (rijen[i][j] == '@')
                    {
                        totalRolls += 1;

                        int iMin = Math.Max(0, i - 1);
                        int iMax = Math.Min(maxI - 1, i + 1);
                        int jMin = Math.Max(0, j - 1);
                        int jMax = Math.Min(maxJ - 1, j + 1);

                        for (int ni = iMin; ni <= iMax; ni++)
                        {
                            for (int nj = jMin; nj <= jMax; nj++)
                            {
                                if (ni == i && nj == j) continue;                
                       
                                solMatrix[ni, nj] += 1;

                                if (solMatrix[ni, nj] == 4 && rijen[ni][nj] == '@')
                                {
                                    inaccesibleRolls++;
                                }
                            }
                        }
                    }
                }
            }
      
            return "" + (totalRolls- inaccesibleRolls);

        }

        public string SolvePart2(string input)
        {
            input = input.Replace('.', '9');
            input = input.Replace('@', '0');

            string[] rijen = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            int[,] grid = Extra.ToIntMatrix(rijen);

            int maxI = rijen.Length;
            int maxJ = rijen[0].Length;

            int totalRolls = 0;
            int inaccesibleRolls = 0;
            int totalRollsRemoved = 0;

            for (int i = 0; i < maxI; i++)
            {
                for (int j = 0; j < maxJ; j++)
                {
                    if (grid[i,j] < 9)
                    {
                        totalRolls += 1;

                        int iMin = Math.Max(0, i - 1);
                        int iMax = Math.Min(maxI - 1, i + 1);
                        int jMin = Math.Max(0, j - 1);
                        int jMax = Math.Min(maxJ - 1, j + 1);

                        for (int ni = iMin; ni <= iMax; ni++)
                        {
                            for (int nj = jMin; nj <= jMax; nj++)
                            {
                                if (ni == i && nj == j) continue;
                                if (grid[ni,nj] < 9)
                                {
                                    grid[ni, nj] += 1;
                                }                 
                            }
                        }
                    }
                }
            }

            int accessibleRolls = 0;
            do
            {
                for (int i = 0; i < maxI; i++)
                {
                    for (int j = 0; j < maxJ; j++)
                    {
                        if (grid[i, j] < 4)
                        {                                            
                            accessibleRolls += 1;
                            totalRolls -= 1;
                            grid[i, j] = 9; 

                            int iMin = Math.Max(0, i - 1);
                            int iMax = Math.Min(maxI - 1, i + 1);
                            int jMin = Math.Max(0, j - 1);
                            int jMax = Math.Min(maxJ - 1, j + 1);

                            for (int ni = iMin; ni <= iMax; ni++)
                            {
                                for (int nj = jMin; nj <= jMax; nj++)
                                {
                                    if (ni == i && nj == j) continue;
                                    if (grid[ni, nj] < 9)
                                    {
                                        grid[ni, nj] -= 1;
                                    }
                                }
                            }
                        }
                    }
                }
                totalRollsRemoved += accessibleRolls;
                Console.WriteLine($"Total Rolls : {totalRolls} - Accessible Rolls : {accessibleRolls}");
                if (accessibleRolls == 0)
                {
                    break;
                }
                else
                {
                    accessibleRolls = 0;
                }

            } while (true);



            return "" + totalRollsRemoved;
        }
        public string GetInput()
        {
            var file_contents = File.ReadAllText("./input.txt");
            return file_contents;
        }
    }
}
