using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace The_Assembler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class frmMainWindow : Window
    {
        public frmMainWindow()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCart_Click(object sender, RoutedEventArgs e)
        {
            frmCart cartWindow = new frmCart();
            cartWindow.Show();
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnProduct1_Click(object sender, RoutedEventArgs e)
        {
            HighlightedProducts.openHighlightedProduct(0);
        }

        private void btnProduct2_Click(object sender, RoutedEventArgs e)
        {
            HighlightedProducts.openHighlightedProduct(1);
        }

        private void btnProduct3_Click(object sender, RoutedEventArgs e)
        {
            HighlightedProducts.openHighlightedProduct(3);
        }

        private void btnProduct4_Click(object sender, RoutedEventArgs e)
        {
            HighlightedProducts.openHighlightedProduct(4);
        }

        private void btnProduct5_Click(object sender, RoutedEventArgs e)
        {
            HighlightedProducts.openHighlightedProduct(5);
        }

        private void btnProduct6_Click(object sender, RoutedEventArgs e)
        {
            HighlightedProducts.openHighlightedProduct(6);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            frmAdmin adminWindow = new frmAdmin();
            adminWindow.Show();
        }
    }
}