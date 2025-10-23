using System;

namespace ShopManagementSystem
{
    public class OrderItemModel
    {
        private string productName;
        private double priceAtSale;
        private double discountAtSale;
        private int quantity;

        public OrderItemModel(string name, double price, double discount, int quantity)
        {
            this.productName = name;
            this.priceAtSale = price;
            this.discountAtSale = discount;
            this.quantity = quantity;
        }

        public string GetProductName()
        {
            return this.productName;
        }

        public double GetPriceAtSale()
        {
            return this.priceAtSale;
        }

        public double GetDiscountAtSale()
        {
            return this.discountAtSale;
        }

        public int GetQuantity()
        {
            return this.quantity;
        }

        public double GetSubtotal()
        {
            double discountedPrice = priceAtSale - (priceAtSale * discountAtSale / 100);
            return discountedPrice * quantity;
        }

        public override string ToString()
        {
            return $"Name: {productName}, Price: {priceAtSale}, Discount: {discountAtSale}, Quantity: {quantity}";
        }
    }
}
