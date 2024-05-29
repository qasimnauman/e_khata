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
    public class StatsDBControl
    {
        public static List<StatsModel> GetStats()
        {
            List<StatsModel> stats = new List<StatsModel>();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "select * from Stats";
                using (SqlCommand cmdd = new SqlCommand(query, conn))
                {
                    cmdd.CommandType = CommandType.Text;
                    SqlDataReader reader = cmdd.ExecuteReader();
                    while (reader.Read())
                    {
                        StatsModel stat = new StatsModel();
                        stat.totalsales = Convert.ToInt32(reader["totalsales"]);
                        stat.totalorderstaken = Convert.ToInt32(reader["totalordertaken"]);
                        stat.totalordercomplete = Convert.ToInt32(reader["totalordercomplete"]);
                        stats.Add(stat);
                    }
                }
                conn.Close();
                return stats;
            }
            
        }       
    }
}
