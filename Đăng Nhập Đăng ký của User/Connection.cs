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

        private static string stringConnection = @"Data Source=VinhNgocTran\SQLEXPRESS02;Initial Catalog=UserInfo;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(stringConnection);
        }
    }
}