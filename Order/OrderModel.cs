using System;
using System.Collections.Generic;

namespace ShopManagementSystem
{
    internal class OrderModel
    {
        public int OrderID;
        public List<OrderItemModel> OrderList = new List<OrderItemModel>();
        private string CustomerName;
        private string PhoneNo;
        private int Age;
        private string Address;
        private DateTime OrderDate;

        public OrderModel(string customerName, string phoneNo, int age, string address)
        {
            this.CustomerName = customerName;
            this.PhoneNo = phoneNo;
            this.Age = age;
            this.Address = address;
            this.OrderDate = DateTime.Now;
        }
        public OrderModel(int orderId, string customerName, string phoneNo, int age, string address)
        {
            this.OrderID = orderId;
            this.CustomerName = customerName;
            this.PhoneNo = phoneNo;
            this.Age = age;
            this.Address = address;
            this.OrderDate = DateTime.Now;
        }

        public void AddItems(OrderItemModel item)
        {
            OrderList.Add(item);
        }

        public string GetCustomerName()
        {
            return CustomerName;
        }

        public string GetPhoneNo()
        {
            return PhoneNo;
        }

        public int GetAge()
        {
            return Age;
        }

        public string GetAddress()
        {
            return Address;
        }

        public DateTime GetOrderDate()
        {
            return this.OrderDate;
        }

        public void SetCustomerName(string name)
        {
            this.CustomerName = name;
        }

        public void SetPhoneNo(string phoneNo)
        {
            this.PhoneNo = phoneNo;
        }

        public void SetAge(int age)
        {
            this.Age = age;
        }

        public void SetAddress(string address)
        {
            this.Address = address;
        }

        public void SetOrderDate(DateTime date)
        {
            this.OrderDate = date;
        }

        public double GetTotalAmount()
        {
            double total = 0;
            foreach (OrderItemModel item in OrderList)
            {
                total = total + item.GetSubtotal();
            }
            return total;
        }

        public void SetTotalAmount(double total)
        {
            // This method is intentionally left blank as TotalAmount is calculated dynamically.
        }
    }
}
