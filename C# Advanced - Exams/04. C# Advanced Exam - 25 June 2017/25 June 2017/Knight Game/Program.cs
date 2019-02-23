using System;

namespace Knight_Game
{
    class Program
    {
        public static int counter = 0;
        public static int currentKnightsInDanger = 0;
        public static int maxKnightsInDanger = -1;
        public static int mostDangerousKnightRow = 0;
        public static int mostDangerousKnightCol = 0;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] board = new char[n][];
            GetBoard(board);

            while (true)
            {
                for (int row = 0; row < board.Length; row++)
                {
                    for (int col = 0; col < board[row].Length; col++)
                    {
                        if (board[row][col] == 'K')
                        {
                            if (isInside(board, row + 2, col + 1))
                            {
                                if (board[row + 2][col + 1] == 'K')
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            if (isInside(board, row + 2, col - 1))
                            {
                                if (board[row + 2][col - 1] == 'K')
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            if (isInside(board, row - 2, col - 1))
                            {
                                if (board[row - 2][col - 1] == 'K')
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            if (isInside(board, row - 2, col + 1))
                            {
                                if (board[row - 2][col + 1] == 'K')
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            if (isInside(board, row - 1, col - 2))
                            {
                                if (board[row - 1][col - 2] == 'K')
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            if (isInside(board, row + 1, col - 2))
                            {
                                if (board[row + 1][col - 2] == 'K')
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            if (isInside(board, row - 1, col + 2))
                            {
                                if (board[row - 1][col + 2] == 'K')
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            if (isInside(board, row + 1, col + 2))
                            {
                                if (board[row + 1][col + 2] == 'K')
                                {
                                    currentKnightsInDanger++;
                                }
                            }
                        }

                        if (currentKnightsInDanger > maxKnightsInDanger)
                        {
                            maxKnightsInDanger = currentKnightsInDanger;
                            mostDangerousKnightRow = row;
                            mostDangerousKnightCol = col;
                        }

                        currentKnightsInDanger = 0;
                    }
                }

                if (maxKnightsInDanger != 0)
                {
                    board[mostDangerousKnightRow][mostDangerousKnightCol] = '0';
                    counter++;
                    maxKnightsInDanger = 0;
                }
                else
                {
                    Console.WriteLine(counter);
                    return;
                }
            }
        }

        private static bool isInside(char[][] board, int row, int col)
        {
            return row >= 0 && row < board.Length && col >= 0 && col < board[row].Length;
        }

        private static void GetBoard(char[][] board)
        {
            for (int row = 0; row < board.Length; row++)
            {
                board[row] = Console.ReadLine().ToCharArray();
            }
        }
    }
}
