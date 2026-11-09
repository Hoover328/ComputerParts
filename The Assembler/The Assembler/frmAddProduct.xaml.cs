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
            txtProductID.Text = (HighlightedProducts.GetNextProductID()).ToString();
            txtProductPrice.Text = "€";
            

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
            HighlightedProducts newProduct = new HighlightedProducts();
            if (newProduct.Validator(txtProductName, txtProductPrice, txtProductDescription, chkAvailability, txtProductID) == true)
            {
                newProduct.AddProduct(HighlightedProducts.GetNextProductID(), txtProductName.Text, txtProductDescription.Text, availability, txtProductPrice.Text);
                txtProductDescription.Text = "";
                txtProductName.Text = "";
                txtProductPrice.Text = "€";
                txtProductID.Text = (HighlightedProducts.GetNextProductID()).ToString();
            }

        }

        

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
