using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataModels;
using System.Data.SqlClient;

namespace DataControllers
{
    public class SuppliersDBControl
    {
        public static void addsupplier(SuppliersModel supplier)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand("addsupplier", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@supid", supplier.supplierid);
                    cmd.Parameters.AddWithValue("@supname", supplier.name);
                    cmd.Parameters.AddWithValue("@supcontact", supplier.contact_supp);
                    cmd.Parameters.AddWithValue("@citytype", supplier.citytype);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static List<SuppliersModel> showsupplierdata()
        {
            using(SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand("showsupplier", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<SuppliersModel> suppliers = new List<SuppliersModel>();
                    while(reader.Read())
                    {
                        SuppliersModel supplier = new SuppliersModel();
                        supplier.supplierid = Convert.ToInt32(reader["supplier_id"]);
                        supplier.name = reader["supplier_name"].ToString();
                        supplier.contact_supp = reader["supp_contact"].ToString();
                        supplier.citytype = reader["citytype"].ToString();
                        suppliers.Add(supplier);
                    }
                    return suppliers;
                }
            }
        }

        public static void updatesupplier(SuppliersModel supplier)
        {
            using(SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("updatesupplier", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@supid", supplier.supplierid);
                    cmd.Parameters.AddWithValue("@nsupname", supplier.name);
                    cmd.Parameters.AddWithValue("@nsupcontact", supplier.contact_supp);
                    cmd.Parameters.AddWithValue("@ncitytype", supplier.citytype);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static void deletesupplier(int supid)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand("deletesupplier", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@supid", supid);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static int gettotalsup()
        {
            int no = 0;
            string query = "select count(*) from Suppliers;";
            using(SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    no = (int)cmd.ExecuteScalar();
                }
                conn.Close();
            }
            return no;
        }

        public static int getincitysup()
        {
            int no = 0;
            string query = "select count(*) from Suppliers where citytype = 'InCity';";
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    no = (int)cmd.ExecuteScalar();
                }
                conn.Close();
            }
            return no;
        }

        public static int getoutcitysup()
        {
            int no = 0;
            string query = "select count(*) from Suppliers where citytype = 'OutCity';";
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    no = (int)cmd.ExecuteScalar();
                }
                conn.Close();
            }
            return no;
        }
    }
}
