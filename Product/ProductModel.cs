using System;
using System.Net;

namespace ShopManagementSystem
{
    internal class ProductModel
    {
        private string Name;
        private double PurchasePrice;
        private double SalePrice;
        private double Discount;

        public ProductModel(string name, double purchasePrice, double salePrice, double discount)
        {
            this.Name = name;
            this.PurchasePrice = purchasePrice;
            this.SalePrice = salePrice;
            this.Discount = discount;
        }

        public string GetName()
        {
            return this.Name;
        }

        public double GetPurchasePrice()
        {
            return this.PurchasePrice;
        }

        public double GetSalePrice()
        {
            return this.SalePrice;
        }

        public double GetDiscount()
        {
            return this.Discount;
        }

        public void SetName(string name)
        {
            this.Name = name;
        }

        public void SetSalePrice(double salePrice)
        {
            this.SalePrice = salePrice;
        }

        public void SetDiscount(double discount)
        {
            this.Discount = discount;
        }

        public string ToDataString()
        {
            return $"{Name},{PurchasePrice},{SalePrice},{Discount}";
        }

        public override string ToString()
        {
            return $"Name: {Name}, Sale Price: {SalePrice}, Discount: {Discount}%";
        }
    }
}
