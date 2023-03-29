using CleaningCompany.CleaningCompany11DataSetTableAdapters;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace CleaningCompany
{
    public partial class PageAdmStype : Page
    {
        services_typeTableAdapter stype = new services_typeTableAdapter();
        public PageAdmStype()
        {
            InitializeComponent();
            stypeGrid.ItemsSource = stype.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id = (int)(stypeGrid.SelectedItem as DataRowView).Row[0];
            stype.DeleteQuery(id);

            stypeGrid.ItemsSource = stype.GetData();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            stype.InsertQuery(StypeName.Text);
            stypeGrid.ItemsSource = stype.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (stypeGrid.SelectedItem != null)
            {
                int id = (int)(stypeGrid.SelectedItem as DataRowView).Row[0];
                stype.UpdateQuery(StypeName.Text, id);
                stypeGrid.ItemsSource = stype.GetData();
            }
        }

        private void equipmentGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (stypeGrid.SelectedItem != null)
            {
                var vibor = stypeGrid.SelectedItem as DataRowView;
                StypeName.Text = (string)vibor.Row[1];
            }
        }
    }
}
