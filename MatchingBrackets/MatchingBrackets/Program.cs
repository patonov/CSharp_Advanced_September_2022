using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> indices = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    indices.Push(i);
                }
                else if (input[i] == ')')
                {
                    var interim = indices.Pop();
                    Console.WriteLine(input.Substring(interim, i - interim + 1));                
                }
            }
        }
    }
}
