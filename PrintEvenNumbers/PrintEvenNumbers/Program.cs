using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", new Queue<int>(Console.ReadLine().Split()
                                                                                 .Select(int.Parse)
                                                                                 .Where(n => n % 2 == 0).ToArray())));
        }
    }
}
