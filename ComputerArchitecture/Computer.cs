using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        private List<CPU> multiprocessor;
        private string model;
        private int capacity;

        public Computer(string model, int capacity)
        {
            this.Model = model;
            this.Capacity = capacity;
            this.multiprocessor = new List<CPU>();
        }

        public string Model
        {
            get => this.model;
            set { this.model = value; }
        }

        public int Capacity
        {
            get => this.capacity;
            set { this.capacity = value; }
        }

        public List<CPU> Multiprocessor => this.multiprocessor;

        public int Count => this.multiprocessor.Count;

        public void Add(CPU cpu)
        {
            if (this.multiprocessor.Count < this.Capacity)
            {
                this.multiprocessor.Add(cpu);
            }        
        }

        public bool Remove(string brand)
        {
            CPU target = this.multiprocessor.Find(x => x.Brand == brand);
            if (target != null)
            {
                this.multiprocessor.Remove(target);
                return true;
            }
            else
            {
                return false;
            }
        }

        public CPU MostPowerful()
        {
            return this.multiprocessor.OrderByDescending(x => x.Frequency).First();
        }

        public CPU GetCPU(string brand)
        {
            return this.multiprocessor.Find(x => x.Brand == brand);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CPUs in the Computer {model}:");
            foreach (CPU cpu in this.multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
