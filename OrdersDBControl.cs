using DataModels;
using System.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControllers
{
    public class OrdersDBControl
    {
        public static void addordres(OrdersModel order)
        {
            using(SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("addorders",conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@orderid",order.orderid);
                    cmd.Parameters.AddWithValue("@date",order.orderdate);
                    cmd.Parameters.AddWithValue("@customerid",order.customerid);
                    cmd.Parameters.AddWithValue("@amount",order.billamount);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public List<OrdersModel> showorderdata()
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
                        ord.orderdate = DateOnly.Parse(reader["order_date"].ToString());
                        ord.customerid = Convert.ToInt32(reader["cust_id"]);
                        ord.billamount = Convert.ToInt32(reader["amount"]);
                        _orders.Add(ord);
                    }
                }
                conn.Close();
                return _orders;
            }
        }

        public static void deleteorder(int orderid)
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
    }
}
