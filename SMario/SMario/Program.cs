using System;
using System.Linq;

namespace SMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int e = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            char[][] matrix = new char[n][];

            int marioRow = 0;
            int marioCol = 0;

            if (n < 5 || n > 25)
            {
                return;
            }

            for (int row = 0; row < n; row++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                matrix[row] = line;
                
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split().ToArray();

                string moveDirect = command[0];

                int enemyRow = int.Parse(command[1]);
                int enemyCol = int.Parse(command[2]);

                matrix[enemyRow][enemyCol] = 'B';
                e--;

                if (moveDirect == "W") //"W"(up), "S"(down), "A"(left), "D"(right).
                {
                    if (AreCoordinatesValid(marioRow - 1, marioCol, matrix))              
                    {
                        if (matrix[marioRow - 1][marioCol] == 'B')
                        {
                            e -= 2;
                            if (e <= 0)
                            {
                                Console.WriteLine("Mario died at {0};{1}.", marioRow - 1, marioCol);
                                matrix[marioRow - 1][marioCol] = 'X';
                                matrix[marioRow][marioCol] = '-';
                                break;
                            }
                            else
                            {
                                matrix[marioRow - 1][marioCol] = 'M';
                                matrix[marioRow][marioCol] = '-';
                                marioRow--;
                            }
                        }
                        else if (matrix[marioRow - 1][marioCol] == 'P')
                        {                            
                            matrix[marioRow - 1][marioCol] = '-';
                            matrix[marioRow][marioCol] = '-';
                            Console.WriteLine("Mario has successfully saved the princess! Lives left: {0}", e);
                            break;
                        }
                        else
                        {
                            matrix[marioRow - 1][marioCol] = 'M';
                            matrix[marioRow][marioCol] = '-';
                            marioRow--;
                        }
                    }
                }
                else if (moveDirect == "S")
                {
                    if (AreCoordinatesValid(marioRow + 1, marioCol, matrix))
                    {
                        if (matrix[marioRow + 1][marioCol] == 'B')
                        {
                            e -= 2;
                            if (e <= 0)
                            {
                                Console.WriteLine("Mario died at {0};{1}.", marioRow + 1, marioCol);
                                matrix[marioRow + 1][marioCol] = 'X';
                                matrix[marioRow][marioCol] = '-';
                                break;
                            }
                            else
                            {
                                matrix[marioRow + 1][marioCol] = 'M';
                                matrix[marioRow][marioCol] = '-';
                                marioRow++;
                            }
                        }
                        else if (matrix[marioRow + 1][marioCol] == 'P')
                        {                            
                            matrix[marioRow + 1][marioCol] = '-';
                            matrix[marioRow][marioCol] = '-';
                            Console.WriteLine("Mario has successfully saved the princess! Lives left: {0}", e);
                            break;
                        }
                        else
                        {
                            matrix[marioRow + 1][marioCol] = 'M';
                            matrix[marioRow][marioCol] = '-';
                            marioRow++;
                        }
                    }
                }
                else if (moveDirect == "A")
                {
                    if (AreCoordinatesValid(marioRow, marioCol - 1, matrix))
                    {
                        if (matrix[marioRow][marioCol - 1] == 'B')
                        {
                            e -= 2;
                            if (e <= 0)
                            {
                                Console.WriteLine("Mario died at {0};{1}.", marioRow, marioCol - 1);
                                matrix[marioRow][marioCol - 1] = 'X';
                                matrix[marioRow][marioCol] = '-';
                                break;
                            }
                            else
                            {
                                matrix[marioRow][marioCol - 1] = 'M';
                                matrix[marioRow][marioCol] = '-';
                                marioCol--;
                            }
                        }
                        else if (matrix[marioRow][marioCol - 1] == 'P')
                        {                            
                            matrix[marioRow][marioCol - 1] = '-';
                            matrix[marioRow][marioCol] = '-';
                            Console.WriteLine("Mario has successfully saved the princess! Lives left: {0}", e);
                            break;
                        }
                        else 
                        {
                            matrix[marioRow][marioCol - 1] = 'M';
                            matrix[marioRow][marioCol] = '-';
                            marioCol--;
                        }
                    }
                }
                                   
                else if (moveDirect == "D")
                {
                    if (AreCoordinatesValid(marioRow, marioCol + 1, matrix))
                    {
                        if (matrix[marioRow][marioCol + 1] == 'B')
                        {
                            e -= 2;
                            if (e <= 0)
                            {
                                Console.WriteLine("Mario died at {0};{1}.", marioRow, marioCol + 1);
                                matrix[marioRow][marioCol + 1] = 'X';
                                matrix[marioRow][marioCol] = '-';
                                break;
                            }
                            else
                            {
                                matrix[marioRow][marioCol + 1] = 'M';
                                matrix[marioRow][marioCol] = '-';
                                marioCol++;
                            }
                        }
                        else if (matrix[marioRow][marioCol + 1] == 'P')
                        {                            
                            matrix[marioRow][marioCol + 1] = '-';
                            matrix[marioRow][marioCol] = '-';
                            Console.WriteLine("Mario has successfully saved the princess! Lives left: {0}", e);
                            break;
                        }
                        else 
                        {
                            matrix[marioRow][marioCol + 1] = 'M';
                            matrix[marioRow][marioCol] = '-';
                            marioCol++;
                        }
                    }                   
                }
                if (e == 0)
                {
                    Console.WriteLine("Mario died at {0};{1}.", marioRow, marioCol);
                    matrix[marioRow][marioCol] = 'X';                    
                    break;
                }
            }

            MatrixPrinter(matrix);
        }

        public static bool AreCoordinatesValid(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length;            
        }

        public static void MatrixPrinter(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}

