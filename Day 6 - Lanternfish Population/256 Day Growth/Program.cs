using System;
using System.Collections.Generic;
using System.Linq;

namespace _80_Day_Growth
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rawData = System.IO.File.ReadAllText(@"C:\Users\lukej\OneDrive\Documents\AOC-2021\AdventOfCode\256 Day Growth\Lanternfish Population.txt").Split(",");

            long[] population = new long[9];
            for (int fish = 0; fish < rawData.Length; fish++)
            {
                population[Convert.ToInt32(rawData[fish])]++;
            }

            for (int day = 0; day < 256; day++)
            {
                long[] nextFish = new long[9];

                for (long fish = 0; fish < 8; fish++)
                {
                    nextFish[fish] = population[fish + 1];
                }

                nextFish[8] = population[0];
                nextFish[6] += population[0];
                population = nextFish;
            }

            long totalFish = 0;
            foreach (long pop in population) { totalFish += pop; }
            Console.WriteLine(totalFish);
        }
    }
}
