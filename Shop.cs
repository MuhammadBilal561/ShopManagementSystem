using System;

namespace ShopManagementSystem
{
    internal class Shop
    {
        // All Services
        private static ProductService productService = new ProductService();
        private static CustomerService customerService = new CustomerService();
        private static OrderService orderService = new OrderService();

        // All UI Classes
        private static ProductUI productUI = new ProductUI();
        private static CustomerUI customerUI = new CustomerUI();
        private static OrderUI orderUI = new OrderUI();

        public void OurShop()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                ConsoleHelper.WriteTitle("SHOP MANAGEMENT SYSTEM");
                Console.WriteLine("1. Product Management");
                Console.WriteLine("2. Customer Management");
                Console.WriteLine("3. Create New Sale (Order)");
                Console.WriteLine("4. View Order History");
                Console.WriteLine("0. Exit Application");
                ConsoleHelper.WritePrompt("Enter your choice: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    productUI.ShowProductMenu();
                }
                else if (choice == "2")
                {
                    customerUI.ShowCustomerMenu();
                }
                else if (choice == "3")
                {
                    orderUI.CreateNewSale();
                }
                else if (choice == "4")
                {
                    orderUI.ShowHistoryMenu();
                }
                else if (choice == "0")
                {
                    running = false;
                }
                else
                {
                    ConsoleHelper.WriteError("Invalid choice. Press any key to continue...");
                    Console.ReadKey();
                }
            }

            Console.Clear();
            ConsoleHelper.WriteSuccess("Thank you for using the Shop Management System!");
        }
    }
}
