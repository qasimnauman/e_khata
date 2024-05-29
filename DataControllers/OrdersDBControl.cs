using DataModels;
using System.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Collections;

namespace DataControllers
{
    public class OrdersDBControl
    {
        public static void addordres(OrdersModel order)
        {
            String updatequery = "update Products set quantity = quantity - @qty where product_id = @prodid;";
            string statsupdatequery = "update Stats set totalordertaken = totalordertaken + 1;";
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("addorders",conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@orderid",order.orderid);
                    cmd.Parameters.AddWithValue("@date",order.orderdate);
                    cmd.Parameters.AddWithValue("@customerid",order.customerid);
                    cmd.Parameters.AddWithValue("@amount",order.billamount);
                    cmd.Parameters.AddWithValue("@prodid",order.productid);
                    cmd.Parameters.AddWithValue("@quantity",order.quantity);
                    cmd.ExecuteNonQuery();
                }
                using(SqlCommand cmd = new SqlCommand(updatequery,conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@qty", order.quantity);
                    cmd.Parameters.AddWithValue("@prodid", order.productid);
                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmd = new SqlCommand(statsupdatequery, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static List<OrdersModel> showorderdata()
        {
            List<OrdersModel> _orders = new List<OrdersModel>();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand("showOrders",conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        OrdersModel ord = new OrdersModel();
                        ord.orderid = Convert.ToInt32(reader["order_id"]);
                        ord.orderdate = DateTime.Parse(reader["order_date"].ToString());
                        ord.customerid = Convert.ToInt32(reader["cust_id"]);
                        ord.billamount = Convert.ToInt32(reader["amount"]);
                        ord.productid = Convert.ToInt32(reader["prod_id"]);
                        ord.quantity = Convert.ToInt32(reader["quantity"]);
                        ord.status = reader["status"].ToString();
                        _orders.Add(ord);
                    }
                }
                conn.Close();
                return _orders;
            }
        }

        public static void deleteorder(int orderid, int salesamount)
        {
            using(SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("deleteOrders",conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CurrentOrderID", orderid);
                    cmd.ExecuteNonQuery();
                }
                string updatequery = "update Stats set totalsales = totalsales + @slsamount, totalordercomplete = totalordercomplete + 1;";
                using(SqlCommand cmd =  new SqlCommand(updatequery, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@slsamount", salesamount);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static void updateorder(OrdersModel _order)
        {
            using(SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand("updateorder",conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@orderid", _order.orderid);
                    cmd.Parameters.AddWithValue("@ndate", _order.orderdate);
                    cmd.Parameters.AddWithValue("@ncustid", _order.customerid);
                    cmd.Parameters.AddWithValue("@namount", _order.billamount);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static int gettotalorders()
        {
            int nooforder = 0;
            string query = "SELECT COUNT(*) FROM Orders";
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    nooforder = (int)cmd.ExecuteScalar();
                }
                conn.Close();
            }
            return nooforder;
        }

        public static int getpendingorders()
        {
            int nooforder = 0;
            string query = "SELECT COUNT(*) FROM Orders where status = 'Pending';";
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    nooforder = (int)cmd.ExecuteScalar();
                }
                conn.Close();
            }
            return nooforder;
        }

        public static int getcompleteorders()
        {
            int nooforder = 0;
            string query = "SELECT COUNT(*) FROM Orders where status = 'Complete';";
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    nooforder = (int)cmd.ExecuteScalar();
                }
                conn.Close();
            }
            return nooforder;
        }

        public static void updateorderstatus(int oid, string sts)
        {
            string query = "update Orders set status = @status where order_id = @oid ;";
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@oid", oid);
                    cmd.Parameters.AddWithValue("@status", sts);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static string getordstatus(int oid)
        {
            string sts = "";
            string query = "select status from Orders where order_id = @ordid;";
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ordid", oid);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        sts = reader["status"].ToString();
                    }
                }
                conn.Close();
            }
            return sts;
        }

        public static void updatetotalorders()
        {
            string query = "update Stats set totalordertaken = totalordertaken + 1";
            using(SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}
