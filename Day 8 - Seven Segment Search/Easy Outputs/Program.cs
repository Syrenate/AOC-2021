using System;
using System.Collections.Generic;

namespace Easy_Outputs
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rawData = System.IO.File.ReadAllLines(@"C:\Users\lukej\OneDrive\Documents\Personal Projects\AdventOfCode\Easy Outputs\Entries.txt");
            List<string> outputValues = new List<string>();
            for (int i = 0; i < rawData.Length; i++)
            {
                string[] outputData = rawData[i].Split(" | ")[1].Split(" ");
                foreach (string value in outputData)
                {
                    outputValues.Add(value);
                }
            }

            int validOutputs = 0;
            foreach (string value in outputValues)
            {
                if (value.Length == 2 || value.Length == 3 || value.Length == 4 || value.Length == 7)
                {
                    validOutputs++;
                }
            }

            Console.WriteLine(validOutputs);
        }
    }
}
