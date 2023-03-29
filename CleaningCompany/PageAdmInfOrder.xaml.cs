using CleaningCompany.CleaningCompany11DataSetTableAdapters;
using System.Data;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace CleaningCompany
{
    /// <summary>
    /// Логика взаимодействия для PageAdmInfOrder.xaml
    /// </summary>
    public partial class PageAdmInfOrder : Page
    {
        infordersTableAdapter inforder = new infordersTableAdapter();
        usersTableAdapter usersTableAdapter = new usersTableAdapter();
        public PageAdmInfOrder()
        {
            InitializeComponent();
            inforderGrid.ItemsSource = inforder.GetData();
            User.ItemsSource = usersTableAdapter.GetData();
            User.DisplayMemberPath = "users_login";
            User.SelectedValuePath = "users_id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime data = Convert.ToDateTime(Date.Text);
            int iduser = (int)(User.SelectedItem as DataRowView).Row[0];
            inforder.InsertQuery(iduser ,data.ToShortDateString());
            inforderGrid.ItemsSource = inforder.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id = (int)(inforderGrid.SelectedItem as DataRowView).Row[0];
            inforder.DeleteQuery(id);

            inforderGrid.ItemsSource = inforder.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(inforderGrid.SelectedItem != null)
            {
                DateTime data = Convert.ToDateTime(Date.Text);
                int id = (int)(inforderGrid.SelectedItem as DataRowView).Row[0];
                int iduser = (int)User.SelectedValue;
                inforder.UpdateQuery(iduser, data.ToShortDateString(), id);
                inforderGrid.ItemsSource = inforder.GetData();
            }
        }

        private void inforderGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (inforderGrid.SelectedItem != null)
            {
                var vibor = inforderGrid.SelectedItem as DataRowView;
                Date.Text = Convert.ToString(vibor.Row[2]);
                User.SelectedValue = (int)vibor.Row[1];
            }
        }
    }
}
