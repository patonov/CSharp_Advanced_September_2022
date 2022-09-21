using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> charStack = new Stack<char>(Console.ReadLine().ToCharArray());

            foreach(var ch in charStack) Console.Write(ch);
        }
    }
}
