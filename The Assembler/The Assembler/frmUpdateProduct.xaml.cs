using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for frmUpdateProduct.xaml
    /// </summary>
    public partial class frmUpdateProduct : Window
    {
        string availability = "";

        public frmUpdateProduct()
        {
            InitializeComponent();
            dgSearchedProducts.IsEnabled = false;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            dgSearchedProducts.IsEnabled = true;

            if (txtProductID.Text != "")
            {
                DataSet searchedIds = HighlightedProducts.getAllDesiredProducts(Convert.ToInt32(txtProductID.Text));
                dgSearchedProducts.ItemsSource = searchedIds.Tables[0].DefaultView;
            }

            else
            {
                DataSet searchedIds = HighlightedProducts.getAllDesiredProducts();
                dgSearchedProducts.ItemsSource = searchedIds.Tables[0].DefaultView;

            }
        }

        private void btnUpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            HighlightedProducts newProduct = new HighlightedProducts();
            if (newProduct.Validator(txtProductName, txtProductPrice, txtProductDescription, chkAvailability, txtProductID) == true)
            {
                newProduct.UpdateProduct(HighlightedProducts.GetNextProductID(), txtProductName.Text, txtProductDescription.Text, availability, txtProductPrice.Text);
                txtProductDescription.Text = "";
                txtProductName.Text = "";
                txtProductPrice.Text = "€";
                txtProductID.Text = (HighlightedProducts.GetNextProductID()).ToString();
            }
        }

        private void txtProductID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtProductName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtProductPrice_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, TextChangedEventArgs e)
        {

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

        private void dgSearchedProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           if(dgSearchedProducts.SelectedItem is DataRowView rowView)
            {
                txtProductName.Text = rowView["ProductName"]?.ToString() ?? string.Empty;
                txtProductDescription.Text = rowView["Description"]?.ToString() ?? string.Empty;
                txtProductPrice.Text = rowView["Price"]?.ToString() ?? string.Empty;
                
                if(rowView["Availability"].ToString() == "In Stock")
                {
                    chkAvailability.IsChecked = true;
                }
                else
                {
                    chkAvailability.IsChecked = false;
                }


            }
        }

        private void chkAvailability_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
