using System;

namespace Overlapping_Vents
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rawData = System.IO.File.ReadAllLines(@"C:\Users\lukej\OneDrive\Documents\AOC-2021\AdventOfCode\Overlapping Vents\VentCoords.txt");

            // Finds dimensions of the environment I need to map
            int xDimensions = 0; int yDimensions = 0;
            for (int vent = 0; vent < rawData.Length; vent++)
            {
                string[] ventsData = rawData[vent].Split(" -> ");
                int[] ventCoords = new int[4];
                ventCoords[0] = Convert.ToInt32(ventsData[0].Split(",")[0]);
                ventCoords[1] = Convert.ToInt32(ventsData[0].Split(",")[1]);
                ventCoords[2] = Convert.ToInt32(ventsData[1].Split(",")[0]);
                ventCoords[3] = Convert.ToInt32(ventsData[1].Split(",")[1]);
                
                if (ventCoords[0] >= ventCoords[2])
                {
                    if (ventCoords[0] > xDimensions) 
                    { 
                        xDimensions = ventCoords[0]; 
                    }
                } 
                else 
                { 
                    if (ventCoords[2] > xDimensions) 
                    { 
                        xDimensions = ventCoords[2]; 
                    } 
                }

                if (ventCoords[1] >= ventCoords[3])
                {
                    if (ventCoords[1] > yDimensions)
                    {
                        yDimensions = ventCoords[1];
                    }
                }
                else
                {
                    if (ventCoords[3] > yDimensions)
                    {
                        yDimensions = ventCoords[3];
                    }
                }
            }

            int[,] ventPoints = new int[yDimensions + 1, xDimensions + 1];

            // Goes through all vents
            for (int vent = 0; vent < rawData.Length; vent++)
            {
                // Converts input to x1, y1, x2, y2
                string[] data = rawData[vent].Split(" -> ");
                int x1 = Convert.ToInt32(data[0].Split(",")[0]);
                int y1 = Convert.ToInt32(data[0].Split(",")[1]);
                int x2 = Convert.ToInt32(data[1].Split(",")[0]);
                int y2 = Convert.ToInt32(data[1].Split(",")[1]);

                int displacement = 0;

                // Horizontal Line 
                if (x1 != x2 && y1 == y2) 
                {
                    if (x1 > x2)
                    {
                        displacement = x1 - x2;

                        for (int i = 0; i <= displacement; i++)
                        {
                            ventPoints[y1, x2 + i] += 1;
                        }
                    }
                    else
                    {
                        displacement = x2 - x1;

                        for (int i = 0; i <= displacement; i++)
                        {
                            ventPoints[y1, x1 + i] += 1;
                        }
                    }
                }

                // Vertical Line
                if (x1 == x2 && y1 != y2)
                {
                    if (y1 > y2)
                    {
                        displacement = y1 - y2;

                        for (int i = 0; i <= displacement; i++)
                        {
                            ventPoints[y2 + i, x2] += 1;
                        }
                    }
                    else
                    {
                        displacement = y2 - y1;

                        for (int i = 0; i <= displacement; i++)
                        {
                            ventPoints[y1 + i, x2] += 1;
                        }
                    }
                }
            }

            int totalOverlap = 0;
            for (int row = 0; row <= yDimensions; row++)
            {
                for (int column = 0; column <= xDimensions; column++)
                {
                    if (ventPoints[row, column] > 1) { totalOverlap++; }
                }
            }

            Console.WriteLine(totalOverlap);
        }
    }
}
