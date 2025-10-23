using System;
using System.Collections.Generic;
using System.IO;

namespace ShopManagementSystem
{
    internal class OrderRepository
    {
        private const string ORDERS_FILE = "orders.txt";

        public List<OrderModel> LoadOrders()
        {
            List<OrderModel> orders = new List<OrderModel>();

            if (!File.Exists(ORDERS_FILE))
            {
                return orders;
            }

            OrderModel currentOrder = null;

            using (StreamReader reader = new StreamReader(ORDERS_FILE))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("ORDER"))
                    {
                        string[] parts = line.Split(',');

                        string customerName = parts[1];
                        string phoneNo = parts[2];
                        int age = int.Parse(parts[3]);
                        string address = parts[4];
                        DateTime orderDate = DateTime.Parse(parts[5]);

                        currentOrder = new OrderModel(customerName, phoneNo, age, address);
                        currentOrder.SetOrderDate(orderDate);
                        orders.Add(currentOrder);
                    }
                    else if (line.StartsWith("ITEM") && currentOrder != null)
                    {
                        string[] parts = line.Split(',');

                        string productName = parts[1];
                        double price = double.Parse(parts[2]);
                        double discount = double.Parse(parts[3]);
                        int quantity = int.Parse(parts[4]);

                        OrderItemModel item = new OrderItemModel(
                            productName,
                            price,
                            discount,
                            quantity
                        );
                        currentOrder.AddItems(item);
                    }
                    else if (line.StartsWith("---"))
                    {
                        currentOrder = null;
                    }
                }
            }

            return orders;
        }

        public void SaveOrders(List<OrderModel> orders)
        {
            using (StreamWriter writer = new StreamWriter(ORDERS_FILE))
            {
                foreach (OrderModel order in orders)
                {
                    writer.WriteLine(
                        $"ORDER,{order.GetCustomerName()},{order.GetPhoneNo()},{order.GetAge()},{order.GetAddress()},{order.GetOrderDate()}"
                    );

                    foreach (OrderItemModel item in order.OrderList)
                    {
                        writer.WriteLine(
                            $"ITEM,{item.GetProductName()},{item.GetPriceAtSale()},{item.GetDiscountAtSale()},{item.GetQuantity()}"
                        );
                    }

                    writer.WriteLine("---");
                }
            }
        }
    }
}
