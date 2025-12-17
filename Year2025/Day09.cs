using AdventOfCode.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
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

            for (int i = connections.Count - 1; i >= 0; i--)
            {

                Vector2D v1 = connections[i].v1;
                Vector2D v2 = new(connections[i].v1.X, connections[i].v2.Y);
                Vector2D v3 = connections[i].v2;
                Vector2D v4 = new(connections[i].v2.X, connections[i].v1.Y);
                
                for (int j=0; j < redTiles.Count - 1; j++)
                {

                    CheckIntersect(v1, v2, redTiles[j], redTiles[j + 1]);
                    CheckIntersect(v2, v3, redTiles[j], redTiles[j + 1]);
                    CheckIntersect(v3, v4, redTiles[j], redTiles[j + 1]);
                    CheckIntersect(v4, v1, redTiles[j], redTiles[j + 1]);
                }


            }


            return "error";
        }


        public bool CheckIntersect(Vector2D a1, Vector2D a2, Vector2D b1, Vector2D b2)
        {
            Vector2D b = a2 - a1;
            Vector2D d = b2 - b1;

            double dot = Vector2D.Dot(b, d);

            if (dot == 0)
            {
                return false;
            }


            Vector2D c = b1 - a1;

            double t = (c.X * d.Y - c.Y * d.X) / dot;
            if (t < 0 || t > 1)
            {
                return false;
            }

            double u = (c.X * b.Y - c.Y * b.X) / dot;
            if (u < 0 || u > 1)
            {
                return false;
            }

            return true;
        }

    }
}
