using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stocklibrary
{
    public class Stock
    {
        private string symbol;
        private string name;
        private decimal previousClosingPrice;
        private decimal currentPrice;
        private decimal changedPercent;

        public Stock(string symbol, string name, decimal currentPrice) { 
            this.Symbol = symbol;
            this.Name = name;
            this.CurrentPrice = currentPrice;
            this.previousClosingPrice = currentPrice;
            
        }

        public string Symbol
        {
            get 
            { 
                return symbol; 
            }
            private set 
            { 
                symbol = value; 
            }
        }
        public string Name
        { 
            get 
            { 
                return name; 
            }
            private set
            { 
               symbol = value;
            } 
        }
        public decimal PrevClosingPrice
        {
            get
            {
                return previousClosingPrice;
            }
            private set
            {
                previousClosingPrice = value;
            }
        }
        public decimal CurrentPrice
        {
            get
            {
                return currentPrice;
            }
            set
            {
                previousClosingPrice = currentPrice;
                currentPrice = value;
            }

        }
        public decimal ChangedPercent
        {
            get {
                return changedPercent;
                 }
            private set
            {
                changedPercent = (this.currentPrice - this.previousClosingPrice)/previousClosingPrice;
            }
        }
    
    
    
    }
}
