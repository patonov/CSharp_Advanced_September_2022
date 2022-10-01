using System;
using System.Linq;
using System.Collections.Generic;

namespace MealPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            var meals = Console.ReadLine().Split().ToArray();
            var calories = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<string> dailyMeals = new Queue<string>(meals);
            Stack<int> dailyCalories = new Stack<int>(calories);
            int mealsCounter = 0;
            
            while (dailyMeals.Any() && dailyCalories.Any())
            {
                string currentMeal = dailyMeals.Dequeue();
                mealsCounter++;
                int todaysCalories = dailyCalories.Pop();

                if (currentMeal == "salad")
                {
                    todaysCalories -= 350;
                }
                else if (currentMeal == "soup")
                {
                    todaysCalories -= 490;
                }
                else if (currentMeal == "pasta")
                {
                    todaysCalories -= 680;
                }
                else if (currentMeal == "steak")
                {
                    todaysCalories -= 790;
                }

                if (todaysCalories > 0)
                {
                    dailyCalories.Push(todaysCalories);
                }
                else if (todaysCalories < 0)
                {
                    if (dailyCalories.Any())
                    {
                        int nextDayCalories = dailyCalories.Pop();
                        nextDayCalories += todaysCalories;
                        dailyCalories.Push(nextDayCalories);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (dailyCalories.Any())
            {
                Console.WriteLine($"John had {mealsCounter} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", dailyCalories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealsCounter} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", dailyMeals)}.");
            }
        }
    }
}
