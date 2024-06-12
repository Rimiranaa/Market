using Market.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Market.Views
{
    /// <summary>
    /// Логика взаимодействия для ProductAndCategoryM.xaml
    /// </summary>
    public partial class ProductAndCategoryM : Window
    {
        public ProductAndCategoryM()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ManagerWindow managerWindow = new ManagerWindow();
            managerWindow.Show();
            Close();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Product> products = new List<Product>();
            Products.ItemsSource = null;
            Products.ItemsSource = ShopEntities1.GetContext().Product.ToList();
            if (SearchBox.Text == string.Empty || SearchBox.Text == "")
            {
                Products.ItemsSource = null;
                Products.ItemsSource = ShopEntities1.GetContext().Product.ToList();
            }
            else
            {
                foreach (Product product in Products.Items)
                {
                    if (product.nameProduct.Contains(SearchBox.Text) || product.description.Contains(SearchBox.Text))
                    {
                        products.Add(product);
                    }
                }
                Products.ItemsSource = null;
                Products.ItemsSource = products;
            }
        }
    }
}
