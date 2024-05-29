using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControllers
{
    public class DBHelper
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-D4M3HH9\\SQLEXPRESS;Initial Catalog=IMSProject;Integrated Security=True");
            return connection;
        }
    }
}
