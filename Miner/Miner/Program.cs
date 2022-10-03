using System;
using System.Collections.Generic;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var directs = Console.ReadLine().Split().ToArray();

            char[,] matrix = new char[n, n];

            int startRow = -1;
            int startCol = -1;

            int coalCounter = 0;
            int coalsToCollect = 0;

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 's')
                    {
                        startRow = row;
                        startCol = col;
                    }
                    if (matrix[row, col] == 'c')
                    {
                        coalsToCollect++;
                    }
                }
            }

            for (int i = 0; i < directs.Length; i++)
            {
                if (directs[i] == "up")
                {
                    if (IsValidCoordinates(startRow - 1, startCol, matrix))
                    {
                        if (matrix[startRow - 1, startCol] == 'e')
                        {
                            startRow--;
                            Console.WriteLine($"Game over! ({startRow}, {startCol})");
                            return;
                        }
                        else if ((matrix[startRow - 1, startCol] == 'c'))
                        {
                            coalCounter++;
                            matrix[startRow - 1, startCol] = '*';
                            coalsToCollect--;
                            startRow--;
                            if (coalsToCollect == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                                return;
                            }
                        }
                        else
                        {
                            startRow--;
                        }                    
                    }
                
                }
                else if (directs[i] == "down")
                {
                    if (IsValidCoordinates(startRow + 1, startCol, matrix))
                    {
                        if (matrix[startRow + 1, startCol] == 'e')
                        {
                            startRow++;
                            Console.WriteLine($"Game over! ({startRow}, {startCol})");
                            return;
                        }
                        else if ((matrix[startRow + 1, startCol] == 'c'))
                        {
                            coalCounter++;
                            matrix[startRow + 1, startCol] = '*';
                            coalsToCollect--;
                            startRow++;
                            if (coalsToCollect == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                                return;
                            }
                        }
                        else
                        {
                            startRow++;
                        }
                    }
                }
                else if (directs[i] == "left")
                {
                    if (IsValidCoordinates(startRow, startCol - 1, matrix))
                    {
                        if (matrix[startRow, startCol - 1] == 'e')
                        {
                            startCol--;
                            Console.WriteLine($"Game over! ({startRow}, {startCol})");
                            return;
                        }
                        else if ((matrix[startRow, startCol - 1] == 'c'))
                        {
                            coalCounter++;
                            matrix[startRow, startCol - 1] = '*';
                            coalsToCollect--;
                            startCol--;
                            if (coalsToCollect == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                                return;
                            }
                        }
                        else
                        {
                            startCol--;
                        }
                    }

                }
                else if (directs[i] == "right")
                {
                    if (IsValidCoordinates(startRow, startCol + 1, matrix))
                    {
                        if (matrix[startRow, startCol + 1] == 'e')
                        {
                            startCol++;
                            Console.WriteLine($"Game over! ({startRow}, {startCol})");
                            return;
                        }
                        else if ((matrix[startRow, startCol + 1] == 'c'))
                        {
                            coalCounter++;
                            matrix[startRow, startCol + 1] = '*';
                            coalsToCollect--;
                            startCol++;
                            if (coalsToCollect == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                                return;
                            }
                        }
                        else
                        {
                            startCol++;
                        }
                    }
                }
            }

            Console.WriteLine($"{coalsToCollect} coals left. ({startRow}, {startCol})");

        }

        private static bool IsValidCoordinates(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
