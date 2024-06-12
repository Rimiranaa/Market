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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            Table.ItemsSource = ShopEntities1.GetContext().Order.ToList();
            Clients.ItemsSource = ShopEntities1.GetContext().Client.ToList();

        }

        private void Client_Click(object sender, RoutedEventArgs e)
        {
            Client selectedClient = (Client)Clients.SelectedItem;
            if(selectedClient == null)
            {
                MessageBox.Show("Выберите элемент для редактирования!");
            }
            else
            {
                EditClientWindow editClientWindow = new EditClientWindow(selectedClient);
                editClientWindow.ShowDialog();
            }
            Table.ItemsSource = null;
            Clients.ItemsSource = null;
            Table.ItemsSource = ShopEntities1.GetContext().Order.ToList();
            Clients.ItemsSource = ShopEntities1.GetContext().Client.ToList();
        }


        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Order selectedOrder = (Order)Table.SelectedItem;
            if(selectedOrder == null)
            {
                MessageBox.Show("Выберите элемент для редактирования!");
            }

            else
            {
                EditOrderWindow editOrderWindow = new EditOrderWindow(selectedOrder);
                editOrderWindow.ShowDialog();
            }
            Table.ItemsSource = null;
            Clients.ItemsSource = null;
            Table.ItemsSource = ShopEntities1.GetContext().Order.ToList();
            Clients.ItemsSource = ShopEntities1.GetContext().Client.ToList();

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Window_Click(object sender, RoutedEventArgs e)
        {
            ProductAndCategoryxaml productAndCategory = new ProductAndCategoryxaml();
            productAndCategory.Show();
            Close();
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            AddOrderWindow addOrderWindow = new AddOrderWindow();
            addOrderWindow.ShowDialog();
            Table.ItemsSource = null;
            Clients.ItemsSource = null;
            Table.ItemsSource = ShopEntities1.GetContext().Order.ToList();
            Clients.ItemsSource = ShopEntities1.GetContext().Client.ToList();
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClientWindow = new AddClientWindow();
            addClientWindow.ShowDialog();
            Table.ItemsSource = null;
            Clients.ItemsSource = null;
            Table.ItemsSource = ShopEntities1.GetContext().Order.ToList();
            Clients.ItemsSource = ShopEntities1.GetContext().Client.ToList();
        }
    }
}
