/*
 * Name: Dongok Yang
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2024-01-21
 * Updated: 2024-01-21
 */

using Business.Dongok.Yang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dongok.Yang;

namespace ConsoleApp.Dongok.Yang
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Declare a variable of Quote type.
            Quote firstquote;

            // 2. Define the variable above to a new Quote instance with a sale price
            //    and tax rate of your choosing.
            firstquote = new Quote(5000, 17);

            // 3. Print the state of the Quote object using accessor methods. 
            //    Format of the output is: 
            //    field: value
            Console.WriteLine("SalePrice: " + firstquote.GetSalePrice());
            Console.WriteLine("TaxRate: " + firstquote.GetTaxRate());

            // 4. Print the Quote instance created in a previous step.
            Console.WriteLine(firstquote.ToString());

            // 5. Declare and define a new Quote object with the default state.
            Quote secondquote;

            // 6. Update the state of the second Quote object with a sale price 
            //    between $10,000 - $15,000 and a tax rate between 4.01% and 4.99% 
            //    (inclusive).
            secondquote = new Quote(12020, 4.53m);

            // 7. Declare a variable of List type that can store Vehicle objects.
            List<Vehicle> vehicleList;

            // 8. Define the variable from the previous step to an empty List object.
            vehicleList = new List<Vehicle>();

            // 9. Populate the List with 3 Vehicle objects. Each Vehicle object must 
            //    have unique state.
            Vehicle firstVehicle = new Vehicle(2020, "Genesis G80", "Hyundai", PaintColor.Red, 30000);
            Vehicle secondVehicle = new Vehicle(2022, "Mercedes S", "Mercedes Benz", PaintColor.Blue, 25000);
            Vehicle thirdVehicle = new Vehicle(2024, "Tesla Y", "Tesla", PaintColor.Yellow, 35000);

            vehicleList.Add(firstVehicle);
            vehicleList.Add(secondVehicle);
            vehicleList.Add(thirdVehicle);

            // 10. Print out the number of objects in the List, using the List object
            //     reference.
            Console.WriteLine($"Number of objects in the List: {vehicleList.Count}");

            // 11. Print out the Vehicle objects from the List.
            foreach (Vehicle vehicle in vehicleList)
            {
                Console.WriteLine(vehicle.ToString());
            }
            Console.ReadLine();
        }
    }
}
