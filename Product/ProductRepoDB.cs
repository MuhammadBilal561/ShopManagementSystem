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
    }
}
