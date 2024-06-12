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
    /// Логика взаимодействия для EditClientWindow.xaml
    /// </summary>
    public partial class EditClientWindow : Window
    {
        Client client;

        public EditClientWindow(Client selectedClient)
        {
            InitializeComponent();
            FullNameBox.Text = selectedClient.FullName;
            PhoneBox.Text = selectedClient.Phone;
            client = selectedClient;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            List<Client> clientList = ShopEntities1.GetContext().Client.Where(c => c.idClient == client.idClient).ToList();
            clientList[0].FullName = FullNameBox.Text;
            clientList[0].Phone = PhoneBox.Text;
            ShopEntities1.GetContext().SaveChanges();
            MessageBox.Show("Сохранение прошло успешно!");
            Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ShopEntities1.GetContext().Client.Remove(client);
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
