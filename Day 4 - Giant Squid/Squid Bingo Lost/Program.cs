using System;
using System.Collections.Generic;

namespace Squid_Bingo_Lost
{
    class Program
    {
        static void Main(string[] args)
        {
            bool bingo = false;
            string[] rawData = (System.IO.File.ReadAllText(@"C:\Users\lukej\OneDrive\Documents\AOC-2021\AdventOfCode\Squid Bingo Lost\BingBoards.txt").Split("\r\n\r\n"));
            bool[,] boardData = new bool[rawData.Length, 25];
            int[,] boardValues = new int[rawData.Length, 25];
            string[] possibleDraws = rawData[0].Split(",");

            for (int i = 1; i < rawData.Length; i++)
            {
                for (int row = 0; row < 5; row++)
                {
                    for (int column = 0; column < 5; column++)
                    {
                        boardData[i, (row * 5) + column] = false;
                    }
                }
            }

            for (int i = 1; i < rawData.Length; i++)
            {
                string[] boardRows = rawData[i].Split("\n");
                for (int row = 0; row < boardRows.Length; row++)
                {
                    string[] tempRowValues = boardRows[row].Split(" ");
                    int column = 0;
                    for (int value = 0; value < tempRowValues.Length; value++)
                    {
                        if (tempRowValues[value] != "")
                        {
                            boardValues[i, (row * 5) + column] = Convert.ToInt32(tempRowValues[value]);
                            column++;
                        }
                    }
                }
            }

            List<int> wonIndex = new List<int>();
            int bingoIndex = 0;
            int a = 0;
            int finalDraw = 0;
            while (wonIndex.Count < rawData.Length - 1)
            {
                int drawnValue = Convert.ToInt32(possibleDraws[a]);
                a++;

                for (int board = 1; board < rawData.Length; board++)
                {
                    bool validBoard = true;
                    foreach (int i in wonIndex)
                    {
                        if (i == board) { validBoard = false; }
                    }
                    if (validBoard == true)
                    {
                        for (int i = 0; i < 25; i++)
                        {
                            if (boardValues[board, i] == drawnValue) { boardData[board, i] = true; }
                        }


                        int row0 = 0;
                        for (int i = 0; i < 5; i++)
                        {
                            if (boardData[board, i * 5] == true) { row0++; }
                        }
                        if (row0 == 5) { bingo = true; bingoIndex = board; }

                        int row1 = 0;
                        for (int i = 0; i < 5; i++)
                        {
                            if (boardData[board, 1 + (i * 5)] == true) { row1++; }
                        }
                        if (row1 == 5) { bingo = true; bingoIndex = board; }

                        int row2 = 0;
                        for (int i = 0; i < 5; i++)
                        {
                            if (boardData[board, 2 + i * 5] == true) { row2++; }
                        }
                        if (row2 == 5) { bingo = true; bingoIndex = board; }

                        int row3 = 0;
                        for (int i = 0; i < 5; i++)
                        {
                            if (boardData[board, 3 + i * 5] == true) { row3++; }
                        }
                        if (row3 == 5) { bingo = true; bingoIndex = board; }

                        int row4 = 0;
                        for (int i = 0; i < 5; i++)
                        {
                            if (boardData[board, 4 + i * 5] == true) { row4++; }
                        }
                        if (row4 == 5) { bingo = true; bingoIndex = board; }


                        int column0 = 0;
                        for (int i = 0; i < 5; i++)
                        {
                            if (boardData[board, i] == true) { column0++; }
                        }
                        if (column0 == 5) { bingo = true; bingoIndex = board; }

                        int column1 = 0;
                        for (int i = 0; i < 5; i++)
                        {
                            if (boardData[board, i + 5] == true) { column1++; }
                        }
                        if (column1 == 5) { bingo = true; bingoIndex = board; }

                        int column2 = 0;
                        for (int i = 0; i < 5; i++)
                        {
                            if (boardData[board, i + 10] == true) { column2++; }
                        }
                        if (column2 == 5) { bingo = true; bingoIndex = board; }

                        int column3 = 0;
                        for (int i = 0; i < 5; i++)
                        {
                            if (boardData[board, i + 15] == true) { column3++; }
                        }
                        if (column3 == 5) { bingo = true; bingoIndex = board; }

                        int column4 = 0;
                        for (int i = 0; i < 5; i++)
                        {
                            if (boardData[board, i + 20] == true) { column4++; }
                        }
                        if (column4 == 5) { bingo = true; bingoIndex = board; }

                        if (bingo == true)
                        {
                            wonIndex.Add(board);
                            bingo = false;
                        }
                    }

                    finalDraw = drawnValue;
                }
            }

            int unmarkedSum = 0;
            for (int i = 0; i < 25; i++)
            {
                if (boardData[bingoIndex, i] == false) { unmarkedSum += Convert.ToInt32(boardValues[bingoIndex, i]); }
            }

            Console.WriteLine(unmarkedSum * finalDraw);
        }
    }
}
