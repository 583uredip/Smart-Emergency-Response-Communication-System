using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Final_Project_1.Models
{
    public static class DBHelper
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(@"Data Source=desktop-udmdgkf\sqlexpress;Initial Catalog=Smart Emargency System Bd;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
