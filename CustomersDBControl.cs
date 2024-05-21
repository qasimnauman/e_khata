using DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControllers
{
    public class CustomersDBControl
    {
        public static void addcustomer(CustomersModel cust)
        {
            using(SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand("addcustomer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@custid", cust.customerid);
                    cmd.Parameters.AddWithValue("@custname", cust.name);
                    cmd.Parameters.AddWithValue("@contact", cust.contact);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static void deletecustomer(int cid)
        {
            using(SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand("deletecustomer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@custid", cid);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static void updatecustomer(CustomersModel cust)
        {
            using(SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand("updatecustomer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@custid", cust.customerid);
                    cmd.Parameters.AddWithValue("@ncustname", cust.name);
                    cmd.Parameters.AddWithValue("@ncontact", cust.contact);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        
        public List<CustomersModel> showcustomer()
        {
            List<CustomersModel> customers = new List<CustomersModel>();
            using(SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand("showcustomers", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        CustomersModel cust = new CustomersModel();
                        cust.customerid = Convert.ToInt32(reader["customerid"]);
                        cust.name = reader["cust_name"].ToString();
                        cust.contact = reader["contact"].ToString();
                        customers.Add(cust);
                    }
                }
                conn.Close();
            }
            return customers;
        }   
    }
}
