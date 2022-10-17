using System;
using System.Collections.Generic;
using System.Linq;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();

            Tuple<string> stringTuple = new Tuple<string>(input[0] + " " + input[1], input[2]);

            string[] beer = Console.ReadLine().Split().ToArray();
           
            Tuple<string> beerTuple = new Tuple<string>(beer[0], beer[1]);

            double[] doubleInput = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Tuple<double> doubleTuple = new Tuple<double>(doubleInput[0], doubleInput[1]);

            Console.WriteLine(stringTuple);
            Console.WriteLine(beerTuple);
            Console.WriteLine(doubleTuple);

        }
    }
}
