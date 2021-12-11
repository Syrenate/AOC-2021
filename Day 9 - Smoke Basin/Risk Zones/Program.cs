using System;
using System.Collections.Generic;

namespace Risk_Zones
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rawData = System.IO.File.ReadAllLines(@"C:\Users\lukej\OneDrive\Documents\Personal Projects\AdventOfCode\Risk Zones\Height Map.txt");

            int sum = 0;
            int row = 0; int column = 0;
            for (int i = 0; i < rawData.Length * rawData[0].Length; i++)
            {
                int focus = rawData[row][column];
                List<int> neighbours = new List<int>();

                if (row == 0)
                {
                    if (column == 0)
                    {
                        neighbours.Add(rawData[row][column + 1]);
                        neighbours.Add(rawData[row + 1][column]);
                    }
                    else if (column == rawData[row].Length - 1)
                    {
                        neighbours.Add(rawData[row][column - 1]);
                        neighbours.Add(rawData[row + 1][column]);
                    }
                    else
                    {
                        neighbours.Add(rawData[row][column + 1]);
                        neighbours.Add(rawData[row][column - 1]);
                        neighbours.Add(rawData[row + 1][column]);
                    }
                }
                else if (row == rawData.Length - 1)
                {
                    if (column == 0)
                    {
                        neighbours.Add(rawData[row][column + 1]);
                        neighbours.Add(rawData[row - 1][column]);
                    }
                    else if (column == rawData[row].Length - 1)
                    {
                        neighbours.Add(rawData[row][column - 1]);
                        neighbours.Add(rawData[row - 1][column]);
                    }
                    else
                    {
                        neighbours.Add(rawData[row][column + 1]);
                        neighbours.Add(rawData[row][column - 1]);
                        neighbours.Add(rawData[row - 1][column]);
                    }
                }
                else
                {
                    if (column == 0)
                    {
                        neighbours.Add(rawData[row + 1][column]);
                        neighbours.Add(rawData[row - 1][column]);
                        neighbours.Add(rawData[row][column + 1]);
                    }
                    else if (column == rawData[row].Length - 1)
                    {
                        neighbours.Add(rawData[row + 1][column]);
                        neighbours.Add(rawData[row - 1][column]);
                        neighbours.Add(rawData[row][column - 1]);
                    }
                    else
                    {
                        neighbours.Add(rawData[row + 1][column]);
                        neighbours.Add(rawData[row - 1][column]);
                        neighbours.Add(rawData[row][column + 1]);
                        neighbours.Add(rawData[row][column - 1]);
                    }
                }

                bool isLower = true;
                foreach (int num in neighbours)
                {
                    if (num <= focus) { isLower = false; }
                }

                if (isLower == true)
                {
                    sum += (1 + (focus - 48));
                }

                if (column != 0 && column % (rawData[0].Length - 1) == 0)
                {
                    column = 0; row++;
                }
                else
                {
                    column++;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
