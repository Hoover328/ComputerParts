using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO.Packaging;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace The_Assembler
{
    /// <summary>
    /// Interaction logic for frmAddProduct.xaml
    /// </summary>
    public partial class frmAddProduct : Window
    {
        string availability = "";
        public frmAddProduct()
        {
            InitializeComponent();
            txtProductID.Text = (GetNextProductID()).ToString();
            txtProductPrice.Text = "€";
            

        }

        public void Validator()
        {
            if (txtProductName.Text.Equals(""))
            {
                System.Windows.MessageBox.Show("Product name must be entered",
                "Warning",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
                txtProductName.Focus();
                return;
            }

            if (txtProductPrice.Text.Equals("€") || txtProductPrice.Text.Equals(""))
            {
                System.Windows.MessageBox.Show("Product price must be entered",
                "Warning",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
                txtProductPrice.Focus();
                return;
            }

            if (txtProductDescription.Text.Equals(""))
            {
                System.Windows.MessageBox.Show("Product description must be entered",
                "Warning",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
                txtProductDescription.Focus();
                return;
            }
            
            if (txtProductPrice.Text[0] != '€')
            {
                System.Windows.MessageBox.Show("Product price must start with a €",
                "Warning",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
                txtProductDescription.Focus();
                return;
            }

            int thirdLast = (txtProductPrice.Text).Length - 3;
            if (txtProductPrice.Text[thirdLast] != '.')
            {
                System.Windows.MessageBox.Show("Product price must written in format €x.xx (example: €123.45)",
                "Warning",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
                txtProductDescription.Focus();
                return;
            }

            else
            {
                if (chkAvailability.IsChecked == true)
                {
                    availability = "In Stock";
                }

                else
                {
                    availability = "Out Of Stock";
                }

                AddProduct(GetNextProductID(), txtProductName.Text, txtProductDescription.Text, availability, txtProductPrice.Text);
                System.Windows.MessageBox.Show("Product added successfully",
                "Congrats",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
                txtProductDescription.Focus();

                txtProductName.Clear();
                txtProductDescription.Clear();
                txtProductPrice.Text = "€";
                txtProductID.Text = (GetNextProductID()).ToString();


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

        private void txtProductName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtProductDescription_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtProductPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void txtProductID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {

            Validator();
        }

        public static int GetNextProductID()
        {
            string sqlQuery = "SELECT MAX(ProductID) AS MaxProdID FROM Products";
            SqlConnection conn = DatabaseAssembler.OpenConnection();
            var reader =  DatabaseAssembler.ExecuteSingleRowQuery(sqlQuery, conn);

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
