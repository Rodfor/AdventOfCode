using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Utilities
{
    internal class Vector3D
    {

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public static Vector3D operator +(Vector3D a, Vector3D b)
        {
            return new Vector3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        public static Vector3D operator -(Vector3D a, Vector3D b)
        {
            return new Vector3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        public static Vector3D operator *(Vector3D a, double scalar)
        {
            return new Vector3D(a.X * scalar, a.Y * scalar, a.Z * scalar);
        }
        public static Double Dot(Vector3D a, Vector3D b)
        {
           return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }
        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";  
        }

        public Vector3D Normalize()
        {
            double length = Length();
            if (length == 0) throw new InvalidOperationException();
            return new Vector3D(X / length, Y / length, Z / length);
        }
    }
}
