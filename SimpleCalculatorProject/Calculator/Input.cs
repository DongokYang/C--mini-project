using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Input
    {
        List<object> list = new List<object>();

        public void gettingInput()
        {
            string input = "0";
            while (true)
            {
                Console.WriteLine("Enter values:");
                input = Console.ReadLine();

                if (input == "=")
                {
                    foreach (string element in list)
                    {
                        Console.WriteLine(element);
                    }
                    
                    Functions valuecalculator = new Functions();
                    valuecalculator.calculateTotalValue(list);

                    Console.WriteLine("this loop is ended");
                    // break;
                }
                else if (input == "+" || input == "-" || input == "*" || input == "%")
                {
                    list.Add(input);
                }
                else
                {
                    list.Add(input);
                }
            }


        }


    }

}
