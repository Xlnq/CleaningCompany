using CleaningCompany.CleaningCompany11DataSetTableAdapters;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace CleaningCompany
{
    /// <summary>
    /// Логика взаимодействия для PageAdmOtdel.xaml
    /// </summary>
    public partial class PageAdmOtdel : Page
    {
        otdelTableAdapter otdel = new otdelTableAdapter();
        public PageAdmOtdel()
        {
            InitializeComponent();
            OtdelGrid.ItemsSource = otdel.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id = (int)(OtdelGrid.SelectedItem as DataRowView).Row[0];
            otdel.DeleteQuery(id);

            OtdelGrid.ItemsSource = otdel.GetData();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            otdel.InsertQuery(OtdelName.Text);
            OtdelGrid.ItemsSource = otdel.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (OtdelGrid.SelectedItem != null)
            {
                int id = (int)(OtdelGrid.SelectedItem as DataRowView).Row[0];
                otdel.UpdateQuery(OtdelName.Text, id);
                OtdelGrid.ItemsSource = otdel.GetData();
            }
        }

        private void OtdelGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OtdelGrid.SelectedItem != null)
            {
                var vibor = OtdelGrid.SelectedItem as DataRowView;
                OtdelName.Text = (string)vibor.Row[1];
            }
        }
    }
}
