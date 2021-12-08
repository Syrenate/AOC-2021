using System;
using System.Collections.Generic;
using System.Linq;

namespace Decode_All_Outputs_V2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rawData = System.IO.File.ReadAllLines(@"C:\Users\lukej\OneDrive\Documents\Personal Projects\AdventOfCode\Decode All Outputs V2\Entries.txt");
            int[,] displayFormat = new int[10, 7];

            int outputSum = 0;
            foreach (string line in rawData)
            {
                string[] inputData = line.Split(" | ")[0].Split(" ");
                string[] outputData = line.Split(" | ")[1].Split(" ");

                string[] step1 = new string[10];
                string currentValue = "";

                foreach (string num in inputData)
                {
                    if (num.Length == 2) { step1[1] = num; }
                    else if (num.Length == 3) { step1[7] = num; }
                    else if (num.Length == 4) { step1[4] = num; }
                    else if (num.Length == 7) { step1[8] = num; }
                }

                foreach (string num in inputData)
                {
                    if (num.Length == 5)
                    {
                        if (IfContains(step1[1], num) == 2)
                        {
                            step1[3] = num;
                        }
                        else if (IfContains(step1[4], num) > 2)
                        {
                            step1[5] = num;
                        }
                        else
                        {
                            step1[2] = num;
                        }
                    }
                    else if (num.Length == 6)
                    {
                        if (IfContains(step1[1], num) != 2)
                        {
                            step1[6] = num;
                        }
                        else if (IfContains(step1[4], num) == 4)
                        {
                            step1[9] = num;
                        }
                        else
                        {
                            step1[0] = num;
                        }
                    }
                }

                for (int ind = 0; ind < outputData.Length; ind++)
                {
                    string output = outputData[ind];

                    for (int x = 0; x < step1.Length; x++)
                    {
                        int[] checkLetters = new int[output.Length];
                        for (int i = 0; i < output.Length; i++) { checkLetters[i] = Convert.ToInt32(output[i]); }
                        int[] isInLetters = new int[step1[x].Length];
                        for (int i = 0; i < step1[x].Length; i++) { isInLetters[i] = Convert.ToInt32(step1[x][i]); }

                        if (Enumerable.SequenceEqual(checkLetters.OrderBy(e => e), isInLetters.OrderBy(e => e)) == true) 
                        {
                            currentValue += x;
                        }
                    }
                }

                outputSum += Convert.ToInt32(currentValue);
            }

            int IfContains(string checkNum, string isInNumber)
            {
                bool contains = false;
                string[] checkLetters = new string[checkNum.Length];
                for (int i = 0; i < checkNum.Length; i++) { checkLetters[i] = Convert.ToString(checkNum[i]); }
                string[] isInLetters = new string[isInNumber.Length];
                for (int i = 0; i < isInNumber.Length; i++) { isInLetters[i] = Convert.ToString(isInNumber[i]); }

                int count = 0;
                for (int i = 0; i < checkLetters.Length; i++)
                {
                    string letter = checkLetters[i];
                    foreach (string compLetter in isInLetters)
                    {
                        if (letter == compLetter) { count++; }
                    }
                }

                return count;
            }

            Console.WriteLine(outputSum);
        }
    }
}