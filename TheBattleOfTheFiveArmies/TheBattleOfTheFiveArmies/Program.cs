using System;
using System.Linq;
using System.Collections.Generic;

namespace TheBattleOfTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int e = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            char[][] matrix = new char[n][];

            int armyRow = 0;
            int armyCol = 0;


            if (n < 5 || n > 20)
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
                    if (matrix[row][col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }
            }

            string[] command = Console.ReadLine().Split().ToArray();

            while (true)
            {              
                string moveDirect = command[0];

                int orcRow = int.Parse(command[1]);
                int orcCol = int.Parse(command[2]);

                matrix[orcRow][orcCol] = 'O';
                e--;

                if (moveDirect == "up")
                {
                    if (AreCoordinatesValid(armyRow - 1, armyCol, matrix))
                    {
                        if (matrix[armyRow - 1][armyCol] == 'O')
                        {
                            e -= 2;
                            if (e <= 0)
                            {
                                matrix[armyRow][armyCol] = '-';
                                armyRow--;
                                matrix[armyRow][armyCol] = 'X';
                                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                                break;
                            }
                            else
                            {
                                matrix[armyRow][armyCol] = '-';
                                armyRow--;
                                matrix[armyRow][armyCol] = 'A';
                            }
                        }
                        else if (matrix[armyRow - 1][armyCol] == 'M')
                        {
                            matrix[armyRow][armyCol] = '-';
                            armyRow--;
                            matrix[armyRow][armyCol] = '-';
                            Console.WriteLine($"The army managed to free the Middle World! Armor left: {e}");
                            break;
                        }
                        else if (matrix[armyRow - 1][armyCol] == '-')
                        {
                            if (e <= 0)
                            {
                                matrix[armyRow][armyCol] = '-';
                                armyRow--;
                                matrix[armyRow][armyCol] = 'X';
                                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                                break;
                            }
                            else
                            {
                                matrix[armyRow][armyCol] = '-';
                                armyRow--;
                                matrix[armyRow][armyCol] = 'A';
                            }
                        }

                    }
                }
                else if (moveDirect == "down")
                {
                    if (AreCoordinatesValid(armyRow + 1, armyCol, matrix))
                    {
                        if (matrix[armyRow + 1][armyCol] == 'O')
                        {
                            e -= 2;
                            if (e <= 0)
                            {
                                matrix[armyRow][armyCol] = '-';
                                armyRow++;
                                matrix[armyRow][armyCol] = 'X';
                                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                                break;
                            }
                            else
                            {
                                matrix[armyRow][armyCol] = '-';
                                armyRow++;
                                matrix[armyRow][armyCol] = 'A';
                            }
                        }
                        else if (matrix[armyRow + 1][armyCol] == 'M')
                        {
                            matrix[armyRow][armyCol] = '-';
                            armyRow++;
                            matrix[armyRow][armyCol] = '-';
                            Console.WriteLine($"The army managed to free the Middle World! Armor left: {e}");
                            break;
                        }
                        else if (matrix[armyRow + 1][armyCol] == '-')
                        {
                            if (e <= 0)
                            {
                                matrix[armyRow][armyCol] = '-';
                                armyRow++;
                                matrix[armyRow][armyCol] = 'X';
                                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                                break;
                            }
                            else
                            {
                                matrix[armyRow][armyCol] = '-';
                                armyRow++;
                                matrix[armyRow][armyCol] = 'A';
                            }
                        }

                    }
                }
                else if (moveDirect == "left")
                {
                    if (AreCoordinatesValid(armyRow, armyCol - 1, matrix))
                    {
                        if (matrix[armyRow][armyCol - 1] == 'O')
                        {
                            e -= 2;
                            if (e <= 0)
                            {
                                matrix[armyRow][armyCol] = '-';
                                armyCol--;
                                matrix[armyRow][armyCol] = 'X';
                                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                                break;
                            }
                            else
                            {
                                matrix[armyRow][armyCol] = '-';
                                armyCol--;
                                matrix[armyRow][armyCol] = 'A';
                            }
                        }
                        else if (matrix[armyRow][armyCol - 1] == 'M')
                        {
                            matrix[armyRow][armyCol] = '-';
                            armyCol--;
                            matrix[armyRow][armyCol] = '-';
                            Console.WriteLine($"The army managed to free the Middle World! Armor left: {e}");
                            break;
                        }
                        else if (matrix[armyRow][armyCol - 1] == '-')
                        {
                            if (e <= 0)
                            {
                                matrix[armyRow][armyCol] = '-';
                                armyCol--;
                                matrix[armyRow][armyCol] = 'X';
                                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                                break;
                            }
                            else
                            {
                                matrix[armyRow][armyCol] = '-';
                                armyCol--;
                                matrix[armyRow][armyCol] = 'A';
                            }
                        }

                    }
                }
                else if (moveDirect == "right")
                {
                    if (AreCoordinatesValid(armyRow, armyCol - 1, matrix))
                    {
                        if (matrix[armyRow][armyCol + 1] == 'O')
                        {
                            e -= 2;
                            if (e <= 0)
                            {
                                matrix[armyRow][armyCol] = '-';
                                armyCol++;
                                matrix[armyRow][armyCol] = 'X';
                                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                                break;
                            }
                            else
                            {
                                matrix[armyRow][armyCol] = '-';
                                armyCol++;
                                matrix[armyRow][armyCol] = 'A';
                            }
                        }
                        else if (matrix[armyRow][armyCol + 1] == 'M')
                        {
                            matrix[armyRow][armyCol] = '-';
                            armyCol++;
                            matrix[armyRow][armyCol] = '-';
                            Console.WriteLine($"The army managed to free the Middle World! Armor left: {e}");
                            break;
                        }
                        else if (matrix[armyRow][armyCol + 1] == '-')
                        {
                            if (e <= 0)
                            {
                                matrix[armyRow][armyCol] = '-';
                                armyCol++;
                                matrix[armyRow][armyCol] = 'X';
                                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                                break;
                            }
                            else
                            {
                                matrix[armyRow][armyCol] = '-';
                                armyCol++;
                                matrix[armyRow][armyCol] = 'A';
                            }
                        }

                    }
                }
                command = Console.ReadLine().Split().ToArray();
            }
            MatrixPrinter(matrix);

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

        public static bool AreCoordinatesValid(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length;
        }

    }
}
