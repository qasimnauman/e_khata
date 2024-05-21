using DataModels;
using System.Data;
using System.Data.SqlClient;

namespace DataControllers
{
    public class UserDBHControl
    {
        public static void Adduser(UserModel user)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmdd = new SqlCommand("adduserdata", conn))
                {
                    cmdd.CommandType = CommandType.StoredProcedure;
                    cmdd.Parameters.AddWithValue("@name", user.Username);
                    cmdd.Parameters.AddWithValue("@email", user.Email);
                    cmdd.Parameters.AddWithValue("@pass", user.Password);
                    cmdd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static bool Login(UserModel user)
        {
            using(SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using(SqlCommand cmdd = new SqlCommand("userlgin", conn))
                {
                    cmdd.CommandType = CommandType.StoredProcedure;
                    cmdd.Parameters.AddWithValue("@email", user.Email);
                    cmdd.Parameters.AddWithValue("@pass", user.Password);
                    int count = (int)cmdd.ExecuteScalar();
                    conn.Close();
                    return count > 0;
                }
            }
        }
    }
}
