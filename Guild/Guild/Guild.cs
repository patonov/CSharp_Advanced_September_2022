using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;
        private string name;
        private int capacity;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public IEnumerable<Player> Roster => this.roster;

        public bool AddPlayer(Player player)
        {

            if (this.Capacity > this.roster.Count)
            {
                this.roster.Add(player);
                return true;
            }
            return false;
        }

        public bool RemovePlayer(string name)
        {
            Player target = this.roster.Find(x => x.Name == name);
            
            return this.roster.Remove(target);
        }

        public void PromotePlayer(string name)
        {
            Player target = this.roster.Find(x => x.Name == name);
            if (target.Rank != "Member")
            {
                target.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player target = this.roster.Find(x => x.Name == name);
            if (target.Rank != "Trial")
            {
                target.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class) 
        {
            var removedPlayers = this.roster.Where(x => x.Class == @class).ToArray();
            this.roster.RemoveAll(x => x.Class == @class);
            return removedPlayers;
        }

        public int Count => this.roster.Count;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (Player p in this.roster)
            {
                sb.AppendLine(p.ToString());
            }

            return sb.ToString().Trim();
        }

    }
}
