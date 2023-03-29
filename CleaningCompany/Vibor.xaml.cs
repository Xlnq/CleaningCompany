using System;
using System.Collections.Generic;
using System.Data;
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
using System.Xml;

namespace CleaningCompany
{
    public partial class Vibor : Page
    {
        public Vibor()
        {
            InitializeComponent();
            ViborTabl.Items.Add("Роли");
            ViborTabl.Items.Add("Услуги");
            ViborTabl.Items.Add("Работники");
            ViborTabl.Items.Add("Категория работников");
            ViborTabl.Items.Add("Оборудование");
            ViborTabl.Items.Add("Пользователи");
            ViborTabl.Items.Add("Информация о чеке");
            ViborTabl.Items.Add("Чек");
            ViborTabl.Items.Add("Тип услуги");
            ViborTabl.Items.Add("Отделы");
            ViborTab.Content = new PageAdmRole();
        }

        private void ViborTabl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                if (ViborTabl.SelectedIndex == 0)
                {
                    ViborTab.Content = new PageAdmRole();
                }
                if (ViborTabl.SelectedIndex == 1)
                {
                    ViborTab.Content = new PageAdmServices();
                }
                if (ViborTabl.SelectedIndex == 2)
                {
                    ViborTab.Content = new PageAdmEmployees();
                }
                if (ViborTabl.SelectedIndex == 3)
                {
                    ViborTab.Content = new PageAdmEmployeesCategory();
                }
                if (ViborTabl.SelectedIndex == 4)
                {
                    ViborTab.Content = new PageAdmEquipment();
                }
                if (ViborTabl.SelectedIndex == 5)
                {
                    ViborTab.Content = new PageAdmUser();
                }
                if (ViborTabl.SelectedIndex == 6)
                {
                    ViborTab.Content = new PageAdmInfOrder();
                }
                if (ViborTabl.SelectedIndex == 7)
                {
                    ViborTab.Content = new PageAdmOrder();
                }
                if (ViborTabl.SelectedIndex == 8)
                {
                    ViborTab.Content = new PageAdmStype();
                }
                if (ViborTabl.SelectedIndex == 9)
                {
                    ViborTab.Content = new PageAdmOtdel();
                }
        }

        private void Auth_Click(object sender, RoutedEventArgs e)
        {
            ViborTab.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            ViborTabl.Visibility = Visibility.Hidden;
            Auth.Visibility = Visibility.Hidden;
            ViborTab.Content = new PageLogin();
        }
    }
}
