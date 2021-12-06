using System;

namespace Gamma_and_Epsilon_Rate
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rawData = System.IO.File.ReadAllLines(@"C:\Users\lukej\OneDrive\Documents\Personal Projects\AdventOfCode\Gamma and Epsilon Rate\DiagnosticsData.txt");

            int[] gammaRate = new int[rawData[0].Length]; 
            int[] epsilonRate = new int[rawData[0].Length];

            for (int column = 0; column < rawData[0].Length; column++)
            {
                int total1s = 0; int total0s = 0;
                for (int row = 0; row < rawData.Length; row++)
                {
                    if (rawData[row][column] == Convert.ToChar("1"))
                    {
                        total1s++;
                    }
                    else
                    {
                        total0s++;
                    }
                }

                if (total1s > total0s)
                {
                    gammaRate[column] = 1;
                    epsilonRate[column] = 0;
                }
                else
                {
                    gammaRate[column] = 0;
                    epsilonRate[column] = 1;
                }
            }

            int gammaDecimal = 0; int epsilonDecimal = 0;

            int ind = gammaRate.Length - 1;
            for (int i = 0; i < gammaRate.Length; i++)
            {
                gammaDecimal += gammaRate[i] * Convert.ToInt32(Math.Pow(2, ind));
                epsilonDecimal += epsilonRate[i] * Convert.ToInt32(Math.Pow(2, ind));
                ind--;
            }

            Console.WriteLine(gammaDecimal * epsilonDecimal);
        }
    }
}
