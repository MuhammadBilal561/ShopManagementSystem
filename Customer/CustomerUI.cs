using System;
using System.Collections.Generic;

namespace ShopManagementSystem
{
    internal class CustomerUI
    {
        private CustomerService customerService = new CustomerService();

        public void ShowCustomerMenu()
        {
            while (true)
            {
                Console.Clear();
                ConsoleHelper.WriteTitle("-----CUSTOMER MANAGEMENT-----");

                ConsoleHelper.WriteInfo("1. Add Customer");
                ConsoleHelper.WriteInfo("2. View All Customers");
                ConsoleHelper.WriteInfo("3. Update Customer");
                ConsoleHelper.WriteInfo("4. Delete Customer");
                ConsoleHelper.WriteInfo("5. Advance Search");
                ConsoleHelper.WriteInfo("0. Go Back");

                ConsoleHelper.WritePrompt("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    AddCustomer();
                }
                else if (choice == "2")
                {
                    ViewAllCustomers();
                }
                else if (choice == "3")
                {
                    UpdateCustomer();
                }
                else if (choice == "4")
                {
                    DeleteCustomer();
                }
                else if (choice == "5")
                {
                    AdvanceSearchMenu();
                }
                else if (choice == "0")
                {
                    break;
                }
                else
                {
                    ConsoleHelper.WriteError("Invalid option! Please select again.");
                }

                ConsoleHelper.Wait();
            }
        }

        public void AdvanceSearchMenu()
        {
            Console.Clear();
            ConsoleHelper.WriteTitle("-----ADVANCE SEARCH-----");
            ConsoleHelper.WriteInfo("1. Search Customer by Name");
            ConsoleHelper.WriteInfo("2. Search Customer by First Character");
            ConsoleHelper.WriteInfo("3. Search Customer by Phone Number");
            ConsoleHelper.WriteInfo("4. Search Customer by Address");
            ConsoleHelper.WriteInfo("5. Search Customer by Age");
            ConsoleHelper.WriteError("0. Go Back");
            ConsoleHelper.WritePrompt("Enter your choice: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                SearchCustomerByName();
            }
            else if (choice == "2")
            {
                SearchCustomerByFirstChar();
            }
            else if (choice == "3")
            {
                SearchCustomerByPhNo();
            }
            else if (choice == "4")
            {
                SearchCustomerByAddress();
            }
            else if (choice == "5")
            {
                SearchCustomerByAge();
            }
            else if (choice == "0")
            {
                return;
            }
            else
            {
                ConsoleHelper.WriteError("Invalid choice! Please try again.");
            }
        }

        private void SearchCustomerByFirstChar()
        {
            Console.Clear();
            ConsoleHelper.WriteSubmenu("--SEARCH CUSTOMER BY FIRST CHARACTER--");
            ConsoleHelper.WritePrompt("Enter the first character of Customer Name to search: ");
            string firstChar = Console.ReadLine();
            List<CustomerModel> customers = customerService.FindCustomerByFirstChar(firstChar);
            if (customers.Count > 0)
            {
                ConsoleHelper.WriteSuccess("Customers Found:");
                foreach (CustomerModel customer in customers)
                {
                    ConsoleHelper.WriteInfo(customer.ToString());
                }
            }
            else
            {
                ConsoleHelper.WriteError("No customers found with the given first character!");
            }
        }

        private void SearchCustomerByPhNo()
        {
            Console.Clear();
            ConsoleHelper.WriteSubmenu("--SEARCH CUSTOMER BY PHONE NUMBER--");
            ConsoleHelper.WritePrompt("Enter Phone Number to search: ");
            string phone = Console.ReadLine();
            CustomerModel customer = customerService.FindCustomerByPhoneNumber(phone);
            if (customer != null)
            {
                ConsoleHelper.WriteSuccess("Customer Found:");
                ConsoleHelper.WriteInfo(customer.ToString());
            }
            else
            {
                ConsoleHelper.WriteError("Customer not found with the given phone number!");
            }
        }

        private void SearchCustomerByAddress()
        {
            Console.Clear();
            ConsoleHelper.WriteSubmenu("--SEARCH CUSTOMER BY ADDRESS--");
            ConsoleHelper.WritePrompt("Enter Address to search: ");
            string address = Console.ReadLine();
            List<CustomerModel> customers = customerService.FindCustomerByAddress(address);
            if (customers.Count > 0)
            {
                ConsoleHelper.WriteSuccess("Customers Found:");
                foreach (CustomerModel customer in customers)
                {
                    ConsoleHelper.WriteInfo(customer.ToString());
                }
            }
            else
            {
                ConsoleHelper.WriteError("No customers found with the given address!");
            }
        }

