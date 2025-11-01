using System;
using System.Collections.Generic;

namespace ShopManagementSystem
{
    internal class OrderUI
    {
        private readonly OrderService orderService;
        private readonly CustomerService customerService;
        private readonly ProductService productService;

        public OrderUI()
        {
            orderService = new OrderService();
            customerService = new CustomerService();
            productService = new ProductService();
        }

        public void CreateNewSale()
        {
            Console.Clear();
            ConsoleHelper.WriteSubmenu("--- CREATE NEW SALE ---");

            ConsoleHelper.WritePrompt("Enter customer id: ");
            int id = int.Parse(Console.ReadLine());

            CustomerModel customer = customerService.FindCustomerByID(id);

            if (customer ==null)
            {
                ConsoleHelper.WriteInfo("New customer. Please provide details:");
                ConsoleHelper.WritePrompt("Enter Customer Name: ");
                string name = Console.ReadLine();
                ConsoleHelper.WritePrompt("Enter Phone Number: ");
                string phone = Console.ReadLine();
                ConsoleHelper.WritePrompt("Enter Age: ");
                int age = int.Parse(Console.ReadLine());
                ConsoleHelper.WritePrompt("Enter Address: ");
                string address = Console.ReadLine();

                customer = new CustomerModel(name, phone, age, address);
                customerService.AddCustomer(customer);
                ConsoleHelper.WriteSuccess("New customer created and saved.");
            }
            else
            {
                ConsoleHelper.WriteSuccess($"Existing customer found: {customer.GetName()}");
            }

            OrderModel newOrder = new OrderModel(
                customer.GetName(),
                customer.GetPhoneNumber(),
                customer.GetAge(),
                customer.GetAddress()
            );

            while (true)
            {
                ConsoleHelper.WritePrompt("Enter product name to add (or type 'done' to finish): ");
                string productName = Console.ReadLine();

                if (productName == "done")
                {
                    break;
                }

                ProductModel product = productService.FindProductByName(productName);
                if (product == null)
                {
                    ConsoleHelper.WriteError("Product not found!");
                    continue;
                }

                ConsoleHelper.WriteInfo(
                    $"Found: {product.GetName()} | Price: {product.GetSalePrice()} | Discount: {product.GetDiscount()}%"
                );
                ConsoleHelper.WritePrompt("Enter quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                OrderItemModel item = new OrderItemModel(
                    product.GetName(),
                    product.GetSalePrice(),
                    product.GetDiscount(),
                    quantity
                );

                newOrder.AddItems(item);
                ConsoleHelper.WriteSuccess("Product added to order.");
            }

            if (newOrder.OrderList.Count > 0)
            {
                orderService.CreateNewOrder(newOrder);

                ConsoleHelper.WriteInfo("--- ORDER SUMMARY ---");
                Console.WriteLine($"Customer: {newOrder.GetCustomerName()}");
                Console.WriteLine($"Date: {newOrder.GetOrderDate()}");
                Console.WriteLine("Items:");
                foreach (var item in newOrder.OrderList)
                {
                    Console.WriteLine(
                        $"- {item.GetProductName()} x{item.GetQuantity()} = {item.GetSubtotal()}"
                    );
                }
                ConsoleHelper.WriteSuccess($"TOTAL BILL: {newOrder.GetTotalAmount()}");
            }
            else
            {
                ConsoleHelper.WriteError("No items added. Order cancelled.");
            }

            ConsoleHelper.Wait();
        }

        public void ShowHistoryMenu()
        {
            Console.Clear();
            ConsoleHelper.WriteSubmenu("VIEW ORDER HISTORY");
            ConsoleHelper.WriteInfo("1. View All Orders");
            ConsoleHelper.WriteInfo("2. View Orders by Customer Name");
            ConsoleHelper.WriteError("0. Go Back");
            ConsoleHelper.WritePrompt("Enter your choice: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                List<OrderModel> orders = orderService.GetAllOrders();
                DisplayOrders(orders);
            }
            else if (choice == "2")
            {
                ConsoleHelper.WritePrompt("Enter customer name: ");
                string name = Console.ReadLine();
                List<OrderModel> orders = orderService.GetAllOrders();

                List<OrderModel> filtered = new List<OrderModel>();
                foreach (var order in orders)
                {
                    if (order.GetCustomerName() == name)
                    {
                        filtered.Add(order);
                    }
                }

                DisplayOrders(filtered);
            }
            else if (choice == "0")
            {
                return;
            }
            else
            {
                ConsoleHelper.WriteError("Invalid choice.");
            }

            ConsoleHelper.Wait();
        }

        private void DisplayOrders(List<OrderModel> orders)
        {
            if (orders.Count == 0)
            {
                ConsoleHelper.WriteError("No orders found.");
                return;
            }

            foreach (var order in orders)
            {
                ConsoleHelper.WriteInfo("--------------------------------------------");
                Console.WriteLine(
                    $"Customer: {order.GetCustomerName()} | Date: {order.GetOrderDate()}"
                );
                Console.WriteLine($"Phone: {order.GetPhoneNo()} | Address: {order.GetAddress()}");
                Console.WriteLine("Items:");
                foreach (var item in order.OrderList)
                {
                    Console.WriteLine(
                        $"- {item.GetProductName()} (x{item.GetQuantity()}) = {item.GetSubtotal()}"
                    );
                }
                ConsoleHelper.WriteSuccess($"Total: {order.GetTotalAmount()}");
                ConsoleHelper.WriteInfo("--------------------------------------------\n");
            }
        }
    }
}
