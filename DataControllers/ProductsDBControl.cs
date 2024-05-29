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
    public class ProductsDBControl
    {
        public static void addproduct(ProductsModel product)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmdd = new SqlCommand("addproduct", conn))
                {
                    cmdd.CommandType = CommandType.StoredProcedure;
                    cmdd.Parameters.AddWithValue("@prodid", product.productid);
                    cmdd.Parameters.AddWithValue("@prodname", product.Name);
                    cmdd.Parameters.AddWithValue("@price", product.price);
                    cmdd.Parameters.AddWithValue("@quantity", product.quantity);
                    cmdd.Parameters.AddWithValue("@cat_id", product.category_id);
                    cmdd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static List<ProductsModel> Getproducts()
        {
            List<ProductsModel> products = new List<ProductsModel>();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "select * from Products";
                using (SqlCommand cmdd = new SqlCommand(query, conn))
                {
                    cmdd.CommandType = CommandType.Text;
                    SqlDataReader reader = cmdd.ExecuteReader();
                    while (reader.Read())
                    {
                        ProductsModel product = new ProductsModel();
                        product.productid = Convert.ToInt32(reader["product_id"]);
                        product.Name = reader["product_name"].ToString();
                        product.price = Convert.ToInt32(reader["price"]);
                        product.quantity = Convert.ToInt32(reader["quantity"]);
                        product.category_id = Convert.ToInt32(reader["cat_id"]);
                        products.Add(product);
                    }
                }
                conn.Close();
                return products;
            }
            
        }

        public static void updateproduct(ProductsModel product)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmdd = new SqlCommand("updateproduct", conn))
                {
                    cmdd.CommandType = CommandType.StoredProcedure;
                    cmdd.Parameters.AddWithValue("@prodid", product.productid);
                    cmdd.Parameters.AddWithValue("@newname", product.Name);
                    cmdd.Parameters.AddWithValue("@newprice", product.price);
                    cmdd.Parameters.AddWithValue("@newquantity", product.quantity);
                    cmdd.Parameters.AddWithValue("@newcatid", product.category_id);
                    cmdd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static void deleteproduct(int id)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmdd = new SqlCommand("deleteproduct", conn))
                {
                    cmdd.CommandType = CommandType.StoredProcedure;
                    cmdd.Parameters.AddWithValue("@prodid", id);
                    cmdd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static List<ProductsModel> Getproducts(int pid)
        {
            List<ProductsModel> products = new List<ProductsModel>();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "select * from Products where product_id = @pid;";
                using (SqlCommand cmdd = new SqlCommand(query, conn))
                {
                    cmdd.CommandType = CommandType.Text;
                    cmdd.Parameters.AddWithValue("@pid", pid);
                    SqlDataReader reader = cmdd.ExecuteReader();
                    while (reader.Read())
                    {
                        ProductsModel product = new ProductsModel();
                        product.productid = Convert.ToInt32(reader["product_id"]);
                        product.Name = reader["product_name"].ToString();
                        product.price = Convert.ToInt32(reader["price"]);
                        product.quantity = Convert.ToInt32(reader["quantity"]);
                        product.category_id = Convert.ToInt32(reader["cat_id"]);
                        products.Add(product);
                    }
                }
                conn.Close();
                return products;
            }
        }

        public static int Getproductamount(int pid)
        {
            int amount = 0;
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "select price from Products where product_id = @pid;";
                using (SqlCommand cmdd = new SqlCommand(query, conn))
                {
                    cmdd.CommandType = CommandType.Text;
                    cmdd.Parameters.AddWithValue("@pid", pid);
                    SqlDataReader reader = cmdd.ExecuteReader();
                    while (reader.Read())
                    {
                        amount = Convert.ToInt32(reader["price"]);
                    }
                }
                conn.Close();
                return amount;
            }
        }

        public static int getquantity(int pid)
        {
            int amount = 0;
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "select quantity from Products where product_id = @pid;";
                using (SqlCommand cmdd = new SqlCommand(query, conn))
                {
                    cmdd.CommandType = CommandType.Text;
                    cmdd.Parameters.AddWithValue("@pid", pid);
                    SqlDataReader reader = cmdd.ExecuteReader();
                    while (reader.Read())
                    {
                        amount = Convert.ToInt32(reader["quantity"]);
                    }
                }
                conn.Close();
                return amount;
            }
        }

        public static int getnoofproducts()
        {
            int no = 0;
            string query = "select count(*) from Products";
            using(SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    no = (int)cmd.ExecuteScalar();
                }
                conn.Close();
            }
            return no;
        }

        public static List<ProductsModel> Getproductbycat(int cid)
        {
            List<ProductsModel> products = new List<ProductsModel>();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "select product_id,product_name,price,quantity,cat_id from Products where cat_id = @cid order by cat_id;";
                using (SqlCommand cmdd = new SqlCommand(query, conn))
                {
                    cmdd.CommandType = CommandType.Text;
                    cmdd.Parameters.AddWithValue("@cid", cid);
                    SqlDataReader reader = cmdd.ExecuteReader();
                    while (reader.Read())
                    {
                        ProductsModel product = new ProductsModel();
                        product.productid = Convert.ToInt32(reader["product_id"]);
                        product.Name = reader["product_name"].ToString();
                        product.price = Convert.ToInt32(reader["price"]);
                        product.quantity = Convert.ToInt32(reader["quantity"]);
                        product.category_id = Convert.ToInt32(reader["cat_id"]);
                        products.Add(product);
                    }
                }
                conn.Close();
                return products;
            }
        }

    }
}
