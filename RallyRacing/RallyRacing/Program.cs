using System;
using System.Linq;
using System.Collections.Generic;

namespace RallyRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            string recingNumber = Console.ReadLine();

            int startRow = 0;
            int startCol = 0;

            int kilometers = 0;

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            while (true)
            {
                string direction = Console.ReadLine();
                if (direction == "End")
                {
                    Console.WriteLine("Racing car {0} DNF.", recingNumber);
                    break;
                }

                if (direction == "up")
                {
                    if (IsValidCoordinates(startRow - 1, startCol, matrix))
                    {
                        if (matrix[startRow - 1, startCol] == '.')
                        {
                            matrix[startRow, startCol] = '.';
                            startRow--;
                            matrix[startRow, startCol] = 'C';
                            kilometers += 10;
                        }
                        else if (matrix[startRow - 1, startCol] == 'T')
                        {
                            matrix[startRow, startCol] = '.';
                            startRow--;
                            matrix[startRow, startCol] = 'C';

                            int tunnelRow = -1;
                            int tunnelCol = -1;
                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < n; col++)
                                {
                                    if (matrix[row, col] == 'T')
                                    {
                                        tunnelRow = row;
                                        tunnelCol = col;
                                    }
                                }
                            }
                            matrix[startRow, startCol] = '.';
                            startRow = tunnelRow;
                            startCol = tunnelCol;
                            matrix[startRow, startCol] = 'C';
                            kilometers += 30;
                        }
                        else if (matrix[startRow - 1, startCol] == 'F')
                        {

                            matrix[startRow, startCol] = '.';
                            startRow--;
                            matrix[startRow, startCol] = 'C';
                            kilometers += 10;
                            Console.WriteLine("Racing car {0} finished the stage!", recingNumber);
                            break;
                        }
                    }

                }
                else if (direction == "down")
                {
                    if (IsValidCoordinates(startRow + 1, startCol, matrix))
                    {
                        if (matrix[startRow + 1, startCol] == '.')
                        {
                            matrix[startRow, startCol] = '.';
                            startRow++;
                            matrix[startRow, startCol] = 'C';
                            kilometers += 10;
                        }
                        else if (matrix[startRow + 1, startCol] == 'T')
                        {
                            matrix[startRow, startCol] = '.';
                            startRow++;
                            matrix[startRow, startCol] = 'C';

                            int tunnelRow = -1;
                            int tunnelCol = -1;
                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < n; col++)
                                {
                                    if (matrix[row, col] == 'T')
                                    {
                                        tunnelRow = row;
                                        tunnelCol = col;
                                    }
                                }
                            }
                            matrix[startRow, startCol] = '.';
                            startRow = tunnelRow;
                            startCol = tunnelCol;
                            matrix[startRow, startCol] = 'C';
                            kilometers += 30;
                        }
                        else if (matrix[startRow + 1, startCol] == 'F')
                        {
                            matrix[startRow, startCol] = '.';
                            startRow++;
                            matrix[startRow, startCol] = 'C';

                            kilometers += 10;
                            Console.WriteLine("Racing car {0} finished the stage!", recingNumber);
                            break;
                        }
                    }


                }
                else if (direction == "left")
                {
                    if (IsValidCoordinates(startRow, startCol - 1, matrix))
                    {
                        if (matrix[startRow, startCol - 1] == '.')
                        {
                            matrix[startRow, startCol] = '.';
                            startCol--;
                            matrix[startRow, startCol] = 'C';
                            kilometers += 10;
                        }
                        else if (matrix[startRow, startCol - 1] == 'T')
                        {
                            matrix[startRow, startCol] = '.';
                            startCol--;
                            matrix[startRow, startCol] = 'C';

                            int tunnelRow = -1;
                            int tunnelCol = -1;
                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < n; col++)
                                {
                                    if (matrix[row, col] == 'T')
                                    {
                                        tunnelRow = row;
                                        tunnelCol = col;
                                    }
                                }
                            }
                            matrix[startRow, startCol] = '.';
                            startRow = tunnelRow;
                            startCol = tunnelCol;
                            matrix[startRow, startCol] = 'C';
                            kilometers += 30;

                        }
                        else if (matrix[startRow, startCol - 1] == 'F')
                        {
                            matrix[startRow, startCol] = '.';
                            startCol--;
                            matrix[startRow, startCol] = 'C';

                            kilometers += 10;
                            Console.WriteLine("Racing car {0} finished the stage!", recingNumber);
                            break;

                        }
                    }


                }
                else if (direction == "right")
                {
                    if (IsValidCoordinates(startRow, startCol + 1, matrix))
                    {
                        if (matrix[startRow, startCol + 1] == '.')
                        {
                            matrix[startRow, startCol] = '.';
                            startCol++;
                            matrix[startRow, startCol] = 'C';
                            kilometers += 10;
                        }
                        else if (matrix[startRow, startCol + 1] == 'T')
                        {
                            matrix[startRow, startCol] = '.';
                            startCol++;
                            matrix[startRow, startCol] = 'C';

                            int tunnelRow = -1;
                            int tunnelCol = -1;
                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < n; col++)
                                {
                                    if (matrix[row, col] == 'T')
                                    {
                                        tunnelRow = row;
                                        tunnelCol = col;
                                    }
                                }
                            }
                            matrix[startRow, startCol] = '.';
                            startRow = tunnelRow;
                            startCol = tunnelCol;
                            matrix[startRow, startCol] = 'C';
                            kilometers += 30;
                        }
                        else if (matrix[startRow, startCol + 1] == 'F')
                        {
                            matrix[startRow, startCol] = '.';
                            startCol++;
                            matrix[startRow, startCol] = 'C';

                            kilometers += 10;
                            Console.WriteLine("Racing car {0} finished the stage!", recingNumber);
                            break;
                        }
                    }
                }
            }// here ends the cycle

            Console.WriteLine($"Distance covered {kilometers} km.");

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