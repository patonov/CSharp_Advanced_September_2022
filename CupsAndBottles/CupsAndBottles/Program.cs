using System;
using System.Linq;
using System.Collections.Generic;

namespace CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputCups = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] inputBottles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> cups = new Queue<int>(inputCups);
            Stack<int> bottles = new Stack<int>(inputBottles);
            int waste = 0;
            
            while (cups.Any() && bottles.Any())
            {
                int currentCub = cups.Peek();
                int currentBottle = bottles.Pop();

                if (currentCub > currentBottle)
                {                    
                    currentCub -= currentBottle;
                    cups.Dequeue();
                    var oooooo = cups.Reverse().ToArray();
                    cups = new Queue<int>(oooooo);
                    cups.Enqueue(currentCub);
                    var eeeeeeeeee = cups.Reverse().ToArray();
                    cups = new Queue<int>(eeeeeeeeee);
                }
                else if (currentCub <= currentBottle)
                {
                    cups.Dequeue();
                    currentBottle -= currentCub;
                    waste += currentBottle;
                }           
            }

            if (bottles.Any())
            {
                Console.WriteLine("Bottles: {0}", string.Join(" ", bottles));
                Console.WriteLine("Wasted litters of water: {0}", waste);
            }
            else if (cups.Any())
            {
                Console.WriteLine("Cups: {0}", string.Join(" ", cups));
                Console.WriteLine("Wasted litters of water: {0}", waste);
            }
        }
    }
}
