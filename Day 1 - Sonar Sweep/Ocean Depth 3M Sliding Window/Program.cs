using System;

namespace Ocean_Depth_3M_Sliding_Window
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rawData = System.IO.File.ReadAllLines(@"C:\Users\lukej\OneDrive\Documents\Personal Projects\AdventOfCode\Ocean Depth 3M Sliding Window\DepthData.txt");
            int[] dataPoints = new int[rawData.Length];
            for (int i = 0; i < dataPoints.Length; i++) { dataPoints[i] = Convert.ToInt32(rawData[i]); }

            int totalIncreased = 0;
            for (int i = 3; i < dataPoints.Length; i++)
            {
                int prevSum = dataPoints[i - 1] + dataPoints[i - 2] + dataPoints[i - 3];
                int newSum = dataPoints[i] + dataPoints[i - 1] + dataPoints[i - 2];

                Console.Write(newSum + " ");
                
                if (newSum > prevSum)
                {
                    Console.Write("(increased)");
                    totalIncreased++;
                }
                else if (newSum < prevSum)
                {
                    Console.Write("(decreased)");
                }
                else
                {
                    Console.Write("(N/A - no change)");
                }
                
                Console.Write("\n");
            }

            Console.Write($"\nIn total, {totalIncreased} windows were higher than the previous window");
        }
    }
}
