using System.Collections.Generic;

namespace ShopManagementSystem
{
    internal class CustomerService
    {
        private CustomerRepository customerRepository;

        public CustomerService()
        {
            customerRepository = new CustomerRepository();
        }

        public void AddCustomer(CustomerModel customer)
        {
            customerRepository.SaveToFile(customer);
        }

        public CustomerModel FindCustomerByName(string name)
        {
            List<CustomerModel> customers = customerRepository.LoadCustomers();
            foreach (var c in customers)
            {
                if (c.GetName() == name)
                    return c;
            }
            return null;
        }

        public bool UpdateCustomer(
            string originalName,
            string newName,
            string newPhone,
            int newAge,
            string newAddress
        )
        {
            List<CustomerModel> customers = customerRepository.LoadCustomers();

            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].GetName() == originalName)
                {
                    customers[i].SetName(newName);
                    customers[i].SetPhoneNumber(newPhone);
                    customers[i].SetAge(newAge);
                    customers[i].SetAddress(newAddress);
                    customerRepository.SaveData(customers);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteCustomer(string name)
        {
            List<CustomerModel> customers = customerRepository.LoadCustomers();

            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].GetName() == name)
                {
                    customers.RemoveAt(i);
                    customerRepository.SaveData(customers);
                    return true;
                }
            }
            return false;
        }

        public List<CustomerModel> GetAllCustomers()
        {
            return customerRepository.LoadCustomers();
        }
    }
}
