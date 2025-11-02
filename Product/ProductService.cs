using System;
using System.Collections.Generic;

namespace ShopManagementSystem
{
    internal class ProductService
    {
        private ProductRepository productRepository = new ProductRepository();

        //private ProductRepository fileRepo = new ProductRepository();
        private ProductRepoDB dbRepo = new ProductRepoDB();

        public void AddProduct(ProductModel product)
        {
            bool dbResult = dbRepo.Create(product);
            if (dbResult)
            {
                //file backup
                productRepository.SaveToFile(product);
            }
        }

        public ProductModel FindProductByName(string name)
        {
            ProductModel product = dbRepo.FindByName(name);
            if (product == null)
            {
                foreach (var p in productRepository.LoadProducts())
                {
                    if (p.GetName() == name)
                    {
                        return p;
                    }
                }
                return null;
            }
            return product;
        }

        public List<ProductModel> FindProductsByPrice(double price)
        {
            List<ProductModel> products = dbRepo.FindByPrice(price);
            if (products.Count == 0)
            {
                List<ProductModel> fileProducts = productRepository.LoadProducts();
                List<ProductModel> matchedProducts = new List<ProductModel>();
                foreach (var product in fileProducts)
                {
                    if (product.GetSalePrice() == price)
                    {
                        matchedProducts.Add(product);
                    }
                }
                return matchedProducts;
            }
            return products;
        }

        public List<ProductModel> FindProductsByPriceRange(double minPirce, double maxPrice)
        {
            List<ProductModel> products = dbRepo.FindByPriceRange(minPirce, maxPrice);
            if (products.Count == 0)
            {
                List<ProductModel> fileProducts = productRepository.LoadProducts();
                List<ProductModel> matchedProducts = new List<ProductModel>();
                foreach (var product in fileProducts)
                {
                    if (product.GetSalePrice() >= minPirce && product.GetSalePrice() <= maxPrice)
                    {
                        matchedProducts.Add(product);
                    }
                }
                return matchedProducts;
            }
            return products;
        }

        public List<ProductModel> FindProductByPirceDiff(double priceDiff)
        {
            List<ProductModel> products = dbRepo.FindByPriceDiff(priceDiff);
            if (products.Count == 0)
            {
                List<ProductModel> fileProducts = productRepository.LoadProducts();
                List<ProductModel> matchedProducts = new List<ProductModel>();
                foreach (var product in fileProducts)
                {
                    double diff = product.GetSalePrice() - product.GetPurchasePrice();
                    if (Math.Abs(diff) == priceDiff)
                    {
                        matchedProducts.Add(product);
                    }
                }
                return matchedProducts;
            }
            return products;
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

        public bool UpdateProduct(
            int productID,
            string newName,
            double newSalePrice,
            double newDiscount
        )
        {
            List<ProductModel> products = dbRepo.GetAll();

            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].GetProductID() == productID)
                {
                    products[i].SetName(newName);
                    products[i].SetSalePrice(newSalePrice);
                    products[i].SetDiscount(newDiscount);

                    bool dbResult = dbRepo.Update(productID, products[i]);
                    if (dbResult)
                    {
                        // save to file also
                        productRepository.SaveData(products);
                    }
                    return dbResult;
                }
            }
            return false;
        }

        public ProductModel FindProductByID(int id)
        {
            return dbRepo.FindByID(id);
        }

        public bool DeleteProduct(int productID)
        {
            bool dbResult = dbRepo.Delete(productID);
            if (dbResult)
            {
                // update file
                List<ProductModel> products = dbRepo.GetAll();
                productRepository.SaveData(products);
            }
            return dbResult;
        }

        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> products = dbRepo.GetAll();
            if (products.Count == 0)
            {
                products = productRepository.LoadProducts();
            }
            return products;
        }
    }
}
