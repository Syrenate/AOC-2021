using System;
using System.Collections.Generic;

namespace Shortest_Path
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rawData = System.IO.File.ReadAllLines(@"C:\Users\lukej\OneDrive\Documents\Personal Projects\AdventOfCode\Shortest Path\map.txt");
            Dictionary<int, Dictionary<int, int>> graph = new Dictionary<int, Dictionary<int, int>>();
            int[,] nodes = new int[rawData.Length, rawData[0].Length];

            int d = rawData.Length;
            int count = 0;

            for (int row = 0; row < rawData.Length; row++)
            {
                for (int column = 0; column < rawData[0].Length; column++)
                {
                    nodes[row, column] = count;
                    if (count < 10)
                    {
                        Console.Write("0" + nodes[row, column] + " ");
                    }
                    else
                    {
                        Console.Write(nodes[row, column] + " ");
                    }
                    count++;
                }
                Console.Write("\n");
            }

            for (int row = 0; row < rawData.Length; row++)
            {
                for (int column = 0; column < rawData[0].Length; column++)
                {
                    int node = nodes[row, column];
                    Console.WriteLine(node);

                    graph.Add(node, new Dictionary<int, int>());
                    if (row > 0) { graph[node].Add(rawData[row - 1][column], nodes[row - 1, column]); }
                    if (row < nodes.GetLength(0)) { graph[node].Add(rawData[row + 1][column], nodes[row + 1, column]); }
                    if (column > 0) { graph[node].Add(rawData[row][column - 1], nodes[row, column - 1]); }
                    if (column < nodes.GetLength(1)) { graph[node].Add(rawData[row][column + 1], nodes[row, column + 1]); var entry = graph[node]; }
                }
            }
        }
    }
}
