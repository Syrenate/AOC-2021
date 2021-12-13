using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Infrared_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string[] rawData = System.IO.File.ReadAllText(@"C:\Users\lukej\OneDrive\Documents\Personal Projects\AdventOfCode\Infrared Code\Sheet.txt").Split("\r\n\r\n");
            string[] points = rawData[0].Split("\r\n"); string[] folds = rawData[1].Split("\r\n");

            int maxX = 0; int maxY = 0;
            foreach (string point in points)
            {
                string[] data = point.Split(",");
                if (Convert.ToInt32(data[0]) > maxX) { maxX = Convert.ToInt32(data[0]); }
                if (Convert.ToInt32(data[1]) > maxY) { maxY = Convert.ToInt32(data[1]); }
            }

            bool[,] sheet = new bool[maxY + 1, maxX + 1];
            foreach (string point in points)
            {
                string[] data = point.Split(",");
                sheet[Convert.ToInt32(data[1]), Convert.ToInt32(data[0])] = true;
            }

            foreach (string fold in folds)
            {
                int foldLine = Convert.ToInt32(fold.Split("=")[1]);

                if (fold.Contains("y="))
                {
                    for (int row = foldLine + 1; row < sheet.GetLength(0); row++)
                    {
                        for (int column = 0; column < sheet.GetLength(1); column++)
                        {
                            if (sheet[row, column] == true)
                            {
                                int distance = row - foldLine;
                                sheet[row, column] = false;
                                sheet[foldLine - distance, column] = true;
                            }
                        }
                    }

                    bool[,] newSheet = new bool[foldLine, sheet.GetLength(1)];

                    for (int i = 0; i < newSheet.GetLength(0); i++)
                    {
                        for (int x = 0; x < newSheet.GetLength(1); x++)
                        {
                            if (sheet[i, x]) { newSheet[i, x] = true; }
                        }
                    }

                    sheet = newSheet;
                }

                if (fold.Contains("x="))
                {
                    for (int row = 0; row < sheet.GetLength(0); row++)
                    {
                        for (int column = foldLine + 1; column < sheet.GetLength(1); column++)
                        {
                            if (sheet[row, column] == true)
                            {
                                int distance = column - foldLine;
                                sheet[row, foldLine - distance] = true;
                            }
                        }
                    }

                    bool[,] newSheet = new bool[sheet.GetLength(0), foldLine];

                    for (int i = 0; i < newSheet.GetLength(0); i++)
                    {
                        for (int x = 0; x < newSheet.GetLength(1); x++)
                        {
                            if (sheet[i, x]) { newSheet[i, x] = true; }
                        }
                    }

                    sheet = newSheet;
                }
            }

            int dots = 0;
            for (int i = 0; i < sheet.GetLength(0); i++)
            {
                for (int x = 0; x < sheet.GetLength(1); x++)
                {
                    if (sheet[i, x]) { Console.Write("██"); }
                    else { Console.Write("  "); }
                }
                Console.Write("\n");
            }

            Console.WriteLine(dots);
        }
    }
}
