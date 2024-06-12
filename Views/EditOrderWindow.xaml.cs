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
    /// Логика взаимодействия для EditOrderWindow.xaml
    /// </summary>
    public partial class EditOrderWindow : Window
    { 
        Order order;
        public EditOrderWindow(Order selectedOrder)
        {
            InitializeComponent();
            order = selectedOrder;
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
            AddresBox.Text = selectedOrder.address;
            QuantityBox.Text = selectedOrder.quantity;


        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ShopEntities1.GetContext().Order.Remove(order);
            ShopEntities1.GetContext().SaveChanges();
            MessageBox.Show("Удаление прошло успешно");
            Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            List<Order> ordertList = ShopEntities1.GetContext().Order.Where(o => o.idOrder == order.idOrder).ToList();
            ordertList[0].quantity = QuantityBox.Text;
            ordertList[0].address = AddresBox.Text;
            ordertList[0].idStatus = ShopEntities1.GetContext().Status.Where(s => s.nameStatus == StatusBox.Text).ToList()[0].idStatus;
            ordertList[0].idProduct = ShopEntities1.GetContext().Product.Where(p => p.nameProduct == ProductBox.Text).ToList()[0].idProduct;
            ShopEntities1.GetContext().SaveChanges();
            MessageBox.Show("Сохранение прошло успешно!");
            Close();
        }


    }
}
