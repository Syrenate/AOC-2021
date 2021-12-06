using System;
using System.Collections.Generic;

namespace _80_Day_Growth
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rawData = System.IO.File.ReadAllText(@"C:\Users\lukej\OneDrive\Documents\AOC-2021\AdventOfCode\80 Day Growth\Lanternfish Population.txt").Split(",");
            List<int> population = new List<int>();
            for (int i = 0; i < rawData.Length; i++) { population.Add(Convert.ToInt32(rawData[i])); }

            for (int day = 0; day < 80; day++)
            {
                List<int> newFish = new List<int>();
                foreach (int fish in population)
                {
                    if (fish == 0) { newFish.Add(6); newFish.Add(8); }
                    else { newFish.Add(fish - 1); }
                }
                population = newFish;
                Console.WriteLine(day + " " + population.Count);
            }

            Console.WriteLine(population.Count);
        }
    }
}
