using System;

namespace ComputerArchitecture
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            // Initialize entity
            CPU cpu = new CPU("AMD", 6, 3.4);

            // Print CPU
            Console.WriteLine(cpu.ToString());
            // AMD Ryzen 5 CPU:
            // Cores: 6
            // Frequency: 3.7 GHz

        }
    }
}
