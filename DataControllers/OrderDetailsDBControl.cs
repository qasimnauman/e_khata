using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace DataControllers
{
    public class OrderDetailsDBControl
    {
        public static void AddOrderDetails(OrderDetailsModel orddetail)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("addorderdetails", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ord_detail_id", orddetail.orderdetailid);
                    cmd.Parameters.AddWithValue("@orderid", orddetail.orderid);
                    cmd.Parameters.AddWithValue("@prod_id", orddetail.productid);
                    cmd.Parameters.AddWithValue("@quantity", orddetail.quantity);
                    cmd.Parameters.AddWithValue("@amount", orddetail.billamount);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static void deleetorderdetails(int orddetid)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ord_detail_id", orddetid);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static void updateorderdetails(OrderDetailsModel orddet)
        {
            using(SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand("updateorderdetails", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ord_detail_id", orddet.orderdetailid);
                    cmd.Parameters.AddWithValue("@norderid", orddet.orderid);
                    cmd.Parameters.AddWithValue("@nprod_id", orddet.productid);
                    cmd.Parameters.AddWithValue("@nquantity", orddet.quantity);
                    cmd.Parameters.AddWithValue("@namount", orddet.billamount);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public List<OrderDetailsModel> getorderdetails()
        {
            using(SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand("showorderdetails", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<OrderDetailsModel> orderdetails = new List<OrderDetailsModel>();
                    while(reader.Read())
                    {
                        OrderDetailsModel orddet = new OrderDetailsModel();
                        orddet.orderdetailid = Convert.ToInt32(reader["ord_detail_id"]);
                        orddet.orderid = Convert.ToInt32(reader["order_id"]);
                        orddet.productid = Convert.ToInt32(reader["prod_id"]);
                        orddet.quantity = Convert.ToInt32(reader["quantity"]);
                        orddet.billamount = Convert.ToInt32(reader["amount"]);
                        orderdetails.Add(orddet);
                    }
                    return orderdetails;
                }
            }
        }
    }
}
