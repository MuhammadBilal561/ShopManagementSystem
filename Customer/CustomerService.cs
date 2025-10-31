using System.Collections.Generic;

namespace ShopManagementSystem
{
    internal class CustomerService
    {
        private CustomerRepository customerRepository;
        private CustomerRepoDB _repoDB = new CustomerRepoDB();

        public CustomerService()
        {
            customerRepository = new CustomerRepository();
        }

        public void AddCustomer(CustomerModel customer)
        {
            _repoDB.Create(customer);
            customerRepository.SaveToFile(customer);
        }

        public CustomerModel FindCustomerByID(int id)
        {
            List<CustomerModel> customers = _repoDB.GetAll();
            foreach (var c in customers)
            {
                if (c.GetCustomerID() == id)
                    return c;
            }
            return null;
        }

        public CustomerModel FindCustomerByName(string name)
        {
            //List<CustomerModel> customers = customerRepository.LoadCustomers();
            List<CustomerModel> customers = _repoDB.FindByName(name);
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

        public bool DeleteCustomer(int id)
        {
            List<CustomerModel> customers = _repoDB.GetAll();

            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].GetCustomerID() == id)
                {
                    int deleteId = customers[i].GetCustomerID();
                    customers.RemoveAt(i);
                    _repoDB.Delete(deleteId);
                    return true;
                }
            }
            return false;
        }

        public List<CustomerModel> GetAllCustomers()
        {
            //return customerRepository.LoadCustomers();
            return _repoDB.GetAll();
        }

        public List<CustomerModel> FindCustomerByFirstChar(string firstChar)
        {
            List<CustomerModel> customers = customerRepository.LoadCustomers();
            List<CustomerModel> matchedCustomers = new List<CustomerModel>();
            foreach (var customer in customers)
            {
                if (customer.GetName().StartsWith(firstChar))
                {
                    matchedCustomers.Add(customer);
                }
            }
            //return matchedCustomers;
            return _repoDB.FindByFirstChar(firstChar);

        }

        public CustomerModel FindCustomerByPhoneNumber(string phoneNumber)
        {
            List<CustomerModel> customers = customerRepository.LoadCustomers();
            foreach (var customer in customers)
            {
                if (customer.GetPhoneNumber() == phoneNumber)
                {
                    return customer;
                }
            }
            return null;
        }

        public List<CustomerModel> FindCustomerByAddress(string address)
        {
            List<CustomerModel> customers = customerRepository.LoadCustomers();
            List<CustomerModel> matchedCustomers = new List<CustomerModel>();
            foreach (var customer in customers)
            {
                if (customer.GetAddress() == address)
                {
                    matchedCustomers.Add(customer);
                }
            }
            //return matchedCustomers;
            return _repoDB.FindByAddress(address);

        }

        public List<CustomerModel> FindCustomerByAge(int age)
        {
            List<CustomerModel> customers = customerRepository.LoadCustomers();
            List<CustomerModel> matchedCustomers = new List<CustomerModel>();
            foreach (var customer in customers)
            {
                if (customer.GetAge() == age)
                {
                    matchedCustomers.Add(customer);
                }
            }
            return matchedCustomers;
        }
    }
}
