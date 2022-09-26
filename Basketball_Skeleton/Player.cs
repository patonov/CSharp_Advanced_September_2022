using System;

namespace Basketball
{
    public class Player
    {
        private string name;
        private string position;
        private double rating;
        private int games;

        public Player(string name, string position, double rating, int games)
        {
            this.Name = name;
            this.Position = position;
            this.Rating = rating;
            this.Games = games;
        }


        public string Name
        {
            get => this.name;
            set { this.name = value; }
        }
        
        public string Position 
        { 
            get => this.position;
            set { this.position = value; }
        }
        public double Rating 
        { 
            get => this.rating;
            set { this.rating = value; }
        }

        public int Games 
        {
            get => this.games;
            set { this.games = value; }
        }

        public bool Retired { get; set; }

        public override string ToString()
        {
            return $"-Player: {this.Name}" + Environment.NewLine +
                    $"--Position: {this.Position}" + Environment.NewLine +
                    $"--Rating: {this.Rating}" + Environment.NewLine +
                    $"--Games played: {this.Games}";

        }
    }
}
