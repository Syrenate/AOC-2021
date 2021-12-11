using System;
using System.Collections.Generic;

namespace Illegal_Score
{
    class Program
    {
        public static string opens = "([{<";

        static void Main(string[] args)
        {
            string[] rawData = System.IO.File.ReadAllLines(@"C:\Users\lukej\OneDrive\Documents\Personal Projects\AdventOfCode\Illegal Score\CorruptedData.txt");

            int score = 0;
            
            foreach (string line in rawData)
            {
                char firstToCorrupt = CheckIfCorrupted(line);
                if (firstToCorrupt != 'N')
                {
                    if (firstToCorrupt == ')')
                    {
                        score += 3;
                    }
                    else if (firstToCorrupt == ']')
                    {
                        score += 57;
                    }
                    else if (firstToCorrupt == '}')
                    {
                        score += 1197;
                    }
                    else if (firstToCorrupt == '>')
                    {
                        score += 25137;
                    }
                }
            }

            Console.WriteLine(score);
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
    }
}
