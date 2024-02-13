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
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dongok.Yang
{
    public class Quote
    {
        private decimal SalePrice;
        private decimal TaxRate;
        private decimal SaleTax;
        private decimal Total;

        public Quote(decimal salePrice, decimal taxRate)
        {
            SalePrice = salePrice;
            TaxRate = taxRate;
            SaleTax = taxRate * salePrice / 100;
            Total = SaleTax + salePrice;
        }
        public Quote()
        {
            SalePrice = 0;
            TaxRate = 0;
        }

        public decimal GetSalePrice()
        {
            return SalePrice;
        }

        public decimal GetTaxRate()
        {
            return TaxRate;
        }

        public void SetSalePrice(decimal newSalePrice)
        {
            SalePrice = newSalePrice;
        }

        public void SetTaxRate(decimal newTaxRate)
        {
            TaxRate = newTaxRate;
        }
        public decimal GetSaleTax()
        {
            return SaleTax;
        }
        public decimal GetTotal()
        {
            return Total;
        }
        public override string ToString()
        {
            return $"Quote: ${Total}";
        }
    }
}