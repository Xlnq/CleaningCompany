using CleaningCompany.CleaningCompany11DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace CleaningCompany
{
    /// <summary>
    /// Логика взаимодействия для PageKassirChekOrder.xaml
    /// </summary>
    public partial class PageKassirChekOrder : Page
    {
        servicesTableAdapter services = new servicesTableAdapter();
        ordersTableAdapter orders = new ordersTableAdapter();
        infordersTableAdapter inforders= new infordersTableAdapter();
        List<Tovar> uslugi = new List<Tovar>();
        public int Sum = 0;
        public PageKassirChekOrder()
        {
            InitializeComponent();
            myDataGrid.ItemsSource = uslugi;
            ServiceGrid.ItemsSource = services.GetData();
            Id.Visibility = Visibility.Hidden;
            Name.Visibility = Visibility.Hidden;
            Type.Visibility = Visibility.Hidden;
            Price.Visibility = Visibility.Hidden;
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            if (ServiceGrid.SelectedItem != null)
            {
                uslugi.Add(new Tovar {Id =Convert.ToInt32(Id.Text), Name = Name.Text, Type = Convert.ToInt32(Type.Text), Price = Convert.ToInt32(Price.Text)});
                myDataGrid.Items.Refresh();
                Sum += Convert.ToInt32(Price.Text);
                Prices.Text = "Итоговая цена: " + Sum;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int Sdacha = Convert.ToInt32(Vnesenie.Text) - Sum;
            int num = 0;
            var itom = inforders.GetData().Rows;
            for(int i = 0; i < itom.Count; i++)
            {
                num = (int)itom[i][0];
            }

            foreach (var item in uslugi)
            {
                orders.InsertQuery(num, item.Id, item.Name, item.Type, item.Price);
            }



            string path = "C:\\Users\\mrpor\\Desktop\\Чек" + num;
            File.Create(path).Close();
            File.AppendAllText(path, "              Клининговая компания \n");
            File.AppendAllText(path, "         Чек заказа № " + num + "\n");

            foreach (var item in uslugi)
            {
                File.AppendAllText(path, "    " + item.Name + "-" + item.Price + "\n");
            }
            File.AppendAllText(path, "     Итого к оплате: " + Sum + "\n");
            File.AppendAllText(path, "     Внесено: " + Convert.ToInt32(Vnesenie.Text) + "\n");
            File.AppendAllText(path, "     Сдача: " + Sdacha + "\n");

        }
        private void D_Click(object sender, RoutedEventArgs e)
        {
            Tovar selectedTovar = (Tovar)myDataGrid.SelectedItem;
            uslugi.Remove(selectedTovar);
            myDataGrid.Items.Refresh();
            Sum -= Convert.ToInt32(selectedTovar.Price);
            Prices.Text = "Итоговая цена: " + Sum;
        }

        private void ServiceGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ServiceGrid.SelectedItem != null)
            {
                var vibor = ServiceGrid.SelectedItem as DataRowView;
                Id.Text = Convert.ToString(vibor.Row[0]);
                Name.Text = Convert.ToString(vibor.Row[1]);
                Type.Text = Convert.ToString(vibor.Row[3]);
                Price.Text = Convert.ToString(vibor.Row[4]);
            }
        }
    }
}
