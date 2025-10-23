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







        //public List<ProductModel> PriceDiff()
        //{
        //    List<ProductModel> products = new List<ProductModel>();

        //    foreach (var product in productRepository.LoadProducts())
        //    {
        //        if (product.GetPurchasePrice() - product.GetSalePrice() == 100)
        //        {
        //            products.Add(product);
        //        }

        //    }
        //    return products;
        //}












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
