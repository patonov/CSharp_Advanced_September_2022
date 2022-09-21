using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> ints = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            var input = Console.ReadLine().Split().ToArray();

            while (true)
            {
                string command = input[0].ToLower();

                if (command == "end")
                {
                    Console.WriteLine("Sum: {0}", ints.Sum());
                    break;
                }
                else if (command == "add")
                {
                    ints.Push(int.Parse(input[1]));
                    ints.Push(int.Parse(input[2]));
                }
                else if (command == "remove")
                {
                    int n = int.Parse(input[1]);
                    
                    if (ints.Count >= n)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            ints.Pop();
                        }                        
                    }                                    
                }

                input = Console.ReadLine().Split().ToArray();
            }
        }
    }
}
