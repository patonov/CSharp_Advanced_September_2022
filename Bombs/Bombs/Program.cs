using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int aliveCellsCounter = 0;

            var array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                int[] arrayExit = array[i].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int bombRow = arrayExit[0];
                int bombCol = arrayExit[1];
                int bombValue = matrix[bombRow, bombCol];

                for (int j = bombRow - 1; j <= bombRow + 1; j++)
                {
                    for (int k = bombCol - 1; k <= bombCol + 1; k++)
                    {
                        if (AreCoordinatesValid(j, k, matrix) && matrix[j,k] > 0)
                        {
                            matrix[j, k] -= bombValue;
                        }                    
                    }                
                }
            }

            int aliveCellSum = 0;

            for (int row = 0; row < n; row++)
            {                
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCellsCounter++;
                        aliveCellSum += matrix[row, col];
                    }
                }
            }

                        
                Console.WriteLine($"Alive cells: {aliveCellsCounter}");
                Console.WriteLine($"Sum: {aliveCellSum}");
            
            
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }

        }


        private static bool AreCoordinatesValid(int row, int col, int[,] matrix)
        {
            if (row < 0 || row > matrix.GetLength(0) - 1 || col < 0 || col > matrix.GetLength(1) - 1)
            {
                return false;
            }
            return true;
        }
    }
}
