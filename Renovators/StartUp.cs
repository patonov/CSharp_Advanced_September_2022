using System;
using System.Collections.Generic;

namespace Renovators
{
    public class StartUp
    {
        static void Main()
        {
            List<string> brrr = new List<string>() { "putka", "putka", "putka", "kur", "biski" };

            Console.WriteLine(brrr.RemoveAll(p => p == "putka"));

        }
    }
}
