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
                ConsoleHelper.WriteInfo("3. Update Product");
                ConsoleHelper.WriteInfo("4. Delete Product");
                ConsoleHelper.WriteInfo("5. Advance Search Option");
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
                    UpdateProduct();
                }
                else if (choice == "4")
                {
                    DeleteProduct();
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
                    ConsoleHelper.WriteError("Invalid choice! Please try again.");
                }
                ConsoleHelper.Wait();
            }
        }

        public void AdvanceSearchMenu()
        {
            Console.Clear();
            ConsoleHelper.WriteTitle("----ADVANCE SEARCH OPTIONS----");
            ConsoleHelper.WriteInfo("1. Search Product by Name");
            ConsoleHelper.WriteInfo("2. Search All Products by Price");
            ConsoleHelper.WriteInfo("3. Find Products Between a Given Price Range");
            ConsoleHelper.WriteInfo("4. Find Products with Price Difference");
            ConsoleHelper.WriteInfo("5. Find Products by Substring");
            ConsoleHelper.WriteError("0. Go Back");
            ConsoleHelper.WritePrompt("Enter your choice: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                SearchProductByName();
            }
            else if (choice == "2")
            {
                SearchProductsByPrice();
            }
            else if (choice == "3")
            {
                SearchProductsByPriceRange();
            }
            else if (choice == "4")
                SearchProductsByPriceDifference();
            else if (choice == "5")
            {
                SearchProductsBySubstring();
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

        private void SearchProductByName()
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

        private void SearchProductsByPrice()
        {
            Console.Clear();
            ConsoleHelper.WriteSubmenu("--SEARCH PRODUCTS BY PRICE--");
            ConsoleHelper.WritePrompt("Enter Sale Price to search: ");
            double price = double.Parse(Console.ReadLine());
            List<ProductModel> products = productService.FindProductsByPrice(price);
            if (products.Count > 0)
            {
                ConsoleHelper.WriteSuccess($"Found {products.Count} products:");
                foreach (var product in products)
                {
                    ConsoleHelper.WriteInfo(product.ToString());
                }
            }
            else
            {
                ConsoleHelper.WriteError("No products found with the given price!");
            }
        }

        private void SearchProductsByPriceRange()
        {
            Console.Clear();
            ConsoleHelper.WriteSubmenu("--SEARCH PRODUCTS BY PRICE RANGE--");
            ConsoleHelper.WritePrompt("Enter Minimum Price: ");
            double minPrice = double.Parse(Console.ReadLine());
            ConsoleHelper.WritePrompt("Enter Maximum Price: ");
            double maxPrice = double.Parse(Console.ReadLine());
            List<ProductModel> products = productService.FindProductsByPriceRange(
                minPrice,
                maxPrice
            );
            if (products.Count > 0)
            {
                ConsoleHelper.WriteSuccess($"Found {products.Count} products:");
                foreach (var product in products)
                {
                    ConsoleHelper.WriteInfo(product.ToString());
                }
            }
            else
            {
                ConsoleHelper.WriteError("No products found in the given price range!");
            }
        }

        private void SearchProductsByPriceDifference()
        {
            Console.Clear();
            ConsoleHelper.WriteSubmenu("--SEARCH PRODUCTS BY PRICE DIFFERENCE--");
            ConsoleHelper.WritePrompt("Enter Price Difference: ");
            double priceDiff = double.Parse(Console.ReadLine());
            List<ProductModel> products = productService.FindProductByPirceDiff(priceDiff);
            if (products.Count > 0)
            {
                ConsoleHelper.WriteSuccess($"Found {products.Count} products:");
                foreach (var product in products)
                {
                    ConsoleHelper.WriteInfo(product.ToString());
                }
            }
            else
            {
                ConsoleHelper.WriteError("No products found with the given price difference!");
            }
        }

        private void SearchProductsBySubstring()
        {
            Console.Clear();
            ConsoleHelper.WriteSubmenu("--SEARCH PRODUCTS BY SUBSTRING--");
            ConsoleHelper.WritePrompt("Enter Substring to search in Product Names: ");
            string substring = Console.ReadLine();
            List<ProductModel> products = productService.FindProductsBySubString(substring);
            if (products.Count > 0)
            {
                ConsoleHelper.WriteSuccess($"Found {products.Count} products:");
                foreach (var product in products)
                {
                    ConsoleHelper.WriteInfo(product.ToString());
                }
            }
            else
            {
                ConsoleHelper.WriteError("No products found with the given substring!");
            }
        }

        private void UpdateProduct()
        {
            Console.Clear();
            ConsoleHelper.WriteSubmenu("--UPDATE Product--");
            ConsoleHelper.WritePrompt("Enter Prodcut ID: ");
            int id = int.Parse(Console.ReadLine());

            ProductModel existing = productService.FindProductByID(id);
            if (existing == null)
            {
                ConsoleHelper.WriteError("Product not found!");
                return;
            }

            ConsoleHelper.WritePrompt("Enter new Name: ");
            string newName = Console.ReadLine();

            ConsoleHelper.WritePrompt("Enter new Sale Price: ");
            double newPrice = double.Parse(Console.ReadLine());

            ConsoleHelper.WritePrompt("Enter new Discount: ");
            double newDiscount = double.Parse(Console.ReadLine());

            

            bool updated = productService.UpdateProduct(
                id,
                newName,
                newPrice,
                newDiscount
            );
            if (updated)
                ConsoleHelper.WriteSuccess("Product updated successfully!");
            else
                ConsoleHelper.WriteError("Failed to update Product!");
        }

        private void DeleteProduct()
        {
            Console.Clear();
            ConsoleHelper.WriteSubmenu("--DELETE PRODUCT--");

            ConsoleHelper.WritePrompt("Enter Product ID to Delete: ");
            int id = int.Parse(Console.ReadLine());

            ProductModel product = productService.FindProductByID(id);

            if (product == null)
            {
                ConsoleHelper.WriteError("Product not found!");
                return;
            }

            ConsoleHelper.WriteInfo($"Found: {product.GetName()}");
            ConsoleHelper.WritePrompt($"Are you sure you want to delete {product.GetName()}? (Y/N): ");
            string confirm = Console.ReadLine().Trim().ToUpper();

            if (confirm == "Y")
            {
                bool deleted = productService.DeleteProduct(id);

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
