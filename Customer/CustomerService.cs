using System.Collections.Generic;

namespace ShopManagementSystem
{
    internal class CustomerService
    {
        private CustomerRepository fileRepo = new CustomerRepository();
        private CustomerRepoDB dbRepo = new CustomerRepoDB();

        public void AddCustomer(CustomerModel customer)
        {
            bool dbResult = dbRepo.Create(customer);
            if (dbResult)
            {
                //file backup
                fileRepo.SaveToFile(customer);
            }
        }

        public CustomerModel FindCustomerByID(int id)
        {
            return dbRepo.FindByID(id);
        }

        public List<CustomerModel> FindCustomerByName(string name)
        {
            List<CustomerModel> customers = dbRepo.FindByName(name);
            if (customers.Count == 0)
            {
                //  file
                List<CustomerModel> fileCustomers = fileRepo.LoadCustomers();
                List<CustomerModel> matched = new List<CustomerModel>();
                foreach (var c in fileCustomers)
                {
                    if (c.GetName() == name)
                        matched.Add(c);
                }
                return matched;
            }
            return customers;
        }

        public bool UpdateCustomer(
            int customerID,
            string newName,
            string newPhone,
            int newAge,
            string newAddress
        )
        {
            List<CustomerModel> customers = dbRepo.GetAll();

            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].GetCustomerID() == customerID)
                {
                    customers[i].SetName(newName);
                    customers[i].SetPhoneNumber(newPhone);
                    customers[i].SetAge(newAge);
                    customers[i].SetAddress(newAddress);

                    bool dbResult = dbRepo.Update(customerID, customers[i]);
                    if (dbResult)
                    {
                        // save to file also
                        fileRepo.SaveData(customers);
                    }
                    return dbResult;
                }
            }
            return false;
        }

        public bool DeleteCustomer(int id)
        {
            bool dbResult = dbRepo.Delete(id);
            if (dbResult)
            {
                // update file
                List<CustomerModel> customers = dbRepo.GetAll();
                fileRepo.SaveData(customers);
            }
            return dbResult;
        }

        public List<CustomerModel> GetAllCustomers()
        {
            List<CustomerModel> customers = dbRepo.GetAll();
            if (customers.Count == 0)
            {
                customers = fileRepo.LoadCustomers();
            }
            return customers;
        }

        public List<CustomerModel> FindCustomerByFirstChar(string firstChar)
        {
            List<CustomerModel> customers = dbRepo.FindByFirstChar(firstChar);
            if (customers.Count == 0)
            {
                List<CustomerModel> fileCustomers = fileRepo.LoadCustomers();
                List<CustomerModel> matched = new List<CustomerModel>();
                foreach (var c in fileCustomers)
                {
                    if (c.GetName().StartsWith(firstChar))
                        matched.Add(c);
                }
                return matched;
            }
            return customers;
        }

        public CustomerModel FindCustomerByPhoneNumber(string phoneNumber)
        {
            CustomerModel customer = dbRepo.FindByPhoneNo(phoneNumber);
            if (customer == null)
            {
                List<CustomerModel> fileCustomers = fileRepo.LoadCustomers();
                foreach (var c in fileCustomers)
                {
                    if (c.GetPhoneNumber() == phoneNumber)
                        return c;
                }
            }
            return customer;
        }

        public List<CustomerModel> FindCustomerByAddress(string address)
        {
            List<CustomerModel> customers = dbRepo.FindByAddress(address);
            if (customers.Count == 0)
            {
                List<CustomerModel> fileCustomers = fileRepo.LoadCustomers();
                List<CustomerModel> matched = new List<CustomerModel>();
                foreach (var c in fileCustomers)
                {
                    if (c.GetAddress() == address)
                        matched.Add(c);
                }
                return matched;
            }
            return customers;
        }

        public List<CustomerModel> FindCustomerByAge(int age)
        {
            List<CustomerModel> customers = dbRepo.FindByAge(age);
            if (customers.Count == 0)
            {
                List<CustomerModel> fileCustomers = fileRepo.LoadCustomers();
                List<CustomerModel> matched = new List<CustomerModel>();
                foreach (var c in fileCustomers)
                {
                    if (c.GetAge() == age)
                        matched.Add(c);
                }
                return matched;
            }
            return customers;
        }
    }
}
