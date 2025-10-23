using System;

namespace ShopManagementSystem
{
    internal class CustomerModel
    {
        private string name;
        private string phoneNumber;
        private int age;
        private string address;

        public CustomerModel(string name, string phoneNumber, int age, string address)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.age = age;
            this.address = address;
        }

        public string GetName()
        {
            return this.name;
        }

        public string GetPhoneNumber()
        {
            return this.phoneNumber;
        }

        public int GetAge()
        {
            return this.age;
        }

        public string GetAddress()
        {
            return this.address;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }

        public void SetAge(int age)
        {
            this.age = age;
        }

        public void SetAddress(string address)
        {
            this.address = address;
        }

        public string ToDataString()
        {
            return $"{name},{phoneNumber},{age},{address}";
        }

        public override string ToString()
        {
            return $"Name: {name}, Phone: {phoneNumber}, Age: {age}, Address: {address}";
        }
    }
}
