using System;
using System.Threading;

namespace Crab_Movement
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rawData = System.IO.File.ReadAllText(@"C:\Users\lukej\OneDrive\Documents\Personal Projects\AdventOfCode\Crab Movement\Crab Coords.txt").Split(",");
            int[] crabCoords = new int[rawData.Length];
            for (int i = 0; i < rawData.Length; i++) { crabCoords[i] = Convert.ToInt32(rawData[i]); }


            while (IsSorted(crabCoords) == false)
            {
                for (int ind = 1; ind < crabCoords.Length; ind++)
                {
                    if (crabCoords[ind] < crabCoords[ind - 1])
                    {
                        int tempValue = crabCoords[ind];
                        crabCoords[ind] = crabCoords[ind - 1];
                        crabCoords[ind - 1] = tempValue;
                    }
                }
            }

            int midIndex = crabCoords.Length / 2;
            int median = crabCoords[midIndex];

            int fuel = 0;
            foreach (int num in crabCoords)
            {
                if (num > median)
                {
                    fuel += num - median;
                }
                else
                {
                    fuel += median - num;
                }
            }

            Console.WriteLine(fuel);



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
