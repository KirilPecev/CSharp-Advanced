using System;

namespace The_Heigan_Dance
{
    class Program
    {
        static int playerRow = 7;
        static int playerCol = 7;

        static int plagueCloud = 3500;
        static int eruption = 6000;
        static int playerLifePoints = 18500;
        static double heiganLifePoints = 3000000;
        static string lastSpell = string.Empty;
        static bool isPlagueCloud = false;

        static void Main(string[] args)
        {
            double dmgDoneToHeiganEachTurn = double.Parse(Console.ReadLine());

            while (true)
            {
                if (playerLifePoints > 0)
                {
                    heiganLifePoints -= dmgDoneToHeiganEachTurn;
                }

                if (isPlagueCloud)
                {
                    playerLifePoints -= plagueCloud;
                    isPlagueCloud = false;
                }

                if (playerLifePoints <= 0 || heiganLifePoints <= 0)
                {
                    break;
                }

                string[] spellInput = Console.ReadLine().Split();
                string spell = spellInput[0];
                int targetRow = int.Parse(spellInput[1]);
                int targetCol = int.Parse(spellInput[2]);

                if (!IsPlayerInTargetCloud(playerRow, playerCol, targetRow, targetCol))
                {
                    continue;
                }

                bool canMoveUp = !IsPlayerInTargetCloud(playerRow - 1, playerCol, targetRow, targetCol) && IsInside(playerRow - 1);
                bool canMoveRight = !IsPlayerInTargetCloud(playerRow, playerCol + 1, targetRow, targetCol) && IsInside(playerCol + 1);
                bool canMoveDown = !IsPlayerInTargetCloud(playerRow + 1, playerCol, targetRow, targetCol) && IsInside(playerRow + 1);
                bool canMoveLeft = !IsPlayerInTargetCloud(playerRow, playerCol - 1, targetRow, targetCol) && IsInside(playerCol - 1);

                if (canMoveUp)
                {
                    playerRow--;
                    continue;
                }

                if (canMoveRight)
                {
                    playerCol++;
                    continue;
                }

                if (canMoveDown)
                {
                    playerRow++;
                    continue;
                }

                if (canMoveLeft)
                {
                    playerCol--;
                    continue;
                }

                if (spell == "Cloud")
                {
                    playerLifePoints -= plagueCloud;
                    isPlagueCloud = true;
                    lastSpell = "Plague Cloud";
                }
                else if (spell == "Eruption")
                {
                    playerLifePoints -= eruption;
                    lastSpell = "Eruption";
                }
            }

            if (heiganLifePoints <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {heiganLifePoints:f2}");
            }

            if (playerLifePoints <= 0)
            {
                Console.WriteLine($"Player: Killed by {lastSpell}");
            }
            else
            {
                Console.WriteLine($"Player: {playerLifePoints}");
            }

            Console.WriteLine($"Final position: {playerRow}, {playerCol}");
        }

        private static bool IsInside(int rcIndex)
        {
            return rcIndex >= 0 && rcIndex < 15;
        }

        private static bool IsPlayerInTargetCloud(int targetPlayerRow, int targerPlayerCol, int row, int col)
        {
            return targetPlayerRow >= row - 1 && targetPlayerRow <= row + 1 &&
                targerPlayerCol >= col - 1 && targerPlayerCol <= col + 1;
        }
    }
}
