using System;

namespace Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsAndColumns = int.Parse(Console.ReadLine());
            char[,] matrix = new char[rowsAndColumns, rowsAndColumns];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                string word = Console.ReadLine();
                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    matrix[rows, columns] = word[columns];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool hasSymbol = false;
            for (int rows = 0; rows < rowsAndColumns; rows++)
            {
                for (int columns = 0; columns < rowsAndColumns; columns++)
                {
                    if (matrix[rows,columns] == symbol)
                    {
                        Console.WriteLine($"({rows}, {columns})");
                        hasSymbol = true;
                        return;
                    }
                }
            }

            if (!hasSymbol)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
