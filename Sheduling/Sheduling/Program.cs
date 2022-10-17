using System;
using System.Collections.Generic;
using System.Linq;

namespace Sheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasks = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var threads = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int targetTask = int.Parse(Console.ReadLine());

            Stack<int> taskStack = new Stack<int>(tasks);
            Queue<int> threadQueue = new Queue<int>(threads);


			while (true)
			{

				int currentTask = taskStack.Peek();
				int currentThread = threadQueue.Peek();
				if (currentTask == targetTask)
				{
					Console.WriteLine("Thread with value {0} killed task {1}", currentThread, targetTask);
					break;
				}

				if (currentThread >= currentTask)
				{
					taskStack.Pop();
					threadQueue.Dequeue();
				}
				else
				{
					threadQueue.Dequeue();
				}
			}
			Console.WriteLine(string.Join(" ", threadQueue));

        }
    }
}
