using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project2_1Library;

namespace Project2_1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(4, 5);

            Console.WriteLine($"Width: {rectangle.Width}");
            Console.WriteLine($"Height: {rectangle.Height}");
            Console.WriteLine($"Area: {rectangle.Area}");
            Console.WriteLine($"Perimeter: {rectangle.Perimeter}");
            Console.WriteLine(rectangle.ToString());

            Console.ReadLine();
        }
    }
}