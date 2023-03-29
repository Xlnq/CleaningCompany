using CleaningCompany.CleaningCompany11DataSetTableAdapters;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace CleaningCompany
{
    /// <summary>
    /// Логика взаимодействия для PageAdmEmployeesCategory.xaml
    /// </summary>
    public partial class PageAdmEmployeesCategory : Page
    {
        employee_categoriesTableAdapter employees = new employee_categoriesTableAdapter();
        public PageAdmEmployeesCategory()
        {
            InitializeComponent();
            employeescategoryGrid.ItemsSource = employees.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id = (int)(employeescategoryGrid.SelectedItem as DataRowView).Row[0];
            employees.DeleteQuery(id);

            employeescategoryGrid.ItemsSource = employees.GetData();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            employees.InsertQuery(EmployeesName.Text);
            employeescategoryGrid.ItemsSource = employees.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (employeescategoryGrid.SelectedItem != null)
            {
                int id = (int)(employeescategoryGrid.SelectedItem as DataRowView).Row[0];
                employees.UpdateQuery(EmployeesName.Text, id);
                employeescategoryGrid.ItemsSource = employees.GetData();
            }
        }

        private void employeescategoryGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (employeescategoryGrid.SelectedItem != null)
            {
                var vibor = employeescategoryGrid.SelectedItem as DataRowView;
                EmployeesName.Text = (string)vibor.Row[1];
            }
        }
    }
}
