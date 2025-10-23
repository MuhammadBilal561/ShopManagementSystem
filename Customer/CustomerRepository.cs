using System.Collections.Generic;
using System.IO;

namespace ShopManagementSystem
{
    internal class CustomerRepository
    {
        private const string CUSTOMERS_FILE = "customers.txt";

        public List<CustomerModel> LoadCustomers()
        {
            List<CustomerModel> customers = new List<CustomerModel>();

            if (!File.Exists(CUSTOMERS_FILE))
                return customers;

            using (StreamReader reader = new StreamReader(CUSTOMERS_FILE))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        string name = parts[0];
                        string phone = parts[1];
                        int age = int.Parse(parts[2]);
                        string address = parts[3];
                        customers.Add(new CustomerModel(name, phone, age, address));
                    }
                }
            }
            return customers;
        }

        public void SaveToFile(CustomerModel customer)
        {
            using (StreamWriter writer = new StreamWriter(CUSTOMERS_FILE, true))
            {
                writer.WriteLine(customer.ToDataString());
            }
        }

        public void SaveData(List<CustomerModel> customers)
        {
            File.WriteAllText(CUSTOMERS_FILE, "");
            foreach (var customer in customers)
            {
                SaveToFile(customer);
            }
        }
    }
}
