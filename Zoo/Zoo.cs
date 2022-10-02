using System;
using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        private List<Animal> animals;

        public Zoo(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            animals = new List<Animal>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public List<Animal> Animals => this.animals;

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }
            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            if (this.animals.Count >= this.Capacity) 
            {
                return "The zoo is full.";
            }
            else
            {
                this.animals.Add(animal);
                return $"Successfully added {animal.Species} to the zoo.";
            }
        }

        public int RemoveAnimals(string species)
        {            
            if (this.animals.Where(c => c.Species == species).Count() > 0)
            {
                return animals.RemoveAll(a => a.Species == species); 
            }
            return 0;    
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> animalsByDiet = new List<Animal>();
            animalsByDiet = animals.Where(a => a.Diet == diet).ToList();
            return animalsByDiet;
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return animals.Find(a => a.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int counter = 0;
            foreach (Animal ani in animals)
            {
                if (ani.Length >= minimumLength && ani.Length <= maximumLength)
                {
                    counter++;
                }           
            }
            return $"There are {counter} animals with a length between {minimumLength} and {minimumLength} meters.";
        }

    }
}
