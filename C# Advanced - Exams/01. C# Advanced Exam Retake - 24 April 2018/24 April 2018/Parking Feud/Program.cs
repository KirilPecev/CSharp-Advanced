using System;
using System.Linq;

namespace Parking_Feud
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rowEnteredSam = int.Parse(Console.ReadLine());
            int[,] parking = CreateParking(dimensions[0], dimensions[1]);

            PrintMatrix(parking);

            while (true)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                if (input[0] != input[1] && input[0] != input[2])
                {
                    CalculateSteps(input[0], parking, rowEnteredSam);
                    return;
                }
                else
                {

                }
            }
        }

        private static void CalculateSteps(string slot, int[,] parking, int rowEnteredSam)
        {
            string slotLetter = slot[0].ToString();
            int slotRow = int.Parse(slot[1].ToString());
            if (slotRow % 2 == 0)
            {
                slotRow++;
            }

            int slotCol = 0;
            if (slotLetter == "A")
            {
                slotCol = 1;
            }
            else if (slotLetter == "B")
            {
                slotCol = 2;
            }
            else if (slotLetter == "C")
            {
                slotCol = 3;
            }
            else if (slotLetter == "D")
            {
                slotCol = 4;
            }

            int stepsSam = 0;
            bool endOfTheRow = false;
            for (int row = rowEnteredSam; row < parking.GetLength(0); row++)
            {
                if (!endOfTheRow)
                {
                    for (int col = 1; col < parking.GetLength(1); col++)
                    {
                        stepsSam++;
                        if (row == slotRow)
                        {
                            if (col == slotCol)
                            {
                                Console.WriteLine($"Parked successfully at {slot}.");
                                Console.WriteLine($"Total Distance Passed: {stepsSam}");
                                return;
                            }
                        }

                        if (col == parking.GetLength(1) - 1)
                        {
                            endOfTheRow = true;
                            break;

                        }
                    }
                }
                else
                {
                    for (int col = parking.GetLength(1) - 1; col >= 1; col--)
                    {
                        stepsSam++;
                        if (row == slotRow)
                        {
                            if (col == slotCol)
                            {
                                Console.WriteLine($"Parked successfully at {slot}.");
                                Console.WriteLine($"Total Distance Passed: {stepsSam}");
                                return;
                            }
                        }
                        else
                        {
                            break;
                        }

                        if (col == 1)
                        {
                            endOfTheRow = false;
                            break;

                        }
                    }
                }
            }
        }

        private static void PrintMatrix(int[,] parking)
        {
            for (int row = 0; row < parking.GetLength(0); row++)
            {
                for (int col = 0; col < parking.GetLength(1); col++)
                {
                    Console.Write(parking[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static int[,] CreateParking(int rows, int cols)
        {
            int actualRows = rows * 2 - 1;
            int actualCols = cols + 2;

            int[,] parking = new int[actualRows, actualCols];
            for (int row = 0; row < parking.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    parking[row, 0] = parking[row, parking.GetLength(1) - 1] = 1;
                    for (int col = 1; col < parking.GetLength(1) - 1; col++)
                    {
                        parking[row, col] = 0;
                    }

                }
                else
                {
                    for (int col = 0; col < parking.GetLength(1); col++)
                    {
                        parking[row, col] = 1;
                    }
                }

            }

            return parking;
        }
    }
}
