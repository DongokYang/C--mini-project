using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject2
{
    internal class Stock
    {
        private string symbol;
        private string name;
        private decimal previousClosingPrice;
        private decimal currentPrice;
        private decimal changedPercent;

        public Stock(string symbol, string name, decimal previousClosingPrice)
        {
            this.symbol = symbol;
            this.name = name;
            this.previousClosingPrice = previousClosingPrice;
            this.currentPrice = previousClosingPrice;
        }
        public decimal GetCurrentPrice()
        {
            return currentPrice;
        }

        public void SetCurrentPrice(decimal currentPrice)
        {
            this.currentPrice = currentPrice;
        }

        public decimal GetChangePercent()
        {
            changedPercent = (currentPrice - previousClosingPrice) / previousClosingPrice;
            return changedPercent;
        }
    }
}
