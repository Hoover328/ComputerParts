using Microsoft.Data.SqlClient;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

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

        public static DataSet getAllDesiredProducts(int productID)
        {
            string sqlQuery = "SELECT * FROM PRODUCTS WHERE ProductID = " + productID;

            SqlConnection conn = DatabaseAssembler.OpenConnection();
            return DatabaseAssembler.ExecuteMultiRowQuery(sqlQuery);
        }

        public static DataSet getAllDesiredProducts()
        {
            string sqlQuery = "SELECT * FROM PRODUCTS";

            SqlConnection conn = DatabaseAssembler.OpenConnection();
            return DatabaseAssembler.ExecuteMultiRowQuery(sqlQuery);
        }

        public static void openHighlightedProduct(int productID)
        {
            frmHighlightedProduct highlightedProductWindow = new frmHighlightedProduct();
            highlightedProductWindow.loadDesiredProduct(productID);
            highlightedProductWindow.Show();
        }

        public bool Validator(TextBox txtProductName, TextBox txtProductPrice, TextBox txtProductDescription, CheckBox chkAvailability, TextBox txtProductID)
        {
            string availability;
            if (txtProductName.Text.Equals(""))
            {
                System.Windows.MessageBox.Show("Product name must be entered",
                "Warning",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
                txtProductName.Focus();
                return false;
            }

            if (txtProductPrice.Text.Equals("€") || txtProductPrice.Text.Equals(""))
            {
                System.Windows.MessageBox.Show("Product price must be entered",
                "Warning",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
                txtProductPrice.Focus();
                return false;
            }

            if (txtProductDescription.Text.Equals(""))
            {
                System.Windows.MessageBox.Show("Product description must be entered",
                "Warning",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
                txtProductDescription.Focus();
                return false;
            }

            if (txtProductPrice.Text[0] != '€')
            {
                System.Windows.MessageBox.Show("Product price must start with a €",
                "Warning",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
                txtProductDescription.Focus();
                return false;
            }

            int thirdLast = (txtProductPrice.Text).Length - 3;
            if (txtProductPrice.Text[thirdLast] != '.')
            {
                System.Windows.MessageBox.Show("Product price must written in format €x.xx (example: €123.45)",
                "Warning",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
                txtProductDescription.Focus();
                return false;
            }

            else
            {
                if (chkAvailability.IsChecked == true)
                {
                    availability = "In Stock";
                    System.Windows.MessageBox.Show("Product Added",
                "Warning",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
                    return true;
                }

                else
                {
                    availability = "Out Of Stock";
                    System.Windows.MessageBox.Show("Product Added",
               "Warning",
               MessageBoxButton.OK,
               MessageBoxImage.Information);
                    return true;

                }
            }
        }

        public void AddProduct(int ProductID, string ProductName, string Description, string Availability, string Price)
        {
            string sqlQuery = "SET IDENTITY_INSERT PRODUCTS ON; " +
        "INSERT INTO PRODUCTS(ProductID, ProductName, Description, Availability, Price) " +
        "VALUES(" + ProductID + ", '" + ProductName + "', '" + Description + "', '" + Availability + "', '" + Price + "'); " +
        "SET IDENTITY_INSERT PRODUCTS OFF;";

            DatabaseAssembler.ExecuteNonQuery(sqlQuery);
        }

        public void UpdateProduct(int ProductID, string ProductName, string Description, string Availability, string Price)
        {
            string sqlQuery = "SET IDENTITY_INSERT PRODUCTS ON; " +
        "UPDATE PRODUCTS SET ProductName = " + ProductName + "SET Description = " + Description + 
        "SET Availability = " + Availability + "SET Price = " + Price + "WHERE ProductID = " + ProductID + 
        "SET IDENTITY_INSERT PRODUCTS OFF;";

            DatabaseAssembler.ExecuteNonQuery(sqlQuery);
        }

        public static int GetNextProductID()
        {
            string sqlQuery = "SELECT MAX(ProductID) AS MaxProdID FROM Products";
            SqlConnection conn = DatabaseAssembler.OpenConnection();
            var reader = DatabaseAssembler.ExecuteSingleRowQuery(sqlQuery, conn);

            int nextID = 1;
            if (reader.Read())
            {
                if (!reader.IsDBNull(0))
                {
                    nextID = reader.GetInt32(0) + 1;
                }
            }
            reader.Close();
            return nextID;
        }


    }
}
