/*
 * Name: Dongok Yang
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2024-01-21
 * Updated: 2024-01-21
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dongok.Yang
{
    public class Vehicle
    {
        private int Year;
        private string Model;
        private string Manufacturer;
        private PaintColor Color;
        private decimal Sale_Price;
        public Vehicle(int year, string model, string manufacturer, PaintColor color, decimal sale_Price)
        {
            Year = year;
            Model = model;
            Manufacturer = manufacturer;
            Color = color;
            Sale_Price = sale_Price;
        }
        public int GetYear()
        {
            return Year;
        }
        public string GetModel()
        {
            return Model;
        }
        public string GetManufacturer()
        {
            return Manufacturer;
        }
        public decimal GetSalePrice()
        {
            return Sale_Price;
        }
        public override string ToString()
        {
            return $"{Year}, {Manufacturer}, {Model}, {Color}";
        }

    }
}
