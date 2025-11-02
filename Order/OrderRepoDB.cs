using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagementSystem.Order
{
    internal class OrderRepoDB
    {
        private string ConvertItemsToString(List<OrderItemModel> items)
        {
            string text = "";

            foreach (OrderItemModel item in items)
            {
                text +=
                    item.GetProductName()
                    + ","
                    + item.GetPriceAtSale()
                    + ","
                    + item.GetQuantity()
                    + "|";
            }

            return text;
        }

        private List<OrderItemModel> ConvertStringToItems(string data)
        {
            List<OrderItemModel> items = new List<OrderItemModel>();

            if (string.IsNullOrEmpty(data))
                return items;

            string[] allItems = data.Split('|'); // split each item

            foreach (string itemText in allItems)
            {
                string[] parts = itemText.Split(',');

                if (parts.Length == 3)
                {
                    string name = parts[0];
                    double price = Convert.ToDouble(parts[1]);
                    int quantity = Convert.ToInt32(parts[2]);

                    OrderItemModel item = new OrderItemModel(name, price, 0.0, quantity);
                    items.Add(item);
                }
            }

            return items;
        }

        public bool Create(OrderModel order)
        {
            string itemsText = ConvertItemsToString(order.OrderList);

            string query =
                "INSERT INTO OrderDetail "
                + "(CustomerName, PhoneNo, Age, Address, OrderDate, ItemsText, TotalAmount) "
                + "VALUES (@CustomerName, @PhoneNo, @Age, @Address, @OrderDate, @ItemsText, @TotalAmount)";

            using (SqlConnection con = new SqlConnection(Utils.DBConnection()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@CustomerName", order.GetCustomerName());
                cmd.Parameters.AddWithValue("@PhoneNo", order.GetPhoneNo());
                cmd.Parameters.AddWithValue("@Age", order.GetAge());
                cmd.Parameters.AddWithValue("@Address", order.GetAddress());
                cmd.Parameters.AddWithValue("@OrderDate", order.GetOrderDate());
                cmd.Parameters.AddWithValue("@ItemsText", itemsText);
                cmd.Parameters.AddWithValue("@TotalAmount", order.GetTotalAmount());
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

       
    }
}
