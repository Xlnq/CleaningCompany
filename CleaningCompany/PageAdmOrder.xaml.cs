using CleaningCompany.CleaningCompany11DataSetTableAdapters;
using System.Windows;
using System.Windows.Controls;
using System;
using System.Data;

namespace CleaningCompany
{
    /// <summary>
    /// Логика взаимодействия для PageAdmOrder.xaml
    /// </summary>
    public partial class PageAdmOrder : Page
    {
        ordersTableAdapter orders = new ordersTableAdapter();
        servicesTableAdapter services = new servicesTableAdapter();
        infordersTableAdapter inforders = new infordersTableAdapter();
        public PageAdmOrder()
        {
            InitializeComponent();
            orderGrid.ItemsSource = orders.GetData();
            IdOrd.ItemsSource = inforders.GetData();
            IdServ.ItemsSource = services.GetData();
            IdType.ItemsSource = services.GetData();
            IdOrd.DisplayMemberPath = "inforder_id";
            IdOrd.SelectedValuePath = "inforder_id";
            IdServ.DisplayMemberPath = "service_name";
            IdServ.SelectedValuePath = "service_id";
            IdType.DisplayMemberPath = "stype_id";
            IdType.SelectedValuePath = "stype_id";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id = (int)(orderGrid.SelectedItem as DataRowView).Row[0];
            orders.DeleteQuery(id);

            orderGrid.ItemsSource = orders.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int idord = (int)(IdOrd.SelectedItem as DataRowView).Row[0];
            int idserv = (int)(IdServ.SelectedItem as DataRowView).Row[0];
            int idtype = (int)(IdType.SelectedItem as DataRowView).Row[0];
            orders.InsertQuery(idord, idserv, Name.Text, idtype, Convert.ToInt32(Cost.Text));
            orderGrid.ItemsSource = orders.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (orderGrid.SelectedItem != null)
            {
                int id = (int)(orderGrid.SelectedItem as DataRowView).Row[0];
                int idord = (int)IdOrd.SelectedValue;
                int idserv = (int)IdServ.SelectedValue;
                int idtype = (int)IdType.SelectedValue;
                orders.UpdateQuery(idord, idserv, Name.Text, idtype, Convert.ToInt32(Cost.Text), id);
                orderGrid.ItemsSource = orders.GetData();
            }
        }

        private void orderGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (orderGrid.SelectedItem != null)
            {
                var vibor = orderGrid.SelectedItem as DataRowView;
                IdOrd.SelectedValue = (int)vibor.Row[1];
                IdServ.SelectedValue = (int)vibor.Row[2];
                Name.Text = Convert.ToString(vibor.Row[3]);
                IdType.SelectedValue = (int)vibor.Row[4];
                Cost.Text = Convert.ToString(vibor.Row[5]);
            }
        }
    }
}
