using System;
using System.Collections.Generic;

namespace Trajectory_count
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
            string[] rawData = (System.IO.File.ReadAllText(@"C:\Users\lukej\OneDrive\Documents\Personal Projects\AdventOfCode\Trajectory count\range.txt")).Split(" ");
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

            for (int y = -100; y < 100; y++)
            {
                for (int i = -100; i < 100; i++)
                {
                    trajectory current = new trajectory();
                    current.posX = 0; current.posY = 0;
                    current.startXVel = i; current.startYVel = y;
                    current.velX = current.startXVel; current.velY = current.startYVel;

                    if (validTrajectory(current, targetX, targetY)) { intersectVelocities.Add(current); }
                }
            }

            int highestY = 0;
            foreach (trajectory x in intersectVelocities)
            {
                if (x.highestYPos > highestY) { highestY = x.highestYPos; }
            }

            Console.WriteLine(highestY);
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
