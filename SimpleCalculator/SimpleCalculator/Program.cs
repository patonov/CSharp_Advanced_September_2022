using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Stack<string> startArray = new Stack<string>(Console.ReadLine().Split(" ").Reverse().ToArray());

            while (startArray.Count > 1)
            {
                int first = int.Parse(startArray.Pop());
                string sign = startArray.Pop();
                int second = int.Parse(startArray.Pop());
                
                if (sign == "+")
                {
                    first += second;
                    startArray.Push(first.ToString());
                }
                else if (sign == "-")
                {
                    first -= second;
                    startArray.Push(first.ToString());
                }

            }
            Console.WriteLine(startArray.Peek());
        }
    }
}
