using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var intArrToManupolite = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> intQue = new Queue<int>();

            int n = input[0];

            int s = input[1];

            int x = input[2];

            for (int i = 0; i < n; i++)
            {
                intQue.Enqueue(intArrToManupolite[i]);
            }

            for (int i = 0; i < s; i++)
            {
                intQue.Dequeue();
            }

            int[] derivative = intQue.ToArray();

            if (derivative.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                int minValue = int.MaxValue;

                if (!derivative.Any())
                {
                    Console.WriteLine("0");
                }
                else
                {
                    foreach (int item in derivative)
                    {
                        if (item < minValue)
                        {
                            minValue = item;
                        }
                    }
                    Console.WriteLine(minValue);
                }
            }
        }
    }
}
