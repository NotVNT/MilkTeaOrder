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
        SqlCommand SqlCommand; //truy vấn các câu lệnh crud,....
        SqlDataReader dataReader; // đọc dữ liệu trong bảng
        public List<Account> Accounts(string query)
        {
            List<Account> accounts = new List<Account>();
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                SqlCommand = new SqlCommand(query, sqlConnection);
                dataReader = SqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    accounts.Add(new Account(dataReader.GetString(0),dataReader.GetString(1)));
                }
                sqlConnection.Close();
            }
                return accounts;
        }
        // hàm này dùng để Đăng ký tài khoản
        public void Command(string query)
        {
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                SqlCommand = new SqlCommand (query, sqlConnection);
                SqlCommand.ExecuteNonQuery(); // thực thi câu truy vấn
                sqlConnection.Close();
            }
        }
    }
}
