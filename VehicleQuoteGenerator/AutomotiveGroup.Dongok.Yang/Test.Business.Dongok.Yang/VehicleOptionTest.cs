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
using System.IO;

namespace Test.Business.Dongok.Yang
{
    [TestClass]
    public class VehicleOptionTest
    {
        [TestMethod]
        public void VehicleOption_DescriptionHasNoContent_ThrowsException()
        {
            // Arrange
            string description = " ";
            decimal unitPrice = 300m;
            int quantity = 1;

            // act & assert
            ArgumentException exception = Assert.ThrowsException<ArgumentException>(() =>
            new VehicleOption(description, unitPrice, quantity));

            // assert exception state
            Assert.AreEqual("Description", exception.ParamName);
            Assert.AreEqual("The description must contain non-whitespace characters.", GetExceptionMessage(exception.Message));
        }

        [TestMethod]
        public void VehicleOption_PriceLessThanZero_ThrowsException()
        {
            // Arrange
            string description = "Sunroof";
            decimal unitPrice = -300m;
            int quantity = 1;

            // act & assert
            ArgumentOutOfRangeException exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            new VehicleOption(description, unitPrice, quantity));

            // assert exception state
            Assert.AreEqual("UnitPrice", exception.ParamName);
            Assert.AreEqual("The unit price must be 0 or greater.", GetExceptionMessage(exception.Message));
        }

        [TestMethod]
        public void VehicleOption_QuantityLessThanZero_ThrowsException()
        {
            // Arrange
            string description = "Sunroof";
            decimal unitPrice = 300m;
            int quantity = -1;

            // act & assert
            ArgumentOutOfRangeException exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            new VehicleOption(description, unitPrice, quantity));

            // assert exception state
            Assert.AreEqual("Quantity", exception.ParamName);
            Assert.AreEqual("The quantity must be 0 or greater.", GetExceptionMessage(exception.Message));
        }

        [TestMethod]
        public void VehicleOption_ValidArgumentValues_SuccesfulInstantiation()
        {
            // Arrange
            string description = "Sunroof";
            decimal unitPrice = 300m;
            int quantity = 1;

            // act & assert
            VehicleOption vehicleOption = new VehicleOption(description, unitPrice, quantity);

            // assert
            Assert.AreEqual(description, vehicleOption.Description);
            Assert.AreEqual(unitPrice, vehicleOption.UnitPrice);
            Assert.AreEqual(quantity, vehicleOption.Quantity);
        }

        [TestMethod]
        public void VehicleOption_ToString_ReturnsExpectedString()
        {
            // Arrange
            string description = "Sunroof";
            decimal unitPrice = 300m;
            int quantity = 1;

            VehicleOption vehicleOption = new VehicleOption(description, unitPrice, quantity);

            // Act
            string actual = vehicleOption.ToString();
            string expected = "Sunroof x 1 @ $300.00";

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
