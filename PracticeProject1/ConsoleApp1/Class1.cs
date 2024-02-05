using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceProject1
{
    internal class Rectangle
    {
        private double Width = 1;
        private double Height = 1;
        private double Area;
        private double Perimeter;

        public Rectangle()
        {
        }
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
            Area = width * height;
            Perimeter = (width + height) * 2;
        }

        public double GetWidth()
        {
            return Width;

        }
        public double GetHeight()
        {
            return Height;

        }
        public void SetWidth(double width)
        {
            Width = width;
        }
        public void SetHeight(double height)
        {
            Height = height;
        }
        public double GetArea(double width, double height)
        {
            Area = width * height;
            return Area;
        }
        public double GetPerimeter(double width, double height)
        {
            Perimeter = (width + height) * 2;
            return Perimeter;
        }
        public override string ToString()
        {
            return $"Rectangle - Width: {Width}, Height: {Height}, Area: {Area}, P:{Perimeter}";
        }
    }

}

