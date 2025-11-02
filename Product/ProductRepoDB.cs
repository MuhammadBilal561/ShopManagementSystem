using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagementSystem
{
    internal class ProductRepoDB
    {
        public bool Create(ProductModel product)
        {
            using (SqlConnection con = new SqlConnection(Utils.DBConnection()))
            {
                con.Open();
                string query =
                    "INSERT INTO Product (Name, PurchasePrice, SalePrice, Discount) VALUES (@Name, @PurchasePrice, @SalePrice, @Discount)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", product.GetName());
                    cmd.Parameters.AddWithValue("@PurchasePrice", product.GetPurchasePrice());
                    cmd.Parameters.AddWithValue("@SalePrice", product.GetSalePrice());
                    cmd.Parameters.AddWithValue("@Discount", product.GetDiscount());
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        public ProductModel FindByID(int productID)
        {
            ProductModel product = null;
            using (SqlConnection con = new SqlConnection(Utils.DBConnection()))
            {
                con.Open();
                string query = "SELECT * FROM Product WHERE ProductID = @ProductID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductID", productID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ProductID"]);
                    string name = reader["Name"].ToString();
                    double purchasePrice = Convert.ToDouble(reader["PurchasePrice"]);
                    double salePirce = Convert.ToDouble(reader["SalePrice"]);
                    double dicount = Convert.ToDouble(reader["Discount"]);
                    product = new ProductModel(id, name, purchasePrice, salePirce, dicount);
                }
            }
            return product;
        }

        public bool Delete(int productID)
        {
            using (SqlConnection con = new SqlConnection(Utils.DBConnection()))
            {
                con.Open();
                string query = "DELETE FROM Product WHERE ProductID = @ProductID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productID);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        public bool Update(int productID, ProductModel updateProduct)
        {
            using (SqlConnection con = new SqlConnection(Utils.DBConnection()))
            {
                con.Open();
                string query =
                    "UPDATE Product SET Name = @Name, PurchasePrice = @PurchasePrice, SalePrice = @SalePrice, Discount = @Discount WHERE ProductID = @ProductID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", updateProduct.GetName());
                    cmd.Parameters.AddWithValue("@PurchasePrice", updateProduct.GetPurchasePrice());
                    cmd.Parameters.AddWithValue("@SalePrice", updateProduct.GetSalePrice());
                    cmd.Parameters.AddWithValue("@Discount", updateProduct.GetDiscount());
                    cmd.Parameters.AddWithValue("@ProductID", productID);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        public List<ProductModel> GetAll()
        {
            List<ProductModel> products = new List<ProductModel>();
            using (SqlConnection con = new SqlConnection(Utils.DBConnection()))
            {
                con.Open();
                string query = "SELECT * FROM Product";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int productID = Convert.ToInt32(reader["ProductID"]);
                    string name = reader["Name"].ToString();
                    double purchasePrice = Convert.ToDouble(reader["PurchasePrice"]);
                    double salePirce = Convert.ToDouble(reader["SalePrice"]);
                    double dicount = Convert.ToDouble(reader["Discount"]);
                    products.Add(
                        new ProductModel(productID, name, purchasePrice, salePirce, dicount)
                    );
                }
            }
            return products;
        }
    }
}
