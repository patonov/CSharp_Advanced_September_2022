using System;
using System.Linq;
using System.Collections.Generic;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int intelligenceValueToBePaidForSex = int.Parse(Console.ReadLine());

            Stack<int> bulletsStack = new Stack<int>(bullets);
            Queue<int> locksQueue = new Queue<int>(locks);
            
            int bulletsCounter = 0;

            while (true)
            {
                if (!bulletsStack.Any() || !locksQueue.Any())
                {
                    break;
                }

                int currentBullet = bulletsStack.Pop();
                bulletsCounter++;


                int currentLock = locksQueue.Peek();

                if (currentBullet <= currentLock)
                {
                    locksQueue.Dequeue();
                    Console.WriteLine("Bang!");
                    
                }
                else
                {
                    Console.WriteLine("Ping!");
                    
                }

                if (bulletsStack.Any() && bulletsCounter % barrelSize == 0)
                {
                    Console.WriteLine("Reloading!");
                }
            }

            if (locksQueue.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
            else
            {
                int bulletsCost = bulletsCounter * bulletPrice;
                int finalEarning =  intelligenceValueToBePaidForSex - bulletsCost;
                Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${finalEarning}");
            }
        }
    }
}
