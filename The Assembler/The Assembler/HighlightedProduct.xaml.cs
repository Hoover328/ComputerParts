using MySqlConnector;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for HighlightedProduct.xaml
    /// </summary>
    public partial class HighlightedProduct : Window
    {
        public HighlightedProduct()
        {
            InitializeComponent();
            loadDesiredProduct(1);
        }

        private void txtProductName_Text(object sender, TextChangedEventArgs e)
        {
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        public void loadDesiredProduct(int productID)
        {
            using (MySqlDataReader read = HighlightedProducts.getDesiredProduct(productID))
            {
                txtProductName.Text = read["name"].ToString();
                txtProductPrice.Text = read["price"].ToString();
                txtProductDescription.Text = read["description"].ToString();
            }
        }
    }
}
