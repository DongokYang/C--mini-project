using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_Projects_1
{
    internal class Rectangle
    {
        decimal width = 1;
        decimal height = 1;
        decimal area;
        decimal perimeter;
        public Rectangle()
        {
            // no-arg constructor
        }
        
        public Rectangle(decimal width, decimal height)
        {
            this.width = width;
            this.height = height;
            this.area = width * height;
            this.perimeter = (width+height)*2;
        }

        public decimal GetWidth(decimal width)
        {
            return width;
        }
        public decimal GetHeight(decimal height)
        {
            return height;
        }
        public decimal GetArea(decimal area)
        {
            return area;
        }
        public decimal GetPerimeter(decimal perimeter)
        {
            return perimeter;
        }

        public override string ToString()
        {
            return $"W: {width} H: {height} A: {area} P: {perimeter}";
        }
    }
}
