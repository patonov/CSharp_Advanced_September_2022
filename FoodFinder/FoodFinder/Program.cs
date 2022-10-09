using System;
using System.Linq;
using System.Collections.Generic;

namespace FoodFinder
{
    class Program
    {
        static void Main(string[] args)
        {            
            var vowels = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            var consonants = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
                        
            Queue<char> vows = new Queue<char>(vowels);
            Stack<char> cons = new Stack<char>(consonants);

            string pear = "pear";
            string flour = "flour";
            string pork = "pork";
            string olive = "olive";

            List<string> list = new List<string>();


            for (int i = 0; i < consonants.Length; i++)
            {
                var firstVow = vows.Dequeue();
                var lastCon = cons.Pop();

                if (pear.Length > 0 && pear.Contains(firstVow) || pear.Length > 0 && pear.Contains(lastCon))
                {
                    if (pear.Contains(firstVow))
                    {
                        pear = pear.Replace(firstVow, ' ');
                        var temp = pear.Split(' ').ToArray();
                        pear = string.Join("", temp);
                    }
                    if (pear.Contains(lastCon))
                    {
                        pear = pear.Replace(lastCon, ' ');
                        var temp = pear.Split(' ').ToArray();
                        pear = string.Join("", temp);
                    }
                    
                }

                if (flour.Length > 0 && flour.Contains(firstVow) || flour.Length > 0 && flour.Contains(lastCon))
                {
                    if (flour.Contains(firstVow))
                    {
                        flour = flour.Replace(firstVow, ' ');
                        var temp = flour.Split(' ').ToArray();
                        flour = string.Join("", temp);
                    }
                    if (flour.Contains(lastCon))
                    {
                        flour = flour.Replace(lastCon, ' ');
                        var temp = flour.Split(' ').ToArray();
                        flour = string.Join("", temp);
                    }
                    
                }

                if (pork.Length > 0 && pork.Contains(firstVow) || pork.Length > 0 && pork.Contains(lastCon))
                {
                    if (pork.Contains(firstVow))
                    {
                        pork = pork.Replace(firstVow, ' ');
                        var temp = pork.Split(' ').ToArray();
                        pork = string.Join("", temp);
                    }
                    if (pork.Contains(lastCon))
                    {
                        pork = pork.Replace(lastCon, ' ');
                        var temp = pork.Split(' ').ToArray();
                        pork = string.Join("", temp);
                    }                    
                }

                if (olive.Length > 0 && olive.Contains(firstVow) || olive.Length > 0 && olive.Contains(lastCon))
                {
                    if (olive.Contains(firstVow))
                    {
                        olive = olive.Replace(firstVow, ' ');
                        var temp = olive.Split(' ').ToArray();
                        olive = string.Join("", temp);
                    }
                    if (olive.Contains(lastCon))
                    {
                        olive = olive.Replace(lastCon, ' ');
                        var temp = olive.Split(' ').ToArray();
                        olive = string.Join("", temp);
                    }
                    
                }

                vows.Enqueue(firstVow);
            }

            if (pear.Length == 0)
            {
                list.Add("pear");
            }
            if (flour.Length == 0)
            {
                list.Add("flour");
            }
            if (pork.Length == 0)
            {
                list.Add("pork");
            }
            if (olive.Length == 0)
            {
                list.Add("olive");
            }

            Console.WriteLine($"Words found: {list.Count}");
            
            foreach (string l in list)
            {
                Console.WriteLine(l);
            }
            
        }
    }
}
