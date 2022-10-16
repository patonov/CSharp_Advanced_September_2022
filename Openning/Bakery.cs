using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;
        private string name;
        private int capacity;

        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Employee>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public bool Add(Employee employee)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(employee);
                return true;
            }
            return false;
        }

        public bool Remove(string name)
        {
            Employee emo = this.data.Where(x => x.Name == name).FirstOrDefault();
            if (emo != null)
            {
                return this.data.Remove(emo);                
            }
            else
            {
                return false;
            }
        }

        public Employee GetOldestEmployee()
        {
            return this.data.OrderByDescending(m => m.Age).First();
        }

        public Employee GetEmployee(string name)
        {
            return this.data.Find(x => x.Name == name);
        }

        public int Count => this.data.Count;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {this.Name}:");

            foreach (Employee e in this.data)
            {
                sb.AppendLine(e.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
