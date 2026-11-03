using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Microsoft.Data.SqlClient;

namespace The_Assembler
{
    internal class HighlightedProducts
    {
        public static SqlDataReader getDesiredProduct(int productID)
        {
            string sqlQuery = "SELECT * FROM PRODUCTS WHERE ProductID = " + productID;

            SqlConnection conn = DatabaseAssembler.OpenConnection();
            return DatabaseAssembler.ExecuteSingleRowQuery(sqlQuery, conn);
        }

        public static void openHighlightedProduct(int productID)
        {
            frmHighlightedProduct highlightedProductWindow = new frmHighlightedProduct();
            highlightedProductWindow.loadDesiredProduct(productID);
            highlightedProductWindow.Show();
        }

       
    }
}
