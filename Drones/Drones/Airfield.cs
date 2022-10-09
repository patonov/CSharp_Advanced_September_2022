using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        
        private string name;
        private int capacity;
        private double andingStrip;
        private readonly List<Drone> drones;

        public Airfield(string name, int capacity, double andingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.AndingStrip = andingStrip;
            this.drones = new List<Drone>();
        }

        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
            }
        }

        public int Capacity
        {
            get => this.capacity;
            set
            {
                this.capacity = value;
            }
        }

        public double AndingStrip
        {
            get => this.andingStrip;
            set
            {
                this.andingStrip = value;
            }
        }

        public IEnumerable<Drone> Drones => this.drones;

        public int Count => this.drones.Count;

        public string AddDrone(Drone drone)
        {
            
                if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand))
                {
                    return "Invalid drone.";
                }
                else if (drone.Range < 5 || drone.Range > 15)
                {
                    return "Invalid drone.";
                }

            if (this.drones.Count >= this.capacity)
            {
                return "Airfield is full.";
            }
            else
            {
                this.drones.Add(drone);
                return $"Successfully added {drone.Name} to the airfield.";
            }
        }

        public bool RemoveDrone(string name)
        {
            var targetDrone = this.drones.FirstOrDefault(d => d.Name == name);
            if (targetDrone != null)
            {
                this.drones.Remove(targetDrone);
                return true;
            }
            return false;
        }

        public int RemoveDroneByBrand(string brand)
        {
            return this.drones.RemoveAll(d => d.Brand == brand);
        }

        public Drone FlyDrone(string name)
        {
            var targetDrone = this.drones.FirstOrDefault(d => d.Name == name);
            if (targetDrone != null)
            {
                foreach (Drone d in this.drones)
                {
                    if (d == targetDrone)
                    {
                        d.Available = false;                        
                        return d;                        
                    }
                }                
            }
            return null;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            foreach (Drone d in drones.FindAll(d => d.Range >= range))
            {
                d.Available = false;
            }
            return drones.FindAll(d => d.Range >= range).ToList();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Drones available at {this.Name}:");

            foreach (Drone d in this.drones.Where(d => d.Available == true))
            {
                sb.AppendLine(d.ToString());
            }
            return sb.ToString();
        }
    }

}
