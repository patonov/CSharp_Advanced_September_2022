using System;
using System.Linq;
using System.Collections.Generic;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int startRow = -1;
            int startCol = -1;

            int foodQuantity = 0;

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'S')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

          

            while (true)
            {
                string direction = Console.ReadLine();

                if (direction == "up")
                {
                    if (IsValidCoordinates(startRow - 1, startCol, matrix))
                    {
                        if (matrix[startRow - 1, startCol] == '-')
                        {
                            matrix[startRow, startCol] = '.';
                            startRow--;
                            matrix[startRow, startCol] = 'S';
                        }
                        else if (matrix[startRow - 1, startCol] == 'B')
                        {
                            matrix[startRow, startCol] = '.';
                            startRow--;
                            matrix[startRow, startCol] = 'S';

                            int mirrorRow = -1;
                            int mirrorCol = -1;
                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < n; col++)
                                {
                                    if (matrix[row, col] == 'B')
                                    {
                                        mirrorRow = row;
                                        mirrorCol = col;
                                    }
                                }
                            }
                            matrix[startRow, startCol] = '.';
                            startRow = mirrorRow;
                            startCol = mirrorCol;
                            matrix[startRow, startCol] = 'S';
                        }
                        else if (matrix[startRow - 1, startCol] == '*')
                        {                            
                            foodQuantity++;
                            matrix[startRow, startCol] = '.';
                            startRow--;
                            matrix[startRow, startCol] = 'S';

                            if (foodQuantity >= 10)
                            {
                                Console.WriteLine("You won! You fed the snake.");
                                break;
                            }
                        }
                    }
                    else
                    {
                        matrix[startRow, startCol] = '.';
                        Console.WriteLine("Game over!");
                        break;
                    }

                }
                else if (direction == "down")
                {
                    if (IsValidCoordinates(startRow + 1, startCol, matrix))
                    {
                        if (matrix[startRow + 1, startCol] == '-')
                        {
                            matrix[startRow, startCol] = '.';
                            startRow++;
                            matrix[startRow, startCol] = 'S';
                        }
                        else if (matrix[startRow + 1, startCol] == 'B')
                        {
                            matrix[startRow, startCol] = '.';
                            startRow++;
                            matrix[startRow, startCol] = 'S';

                            int mirrorRow = -1;
                            int mirrorCol = -1;
                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < n; col++)
                                {
                                    if (matrix[row, col] == 'B')
                                    {
                                        mirrorRow = row;
                                        mirrorCol = col;
                                    }
                                }
                            }
                            matrix[startRow, startCol] = '.';
                            startRow = mirrorRow;
                            startCol = mirrorCol;
                            matrix[startRow, startCol] = 'S';
                        }
                        else if (matrix[startRow + 1, startCol] == '*')
                        {
                            foodQuantity++;
                            matrix[startRow, startCol] = '.';
                            startRow++;
                            matrix[startRow, startCol] = 'S';

                            if (foodQuantity >= 10)
                            {
                                Console.WriteLine("You won! You fed the snake.");
                                break;
                            }
                        }
                    }
                    else
                    {
                        matrix[startRow, startCol] = '.';
                        Console.WriteLine("Game over!");
                        break;
                    }

                }
                else if (direction == "left")
                {
                    if (IsValidCoordinates(startRow, startCol - 1, matrix))
                    {
                        if (matrix[startRow, startCol - 1] == '-')
                        {
                            matrix[startRow, startCol] = '.';
                            startCol--;
                            matrix[startRow, startCol] = 'S';
                        }
                        else if (matrix[startRow, startCol - 1] == 'B')
                        {
                            matrix[startRow, startCol] = '.';
                            startCol--;
                            matrix[startRow, startCol] = 'S';

                            int mirrorRow = -1;
                            int mirrorCol = -1;
                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < n; col++)
                                {
                                    if (matrix[row, col] == 'B')
                                    {
                                        mirrorRow = row;
                                        mirrorCol = col;
                                    }
                                }
                            }
                            matrix[startRow, startCol] = '.';
                            startRow = mirrorRow;
                            startCol = mirrorCol;
                            matrix[startRow, startCol] = 'S';
                        }
                        else if (matrix[startRow, startCol - 1] == '*')
                        {
                            foodQuantity++;
                            matrix[startRow, startCol] = '.';
                            startCol--;
                            matrix[startRow, startCol] = 'S';

                            if (foodQuantity >= 10)
                            {
                                Console.WriteLine("You won! You fed the snake.");
                                break;
                            }
                        }
                    }
                    else
                    {
                        matrix[startRow, startCol] = '.';
                        Console.WriteLine("Game over!");
                        break;
                    }

                }
                else if (direction == "right")
                {
                    if (IsValidCoordinates(startRow, startCol + 1, matrix))
                    {
                        if (matrix[startRow, startCol + 1] == '-')
                        {
                            matrix[startRow, startCol] = '.';
                            startCol++;
                            matrix[startRow, startCol] = 'S';
                        }
                        else if (matrix[startRow, startCol + 1] == 'B')
                        {
                            matrix[startRow, startCol] = '.';
                            startCol++;
                            matrix[startRow, startCol] = 'S';

                            int mirrorRow = -1;
                            int mirrorCol = -1;
                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < n; col++)
                                {
                                    if (matrix[row, col] == 'B')
                                    {
                                        mirrorRow = row;
                                        mirrorCol = col;
                                    }
                                }
                            }
                            matrix[startRow, startCol] = '.';
                            startRow = mirrorRow;
                            startCol = mirrorCol;
                            matrix[startRow, startCol] = 'S';
                        }
                        else if (matrix[startRow, startCol + 1] == '*')
                        {
                            foodQuantity++;
                            matrix[startRow, startCol] = '.';
                            startCol++;
                            matrix[startRow, startCol] = 'S';

                            if (foodQuantity >= 10)
                            {
                                Console.WriteLine("You won! You fed the snake.");
                                break;
                            }
                        }
                    }
                    else
                    {
                        matrix[startRow, startCol] = '.';
                        Console.WriteLine("Game over!");
                        break;
                    }
                }
              // here ends the cycle
            }

            Console.WriteLine($"Food eaten: {foodQuantity}");

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
