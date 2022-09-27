using System;
using System.Linq;
using System.Collections.Generic;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            int firstDiagonalSum = 0;
            int secondDiagonalSum = 0;
            int counter = n - 1;

            for (int i = 0; i < n; i++)
            {         
                    firstDiagonalSum += matrix[i, i];
                    secondDiagonalSum += matrix[i, counter];
                    counter--;
                
            }

            
            Console.WriteLine(Math.Abs(firstDiagonalSum));
            Console.WriteLine(Math.Abs(secondDiagonalSum));
            Console.WriteLine(Math.Abs(firstDiagonalSum - secondDiagonalSum));
        }
    }
}
