using System;
using System.Linq;
using System.Collections.Generic;

namespace EnergyDrinks
{
    class Program
    {
        static void Main(string[] args)
        {
            var cafeine = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var drinks = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Queue<int> drinksQueue = new Queue<int>(drinks);
            Stack<int> cafeineStack = new Stack<int>(cafeine);

            int StamatCafeine = 300;

            while (drinksQueue.Any() && cafeineStack.Any())
            {

                int interimDrink = drinksQueue.Peek();
                int interimCafeine = cafeineStack.Peek();
                int sum = interimDrink * interimCafeine;

                if (sum <= StamatCafeine)
                {
                    drinksQueue.Dequeue();
                    cafeineStack.Pop();
                    StamatCafeine -= sum;
                }
                else
                {
                    cafeineStack.Pop();
                    drinksQueue.Enqueue(drinksQueue.Dequeue());
                    StamatCafeine += 30;
                }

            }

            if (drinksQueue.Any())
            {
                Console.WriteLine("Drinks left: {0}", string.Join(", ", drinksQueue));
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }
            Console.WriteLine("Stamat is going to sleep with {0} mg caffeine.", 300 - StamatCafeine);
        }
    }
}