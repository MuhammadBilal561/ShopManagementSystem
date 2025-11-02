using System;
using System.Net;

namespace ShopManagementSystem
{
    internal class ProductModel
    {
        private int ProductID;
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
        public ProductModel(int productID, string name, double purchasePrice, double salePrice, double discount)
        {
            this.ProductID = productID;
            this.Name = name;
            this.PurchasePrice = purchasePrice;
            this.SalePrice = salePrice;
            this.Discount = discount;
        }

        public int GetProductID()
        {
            return this.ProductID;
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
            return $"{ProductID},{Name},{PurchasePrice},{SalePrice},{Discount}";
        }

        public override string ToString()
        {
            return $"ProductID: {ProductID}, Name: {Name}, Sale Price: {SalePrice}, Discount: {Discount}%";
        }
    }
}
