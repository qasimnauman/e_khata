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
    public class TransactrionsDBControl
    {
        public static void addtransactions(TransactionModel transactionm)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmdd = new SqlCommand("addtransactions", conn))
                {
                    cmdd.CommandType = CommandType.StoredProcedure;
                    cmdd.Parameters.AddWithValue("@transid", transactionm.TransactionsId);
                    cmdd.Parameters.AddWithValue("@transdate", transactionm.transaction_date);
                    cmdd.Parameters.AddWithValue("@prodid", transactionm.product_id);
                    cmdd.Parameters.AddWithValue("@quantity", transactionm.qunatity);
                    cmdd.Parameters.AddWithValue("@unitprice", transactionm.unitprice);
                    cmdd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static List<TransactionModel> Showtransactionss()
        {
            List<TransactionModel> transactions = new List<TransactionModel>();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmdd = new SqlCommand("showtransactions", conn))
                {
                    cmdd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmdd.ExecuteReader();
                    while (reader.Read())
                    {
                        TransactionModel transaction = new TransactionModel();
                        transaction.TransactionsId = Convert.ToInt32(reader["transaction_id"]);
                        transaction.transaction_date = Convert.ToDateTime(reader["trasac_date"]);
                        transaction.product_id = Convert.ToInt32(reader["prod_id"]);
                        transaction.qunatity = Convert.ToInt32(reader["quantity"]);
                        transaction.unitprice = Convert.ToInt32(reader["unitprice"]);
                        transactions.Add(transaction);
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return transactions;
        }

        public static void updatetransactions(TransactionModel transaction)
        {
            using(SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using(SqlCommand cmdd = new SqlCommand("updatetransactions", conn))
                {
                    cmdd.CommandType = CommandType.StoredProcedure;
                    cmdd.Parameters.AddWithValue("@transid", transaction.TransactionsId);
                    cmdd.Parameters.AddWithValue("@ntransdate", transaction.transaction_date);
                    cmdd.Parameters.AddWithValue("@nprodid", transaction.product_id);
                    cmdd.Parameters.AddWithValue("@nquantity", transaction.qunatity);
                    cmdd.Parameters.AddWithValue("@nunitprice", transaction.unitprice);
                    cmdd.ExecuteNonQuery();
                }
                conn.Close();
            }   
        }

        public static void deletetransac(int transactionid)
        {
            using(SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using(SqlCommand cmdd = new SqlCommand("deletetransactions", conn))
                {
                    cmdd.CommandType = CommandType.StoredProcedure;
                    cmdd.Parameters.AddWithValue("@transid", transactionid);
                    cmdd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}
    