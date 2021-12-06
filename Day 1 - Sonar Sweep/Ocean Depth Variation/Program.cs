using System;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rawData = System.IO.File.ReadAllLines(@"C:\Users\lukej\OneDrive\Documents\Personal Projects\AdventOfCode\Ocean Depth Variation\DepthData.txt");
            int[] dataPoints = new int[rawData.Length];
            for (int i = 0; i < dataPoints.Length; i++) { dataPoints[i] = Convert.ToInt32(rawData[i]); }

            int totalIncreased = 0;
            for (int i = 0; i < dataPoints.Length; i++)
            {
                Console.Write(dataPoints[i] + " ");
                if (i != 0)
                {
                    if (dataPoints[i] > dataPoints[i - 1])
                    {
                        Console.Write("(increased)");
                        totalIncreased++;
                    }
                    else if (dataPoints[i] < dataPoints[i - 1])
                    {
                        Console.Write("(decreased)");
                    }
                    else
                    {
                        Console.Write("(N/A - no change)");
                    }
                }
                else
                {
                    Console.Write("(N/A - no previous measurement)");
                }

                Console.Write("\n");
            }

            Console.Write($"\nIn total, {totalIncreased} values were higher than the previous value");
        }
    }
}
