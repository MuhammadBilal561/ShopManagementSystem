using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        public bool Delete(int customerID)
        {
            using (SqlConnection con = new SqlConnection(Utils.DBConnection()))
            {
                con.Open();
                string query = "DELETE FROM Customer WHERE CustomerID = @CustomerID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        public bool Update(int customerID, CustomerModel updatedCustomer)
        {
            using (SqlConnection con = new SqlConnection(Utils.DBConnection()))
            {
                con.Open();
                string query =
                    "UPDATE Customer SET Name = @Name, PhoneNumber = @PhoneNumber, Age = @Age, Address = @Address WHERE CustomerID = @CustomerID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", updatedCustomer.GetName());
                    cmd.Parameters.AddWithValue("@PhoneNumber", updatedCustomer.GetPhoneNumber());
                    cmd.Parameters.AddWithValue("@Age", updatedCustomer.GetAge());
                    cmd.Parameters.AddWithValue("@Address", updatedCustomer.GetAddress());
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
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


        public CustomerModel FindByID(int customerID)
        {
            CustomerModel customer = null;
            using (SqlConnection con = new SqlConnection(Utils.DBConnection()))
            {
                con.Open();
                string query = "SELECT * FROM Customer WHERE CustomerID = @ID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", customerID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int id = Convert.ToInt32(reader["CustomerID"]);
                    string name = reader["Name"].ToString();
                    string phoneNumber = reader["PhoneNumber"].ToString();
                    int age = Convert.ToInt32(reader["Age"]);
                    string address = reader["Address"].ToString();
                    customer = new CustomerModel(id, name, phoneNumber, age, address);
                }
            }
            return customer;
        }

        public List<CustomerModel> FindByName(string name)
        {
            List<CustomerModel> customers = new List<CustomerModel>();
            using (SqlConnection con = new SqlConnection(Utils.DBConnection()))
            {
                con.Open();
                string query = "SELECT * FROM Customer WHERE Name LIKE @Name";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", "%" + name + "%");
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
                    string name = reader["Name"].ToString();
                    string phoneNumber = reader["PhoneNumber"].ToString();
                    int age = Convert.ToInt32(reader["Age"]);
                    string address = reader["Address"].ToString();
                    customers.Add(new CustomerModel(customerID, name, phoneNumber, age, address));
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

        public List<CustomerModel> FindByAge(int age)
        {
            List<CustomerModel> customers = new List<CustomerModel>();
            using (SqlConnection con = new SqlConnection(Utils.DBConnection()))
            {
                con.Open();
                string query = "SELECT * FROM Customer WHERE Age = @Age";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Age", age);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int customerID = Convert.ToInt32(reader["CustomerID"]);
                    string name = reader["Name"].ToString();
                    string phoneNumber = reader["PhoneNumber"].ToString();
                    int cAge = Convert.ToInt32(reader["Age"]);
                    string address = reader["Address"].ToString();
                    customers.Add(new CustomerModel(customerID, name, phoneNumber, cAge, address));
                }
            }
            return customers;
        }

        public CustomerModel FindByPhoneNo(string phoneNo)
        {
            CustomerModel customer = null;
            using (SqlConnection con = new SqlConnection(Utils.DBConnection()))
            {
                con.Open();
                string query = "SELECT * FROM Customer WHERE TRIM(PhoneNumber) = @PhoneNumber";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PhoneNumber", phoneNo);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int customerID = Convert.ToInt32(reader["CustomerID"]);
                    string name = reader["Name"].ToString();
                    string phoneNumber = reader["PhoneNumber"].ToString();
                    int age = Convert.ToInt32(reader["Age"]);
                    string address = reader["Address"].ToString();
                    customer = new CustomerModel(customerID, name, phoneNumber, age, address);
                }
            }
            return customer;
        }
    }
}
