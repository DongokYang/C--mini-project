using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeProjectFour;

/*
 * Name: Dongok Yang
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2024-01-25
 * Updated: 2024-01-25
 */

namespace GeometricShapeTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Reminder: abstract base classes cannot be instantiated
            //The code will not compile
            //GeometricShape geometricShapeTwo = new GeometricShape(GeometricShapeColour.Blue, true);

            /*
             * Remember the steps in gaining access to a class library:
             * 1. Right-click on references and add a reference to the Library
             * 2. Note the NameSpace of the Class you want to reference
             * 3. Add a using statement. See above.
             */

            try
            {
                Circle circleOne = new Circle();
                Circle circleTwo = new Circle(5.50);
                Circle circleThree = new Circle(5.5, GeometricShapeColour.Blue, true);

                Console.WriteLine(circleOne.ToString());
                Console.WriteLine(circleTwo.ToString());
                Console.WriteLine(circleThree.ToString());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("\nException Occurred: " + ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("\nException Occurred: " + ex.Message);
            }

            //Reminder: Keep the scope of your try blocks small
            try
            {
                Triangle triangleOne = new Triangle();
                Triangle triangleTwo = new Triangle(5, 5, 5);

                //How to: Execute or call a sub procedure:
                PrintTriangle(triangleOne);
                PrintTriangle(triangleTwo);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("\nException Occurred: " + ex.Message);
            }

            Console.WriteLine("\nPress a key to continue");
            Console.ReadKey();
        }

        /// <summary>
        /// How to: Create a sub procedure
        /// In the context of the main method in Program.cs
        /// The sub procedure needs to be defined as static
        /// </summary>
        /// <param name="triangle">The Triangle to be printed</param>
        static void PrintTriangle(Triangle triangle)
        {
            //Reminder: A void method has no return statement!

            Console.WriteLine(triangle.ToString());
        }

    }
}
