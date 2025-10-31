using System;

namespace ShopManagementSystem
{
    public class OrderItemModel
    {
        private string ProductName;
        private double PriceAtSale;
        private double DiscountAtSale;
        private int Quantity;

        public OrderItemModel(string name, double price, double discount, int quantity)
        {
            this.ProductName = name;
            this.PriceAtSale = price;
            this.DiscountAtSale = discount;
            this.Quantity = quantity;
        }

        public string GetProductName()
        {
            return this.ProductName;
        }

        public double GetPriceAtSale()
        {
            return this.PriceAtSale;
        }

        public double GetDiscountAtSale()
        {
            return this.DiscountAtSale;
        }

        public int GetQuantity()
        {
            return this.Quantity;
        }

        public double GetSubtotal()
        {
            double discountedPrice = PriceAtSale - (PriceAtSale * DiscountAtSale / 100);
            return discountedPrice * Quantity;
        }

        public override string ToString()
        {
            return $"Name: {ProductName}, Price: {PriceAtSale}, Discount: {DiscountAtSale}, Quantity: {Quantity}";
        }
    }
}
