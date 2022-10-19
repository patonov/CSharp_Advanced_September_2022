using System;
using System.Linq;
using System.Collections.Generic;

namespace ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] personProperties = command.Split().ToArray();

                Person person = new Person
                {
                    Name = personProperties[0],
                    Age = int.Parse(personProperties[1]),
                    Town = personProperties[2]
                };

                people.Add(person);
            }

            int compereIndex = int.Parse(Console.ReadLine()) - 1;

            Person personToCompare = people[compereIndex];

            int equalCount = 0;
            int diffCount = 0;

            foreach (var person in people)
            {
                if (person.CompareTo(personToCompare) == 0)
                {
                    equalCount++;
                }
                else
                {
                    diffCount++;
                }            
            }

            if (equalCount == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalCount} {diffCount} {people.Count}");
            }

        }
    }
}
