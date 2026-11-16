using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace The_Assembler
{
    internal class DatabaseAssembler
    {
        private static string GetConnectionString()
        {
            string[] lines = File.ReadAllLines("credentials.txt");
            string userId = lines[0].Trim();
            string password = lines[1].Trim();

            return $@"Server=tcp:mysqlserverassembly.database.windows.net,1433;Initial Catalog=mySampleDatabase;User ID={userId};Password={password};Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
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


