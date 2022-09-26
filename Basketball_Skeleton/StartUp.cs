using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Basketball
{
    public class StartUp
    {
        static void Main()
        {
            // Initialize the repository (Team)
            Team team = new Team("BHTC", 5, 'A');

            // Initialize entity
            Player firstPlayer = new Player("Viktor", "Center", 97.5, 10);

            // Print player
            Console.WriteLine(firstPlayer);
            /*
            -Player: Viktor
            --Position: Center
            --Rating: 97.5
            --Games played: 10
            */

            





        }
    }
}
