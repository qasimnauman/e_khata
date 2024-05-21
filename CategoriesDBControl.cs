using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace DataControllers
{
    public class CategoriesDBControl
    {
        public static void addcategory(CategoriesModel cat)
        {
            using(SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand("addcatergory", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@catid", cat.category_id);
                    cmd.Parameters.AddWithValue("@catname", cat.cat_name);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static void deletecategory(int cid)
        {
            using(SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand("deletecatergory", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@catid", cid);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static void updatecatergory(CategoriesModel cat)
        {
            using(SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand("updatecategory", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Catid", cat.category_id);
                    cmd.Parameters.AddWithValue("CatName", cat.cat_name);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static List<CategoriesModel> Showcategories()
        {
            List<CategoriesModel> categories = new List<CategoriesModel>();
            using(SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("shoecategories", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CategoriesModel cat = new CategoriesModel();
                        cat.category_id = Convert.ToInt32(reader["catergory_id"]);
                        cat.cat_name = reader["cat_name"].ToString();
                        categories.Add(cat);
                    }
                conn.Close();
                return categories;
            }
        }

        public static string getcatname(int pid)
        {
            string name = "";
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = "select cat_name from Catergories" +
                    "where catergory_id = (select cat_id from Products where product_id = @pid)";
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@pid", pid);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        name = reader["cat_name"].ToString();
                    }
                }
                conn.Close();
            }
            return name;
        }
    }
}
