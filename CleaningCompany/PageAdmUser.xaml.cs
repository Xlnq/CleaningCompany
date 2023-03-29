using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using CleaningCompany.CleaningCompany11DataSetTableAdapters;

namespace CleaningCompany
{
    /// <summary>
    /// Логика взаимодействия для PageAdmUser.xaml
    /// </summary>
    public partial class PageAdmUser : Page
    {
        usersTableAdapter user = new usersTableAdapter();
        roleTableAdapter role = new roleTableAdapter();
        public PageAdmUser()
        {
            InitializeComponent();
            usersGrid.ItemsSource = user.GetData();
            Idrole.ItemsSource = role.GetData();
            Idrole.DisplayMemberPath = "role_name";
            Idrole.SelectedValuePath = "role_id";

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (usersGrid.SelectedItem != null)
            {
                int id = (int)(usersGrid.SelectedItem as DataRowView).Row[0];
                int idrole = (int)Idrole.SelectedValue;
                user.UpdateQuery(Login.Text, Password.Text, idrole, id);
                usersGrid.ItemsSource = user.GetData();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id = (int)(usersGrid.SelectedItem as DataRowView).Row[0];
            user.DeleteQuery(id);

            usersGrid.ItemsSource = user.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int idrole = (int)(usersGrid.SelectedItem as DataRowView).Row[0];
            user.InsertQuery(Login.Text, Password.Text, idrole);
            usersGrid.ItemsSource = user.GetData();
        }

        private void usersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (usersGrid.SelectedItem != null)
            {
                var vibor = usersGrid.SelectedItem as DataRowView;
                Login.Text = (string)vibor.Row[1];
                Password.Text = (string)vibor.Row[2];
                Idrole.SelectedValue = (int)vibor.Row[3];
            }
        }
    }
}
