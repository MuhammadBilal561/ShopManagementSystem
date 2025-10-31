using System;

namespace ShopManagementSystem
{
    internal class CustomerModel
    {
        private int CustomerID;
        private string Name;
        private string PhoneNumber;
        private int Age;
        private string Address;

        public CustomerModel(string name, string phoneNumber, int age, string address)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.Age = age;
            this.Address = address;
        }

        public CustomerModel(int customerID, string name, string phoneNumber, int age, string address)
        {
            this.CustomerID = customerID;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.Age = age;
            this.Address = address;
        }

        public int GetCustomerID()
        {
            return this.CustomerID;
        }

        public string GetName()
        {
            return this.Name;
        }

        public string GetPhoneNumber()
        {
            return this.PhoneNumber;
        }

        public int GetAge()
        {
            return this.Age;
        }

        public string GetAddress()
        {
            return this.Address;
        }

        public void SetName(string name)
        {
            this.Name = name;
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
        }

        public void SetAge(int age)
        {
            this.Age = age;
        }

        public void SetAddress(string address)
        {
            this.Address = address;
        }

        public string ToDataString()
        {
            return $"{Name},{PhoneNumber},{Age},{Address}";
        }

        public override string ToString()
        {
            return $"ID: {CustomerID}, Name: {Name}, Phone: {PhoneNumber}, Age: {Age}, Address: {Address}";
        }
    }
}
