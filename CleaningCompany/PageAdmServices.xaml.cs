using CleaningCompany.CleaningCompany11DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CleaningCompany
{
    /// <summary>
    /// Логика взаимодействия для PageAdmServices.xaml
    /// </summary>
    public partial class PageAdmServices : Page
    {
        servicesTableAdapter services = new servicesTableAdapter();
        employeesTableAdapter employees = new employeesTableAdapter(); 
        services_typeTableAdapter services_type = new services_typeTableAdapter();
        equipmentTableAdapter equipment = new equipmentTableAdapter();
        public PageAdmServices()
        {
            InitializeComponent();
            servicesGrid.ItemsSource = services.GetData();
            EmployeesGrid.ItemsSource = employees.GetData();
            StypeGrid.ItemsSource = services_type.GetData();
            EquipmentGrid.ItemsSource = equipment.GetData();
            StypeGrid.DisplayMemberPath = "stype_name";
            StypeGrid.SelectedValuePath = "stype_id";
            EmployeesGrid.DisplayMemberPath = "employee_name";
            EmployeesGrid.SelectedValuePath = "employee_id";
            EquipmentGrid.DisplayMemberPath = "equipment_name";
            EquipmentGrid.SelectedValuePath = "equipment_id";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int id = (int)(servicesGrid.SelectedItem as DataRowView).Row[0];
            services.DeleteQuery(id);

            servicesGrid.ItemsSource = services.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int idstype = (int)(StypeGrid.SelectedItem as DataRowView).Row[0];
            int idequipment = (int)(EquipmentGrid.SelectedItem as DataRowView).Row[0];
            int idemployees = (int)(EmployeesGrid.SelectedItem as DataRowView).Row[0];
            services.InsertQuery(ServiceGrid.Text, idequipment, idstype, Convert.ToInt32(CostGrid.Text), idemployees);
            servicesGrid.ItemsSource = services.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (servicesGrid.SelectedItem != null)
            {
                int id = (int)(servicesGrid.SelectedItem as DataRowView).Row[0];
                int idemployees = (int)EmployeesGrid.SelectedValue;
                int idequipment = (int)EquipmentGrid.SelectedValue;
                int idstype = (int)StypeGrid.SelectedValue;
                services.UpdateQuery(ServiceGrid.Text, idequipment, idstype, Convert.ToInt32(CostGrid.Text), idemployees,id);
                servicesGrid.ItemsSource = employees.GetData();
            }
        }

        private void servicesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (servicesGrid.SelectedItem != null)
            {
                var vibor = servicesGrid.SelectedItem as DataRowView;
                ServiceGrid.Text = (string)vibor.Row[1];
                EquipmentGrid.SelectedValue = (int)vibor.Row[2]; 
                StypeGrid.SelectedValue = (int)vibor.Row[3];
                CostGrid.Text = Convert.ToString(vibor.Row[4]);
                EmployeesGrid.SelectedValue = (int)vibor.Row[5]; 
            }
        }
    }
}
