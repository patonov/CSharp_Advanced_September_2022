namespace FishingNet
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Net
    {
        private List<Fish> fish;
        private string material;
        private int capacity;

        public Net(string material, int capacity)
        {
            this.Material = material;
            this.capacity = capacity;
            fish = new List<Fish>();
        }

        public string Material 
        {
            get => this.material;
            set { this.material = value; }
        }

        public int Capacity 
        { 
            get => this.capacity;
            set { this.capacity = value; }
        }

        public IEnumerable<Fish> Fish => this.fish;

        public int Count => this.fish.Count;

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrEmpty(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }
            else
            {
                if (this.Count < this.Capacity)
                {
                    this.fish.Add(fish);
                    return $"Successfully added {fish.FishType} to the fishing net.";
                }
                else
                {
                    return "Fishing net is full.";
                }
            }
        }

       public bool ReleaseFish(double weight)
       {
          int n = this.fish.RemoveAll(f => f.Weight == weight);
            if (n == 0)
            {
                return false;
            }
            return true;
       }

        public Fish GetFish(string fishType)
        {
            return this.fish.Find(f => f.FishType == fishType);
        }

        public Fish GetBiggestFish()
        {
            return this.fish.OrderByDescending(f => f.Length).First();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {this.Material}:");

            foreach (var f in this.fish.OrderByDescending(f => f.Length))
            {
                sb.AppendLine(f.FishType);
            }
            return sb.ToString();
        }
    }
}
