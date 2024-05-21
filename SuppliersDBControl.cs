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
                using(SqlCommand cmd = new SqlCommand("getsupplierdata", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<SuppliersModel> suppliers = new List<SuppliersModel>();
                    while(reader.Read())
                    {
                        SuppliersModel supplier = new SuppliersModel();
                        supplier.supplierid = Convert.ToInt32(reader["supplier_id"]);
                        supplier.name = reader["supplier_name"].ToString();
                        supplier.contact_supp = reader["supplier_contact"].ToString();
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
    }
}
