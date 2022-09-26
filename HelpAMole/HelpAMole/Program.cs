using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpAMole
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            int rowMole = 0;
            int colMole = 0;

            int points = 0;

            char[,] matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'M')
                    {
                        rowMole = row;
                        colMole = col;
                    }
                }
            }           

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                if (command == "up")
                {
                    if (rowMole - 1 < 0)
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                    else if (matrix[rowMole - 1, colMole] == 'S')
                    {
                        matrix[rowMole, colMole] = '-';
                        matrix[rowMole - 1, colMole] = '-';

                        for (int i = 0; i < matrix.GetLongLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLongLength(1); j++)
                            {
                                if (matrix[i, j] == 'S')
                                {
                                    matrix[i, j] = 'M';
                                    rowMole = i;
                                    colMole = j;
                                    points -= 3;
                                }

                            }
                        }
                    }
                    else if (matrix[rowMole - 1, colMole] != 'S' && matrix[rowMole - 1, colMole] != '-')
                    {
                        int interimPoints = int.Parse(matrix[rowMole - 1, colMole].ToString());
                        points += interimPoints;
                        matrix[rowMole, colMole] = '-';
                        rowMole -= 1;
                        matrix[rowMole, colMole] = 'M';
                    }
                    else if (matrix[rowMole - 1, colMole] == '-')
                    {
                        matrix[rowMole, colMole] = '-';
                        rowMole -= 1;
                        matrix[rowMole, colMole] = 'M';
                    }                       
                }             
                
                else if (command == "down")
                {
                    if (rowMole + 1 >= n)
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                    else if (matrix[rowMole + 1, colMole] == 'S')
                    {
                        matrix[rowMole, colMole] = '-';
                        matrix[rowMole + 1, colMole] = '-';

                        for (int i = 0; i < matrix.GetLongLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLongLength(1); j++)
                            {
                                if (matrix[i, j] == 'S')
                                {
                                    matrix[i, j] = 'M';
                                    rowMole = i;
                                    colMole = j;
                                    points -= 3;
                                }

                            }
                        }
                    }
                    else if (matrix[rowMole + 1, colMole] != 'S' && matrix[rowMole + 1, colMole] != '-')
                    {
                        int interimPoints = int.Parse(matrix[rowMole + 1, colMole].ToString());
                        points += interimPoints;
                        matrix[rowMole, colMole] = '-';
                        rowMole += 1;
                        matrix[rowMole, colMole] = 'M';
                    }
                    else if (matrix[rowMole + 1, colMole] == '-')
                    {
                        matrix[rowMole, colMole] = '-';
                        rowMole += 1;
                        matrix[rowMole, colMole] = 'M';
                    }

                }
                else if (command == "left")
                {
                    if (colMole - 1 < 0)
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                    else if (matrix[rowMole, colMole - 1] == 'S')
                    {
                        matrix[rowMole, colMole] = '-';
                        matrix[rowMole, colMole - 1] = '-';

                        for (int i = 0; i < matrix.GetLongLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLongLength(1); j++)
                            {
                                if (matrix[i, j] == 'S')
                                {
                                    matrix[i, j] = 'M';
                                    rowMole = i;
                                    colMole = j;
                                    points -= 3;
                                }

                            }
                        }
                    }
                    else if (matrix[rowMole, colMole - 1] != 'S' && matrix[rowMole, colMole - 1] != '-')
                    {
                        int interimPoints = int.Parse(matrix[rowMole, colMole - 1].ToString());
                        points += interimPoints;
                        matrix[rowMole, colMole] = '-';
                        colMole -= 1;
                        matrix[rowMole, colMole] = 'M';
                    }
                    else if (matrix[rowMole, colMole - 1] == '-')
                    {
                        matrix[rowMole, colMole] = '-';
                        colMole -= 1;
                        matrix[rowMole, colMole] = 'M';
                    }

                }
                else if (command == "right")
                {
                    if (colMole + 1 >= n)
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                    else if (matrix[rowMole, colMole + 1] == 'S')
                    {
                        matrix[rowMole, colMole] = '-';
                        matrix[rowMole, colMole + 1] = '-';

                        for (int i = 0; i < matrix.GetLongLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLongLength(1); j++)
                            {
                                if (matrix[i, j] == 'S')
                                {
                                    matrix[i, j] = 'M';
                                    rowMole = i;
                                    colMole = j;
                                    points -= 3;
                                }

                            }
                        }
                    }
                    else if (matrix[rowMole, colMole + 1] != 'S' && matrix[rowMole, colMole + 1] != '-')
                    {
                        int interimPoints = int.Parse(matrix[rowMole, colMole + 1].ToString());
                        points += interimPoints;
                        matrix[rowMole, colMole] = '-';
                        colMole += 1;
                        matrix[rowMole, colMole] = 'M';
                    }
                    else if (matrix[rowMole, colMole + 1] == '-')
                    {
                        matrix[rowMole, colMole] = '-';
                        colMole += 1;
                        matrix[rowMole, colMole] = 'M';
                    }
                }

                if (points >= 25)
                {
                    Console.WriteLine("Yay! The Mole survived another game!");
                    Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
                    break;
                }
                
            }

            if (points < 25)
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }

            for (int i = 0; i < matrix.GetLongLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLongLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
