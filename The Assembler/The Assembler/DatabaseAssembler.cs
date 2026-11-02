using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace The_Assembler
{
    internal class DatabaseAssembler
    {
        private static string GetConnectionString()
        {
            // Placed your Azure SQL connection string directly here
            return @"Server=tcp:mysqlserverassembly.database.windows.net,1433;Initial Catalog=mySampleDatabase;User ID=azureuser;Password=admin123!;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

        public static SqlConnection OpenConnection()
        {
            var connection = new SqlConnection(GetConnectionString());
            connection.Open();
            return connection;
        }



        public static DataSet ExecuteMultiRowQuery(string query)
        {
            using (var connection = OpenConnection())
            using (var command = new SqlCommand(query, connection))
            using (var adapter = new SqlDataAdapter(command))
            {
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                return dataSet;
            }
        }

        public static SqlDataReader ExecuteSingleRowQuery(string query, SqlConnection conn)
        {
            var cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }

        // Used for insert, update, delete, doesn't return any data
        public static void ExecuteNonQuery(string query)
        {
            using (var connection = OpenConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }

    }
}


