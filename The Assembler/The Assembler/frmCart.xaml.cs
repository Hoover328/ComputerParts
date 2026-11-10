using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace The_Assembler
{
    /// <summary>
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class frmCart : Window
    {
        private const int CurrentAccountId = 3;

        private int? selectedCartId = null;
        private int? selectedProductId = null;

        public frmCart()
        {
            InitializeComponent();

        }

        private void btnMain_Click(object sender, RoutedEventArgs e)
        {
            frmMainWindow mainWindow = new frmMainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCartData();
        }

        private void LoadCartData()
        {
            try
            {
                string query = $@"SELECT c.CartID, p.ProductID, p.ProductName, p.Price 
                                 FROM CARTS c
                                 JOIN PRODUCTS p ON c.ProductID = p.ProductID
                                 WHERE c.AccountID = {CurrentAccountId}";

                DataSet ds = DatabaseAssembler.ExecuteMultiRowQuery(query);

                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    dataGrid.ItemsSource = dt.DefaultView;

                    decimal grandTotal = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["Price"] != DBNull.Value)
                        {
                            string priceString = row["Price"].ToString().Replace("€", "").Trim();
                            if (decimal.TryParse(priceString, out decimal price))
                            {
                                grandTotal += price;
                            }
                        }
                    }

                    subSum.Text = $"€{grandTotal:N2}";
                    totalSum.Text = $"€{grandTotal:N2}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading cart: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem is DataRowView rowView)
            {
                selectedCartId = Convert.ToInt32(rowView["CartID"]);
                selectedProductId = Convert.ToInt32(rowView["ProductID"]);
            }
        }

        private void RmvItem_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCartId == null)
            {
                MessageBox.Show("Please select an item from the cart to remove.", "Selection Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                string deleteQuery = $"DELETE FROM CARTS WHERE CartID = {selectedCartId}";
                DatabaseAssembler.ExecuteNonQuery(deleteQuery);

                selectedCartId = null;
                selectedProductId = null;
                LoadCartData();

                MessageBox.Show("Item removed from cart.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing item: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddItem_Clicked(object sender, RoutedEventArgs e)
        {
            if (selectedProductId == null)
            {
                MessageBox.Show("Please select an item from the cart to add quantity/another entry.", "Selection Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                string insertQuery = $"INSERT INTO CARTS (AccountID, ProductID) VALUES ({CurrentAccountId}, {selectedProductId})";
                DatabaseAssembler.ExecuteNonQuery(insertQuery);

                LoadCartData();
                MessageBox.Show("Item added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding item: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
