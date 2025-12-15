using AdventOfCode.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Numerics;
using System.Text;

namespace AdventOfCode.Year2025
{
    internal class Day08 : IAoC
    {
        public string GetInput()
        {
            var file_contents = File.ReadAllText("./input.txt");
            return file_contents;
        }

        public string SolvePart1(string input)
        {
            List<Vector3D> boxes = [];

            foreach (var line in input.Split(Environment.NewLine))
            {
                string[] coords = line.Split(',');
                Vector3D v = new(double.Parse(coords[0]), double.Parse(coords[1]), double.Parse(coords[2]));
                boxes.Add(v);
            }

            List<Connection> connections = new();

            for (int i = 0; i < boxes.Count; i++)
            {
                for (int j = i + 1; j < boxes.Count; j++)
                {
                    Connection conn = new Connection(boxes[i], boxes[j]);
                    connections.Add(conn);  
                }
            }

            connections.Sort((a, b) => a.Length().CompareTo(b.Length()));

            List<List<Vector3D>> circuits = [];

            List<Vector3D> initialCircuit = [];
            initialCircuit.Add(connections[0].v1);
            initialCircuit.Add(connections[0].v2);
            circuits.Add(initialCircuit);
            Console.WriteLine($"Creating new circuit with {connections[0].v1} and {connections[0].v2}");

            int limit = 1000;

            for (int k=1; k<limit; k++)
            {
                List<Vector3D> circuit1 = [];
                List<Vector3D> circuit2 = [];

                foreach (List<Vector3D> circuit in circuits)
                {
                    if (circuit.Contains(connections[k].v1))
                    {
                        circuit1 = circuit;
                    }

                    if (circuit.Contains(connections[k].v2))
                    {
                        circuit2 = circuit;
                    }
                 
                }
                if (circuit1 == circuit2)
                {
                    //Console.WriteLine($"{connections[k].v1} en {connections[k].v2} gevondne in zelfde circuit. Skipping");
                }
                else if (circuit1.Count > 0 && circuit2.Count> 0)
                {
                    circuit1.AddRange(circuit2);
                    circuits.Remove(circuit2);
                    //Console.WriteLine($"{connections[k].v1} en {connections[k].v2} joining circuits.");
                }
                else if (circuit1.Count > 0)
                {
                    circuit1.Add(connections[k].v2);
                    //Console.WriteLine($"{connections[k].v1} in circuit, adding {connections[k].v2}");
                }
                else if (circuit2.Count > 0)
                {
                    circuit2.Add(connections[k].v1);
                   // Console.WriteLine($"{connections[k].v2} in circuit, adding {connections[k].v1}");
                }
                else
                {
                    List<Vector3D> newCircuit = [];
                    newCircuit.Add(connections[k].v1);
                    newCircuit.Add(connections[k].v2);
                    circuits.Add(newCircuit);
                    //Console.WriteLine($"Creating new circuit with {connections[k].v1} and {connections[k].v2}");
                }
            }

            circuits.Sort((a,b) => b.Count.CompareTo(a.Count));

            int total = 1;

            for (int i = 0; i < 3; i++)
            {
                total *= circuits[i].Count;
            }

            return "" + total;
        }

        private class Connection 
        {
            public Vector3D v1;
            public Vector3D v2;

            public Connection(Vector3D v1, Vector3D v2)
            {
                this.v1 = v1;
                this.v2 = v2;
            }

            public double Length()
            {                 
                return (v1 - v2).Length();
            }
        }


        public string SolvePart2(string input)
        {
            List<Vector3D> boxes = [];

            foreach (var line in input.Split(Environment.NewLine))
            {
                string[] coords = line.Split(',');
                Vector3D v = new(double.Parse(coords[0]), double.Parse(coords[1]), double.Parse(coords[2]));
                boxes.Add(v);
            }

            List<Connection> connections = new();

            for (int i = 0; i < boxes.Count; i++)
            {
                for (int j = i + 1; j < boxes.Count; j++)
                {
                    Connection conn = new Connection(boxes[i], boxes[j]);
                    connections.Add(conn);
                }
            }

            connections.Sort((a, b) => a.Length().CompareTo(b.Length()));

            List<List<Vector3D>> circuits = [];

            foreach (Vector3D v in boxes)
            {
                List<Vector3D> circuit = [];
                circuit.Add(v);
                circuits.Add(circuit);
            }

            int k = 0;

            while (circuits.Count > 1)
            {
                List<Vector3D> circuit1 = [];
                List<Vector3D> circuit2 = [];
          
                foreach (List<Vector3D> circuit in circuits)
                {
                    if (circuit.Contains(connections[k].v1))
                    {
                        circuit1 = circuit;
                    }

                    if (circuit.Contains(connections[k].v2))
                    {
                        circuit2 = circuit;
                    }

                }
                if (circuit1 == circuit2)
                {
                   // Console.WriteLine($"{connections[k].v1} en {connections[k].v2} gevondne in zelfde circuit. Skipping");
                }
                else if (circuit1.Count > 0 && circuit2.Count > 0)
                {
                    circuit1.AddRange(circuit2);
                    circuits.Remove(circuit2);
                   // Console.WriteLine($"{connections[k].v1} en {connections[k].v2} joining circuits.");
                }              
                k++;

            }

            return "" + (connections[k-1].v1.X * connections[k-1].v2.X).ToString();
        }
    }
}
