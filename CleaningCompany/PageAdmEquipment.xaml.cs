using CleaningCompany.CleaningCompany11DataSetTableAdapters;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;

namespace CleaningCompany
{
    /// <summary>
    /// Логика взаимодействия для PageAdmEquipment.xaml
    /// </summary>
    public partial class PageAdmEquipment : Page
    {
        equipmentTableAdapter equipment = new equipmentTableAdapter();
        public PageAdmEquipment()
        {
            InitializeComponent();
            equipmentGrid.ItemsSource = equipment.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id = (int)(equipmentGrid.SelectedItem as DataRowView).Row[0];
            equipment.DeleteQuery(id);

            equipmentGrid.ItemsSource = equipment.GetData();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            equipment.InsertQuery(EquipmentName.Text, EquipmentDescription.Text);
            equipmentGrid.ItemsSource = equipment.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (equipmentGrid.SelectedItem != null)
            {
                int id = (int)(equipmentGrid.SelectedItem as DataRowView).Row[0];
                equipment.UpdateQuery(EquipmentName.Text, EquipmentDescription.Text, id);
                equipmentGrid.ItemsSource = equipment.GetData();
            }
        }

        private void equipmentGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (equipmentGrid.SelectedItem != null)
            {
                var vibor = equipmentGrid.SelectedItem as DataRowView;
                EquipmentName.Text = (string)vibor.Row[1];
                EquipmentDescription.Text = (string)vibor.Row[2];
            }
        }
    }
}
