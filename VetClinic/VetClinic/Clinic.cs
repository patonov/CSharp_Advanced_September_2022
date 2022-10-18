using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;
        private int capacity;

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.data = new List<Pet>();
        }

        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public bool Add(Pet pet)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(pet);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Remove(string name)
        {
            Pet pet = this.data.Find(x => x.Name == name);
            if (pet != null)
            {
                this.data.Remove(pet);
                return true;
            }
            else
            { 
            return false;
            }
        }

        public Pet GetPet(string name, string owner)
        {
            var pets = this.data.Where(x => x.Name == name).ToList();

            if (pets.Count > 0)
            {
                Pet pet = this.data.Find(x => x.Owner == owner);
                if (pet != null)
                {
                    return pet;
                }
            }
            return null;
        }

        public Pet GetOldestPet()
        {
            return this.data.OrderByDescending(x => x.Age).First();
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The clinic has the following patients:");

            foreach (Pet d in this.data)
            {
                sb.AppendLine($"Pet {d.Name} with owner: {d.Owner}");
            }
            return sb.ToString().Trim();
        }

    }
}
