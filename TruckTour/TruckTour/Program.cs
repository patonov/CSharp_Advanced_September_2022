using System;
using System.Linq;
using System.Collections.Generic;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<KeyValuePair<int, int>> queue = new Queue<KeyValuePair<int, int>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int petrol = input[0];
                int distance = input[1];
                KeyValuePair<int, int> kvp = new KeyValuePair<int, int>(petrol, distance);
                queue.Enqueue(kvp);
            }           

            for (int i = 0; i < n; i++)
            {
                int fuel = 0;
                bool isPossible = true;

                for (int j = 0; j < n; j++)
                {
                    var elem = queue.Dequeue();

                    fuel += elem.Key;
                    fuel -= elem.Value;

                    if (fuel < 0)
                    {
                        isPossible = false;
                    }

                    queue.Enqueue(elem);
                }

                if (isPossible == true)
                {
                    Console.WriteLine(i);
                    break;
                }
                queue.Enqueue(queue.Dequeue());
            }
            
            
        }
    }
}
