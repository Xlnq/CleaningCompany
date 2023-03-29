using System.Data;
using System.Windows;
using System.Windows.Controls;
using CleaningCompany.CleaningCompany11DataSetTableAdapters;

namespace CleaningCompany
{
    /// <summary>
    /// Логика взаимодействия для PageAdmRole.xaml
    /// </summary>
    public partial class PageAdmRole : Page
    {
        roleTableAdapter role = new roleTableAdapter();
        public PageAdmRole()
        {
            InitializeComponent();
            roleGrid.ItemsSource = role.GetData();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id = (int)(roleGrid.SelectedItem as DataRowView).Row[0];
            role.DeleteQuery(id);

            roleGrid.ItemsSource = role.GetData();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            role.InsertQuery(RoleName.Text);
            roleGrid.ItemsSource = role.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (roleGrid.SelectedItem != null)
            {
                int id = (int)(roleGrid.SelectedItem as DataRowView).Row[0];
                role.UpdateQuery(RoleName.Text,id);
                roleGrid.ItemsSource = role.GetData();
            }
        }

        private void roleGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (roleGrid.SelectedItem != null)
            {
                var vibor = roleGrid.SelectedItem as DataRowView;
                RoleName.Text = (string)vibor.Row[1];

            }
        }
    }
}
