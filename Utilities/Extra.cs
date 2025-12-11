using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Utilities
{
    static class Extra
    {

        public static int[,] ToIntMatrix(string[] lines)
        {
            int rows = lines.Length;
            int cols = lines[0].Length;

            var matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {

                for (int j = 0; j < cols; j++)
                {
                    char c = lines[i][j];
                    matrix[i, j] = c - '0';
                }
            }

            return matrix;
        }
    }
}