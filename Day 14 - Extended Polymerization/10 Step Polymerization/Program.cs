using System;
using System.Collections.Generic;

namespace _10_Step_Polymerization
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rawData = System.IO.File.ReadAllText(@"C:\Users\lukej\OneDrive\Documents\Personal Projects\AdventOfCode\10 Step Polymerization\rules.txt").Split("\r\n\r\n");
            Dictionary<string, string> pairInstructions = new Dictionary<string, string>();

            string basePolymer = rawData[0];

            string[] instructions = rawData[1].Split("\r\n");
            foreach (string instruction in instructions)
            {
                string[] data = instruction.Split(" -> ");
                pairInstructions.Add(data[0], data[1]);
            }
            
            for (int step = 0; step < 10; step++)
            {
                for (int i = 1; i < basePolymer.Length; i++)
                {
                    string newPolymer = "";
                    string pair = basePolymer[i - 1] + "" + basePolymer[i];

                    for (int a = 0; a < i; a++) { newPolymer += basePolymer[a]; }
                    newPolymer += pairInstructions[pair];
                    for (int a = i; a < basePolymer.Length; a++) { newPolymer += basePolymer[a]; }
                    i++;

                    basePolymer = newPolymer;
                }
            }

            Dictionary<char, int> frequency = new Dictionary<char, int>();

            for (int i = 0; i < basePolymer.Length; i++)
            {
                char letter = basePolymer[i];
                int value = 0;
                if (frequency.TryGetValue(letter, out value))
                {
                    frequency[letter]++;
                }
                else
                {
                    frequency.Add(letter, 1);
                }
            }

            int min = frequency['C']; int max = 0;
            foreach (var entry in frequency)
            {
                if (entry.Value < min) { min = entry.Value; }
                if (entry.Value > max) { max = entry.Value; }
            }

            Console.WriteLine(max - min);
        }
    }
}