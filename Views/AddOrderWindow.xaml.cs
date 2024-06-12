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
    /// Логика взаимодействия для AddOrderWindow.xaml
    /// </summary>
    public partial class AddOrderWindow : Window
    {
        public AddOrderWindow()
        {
            InitializeComponent();
            List<Product> products = ShopEntities1.GetContext().Product.ToList();
            List<Status> statuses = ShopEntities1.GetContext().Status.ToList();
            foreach (Product p in products)
            {
                ProductBox.Items.Add(p.nameProduct);
            }

            foreach (Status s in statuses)
            {
                StatusBox.Items.Add(s.nameStatus);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (QuantityBox.Text == string.Empty || AddresBox.Text == string.Empty || StatusBox.Text == string.Empty || ProductBox.Text == string.Empty)
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else
            {
                DB.Order order = new DB.Order();
                order.quantity = QuantityBox.Text;
                order.address = AddresBox.Text;
                order.idStatus = ShopEntities1.GetContext().Status.Where(p => p.nameStatus == StatusBox.Text).ToList()[0].idStatus;
                order.idProduct = ShopEntities1.GetContext().Product.Where(p => p.nameProduct == ProductBox.Text).ToList()[0].idProduct;
                ShopEntities1.GetContext().Order.Add(order);
                ShopEntities1.GetContext().SaveChanges();
                Close();
            }
        }
    }
}
