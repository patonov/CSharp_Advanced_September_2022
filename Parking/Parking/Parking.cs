using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;
        private string type; 
        private int capacity;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }

        public bool Add(Car car)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(car);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            var cars = this.data.Where(x => x.Manufacturer == manufacturer).ToList();
            Car target = cars.Find(x => x.Model == model);

            if (target != null)
            {
                this.data.Remove(target);
                return true;
            }
            else 
            {
                return false;
            }
        }

        public Car GetLatestCar()
        {
            if (this.data.Count > 0)
            {
                return this.data.OrderByDescending(x => x.Year).FirstOrDefault();
            }
            return null;
        }

        public Car GetCar(string manufacturer, string model)
        {
            var cars = this.data.Where(x => x.Manufacturer == manufacturer).ToList();
            Car target = cars.Find(x => x.Model == model);

            if (target != null)
            {                
                return target;
            }
            else
            {
                return null;
            }
        }

        public int Count => this.data.Count;

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");

            foreach (Car car in this.data)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
