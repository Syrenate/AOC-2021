using System;
using System.Collections.Generic;

namespace Maximum_Turning_Point
{
    class trajectory
    {
        public int posX; public int posY;
        public int velX; public int velY;

        public int startXVel = 0;
        public int startYVel = 0;

        public int highestYPos = 0;
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] rawData = (System.IO.File.ReadAllText(@"C:\Users\lukej\OneDrive\Documents\Personal Projects\AdventOfCode\Maximum Turning Point\RANGE.txt")).Split(" ");
            int[] targetX = new int[2];
            int[] targetY = new int[2];

            foreach (string range in rawData)
            {
                if (!range.Contains("area"))
                {
                    string[] data = range.Split("...");
                    foreach (string d in data)
                    {
                        if (d.Contains("x"))
                        {
                            string[] n = d.Split("..");
                            targetX[0] = Convert.ToInt32(d.Split("..")[0].Split("=")[1]);
                            targetX[1] = Convert.ToInt32(d.Split("..")[1].Split(",")[0]);
                        }
                        else if (d.Contains("y"))
                        {
                            string[] n = d.Split("..");
                            targetY[0] = Convert.ToInt32(d.Split("..")[0].Split("=")[1]);
                            targetY[1] = Convert.ToInt32(d.Split("..")[1].Split(",")[0]);
                        }
                    }
                }
            }

            List<trajectory> intersectVelocities = new List<trajectory>();
            
            for (int y = -200; y < 200; y++)
            {
                for (int i = -200; i < 200; i++)
                {
                    trajectory current = new trajectory();
                    current.posX = 0; current.posY = 0;
                    current.startXVel = i; current.startYVel = y;
                    current.velX = current.startXVel; current.velY = current.startYVel;

                    if (validTrajectory(current, targetX, targetY)) { intersectVelocities.Add(current); }
                }
            }

            int total = 0;
            foreach (trajectory x in intersectVelocities)
            {
                Console.Write(x.startXVel + "," + x.startYVel);

                string coords = x.startXVel + "," + x.startYVel;
                for (int i = 8; i > coords.Length; i--)
                {
                    Console.Write(" ");
                }

                if (total % 9 == 0 && total != 0) { Console.Write("\n"); }
                total++;
            }

            Console.WriteLine(total);
        }

        static bool validTrajectory(trajectory current, int[] xRange, int[] yRange)
        {
            while (current.posY >= yRange[1])
            {
                current.posX += current.velX;
                current.posY += current.velY;

                if (current.velY == 0)
                {
                    current.highestYPos = current.posY;
                }


                if (current.velX > 0) { current.velX--; }
                else if (current.velX < 0) { current.velX++; }

                current.velY--;


                if (current.posX >= xRange[0] && current.posX <= xRange[1] && current.posY >= yRange[0] && current.posY <= yRange[1])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
