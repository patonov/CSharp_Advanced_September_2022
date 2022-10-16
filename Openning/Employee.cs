using System;
using System.Collections.Generic;
using System.Text;

namespace BakeryOpenning
{
    public class Employee
    {
        private string name;
        private int age;
        private string country;

        public Employee(string name, int age, string country ) 
        {
            this.Name = name;
            this.Age = age;
            this.Country = country;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return $"Employee: {this.Name}, {this.Age} ({this.Country})";
        }

    }
}
