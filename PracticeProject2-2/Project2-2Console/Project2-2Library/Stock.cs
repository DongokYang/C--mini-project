using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_2Library
{
    public class Stock
    {
        public string Symbol { get; private set; }
        public string Name { get; private set; }
        public decimal CurrentPrice { get; set; }
        public decimal PreviousClosingPrice { get; private set; }
        public Stock(string symbol, string name, decimal currentPrice)
        {
            Symbol = symbol; // Corrected assignment
            Name = name;     // Corrected assignment
            PreviousClosingPrice = currentPrice; // Corrected assignment
            CurrentPrice = currentPrice;
        }

        public decimal GetChangePercent()
        {
            return (PreviousClosingPrice - CurrentPrice) / PreviousClosingPrice;
        }
    }
}
