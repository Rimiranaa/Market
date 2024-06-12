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
    /// Логика взаимодействия для EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        Product product;
        public EditProductWindow(Product selectedProduct)
        {
            InitializeComponent();
            product = selectedProduct;
            List<Category> categories = ShopEntities1.GetContext().Category.ToList();
            foreach (Category c in categories)
            {
                CategoryBox.Items.Add(c.nameCategory);
            }
            QuantityBox.Text = selectedProduct.quantityStock;
            DescriptionBox.Text = selectedProduct.description;
            NameProductBox.Text = selectedProduct.nameProduct;
            PriceBox.Text = selectedProduct.price.ToString();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            List<Product> productList =ShopEntities1.GetContext().Product.Where(p => p.idProduct == product.idProduct).ToList();
            productList[0].quantityStock = QuantityBox.Text;
            productList[0].description = DescriptionBox.Text;
            productList[0].price = int.Parse(PriceBox.Text);
            productList[0].nameProduct = NameProductBox.Text;
            productList[0].idCategory = ShopEntities1.GetContext().Category.Where(c => c.nameCategory == CategoryBox.Text).ToList()[0].idCategory;
            ShopEntities1.GetContext().SaveChanges();
            MessageBox.Show("Сохранение прошло успешно!");
            Close();

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ShopEntities1.GetContext().Product.Remove(product);
            ShopEntities1.GetContext().SaveChanges();
            MessageBox.Show("Удаление прошло успешно");
            Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
