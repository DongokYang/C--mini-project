using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Name: Dongok Yang
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2024-01-25
 * Updated: 2024-01-25
 */

namespace PracticeProjectFour
{
    /// <summary>
    /// Represents a circle
    /// </summary>
    public class Circle : GeometricShape
    {
        private double radius;

        /// <summary>
        /// Sets the initial state of a Circle
        /// </summary>
        public Circle() : this(1)
        {
        }

        /// <summary>
        /// Sets the initial state of a Circle to a specified radius
        /// </summary>
        /// <param name="radius">A specified radius</param>
        public Circle(double radius) : this(radius, GeometricShapeColour.White, false)
        {
        }

        /// <summary>
        /// Sets the initial state of a Circle to specific attributes
        /// </summary>
        /// <param name="radius">a specified radius</param>
        /// <param name="colour">a specified colour</param>
        /// <param name="isFilled">is filled or not</param>
        public Circle(double radius, GeometricShapeColour colour, bool isFilled) : base(colour, isFilled)
        {
            if( radius <= 0)
            {
                throw new ArgumentOutOfRangeException("Error: Radius must be greater than 0.");
            }

            this.radius = radius;
        }

        /// <summary>
        /// Gets or sets the radius
        /// </summary>
        public double Radius
        {
            get => radius;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Error: Radius must be greater than 0.");
                }

                this.radius = value;
            }
        }

        /// <summary>
        /// Gets the area of a circle
        /// </summary>
        public double Area
        {
            get
            {
                return Math.Pow(Math.PI * radius, 2);
            }
        }

        /// <summary>
        /// Gets the Perimeter of a Circle
        /// </summary>
        public double Perimeter
        {
            get
            {
                return 2 * Math.PI * radius;
            }
        }

        /// <summary>
        /// Gets the Diameter of a circle
        /// </summary>
        public double Diameter
        {
            get
            {
                return 2 * radius;
            }
        }

        /// <summary>
        /// A string representation of a Circle
        /// </summary>
        /// <returns>A formatted string</returns>
        public override string ToString()
        {
           return String.Format("\nThe Circle's colour is {0}\nThe circle is {1}\nThe radius is {2}\n" +
                "The area is {3:f2}\nThe perimeter is {4:f2}\nThe diameter is {5:f2}",
                base.Colour, base.IsFilled == true ? "is filled" : "is not filled",
                Radius, Area, Perimeter, Diameter);
        }
    }
}
