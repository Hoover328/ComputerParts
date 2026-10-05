using System;
using System.Threading.Tasks;
using MySqlConnector;

namespace The_Assembler
{
    internal class DatabaseAssembler
    {
        static async Task Main(string[] args)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "mysqlserverassembly.database.windows.net",
                Database = "mySampleDatabase",
                UserID = "azureuser",
                Password = "admin123!",
                SslMode = MySqlSslMode.Required,
            };

            using (var conn = new MySqlConnection(builder.ConnectionString))
            {
                Console.WriteLine("Opening connection");
                await conn.OpenAsync();

             

                // connection will be closed by the 'using' block
                Console.WriteLine("Closing connection");
            }

            Console.WriteLine("Press RETURN to exit");
            Console.ReadLine();
        }

        public static MySqlDataReader ExecuteSingleRowQuery(string query, MySqlConnection conn)
        {
            var cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }


    }
}


