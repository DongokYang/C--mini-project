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
    /// Represents event arguments for the VehicleOptionAdded event.
    /// </summary>
    public class VehicleOptionAddedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the VehicleOption.
        /// </summary>
        public VehicleOption VehicleOption
        {
            get;
            set;
        }
        /// <summary>
        /// Initializes a new instance of the VehicleOptionAddedEventArgs class.
        /// </summary>
        /// <param name="vehicleOption">The VehicleOption.</param>
        public VehicleOptionAddedEventArgs(VehicleOption vehicleOption)
        {
            this.VehicleOption = vehicleOption;
        }
    }
}
