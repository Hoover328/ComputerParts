using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace The_Assembler
{
    internal class HighlightedProducts
    {
        public static MySqlDataReader getDesiredProduct(int productID)
        {
            string sqlQuery = "SELECT * FROM Products WHERE ProductID = " + productID;

            MySqlConnection conn = DatabaseAssembler.OpenConnection();
            return DatabaseAssembler.ExecuteSingleRowQuery(sqlQuery, conn);
        }

       
    }
}
