using System;
using System.Collections.Generic;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            double[][] jArr = new double[n][];

            for (int row = 0; row < n; row++)
            {
                double[] input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                jArr[row] = new double[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    jArr[row][col] = input[col];
                }
            }

            for (int row = 0; row < n - 1; row++)
            {
                if (jArr[row].Length == jArr[row + 1].Length)
                {
                    for (int currentRow = row; currentRow <= row + 1; currentRow++)
                    {
                        for (int col = 0; col < jArr[currentRow].Length; col++)
                        {
                            jArr[currentRow][col] *= 2;
                        }
                    }
                }
                else
                {
                    for (int currentRow = row; currentRow <= row + 1; currentRow++)
                    {
                        for (int col = 0; col < jArr[currentRow].Length; col++)
                        {
                            jArr[currentRow][col] /= 2;
                        }
                    }
                }
            }

            string command = Console.ReadLine();

            while (command.ToLower() != "end")
            {
                string[] comArr = command.Split();

                string task = comArr[0];
                int taskRow = int.Parse(comArr[1]);
                int taskCol = int.Parse(comArr[2]);
                double taskValue = double.Parse(comArr[3]);

                if (task.ToLower() == "add")
                {
                    if (taskRow >= 0 && taskRow < n && taskCol >= 0 && taskCol < jArr[taskRow].Length)
                    {
                        jArr[taskRow][taskCol] += taskValue;
                    }
                }
                else if (task.ToLower() == "subtract")
                {
                    if (taskRow >= 0 && taskRow < n && taskCol >= 0 && taskCol < jArr[taskRow].Length)
                    {
                        jArr[taskRow][taskCol] -= taskValue;
                    }
                }

                command = Console.ReadLine();
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < jArr[row].Length; col++)
                {
                    Console.Write(jArr[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
