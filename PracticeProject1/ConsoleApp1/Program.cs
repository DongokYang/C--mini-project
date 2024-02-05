/*Project 1
Create a Console App (.NET Framework) project.

Declare and define a class named Rectangle to represent a rectangle.

The class is define as:

Two decimal attributes named width and height that specify the width and height of the Rectangle. 
The default values are 1 for both width and height.
A no-arg constructor that creates a default Rectangle.
A constructor that creates a Rectangle with the specified width and height.
A method named GetWidth() that returns the width of the Rectangle.
A method named GetHeight() that returns the height of the Rectangle.
A method named GetArea() that returns the area of the Rectangle.
A method named GetPerimeter() that returns the perimeter of the Rectangle.
A ToString() method that returns the string representation of the Rectangle in the following format:
W: {width} H: {height} A: {area} P: {perimeter}

Develop a console program that creates two Rectangle objects; one with a width of 4 and a height of 40. 
The other with a width of 3.5 and a height of 35.9. Print the width, height, area, and perimeter of each Rectangle to the console.*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceProject1

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle first = new Rectangle(4,40);
            Rectangle second = new Rectangle(3.5, 35.9);
            Console.WriteLine("First Rectangle: " + first.ToString());
            Console.WriteLine("Second Rectangle: " + second.ToString());
        }
    }
}
