using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> portfolio;
        private string fullName;
        private string emailAddress;
        private decimal moneyToInvest;
        private string brokerName;

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            this.FullName = fullName;
            this.EmailAddress = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
            this.portfolio = new List<Stock>();
        }

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public IEnumerable Portfolio => this.portfolio;

        public int Count => this.portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000m && this.moneyToInvest <= stock.PricePerShare)
            {
                this.portfolio.Add(stock);
                this.MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            var target = this.portfolio.FirstOrDefault(s => s.CompanyName == companyName);

            if (target == null)
            {
                return $"{companyName} does not exist.";
            }
            else
            {
                if (sellPrice < target.PricePerShare)
                {
                    return $"Cannot sell {companyName}.";
                }
                else
                {
                    this.moneyToInvest += target.PricePerShare;
                    this.portfolio.Remove(target);
                    return $"{companyName} was sold.";
                }
            }        
        }

        public Stock FindStock(string companyName)
        { 
        return this.portfolio.FirstOrDefault(s => s.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            if (this.portfolio.Count == 0)
            {
                return null;
            }
            decimal max = decimal.MinValue;
            Stock target = null;

            foreach (var s in this.portfolio)
            {
                if (s.MarketCapitalization > max)
                {
                    target = s;
                }            
            }
            return target;
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");
            foreach (var s in this.portfolio)
            {
                sb.AppendLine(s.ToString());
            }
            return sb.ToString();
        }

    }
}
