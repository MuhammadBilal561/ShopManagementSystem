using System;
using System.Net;

namespace ShopManagementSystem
{
    internal class ProductModel
    {
        private string name;
        private double purchasePrice;
        private double salePrice;
        private double discount;

        public ProductModel(string name, double purchasePrice, double salePrice, double discount)
        {
            this.name = name;
            this.purchasePrice = purchasePrice;
            this.salePrice = salePrice;
            this.discount = discount;
        }

        public string GetName()
        {
            return this.name;
        }

        public double GetPurchasePrice()
        {
            return this.purchasePrice;
        }

        public double GetSalePrice()
        {
            return this.salePrice;
        }

        public double GetDiscount()
        {
            return this.discount;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetSalePrice(double salePrice)
        {
            this.salePrice = salePrice;
        }

        public void SetDiscount(double discount)
        {
            this.discount = discount;
        }

        public string ToDataString()
        {
            return $"{name},{purchasePrice},{salePrice},{discount}";
        }

        public override string ToString()
        {
            return $"Name: {name}, Sale Price: {salePrice}, Discount: {discount}%";
        }
    }
}
