using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        private List<Car> participants;
        private string name;
        private string type;
        private int laps;
        private int capacity;
        private int maxHorsePower;

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
            this.participants = new List<Car>();
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public IEnumerable<Car> Participants => this.participants;

        public int Count => this.participants.Count;

        public bool Add(Car car)
        {
            string target = car.LicensePlate;
            if (this.participants.Find(p => p.LicensePlate == target) == null && this.participants.Count < this.Capacity && car.HorsePower <= this.MaxHorsePower)
            {
                this.participants.Add(car);
                return true;
            }
            return false;
        }

        public bool Remove(string licensePlate)
        {
            Car car = this.participants.Find(p => p.LicensePlate == licensePlate);
            if (car != null)
            {
                this.participants.Remove(car);
                return true;
            }
            return false;
        }

        public Car FindParticipant(string licensePlate)
        { 
        return this.participants.Find(p => p.LicensePlate == licensePlate);
        }

        public Car GetMostPowerfulCar()
        {
            return this.participants.OrderByDescending(c => c.HorsePower).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");

            foreach (Car c in this.participants)
            {
                sb.AppendLine(c.ToString());
            }

            string result = sb.ToString();
            return result;
        }
    }
}
