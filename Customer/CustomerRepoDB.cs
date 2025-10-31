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

        public bool Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(Utils.DBConnection()))
            {
                con.Open();
                string query = "delete from customer where CustomerID = @CustomerID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        public List<CustomerModel> GetAll()
        {
            List<CustomerModel> customers = new List<CustomerModel>();
            using (SqlConnection con = new SqlConnection(Utils.DBConnection()))
            {
                con.Open();
                string query = "SELECT * FROM Customer";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int customerID = Convert.ToInt32(reader["CustomerID"]);
                    string name = reader["Name"].ToString();
                    string phoneNumber = reader["PhoneNumber"].ToString();
                    int age = Convert.ToInt32(reader["Age"]);
                    string address = reader["Address"].ToString();
                    customers.Add(new CustomerModel(customerID, name, phoneNumber, age, address));
                }
            }
            return customers;
        }

        public List<CustomerModel> FindByName(string name)
        {
            List<CustomerModel> customers = new List<CustomerModel>();
            using (SqlConnection con = new SqlConnection(Utils.DBConnection()))
            {
                con.Open();
                string query = "SELECT * FROM Customer WHERE Name LIKE @Name";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", name);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int customerID = Convert.ToInt32(reader["CustomerID"]);
                    string cName = reader["Name"].ToString();
                    string phoneNumber = reader["PhoneNumber"].ToString();
                    int age = Convert.ToInt32(reader["Age"]);
                    string address = reader["Address"].ToString();
                    customers.Add(new CustomerModel(customerID, cName, phoneNumber, age, address));
                }
            }
            return customers;
        }

        public List<CustomerModel> FindByFirstChar(string firstChar)
        {
            List<CustomerModel> customers = new List<CustomerModel>();
            using (SqlConnection con = new SqlConnection(Utils.DBConnection()))
            {
                con.Open();
                string query = "SELECT * FROM Customer WHERE Name LIKE @FirstChar + '%'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FirstChar", firstChar);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int customerID = Convert.ToInt32(reader["CustomerID"]);
                    string cName = reader["Name"].ToString();
                    string phoneNumber = reader["PhoneNumber"].ToString();
                    int age = Convert.ToInt32(reader["Age"]);
                    string address = reader["Address"].ToString();
                    customers.Add(new CustomerModel(customerID, cName, phoneNumber, age, address));
                }
            }
            return customers;
        }

        public List<CustomerModel> FindByAddress(string address)
        {
            List<CustomerModel> customers = new List<CustomerModel>();
            using (SqlConnection con = new SqlConnection(Utils.DBConnection()))
            {
                con.Open();
                string query = "SELECT * FROM Customer WHERE Address = @Address";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Address", address);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int customerID = Convert.ToInt32(reader["CustomerID"]);
                    string name = reader["Name"].ToString();
                    string phoneNumber = reader["PhoneNumber"].ToString();
                    int age = Convert.ToInt32(reader["Age"]);
                    string cAddress = reader["Address"].ToString();
                    customers.Add(new CustomerModel(customerID, name, phoneNumber, age, cAddress));
                }
            }
            return customers;
        }
    }
}
