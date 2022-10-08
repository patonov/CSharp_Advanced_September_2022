using System;
using System.Linq;
using System.Collections.Generic;

namespace Armory
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int startRow = -1;
            int startCol = -1;

            int coins = 0;

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'A')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            string direction = Console.ReadLine();

            while (true)
            {
                if (direction == "up")
                {
                    if (IsValidCoordinates(startRow - 1, startCol, matrix))
                    {
                        if (matrix[startRow - 1, startCol] == '-')
                        {
                            matrix[startRow, startCol] = '-';
                            startRow--;
                            matrix[startRow, startCol] = 'A';
                        }
                        else if (matrix[startRow - 1, startCol] == 'M')
                        {
                            matrix[startRow, startCol] = '-';
                            startRow--;
                            matrix[startRow, startCol] = 'A';

                            int mirrorRow = -1;
                            int mirrorCol = -1;
                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < n; col++)
                                {
                                    if (matrix[row, col] == 'M')
                                    {
                                        mirrorRow = row;
                                        mirrorCol = col;
                                    }
                                }
                            }
                            matrix[startRow, startCol] = '-';
                            startRow = mirrorRow;
                            startCol = mirrorCol;
                            matrix[startRow, startCol] = 'A';
                        }
                        else if (char.IsDigit(matrix[startRow - 1, startCol]))
                        {
                            int temp = int.Parse((matrix[startRow - 1, startCol]).ToString());
                            coins += temp;
                            matrix[startRow, startCol] = '-';
                            startRow--;
                            matrix[startRow, startCol] = 'A';

                            if (coins >= 65)
                            {
                                Console.WriteLine("Very nice swords, I will come back for more!");
                                break;
                            }
                        }
                    }
                    else
                    {
                        matrix[startRow, startCol] = '-';
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }

                }
                else if (direction == "down")
                {
                    if (IsValidCoordinates(startRow + 1, startCol, matrix))
                    {
                        if (matrix[startRow + 1, startCol] == '-')
                        {
                            matrix[startRow, startCol] = '-';
                            startRow++;
                            matrix[startRow, startCol] = 'A';
                        }
                        else if (matrix[startRow + 1, startCol] == 'M')
                        {
                            matrix[startRow, startCol] = '-';
                            startRow++;
                            matrix[startRow, startCol] = 'A';

                            int mirrorRow = -1;
                            int mirrorCol = -1;
                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < n; col++)
                                {
                                    if (matrix[row, col] == 'M')
                                    {
                                        mirrorRow = row;
                                        mirrorCol = col;
                                    }
                                }
                            }
                            matrix[startRow, startCol] = '-';
                            startRow = mirrorRow;
                            startCol = mirrorCol;
                            matrix[startRow, startCol] = 'A';
                        }
                        else if (char.IsDigit(matrix[startRow + 1, startCol]))
                        {
                            int temp = int.Parse((matrix[startRow + 1, startCol]).ToString());
                            coins += temp;
                            matrix[startRow, startCol] = '-';
                            startRow++;
                            matrix[startRow, startCol] = 'A';

                            if (coins >= 65)
                            {
                                Console.WriteLine("Very nice swords, I will come back for more!");
                                break;
                            }
                        }
                    }
                    else
                    {
                        matrix[startRow, startCol] = '-';
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }

                }
                else if (direction == "left")
                {
                    if (IsValidCoordinates(startRow, startCol - 1, matrix))
                    {
                        if (matrix[startRow, startCol - 1] == '-')
                        {
                            matrix[startRow, startCol] = '-';
                            startCol--;
                            matrix[startRow, startCol] = 'A';
                        }
                        else if (matrix[startRow, startCol - 1] == 'M')
                        {
                            matrix[startRow, startCol] = '-';
                            startCol--;
                            matrix[startRow, startCol] = 'A';

                            int mirrorRow = -1;
                            int mirrorCol = -1;
                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < n; col++)
                                {
                                    if (matrix[row, col] == 'M')
                                    {
                                        mirrorRow = row;
                                        mirrorCol = col;
                                    }
                                }
                            }
                            matrix[startRow, startCol] = '-';
                            startRow = mirrorRow;
                            startCol = mirrorCol;
                            matrix[startRow, startCol] = 'A';
                        }
                        else if (char.IsDigit(matrix[startRow, startCol - 1]))
                        {
                            int temp = int.Parse((matrix[startRow, startCol - 1]).ToString());
                            coins += temp;
                            matrix[startRow, startCol] = '-';
                            startCol--;
                            matrix[startRow, startCol] = 'A';

                            if (coins >= 65)
                            {
                                Console.WriteLine("Very nice swords, I will come back for more!");
                                break;
                            }
                        }
                    }
                    else
                    {
                        matrix[startRow, startCol] = '-';
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }

                }
                else if (direction == "right")
                {
                    if (IsValidCoordinates(startRow, startCol + 1, matrix))
                    {
                        if (matrix[startRow, startCol + 1] == '-')
                        {
                            matrix[startRow, startCol] = '-';
                            startCol++;
                            matrix[startRow, startCol] = 'A';
                        }
                        else if (matrix[startRow, startCol + 1] == 'M')
                        {
                            matrix[startRow, startCol] = '-';
                            startCol++;
                            matrix[startRow, startCol] = 'A';

                            int mirrorRow = -1;
                            int mirrorCol = -1;
                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < n; col++)
                                {
                                    if (matrix[row, col] == 'M')
                                    {
                                        mirrorRow = row;
                                        mirrorCol = col;
                                    }
                                }
                            }
                            matrix[startRow, startCol] = '-';
                            startRow = mirrorRow;
                            startCol = mirrorCol;
                            matrix[startRow, startCol] = 'A';
                        }
                        else if (char.IsDigit(matrix[startRow, startCol + 1]))
                        {
                            int temp = int.Parse((matrix[startRow, startCol + 1]).ToString());
                            coins += temp;
                            matrix[startRow, startCol] = '-';
                            startCol++;
                            matrix[startRow, startCol] = 'A';

                            if (coins >= 65)
                            {
                                Console.WriteLine("Very nice swords, I will come back for more!");
                                break;
                            }
                        }
                    }
                    else
                    {
                        matrix[startRow, startCol] = '-';
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }
                }
                direction = Console.ReadLine(); // here ends the cycle
            }

            Console.WriteLine($"The king paid {coins} gold coins.");

            Printer(matrix);
        }

        public static void Printer(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        
        public static bool IsValidCoordinates(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

    }
}
