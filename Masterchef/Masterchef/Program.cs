using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            var ingredients = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var freshness = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> ingredientQueue = new Queue<int>(ingredients);
            Stack<int> freshnessStack = new Stack<int>(freshness);

            Dictionary<string, int> dishes = new Dictionary<string, int>();
            dishes.Add("Dipping sauce", 0);
            dishes.Add("Green salad", 0);
            dishes.Add("Chocolate cake", 0);
            dishes.Add("Lobster", 0);

            while (ingredientQueue.Any() && freshnessStack.Any())
            {
                int interimIngredient = ingredientQueue.Dequeue();

                if (interimIngredient == 0)
                {
                    continue;
                }

                int interimFresh = freshnessStack.Pop();
                int sum = interimFresh * interimIngredient;

                if (sum == 150)
                {
                    dishes["Dipping sauce"]++;                    
                }
                else if (sum == 250)
                {
                    dishes["Green salad"]++;                   
                }
                else if (sum == 300)
                {
                    dishes["Chocolate cake"]++;
                }
                else if (sum == 400)
                {
                    dishes["Lobster"]++;                    
                }
                else
                {
                    interimIngredient += 5;
                    ingredientQueue.Enqueue(interimIngredient);
                }
            }

            int counter = 0;
            foreach (var d in dishes)
            {
                if (d.Value > 0)
                {
                    counter++;
                }
            }
            if (counter == 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");                
            }

            if (ingredientQueue.Sum() > 0)
            {
                Console.WriteLine("Ingredients left: {0}", ingredientQueue.Sum());
            }

            foreach (var dish in dishes.OrderBy(x => x.Key))
            {
                if (dish.Value > 0)
                {
                    Console.WriteLine($" # {dish.Key} --> {dish.Value}");
                }
            }
        }
    }
}
