using System;
using System.Linq;
using System.Collections.Generic;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int startRow = -1;
            int startCol = -1;

            int flowers = 0;

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'B')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            string direction = Console.ReadLine();

            while (direction != "End")
            {
                if (direction == "up")
                {
                    if (IsValidCoordinates(startRow - 1, startCol, matrix))
                    {
                        if (matrix[startRow - 1, startCol] == 'f')
                        {
                            matrix[startRow, startCol] = '.';
                            startRow--;
                            matrix[startRow, startCol] = 'B';
                            flowers++;
                        }
                        else if (matrix[startRow - 1, startCol] == 'O')
                        {
                            matrix[startRow, startCol] = '.';
                            startRow--;
                            matrix[startRow, startCol] = '.';
                            startRow--;
                            if (matrix[startRow, startCol] == 'f')
                            {
                                flowers++;
                            }
                            if (!IsValidCoordinates(startRow, startCol, matrix))
                            {
                                Console.WriteLine("The bee got lost!");
                                matrix[startRow, startCol] = '.';
                                break;
                            }
                            matrix[startRow, startCol] = 'B';
                        }
                        else if (matrix[startRow - 1, startCol] == '.')
                        {
                            matrix[startRow, startCol] = '.';
                            startRow--;
                            matrix[startRow, startCol] = 'B';
                        }
                    }
                    else
                    {
                        Console.WriteLine("The bee got lost!");
                        matrix[startRow, startCol] = '.';
                        break;
                    }

                }
                else if (direction == "down")
                {
                    if (IsValidCoordinates(startRow + 1, startCol, matrix))
                    {
                        if (matrix[startRow + 1, startCol] == 'f')
                        {
                            matrix[startRow, startCol] = '.';
                            startRow++;
                            matrix[startRow, startCol] = 'B';
                            flowers++;
                        }
                        else if (matrix[startRow + 1, startCol] == 'O')
                        {
                            matrix[startRow, startCol] = '.';
                            startRow++;
                            matrix[startRow, startCol] = '.';
                            startRow++;
                            if (matrix[startRow, startCol] == 'f')
                            {
                                flowers++;
                            }
                            if (!IsValidCoordinates(startRow, startCol, matrix))
                            {
                                Console.WriteLine("The bee got lost!");
                                matrix[startRow, startCol] = '.';
                                break;
                            }
                            matrix[startRow, startCol] = 'B';
                        }
                        else if (matrix[startRow + 1, startCol] == '.')
                        {
                            matrix[startRow, startCol] = '.';
                            startRow++;
                            matrix[startRow, startCol] = 'B';
                        }

                    }
                    else
                    {
                        Console.WriteLine("The bee got lost!");
                        matrix[startRow, startCol] = '.';
                        break;
                    }

                }
                else if (direction == "left")
                {
                    if (IsValidCoordinates(startRow, startCol - 1, matrix))
                    {
                        if (matrix[startRow, startCol - 1] == 'f')
                        {
                            matrix[startRow, startCol] = '.';
                            startCol--;
                            matrix[startRow, startCol] = 'B';
                            flowers++;
                        }
                        else if (matrix[startRow, startCol - 1] == 'O')
                        {
                            matrix[startRow, startCol] = '.';
                            startCol--;
                            matrix[startRow, startCol] = '.';
                            startCol--;
                            if (matrix[startRow, startCol] == 'f')
                            {
                                flowers++;
                            }
                            if (!IsValidCoordinates(startRow, startCol, matrix))
                            {
                                Console.WriteLine("The bee got lost!");
                                matrix[startRow, startCol] = '.';
                                break;
                            }
                            matrix[startRow, startCol] = 'B';
                        }
                        else if (matrix[startRow, startCol - 1] == '.')
                        {
                            matrix[startRow, startCol] = '.';
                            startCol--;
                            matrix[startRow, startCol] = 'B';
                        }
                    }
                    else
                    {
                        Console.WriteLine("The bee got lost!");
                        matrix[startRow, startCol] = '.';
                        break;
                    }

                }
                else if (direction == "right")
                {
                    if (IsValidCoordinates(startRow, startCol + 1, matrix))
                    {
                        if (matrix[startRow, startCol + 1] == 'f')
                        {
                            matrix[startRow, startCol] = '.';
                            startCol++;
                            matrix[startRow, startCol] = 'B';
                            flowers++;
                        }
                        else if (matrix[startRow, startCol + 1] == 'O')
                        {
                            matrix[startRow, startCol] = '.';
                            startCol++;
                            matrix[startRow, startCol] = '.';
                            startCol++;
                            if (matrix[startRow, startCol] == 'f')
                            {
                                flowers++;
                            }
                            if (!IsValidCoordinates(startRow, startCol, matrix))
                            {
                                Console.WriteLine("The bee got lost!");
                                matrix[startRow, startCol] = '.';
                                break;
                            }
                            matrix[startRow, startCol] = 'B';
                        }
                        else if (matrix[startRow, startCol + 1] == '.')
                        {
                            matrix[startRow, startCol] = '.';
                            startCol++;
                            matrix[startRow, startCol] = 'B';
                        }
                    }
                    else
                    {
                        Console.WriteLine("The bee got lost!");
                        matrix[startRow, startCol] = '.';
                        break;
                    }
                }
                direction = Console.ReadLine(); // here ends the cycle
            }

            if (flowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowers} flowers!");
            }
            else
            {
                int term = 5 - flowers;
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {term} flowers more");
            }
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
