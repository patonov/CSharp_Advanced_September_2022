using System;
using System.Collections.Generic;
using System.Linq;

namespace BaristaContest
{
    class Program
    {
        static void Main(string[] args)
        {
            var coffee = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var milk = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Queue<int> coffeeQueue = new Queue<int>(coffee);
            Stack<int> milkStack = new Stack<int>(milk);

            Dictionary<string, int> bevaragesMixed = new Dictionary<string, int>();

            while (coffeeQueue.Any() && milkStack.Any())
            {
                int interimCoffee = coffeeQueue.Dequeue();
                int interimMilk = milkStack.Pop();
                int sum = interimCoffee + interimMilk;

                if (sum == 50)
                {
                    if (bevaragesMixed.ContainsKey("Cortado"))
                    {
                        bevaragesMixed["Cortado"]++;
                    }
                    else
                    {
                        bevaragesMixed.Add("Cortado", 1);
                    }
                }
                else if (sum == 75)
                {
                    if (bevaragesMixed.ContainsKey("Espresso"))
                    {
                        bevaragesMixed["Espresso"]++;

                    }
                    else
                    {
                        bevaragesMixed.Add("Espresso", 1);
                    }
                }
                else if (sum == 100)
                {
                    if (bevaragesMixed.ContainsKey("Capuccino"))
                    {
                        bevaragesMixed["Capuccino"]++;
                    }
                    else
                    {
                        bevaragesMixed.Add("Capuccino", 1);
                    }
                }
                else if (sum == 150)
                {
                    if (bevaragesMixed.ContainsKey("Americano"))
                    {
                        bevaragesMixed["Americano"]++;
                    }
                    {
                        bevaragesMixed.Add("Americano", 1);
                    }
                }
                else if (sum == 200)
                {
                    if (bevaragesMixed.ContainsKey("Latte"))
                    {
                        bevaragesMixed["Latte"]++;
                    }
                    else
                    {
                        bevaragesMixed.Add("Latte", 1);
                    }
                }
                else
                {
                    int decreasedMilk = interimMilk -= 5;
                    milkStack.Push(decreasedMilk);
                }
            }

            if (coffeeQueue.Count == 0 && milkStack.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");               
            }

            if (coffeeQueue.Any())
            {
                Console.WriteLine("Coffee left: {0}", string.Join(", ", coffeeQueue));
            }
            else if (!coffeeQueue.Any())
            {
                Console.WriteLine("Coffee left: none");
            }

            if (milkStack.Any())
            {
                Console.WriteLine("Milk left: {0}", string.Join(" ", milkStack));
            }
            else if (!milkStack.Any())
            {
                Console.WriteLine("Milk left: none");
            }
               

            foreach (var bevarage in bevaragesMixed.OrderBy(b => b.Value).ThenByDescending(b => b.Key))
            {
                Console.WriteLine($"{bevarage.Key}: {bevarage.Value}");
            }



        }
    }
}
