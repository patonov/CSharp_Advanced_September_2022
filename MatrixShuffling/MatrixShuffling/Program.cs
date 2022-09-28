using System;
using System.Linq;
using System.Collections.Generic;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var yakooo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = yakooo[col];
                }
            }

            while (true)
            { 
            var command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                
                if (command[0] == "END")
                {
                    break;
                }
                  

                if (IsCommandValid(command))
                {
                    int oldRow = int.Parse(command[1]);
                    int oldCol = int.Parse(command[2]);

                    int newRow = int.Parse(command[3]);
                    int newCol = int.Parse(command[4]);

                    if (AreCoordinatesValid(oldRow, oldCol, matrix) && AreCoordinatesValid(newRow, newCol, matrix))
                    {
                        string interimOldValue = matrix[oldRow, oldCol];
                        string interimNewValue = matrix[newRow, newCol];

                        matrix[oldRow, oldCol] = interimNewValue;
                        matrix[newRow, newCol] = interimOldValue;

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write(matrix[row, col] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                

            }

        }

        private static bool IsCommandValid(string[] command)
        {
            if (command[0] != "swap" || command.Length != 5)
            {
                return false;
            }
            return true;
        }

        private static bool AreCoordinatesValid(int row, int col, string[,] matrix)
        {
            if (row < 0 || row > matrix.GetLength(0) - 1 || col < 0 || col > matrix.GetLength(1) - 1)
            {
                return false;
            }
            return true;
        }
    }
}
