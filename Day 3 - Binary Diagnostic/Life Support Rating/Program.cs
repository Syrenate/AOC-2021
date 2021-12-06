using System;
using System.Collections.Generic;

namespace Life_Support_Rating
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rawData = System.IO.File.ReadAllLines(@"C:\Users\lukej\OneDrive\Documents\Personal Projects\AdventOfCode\Life Support Rating\DiagnosticsData.txt");

            List<string> O2PassValues = new List<string>();
            List<string> CO2PassValues = new List<string>();

            foreach (string line in rawData) { O2PassValues.Add(line); }
            foreach (string line in rawData) { CO2PassValues.Add(line); }

            for (int column = 0; column < O2PassValues[0].Length; column++)
            {
                int total1s = 0; int total0s = 0;
                for (int row = 0; row < O2PassValues.Count; row++)
                {
                    if (O2PassValues[row][column] == Convert.ToChar("1"))
                    {
                        total1s++;
                    }
                    else
                    {
                        total0s++;
                    }
                }

                List<string> newO2PassValues = new List<string>();
                if (total1s >= total0s)
                {
                    for (int row = 0; row < O2PassValues.Count; row++)
                    {
                        if (O2PassValues[row][column] == Convert.ToChar("1"))
                        {
                            newO2PassValues.Add(O2PassValues[row]);
                        }
                    }
                }
                else
                {
                    for (int row = 0; row < O2PassValues.Count; row++)
                    {
                        if (O2PassValues[row][column] == Convert.ToChar("0"))
                        {
                            newO2PassValues.Add(O2PassValues[row]);
                        }
                    }
                }

                O2PassValues = newO2PassValues;

                if (O2PassValues.Count <= 1)
                {
                    column = O2PassValues[0].Length * 2;
                }
            }

            for (int column = 0; column < CO2PassValues[0].Length; column++)
            {
                int total1s = 0; int total0s = 0;
                for (int row = 0; row < CO2PassValues.Count; row++)
                {
                    if (CO2PassValues[row][column] == Convert.ToChar("1"))
                    {
                        total1s++;
                    }
                    else
                    {
                        total0s++;
                    }
                }

                List<string> newCO2PassValues = new List<string>();
                if (total1s >= total0s)
                {
                    for (int row = 0; row < CO2PassValues.Count; row++)
                    {
                        if (CO2PassValues[row][column] == Convert.ToChar("0"))
                        {
                            newCO2PassValues.Add(CO2PassValues[row]);
                        }
                    }
                }
                else if (total1s < total0s)
                {
                    for (int row = 0; row < CO2PassValues.Count; row++)
                    {
                        if (CO2PassValues[row][column] == Convert.ToChar("1"))
                        {
                            newCO2PassValues.Add(CO2PassValues[row]);
                        }
                    }
                }

                CO2PassValues = newCO2PassValues;

                if (CO2PassValues.Count <= 1)
                {
                    column = CO2PassValues[0].Length * 2;
                }
            }

            string O2Rating = O2PassValues[0];
            string CO2Rating = CO2PassValues[0];

            Console.WriteLine(O2Rating + " " + CO2Rating);

            int O2Decimal = Convert.ToInt32(O2Rating, 2); 
            int CO2Decimal = Convert.ToInt32(CO2Rating, 2);

            Console.WriteLine(O2Decimal * CO2Decimal);
        }
    }
}
