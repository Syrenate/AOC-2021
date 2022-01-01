using System;
using System.Collections.Generic;

namespace _2x_Enhancment_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rawData = System.IO.File.ReadAllText(@"C:\Users\lukej\OneDrive\Documents\Personal Projects\AdventOfCode\2x Enhancment Algorithm\OriginalImage.txt").Split("\r\n\r\n");

            char[] algorithm = new char[rawData[0].Length];

            for (int i = 0; i < rawData[0].Length; i++)
            {
                algorithm[i] = rawData[0][i];
            }

            string[] imageLines = rawData[1].Split("\n");

            int[,] image = new int[imageLines.Length, imageLines[0].Length];
            for (int i = 0; i < image.GetLength(0); i++)
            {
                for (int n = 0; n < image.GetLength(1) - 1; n++)
                {
                    if (imageLines[i][n] == '#') { image[i, n] = 1; }
                    else if (imageLines[i][n] == '.') { image[i, n] = 0; }
                }
            }

            DisplayImage(image);

            for (int i = 0; i < 1; i++)
            {
                image = Enhancment(algorithm, image);
            }

            DisplayImage(image);

            int sum = 0;
            for (int i = 5; i < image.GetLength(0) - 5; i++)
            {
                for (int n = 4; n < image.GetLength(1) - 4; n++)
                {
                    if (image[i, n] == 1)
                    {
                        sum++;
                    }
                }
            }

            Console.WriteLine(sum);
        }

        static int[,] Enhancment(char[] algorithm, int[,] image)
        {
            int[,] newImage = new int[image.GetLength(0) + 8, image.GetLength(1) + 8];

            for (int row = 0; row < image.GetLength(0); row++)
            {
                for (int column = 0; column < image.GetLength(1); column++)
                {
                    newImage[row + 4, column + 4] = image[row, column];
                }
            }

            string[,] binaryArray = new string[image.GetLength(0) + 8, image.GetLength(1) + 8];

            for (int row = 0; row < newImage.GetLength(0); row++)
            {
                for (int column = 0; column < newImage.GetLength(1); column++)
                {
                    string binary = "";
                    if (row > 0 && column > 0) { if (newImage[row - 1, column - 1] == 1) { binary += "1"; } else { binary += "0"; } } else { binary += "0"; }
                    if (row > 0) { if (newImage[row - 1, column] == 1) { binary += "1"; } else { binary += "0"; } } else { binary += "0"; }
                    if (row > 0 && column < newImage.GetLength(1) - 1) { if (newImage[row - 1, column + 1] == 1) { binary += "1"; } else { binary += "0"; } } else { binary += "0"; }
                    if (column > 0) { if (newImage[row, column - 1] == 1) { binary += "1"; } else { binary += "0"; } } else { binary += "0"; }
                    if (newImage[row, column] == 1) { binary += "1"; } else { binary += "0"; }
                    if (column < newImage.GetLength(1) - 1) { if (newImage[row, column + 1] == 1) { binary += "1"; } else { binary += "0"; } } else { binary += "0"; }
                    if (row < newImage.GetLength(0) - 1 && column > 0) { if (newImage[row + 1, column - 1] == 1) { binary += "1"; } else { binary += "0"; } } else { binary += "0"; }
                    if (row < newImage.GetLength(0) - 1) { if (newImage[row + 1, column] == 1) { binary += "1"; } else { binary += "0"; } } else { binary += "0"; }
                    if (row < newImage.GetLength(0) - 1 && column < newImage.GetLength(1) - 1) { if (newImage[row + 1, column + 1] == 1) { binary += "1"; } else { binary += "0"; } } else { binary += "0"; }

                    binaryArray[row, column] = binary;
                }
            }

            for (int row = 0; row < newImage.GetLength(0); row++)
            {
                for (int column = 0; column < newImage.GetLength(1); column++)
                {
                    int num = BinaryToInt(binaryArray[row, column]);
                    if (algorithm[num] == '#')
                    {
                        newImage[row, column] = 1;
                    }
                    else
                    {
                        newImage[row, column] = 0;
                    }
                }
            }

            return newImage;
        }

        static int BinaryToInt(string binary)
        {
            int sum = 0;

            int count = 0;
            for (int i = binary.Length - 1; i >= 0; i--)
            {
                sum += Convert.ToInt32((Convert.ToInt32(binary[i]) - 48) * Math.Pow(2, count));
                count++;
            }

            return sum;
        }


        static void DisplayImage(int[,] image)
        {
            for (int row = 0; row < image.GetLength(0); row++)
            {
                for (int column = 0; column < image.GetLength(1); column++)
                {
                    if (image[row, column] == 1)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }

                Console.Write("\n");
            }

            Console.WriteLine("\n");
        }
    }
}
