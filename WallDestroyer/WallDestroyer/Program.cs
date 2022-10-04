using System;
using System.Collections.Generic;
using System.Linq;

namespace WallDestroyer
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int startRow = -1;
            int startCol = -1;

            int holeCounter = 0;
            int rodCounter = 0;

            bool wasElectriced = false;

            for (int row = 0; row < n; row++)
            {
               var input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'V')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            var command = Console.ReadLine();

            while (command != "End")
            {
                if (command == "up")
                {
                    if (IsValidCoordinates(startRow - 1, startCol, matrix))
                    {
                        if (matrix[startRow - 1, startCol] == 'R')
                        {
                            rodCounter++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if ((matrix[startRow - 1, startCol] == 'C'))
                        {
                            wasElectriced = true;
                            holeCounter++;
                            matrix[startRow, startCol] = '*';
                            matrix[startRow - 1, startCol] = 'E';
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeCounter} hole(s).");
                            break;
                        }
                        else if ((matrix[startRow - 1, startCol] == 'E'))
                        {
                            wasElectriced = true;
                            holeCounter++;
                            matrix[startRow, startCol] = '*';
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeCounter} hole(s).");
                            break;
                        }
                        else if (matrix[startRow - 1, startCol] == '*')
                        {
                            matrix[startRow, startCol] = '*';
                            startRow--;
                            matrix[startRow, startCol] = 'V';
                            Console.WriteLine($"The wall is already destroyed at position [{startRow}, {startCol}]!");
                        }
                        else
                        {
                            holeCounter++;
                            matrix[startRow, startCol] = '*';
                            startRow--;
                            matrix[startRow, startCol] = 'V';
                        }
                    }

                }
                else if (command == "down")
                {
                    if (IsValidCoordinates(startRow + 1, startCol, matrix))
                    {
                        if (matrix[startRow + 1, startCol] == 'R')
                        {
                            rodCounter++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if ((matrix[startRow + 1, startCol] == 'C'))
                        {
                            wasElectriced = true;
                            matrix[startRow, startCol] = '*';
                            holeCounter++;
                            matrix[startRow + 1, startCol] = 'E';
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeCounter} hole(s).");
                            break;
                        }
                        else if ((matrix[startRow + 1, startCol] == 'E'))
                        {
                            wasElectriced = true;
                            matrix[startRow, startCol] = '*';
                            holeCounter++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeCounter} hole(s).");
                            break;
                        }
                        else if (matrix[startRow + 1, startCol] == '*')
                        {
                            matrix[startRow, startCol] = '*';
                            startRow++;
                            matrix[startRow, startCol] = 'V';
                            Console.WriteLine($"The wall is already destroyed at position [{startRow}, {startCol}]!");
                        }
                        else
                        {
                            holeCounter++;
                            matrix[startRow, startCol] = '*';
                            startRow++;
                            matrix[startRow, startCol] = 'V';
                        }
                    }

                }
                else if (command == "left")
                {
                    if (IsValidCoordinates(startRow, startCol - 1, matrix))
                    {
                        if (matrix[startRow, startCol - 1] == 'R')
                        {
                            rodCounter++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if ((matrix[startRow, startCol - 1] == 'C'))
                        {
                            wasElectriced = true;
                            matrix[startRow, startCol] = '*';
                            holeCounter++;
                            matrix[startRow, startCol - 1] = 'E';
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeCounter} hole(s).");
                            break;
                        }
                        else if ((matrix[startRow, startCol - 1] == 'E'))
                        {
                            wasElectriced = true;
                            matrix[startRow, startCol] = '*';
                            holeCounter++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeCounter} hole(s).");
                            break;
                        }
                        else if (matrix[startRow, startCol - 1] == '*')
                        {
                            matrix[startRow, startCol] = '*';
                            startCol--;
                            matrix[startRow, startCol] = 'V';
                            Console.WriteLine($"The wall is already destroyed at position [{startRow}, {startCol}]!");
                        }
                        else
                        {
                            holeCounter++;
                            matrix[startRow, startCol] = '*';
                            startCol--;
                            matrix[startRow, startCol] = 'V';
                        }
                    }

                }
                else if (command == "right")
                {
                    if (IsValidCoordinates(startRow, startCol + 1, matrix))
                    {
                        if (matrix[startRow, startCol + 1] == 'R')
                        {
                            rodCounter++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if ((matrix[startRow, startCol + 1] == 'C'))
                        {
                            wasElectriced = true;
                            matrix[startRow, startCol] = '*';
                            holeCounter++;
                            matrix[startRow, startCol + 1] = 'E';
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeCounter} hole(s).");
                            break;
                        }
                        else if ((matrix[startRow, startCol + 1] == 'E'))
                        {
                            wasElectriced = true;
                            matrix[startRow, startCol] = '*';
                            holeCounter++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeCounter} hole(s).");
                            break;
                        }
                        else if (matrix[startRow, startCol + 1] == '*')
                        {
                            matrix[startRow, startCol] = '*';
                            startCol++;
                            matrix[startRow, startCol] = 'V';
                            Console.WriteLine($"The wall is already destroyed at position [{startRow}, {startCol}]!");
                        }
                        else
                        {
                            holeCounter++;
                            matrix[startRow, startCol] = '*';
                            startCol++;
                            matrix[startRow, startCol] = 'V';
                        }
                    }
                }



                command = Console.ReadLine();
            }

            if (wasElectriced == false)
            {
                Console.WriteLine($"Vanko managed to make {holeCounter} hole(s) and he hit only {rodCounter} rod(s).");
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }

        }

        private static bool IsValidCoordinates(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
