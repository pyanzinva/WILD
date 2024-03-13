using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace WILD.Models
{
    class DataBase
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-VINGOMG;Initial Catalog=Kak;Integrated Security=True;TrustServerCertificate = True");

        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }

        public bool IsLoginValid(string username, string password)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password", sqlConnection))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                openConnection();
                int userCount = (int)cmd.ExecuteScalar();
                closeConnection();
                return userCount > 0;
            }
        }

        public string GetUserRole(string username, string password)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT Role FROM Users WHERE Username = @username AND Password = @password", sqlConnection))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                openConnection();
                object result = cmd.ExecuteScalar();
                closeConnection();
                return result as string;
            }
        }

    }
}
