using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Year2025
{
    internal class Day05 : IAoC
    {
        public string GetInput()
        {
            var file_contents = File.ReadAllText("./input.txt");
            return file_contents;
        }

        public string SolvePart1(string input)
        {
            String[] inputs = input.Split(Environment.NewLine, StringSplitOptions.None);
            SortedDictionary<long, long> FreshRanges = [];
            List<long> ingredientList = [];

            bool ingredients = false;
            foreach (string I in inputs)
            {
                if (string.IsNullOrEmpty(I))
                {
                    ingredients = true;
                }
                else if (!ingredients)
                {
                    string[] minmax = I.Split("-");
                    long key = long.Parse(minmax[0]);
                    long val = long.Parse(minmax[1]);

                    if (FreshRanges.ContainsKey(key))
                    {
                        if (FreshRanges[key] < val)
                        {
                            FreshRanges[key] = val;
                        }
                    }
                    else
                    {
                        FreshRanges.Add(key, val);
                    }
                }
                else
                {
                    ingredientList.Add(long.Parse(I));
                }
            }

            ingredientList.Sort();


            int freshIngredients = 0;
            long CurrentKey = FreshRanges.First().Key;

            foreach (long ingredient in ingredientList)
            {

                while (CurrentKey != 0)
                {
                    if (ingredient < CurrentKey)
                    {
                        break;
                    }

                    if (ingredient <= FreshRanges[CurrentKey])
                    {
                        freshIngredients++;
                        break;
                    }

                    if (ingredient < CurrentKey)
                    {
                        break;
                    }

                    CurrentKey = FreshRanges.Keys.Where(k => k > CurrentKey).FirstOrDefault();
                }
            }

            return "" + freshIngredients;
        }

        public string SolvePart2(string input)
        {
            String[] inputs = input.Split(Environment.NewLine, StringSplitOptions.None);
            SortedDictionary<long, long> FreshRanges = [];
            SortedDictionary<long, long> FreshRangesCascaded = [];

            bool ingredients = false;
            foreach (string I in inputs)
            {
                if (string.IsNullOrEmpty(I))
                {
                    ingredients = true;
                }
                else if (!ingredients)
                {
                    string[] minmax = I.Split("-");
                    long key = long.Parse(minmax[0]);
                    long val = long.Parse(minmax[1]);

                    if (FreshRanges.ContainsKey(key))
                    {
                        if (FreshRanges[key] < val)
                        {
                            FreshRanges[key] = val;
                            FreshRangesCascaded[key] = val;
                        }
                    }
                    else
                    {
                        FreshRanges.Add(key, val);
                        FreshRangesCascaded.Add(key, val);
                    }
                }
            }

            long totalrange = 0;

            foreach (KeyValuePair<long, long> cur in FreshRanges.Reverse())
            {
                if (FreshRangesCascaded.ContainsKey(cur.Key))
                {
                    long val = FreshRangesCascaded[cur.Key];
                    IEnumerable<KeyValuePair<long, long>> smallerKeys = FreshRangesCascaded.Where(x => x.Key < cur.Key && x.Value >= cur.Key);

                    if (smallerKeys.Any())
                    {

                        long kleinste = smallerKeys.First().Key;
                        long newValue = val;

                        foreach (KeyValuePair<long, long> sk in smallerKeys.ToList())
                        {
                            newValue = Math.Max(newValue, sk.Value);
                             if (!kleinste.Equals(sk.Key))
                            {
                               FreshRangesCascaded.Remove(sk.Key);
                            }
                        }

                        FreshRangesCascaded.Remove(cur.Key);
                        FreshRangesCascaded[kleinste] = newValue;
                    
                    }
                    else
                    {
                        totalrange += (val - cur.Key + 1);
                    }
                }
            }
            return "" + totalrange ;
        }
    }
}