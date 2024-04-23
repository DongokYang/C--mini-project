/*
 * Name: Dongok Yang
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2024-01-21
 * Updated: 2024-03-19
 */
using Business.Dongok.Yang;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Test.Business.Dongok.Yang
{
    [TestClass]
    public class VehicleTests
    {
        [TestMethod]
        public void Vehicle_YearLessThanMinimum_ThrowsException()
        {
            // Arrange
            int year = 1800;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            // act & assert
            ArgumentOutOfRangeException exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => 
            new Vehicle(year, model,manufacturer,color,salePrice));

            // assert exception state
            Assert.AreEqual("Year", exception.ParamName);
            Assert.AreEqual($"The year must be in the range of 1950 to {DateTime.Now.Year + 1}.", GetExceptionMessage(exception.Message));
        }

        [TestMethod]
        public void Vehicle_YearGreaterThanMaximum_ThrowsException()
        {
            // Arrange
            int year = 2500;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            // act & assert
            ArgumentOutOfRangeException exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => 
            new Vehicle(year, model, manufacturer, color, salePrice));

            // assert exception state
            Assert.AreEqual("Year", exception.ParamName);
            Assert.AreEqual($"The year must be in the range of 1950 to {DateTime.Now.Year + 1}.", GetExceptionMessage(exception.Message));
        }

        [TestMethod]
        public void Vehicle_ManufacturerHasNoContent_ThrowsException()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = " ";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            // act & assert
            ArgumentException exception = Assert.ThrowsException<ArgumentException>(() =>
            new Vehicle(year, model, manufacturer, color, salePrice));

            // assert exception state
            Assert.AreEqual("Manufacturer", exception.ParamName); 
            Assert.AreEqual("The manufacturer must contain non-whitespace characters.", GetExceptionMessage(exception.Message));
        }

        [TestMethod]
        public void Vehicle_ModelHasNoContent_ThrowsException()
        {
            // Arrange
            int year = 2000;
            string model = " ";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            // act & assert
            ArgumentException exception = Assert.ThrowsException<ArgumentException>(() =>
            new Vehicle(year, model, manufacturer, color, salePrice));

            // assert exception state
            Assert.AreEqual("Model", exception.ParamName);
            Assert.AreEqual("The model must contain non-whitespace characters.", GetExceptionMessage(exception.Message));
        }

        [TestMethod]
        public void Vehicle_SalePriceLessThanZero_ThrowsException()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = -33000;

            // act & assert
            ArgumentOutOfRangeException exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            new Vehicle(year, model, manufacturer, color, salePrice));

            // assert exception state
            Assert.AreEqual("SalePrice", exception.ParamName);
            Assert.AreEqual("The sale_Price must be 0 or greater.", GetExceptionMessage(exception.Message));
        }


        [TestMethod]
        public void Vehicle_ValidArgumentValues_SuccesfulInstantiation()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            // act & assert
            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);

            // assert
            Assert.AreEqual(year, vehicle.Year);
            Assert.AreEqual(model, vehicle.Model);
            Assert.AreEqual(manufacturer, vehicle.Manufacturer);
            Assert.AreEqual(color, vehicle.Color);
            Assert.AreEqual(salePrice, vehicle.SalePrice);
        }

        [TestMethod]
        public void Vehicle_ToString_ReturnsExpectedString()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);

            // Act
            string actual = vehicle.ToString();
            string expected = "2000, Jeep, Gladiator, Green";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /* Utility Methods */
        static string GetExceptionMessage(string exceptionMessage)
        {
            return new StringReader(exceptionMessage).ReadLine();
        }
    }
}
