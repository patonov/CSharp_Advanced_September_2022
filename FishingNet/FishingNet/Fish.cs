﻿namespace FishingNet
{
    public class Fish
    {
        private string fishType;
        private double length;
        private double weight;

        public Fish(string fishType, double length, double weight)
        {
            this.FishType = fishType;
            this.Length = length;
            this.Weight = weight;        
        }

        public string FishType {
            get => this.fishType;
            set 
            {
                this.fishType = value;
            }
        }

        public double Length 
        { 
            get => this.length;
            set 
            {
                this.length = value;
            }
        }

        public double Weight 
        {
            get => this.weight;
            set
            {
                this.weight = value;
            }
        }

        public override string ToString()
        {
            return $"There is a {this.FishType}, {this.Length} cm. long, and {this.Weight} gr. in weight.";
        }
    }
}
