using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OrderMillTeaProgram
{
    class Connection
    {

        private static readonly string stringConnection = @"Data Source=laptop-o9g07qpa;Initial Catalog=UserInfo;Persist Security Info=True;User ID=sa;Password=***********;TrustServerCertificate=True";

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(stringConnection);
        }
    }
}