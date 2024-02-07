/*Project 2
Create a Console App (.NET Framework) project.

Declare and define a class named Stock to represent a stock from a stock market.

The class is defined as:

A string attribute named symbol for the Stock’s symbol.
A string attribute named name for the Stock name.
A decimal attribute named previousClosingPrice that stores the Stock price for the previous day.
A decimal attribute named currentPrice that stores the stock price for the current time.
A constructor that creates a Stock with the specified symbol, name, current price. The Stock's previous closing price will initially equal the current price.
A method name GetCurrentPrice() that returns the current price of the Stock.
A method name SetCurrentPrice(currentPrice) that modifies the previous close price to the state of the current price, then updates the current price to the specified price.
A method named GetChangePercent() that returns the percentage changed from previousClosingPrice to currentPrice. The formula is: price difference / previous closing price. If the change percentage is a negative, this indicates an increase.
Develop a console program that creates a Stock object with the stock symbol "ORCL", the name "Oracle Corporation", and the current price of 34.5. Set a new current price to 34.35 and display the price-change percentage.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stock Orcl = new Stock("ORCL", "Oracle", 34.5m);
            Orcl.SetCurrentPrice(34.35m);
            Console.WriteLine(Orcl.GetChangePercent());
        }
    }
}
