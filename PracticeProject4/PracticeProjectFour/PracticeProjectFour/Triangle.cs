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
    /// Represents a Triangle
    /// </summary>
    public class Triangle : GeometricShape
    {
        private double sideOne;
        private double sideTwo;
        private double sideThree;

        //How to: Declare a list
        private List<Triangle> triangles;

        /// <summary>
        /// Sets the initial state of a Triangle
        /// </summary>
        public Triangle() : this(1,1,1)
        {

        }

        /// <summary>
        /// Sets the inital state of a triangle to specified values
        /// </summary>
        /// <param name="sideOne">Side one of three of a triangle</param>
        /// <param name="sideTwo">Side two of three of a triangle</param>
        /// <param name="sideThree">Side three of three of a triangle</param>
        public Triangle(double sideOne, double sideTwo, double sideThree) : base(GeometricShapeColour.White, false)
        {
            if(sideOne <= 0 || sideTwo <= 0 || sideThree <= 0)
            {
                throw new ArgumentOutOfRangeException("Error: The sides need to be greater than 0.");
            }

            //Reminder: Attributes are only set after above validation.
            this.sideOne = sideOne;
            this.sideTwo = sideTwo;
            this.sideThree = sideThree;

            //How to: define a list. This step only occurs after validation.
            triangles = new List<Triangle>();
        }

        /// <summary>
        /// Gets or Sets Side One
        /// </summary>
        public double SideOne
        {
            get => sideOne;
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Error: Side one needs to be greater than 0");
                }

                sideOne = value;
            }
        }

        /// <summary>
        /// Gets or Sets Side Two
        /// </summary>
        public double SideTwo
        {
            get => sideTwo;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Error: Side two needs to be greater than 0");
                }

                sideTwo = value;
            }
        }

        /// <summary>
        /// Gets or Sets Side Three
        /// </summary>
        public double SideThree
        {
            get => sideThree;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Error: Side three needs to be greater than 0");
                }

                sideThree = value;
            }
        }

        /// <summary>
        /// Gets the Perimeter of the Triangle
        /// </summary>
        public double Perimeter
        {
            get
            {
                return SideOne + SideTwo + SideThree;
            }

        }

        /// <summary>
        /// How to: Overrride a user-defined method
        /// Base class needs to be declared as virtual!
        /// </summary>
        public override void IsAlwaysFilled()
        {
            base.IsFilled = false;
        }

        /// <summary>
        /// How to: Add an item to a list
        /// Note: Removing an item is similar
        /// Hint: Ensure your list is not null before executing this code!
        /// </summary>
        /// <param name="triangle">a triangle onject to be added</param>
        public void AddTriangle(Triangle triangle)
        {
            this.triangles.Add(triangle);
        }

        /// <summary>
        /// How to: NOT return a reference to a List object
        /// Make a new copy
        /// </summary>
        /// <returns>A deep copy of a List of Triangles</returns>
        public List<Triangle> Triangles()
        {
            List<Triangle> localTriangles = new List<Triangle>();

            foreach (Triangle triangle in this.triangles)
            {
                localTriangles.Add(triangle);
            }

            return localTriangles;     
        }

        /// <summary>
        /// A string representation of a Triangle's Perimeter
        /// </summary>
        /// <returns>The Triangle's perimeter</returns>
        public override string ToString()
        {
            return String.Format("\nThe calculated Perimeter of this Triangle is {0}", Perimeter);
        }
    }
}
