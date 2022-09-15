using System;
using System.Collections.Generic;
using System.Linq;

namespace StackMaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Stack<int> intStack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (input[0] == 1)
                {
                    intStack.Push(input[1]);
                }
                else if (input[0] == 2 && intStack.Any())
                {
                    intStack.Pop();
                }
                else if (input[0] == 3 && intStack.Any())
                {
                    Console.WriteLine(intStack.Max());
                }
                else if (input[0] == 4 && intStack.Any())
                {
                    Console.WriteLine(intStack.Min());
                }
            }
            if (intStack.Any())
            {
                var stackArr = intStack.ToArray();

                for (int i = 0; i < stackArr.Length; i++)
                {
                    if (i != stackArr.Length - 1)
                    {
                        Console.Write(stackArr[i]);
                        Console.Write(", ");
                    }
                    else
                    {
                        Console.Write(stackArr[i]);
                    }
                }
            }
            
        }
    }
}
