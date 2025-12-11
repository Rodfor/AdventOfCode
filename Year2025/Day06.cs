using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AdventOfCode.Year2025
{
    internal class Day06 : IAoC
    {
        public string GetInput()
        {
            var file_contents = File.ReadAllText("./input.txt");
            return file_contents;
        }

        private class Problem
        {
            public List<int> cijfers = [];
            public char operatie;
            public int Lengte;

            public long Solve()
            {
                long result = 0;
                if (operatie == Char.Parse("*"))
                {
                    result = 1;
                    foreach (int c in cijfers)
                    {
                        result *= c;
                    }
                }
                else if (operatie == Char.Parse("+"))
                {
                    foreach (int c in cijfers)
                    {
                        result += c;
                    }
                }
                return result;
            }
        }

        public string SolvePart1(string input)
        {
            string[] lijnen = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            List<Problem> problems = [];

            string[] lijn1 = lijnen.FirstOrDefault().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i=0; i<lijn1.Length; i++)
            {
                Problem P = new Problem();
                problems.Add(P);
            }

            long total = 0; 

            foreach (string L in lijnen)
            {
                string[] lijn = L.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (lijn.First() == "*" || lijn.First() == "*")
                {
                    for (int j = 0; j < lijn.Length; j++)
                    {
                        problems[j].operatie = Char.Parse(lijn[j]);
                        total += problems[j].Solve();
                    }
                }
                else
                {
                    for (int j = 0; j < lijn.Length; j++)
                    {
                        problems[j].cijfers.Add(int.Parse(lijn[j]));
                    }
                }
            }

            return "" + total;

        }



        public string SolvePart2(string input)
        {
            string[] lijnen = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            string[] operators = lijnen.Last().Split(" ");

            List<Problem> problems = [];
            Problem cur = null; 

            for (int x=0; x<operators.Length;x++ )
            {
                if (operators[x] == "")
                {
                    cur.Lengte += 1;
                }
                else
                {
                    cur = new Problem
                    {
                        operatie = Char.Parse(operators[x]),
                        Lengte = 1
                    };
                    problems.Add(cur);
                }
            }

            int offset = 0;

            for (int i=0; i < problems.Count; i++)
            {

                for (int j = 0; j < problems[i].Lengte; j++)
                {
                    string cijfer = "";
                    for (int k=0; k < lijnen.Count() - 1; k++)
                    {
                        cijfer += lijnen[k][i + offset + j];
                    }
                    if (cijfer.Trim(" ").Length > 0)
                    {
                        problems[i].cijfers.Add(int.Parse(cijfer));
                    }
                }

                offset += problems[i].Lengte;
            }

            long total = 0;

            foreach (Problem P in problems)
            {
               total +=  P.Solve();
            }


            return "" + total;
        }
    }
}
