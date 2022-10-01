using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int counter = 0;

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }


            while (true)
            {
                int maxAttacked = 0;
                int maxRow = -1;
                int maxCol = -1;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int temp = AttackingAnother(row, col, matrix);
                            if (temp > maxAttacked)
                            {
                                maxAttacked = temp;
                                maxRow = row;
                                maxCol = col;
                            }
                        }
                    }
                }
                if (maxAttacked > 0)
                {
                    matrix[maxRow, maxCol] = '0';
                    counter++;
                }
                else
                {
                    break;
                }

            }
            Console.WriteLine(counter);
        }

        private static int AttackingAnother(int row, int col, char[,] matrix)
        {
            int maxAttacked = 0;
            if (IsValidCoordinates(row + 1, col + 2, matrix) && matrix[row + 1, col + 2] == 'K')
            {

                maxAttacked++;
            }
            if (IsValidCoordinates(row + 1, col - 2, matrix) && matrix[row + 1, col - 2] == 'K')
            {

                maxAttacked++;
            }
            if (IsValidCoordinates(row - 1, col + 2, matrix) && matrix[row - 1, col + 2] == 'K')
            {

                maxAttacked++;
            }
            if (IsValidCoordinates(row - 1, col - 2, matrix) && matrix[row - 1, col - 2] == 'K')
            {

                maxAttacked++;
            }
            if (IsValidCoordinates(row + 2, col + 1, matrix) && matrix[row + 2, col + 1] == 'K')
            {

                maxAttacked++;
            }
            if (IsValidCoordinates(row + 2, col - 1, matrix) && matrix[row + 2, col - 1] == 'K')
            {

                maxAttacked++;
            }
            if (IsValidCoordinates(row - 2, col + 1, matrix) && matrix[row - 2, col + 1] == 'K')
            {

                maxAttacked++;
            }
            if (IsValidCoordinates(row - 2, col - 1, matrix) && matrix[row - 2, col - 1] == 'K')
            {

                maxAttacked++;
            }
            return maxAttacked;
        }

        private static bool IsValidCoordinates(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
