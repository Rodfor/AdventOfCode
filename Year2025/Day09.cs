using AdventOfCode.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Year2025
{
    internal class Day09 : IAoC
    {
        public string GetInput()
        {
            var file_contents = File.ReadAllText("./input.txt");
            return file_contents;
        }

        public string SolvePart1(string input)
        {
            List<Vector2D> redTiles = [];

            foreach (var line in input.Split(Environment.NewLine))
            {
                string[] coords = line.Split(',');
                Vector2D v = new(double.Parse(coords[0]), double.Parse(coords[1]));
                redTiles.Add(v);
            }


            List<Connection> connections = new();

            for (int i = 0; i < redTiles.Count; i++)
            {
                for (int j = i + 1; j < redTiles.Count; j++)
                {
                    Connection conn = new Connection(redTiles[i], redTiles[j]);
                    connections.Add(conn);
                }
            }

            connections.Sort((a, b) => a.AreaOfRectangle().CompareTo(b.AreaOfRectangle()));

            return ""+connections.Last().AreaOfRectangle().ToString();


        }

        private class Connection
        {
            public Vector2D v1;
            public Vector2D v2;

            public Connection(Vector2D v1, Vector2D v2)
            {
                this.v1 = v1;
                this.v2 = v2;
            }

            public double AreaOfRectangle()
            {
                return (Math.Abs(v1.X - v2.X) + 1)  * (Math.Abs(v1.Y - v2.Y) + 1);
            }
        }


        public string SolvePart2(string input)
        {

            return "";
        }
    }
}
