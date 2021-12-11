using System;
using System.Threading;

namespace Flash_Counter
{
    class Program
    {
        public static int flashes = 0;
        public static bool[,] hasFlashed;

        static void Main(string[] args)
        {
            string[] rawData = System.IO.File.ReadAllLines(@"C:\Users\lukej\OneDrive\Documents\Personal Projects\AdventOfCode\Flash Counter\Octopus Brightness.txt");
            int[,] octopus = new int[rawData.Length, rawData[0].Length];

            for (int row = 0; row < octopus.GetLength(0); row++)
            {
                for (int column = 0; column < octopus.GetLength(1); column++)
                {
                    octopus[row, column] = Convert.ToInt32(rawData[row][column] - 48);
                    Console.Write(octopus[row, column] + " ");
                }
                Console.Write("\n");
            }


            for (int day = 0; day < 100; day++)
            {
                hasFlashed = new bool[octopus.GetLength(0), octopus.GetLength(1)];

                for (int row = 0; row < octopus.GetLength(0); row++)
                {
                    for (int column = 0; column < octopus.GetLength(1); column++)
                    {
                        octopus[row, column]++;
                    }
                }

                for (int row = 0; row < octopus.GetLength(0); row++)
                {
                    for (int column = 0; column < octopus.GetLength(1); column++)
                    {
                        Flash(octopus, column, row);
                    }
                }
            }


            Console.WriteLine(flashes);
        }

        public static void Flash(int[,] octopus, int x, int y)
        {

            if (octopus[y, x] > 9 && hasFlashed[y, x] == false)
            {
                flashes++;
                octopus[y, x] = 0;
                hasFlashed[y, x] = true;

                if (y > 0 && hasFlashed[y - 1, x] == false) { octopus[y - 1, x]++; Flash(octopus, x, y - 1); }
                if (y < octopus.GetLength(0) - 1 && hasFlashed[y + 1, x] == false) { octopus[y + 1, x]++; Flash(octopus, x, y + 1); }
                if (x > 0 && hasFlashed[y, x - 1] == false) { octopus[y, x - 1]++; Flash(octopus, x - 1, y); }
                if (x < octopus.GetLength(1) - 1 && hasFlashed[y, x + 1] == false) { octopus[y, x + 1]++; Flash(octopus, x + 1, y); }

                if (y > 0 && x > 0 && hasFlashed[y - 1, x - 1] == false) { octopus[y - 1, x - 1]++; Flash(octopus, x - 1, y - 1); }
                if (y < octopus.GetLength(0) - 1 && x > 0 && hasFlashed[y + 1, x - 1] == false) { octopus[y + 1, x - 1]++; Flash(octopus, x - 1, y + 1); }
                if (x < octopus.GetLength(1) - 1 && y > 0 && hasFlashed[y - 1, x + 1] == false) { octopus[y - 1, x + 1]++; Flash(octopus, x + 1, y - 1); }
                if (x < octopus.GetLength(1) - 1 && y < octopus.GetLength(0) - 1 && hasFlashed[y + 1, x + 1] == false) { octopus[y + 1, x + 1]++; Flash(octopus, x + 1, y + 1); }
            }
        }
    }
}
