using System;
using System.Linq;
using System.Collections.Generic;

namespace BeaverAtWork
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int startRow = -1;
            int startCol = -1;

            Stack<char> branches = new Stack<char>();

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine().Split().Select(char.Parse).ToArray();
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

            while (direction != "end")
            {

                if (direction == "up")
                {
                    if (IsValidCoordinates(startRow - 1, startCol, matrix))
                    {
                        if (matrix[startRow - 1, startCol] == '-')
                        {
                            matrix[startRow, startCol] = '-';
                            startRow--;
                            matrix[startRow, startCol] = 'B';
                        }
                        else if (matrix[startRow - 1, startCol] == 'F')
                        {
                            matrix[startRow, startCol] = '-';
                            startRow--;
                            matrix[startRow, startCol] = '-';

                            if (startRow == 0)
                            {
                                for (int i = startRow; i < matrix.GetLength(0); i++)
                                {
                                    if (matrix[i, startCol] != '-')
                                    {
                                        branches.Push(matrix[i, startCol]);
                                        matrix[i, startCol] = '-';
                                    }
                                }
                                startRow = matrix.GetLength(0) - 1;
                                matrix[startRow, startCol] = 'B';

                                if (AreAllBranchesCollected(matrix))
                                {
                                    break;
                                }
                            }
                            else
                            {
                                for (int i = startRow; i >= 0; i--)
                                {
                                    if (matrix[i, startCol] != '-')
                                    {
                                        branches.Push(matrix[i, startCol]);
                                        matrix[i, startCol] = '-';
                                    }
                                }
                                startRow = 0;
                                matrix[startRow, startCol] = 'B';
                                if (AreAllBranchesCollected(matrix))
                                {
                                    break;
                                }
                            }
                        }
                        else if (char.IsLetter(matrix[startRow - 1, startCol]) && matrix[startRow - 1, startCol] != 'F')
                        {
                            matrix[startRow, startCol] = '-';
                            startRow--;
                            branches.Push(matrix[startRow, startCol]);
                            matrix[startRow, startCol] = 'B';
                            if (AreAllBranchesCollected(matrix))
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (branches.Any())
                        {
                            branches.Pop();
                        }
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
                            matrix[startRow, startCol] = 'B';
                        }
                        else if (matrix[startRow + 1, startCol] == 'F')
                        {
                            matrix[startRow, startCol] = '-';
                            startRow++;
                            matrix[startRow, startCol] = '-';

                            if (startRow == matrix.GetLength(0) - 1)
                            {
                                for (int i = startRow; i >= 0; i--)
                                {
                                    if (matrix[i, startCol] != '-')
                                    {
                                        branches.Push(matrix[i, startCol]);
                                        matrix[i, startCol] = '-';
                                    }
                                }
                                startRow = 0;
                                matrix[startRow, startCol] = 'B';
                                if (AreAllBranchesCollected(matrix))
                                {
                                    break;
                                }
                            }
                            else
                            {
                                for (int i = startRow; i < matrix.GetLength(0); i++)
                                {
                                    if (matrix[i, startCol] != '-')
                                    {
                                        branches.Push(matrix[i, startCol]);
                                        matrix[i, startCol] = '-';
                                    }
                                }
                                startRow = matrix.GetLength(0) - 1;
                                matrix[startRow, startCol] = 'B';
                                if (AreAllBranchesCollected(matrix))
                                {
                                    break;
                                }
                            }
                        }
                        else if (char.IsLetter(matrix[startRow + 1, startCol]) && matrix[startRow + 1, startCol] != 'F')
                        {
                            matrix[startRow, startCol] = '-';
                            startRow++;
                            branches.Push(matrix[startRow, startCol]);
                            matrix[startRow, startCol] = 'B';
                            if (AreAllBranchesCollected(matrix))
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (branches.Any())
                        {
                            branches.Pop();
                        }
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
                            matrix[startRow, startCol] = 'B';
                        }
                        else if (matrix[startRow, startCol - 1] == 'F')
                        {
                            matrix[startRow, startCol] = '-';
                            startCol--;
                            matrix[startRow, startCol] = '-';

                            if (startCol == 0)
                            {
                                for (int i = startCol; i < matrix.GetLength(1); i++)
                                {
                                    if (matrix[startRow, i] != '-')
                                    {
                                        branches.Push(matrix[startRow, i]);
                                        matrix[startRow, i] = '-';
                                    }
                                }
                                startCol = matrix.GetLength(1) - 1;
                                matrix[startRow, startCol] = 'B';
                                if (AreAllBranchesCollected(matrix))
                                {
                                    break;
                                }
                            }
                            else
                            {
                                for (int i = startCol; i >= 0; i--)
                                {
                                    if (matrix[startRow, i] != '-')
                                    {
                                        branches.Push(matrix[startRow, i]);
                                        matrix[startRow, i] = '-';
                                    }
                                }
                                startCol = 0; 
                                matrix[startRow, startCol] = 'B';
                                if (AreAllBranchesCollected(matrix))
                                {
                                    break;
                                }
                            }
                        }
                        else if (char.IsLetter(matrix[startRow, startCol - 1]) && matrix[startRow, startCol - 1] != 'F')
                        {
                            matrix[startRow, startCol] = '-';
                            startCol--;
                            branches.Push(matrix[startRow, startCol]);
                            matrix[startRow, startCol] = 'B';
                            if (AreAllBranchesCollected(matrix))
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (branches.Any())
                        {
                            branches.Pop();
                        }
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
                            matrix[startRow, startCol] = 'B';
                        }
                        else if (matrix[startRow, startCol + 1] == 'F')
                        {
                            matrix[startRow, startCol] = '-';
                            startCol++;
                            matrix[startRow, startCol] = '-';

                            if (startCol == matrix.GetLength(1) - 1)
                            {
                                for (int i = startCol; i >= 0; i--)
                                {
                                    if (matrix[startRow, i] != '-')
                                    {
                                        branches.Push(matrix[startRow, i]);
                                        matrix[startRow, i] = '-';
                                    }
                                }
                                startCol = 0;
                                matrix[startRow, startCol] = 'B';
                                if (AreAllBranchesCollected(matrix))
                                {
                                    break;
                                }
                            }
                            else
                            {
                                for (int i = startCol; i < matrix.GetLength(1); i++)
                                {
                                    if (matrix[startRow, i] != '-')
                                    {
                                        branches.Push(matrix[startRow, i]);
                                        matrix[startRow, i] = '-';
                                    }
                                }
                                startCol = matrix.GetLength(1) - 1;
                                matrix[startRow, startCol] = 'B';
                                if (AreAllBranchesCollected(matrix))
                                {
                                    break;
                                }
                            }
                        }
                        else if (char.IsLetter(matrix[startRow, startCol + 1]) && matrix[startRow, startCol + 1] != 'F')
                        {
                            matrix[startRow, startCol] = '-';
                            startCol++;
                            branches.Push(matrix[startRow, startCol]);
                            matrix[startRow, startCol] = 'B';
                            if (AreAllBranchesCollected(matrix))
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (branches.Any())
                        {
                            branches.Pop();
                        }
                    }
                }
                direction = Console.ReadLine();
            }

            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] != '-' && matrix[row, col] != 'B' && matrix[row, col] != 'F')
                    {
                        counter++;
                    }
                }                
            }

            if (counter == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches.Reverse())}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {counter} branches left.");
            }

            Printer(matrix);


        }

        public static bool AreAllBranchesCollected(char[,] matrix)
        {
            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] != '-' && matrix[row, col] != 'B' && matrix[row, col] != 'F')
                    {
                        counter++;
                    }
                }
            }
            if (counter == 0)
            {
                return true;
            }
            return false;
        }

        public static bool IsValidCoordinates(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        public static void Printer(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }

        }
            
    }
}
