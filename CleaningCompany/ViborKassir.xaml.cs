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

namespace CleaningCompany
{
    /// <summary>
    /// Логика взаимодействия для ViborKassir.xaml
    /// </summary>
    public partial class ViborKassir : Page
    {
        public ViborKassir()
        {
            InitializeComponent();
            Vibor.Items.Add("Чек");
            Vibor.Items.Add("Заказы");
            Vibor.Items.Add("Информация о чеках");
            PageFrameVibor2.Content = new PageKassirChekOrder();
        }

        private void Vibor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Vibor.SelectedIndex == 0)
            {
                PageFrameVibor2.Content = new PageKassirChekOrder();
            }
            if (Vibor.SelectedIndex == 1)
            {
                PageFrameVibor2.Content = new PageAdmInfOrder();
            }
            if (Vibor.SelectedIndex == 2)
            {
                PageFrameVibor2.Content = new PageKassirChekInfo();
            }
        }

        private void Auth_Click(object sender, RoutedEventArgs e)
        {
            PageFrameVibor2.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            Vibor.Visibility = Visibility.Hidden;
            Auth.Visibility= Visibility.Hidden;
            PageFrameVibor2.Content = new PageLogin();
        }
    }
}
