using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagementSystem
{
    internal class CustomerRepoDB
    {
        public bool Create(CustomerModel customer)
        {
            using (SqlConnection con = new SqlConnection(Utils.DBConnection()))
            {
                con.Open();
                string query =
                    "INSERT INTO Customer (Name, PhoneNumber, Age, Address) VALUES (@Name, @PhoneNumber, @Age, @Address)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", customer.GetName());
                    cmd.Parameters.AddWithValue("@PhoneNumber", customer.GetPhoneNumber());
                    cmd.Parameters.AddWithValue("@Age", customer.GetAge());
                    cmd.Parameters.AddWithValue("@Address", customer.GetAddress());
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}
