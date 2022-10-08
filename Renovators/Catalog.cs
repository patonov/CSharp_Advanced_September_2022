using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;
        private string name;
        private int neededRenovators;
        private string project;

        public Catalog(string name, int neededRenovators, string project)
        {
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
            renovators = new List<Renovator>();
        }

        public string Name 
        {
            get => this.name;
            set
            {
                this.name = value;
            }
        }

        public int NeededRenovators 
        {
            get => this.neededRenovators;
            set
            {
                this.neededRenovators = value;
            }
        }

        public string Project 
        {
            get => this.project;
            set
            {
                this.project = value;
            }
        }

        public IEnumerable<Renovator> RenovatorsCollection => this.renovators;

        public int Count => this.renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (this.renovators.Count < this.NeededRenovators)
            {
                if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
                {
                    return "Invalid renovator's information.";
                }
                if (renovator.Rate > 350.00)
                {
                    return "Invalid renovator's rate.";
                }
                this.renovators.Add(renovator);
                return $"Successfully added {renovator.Name} to the catalog.";
            }
            else
            {
                return "Renovators are no more needed.";
            }
        }

        public bool RemoveRenovator(string name)
        {
            Renovator ren = this.renovators.FirstOrDefault(x => x.Name == name);
            if (ren == null)
            {
                return false;
            }
            this.renovators.Remove(ren);
            return true;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            return this.renovators.RemoveAll(r => r.Type == type);
        }

        public Renovator HireRenovator(string name)
        {
            Renovator ren = this.renovators.FirstOrDefault(x => x.Name == name);
            if (ren != null)
            {
                ren.Hired = true;
                return ren;
            }

            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            return this.renovators.FindAll(x => x.Days >= days).ToList();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {this.Project}:");
            
            foreach (Renovator r in this.renovators.Where(r => r.Hired == false))
            {
                sb.AppendLine(r.Name);
            }
            return sb.ToString();

        }



    }
}
