using System;
using System.Collections.Generic;

namespace FishingNet
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> nnnn = new List<string>() { "rrr", "rrr", "rrr", "aaa", "aaa"};
            int a = nnnn.RemoveAll(n => n == "ccc");

            Console.WriteLine(a);
        }
    }
}
