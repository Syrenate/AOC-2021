using System;
using System.Collections.Generic;

namespace _1000_Score_Limit
{
    class Player
    {
        public int start;
        public int score;

        public Dictionary<int, bool> position = new Dictionary<int, bool>() {
            { 0, false }, { 1, false }, { 2, false }, { 3, false }, { 4, false },
            { 5, false }, { 6, false }, { 7, false }, { 8, false }, { 9, false }  };
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] rawData = System.IO.File.ReadAllLines(@"C:\Users\lukej\OneDrive\Documents\Personal Projects\AdventOfCode\1000 Score Limit\Starting.txt");

            Player player1 = new Player();
            Player player2 = new Player();

            player1.start = Convert.ToInt32(rawData[0].Split(": ")[1]);
            player2.start = Convert.ToInt32(rawData[1].Split(": ")[1]);

            int dice = 1;

            player1.position[player1.start - 1] = true;
            player2.position[player2.start - 1] = true;

            int output = 0;
            while (player1.score <= 1000 && player2.score <= 1000)
            {
                if (player2.score <= 1000)
                {
                    player1 = movePawn(player1, dice);
                    dice += 3;
                    if (dice > 100)
                    {
                        dice -= 100;
                    }
                }
                else
                {
                    output =  dice + (3 - (dice % 3));
                }

                if (player1.score <= 1000)
                {
                    player2 = movePawn(player2, dice);
                    dice += 3;
                    if (dice > 100)
                    {
                        dice -= 100;
                    }
                }
                else
                {
                    output = dice + (3 - (dice % 3));
                }
            }

            Console.WriteLine(dice + ", " + output);
        }

        static Player movePawn(Player player, int dice)
        {
            int position = 0;
            foreach (var pos in player.position)
            {
                if (pos.Value == true)
                {
                    position = pos.Key;
                }
            }

            int sum = (3 * dice) + 3;
            string newPos = Convert.ToString(sum + position);
            player.score += newPos[newPos.Length - 1] - 47;
            player.position[position] = false;
            player.position[newPos[newPos.Length - 1] - 48] = true;

            return player;
        }
    }
}
