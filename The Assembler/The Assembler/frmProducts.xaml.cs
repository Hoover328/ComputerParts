using Microsoft.Data.SqlClient;
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
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class frmProducts : Window
    {
        string productNameSearch = "";
        string productPriceSearch = "";
        string productDescriptionSearch = "";

        public frmProducts()
        {
            InitializeComponent();
            
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ApplyFilters(object sender, RoutedEventArgs e)
        {

        }

        private void ApplyFilters_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SortCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearFilters_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Previous_Click(object sender, RoutedEventArgs e)
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

        private void Cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        public void searchDesiredProduct(string productName)
        {
            if (productName == "")
            {
                DataSet searchedIds = Products.ShowSearchedProducts();
                dgSearchedProducts.ItemsSource = searchedIds.Tables[0].DefaultView;
            }

            else
            {
                DataSet searchedIds = Products.ShowSearchedProducts(productName);
                dgSearchedProducts.ItemsSource = searchedIds.Tables[0].DefaultView;
            }
        }

        private void dgSearchedProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgSearchedProducts.SelectedItem is DataRowView rowView)
            {
                int selectedProductId = Convert.ToInt32(rowView["ProductID"]);
                HighlightedProducts.openHighlightedProduct(selectedProductId);

            }
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            searchDesiredProduct(txtSearchBar.Text);
        }
    }
}
