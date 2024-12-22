using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMillTeaProgram
{
    class Modify
    {
        public Modify()
        {

        }
        public List<Account> Accounts(string query)
        {
            List<Account> accounts = new List<Account>();
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            accounts.Add(new Account(dataReader.GetString(0), dataReader.GetString(1)));
                        }
                    }
                }
            }
            return accounts;
        }
        // hàm này dùng để Đăng ký tài khoản
        public void Command(string query, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            sqlCommand.Parameters.AddWithValue(parameter.Key, parameter.Value);
                        }
                    }
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
    }
}

