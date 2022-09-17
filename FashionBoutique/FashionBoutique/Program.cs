using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> cloths = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int rackCapacity = int.Parse(Console.ReadLine());

            int rackCounter = 1;
            int rackFillingSum = 0;

            while (cloths.Any())
            {
                int currentCloth = cloths.Peek();

                if (rackFillingSum + currentCloth <= rackCapacity)
                {
                    rackFillingSum += currentCloth;
                    cloths.Pop();
                }
                else
                {
                    rackCounter++;
                    rackFillingSum = 0;
                }
            
            }

            Console.WriteLine(rackCounter);
        }
    }
}
