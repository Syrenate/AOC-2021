using System;
using System.Collections.Generic;

namespace Illegal_Score
{
    class Program
    {
        public static string opens = "([{<";
        public static string closes = ")]}>";
        public static int[] charValues = new int[] { 1, 2, 3, 4 };

        static void Main(string[] args)
        {
            string[] rawData = System.IO.File.ReadAllLines(@"C:\Users\lukej\OneDrive\Documents\Personal Projects\AdventOfCode\Incomplete Score\CorruptedData.txt");

            List<long> scores = new List<long>();

            foreach (string line in rawData)
            {
                long calc = 0;
                char firstToCorrupt = CheckIfCorrupted(line);

                if (firstToCorrupt == 'N')
                {
                    string completeLine = CompleteIncomplete(line);
                    
                    foreach (char symbol in completeLine)
                    {
                        calc *= 5;
                        calc += ConvertToValue(symbol);
                    }

                    scores.Add(calc);
                }
            }

            while (IsSorted(scores) == false)
            {
                for (int i = 1; i < scores.Count; i++)
                {
                    if (scores[i] < scores[i - 1])
                    {
                        long tempScore = scores[i];
                        scores[i] = scores[i - 1];
                        scores[i - 1] = tempScore;
                    }
                }
            }

            Console.WriteLine(scores[scores.Count / 2]);
        }

        public static char CheckIfCorrupted(string line)
        {
            Stack<char> openers = new Stack<char>();

            for (int i = 0; i < line.Length; i++)
            {
                if (opens.Contains(line[i]) == true)
                {
                    openers.Push(line[i]);
                }
                else
                {
                    char closer = openers.Pop();

                    if (ConvertToCloser(closer) != line[i])
                    {
                        return line[i];
                    }
                }
            }

            return 'N';
        }

        public static string CompleteIncomplete(string line)
        {
            List<char> closers = new List<char>();
            string closing = "";

            for (int i = line.Length - 1; i >= 0; i--)
            {
                if (closes.Contains(line[i]) == true)
                {
                    closers.Add(line[i]);
                }
                else
                {
                    bool found = false;
                    for (int x = 0; x < closers.Count; x++)
                    {
                        if (closers[x] == ConvertToCloser(line[i]))
                        {
                            closers.RemoveAt(x);
                            x = closers.Count + 1;
                            found = true;
                        }
                    }

                    if (found == false)
                    {
                        closing += ConvertToCloser(line[i]);
                    }
                }
            }

            return closing;
        }


        public static char ConvertToCloser(char opener)
        {
            if (opener == '(')
            {
                return ')';
            }

            if (opener == '[')
            {
                return ']';
            }

            if (opener == '{')
            {
                return '}';
            }

            if (opener == '<')
            {
                return '>';
            }

            return opener;
        }

        public static int ConvertToValue(char closer)
        {
            if (closer == ')')
            {
                return charValues[0];
            }

            if (closer == ']')
            {
                return charValues[1];
            }

            if (closer == '}')
            {
                return charValues[2];
            }

            if (closer == '>')
            {
                return charValues[3];
            }

            return closer;
        }

        public static bool IsSorted(List<long> list)
        {
            bool sorted = true;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] < list[i - 1])
                {
                    sorted = false;
                }
            }
            return sorted;
        }
    }
}
