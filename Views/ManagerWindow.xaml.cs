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
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public ManagerWindow()
        {
            InitializeComponent();
            Table.ItemsSource = ShopEntities1.GetContext().Order.ToList();
            Clients.ItemsSource = ShopEntities1.GetContext().Client.ToList();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Order selectedOrder = (Order)Table.SelectedItem;
            if (selectedOrder == null)
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
            ProductAndCategoryM productAndCategoryM = new ProductAndCategoryM();
            productAndCategoryM.Show();
            Close();
        }
    }
}
