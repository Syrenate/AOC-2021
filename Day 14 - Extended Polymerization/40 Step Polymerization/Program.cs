using System;
using System.Collections.Generic;

namespace _40_Step_Polymerization
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rawData = System.IO.File.ReadAllText(@"C:\Users\lukej\OneDrive\Documents\Personal Projects\AdventOfCode\40 Step Polymerization\rules.txt").Split("\r\n\r\n");
            Dictionary<string, string> pairInstructions = new Dictionary<string, string>(); // Rules

            // Sets pair rules
            string[] instructions = rawData[1].Split("\r\n");
            foreach (string instruction in instructions)
            {
                string[] data = instruction.Split(" -> ");
                pairInstructions.Add(data[0], data[1]);
            }

            string basePolymer = rawData[0]; // Starting polymer

            Dictionary<string, long> pairs = FindAllPairs(pairInstructions); // Pair frequency
            Dictionary<char, long> frequency = new Dictionary<char, long>(); // Letter frequency

            foreach (var entry in pairInstructions)
            {
                if (!frequency.TryGetValue(Convert.ToChar(entry.Value), out _))
                {
                    frequency.Add(Convert.ToChar(entry.Value), 0);
                }
            }

            for (int i = 0; i < basePolymer.Length; i++)
            {
                if (i > 0) 
                {
                    string pair = basePolymer[i - 1] + "" + basePolymer[i];
                    pairs[pair] += 1;
                }

                if (frequency.TryGetValue(Convert.ToChar(basePolymer[i]), out _))
                {
                    frequency[Convert.ToChar(basePolymer[i])]++;
                }
            }

            for (int step = 0; step < 40; step++)
            {
                Dictionary<string, long> newPairs = FindAllPairs(pairInstructions);
                foreach (var entry in pairs)
                {
                    string pair = entry.Key;
                    long value = entry.Value;

                    string result = pairInstructions[pair];

                    frequency[Convert.ToChar(result)] += value;

                    newPairs[pair[0] + "" + result] += value;
                    newPairs[result + "" + pair[1]] += value;
                }

                pairs = newPairs;
            }

            long min = frequency['S']; long max = 0;
            foreach (var entry in frequency)
            {
                if (min > entry.Value) { min = entry.Value; }
                if (max < entry.Value) { max = entry.Value; }
            }

            Console.WriteLine(max - min);

            //Dictionary<char, int> frequency = new Dictionary<char, int>();

            //for (int i = 0; i < basePolymer.Length; i++)
            //{
            //    char letter = basePolymer[i];
            //    if (frequency.TryGetValue(letter, out _))
            //    {
            //        frequency[letter]++;
            //    }
            //    else
            //    {
            //        frequency.Add(letter, 1);
            //    }
            //}

            //int min = frequency['C']; int max = 0;
            //foreach (var entry in frequency)
            //{
            //    if (entry.Value < min) { min = entry.Value; }
            //    if (entry.Value > max) { max = entry.Value; }
            //}

            //Console.WriteLine(max - min);
        }

        static Dictionary<string, long> FindAllPairs(Dictionary<string, string> combinations)
        {
            Dictionary<string, long> pairs = new Dictionary<string, long>();

            foreach (var entry in combinations)
            {
                string letter = entry.Key;
                if (!pairs.TryGetValue(letter, out _))
                {
                    pairs.Add(letter, 0);
                }
            }

            return pairs;
        }

        static Dictionary<char, long> FinalAllLetters(string polymer)
        {
            Dictionary<char, long> frequency = new Dictionary<char, long>();

            for (int i = 0; i < polymer.Length; i++)
            {
                if (frequency.TryGetValue(polymer[i], out _))
                {

                }
            }

            return frequency;
        }
    }
}
