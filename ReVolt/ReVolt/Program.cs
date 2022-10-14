using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReVolt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (n < 2 || n > 20)
            {
                return;
            }

            int movementsNumber = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int rowPlayer = -1;
            int colPlayer = -1;
            int finishRow = -1;
            int finishCol = -1;

            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'f')
                    {
                        rowPlayer = row;
                        colPlayer = col;
                    }
                    if (matrix[row, col] == 'F')
                    {
                        finishRow = row;
                        finishCol = col;
                    }
                }
            }

            int counter = 0;

            while (counter != movementsNumber)
            {
                string move = Console.ReadLine();
                counter++;

                if (move == "up")
                {
                    if (IsValidCoordinates(rowPlayer - 1, colPlayer, matrix))
                    {
                        if (matrix[rowPlayer - 1, colPlayer] == 'F')
                        {
                            matrix[rowPlayer, colPlayer] = '-';
                            rowPlayer -= 1;
                            matrix[rowPlayer, colPlayer] = 'f';
                            Console.WriteLine("Player won!");
                            break;
                        }
                        else if (matrix[rowPlayer - 1, colPlayer] == 'B')
                        {
                            matrix[rowPlayer, colPlayer] = '-';
                            rowPlayer -= 1;
                            rowPlayer -= 1;
                            if (rowPlayer < 0)
                            {
                                rowPlayer = matrix.GetLength(0) - 1;
                            }                                
                            matrix[rowPlayer, colPlayer] = 'f';
                        }
                        else if (matrix[rowPlayer - 1, colPlayer] == 'T')
                        {
                            rowPlayer -= 1;
                            rowPlayer += 1;
                        }
                        else
                        {
                            matrix[rowPlayer, colPlayer] = '-';
                            rowPlayer -= 1;
                            matrix[rowPlayer, colPlayer] = 'f';
                        }
                    }
                    else
                    {
                        matrix[rowPlayer, colPlayer] = '-';
                        rowPlayer = matrix.GetLength(0) - 1;

                        if (matrix[rowPlayer, colPlayer] == 'F')
                        {
                            matrix[rowPlayer, colPlayer] = 'f';
                            Console.WriteLine("Player won!");
                            break;
                        }
                        else if (matrix[rowPlayer, colPlayer] == 'B')
                        {
                            matrix[rowPlayer, colPlayer] = '-';
                            rowPlayer -= 1;
                            if (rowPlayer < 0)
                            {
                                rowPlayer = matrix.GetLength(0) - 1;
                            }
                            matrix[rowPlayer, colPlayer] = 'f';
                        }
                        else if (matrix[rowPlayer, colPlayer] == 'T')
                        {
                            rowPlayer += 1;
                            matrix[rowPlayer, colPlayer] = 'f';
                        }
                        else
                        {
                            matrix[rowPlayer, colPlayer] = 'f';
                        }
                    }
                }
                else if (move == "down")
                {
                    if (IsValidCoordinates(rowPlayer + 1, colPlayer, matrix))
                    {
                        if (matrix[rowPlayer + 1, colPlayer] == 'F')
                        {
                            matrix[rowPlayer, colPlayer] = '-';
                            rowPlayer += 1;
                            matrix[rowPlayer, colPlayer] = 'f';
                            Console.WriteLine("Player won!");
                            break;
                        }
                        else if (matrix[rowPlayer + 1, colPlayer] == 'B')
                        {
                            matrix[rowPlayer, colPlayer] = '-';
                            rowPlayer += 1;
                            rowPlayer += 1;
                            if (rowPlayer >= matrix.GetLength(0))
                            {
                                rowPlayer = 0;
                            }
                            matrix[rowPlayer, colPlayer] = 'f';
                        }
                        else if (matrix[rowPlayer + 1, colPlayer] == 'T')
                        {
                            rowPlayer += 1;
                            rowPlayer -= 1;
                        }
                        else
                        {
                            matrix[rowPlayer, colPlayer] = '-';
                            rowPlayer += 1;
                            matrix[rowPlayer, colPlayer] = 'f';
                        }
                    }
                    else
                    {
                        matrix[rowPlayer, colPlayer] = '-';
                        rowPlayer = 0;

                        if (matrix[rowPlayer, colPlayer] == 'F')
                        {
                            matrix[rowPlayer, colPlayer] = 'f';
                            Console.WriteLine("Player won!");
                            break;
                        }
                        else if (matrix[rowPlayer, colPlayer] == 'B')
                        {
                            matrix[rowPlayer, colPlayer] = '-';
                            rowPlayer += 1;
                            if (rowPlayer >= matrix.GetLength(0))
                            {
                                rowPlayer = 0;
                            }
                            matrix[rowPlayer, colPlayer] = 'f';
                        }
                        else if (matrix[rowPlayer, colPlayer] == 'T')
                        {
                            rowPlayer -= 1;
                            matrix[rowPlayer, colPlayer] = 'f';
                        }
                        else
                        {
                            matrix[rowPlayer, colPlayer] = 'f';
                        }
                    }
                }
                else if (move == "left")
                {
                    if (IsValidCoordinates(rowPlayer, colPlayer - 1, matrix))
                    {
                        if (matrix[rowPlayer, colPlayer - 1] == 'F')
                        {
                            matrix[rowPlayer, colPlayer] = '-';
                            colPlayer -= 1;
                            matrix[rowPlayer, colPlayer] = 'f';
                            Console.WriteLine("Player won!");
                            break;
                        }
                        else if (matrix[rowPlayer, colPlayer - 1] == 'B')
                        {
                            matrix[rowPlayer, colPlayer] = '-';
                            colPlayer -= 1;
                            colPlayer -= 1;
                            if (colPlayer < 0)
                            {
                                colPlayer = matrix.GetLength(1) - 1;
                            }
                            matrix[rowPlayer, colPlayer] = 'f';
                        }
                        else if (matrix[rowPlayer, colPlayer - 1] == 'T')
                        {
                            colPlayer -= 1;
                            colPlayer += 1;
                        }
                        else
                        {
                            matrix[rowPlayer, colPlayer] = '-';
                            colPlayer -= 1;
                            matrix[rowPlayer, colPlayer] = 'f';
                        }
                    }
                    else
                    {
                        matrix[rowPlayer, colPlayer] = '-';
                        colPlayer = matrix.GetLength(1) - 1;

                        if (matrix[rowPlayer, colPlayer] == 'F')
                        {
                            matrix[rowPlayer, colPlayer] = 'f';
                            Console.WriteLine("Player won!");
                            break;
                        }
                        else if (matrix[rowPlayer, colPlayer] == 'B')
                        {
                            matrix[rowPlayer, colPlayer] = '-';
                            colPlayer -= 1;
                            if (colPlayer < 0)
                            {
                                colPlayer = matrix.GetLength(1) - 1;
                            }
                            matrix[rowPlayer, colPlayer] = 'f';
                        }
                        else if (matrix[rowPlayer, colPlayer] == 'T')
                        {
                            colPlayer += 1;
                            matrix[rowPlayer, colPlayer] = 'f';
                        }
                        else
                        {
                            matrix[rowPlayer, colPlayer] = 'f';
                        }
                    }
                }
                else if (move == "right")
                {
                    if (IsValidCoordinates(rowPlayer, colPlayer + 1, matrix))
                    {
                        if (matrix[rowPlayer, colPlayer + 1] == 'F')
                        {
                            matrix[rowPlayer, colPlayer] = '-';
                            colPlayer += 1;
                            matrix[rowPlayer, colPlayer] = 'f';
                            Console.WriteLine("Player won!");
                            break;
                        }
                        else if (matrix[rowPlayer, colPlayer + 1] == 'B')
                        {
                            matrix[rowPlayer, colPlayer] = '-';
                            colPlayer += 1;
                            colPlayer += 1;
                            if (colPlayer >= matrix.GetLength(1))
                            {
                                colPlayer = 0;
                            }
                            matrix[rowPlayer, colPlayer] = 'f';
                        }
                        else if (matrix[rowPlayer, colPlayer + 1] == 'T')
                        {
                            colPlayer += 1;
                            colPlayer -= 1;
                        }
                        else
                        {
                            matrix[rowPlayer, colPlayer] = '-';
                            colPlayer += 1;
                            matrix[rowPlayer, colPlayer] = 'f';
                        }
                    }
                    else
                    {
                        matrix[rowPlayer, colPlayer] = '-';
                        colPlayer = 0;

                        if (matrix[rowPlayer, colPlayer] == 'F')
                        {
                            matrix[rowPlayer, colPlayer] = 'f';
                            Console.WriteLine("Player won!");
                            break;
                        }
                        else if (matrix[rowPlayer, colPlayer] == 'B')
                        {
                            matrix[rowPlayer, colPlayer] = '-';
                            colPlayer += 1;
                            if (colPlayer >= matrix.GetLength(1))
                            {
                                colPlayer = 0;
                            }
                            matrix[rowPlayer, colPlayer] = 'f';
                        }
                        else if (matrix[rowPlayer, colPlayer] == 'T')
                        {
                            colPlayer -= 1;
                            matrix[rowPlayer, colPlayer] = 'f';
                        }
                        else
                        {
                            matrix[rowPlayer, colPlayer] = 'f';
                        }
                    }
                }            
                
            }

            
            if (counter == movementsNumber)
            {
                Console.WriteLine("Player lost!");
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
