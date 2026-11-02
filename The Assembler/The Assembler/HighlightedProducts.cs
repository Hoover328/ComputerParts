using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace The_Assembler
{
    internal class HighlightedProducts
    {
        public static SqlDataReader getDesiredProduct(int productID)
        {
            string sqlQuery = "SELECT * FROM Products WHERE ProductID = " + productID;

            SqlConnection conn = DatabaseAssembler.OpenConnection();
            return DatabaseAssembler.ExecuteSingleRowQuery(sqlQuery, conn);
        }

       
    }
}
