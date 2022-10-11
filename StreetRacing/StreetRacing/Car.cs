﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacing
{
    public class Car
    {
        private string make;
        private string model;
        private string licensePlate;
        private int horsePower;
        private double weight;

        public Car(string make, string model, string licensePlate, int horsePower, double weight)
        {
            this.Make = make;
            this.Model = model;
            this.LicensePlate = licensePlate;
            this.HorsePower = horsePower;
            this.Weight = weight;
        }

        public string Make { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public int HorsePower { get; set; }
        public double Weight { get; set; }

        public override string ToString()
        {
            return $"Make: {this.Make}" + Environment.NewLine +
                    $"Model: {this.Model}" + Environment.NewLine +
                    $"License Plate: {this.LicensePlate}" + Environment.NewLine +
                    $"Horse Power: {this.HorsePower}" + Environment.NewLine +
                    $"Weight: {this.Weight}";

        }
    }
}
