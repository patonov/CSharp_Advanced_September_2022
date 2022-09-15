using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFoodOrders
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> orders = new Queue<int>(input);

            Console.WriteLine(orders.Max());

            while (orders.Any())
            {
                int recentOrder = orders.Peek();

                if (recentOrder <= n)
                {
                    n -= recentOrder;
                    orders.Dequeue();
                    if (!orders.Any())
                    {
                        Console.WriteLine("Orders complete");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Orders left: {0}", string.Join(" ", orders));
                    break;
                }
            }
        }
    }
}
