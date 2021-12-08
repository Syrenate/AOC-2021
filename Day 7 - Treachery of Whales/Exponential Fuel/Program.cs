using System;

namespace Exponential_Fuel
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rawData = System.IO.File.ReadAllText(@"C:\Users\lukej\OneDrive\Documents\Personal Projects\AdventOfCode\Exponential Fuel\Crab Coords.txt").Split(",");
            int[] crabs = new int[rawData.Length];
            for (int i = 0; i < rawData.Length; i++) { crabs[i] = Convert.ToInt32(rawData[i]); }

            int highestCrab = 0;
            int lowestCrab = 0;
            foreach (int crab in crabs)
            {
                if (crab > highestCrab) { highestCrab = crab; }
                if (crab < lowestCrab) { lowestCrab = crab; }
            }

            Console.WriteLine(lowestCrab + ", " + highestCrab);

            int minFuel = int.MaxValue;
            for (int i = lowestCrab; i < highestCrab; i++)
            {
                int fuel = 0;
                for (int x = 0; x < crabs.Length; x++)
                {
                    int stepsNeeded = Math.Abs(crabs[x] - i);
                    for (int a = 1; a < stepsNeeded + 1; a++)
                    {
                        fuel += a;
                    }
                }
                if (fuel < minFuel)
                {
                    minFuel = fuel;
                }
                Console.WriteLine(minFuel);
            }

            Console.WriteLine(minFuel);



            bool IsSorted(int[] a)
            {
                for (int i = 1; i < a.Length; i++)
                {
                    if (a[i] < a[i - 1])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
