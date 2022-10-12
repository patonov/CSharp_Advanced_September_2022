using System;
using System.Linq;
using System.Collections.Generic;

namespace Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
                

            char[][] matrix = new char[n][];

            for (int row = 0; row < n; row++)
            {
                var line = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
                matrix[row] = line;
            }

            int ourTokens = 0;
            int oponentTokens = 0;

            string input = Console.ReadLine();

            while (input != "Gong")
            {
                var command = input.Split().ToArray();

                string com = command[0];

                if (com == "Find")
                {
                    int ourRow = int.Parse(command[1]);
                    int ourCol = int.Parse(command[2]);

                    if (AreCoordinatesValid(ourRow, ourCol, matrix))
                    {
                        if (matrix[ourRow][ourCol] == 'T')
                        {
                            ourTokens++;
                            matrix[ourRow][ourCol] = '-';
                        }                    
                    }
                }
                else if (com == "Opponent")
                {
                    int oponentRow = int.Parse(command[1]);
                    int oponentCol = int.Parse(command[2]);
                    string move = command[3];

                    if (AreCoordinatesValid(oponentRow, oponentCol, matrix))
                    {
                        if (matrix[oponentRow][oponentCol] == 'T')
                        {
                            oponentTokens++;
                            matrix[oponentRow][oponentCol] = '-';
                        }
                    }

                    if (move == "up")
                    {                      
                        if (AreCoordinatesValid(oponentRow - 1, oponentCol, matrix))
                        {
                            if (matrix[oponentRow - 1][oponentCol] == 'T')
                            {
                                oponentTokens++;
                                matrix[oponentRow - 1][oponentCol] = '-';
                            }
                        }
                        if (AreCoordinatesValid(oponentRow - 2, oponentCol, matrix))
                        {
                            if (matrix[oponentRow - 2][oponentCol] == 'T')
                            {
                                oponentTokens++;
                                matrix[oponentRow - 2][oponentCol] = '-';
                            }
                        }
                        if (AreCoordinatesValid(oponentRow - 3, oponentCol, matrix))
                        {
                            if (matrix[oponentRow - 3][oponentCol] == 'T')
                            {
                                oponentTokens++;
                                matrix[oponentRow - 3][oponentCol] = '-';
                            }
                        }

                    }
                    else if (move == "down")
                    {
                        if (AreCoordinatesValid(oponentRow + 1, oponentCol, matrix))
                        {
                            if (matrix[oponentRow + 1][oponentCol] == 'T')
                            {
                                oponentTokens++;
                                matrix[oponentRow + 1][oponentCol] = '-';
                            }
                        }
                        if (AreCoordinatesValid(oponentRow + 2, oponentCol, matrix))
                        {
                            if (matrix[oponentRow + 2][oponentCol] == 'T')
                            {
                                oponentTokens++;
                                matrix[oponentRow + 2][oponentCol] = '-';
                            }
                        }
                        if (AreCoordinatesValid(oponentRow + 3, oponentCol, matrix))
                        {
                            if (matrix[oponentRow + 3][oponentCol] == 'T')
                            {
                                oponentTokens++;
                                matrix[oponentRow + 3][oponentCol] = '-';
                            }
                        }
                    }
                    else if (move == "left")
                    {
                        if (AreCoordinatesValid(oponentRow, oponentCol - 1, matrix))
                        {
                            if (matrix[oponentRow][oponentCol - 1] == 'T')
                            {
                                oponentTokens++;
                                matrix[oponentRow][oponentCol - 1] = '-';
                            }
                        }
                        if (AreCoordinatesValid(oponentRow, oponentCol - 2, matrix))
                        {
                            if (matrix[oponentRow][oponentCol - 2] == 'T')
                            {
                                oponentTokens++;
                                matrix[oponentRow][oponentCol - 2] = '-';
                            }
                        }
                        if (AreCoordinatesValid(oponentRow, oponentCol - 3, matrix))
                        {
                            if (matrix[oponentRow][oponentCol - 3] == 'T')
                            {
                                oponentTokens++;
                                matrix[oponentRow][oponentCol - 3] = '-';
                            }
                        }
                    }
                    else if (move == "right")
                    {
                        if (AreCoordinatesValid(oponentRow, oponentCol + 1, matrix))
                        {
                            if (matrix[oponentRow][oponentCol + 1] == 'T')
                            {
                                oponentTokens++;
                                matrix[oponentRow][oponentCol + 1] = '-';
                            }
                        }
                        if (AreCoordinatesValid(oponentRow, oponentCol + 2, matrix))
                        {
                            if (matrix[oponentRow][oponentCol + 2] == 'T')
                            {
                                oponentTokens++;
                                matrix[oponentRow][oponentCol + 2] = '-';
                            }
                        }
                        if (AreCoordinatesValid(oponentRow, oponentCol + 3, matrix))
                        {
                            if (matrix[oponentRow][oponentCol + 3] == 'T')
                            {
                                oponentTokens++;
                                matrix[oponentRow][oponentCol + 3] = '-';
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            } // the cycle ends here!

            MatrixPrinter(matrix);

            Console.WriteLine($"Collected tokens: {ourTokens}");
            Console.WriteLine($"Opponent's tokens: {oponentTokens}");
            
        }

        public static void MatrixPrinter(char[][] matrix)
        {
            foreach (var line in matrix)
            {
                var currentLine = string.Join(' ', line);
                Console.WriteLine(currentLine);
            }
        }

        public static bool AreCoordinatesValid(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length;
        }


    }
}
