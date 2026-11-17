using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace The_Assembler
{
    internal class Products
    {
        public static void searchProduct(string productName)
        {
            frmProducts ProductWindow = new frmProducts();
            ProductWindow.searchDesiredProduct(productName);
            ProductWindow.Show();
        }

        public static DataSet ShowSearchedProducts(string productName)
        {
            string sqlQuery = "SELECT * FROM PRODUCTS WHERE ProductName LIKE '%" + productName + "%'";

            SqlConnection conn = DatabaseAssembler.OpenConnection();
            return DatabaseAssembler.ExecuteMultiRowQuery(sqlQuery);
        }

        public static DataSet ShowSearchedProducts()
        {
            string sqlQuery = "SELECT * FROM PRODUCTS";

            SqlConnection conn = DatabaseAssembler.OpenConnection();
            return DatabaseAssembler.ExecuteMultiRowQuery(sqlQuery);
        }
    }
}
