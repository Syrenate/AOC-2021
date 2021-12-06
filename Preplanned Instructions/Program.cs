using System;

namespace Preplanned_Instructions
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rawData = System.IO.File.ReadAllLines(@"C:\Users\lukej\OneDrive\Documents\Personal Projects\AdventOfCode\Preplanned Instructions\Instructions.txt");
            int depth = 0; int xPos = 0;

            foreach (string command in rawData)
            {
                string[] instruction = command.Split(" ");

                if (instruction[0] == "down")
                {
                    depth += Convert.ToInt32(instruction[1]);
                }
                else if(instruction[0] == "up")
                {
                    depth -= Convert.ToInt32(instruction[1]);
                }
                else
                {
                    xPos += Convert.ToInt32(instruction[1]);
                }
            }

            Console.WriteLine(xPos * depth);
        }
    }
}
