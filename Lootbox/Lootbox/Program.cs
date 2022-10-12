using System;
using System.Linq;
using System.Collections.Generic;

namespace Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstBox = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var secondBox = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> firstBoxQueue = new Queue<int>(firstBox);
            Stack<int> secondBoxStack = new Stack<int>(secondBox);

            List<int> resultCollection = new List<int>();

            while (firstBoxQueue.Any() && secondBoxStack.Any())
            {
                int interimFirstBox = firstBoxQueue.Peek();
                int interimSecondBox = secondBoxStack.Peek();
                int sum = interimFirstBox + interimSecondBox;

                if (sum % 2 == 0)
                {
                    resultCollection.Add(sum);
                    firstBoxQueue.Dequeue();
                    secondBoxStack.Pop();
                }
                else
                {
                    int term = secondBoxStack.Pop();
                    firstBoxQueue.Enqueue(term);
                }
            }
            
            if (!firstBoxQueue.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }

            if (!secondBoxStack.Any())
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (resultCollection.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {resultCollection.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {resultCollection.Sum()}");
            }

        }
    }
}
