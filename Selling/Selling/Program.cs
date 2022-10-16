using System;
using System.Linq;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[][] matrix = new char[n][];

            int myRow = 0;
            int myCol = 0;
            int money = 0;

            for (int row = 0; row < n; row++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                matrix[row] = line;
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'S')
                    {
                        myRow = row;
                        myCol = col;
                    }
                }
            }

            

            while (true)
            {
                string move = Console.ReadLine();

                if (move == "up")
                {
                    if (AreCoordinatesValid(myRow - 1, myCol, matrix))
                    {
                        if (matrix[myRow - 1][myCol] == 'O')
                        {
                            matrix[myRow][myCol] = '-';
                            matrix[myRow - 1][myCol] = '-';

                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < matrix[row].Length; col++)
                                {
                                    if (matrix[row][col] == 'O')
                                    {
                                        myRow = row;
                                        myCol = col;
                                    }
                                }
                            }

                            matrix[myRow][myCol] = 'S';
                        }
                        else if (char.IsDigit(matrix[myRow - 1][myCol]))
                        {
                            int term = int.Parse(matrix[myRow - 1][myCol].ToString());
                            money += term;
                            
                            matrix[myRow][myCol] = '-';
                            myRow--;
                            matrix[myRow][myCol] = 'S';
                        }
                        else if (matrix[myRow - 1][myCol] == '-')
                        {
                            matrix[myRow][myCol] = '-';
                            myRow--;
                            matrix[myRow][myCol] = 'S';
                        }
                    }
                    else
                    {
                        matrix[myRow][myCol] = '-';
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        break;
                    }
                }
                else if (move == "down")
                {
                    if (AreCoordinatesValid(myRow + 1, myCol, matrix))
                    {
                        if (matrix[myRow + 1][myCol] == 'O')
                        {
                            matrix[myRow][myCol] = '-';
                            matrix[myRow + 1][myCol] = '-';

                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < matrix[row].Length; col++)
                                {
                                    if (matrix[row][col] == 'O')
                                    {
                                        myRow = row;
                                        myCol = col;
                                    }
                                }
                            }

                            matrix[myRow][myCol] = 'S';
                        }
                        else if (char.IsDigit(matrix[myRow + 1][myCol]))
                        {
                            int term = int.Parse(matrix[myRow + 1][myCol].ToString());
                            money += term;

                            matrix[myRow][myCol] = '-';
                            myRow++;
                            matrix[myRow][myCol] = 'S';
                        }
                        else if (matrix[myRow + 1][myCol] == '-')
                        {
                            matrix[myRow][myCol] = '-';
                            myRow++;
                            matrix[myRow][myCol] = 'S';
                        }
                    }
                    else
                    {
                        matrix[myRow][myCol] = '-';
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        break;
                    }
                }
                else if (move == "left")
                {
                    if (AreCoordinatesValid(myRow, myCol - 1, matrix))
                    {
                        if (matrix[myRow][myCol - 1] == 'O')
                        {
                            matrix[myRow][myCol] = '-';
                            matrix[myRow][myCol - 1] = '-';

                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < matrix[row].Length; col++)
                                {
                                    if (matrix[row][col] == 'O')
                                    {
                                        myRow = row;
                                        myCol = col;
                                    }
                                }
                            }

                            matrix[myRow][myCol] = 'S';
                        }
                        else if (char.IsDigit(matrix[myRow][myCol - 1]))
                        {
                            int term = int.Parse(matrix[myRow][myCol - 1].ToString());
                            money += term;

                            matrix[myRow][myCol] = '-';
                            myCol--;
                            matrix[myRow][myCol] = 'S';
                        }
                        else if (matrix[myRow][myCol - 1] == '-')
                        {
                            matrix[myRow][myCol] = '-';
                            myCol--;
                            matrix[myRow][myCol] = 'S';
                        }
                    }
                    else
                    {
                        matrix[myRow][myCol] = '-';
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        break;
                    }
                }
                else if (move == "right")
                {
                    if (AreCoordinatesValid(myRow, myCol + 1, matrix))
                    {
                        if (matrix[myRow][myCol + 1] == 'O')
                        {
                            matrix[myRow][myCol] = '-';
                            matrix[myRow][myCol + 1] = '-';

                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < matrix[row].Length; col++)
                                {
                                    if (matrix[row][col] == 'O')
                                    {
                                        myRow = row;
                                        myCol = col;
                                    }
                                }
                            }

                            matrix[myRow][myCol] = 'S';
                        }
                        else if (char.IsDigit(matrix[myRow][myCol + 1]))
                        {
                            int term = int.Parse(matrix[myRow][myCol + 1].ToString());
                            money += term;

                            matrix[myRow][myCol] = '-';
                            myCol++;
                            matrix[myRow][myCol] = 'S';
                        }
                        else if (matrix[myRow][myCol + 1] == '-')
                        {
                            matrix[myRow][myCol] = '-';
                            myCol++;
                            matrix[myRow][myCol] = 'S';
                        }
                    }
                    else
                    {
                        matrix[myRow][myCol] = '-';
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        break;
                    }
                }

                if (money >= 50)
                {
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");                    
                    break;
                }

            }// the loop ends here

            Console.WriteLine($"Money: {money}");
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
