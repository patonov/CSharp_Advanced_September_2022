using System;
using System.Collections.Generic;

namespace HashSetTest
{
    public class Person
    { 
    public string Name { get; set; }

    public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            HashSet<Person> people = new HashSet<Person>();
                       
            people.Add(new Person { Name = "Ivan", Age = 35 });
            people.Add(new Person { Name = "Ivan", Age = 35 });
            people.Add(new Person { Name = "Ivan", Age = 35 });

            Console.WriteLine(people.Count);

            //Yes, there are three Persons with Name "Ivan" and Age 35 in the HashSet!
        }
    }
}
