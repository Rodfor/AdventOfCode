using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Utilities
{
    internal class Vector2D
    {

        public double X { get; set; }
        public double Y { get; set; }
        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }
        public static Vector2D operator +(Vector2D a, Vector2D b)
        {
            return new Vector2D(a.X + b.X, a.Y + b.Y);
        }
        public static Vector2D operator -(Vector2D a, Vector2D b)
        {
            return new Vector2D(a.X - b.X, a.Y - b.Y);
        }
        public static Vector2D operator *(Vector2D a, double scalar)
        {
            return new Vector2D(a.X * scalar, a.Y * scalar);
        }
        public static Double Dot(Vector2D a, Vector2D b)
        {
            return a.X * b.X + a.Y * b.Y;
        }
        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public Vector2D Normalize()
        {
            double length = Length();
            if (length == 0) throw new InvalidOperationException();
            return new Vector2D(X / length, Y / length);
        }
    }
}
