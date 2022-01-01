using System;
using System.Collections.Generic;

namespace FInal_Sum_Magnitude
{
    class Program
    {
        static string syntax = "[,]";

        static void Main(string[] args)
        {
            string[] rawData = System.IO.File.ReadAllLines(@"C:\Users\lukej\OneDrive\Documents\Personal Projects\AdventOfCode\FInal Sum Magnitude\strings.txt");

            for (int i = 0; i < rawData.Length; i++)
            {
                rawData[i] = ReduceString(rawData[i]);
            }

            string newData = "";
            for (int i = 1; i < rawData.Length; i++)
            {
                if (i == 1)
                {
                    newData = AddSnailfish(rawData[i - 1], rawData[i]);
                }
                else
                {
                    newData = AddSnailfish(newData, rawData[i]);
                }

                newData = ReduceString(newData);
            }
        }

        static string AddSnailfish(string newData, string data)
        {
            string fish1 = newData;
            string fish2 = data;
            return $"[{fish1},{fish2}]";
        }

        static string SplitSnailfish(string data, int index)
        {
            int regularNumber = Convert.ToInt32(data[index] + "" + data[index + 1]);

            string splitString = "";
            if (regularNumber % 2 == 0)
            {
                splitString = $"[{regularNumber / 2},{regularNumber / 2}]";
            }
            else
            {
                splitString = $"[{regularNumber / 2},{(regularNumber / 2) + 1}]";
            }

            string newData = "";

            for (int i = 0; i < index; i++)
            {
                newData += data[i];
            }

            newData += splitString;

            for (int i = index + 2; i < data.Length; i++)
            {
                newData += data[i];
            }

            return newData;
        }

        static int[] CanSplit(string data) 
        {
            int[] returnData = new int[2] { 0, 0 };

            for (int i = 0; i < data.Length - 1; i++)
            {
                bool isSyntax = false;
                string value = data[i] + "" + data[i + 1];

                if (syntax.Contains(data[i])) { isSyntax = true; }
                else if (syntax.Contains(data[i + 1])) { isSyntax = true; }

                if (isSyntax == false)
                {
                    if (Convert.ToInt32(value) > 9)
                    {
                        returnData[0] = 1;
                        returnData[1] = i;

                        return returnData;
                    }
                }
            }

            return returnData;
        }

        static string ExplodeSnailfish(string data, int index)
        {
            int[] value1 = new int[3] { data[index + 1] - 48, 0, 0 } ;
            int[] value2 = new int[3] { data[index + 3] - 48, 0, 0 };

            for (int i = index; i > 0; i--)
            {
                if (!syntax.Contains(data[i]))
                {
                    if (!syntax.Contains(data[i - 1]))
                    {
                        value1[0] += ((Convert.ToInt32(data[i - 1]) - 48) * 10) + (Convert.ToInt32(data[i]) - 48);
                        value1[1] = i;
                        value1[2] = 2;
                    }
                    else
                    {
                        value1[0] += Convert.ToInt32(data[i]) - 48;
                        value1[1] = i;
                        value1[2] = 1;
                    }
                    i = 0;
                }
            }

            for (int i = index + 5; i < data.Length; i++)
            {
                if (!syntax.Contains(data[i]))
                {
                    if (!syntax.Contains(data[i + 1]))
                    {
                        value2[0] += (Convert.ToInt32(data[i]) - 48) * 10 + (Convert.ToInt32(data[i + 1]) - 48);
                        value2[1] = i;
                        value2[2] = 2;
                    }
                    else
                    {
                        value2[0] += Convert.ToInt32(data[i]) - 48;
                        value2[1] = i;
                        value2[2] = 1;
                    }
                    i = data.Length;
                }
            }

            string newData = "";

            if (value1[2] == 1)
            {
                for (int i = 0; i < value1[1]; i++)
                {
                    newData += data[i];
                }

                newData += value1[0];

                for (int i = value1[1] + 1; i < index; i++)
                {
                    newData += data[i];
                }
            }
            else if (value1[2] == 2)
            {
                for (int i = 0; i < value1[1]; i++)
                {
                    newData += data[i];
                }

                newData += value1[0];

                for (int i = value1[1] + 2; i < index; i++)
                {
                    newData += data[i];
                }
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    newData += data[i];
                }
            }

            newData += "0";

            if (value2[2] == 1)
            {
                for (int i = index + 5; i < value2[1]; i++)
                {
                    newData += data[i];
                }

                newData += value2[0];

                for (int i = value2[1] + 1; i < data.Length; i++)
                {
                    newData += data[i];
                }
            }
            else if (value2[2] == 2)
            {
                for (int i = index + 5; i < value2[1]; i++)
                {
                    newData += data[i];
                }

                newData += value2[0];

                for (int i = value2[1] + 2; i < data.Length; i++)
                {
                    newData += data[i];
                }
            }
            else
            {
                for (int i = index + 5; i < data.Length; i++)
                {
                    newData += data[i];
                }
            }

            return newData;
        }

        static int[] CanExplode(string data)
        {
            // first will be 1/0 (can explode/cant explode), second is index
            int[] returnValues = new int[2] { 0, 0 };

            List<char> brackets = new List<char>();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == '[')
                {
                    brackets.Add('[');
                }
                else if (data[i] == ']')
                {
                    brackets.Remove('[');
                }

                if (brackets.Count == 5)
                {
                    returnValues[0] = 1;
                    returnValues[1] = i;
                    return returnValues;
                }
            }

            return returnValues;
        }

        static string ReduceString(string data)
        {
            bool isReduced = false;

            while (!isReduced)
            {
                int[] explode = CanExplode(data);
                int[] split = CanSplit(data);

                bool hasExploded = false;
                bool hasSplit = false;

                int dataLength = data.Length;

                if (explode[1] + 1 > split[1])
                {
                    if (split[0] == 1 && hasExploded == false)
                    {
                        data = SplitSnailfish(data, split[1]);
                        hasSplit = true;
                    }

                    if (explode[0] == 1 && hasSplit == false)
                    {
                        data = ExplodeSnailfish(data, explode[1]);
                        hasExploded = true;
                    }
                }
                else
                {
                    if (explode[0] == 1 && hasSplit == false)
                    {
                        data = ExplodeSnailfish(data, explode[1]);
                        hasExploded = true;
                    }

                    if (split[0] == 1 && hasExploded == false)
                    {
                        data = SplitSnailfish(data, split[1]);
                        hasSplit = true;
                    }

                }

                if (hasSplit == false && hasExploded == false)
                {
                    Console.WriteLine(data);
                    isReduced = true;
                }
            }

            return data;
        }
    }
}
