using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(input[0].ToString());
            int m = int.Parse(input[2].ToString());

            List<string> coordinates = new List<string>();

            int[,] matrix = new int[n, m];

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = 0;
                }
            }

            while (true)
            {
                string places = Console.ReadLine();

                if (places == "Bloom Bloom Plow")
                {
                    break;
                }

                int row = int.Parse(places[0].ToString());
                int col = int.Parse(places[2].ToString());

                if (!AreCoordinatesValid(row, col, matrix))
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                else
                {
                    coordinates.Add(places);
                }
            }

            for (int i = 0; i < coordinates.Count; i++)
            {
                string currentPlace = coordinates[i];
                int row = int.Parse(currentPlace[0].ToString());
                int col = int.Parse(currentPlace[2].ToString());

                for (int a = 0; a < n; a++)
                {
                    matrix[a, col]++;
                }
                for (int b = 0; b < m; b++)
                {
                    matrix[row, b]++;
                }
                matrix[row, col]--;
            }//the loop ends here


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool AreCoordinatesValid(int row, int col, int[,] matrix)
        {
            if (row < 0 || row > matrix.GetLength(0) - 1 || col < 0 || col > matrix.GetLength(1) - 1)
            {
                return false;
            }
            return true;
        }
    }
}
