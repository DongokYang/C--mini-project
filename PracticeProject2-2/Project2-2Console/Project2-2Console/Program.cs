using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project2_2Library;
namespace Project2_2Console
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Stock ORCL = new Stock("ORCL", "Oracle Corporation", 34.5m);
            ORCL.CurrentPrice = 34.35m;
            Console.WriteLine($"Price-Change Percentage: {ORCL.GetChangePercent():P}");
        }
    }
}
