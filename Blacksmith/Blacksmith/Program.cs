using System;
using System.Linq;
using System.Collections.Generic;

namespace Blacksmith
{
    class Program
    {
        static void Main(string[] args)
        {
            var steel = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var carbon = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> steelQueue = new Queue<int>(steel);
            Stack<int> carbonStack = new Stack<int>(carbon);

            Dictionary<string, int> forged = new Dictionary<string, int>();
            forged.Add("Gladius", 0);
            forged.Add("Shamshir", 0);
            forged.Add("Katana", 0);
            forged.Add("Sabre", 0);
            forged.Add("Broadsword", 0);

            int swordCounter = 0;

            while (steelQueue.Any() && carbonStack.Any())
            {
                int interimSteel = steelQueue.Dequeue();
                int interimCarbon = carbonStack.Pop();
                int sum = interimSteel + interimCarbon;

                if (sum == 70)
                {
                    forged["Gladius"]++;
                    swordCounter++;
                }
                else if (sum == 80)
                {
                    forged["Shamshir"]++;
                    swordCounter++;
                }
                else if (sum == 90)
                {
                    forged["Katana"]++;
                    swordCounter++;
                }
                else if (sum == 110)
                {
                    forged["Sabre"]++;
                    swordCounter++;
                }
                else if (sum == 150)
                {
                    forged["Broadsword"]++;
                    swordCounter++;
                }
                else
                {
                    interimCarbon += 5;
                    carbonStack.Push(interimCarbon);
                }
                // the cycle breaks here.
            }

            if (swordCounter > 0)
            {
                Console.WriteLine($"You have forged {swordCounter} swords.");
            }
            else 
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (steelQueue.Any())
            {
                Console.WriteLine("Steel left: {0}", string.Join(", ", steelQueue));
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }

            if (carbonStack.Any())
            {
                Console.WriteLine("Carbon left: {0}", string.Join(", ", carbonStack));
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            foreach (var f in forged.Where(f => f.Value > 0).OrderBy(f => f.Key))
            {
                Console.WriteLine($"{f.Key}: {f.Value}");
            }

        }
    }
}
