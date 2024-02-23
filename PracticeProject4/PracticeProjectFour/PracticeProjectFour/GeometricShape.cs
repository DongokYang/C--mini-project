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
    /// Represents a Geometric Shape
    /// </summary>
    public abstract class GeometricShape
    {
        private GeometricShapeColour colour;
        private bool isFilled;

        /// <summary>
        /// Sets the inital state of a GeometricShape
        /// </summary>
        public GeometricShape() : this(GeometricShapeColour.White, false)
        {

        }

        /// <summary>
        /// Sets the inital state of a Geometric shape with defined attributes
        /// </summary>
        /// <param name="colour">a specific colour</param>
        /// <param name="isFilled">if the shape is filled</param>
        public GeometricShape(GeometricShapeColour colour, bool isFilled)
        {
            string colourTest = colour.ToString();

            //How to: Check if a string value is empty
            if (colourTest.Trim().Equals(String.Empty))
            {
                throw new ArgumentException("Value cannot be empty");
            }
            
            //this code must be placed after validation
            this.colour = colour;
            this.isFilled = isFilled;
        }

        /// <summary>
        /// Gets or sets the Colour
        /// </summary>
        public GeometricShapeColour Colour
        {
            get => colour;
            set => colour = value; 
            //using the lambda operator shortcut only works if there's no logic
        }

        /// <summary>
        /// Gets or sets if the shap is filled
        /// </summary>
        public bool IsFilled
        {
            get => isFilled;
            set => isFilled = value;
        }

        /// <summary>
        /// How to: Override a user-defined method
        /// They need to be marked as virtual
        /// </summary>
        public virtual void IsAlwaysFilled()
        {
            IsFilled = true;
        }

        /// <summary>
        /// A string representation of a Geometric shape.
        /// </summary>
        /// <returns>A formatted string</returns>
        public override string ToString()
        {
            return String.Format("The GeometricShape's colour is {0} and {1} ", Colour.ToString(),
                            IsFilled == true ? "is Filled." : "is not filled.");
        }
    }
}
