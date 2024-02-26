using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_1Library
{
    public class Rectangle
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
            Width = width;
            Height = height;
            this.area = width * height;
            this.perimeter = (width + height) * 2;
        }
        public decimal Width
        {
            get => this.width;
            set => this.width = value;
        }
        public decimal Height
        {
            get => this.height;
            set => this.height = value;
        }

        public decimal Area
        {
            get { return Width * Height; }
        }

        public decimal Perimeter
        {
            get { return (width + height) * 2; }
        }


        public override string ToString()
        {
            return $"W: {Width} H: {Height} A: {Area} P: {Perimeter}";
        }
    }
}
