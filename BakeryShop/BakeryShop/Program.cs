using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace BakeryShop
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var water = Console.ReadLine().Split().Select(double.Parse).ToArray();
            var flour = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Queue<double> waterQueue = new Queue<double>(water);
            Stack<double> flourStack = new Stack<double>(flour);

            Dictionary<string, int> bakeryProducts = new Dictionary<string, int>();
            bakeryProducts.Add("Croissant", 0);
            bakeryProducts.Add("Muffin", 0);
            bakeryProducts.Add("Baguette", 0);
            bakeryProducts.Add("Bagel", 0);

            while (waterQueue.Any() && flourStack.Any())
            {
                double waterPiece = waterQueue.Dequeue();
                double flourPiece = flourStack.Pop();
                double sum = waterPiece + flourPiece;
                double ratio = waterPiece / sum * 100;

                if (ratio == 50)
                {
                    bakeryProducts["Croissant"]++;
                }
                else if (ratio == 40)
                {
                    bakeryProducts["Muffin"]++;
                }
                else if (ratio == 30)
                {
                    bakeryProducts["Baguette"]++;
                }
                else if (ratio == 20)
                {
                    bakeryProducts["Bagel"]++;
                }
                else
                {
                    bakeryProducts["Croissant"]++;
                    double restFlour = flourPiece - waterPiece;
                    flourStack.Push(restFlour);
                }
            }

            foreach (var b in bakeryProducts.OrderByDescending(a => a.Value).ThenBy(a => a.Key))
            {
                if (b.Value > 0)
                {
                    Console.WriteLine("{0}: {1}", b.Key, b.Value);
                }

            }

            if (waterQueue.Any())
            {
                Console.WriteLine("Water left: {0}", string.Join(", ", waterQueue));
            }
            else
            {
                Console.WriteLine("Water left: None");
            }

            if (flourStack.Any())
            {
                Console.WriteLine("Flour left: {0}", string.Join(", ", flourStack));
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }


        }
    }
}
