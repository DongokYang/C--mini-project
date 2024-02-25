using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_Project_1_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Stock ORCL = new Stock("ORCL", "Oracle Corporation",34.5m);
            ORCL.SetCurrentPrice(34.35m);
            Console.WriteLine($"Price-Change Percentage: {ORCL.GetChangePercent():P}");
        }
    }
}
