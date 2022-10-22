using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerArchitecture
{
    public class CPU
    {
        private string brand;
        private int cores;
        private double frequency;

        public CPU(string brand, int cores, double frequency)
        {
            this.Brand = brand;
            this.Cores = cores;
            this.Frequency = frequency;
        }

        public string Brand 
        {
            get => this.brand;
            set { this.brand = value; }
        }

        public int Cores 
            {
                get => this.cores;
                set { this.cores = value; }
            }
        

        public double Frequency
        {
            get => this.frequency;
            set { this.frequency = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine($"{this.Brand} CPU:");
            sb.AppendLine($"Cores: {this.Cores}");
            sb.AppendLine($"Frequency: {this.Frequency:f1} GHz");
            return sb.ToString().Trim();
        }

    }
}
