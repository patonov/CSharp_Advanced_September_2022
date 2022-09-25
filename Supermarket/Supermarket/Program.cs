using System;
using System.Linq;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> initial = new Queue<string>();

            string name = Console.ReadLine();

            while (name != "End")
            {                

                if (name != "Paid")
                {
                    initial.Enqueue(name);
                }
                else if (name == "Paid")
                {
                    while (initial.Any())
                    {
                        string current = initial.Dequeue();
                        Console.WriteLine(current);
                    }
                }

                name = Console.ReadLine();
            }

            
                Console.WriteLine("{0} people remaining.", initial.Count);
                
            
        }
    }
}