        private void SearchCustomerByAge()
        {
            Console.Clear();
            ConsoleHelper.WriteSubmenu("--SEARCH CUSTOMER BY AGE--");
            ConsoleHelper.WritePrompt("Enter Age to search: ");
            int age = int.Parse(Console.ReadLine());
            List<CustomerModel> customers = customerService.FindCustomerByAge(age);
            if (customers.Count > 0)
            {
                ConsoleHelper.WriteSuccess("Customers Found:");
                foreach (CustomerModel customer in customers)
                {
                    ConsoleHelper.WriteInfo(customer.ToString());
                }
            }
            else
            {
                ConsoleHelper.WriteError("No customers found with the given age!");
            }
        }

        private void AddCustomer()
        {
            Console.Clear();
            ConsoleHelper.WriteSubmenu("--ADD NEW CUSTOMER--");

            ConsoleHelper.WritePrompt("Enter Customer Name: ");
            string name = Console.ReadLine();

            ConsoleHelper.WritePrompt("Enter Phone Number: ");
            string phone = Console.ReadLine();

            ConsoleHelper.WritePrompt("Enter Age: ");
            int age = int.Parse(Console.ReadLine());

            ConsoleHelper.WritePrompt("Enter Address: ");
            string address = Console.ReadLine();

            CustomerModel newCustomer = new CustomerModel(name, phone, age, address);
            customerService.AddCustomer(newCustomer);

            ConsoleHelper.WriteSuccess("Customer added successfully!");
        }

        private void ViewAllCustomers()
        {
            Console.Clear();
            ConsoleHelper.WriteSubmenu("VIEW ALL CUSTOMERS");

            List<CustomerModel> customers = customerService.GetAllCustomers();

            if (customers.Count == 0)
            {
                ConsoleHelper.WriteError("No customers found!");
                return;
            }

            foreach (CustomerModel customer in customers)
            {
                ConsoleHelper.WriteInfo(customer.ToString());
            }
        }

        private void SearchCustomerByName()
        {
            Console.Clear();
            ConsoleHelper.WriteSubmenu("--SEARCH CUSTOMER--");

            ConsoleHelper.WritePrompt("Enter Customer Name to search: ");
            string name = Console.ReadLine();

            CustomerModel customer = customerService.FindCustomerByName(name);

            if (customer != null)
            {
                ConsoleHelper.WriteSuccess("Customer Found:");
                ConsoleHelper.WriteInfo(customer.ToString());
            }
            else
            {
                ConsoleHelper.WriteError("Customer not found!");
            }
        }

        private void UpdateCustomer()
        {
            Console.Clear();
            ConsoleHelper.WriteSubmenu("--UPDATE CUSTOMER--");

            ConsoleHelper.WritePrompt("Enter the original Customer Name: ");
            string originalName = Console.ReadLine();

            CustomerModel existingCustomer = customerService.FindCustomerByName(originalName);

            if (existingCustomer == null)
            {
                ConsoleHelper.WriteError("Customer not found!");
                return;
            }

            ConsoleHelper.WritePrompt("Enter new Customer Name: ");
            string newName = Console.ReadLine();

            ConsoleHelper.WritePrompt("Enter new Phone Number: ");
            string newPhone = Console.ReadLine();

            ConsoleHelper.WritePrompt("Enter new Age: ");
            int newAge = int.Parse(Console.ReadLine());

            ConsoleHelper.WritePrompt("Enter new Address: ");
            string newAddress = Console.ReadLine();

            bool updated = customerService.UpdateCustomer(
                originalName,
                newName,
                newPhone,
                newAge,
                newAddress
            );

            if (updated)
            {
                ConsoleHelper.WriteSuccess("Customer updated successfully!");
            }
            else
            {
                ConsoleHelper.WriteError("Failed to update customer!");
            }
        }

        private void DeleteCustomer()
        {
            Console.Clear();
            ConsoleHelper.WriteSubmenu("--DELETE CUSTOMER--");

            ConsoleHelper.WritePrompt("Enter Customer Id to delete: ");
            int id = int.Parse(Console.ReadLine());

            CustomerModel customer = customerService.FindCustomerByID(id);

            if (customer == null)
            {
                ConsoleHelper.WriteError("Customer not found!");
                return;
            }

            ConsoleHelper.WriteInfo($"Found Customer: {customer.GetName()}");
            ConsoleHelper.WritePrompt(
                $"Are you sure you want to delete {customer.GetName()}? (Y/N): "
            );
            string confirmation = Console.ReadLine().Trim().ToUpper();

            if (confirmation == "Y")
            {
                bool deleted = customerService.DeleteCustomer(id);

                if (deleted)
                {
                    ConsoleHelper.WriteSuccess("Customer deleted successfully!");
                }
                else
                {
                    ConsoleHelper.WriteError("Failed to delete customer!");
                }
            }
            else
            {
                ConsoleHelper.WriteInfo("Deletion cancelled.");
            }
        }
    }
}
