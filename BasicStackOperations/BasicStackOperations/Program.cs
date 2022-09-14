using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var intArrToManupolite = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> intStack = new Stack<int>();

            int n = input[0];

            int s = input[1];

            int x = input[2];

            for (int i = 0; i < n; i++)
            {
                intStack.Push(intArrToManupolite[i]);
            }

            for (int i = 0; i < s; i++)
            {
               intStack.Pop();
            }

            int[] derivative = intStack.ToArray();

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
