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
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dongok.Yang
{
    /// <summary>
    /// Represents a Quote
    /// </summary>
    public abstract class Quote
    {
        /// <summary>
        /// Event triggered when the sale price changes.
        /// </summary>
        public event EventHandler SalePriceChanged;

        private decimal salePrice;
        private decimal taxRate;
        /// <summary>
        /// Sets the inital state of a quote to specified values
        /// </summary>
        /// <param name="salePrice">Sale price of a quote</param>
        /// <param name="taxRate">taxRate of a quote</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the sale price is less than or equal to 0.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the tax rate is outside the valid range of 0 to 1 (inclusive).</exception>
        public Quote(decimal salePrice, decimal taxRate)
        {
            if (salePrice <= 0)
            {
                throw new ArgumentOutOfRangeException("SalePrice", "The SalePrice must be greater than 0.");
            }
            if (taxRate < 0 || taxRate > 1)
            {
                throw new ArgumentOutOfRangeException("TaxRate", "The TaxRate must be within the range of 0 to 1 (inclusive).");
            }

            SalePrice = salePrice;
            TaxRate = taxRate;
        }

        /// <summary>
        /// Gets or Sets Tax Rate
        /// </summary>
        public decimal TaxRate
        {
            get => this.taxRate;
            private set => this.taxRate = value;
            }

        /// <summary>
        /// Gets or Sets Sale Price
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the sale price is less than or equal to 0.</exception>
        public decimal SalePrice
        {
            get => this.salePrice;
            set
            {
                if (value < 0 )
                {
                    throw new ArgumentOutOfRangeException("SalePrice", "The value must be greater than 0.");
                }
                this.salePrice = value;
                SalePriceChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        /// <summary>
        /// Calculate tax of a quote
        /// </summary>
        /// <returns>A tax of a quote</returns>
        public virtual decimal CalculateTax()
        {
            return TaxRate * SalePrice;
        }

        /// <summary>
        /// Calculate total of a quote
        /// </summary>
        /// <returns>A Total of a quote</returns>
        public virtual decimal CalculateTotal()
        {
            return SalePrice + CalculateTax();
        }

        /// <summary>
        /// Triggers the SalePriceChanged event. This method is triggered when the sale price of the vehicle changes.
        /// </summary>
        protected virtual void OnSalePriceChanged()
        {
            if (SalePriceChanged != null) 
            {
                SalePriceChanged(this, EventArgs.Empty);
             }
        }

        /// <summary>
        /// Returns a string representation of the Quote object.
        /// </summary>
        /// <returns>A formatted string representing the quote.</returns>           
        public override string ToString()
        {
            return $"Quote: {CalculateTotal():C}";
        }
    }
}