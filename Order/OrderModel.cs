using System;
using System.Collections.Generic;

namespace ShopManagementSystem
{
    internal class OrderModel
    {
        public List<OrderItemModel> OrderList = new List<OrderItemModel>();
        private string customerName;
        private string phoneNo;
        private int age;
        private string address;
        private DateTime orderDate;

        public OrderModel(string customerName, string phoneNo, int age, string address)
        {
            this.customerName = customerName;
            this.phoneNo = phoneNo;
            this.age = age;
            this.address = address;
            this.orderDate = DateTime.Now;
        }

        public void AddItems(OrderItemModel item)
        {
            OrderList.Add(item);
        }

        public string GetCustomerName()
        {
            return customerName;
        }

        public string GetPhoneNo()
        {
            return phoneNo;
        }

        public int GetAge()
        {
            return age;
        }

        public string GetAddress()
        {
            return address;
        }

        public DateTime GetOrderDate()
        {
            return this.orderDate;
        }

        public void SetCustomerName(string name)
        {
            this.customerName = name;
        }

        public void SetPhoneNo(string phoneNo)
        {
            this.phoneNo = phoneNo;
        }

        public void SetAge(int age)
        {
            this.age = age;
        }

        public void SetAddress(string address)
        {
            this.address = address;
        }

        public void SetOrderDate(DateTime date)
        {
            this.orderDate = date;
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
    }
}
