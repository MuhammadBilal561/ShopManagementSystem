using System.Collections.Generic;
using System.IO;

namespace ShopManagementSystem
{
    internal class ProductRepository
    {
        private const string PRODUCTS_FILE = "products.txt";

        public List<ProductModel> LoadProducts()
        {
            List<ProductModel> products = new List<ProductModel>();
            if (!File.Exists(PRODUCTS_FILE))
            {
                return products;
            }

            using (StreamReader reader = new StreamReader(PRODUCTS_FILE))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        string name = parts[0];
                        double purchasePrice = double.Parse(parts[1]);
                        double salePrice = double.Parse(parts[2]);
                        double discount = double.Parse(parts[3]);
                        ProductModel product = new ProductModel(
                            name,
                            purchasePrice,
                            salePrice,
                            discount
                        );
                        products.Add(product);
                    }
                }
            }
            return products;
        }

        public void SaveToFile(ProductModel product)
        {
            using (StreamWriter data = new StreamWriter(PRODUCTS_FILE, true))
            {
                data.WriteLine(product.ToDataString());
            }
        }

        public void SaveData(List<ProductModel> products)
        {
            File.WriteAllText(PRODUCTS_FILE, "");
            foreach (var product in products)
            {
                SaveToFile(product);
            }
        }
    }
}
