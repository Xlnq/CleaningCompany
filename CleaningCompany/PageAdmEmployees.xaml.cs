using CleaningCompany.CleaningCompany11DataSetTableAdapters;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace CleaningCompany
{
    /// <summary>
    /// Логика взаимодействия для PageAdmEmployees.xaml
    /// </summary>
    public partial class PageAdmEmployees : Page
    {
        employeesTableAdapter employees = new employeesTableAdapter();
        employee_categoriesTableAdapter employeesC = new employee_categoriesTableAdapter();
        otdelTableAdapter otdelC = new otdelTableAdapter();
        public PageAdmEmployees()
        {
            InitializeComponent();
            employeesGrid.ItemsSource = employees.GetData();
            EmployeesCGrid.ItemsSource = employeesC.GetData();
            OtdelGrid.ItemsSource = otdelC.GetData();
            OtdelGrid.DisplayMemberPath = "otdel_name";
            OtdelGrid.SelectedValuePath = "otdel_id";
            EmployeesCGrid.DisplayMemberPath = "category_name";
            EmployeesCGrid.SelectedValuePath = "category_id";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id = (int)(employeesGrid.SelectedItem as DataRowView).Row[0];
            employees.DeleteQuery(id);

            employeesGrid.ItemsSource = employees.GetData();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int idempl = (int)(employeesGrid.SelectedItem as DataRowView).Row[0];
            int idotdel = (int)(OtdelGrid.SelectedItem as DataRowView).Row[0];
            employees.InsertQuery(EmployeesName.Text, idempl, idotdel);
            employeesGrid.ItemsSource = employees.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (employeesGrid.SelectedItem != null)
            {
                int id = (int)(employeesGrid.SelectedItem as DataRowView).Row[0];
                int idcategory = (int)EmployeesCGrid.SelectedValue;
                int idotdel = (int)OtdelGrid.SelectedValue;
                employees.UpdateQuery(EmployeesName.Text, idcategory, idotdel, id);
                employeesGrid.ItemsSource = employees.GetData();
            }
        }

        private void employeesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (employeesGrid.SelectedItem != null)
            {
                var vibor = employeesGrid.SelectedItem as DataRowView;
                EmployeesName.Text = (string)vibor.Row[1];
                EmployeesCGrid.SelectedValue = (int)vibor.Row[2];
                if (vibor.Row[3].ToString() != "")
                {
                    OtdelGrid.SelectedValue = (int)vibor.Row[3];
                }
            }
        }
    }
}
