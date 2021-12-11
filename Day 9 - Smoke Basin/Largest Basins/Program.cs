using System;
using System.Collections.Generic;
using System.Threading;

namespace Risk_Zones
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            string[] rawData = System.IO.File.ReadAllLines(@"C:\Users\lukej\OneDrive\Documents\Personal Projects\AdventOfCode\Largest Basins\Height Map.txt");

            int[,] heightData = new int[rawData.Length, rawData[0].Length];
            bool[,] heightMap = new bool[rawData.Length, rawData[0].Length];

            int sum = 0;
            for (int row = 0; row < rawData.Length; row++)
            {
                for (int column = 0; column < rawData[0].Length; column++)
                {
                    if (rawData[row][column] == Convert.ToChar("9"))
                    {
                        heightMap[row, column] = true;
                    }
                    else
                    {
                        heightMap[row, column] = false;
                    }

                    heightData[row, column] = rawData[row][column];
                }
            }

            List<int> basinList = new List<int>();

            for (int row = 0; row < rawData.Length; row++)
            {
                for (int column = 0; column < rawData[0].Length; column++)
                {
                    bool origin = heightMap[row, column];
                    if (origin == false)
                    {
                        DisplayArray(heightMap);
                        Thread.Sleep(500);
                        basinList.Add(FloodFill(row, column, new IntPointer(0)).value);
                    }
                }
            }

            DisplayArray(heightMap);
            Thread.Sleep(500);

            while (IsSorted(basinList) == false)
            {
                for (int i = 1; i < basinList.Count; i++)
                {
                    if (basinList[i] < basinList[i - 1])
                    {
                        int temp = basinList[i];
                        basinList[i] = basinList[i - 1];
                        basinList[i - 1] = temp;
                    }
                }
            }


            sum = basinList[basinList.Count - 1] * basinList[basinList.Count - 2] *basinList[basinList.Count - 3];

            Console.WriteLine(sum);



            IntPointer FloodFill(int row, int column, IntPointer count)
            {
                count.value++;
                heightMap[row, column] = true;

                if (row > 0 && heightMap[row - 1, column] == false) { FloodFill(row - 1, column, count); }
                if (row < heightMap.GetLength(0) - 1 && heightMap[row + 1, column] == false) { FloodFill(row + 1, column, count); }
                if (column > 0 && heightMap[row, column - 1] == false) { FloodFill(row, column - 1, count); }
                if (column < heightMap.GetLength(1) - 1 && heightMap[row, column + 1] == false) { FloodFill(row, column + 1, count); }
                return count;
            }

            
            bool IsSorted(List<int> list)
            {
                bool sorted = true;
                for (int i = 1; i < list.Count; i++)
                {
                    if (list[i] < list[i - 1])
                    {
                        sorted = false;
                    }
                }
                return sorted;
            }

            void DisplayArray(bool[,] points)
            {
                Console.Clear();
                for (int row = 0; row < points.GetLength(0); row++)
                {
                    for (int column = 0; column < points.GetLength(1); column++)
                    {
                        if (points[row, column] == false)
                        {
                            Console.Write("  ");
                        }
                        else
                        {
                            Console.Write("██");
                        }
                    }
                    Console.Write("\n");
                }
            }
        }

        public class IntPointer
        {
            public int value;
            public IntPointer(int newInt)
            {
                value = newInt;
            }
        }
    }
}