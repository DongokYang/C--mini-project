using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Functions
    {
        public void calculateTotalValue(List<object> Input)
        {
            int sum = 0;
            string operand = null;

            foreach (object element in Input)
            {
                if (sum == 0)
                {
                    sum = Convert.ToInt32(element);
                }
                else if (operand == null)
                {
                    operand = element.ToString();
                }
                else
                {
                    switch (operand)
                    {
                        case "+":
                            sum += Convert.ToInt32(element);
                            operand = null;
                            break;
                        case "-":
                            sum -= Convert.ToInt32(element);
                            operand = null;
                            break;
                        case "*":
                            sum *= Convert.ToInt32(element);
                            operand = null;
                            break;
                        case "%":
                            sum /= Convert.ToInt32(element);
                            operand = null;
                            break;
                    }
                }
            }
            Console.WriteLine($"Result: {sum}");
        }
    }
}

/*
 + 	(plus)
-	(minus)
=	(executeCalculate)
X	(times)
%	(divide)
C	(clear)
!	(factorial)
 */


