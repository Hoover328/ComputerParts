using MySqlConnector;
using System;
using System.Data;
using System.Threading.Tasks;

namespace The_Assembler
{
    internal class DatabaseAssembler
    {
        private static string GetConnectionString() 
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "mysqlserverassembly.database.windows.net",
                Database = "mySampleDatabase",
                UserID = "azureuser",
                Password = "admin123!",
                SslMode = MySqlSslMode.Required,
            };

            return builder.ConnectionString;
        }

        public static MySqlConnection OpenConnection()
        {
            var connection = new MySqlConnection(GetConnectionString());
            connection.Open();
            return connection;
        }

        public static DataSet executeMultiRowQuery(string query)
        {
            using (var connection = OpenConnection())
            using (var command = new MySqlCommand(query, connection))
            using (var adapter = new MySqlDataAdapter(command))
            {
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                return dataSet;
            }
        }
        public static MySqlDataReader ExecuteSingleRowQuery(string query, MySqlConnection conn)
        {
            var cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }

        //used for insert, update, delete, doesnt return any data
        public static void executeNonQuery(string query)
        {
            using (var connection = OpenConnection())
            using (var command = new MySqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }

    }
}


