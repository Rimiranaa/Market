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
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            InitializeComponent();
            List<Category> categories = ShopEntities1.GetContext().Category.ToList();
            foreach (Category c in categories)
            {
                CategoryBox.Items.Add(c.nameCategory);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DB.Product product = new DB.Product();
            product.nameProduct = NameProductBox.Text;
            product.description = DescriptionBox.Text;
            product.quantityStock = QuantityBox.Text;
            product.price = int.Parse(PriceBox.Text);
            product.idCategory = ShopEntities1.GetContext().Category.Where(c => c.nameCategory == CategoryBox.Text).ToList()[0].idCategory;
            ShopEntities1.GetContext().Product.Add(product);
            ShopEntities1.GetContext().SaveChanges();
            Close();
        }
    }
}
