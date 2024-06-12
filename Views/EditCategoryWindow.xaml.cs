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
    /// Логика взаимодействия для EditCategoryWindow.xaml
    /// </summary>
    public partial class EditCategoryWindow : Window
    {
        
        Category category;
        public EditCategoryWindow(Category selectedCategory)
        {
            InitializeComponent();
            category = selectedCategory;
            CategoryBox.Text = selectedCategory.nameCategory;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            List<Category> categoryList = ShopEntities1.GetContext().Category.Where(c => c.idCategory == category.idCategory).ToList();
            categoryList[0].nameCategory = CategoryBox.Text;
            ShopEntities1.GetContext().SaveChanges();
            MessageBox.Show("Сохранение прошло успешно!");
            Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ShopEntities1.GetContext().Category.Remove(category);
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
