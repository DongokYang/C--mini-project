/*
 * Name: Dongok Yang
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2024-01-21
 * Updated: 2024-03-19
 */
using Business.Dongok.Yang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApp.Dongok.Yang
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Declare and define a variable that references a VehicleQuote object. 
            Vehicle newVehicle = new Vehicle(2020, "Gladiator", "Jeep", PaintColor.Green, 33000);
            VehicleQuote newVehicleQuote = new VehicleQuote(newVehicle, 0.05m, 3000);

            // 2. Define a method in this class that handles the event that occurs when the sale price changes.
            //    The handler method will print: "The sale price changed to {sale-price}."
            //    Subscribe to the event below using the handler method you just defined.            
            newVehicleQuote.SalePriceChanged += Quote_SalePriceChanged;

            // 3. Define a method in this class that handles the event that occurs when an option is added to the quote.
            //    The handler method will print: "The following option was added to the quote:\n{vehicle-option}" 
            //    Subscribe to the event below using the handler method you just defined.
            newVehicleQuote.VehicleOptionAdded += VehicleQuote_VehicleOptionAdded;

            // 4. Define a method in this class that handles the event that occurs when trade-in value has been changed.
            //    The handler method will print "The trade-in value has been changed."
            //    Subscribe to the event below using the handler method you just defined.            
            newVehicleQuote.TradeInValueChanged += VehicleQuote_TradeInValueChanged;

            // 5. Declare and define a variable to reference a new instance of the VehicleOption class.
            VehicleOption firstVehicleOption = new VehicleOption("Custom Seatbelts", 600m, 4);

            // 6. Add the VehicleOption created in the previous statement to the options of the
            //    VehicleQuote instance.
             newVehicleQuote.AddVehicleOption(firstVehicleOption);

            // 7. Add two more VehicleOption objects to the VehicleQuote instance. Only use two statements
            //    to accomplish this step.
            newVehicleQuote.AddVehicleOption(new VehicleOption("Custom Tires", 400m, 4));
            newVehicleQuote.AddVehicleOption(new VehicleOption("Autonomous Driving", 2000m, 1));

            // 8. Change the sale price of the VehicleQuote to a different value than its current state.
            newVehicleQuote.SalePrice = 25000;

            // 9. Add another VehicleOption to the VehicleQuote.
            newVehicleQuote.AddVehicleOption(new VehicleOption("Sun Roof", 1500m, 1));

            // 10. Change the trade-in value of the VehicleQuote to a different value than its current state.
            newVehicleQuote.TradeInValue = 2000;

            // 11. Repeat the previous statement.
            newVehicleQuote.TradeInValue = 2000;
        }

        /// <summary>
        ///  Event handler that is executed when the sale price changes.
        /// </summary>
        static void Quote_SalePriceChanged(object sender, EventArgs e)
        {
            VehicleQuote vehicleQuote = (VehicleQuote)sender;
            Console.WriteLine($"The sale price changed to {vehicleQuote.SalePrice}.");
        }

        /// <summary>
        /// Event handler that is executed when the sale price changes.
        /// </summary>
        static void VehicleQuote_VehicleOptionAdded(object sender, VehicleOptionAddedEventArgs e)
        {
            Console.WriteLine($"The following option was added to the quote:\n{e.VehicleOption}");
        }

        /// <summary>
        /// Event handler that is executed when the sale price changes.
        /// </summary>
        static void VehicleQuote_TradeInValueChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"The trade-in value has been changed.");
        }
    }
}