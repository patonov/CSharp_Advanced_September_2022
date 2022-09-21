using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            int counter = 0;

            string input = Console.ReadLine();

            while (true)
            {
                if (input == "END")
                {
                    Console.WriteLine("Everyone is safe.");
                    Console.WriteLine($"{counter} total cars passed the crossroads.");
                    return;
                }
                
                int interimGreenLight = greenLight;
                int interimFreeWindow = freeWindow;

                if (input == "green")
                {
                    while (interimGreenLight > 0 && cars.Any())
                    {
                        string car = cars.Dequeue();
                        interimGreenLight -= car.Length;
                        if (interimGreenLight >= 0)
                        {
                            counter++;
                        }
                        else
                        {
                            interimFreeWindow += interimGreenLight;
                            if (interimFreeWindow < 0)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{car} was hit at {car[car.Length + interimFreeWindow]}.");
                                return;
                            }
                            else
                            {
                                counter++;
                            }
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }
        }
    }
}
