using System;
using System.Linq;
using System.Collections.Generic;

namespace BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();

            if (!input.Any())
            {
                return;
            }

            Stack<char> stack = new Stack<char>();
            
            foreach (char ch in input)
            {
                if (stack.Any())
                {
                    var currentChar = stack.Peek();

                    if (currentChar == '{' && ch == '}')
                    {
                        stack.Pop();
                        continue;
                    }
                    else if (currentChar == '(' && ch == ')')
                    {
                        stack.Pop();
                        continue;
                    }
                    else if (currentChar == '[' && ch == ']')
                    {
                        stack.Pop();
                        continue;
                    }
                    else if (currentChar == ' ' && ch == ' ')
                    {
                        stack.Pop();
                        continue;
                    }
                }
                stack.Push(ch);
            }

            Console.WriteLine(stack.Any()? "NO": "YES");
            
        }
    }
}
