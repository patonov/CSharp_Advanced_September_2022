using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();
            Stack<string> archive = new Stack<string>();
            archive.Push(text.ToString());

            for (int i = 0; i < n; i++)
            {
                var commandArr = Console.ReadLine().Split().ToArray();
                string command = commandArr[0];


                if (command == "1")
                {
                    text.Append(commandArr[1]);
                    archive.Push(text.ToString());
                   
                }
                else if (command == "2")
                {
                    int number = int.Parse(commandArr[1]);
                    text.Remove(text.Length - number, number);
                    archive.Push(text.ToString());
                   
                }
                else if (command == "3")
                {
                    int index = int.Parse(commandArr[1]);
                    Console.WriteLine(text[index - 1]);
                   
                }
                else if (command == "4")
                {
                    archive.Pop();
                    text = new StringBuilder();
                    text.Append(archive.Peek());
                    
                }

                   
            }
        }
    }
}
