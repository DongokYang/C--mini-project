using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_Project_1_2
{
    internal class Stock
    {
        string symbol;
        string name;
        decimal previousClosingPrice;
        decimal currentPrice;

        public Stock(string symbol, string name, decimal currentPrice)
        {
            this.symbol = symbol;
            this.name = name;
            this.previousClosingPrice = currentPrice;
            this.currentPrice = currentPrice;
        }

        public decimal GetCurrentPrice()
        {
            return currentPrice;
        }
        public void SetCurrentPrice(decimal newcurrentPrice)
        {
            previousClosingPrice = currentPrice;
            currentPrice= newcurrentPrice;
        }
        public decimal GetChangePercent()
        {
            return (previousClosingPrice-currentPrice)/previousClosingPrice;
        }
    }
}
