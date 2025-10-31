using System;
using System.Collections.Generic;

namespace ShopManagementSystem
{
    internal class ProductService
    {
        private ProductRepository productRepository;

        public ProductService()
        {
            productRepository = new ProductRepository();
        }

        public void AddProduct(ProductModel product)
        {
            productRepository.SaveToFile(product);
        }

        public ProductModel FindProductByName(string name)
        {
            foreach (var product in productRepository.LoadProducts())
            {
                if (product.GetName() == name)
                {
                    return product;
                }
            }
            return null;
        }

        public List<ProductModel> FindProductsByPrice(double price)
        {
            List<ProductModel> products = productRepository.LoadProducts();
            List<ProductModel> matchedProducts = new List<ProductModel>();
            foreach (var product in products)
            {
                if (product.GetSalePrice() == price)
                {
                    matchedProducts.Add(product);
                }
            }

            return matchedProducts;
        }

        public List<ProductModel> FindProductsByPriceRange(double minPirce, double maxPrice)
        {
            List<ProductModel> products = productRepository.LoadProducts();
            List<ProductModel> matchedProducts = new List<ProductModel>();
            foreach (var product in products)
            {
                if (product.GetSalePrice() >= minPirce && product.GetSalePrice() <= maxPrice)
                {
                    matchedProducts.Add(product);
                }
            }
            return matchedProducts;
        }

        public List<ProductModel> FindProductByPirceDiff(double priceDiff)
        {
            List<ProductModel> products = productRepository.LoadProducts();
            List<ProductModel> matchedProducts = new List<ProductModel>();
            foreach (var product in products)
            {
                double diff = product.GetSalePrice() - product.GetPurchasePrice();
                if (Math.Abs(diff) == priceDiff)
                {
                    matchedProducts.Add(product);
                }
            }
            return matchedProducts;
        }

        public List<ProductModel> FindProductsBySubString(string subString)
        {
            List<ProductModel> products = productRepository.LoadProducts();
            List<ProductModel> matchedProducts = new List<ProductModel>();
            foreach (var product in products)
            {
                if (product.GetName().Contains(subString))
                {
                    matchedProducts.Add(product);
                }
            }
            return matchedProducts;
        }

        public bool UpdateProduct(string name, double newSalePrice, double newDiscount)
        {
            List<ProductModel> products = productRepository.LoadProducts();
            foreach (var product in products)
            {
                if (product.GetName() == name)
                {
                    product.SetSalePrice(newSalePrice);
                    product.SetDiscount(newDiscount);
                    productRepository.SaveData(products);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteProduct(string name)
        {
            List<ProductModel> products = productRepository.LoadProducts();
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].GetName() == name)
                {
                    products.RemoveAt(i);
                    productRepository.SaveData(products);
                    return true;
                }
            }
            return false;
        }

        public List<ProductModel> GetAllProducts()
        {
            return productRepository.LoadProducts();
        }
    }
}
