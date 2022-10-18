using System;
using System.Linq;
using System.Collections.Generic;

namespace FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {

            var roses = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var lillies = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Queue<int> rosesQueue = new Queue<int>(roses);
            Stack<int> lilliesStack = new Stack<int>(lillies);
            int wreathsCounter = 0;
            int flowersStored = 0;

            while (rosesQueue.Any() && lilliesStack.Any())
            {
                int currentRose = rosesQueue.Peek();
                int currentLillie = lilliesStack.Peek();
                int sum = currentLillie + currentRose;

                if (sum == 15)
                {
                    wreathsCounter++;
                    rosesQueue.Dequeue();
                    lilliesStack.Pop();
                }
                else if (sum > 15)
                {
                    lilliesStack.Pop();
                    currentLillie -= 2;
                    lilliesStack.Push(currentLillie);
                }
                else if (sum < 15)
                {
                    flowersStored += sum;
                    rosesQueue.Dequeue();
                    lilliesStack.Pop();
                }               

            }

            if (flowersStored >= 15)
            {
                int term = flowersStored / 15;
                wreathsCounter += term;
            }

            if (wreathsCounter >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathsCounter} wreaths!");
            }
            else
            {
                int term = 5 - wreathsCounter;
                Console.WriteLine($"You didn't make it, you need {term} wreaths more!");
            }

        }
    }
}
