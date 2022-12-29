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

namespace Encryption
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }
        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TextBlock selectedItem = (TextBlock)comboBox.SelectedItem;
            if (selectedItem.Text == "Магические квадраты")
            {
                NavigationService.Navigate(new magicPage());
            }
            if (selectedItem.Text == "Полибианский квадрат")
            {
                NavigationService.Navigate(new polibPage());
            }
            if (selectedItem.Text == "Шифр Гронсфельда")
            {
                NavigationService.Navigate(new gronsfieldPage());
            }
        }
    }
}
