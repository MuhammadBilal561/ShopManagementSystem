using System;
using System.Collections.Generic;

namespace ShopManagementSystem
{
    internal class ProductUI
    {
        private ProductService productService = new ProductService();

        public void ShowProductMenu()
        {
            while (true)
            {
                Console.Clear();
                ConsoleHelper.WriteTitle("----PRODUCT MANAGEMENT----");

                ConsoleHelper.WriteInfo("1. Add Product");
                ConsoleHelper.WriteInfo("2. View All Products");
                ConsoleHelper.WriteInfo("3. Search Product by Name");
                ConsoleHelper.WriteInfo("4. Update Product");
                ConsoleHelper.WriteInfo("5. Delete Product");
                ConsoleHelper.WriteError("0. Go Back");

                ConsoleHelper.WritePrompt("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    AddProduct();
                }
                else if (choice == "2")
                {
                    ViewAllProducts();
                }
                else if (choice == "3")
                {
                    SearchProduct();
                }
                else if (choice == "4")
                {
                    UpdateProduct();
                }
                else if (choice == "5")
                {
                    DeleteProduct();
                }
                else if (choice == "0")
                {
                    break;
                }
                else
                {
                    ConsoleHelper.WriteError("Invalid choice! Please try again.");
                }

                ConsoleHelper.Wait();
            }
        }

        private void AddProduct()
        {
            Console.Clear();
            ConsoleHelper.WriteSubmenu("--ADD NEW PRODUCT--");

            ConsoleHelper.WritePrompt("Enter Product Name: ");
            string name = Console.ReadLine();

            ConsoleHelper.WritePrompt("Enter Purchase Price: ");
            double purchasePrice = double.Parse(Console.ReadLine());

            ConsoleHelper.WritePrompt("Enter Sale Price: ");
            double salePrice = double.Parse(Console.ReadLine());

            ConsoleHelper.WritePrompt("Enter Discount (%): ");
            double discount = double.Parse(Console.ReadLine());

            ProductModel product = new ProductModel(name, purchasePrice, salePrice, discount);
            productService.AddProduct(product);

            ConsoleHelper.WriteSuccess("Product added successfully!");
        }

        private void ViewAllProducts()
        {
            Console.Clear();
            ConsoleHelper.WriteSubmenu("--ALL PRODUCTS--");

            List<ProductModel> products = productService.GetAllProducts();

            if (products.Count == 0)
            {
                ConsoleHelper.WriteError("No products found!");
                return;
            }

            foreach (ProductModel product in products)
            {
                ConsoleHelper.WriteInfo(product.ToString());
            }
        }

        private void SearchProduct()
        {
            Console.Clear();
            ConsoleHelper.WriteSubmenu("--SEARCH PRODUCT--");

            ConsoleHelper.WritePrompt("Enter Product Name to search: ");
            string name = Console.ReadLine();

            ProductModel product = productService.FindProductByName(name);

            if (product != null)
            {
                ConsoleHelper.WriteSuccess("Product Found:");
                ConsoleHelper.WriteInfo(product.ToString());

            }
            else
            {
                ConsoleHelper.WriteError("Product not found!");
            }
        }

        private void UpdateProduct()
        {
            Console.Clear();
            ConsoleHelper.WriteSubmenu("--UPDATE PRODUCT--");

            ConsoleHelper.WritePrompt("Enter Product Name to Update: ");
            string name = Console.ReadLine();

            ProductModel product = productService.FindProductByName(name);

            if (product == null)
            {
                ConsoleHelper.WriteError("Product not found!");
                return;
            }

            ConsoleHelper.WritePrompt(
                $"Enter New Sale Price (current: {product.GetSalePrice()}): "
            );
            double newSalePrice = double.Parse(Console.ReadLine());

            ConsoleHelper.WritePrompt($"Enter New Discount (current: {product.GetDiscount()}): ");
            double newDiscount = double.Parse(Console.ReadLine());

            bool updated = productService.UpdateProduct(name, newSalePrice, newDiscount);

            if (updated)
            {
                ConsoleHelper.WriteSuccess("Product updated successfully!");
            }
            else
            {
                ConsoleHelper.WriteError("Failed to update product!");
            }
        }

        private void DeleteProduct()
        {
            Console.Clear();
            ConsoleHelper.WriteSubmenu("--DELETE PRODUCT--");

            ConsoleHelper.WritePrompt("Enter Product Name to Delete: ");
            string name = Console.ReadLine();

            ProductModel product = productService.FindProductByName(name);

            if (product == null)
            {
                ConsoleHelper.WriteError("Product not found!");
                return;
            }

            ConsoleHelper.WriteInfo($"Found: {product.GetName()}");
            ConsoleHelper.WritePrompt($"Are you sure you want to delete {name}? (Y/N): ");
            string confirm = Console.ReadLine().Trim().ToUpper();

            if (confirm == "Y")
            {
                bool deleted = productService.DeleteProduct(name);

                if (deleted)
                {
                    ConsoleHelper.WriteSuccess("Product deleted successfully!");
                }
                else
                {
                    ConsoleHelper.WriteError("Failed to delete product!");
                }
            }
            else
            {
                ConsoleHelper.WriteInfo("Deletion cancelled.");
            }
        }
    }
}
