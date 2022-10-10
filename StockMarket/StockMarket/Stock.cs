using System.Text;

namespace StockMarket
{
    public class Stock
    {
        private string companyName;
        private string director;
        private decimal pricePerShare;
        private int totalNumberOfShares;
        private decimal marketCapitalization;

        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShares) 
        {
            this.CompanyName = companyName;
            this.Director = director;
            this.PricePerShare = pricePerShare;
            this.TotalNumberOfShares = totalNumberOfShares;
            this.marketCapitalization = this.TotalNumberOfShares * this.PricePerShare;
        }

        public string CompanyName 
        {
            get => this.companyName;
            set { this.companyName = value; }
        }

        public string Director
        {
            get => this.director;
            set { this.director = value; }
        }

        public decimal PricePerShare
        {
            get => this.pricePerShare;
            set { this.pricePerShare = value; }
        }

        public int TotalNumberOfShares
        {
            get => this.totalNumberOfShares;
            set { this.totalNumberOfShares = value; }
        }

        public decimal MarketCapitalization
        {
            
            get => this.marketCapitalization;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
                        
            sb.AppendLine($"Company: {this.CompanyName}");
            sb.AppendLine($"Director: {this.Director}");
            sb.AppendLine($"Price per share: ${this.PricePerShare}");
            sb.AppendLine($"Market capitalization: ${this.MarketCapitalization}");
            
            return sb.ToString();
        }
    }
}
