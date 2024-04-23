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

namespace Test.Business.Dongok.Yang
{
    [TestClass]
    public class VehicleQuoteTest
    {

        [TestMethod]
        public void VehicleQuote_TaxRateLessThanZero_ThrowsException()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);
            decimal taxRate = -0.05m;
            decimal tradeInValue = 3000;

            // Act & Assert
            ArgumentOutOfRangeException exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            new VehicleQuote(vehicle, taxRate, tradeInValue));

            // assert exception state
            Assert.AreEqual("TaxRate", exception.ParamName);
            Assert.AreEqual("The TaxRate must be within the range of 0 to 1 (inclusive).", GetExceptionMessage(exception.Message));
        }

        [TestMethod]
        public void VehicleQuote_TaxRateGreaterThanZero_ThrowsException()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);
            decimal taxRate = 1.05m;
            decimal tradeInValue = 3000;

            // Act & Assert
            ArgumentOutOfRangeException exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            new VehicleQuote(vehicle, taxRate, tradeInValue));

            // assert exception state
            Assert.AreEqual("TaxRate", exception.ParamName);
            Assert.AreEqual("The TaxRate must be within the range of 0 to 1 (inclusive).", GetExceptionMessage(exception.Message));
        }

        [TestMethod]
        public void VehicleQuote_VehicleISNull_ThrowsException()
        {
            // Arrange
            Vehicle vehicle = null;
            decimal taxRate = 0.05m;
            decimal tradeInValue = 3000;

            // Act & Assert
            NullReferenceException exception = Assert.ThrowsException<NullReferenceException>(() =>
            new VehicleQuote(vehicle, taxRate, tradeInValue));

            // assert exception state
            Assert.AreEqual("NullReferenceException", exception.GetType().Name);
        }

        [TestMethod]
        public void VehicleQuote_TradeinValueLessThanZero_ThrowsException()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);
            decimal taxRate = 0.05m;
            decimal tradeInValue = -3000;

            // Act & Assert
            ArgumentOutOfRangeException exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            new VehicleQuote(vehicle, taxRate, tradeInValue));

            // assert exception state
            Assert.AreEqual("TradeInValue", exception.ParamName);
            Assert.AreEqual("The TradeInValue must be 0 or greater.", GetExceptionMessage(exception.Message));
        }

        [TestMethod]
        public void VehicleQuote_InitializedWithoutTradeinValue_SuccesfulInstantiation()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);
            decimal taxRate = 0.05m;
            List<VehicleOption> options = new List<VehicleOption>();

            // Act
            VehicleQuote vehiclequote = new VehicleQuote(vehicle, taxRate);

            PrivateObject target = new PrivateObject(vehiclequote);
            List<VehicleOption> optionsActual = (List<VehicleOption>)target.GetField("options");
            Vehicle vehicleActual = (Vehicle)target.GetField("vehicle");
            decimal tradeInValue = (decimal)target.GetField("tradeInValue");

            Type baseType = typeof(Quote);
            FieldInfo fieldInfo = baseType.GetField("salePrice", BindingFlags.NonPublic | BindingFlags.Instance);
            decimal actualSalePrice = (decimal)fieldInfo.GetValue(vehiclequote);

            FieldInfo fieldInfo2 = baseType.GetField("taxRate", BindingFlags.NonPublic | BindingFlags.Instance);
            decimal actualTaxRate = (decimal)fieldInfo2.GetValue(vehiclequote);

            // Assert
            Assert.AreEqual(vehicle, vehicleActual);
            Assert.AreEqual(taxRate, actualTaxRate);
            Assert.AreEqual(0, optionsActual.Count);
            Assert.AreEqual(salePrice, actualSalePrice);
            Assert.AreEqual(0, tradeInValue);
        }

        [TestMethod]
        public void VehicleQuote_InitializingSucceed_SuccesfulInstantiation()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);
            decimal taxRate = 0.05m;
            List<VehicleOption> options = new List<VehicleOption>();
            decimal tradeInValue = 100000;

            // Act
            VehicleQuote vehiclequote = new VehicleQuote(vehicle, taxRate, tradeInValue);

            PrivateObject target = new PrivateObject(vehiclequote);
            List<VehicleOption> optionsActual = (List<VehicleOption>)target.GetField("options");
            Vehicle vehicleActual = (Vehicle)target.GetField("vehicle");
            decimal tradeInValueActual = (decimal)target.GetField("tradeInValue");

            Type baseType = typeof(Quote);
            FieldInfo fieldInfo = baseType.GetField("salePrice", BindingFlags.NonPublic | BindingFlags.Instance);
            decimal actualSalePrice = (decimal)fieldInfo.GetValue(vehiclequote);

            FieldInfo fieldInfo2 = baseType.GetField("taxRate", BindingFlags.NonPublic | BindingFlags.Instance);
            decimal actualTaxRate = (decimal)fieldInfo2.GetValue(vehiclequote);

            // Assert
            Assert.AreEqual(vehicle, vehicleActual);
            Assert.AreEqual(taxRate, actualTaxRate);
            Assert.AreEqual(0, optionsActual.Count);
            Assert.AreEqual(salePrice, actualSalePrice);
            Assert.AreEqual(tradeInValue, tradeInValueActual);
        }

        [TestMethod]
        public void VehicleQuote_GetSalePrice_ExpectedSalePrice()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);
            decimal taxRate = 0.05m;
            List<VehicleOption> options = new List<VehicleOption>();
            decimal tradeInValue = 100000;

            // Act
            VehicleQuote vehiclequote = new VehicleQuote(vehicle, taxRate, tradeInValue);

            Type baseType = typeof(Quote);
            FieldInfo fieldInfo = baseType.GetField("salePrice", BindingFlags.NonPublic | BindingFlags.Instance);
            decimal actualSalePrice = (decimal)fieldInfo.GetValue(vehiclequote);

            // Assert
            Assert.AreEqual(salePrice, actualSalePrice);
        }

        [TestMethod]
        public void VehicleQuote_SetInvalidSalePrice_ThrowsException()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);
            decimal taxRate = 0.05m;
            List<VehicleOption> options = new List<VehicleOption>();
            decimal tradeInValue = 100000;
            VehicleQuote vehiclequote = new VehicleQuote(vehicle, taxRate, tradeInValue);

            // Act & Assert
            ArgumentOutOfRangeException exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => vehiclequote.SalePrice = -1);

            // Assert exception state
            Assert.AreEqual("SalePrice", exception.ParamName);
            Assert.AreEqual("The value must be greater than 0.", GetExceptionMessage(exception.Message));

            // Reflection & Obtain object state
            Type baseType = typeof(Quote);
            FieldInfo fieldInfo = baseType.GetField("salePrice", BindingFlags.NonPublic | BindingFlags.Instance);
            decimal actualSalePrice = (decimal)fieldInfo.GetValue(vehiclequote);

            // Assert
            Assert.AreEqual(salePrice, actualSalePrice);
        }

        [TestMethod]
        public void VehicleQuote_SetValidSalePrice_ExpectedSalePrice()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);
            decimal taxRate = 0.05m;
            List<VehicleOption> options = new List<VehicleOption>();
            decimal tradeInValue = 100000;
            VehicleQuote vehiclequote = new VehicleQuote(vehicle, taxRate, tradeInValue);

            // Act 
            Type baseType = typeof(Quote);
            FieldInfo fieldInfo = baseType.GetField("salePrice", BindingFlags.NonPublic | BindingFlags.Instance);
            decimal actualSalePrice = (decimal)fieldInfo.GetValue(vehiclequote);

            // Assert
            Assert.AreEqual(salePrice, actualSalePrice);
        }

        [TestMethod]
        public void VehicleQuote_UpdateSalePrice_ExpectedState()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);
            decimal taxRate = 0.05m;
            List<VehicleOption> options = new List<VehicleOption>();
            decimal tradeInValue = 100000;
            VehicleQuote vehiclequote = new VehicleQuote(vehicle, taxRate, tradeInValue);

            // Act 
            decimal newSalePrice = 35000;
            vehiclequote.SalePrice = newSalePrice;

            Type baseType = typeof(Quote);
            FieldInfo fieldInfo = baseType.GetField("salePrice", BindingFlags.NonPublic | BindingFlags.Instance);
            decimal actualSalePrice = (decimal)fieldInfo.GetValue(vehiclequote);

            // Assert
            Assert.AreEqual(actualSalePrice, newSalePrice);
        }

        [TestMethod]
        public void VehicleQuote_GetVehicle_ExpectedVehicle()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);
            decimal taxRate = 0.05m;
            List<VehicleOption> options = new List<VehicleOption>();
            decimal tradeInValue = 100000;

            // Act
            VehicleQuote vehiclequote = new VehicleQuote(vehicle, taxRate, tradeInValue);
            PrivateObject target = new PrivateObject(vehiclequote);
            Vehicle vehicleActual = (Vehicle)target.GetField("vehicle");

            // Assert
            Assert.AreEqual(vehicle, vehicleActual);
        }
        [TestMethod]
        public void VehicleQuote_SetInvalidVehicle_ThrowsException()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);
            decimal taxRate = 0.05m;
            List<VehicleOption> options = new List<VehicleOption>();
            decimal tradeInValue = 100000;
            VehicleQuote vehiclequote = new VehicleQuote(vehicle, taxRate, tradeInValue);

            // Act & Assert
            ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(() => vehiclequote.Vehicle = null);

            // Assert exception state
            Assert.AreEqual("Vehicle", exception.ParamName);
            Assert.AreEqual("The value must be a reference to a Vehicle.", GetExceptionMessage(exception.Message));

            // Reflection & Obtain object state
            PrivateObject target = new PrivateObject(vehiclequote);
            Vehicle vehicleActual = (Vehicle)target.GetField("vehicle");

            // Assert
            Assert.AreEqual(vehicle, vehicleActual);
        }

        [TestMethod]
        public void VehicleQuote_UpdateVehicle_ExpectedState()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);
            decimal taxRate = 0.05m;
            List<VehicleOption> options = new List<VehicleOption>();
            decimal tradeInValue = 100000;
            VehicleQuote vehiclequote = new VehicleQuote(vehicle, taxRate, tradeInValue);

            // Act 
            int newYear = 2010;
            string newModel = "genesis";
            string newManufacturer = "Hyundai";
            PaintColor newColor = PaintColor.Red;
            decimal newSalePrice = 43000;

            Vehicle newVehicle = new Vehicle(newYear, newModel, newManufacturer, newColor, newSalePrice);

            vehiclequote.Vehicle = newVehicle;

            // Reflection & Obtain object state
            PrivateObject target = new PrivateObject(vehiclequote);
            Vehicle vehicleActual = (Vehicle)target.GetField("vehicle");

            Type baseType = typeof(Quote);
            FieldInfo fieldInfo = baseType.GetField("salePrice", BindingFlags.NonPublic | BindingFlags.Instance);
            decimal actualSalePrice = (decimal)fieldInfo.GetValue(vehiclequote);

            // Assert
            Assert.AreEqual(newVehicle, vehicleActual);
            Assert.AreEqual(newSalePrice, actualSalePrice);
        }

        [TestMethod]
        public void VehicleQuote_GetTradeInValue_ExpectedTradeInValue()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);
            decimal taxRate = 0.05m;
            List<VehicleOption> options = new List<VehicleOption>();
            decimal tradeInValue = 100000;

            // Act
            VehicleQuote vehiclequote = new VehicleQuote(vehicle, taxRate, tradeInValue);

            PrivateObject target = new PrivateObject(vehiclequote);
            decimal tradeInValueActual = (decimal)target.GetField("tradeInValue");

            // Assert
            Assert.AreEqual(tradeInValue, tradeInValueActual);
        }

        [TestMethod]
        public void VehicleQuote_SetInvalidTradeInValue_ThrowsException()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);
            decimal taxRate = 0.05m;
            List<VehicleOption> options = new List<VehicleOption>();
            decimal tradeInValue = 100000;
            VehicleQuote vehiclequote = new VehicleQuote(vehicle, taxRate, tradeInValue);

            // Act & Assert
            ArgumentOutOfRangeException exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => vehiclequote.TradeInValue = -1);

            // Assert exception state
            Assert.AreEqual("TradeInValue", exception.ParamName);
            Assert.AreEqual("The value must be 0 or greater.", GetExceptionMessage(exception.Message));

            // Reflection & Obtain object state
            PrivateObject target = new PrivateObject(vehiclequote);
            decimal tradeInValueActual = (decimal)target.GetField("tradeInValue");

            // Assert
            Assert.AreEqual(tradeInValue, tradeInValueActual);
        }

        [TestMethod]
        public void VehicleQuote_UpdateTradeInValue_ExpectedState()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);
            decimal taxRate = 0.05m;
            List<VehicleOption> options = new List<VehicleOption>();
            decimal tradeInValue = 100000;
            VehicleQuote vehiclequote = new VehicleQuote(vehicle, taxRate, tradeInValue);

            // Act 
            decimal newTradeInValue = 35000;
            vehiclequote.TradeInValue = newTradeInValue;
            PrivateObject target = new PrivateObject(vehiclequote);
            decimal tradeInValueActual = (decimal)target.GetField("tradeInValue");

            // Assert
            Assert.AreEqual(tradeInValueActual, newTradeInValue);
        }

        [TestMethod]
        public void VehicleQuote_AddNullOption_ThrowsException()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);
            decimal taxRate = 0.05m;
            List<VehicleOption> options = new List<VehicleOption>();
            decimal tradeInValue = 100000;

            // Act
            VehicleQuote vehiclequote = new VehicleQuote(vehicle, taxRate, tradeInValue);
            ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(() => vehiclequote.AddVehicleOption(null));

            // Assert
            Assert.AreEqual("VehicleOption", exception.ParamName);
            Assert.AreEqual("The VehicleOption must reference an object.", GetExceptionMessage(exception.Message));
        }
        [TestMethod]
        public void VehicleQuote_AddOptionSucceed_OptionAddedToList()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);
            decimal taxRate = 0.05m;
            List<VehicleOption> options = new List<VehicleOption>();
            decimal tradeInValue = 100000;

            // Act
            VehicleQuote vehiclequote = new VehicleQuote(vehicle, taxRate, tradeInValue);

            VehicleOption firstVehicleOption = new VehicleOption("Custom Seatbelts", 600m, 4);
            vehiclequote.AddVehicleOption(firstVehicleOption);

            PrivateObject target = new PrivateObject(vehiclequote);
            List<VehicleOption> optionsActual = (List<VehicleOption>)target.GetField("options");

            // Assert
            Assert.AreEqual(1, optionsActual.Count);
        }

        [TestMethod]
        public void VehicleQuote_RemoveOptionSucceed_OptionRemovedFromList()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);
            decimal taxRate = 0.05m;
            List<VehicleOption> options = new List<VehicleOption>();
            decimal tradeInValue = 100000;

            // Act
            VehicleQuote vehiclequote = new VehicleQuote(vehicle, taxRate, tradeInValue);

            VehicleOption firstVehicleOption = new VehicleOption("Custom Seatbelts", 600m, 4);
            vehiclequote.AddVehicleOption(firstVehicleOption);

            PrivateObject target = new PrivateObject(vehiclequote);
            List<VehicleOption> optionsAdded = (List<VehicleOption>)target.GetField("options");
            Assert.AreEqual(1, optionsAdded.Count);

            vehiclequote.RemoveVehicleOption(firstVehicleOption);
            List<VehicleOption> optionsActual = (List<VehicleOption>)target.GetField("options");
            // Assert
            Assert.AreEqual(0, optionsActual.Count);
        }

        [TestMethod]
        public void VehicleQuote_GetOptionSucceed_ReturnExpectedValue()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);
            decimal taxRate = 0.05m;
            List<VehicleOption> options = new List<VehicleOption>();
            decimal tradeInValue = 100000;

            // Act
            VehicleQuote vehiclequote = new VehicleQuote(vehicle, taxRate, tradeInValue);
            VehicleOption firstVehicleOption = new VehicleOption("Custom Seatbelts", 600m, 4);
            vehiclequote.AddVehicleOption(firstVehicleOption);

            List<VehicleOption> optionsActual = vehiclequote.GetVehicleQuoteCopy();
            options.Add(firstVehicleOption);

            // Assert
            Assert.AreNotSame(options, optionsActual);
        }

        [TestMethod]
        public void VehicleQuote_GetTotalOptionSucceed_ReturnExpectedValue()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);
            decimal taxRate = 0.05m;
            List<VehicleOption> options = new List<VehicleOption>();
            decimal tradeInValue = 100000;

            VehicleQuote vehiclequote = new VehicleQuote(vehicle, taxRate, tradeInValue);
            VehicleOption firstVehicleOption = new VehicleOption("Custom Seatbelts", 600m, 4);
            vehiclequote.AddVehicleOption(firstVehicleOption);

            // Act
            decimal optionSumActual = vehiclequote.GetVehicleQuoteSum();
            decimal optionSumExpected = 2400;

            // Assert
            Assert.AreEqual(optionSumExpected, optionSumActual);
        }

        [TestMethod]
        public void VehicleQuote_GetSubtotalSucceed_ReturnExpectedValue()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);
            decimal taxRate = 0.05m;
            List<VehicleOption> options = new List<VehicleOption>();
            decimal tradeInValue = 100000;

            VehicleQuote vehiclequote = new VehicleQuote(vehicle, taxRate, tradeInValue);
            VehicleOption firstVehicleOption = new VehicleOption("Custom Seatbelts", 600m, 4);
            vehiclequote.AddVehicleOption(firstVehicleOption);

            // Act
            decimal subtotalActual = vehiclequote.GetVehicleQuoteSubtotal();
            decimal subtotalExpected = 35400;

            // Assert
            Assert.AreEqual(subtotalActual, subtotalExpected);
        }
        [TestMethod]
        public void VehicleQuote_GetSaleTaxSucceed_ReturnExpectedValue()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);
            decimal taxRate = 0.05m;
            List<VehicleOption> options = new List<VehicleOption>();
            decimal tradeInValue = 100000;

            VehicleQuote vehiclequote = new VehicleQuote(vehicle, taxRate, tradeInValue);
            VehicleOption firstVehicleOption = new VehicleOption("Custom Seatbelts", 600m, 4);
            vehiclequote.AddVehicleOption(firstVehicleOption);

            // Act
            decimal SaleTaxActual = vehiclequote.CalculateTax();
            decimal SaleTaxExpected = 1770.00m;

            // Assert
            Assert.AreEqual(SaleTaxActual, SaleTaxExpected);
        }
        [TestMethod]
        public void VehicleQuote_GetTotalSucceed_ReturnExpectedValue()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);
            decimal taxRate = 0.05m;
            List<VehicleOption> options = new List<VehicleOption>();
            decimal tradeInValue = 100000;

            VehicleQuote vehiclequote = new VehicleQuote(vehicle, taxRate, tradeInValue);
            VehicleOption firstVehicleOption = new VehicleOption("Custom Seatbelts", 600m, 4);
            vehiclequote.AddVehicleOption(firstVehicleOption);

            // Act
            decimal TotalActual = vehiclequote.CalculateTotal();
            decimal TotalExpected = 37170.00m;

            // Assert
            Assert.AreEqual(TotalActual, TotalExpected);
        }
        [TestMethod]
        public void VehicleQuote_GetAmountDue_ReturnExpectedValue()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);
            decimal taxRate = 0.05m;
            List<VehicleOption> options = new List<VehicleOption>();
            decimal tradeInValue = 10000;

            VehicleQuote vehiclequote = new VehicleQuote(vehicle, taxRate, tradeInValue);
            VehicleOption firstVehicleOption = new VehicleOption("Custom Seatbelts", 600m, 4);
            vehiclequote.AddVehicleOption(firstVehicleOption);

            // Act
            decimal CalculateAmountDueActual = vehiclequote.CalculateAmountDue();
            decimal CalculateAmountDueExpected = 27170.00m;

            // Assert
            Assert.AreEqual(CalculateAmountDueActual, CalculateAmountDueExpected);
        }
        [TestMethod]
        public void VehicleQuote_ToString_ReturnExpectedValue()
        {
            // Arrange
            int year = 2000;
            string model = "Gladiator";
            string manufacturer = "Jeep";
            PaintColor color = PaintColor.Green;
            decimal salePrice = 33000;

            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);
            decimal taxRate = 0.05m;
            List<VehicleOption> options = new List<VehicleOption>();
            decimal tradeInValue = 10000;

            VehicleQuote vehiclequote = new VehicleQuote(vehicle, taxRate, tradeInValue);
            VehicleOption firstVehicleOption = new VehicleOption("Custom Seatbelts", 600m, 4);
            vehiclequote.AddVehicleOption(firstVehicleOption);

            // Act
            string ToStringActual = vehiclequote.ToString();
            string ToStringExpected = "$27,170.00";

            // Assert
            Assert.AreEqual(ToStringActual, ToStringExpected);
        }
        /* Utility Methods */
        static string GetExceptionMessage(string exceptionMessage)
        {
            return new StringReader(exceptionMessage).ReadLine();
        }
    }
}
