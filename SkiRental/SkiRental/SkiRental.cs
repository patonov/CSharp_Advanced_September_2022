using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> collection;
        private string name;
        private int capacity;

        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.collection = new List<Ski>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public bool Add(Ski ski)
        {
            if (this.collection.Count < this.Capacity)
            {
                this.collection.Add(ski);
                return true;
            }
            return false;
        }
        public bool Remove(string manufacturer, string model)
        {
            Ski target = this.collection.Find(s => s.Manufacturer == manufacturer && s.Model == model);
            if (target != null)
            {
                this.collection.Remove(target);
                return true;
            }
            return false;
        }

        public Ski GetNewestSki()
        {
            if (this.collection.Count > 0)
            {
                return this.collection.OrderByDescending(s => s.Year).First();
            }
            return null;
        }

        public Ski GetSki(string manufacturer, string model)
        { 
        return this.collection.Find(s => s.Manufacturer == manufacturer && s.Model == model);
        }

        public int Count => this.collection.Count;

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {this.Name}:");

            foreach (Ski s in this.collection)
            {
                sb.AppendLine(s.ToString());
            }

            return sb.ToString();
        }
    }
}
