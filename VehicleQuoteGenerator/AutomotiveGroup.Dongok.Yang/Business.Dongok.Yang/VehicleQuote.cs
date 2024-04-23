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
    /// Represents a Vehicle Quote.
    /// </summary>
    public class VehicleQuote : Quote
    {
        /// <summary>
        /// Event triggered when the TradeInValue changes
        /// </summary>
        public event EventHandler TradeInValueChanged;


        /// <summary>
        /// Event triggered when the a VehicleOption is added
        /// </summary>
        public event EventHandler<VehicleOptionAddedEventArgs> VehicleOptionAdded;

        /// <summary>
        /// /// Event triggered when the a VehicleOption is removed
        /// </summary>
        public event EventHandler VehicleOptionRemoved;

        private decimal tradeInValue;
        private List<VehicleOption> options;
        private Vehicle vehicle;

        /// <summary>
        /// Sets the inital state of a Vehicle Quote to specified values
        /// </summary>
        /// <param name="vehicle">vehicle information of an vehicle quote</param>
        /// <param name="salePrice">salePrice of an vehicle quote</param>
        /// <param name="taxRate">taxRate of an vehicle quote</param>
        /// <param name="tradeInValue">tradeInValue of an vehicle quote</param>
        /// <exception cref="NullReferenceException">Thrown when tradeInValuie is less or equal to 0</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when vehicle's value is Null.</exception>
        public VehicleQuote (Vehicle vehicle, decimal taxRate, decimal tradeInValue = 0)
            : base(vehicle.SalePrice, taxRate)
        {
            if (tradeInValue < 0)
            {
                throw new ArgumentOutOfRangeException("TradeInValue", "The TradeInValue must be 0 or greater.");
            }
            if (vehicle == null)
            {
                throw new ArgumentNullException("Vehicle","The value must be a reference to a Vehicle.");
            }

            TradeInValue = tradeInValue;
            options = new List<VehicleOption>();
            Vehicle = vehicle;
            SalePrice = vehicle.SalePrice;
        }

        /// <summary>
        /// gets and sets trade-in value
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when tradeInValuie is less or equal to 0</exception>
        public decimal TradeInValue
        {
            get => this.tradeInValue;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("TradeInValue", "The value must be 0 or greater.");
                }
                decimal previousTradeInValue = this.tradeInValue;
                this.tradeInValue = value;

                if (previousTradeInValue != this.tradeInValue) { OnTradeInValueChanged(); }
            }
        }

        /// <summary>
        /// gets and sets options list
        /// </summary>
        private List<VehicleOption> Options
        {
            get;
            set;
        }

        /// <summary>
        /// gets and sets vehicle. sale price is automatically set when vehicle's sale price is set.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when vehicle's value is Null.</exception>
        public Vehicle Vehicle
        {
            get => this.vehicle;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Vehicle", "The value must be a reference to a Vehicle.");
                }

                this.vehicle = value;
                this.SalePrice = vehicle.SalePrice;
            }
        }

        /// <summary>
        /// add options to options list.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when vehicle's option value is Null.</exception>
        public void AddVehicleOption(VehicleOption input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("VehicleOption", "The VehicleOption must reference an object.");
            }

            options.Add(input);
            OnVehicleOptionAdded();
        }

        /// <summary>
        /// Remove a option from options list
        /// </summary>
        public void RemoveVehicleOption(VehicleOption vehicleoption)
        {
            options.Remove(vehicleoption);
            OnVehicleOptionRemoved();
        }

        /// <summary>
        /// Get deep copy of option lists.
        /// </summary>
        /// <returns>Vehicle quote's deep copy</returns>
        public List<VehicleOption> GetVehicleQuoteCopy()
        {
            List<VehicleOption> localOptions = new List<VehicleOption>();

            foreach (VehicleOption vehicleOption in this.options)
            {
                localOptions.Add(vehicleOption);
            }

            return localOptions;
        }

        /// <summary>
        /// Get vehicle quote's sum
        /// </summary>
        /// <returns>The vehicle quote's sum</returns>
        public decimal GetVehicleQuoteSum()
        {
            decimal sum = 0;
            foreach (VehicleOption option in options)
            {
                sum += option.UnitPrice * option.Quantity;
            }

            return sum;
        }

        /// <summary>
        /// Get vehicle quote's subtotal
        /// </summary>
        /// <returns>The vehicle quote's subtotal</returns>
        public decimal GetVehicleQuoteSubtotal()
        {
            return GetVehicleQuoteSum() + SalePrice;
        }

        /// <summary>
        /// Get vehicle quote's sales tax
        /// </summary>
        /// <returns>The vehicle quote's sales tax</returns>
        public override decimal CalculateTax()
        {
            decimal taxPercentage = TaxRate;
            decimal subtotal = GetVehicleQuoteSubtotal();
            decimal salesTax = subtotal * taxPercentage;

            return salesTax;
        }

        /// <summary>
        /// Calcualate and return vehicle quote's total
        /// </summary>
        /// <returns>The vehicle quote's total</returns>
        public override decimal CalculateTotal()
        {
            decimal subtotal = GetVehicleQuoteSubtotal();
            decimal salesTax = CalculateTax();
            decimal total = subtotal + salesTax;

            total = Math.Round(total, 2);

            return total;
        }

        /// <summary>
        /// Calcualate and return vehicle quote's amount due
        /// </summary>
        /// <returns>The vehicle quote's amount due</returns>
        public decimal CalculateAmountDue()
        {
            decimal total = CalculateTotal();
            decimal amountDue = total - TradeInValue;

            amountDue = Math.Max(amountDue, 0);
            amountDue = Math.Round(amountDue, 2);

            return amountDue;
        }

        /// <summary>
        /// get vehicle quote's amount due
        /// </summary>
        /// <returns>The vehicle quote's amount due</returns>
        public override string ToString()
        {
            decimal amountDue = CalculateAmountDue();
            string formattedAmountDue = amountDue.ToString("C2");

            return $"{formattedAmountDue}";
        }

        /// <summary>
        /// get the number of options of vehicle quote 
        /// </summary>
        /// <returns>The number of vehicle quote's options </returns>
        public int PrintNumberOfOptions()
        {
            return options.Count;
        }

        /// <summary>
        /// Triggers the TradeInValueChanged event.
        /// This method is Triggered when the TradeInValue property changes.
        /// </summary>
        protected virtual void OnTradeInValueChanged()
        {
            if (TradeInValueChanged != null)
            {
                TradeInValueChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Triggers the VehicleOptionAdded event.
        /// This method is Triggered when a VehicleOption is added
        /// </summary>
        protected virtual void OnVehicleOptionAdded()
        {
            if (VehicleOptionAdded != null)
            {
                VehicleOptionAddedEventArgs eventArgs = new VehicleOptionAddedEventArgs(this.options[this.options.Count-1]);
                VehicleOptionAdded(this, eventArgs);
            }
        }

        /// <summary>
        /// Triggers the VehicleOptionRemoved event.
        /// This method is triggered when a VehicleOption is removed 
        /// </summary>
        protected virtual void OnVehicleOptionRemoved()
        {
            if (VehicleOptionRemoved != null)
            {
                VehicleOptionRemoved(this, EventArgs.Empty);
            }
        }
    }
}
