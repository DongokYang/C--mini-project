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
    /// Represents a Vehicle with year, model, manufacturer, color and sale price.
    /// </summary>
    public class Vehicle
    {
        private int year;
        private string model;
        private string manufacturer;
        private PaintColor color;
        private decimal salePrice;

        /// <summary>
        /// Sets the vehicle with basic information of ocar
        /// </summary>
        /// <param name="year">Production year of a vehicle</param>
        /// <param name="model">Model of a vehicle</param>
        /// <param name="manufacturer">Manufacturer of a vehicle</param>
        /// <param name="color">Color of a vehicle</param>
        /// <param name="sale_Price">Sale price of a vehicle</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the year is not within the valid year range.</exception>
        /// <exception cref="ArgumentException">Thrown when the model doesn't contain non-white characters.</exception>
        /// <exception cref="ArgumentException">Thrown when the manufacturer doesn't contain non-white characters.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when sale pricec is less or equal to 0</exception>
        public Vehicle(int year, string model, string manufacturer, PaintColor color, decimal salePrice)
        {
            if (year < 1950 || year > DateTime.Now.Year + 1)
            {
                throw new ArgumentOutOfRangeException("Year", $"The year must be in the range of 1950 to {DateTime.Now.Year + 1}.");
            }
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentException("The model must contain non-whitespace characters.", "Model");
            }
            if (string.IsNullOrWhiteSpace(manufacturer))
            {
                throw new ArgumentException("The manufacturer must contain non-whitespace characters.", "Manufacturer");
            }
            if (salePrice < 0)
            {
                throw new ArgumentOutOfRangeException("SalePrice", "The sale_Price must be 0 or greater.");
            }
            Year = year;
            Model = model;
            Manufacturer = manufacturer;
            Color = color;
            SalePrice = salePrice;
        }

        /// <summary>
        /// Gets or Sets Year
        /// </summary>
        public int Year
        {
            get => this.year;
            private set
            {
                this.year = value;
            }
        }

        /// <summary>
        /// Gets or Sets Model
        /// </summary>
        public string Model
        {
            get => this.model;
            private set { 
                this.model = value; 
            }
        }

        /// <summary>
        /// Gets or Sets Manufacturer
        /// </summary>
       
        public string Manufacturer
        {
            get => this.manufacturer;
            private set
            {
                this.manufacturer = value;
            }
        }

        /// <summary>
        /// Gets or Sets Color
        /// </summary>
        public PaintColor Color
        {
            get => this.color;
            private set => this.color = value;
        }

        /// <summary>
        /// Gets or Sets Sale price
        /// </summary>
        public decimal SalePrice
        {
            get => this.salePrice;
            private set
            {
  
                this.salePrice = value;
            }
        }

        /// <summary>
        /// Returns a string representation of the vehicle in the following format:
        /// {year}, {manufacturer}, {model}, {color} 
        /// </summary>
        /// <returns>A string representation of the vehicle Object.</returns>
        public override string ToString()
        {
            return $"{Year}, {Manufacturer}, {Model}, {Color}";
        }
    }
}
