using System;
using System.Collections.Generic;
using System.Linq;

namespace Sneaking
{
    class Program
    {
        public static char moveLeft = 'd';
        public static char moveRight = 'b';
        public static char Nikoladze = 'N';
        public static char died = 'X';
        public static int samRow;
        public static int samCol;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] room = new char[rows][];

            GetRoom(room);

            Queue<char> moves = new Queue<char>(Console.ReadLine().ToCharArray());

            while (moves.Count != 0)
            {
                MoveEnemies(room);

                if (MoveSam(room, moves.Dequeue()))
                {
                    break;
                }
            }

            PrintRoom(room);
        }

        private static bool MoveSam(char[][] room, char direction)
        {
            if (direction == 'W')
            {
                return false;
            }

            if (room[samRow].Contains(moveLeft) || room[samRow].Contains(moveRight))
            {
                for (int col = 0; col < room[samRow].Length; col++)
                {
                    if (room[samRow][col] == moveLeft)
                    {
                        if (samCol < col)
                        {
                            Console.WriteLine($"Sam died at {samRow}, {samCol}");
                            room[samRow][samCol] = died;
                            return true;
                        }
                    }

                    if (room[samRow][col] == moveRight)
                    {
                        if (samCol > col)
                        {
                            Console.WriteLine($"Sam died at {samRow}, {samCol}");
                            room[samRow][samCol] = died;
                            return true;
                        }
                    }
                }
            }

            room[samRow][samCol] = '.';
            switch (direction)
            {
                case 'U':
                    samRow--;
                    break;
                case 'D':
                    samRow++;
                    break;
                case 'L':
                    samCol--;
                    break;
                case 'R':
                    samCol++;
                    break;
            }

            for (int col = 0; col < room[samRow].Length; col++)
            {
                if (room[samRow][col] == Nikoladze)
                {
                    Console.WriteLine($"Nikoladze killed!");
                    room[samRow][col] = died;
                    room[samRow][samCol] = 'S';
                    return true;
                }
            }

            room[samRow][samCol] = 'S';
            return false;
        }

        private static void MoveEnemies(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (Move(room, row, col))
                    {
                        break;
                    }
                }
            }
        }

        private static bool Move(char[][] room, int row, int col)
        {
            bool hasMove = false;

            if (col == room[row].Length - 1)
            {
                if (room[row][col] == moveRight)
                {
                    room[row][col] = moveLeft;
                    return true;
                }
            }

            if (col == 0)
            {
                if (room[row][0] == moveLeft)
                {
                    room[row][0] = moveRight;
                    return true;
                }
            }

            if (room[row][col] == moveRight)
            {
                room[row][col] = '.';
                room[row][col + 1] = moveRight;
                hasMove = true;
            }
            else if (room[row][col] == moveLeft)
            {
                room[row][col] = '.';
                room[row][col - 1] = moveLeft;
                hasMove = true;
            }

            return hasMove;
        }

        private static void PrintRoom(char[][] room)
        {
            foreach (var row in room)
            {
                Console.WriteLine(string.Join(null, row));
            }
        }

        private static void GetRoom(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                room[row] = Console.ReadLine().ToCharArray();
                if (room[row].Contains('S'))
                {
                    samRow = row;
                    for (int col = 0; col < room[row].Length; col++)
                    {
                        if (room[row][col] == 'S')
                        {
                            samCol = col;
                        }
                    }
                }
            }
        }
    }
}
