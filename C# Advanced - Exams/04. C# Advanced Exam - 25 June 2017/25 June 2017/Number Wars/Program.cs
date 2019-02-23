using System;
using System.Collections.Generic;
using System.Linq;

namespace Number_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> firstPlayer = new Queue<string>(Console.ReadLine().Split());
            Queue<string> secondPlayer = new Queue<string>(Console.ReadLine().Split());

            int count = 0;
            bool gameOver = false;
            while (!gameOver && count < 1000000 && firstPlayer.Count != 0 && secondPlayer.Count != 0)
            {
                count++;
                string firstPlayerCard = firstPlayer.Dequeue();
                string secondPlayerCard = secondPlayer.Dequeue();

                int firstPlayerNum = GetNumberValue(firstPlayerCard);
                int secondPlayerNum = GetNumberValue(secondPlayerCard);

                if (firstPlayerNum > secondPlayerNum)
                {
                    firstPlayer.Enqueue(firstPlayerCard);
                    firstPlayer.Enqueue(secondPlayerCard);
                }
                else if (secondPlayerNum > firstPlayerNum)
                {
                    secondPlayer.Enqueue(secondPlayerCard);
                    secondPlayer.Enqueue(firstPlayerCard);
                }
                else
                {
                    List<string> cardsOnBoard = new List<string>() { firstPlayerCard, secondPlayerCard };

                    while (true)
                    {
                        if (firstPlayer.Count < 3 || secondPlayer.Count < 3)
                        {
                            gameOver = true;
                            break;
                        }

                        int firstPlayerLetters = 0;
                        int secondPlayerLetters = 0;

                        for (int i = 0; i < 3; i++)
                        {
                            firstPlayerLetters += GetCharValue(firstPlayer.Peek());
                            secondPlayerLetters += GetCharValue(secondPlayer.Peek());

                            cardsOnBoard.Add(firstPlayer.Dequeue());
                            cardsOnBoard.Add(secondPlayer.Dequeue());
                        }

                        if (firstPlayerLetters > secondPlayerLetters)
                        {
                            foreach (var card in cardsOnBoard.OrderByDescending(x => GetNumberValue(x)).ThenByDescending(x => GetCharValue(x)))
                            {
                                firstPlayer.Enqueue(card);
                            }

                            break;
                        }
                        else if (firstPlayerLetters < secondPlayerLetters)
                        {
                            foreach (var card in cardsOnBoard.OrderByDescending(x => GetNumberValue(x)).ThenByDescending(x => GetCharValue(x)))
                            {
                                secondPlayer.Enqueue(card);
                            }

                            break;
                        }
                    }
                }
            }

            if (firstPlayer.Count > secondPlayer.Count)
            {
                Console.WriteLine($"First player wins after {count} turns");
            }
            else if (secondPlayer.Count > firstPlayer.Count)
            {
                Console.WriteLine($"Second player wins after {count} turns");
            }
            else
            {
                Console.WriteLine($"Draw after {count} turns");
            }

        }

        private static int GetCharValue(string v)
        {
            return v.Last();
        }

        private static int GetNumberValue(string playerCard)
        {
            return int.Parse(playerCard.Substring(0, playerCard.Length - 1));
        }
    }
}
