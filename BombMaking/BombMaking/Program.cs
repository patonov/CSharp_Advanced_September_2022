using System;
using System.Linq;
using System.Collections.Generic;

namespace BombMaking
{
    class Program
    {
        static void Main(string[] args)
        {
            var effects = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var casing = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Queue<int> efectQueue = new Queue<int>(effects);
            Stack<int> casingStack = new Stack<int>(casing);

            Dictionary<string, int> made = new Dictionary<string, int>();
            made.Add("Datura Bombs", 0);
            made.Add("Cherry Bombs", 0);
            made.Add("Smoke Decoy Bombs", 0);

            while (efectQueue.Any() && casingStack.Any())
            {
                int interimEffect = efectQueue.Peek();
                int interimCasing = casingStack.Peek();
                int sum = interimEffect + interimCasing;

                if (sum == 40)
                {
                    made["Datura Bombs"]++;
                    efectQueue.Dequeue();
                    casingStack.Pop();
                }
                else if (sum == 60)
                {
                    made["Cherry Bombs"]++;
                    efectQueue.Dequeue();
                    casingStack.Pop();
                }
                else if (sum == 120)
                {
                    made["Smoke Decoy Bombs"]++;
                    efectQueue.Dequeue();
                    casingStack.Pop();
                }
                else
                {
                    interimCasing -= 5;
                    casingStack.Pop();
                    casingStack.Push(interimCasing);                   
                }
                if (made["Datura Bombs"] >= 3 && made["Cherry Bombs"] >= 3 && made["Smoke Decoy Bombs"] >= 3)
                {
                    break;
                }
            }

            var pouch = made.Where(x => x.Value >= 3).ToDictionary(x => x.Key, x => x.Value);

            if (pouch.Keys.Count == 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (efectQueue.Any())
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", efectQueue)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (casingStack.Any())
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casingStack)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var bomb in made.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }

        }
    }
}
