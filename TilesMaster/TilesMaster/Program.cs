using System;
using System.Linq;
using System.Collections.Generic;

namespace TilesMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            var white = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var grey = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> whiteTileStack = new Stack<int>(white);
            Queue<int> greyTileQueue = new Queue<int>(grey);

            Dictionary<string, int> areas = new Dictionary<string, int>();
            areas.Add("Sink", 0);
            areas.Add("Oven", 0);
            areas.Add("Countertop", 0);
            areas.Add("Wall", 0);
            areas.Add("Floor", 0);

            while (whiteTileStack.Any() && greyTileQueue.Any())
            {
                int whiteTile = whiteTileStack.Pop();
                int greyTile = greyTileQueue.Dequeue();

                if (whiteTile == greyTile)
                {
                    int sum = whiteTile + greyTile;
                    if (sum == 40)
                    {
                        areas["Sink"]++;
                    }
                    else if (sum == 50)
                    {
                        areas["Oven"]++;
                    }
                    else if (sum == 60)
                    {
                        areas["Countertop"]++;
                    }
                    else if (sum == 70)
                    {
                        areas["Wall"]++;
                    }
                    else
                    {
                        areas["Floor"]++;
                    }
                }
                else
                {
                    whiteTile /= 2;
                    whiteTileStack.Push(whiteTile);
                    greyTileQueue.Enqueue(greyTile);
                }           
            //here the cycle ends.
            }

            if (whiteTileStack.Any())
            {
                Console.WriteLine("White tiles left: {0}", string.Join(", ", whiteTileStack));
            }
            else
            {
                Console.WriteLine("White tiles left: none");
            }

            if (greyTileQueue.Any())
            {
                Console.WriteLine("Grey tiles left: {0}", string.Join(", ", greyTileQueue));
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }

            foreach (var t in areas.OrderByDescending(a => a.Value).ThenBy(a => a.Key))
            {
                if (t.Value > 0)
                {
                    Console.WriteLine("{0}: {1}", t.Key, t.Value);
                }
            
            }


        }
    }
}
