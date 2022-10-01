using System;
using System.Collections.Generic;
using System.Linq;


namespace TruffleHunter
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }


            Dictionary<string, int> truffls = new Dictionary<string, int>();
            truffls.Add("black", 0);
            truffls.Add("summer", 0);
            truffls.Add("white", 0);

            int boarTruflesEaten = 0;

            var command = Console.ReadLine();

            while (command != "Stop the hunt")
            {
                var comArr = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (comArr[0] == "Collect")
                {
                    int peterRow = int.Parse(comArr[1]);
                    int peterCol = int.Parse(comArr[2]);

                    if (matrix[peterRow, peterCol] == 'B')
                    {
                        truffls["black"]++;
                        matrix[peterRow, peterCol] = '-';
                    }
                    else if (matrix[peterRow, peterCol] == 'S')
                    {
                        truffls["summer"]++;
                        matrix[peterRow, peterCol] = '-';
                    }
                    else if (matrix[peterRow, peterCol] == 'W')
                    {
                        truffls["white"]++;
                        matrix[peterRow, peterCol] = '-';
                    }
                }
                else if (comArr[0] == "Wild_Boar")
                {
                    int startBoarRow = int.Parse(comArr[1]);
                    int startBoarCol = int.Parse(comArr[2]);
                    string direct = comArr[3];

                    if (direct == "up")
                    {
                        if (startBoarRow - 1 >= 0)
                        {
                            for (int i = startBoarRow; i >= 0; i--)
                            {
                                if (matrix[i, startBoarCol] == 'B' ||
                                    matrix[i, startBoarCol] == 'S' ||
                                    matrix[i, startBoarCol] == 'W')
                                {
                                    boarTruflesEaten++;
                                    matrix[i, startBoarCol] = '-';
                                }

                            }
                        }
                    }
                    else if (direct == "down")
                    {
                        if (startBoarRow + 1 < matrix.GetLength(0))
                        {
                            for (int i = startBoarRow; i < matrix.GetLength(0); i++)
                            {
                                if (matrix[i, startBoarCol] == 'B' ||
                                    matrix[i, startBoarCol] == 'S' ||
                                    matrix[i, startBoarCol] == 'W')
                                {
                                    boarTruflesEaten++;
                                    matrix[i, startBoarCol] = '-';
                                }

                            }
                        }
                    }
                    else if (direct == "left")
                    {
                        if (startBoarCol - 1 >= 0)
                        {
                            for (int i = startBoarCol; i >= 0; i--)
                            {
                                if (matrix[startBoarRow, i] == 'B' ||
                                    matrix[startBoarRow, i] == 'S' ||
                                    matrix[startBoarRow, i] == 'W')
                                {
                                    boarTruflesEaten++;
                                    matrix[startBoarRow, i] = '-';
                                }
                            }
                        }

                    }
                    else if (direct == "right")
                    {
                        if (startBoarCol + 1 < matrix.GetLength(1))
                        {
                            for (int i = startBoarCol; i < matrix.GetLength(1); i++)
                            {
                                if (matrix[startBoarRow, i] == 'B' ||
                                    matrix[startBoarRow, i] == 'S' ||
                                    matrix[startBoarRow, i] == 'W')
                                {
                                    boarTruflesEaten++;
                                    matrix[startBoarRow, i] = '-';
                                }
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Peter manages to harvest {truffls["black"]} black, {truffls["summer"]} summer, and {truffls["white"]} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarTruflesEaten} truffles.");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}