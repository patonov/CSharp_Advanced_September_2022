using System;
using System.Linq;
using System.Collections.Generic;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            var liquids = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var ingredients = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> liquidQueue = new Queue<int>(liquids);
            Stack<int> ingredStack = new Stack<int>(ingredients);

            Dictionary<string, int> products = new Dictionary<string, int>();
            products.Add("Bread", 0);
            products.Add("Cake", 0);
            products.Add("Pastry", 0);
            products.Add("Fruit Pie", 0);

            while (liquidQueue.Any() && ingredStack.Any())
            {
                int liquidPiece = liquidQueue.Dequeue();
                int ingredPiece = ingredStack.Pop();
                int sum = ingredPiece + liquidPiece;

                if (sum == 25)
                {
                    products["Bread"]++;
                }
                else if (sum == 50)
                {
                    products["Cake"]++;
                }
                else if (sum == 75)
                {
                    products["Pastry"]++;
                }
                else if (sum == 100)
                {
                    products["Fruit Pie"]++;
                }
                else
                {
                    ingredPiece += 3;
                    ingredStack.Push(ingredPiece);
                }
            }
            int term = products.Where(p => p.Value > 0).Count();

            if (term == 4)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquidQueue.Any())
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquidQueue)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredStack.Any())
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredStack)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }
            
            foreach (var product in products.OrderBy(p => p.Key))
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }

        }
    }
}
