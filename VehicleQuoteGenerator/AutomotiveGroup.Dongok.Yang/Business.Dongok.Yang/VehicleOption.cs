/*
 * Name: Dongok Yang
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2024-01-21
 * Updated: 2024-03-19
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dongok.Yang
{
    /// <summary>
    /// Represents a Vehicle option.
    /// </summary>
    public class VehicleOption
    {
        private string description;
        private decimal unitPrice;
        private int quantity;
        /// <summary>
        /// Sets the inital state of a Vehicle Option to specified values
        /// </summary>
        /// <param name="description">Description of an option</param>
        /// <param name="unitPrice">unitprice of an option</param>
        /// <param name="quantity">quantity of an option</param>
        /// <exception cref="ArgumentException">Thrown when the description doesn't contain non-white characters.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the unitprice is  less or equal to 0.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the quantity is  less or equal to 0.</exception>
        public VehicleOption(string description, decimal unitPrice, int quantity)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("The description must contain non-whitespace characters.","Description");
            }

            if (unitPrice < 0)
            {
                throw new ArgumentOutOfRangeException("UnitPrice", "The unit price must be 0 or greater.");
            }

            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException("Quantity", "The quantity must be 0 or greater.");
            }

            Description = description;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        public string Description
        {
            get => this.description;
            private set => this.description = value;
        }

        /// <summary>
        /// Gets or Sets Unit Price
        /// </summary>
        public decimal UnitPrice
        {
            get => this.unitPrice;
            private set => this.unitPrice = value;
        }

        /// <summary>
        /// Gets or Sets Quantity
        /// </summary>
        public int Quantity
        {
            get => this.quantity;
            private set => this.quantity = value;
        }

        /// <summary>
        /// A string representation of a Vehicle Option's parameters
        /// </summary>
        /// <returns>The Vehicle Option's parameters</returns>
        public override string ToString()
        {
            return $"{Description} x {Quantity} @ {UnitPrice:C2}";
        }
    }
}
