using Market.DB;
using Market.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Market
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Registr_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            if (LoginBox.Text == string.Empty || PasswordBox.Text == string.Empty)
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else
            {
                List<Users> users = ShopEntities1.GetContext().Users.ToList();
                foreach (Users u in users)
                {
                    if (LoginBox.Text == u.login && PasswordBox.Text == u.password)
                    {
                        MessageBox.Show("Данный пользователь уже существует");
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    Users user = new Users();
                    user.login = LoginBox.Text;
                    user.password = PasswordBox.Text;
                    user.idRole = 1;

                    ShopEntities1.GetContext().Users.Add(user);
                    ShopEntities1.GetContext().SaveChanges();
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    Close();
                }
            }
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            if (LoginBox.Text == string.Empty || PasswordBox.Text == string.Empty)
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else
            {
                List<Users> users = ShopEntities1.GetContext().Users.ToList();
                foreach (Users u in users)
                {
                    if (LoginBox.Text == u.login && PasswordBox.Text == u.password)
                    {
                        flag = true;
                        if (u.idRole == 1)
                        {
                            AdminWindow adminWindow = new AdminWindow();
                            adminWindow.Show();
                            Close();
                            break;
                        }

                    }
                }
                if (flag == false)
                {
                    MessageBox.Show("Логин или пароль неверны");
                }
            }
        }
    }
}
