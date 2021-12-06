using System;

namespace Aim_Instructions
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rawData = System.IO.File.ReadAllLines(@"C:\Users\lukej\OneDrive\Documents\Personal Projects\AdventOfCode\Aim Instructions\Instructions.txt");
            int aim = 0; int xPos = 0; int depth = 0;

            foreach (string command in rawData)
            {
                string[] instruction = command.Split(" ");

                if (instruction[0] == "down")
                {
                    aim += Convert.ToInt32(instruction[1]);
                }
                else if (instruction[0] == "up")
                {
                    aim -= Convert.ToInt32(instruction[1]);
                }
                else
                {
                    xPos += Convert.ToInt32(instruction[1]);
                    depth += Convert.ToInt32(instruction[1]) * aim;
                }
            }

            Console.WriteLine(xPos * depth);
        }
    }
}
