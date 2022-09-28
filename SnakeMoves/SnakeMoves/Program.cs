using System;
using System.Linq;
using System.Collections.Generic;

namespace SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            Queue<char> snake = new Queue<char>(Console.ReadLine().ToCharArray());

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = snake.Peek();
                        snake.Enqueue(snake.Dequeue());
                    }
                }
                else
                {
                    for (int colReverse = matrix.GetLength(1) - 1; colReverse >= 0; colReverse--)
                    {
                        matrix[row, colReverse] = snake.Peek();
                        snake.Enqueue(snake.Dequeue());
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
