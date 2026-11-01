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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCart_Click(object sender, RoutedEventArgs e)
        {
            Cart cartWindow = new Cart();
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
            HighlightedProduct highlightedProductWindow = new HighlightedProduct();
            highlightedProductWindow.Show();
        }

        private void btnProduct2_Click(object sender, RoutedEventArgs e)
        {
            HighlightedProduct highlightedProductWindow = new HighlightedProduct();
            highlightedProductWindow.Show();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}